using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mineswapper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private static MainForm _mainForm = new MainForm();

        private void MainForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.MineswapperICO;
            _mainForm = this;
            MainGlControl.Hide();
            ResultRichTextBox.Hide();
            TexturesUtils.LoadTextures();
        }

        public static void SetMainGlControlSize(int wight, int height)
        {
            _mainForm.MainGlControl.Width = wight * 32 + 2;
            _mainForm.MainGlControl.Height = height * 32 + 2;
            _mainForm.MinimumSize = _mainForm.MaximumSize = _mainForm.Size = new Size(_mainForm.MainGlControl.Width + 40, _mainForm.MainGlControl.Height + 60);
            _mainForm.SetupViewport();
        }

        private void SetupViewport()
        {
            int w = MainGlControl.Width;
            int h = MainGlControl.Height;
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1); // Верхний левый угол имеет кооординаты(0, 0)
            GL.Viewport(0, 0, w, h); // Использовать всю поверхность GLControl под рисование
        }

        private void MainGlControl_Paint(object sender, PaintEventArgs e)
        {
            RedrawField(true);
        }

        private async Task ShowGameResult(EnumData.EGameResult result)
        {
            await Task.Factory.StartNew(() =>
            {
                if (result == EnumData.EGameResult.None) return;
                BeginInvoke(new Action(() =>
                {
                    ResultRichTextBox.Font = new Font("Segoe UI", (int)(FieldData.CellsCountHeight * 4));
                }));
                switch (result)
                {
                    case EnumData.EGameResult.Win:
                        BeginInvoke(new Action(() =>
                        {
                            ResultRichTextBox.ForeColor = Color.DarkGreen;
                            ResultRichTextBox.Text = "Вы\nпобедили!";
                        }));
                        break;

                    case EnumData.EGameResult.Lose:
                        BeginInvoke(new Action(() =>
                        {
                            ResultRichTextBox.ForeColor = Color.DarkRed;
                            ResultRichTextBox.Text = "Вы\nпроиграли!";
                        }));
                        break;
                }
                FieldUtils.OpenAllCells();
                BeginInvoke(new Action(() =>
                {
                    ResultRichTextBox.Show();
                }));

                do
                {
                    Thread.Sleep(100);
                } while (ResultRichTextBox.Visible);
            });
        }

        private async void RedrawField(bool fromControl)
        {
            if (!MainGlControl.Created) return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadIdentity();
            if (!fromControl)
                if (FieldData.FullyOpened)
                {
                    MainGlControl.Hide();
                    return;
                }

            if (!fromControl)
                await ShowGameResult(FieldUtils.CheckGameResult());

            int x = 2;
            int y = 2;
            int cellSize = 30;

            for (int cellX = 0; cellX < FieldData.CellsCountWight; cellX++)
            {
                int tempY = y;
                for (int cellY = 0; cellY < FieldData.CellsCountHeight; cellY++)
                {
                    Color color = Color.DarkGray;
                    int textureId = 0;

                    if (FieldData.FieldArray[cellX, cellY].Marked)
                    {
                        textureId = (int)EnumData.ETexturesTypes.Mark;
                        color = Color.Gold;
                    }

                    if (FieldData.FieldArray[cellX, cellY].Opened)
                    {
                        color = Color.White;
                        if (FieldData.FieldArray[cellX, cellY].Mined)
                        {
                            textureId = (int)EnumData.ETexturesTypes.Mine;
                            //color = FieldData.Completed ? Color.Green : Color.Red;
                            color = FieldData.FieldArray[cellX, cellY].Mined &&
                                    FieldData.FieldArray[cellX, cellY].Marked
                                ? Color.Green
                                : Color.Red;
                        }
                        if (FieldData.FieldArray[cellX, cellY].MinesNear > 0)
                        {
                            textureId = FieldData.FieldArray[cellX, cellY].MinesNear;
                        }
                    }

                    DrawField(new PointF(x, y), new Size(cellSize, cellSize), textureId, color);
                    y = y + cellSize + 2;
                }
                x = x + cellSize + 2;
                y = tempY;
            }
            MainGlControl.SwapBuffers();
        }

        private void MainGlControl_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = MainGlControl.Height - e.Y;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (FieldData.Closed)
                    {
                        FieldUtils.FillField(x / 32, y / 32);
                        FieldData.Closed = false;
                    }
                    FieldUtils.OpenCell(x / 32, y / 32);
                    RedrawField(false);
                    break;

                case MouseButtons.Right:
                    FieldUtils.MarkCell(x / 32, y / 32);
                    RedrawField(false);
                    break;
            }
        }

        private void DrawField(PointF point, Size size, int texture, Color color)
        {
            GL.PushMatrix();

            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.Begin(PrimitiveType.Quads);
            if (!color.IsEmpty)
                GL.Color3(color);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(point.X, point.Y);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(point.X + size.Width, point.Y);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(point.X + size.Width, point.Y + size.Height);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(point.X, point.Y + size.Height);
            GL.End();
            GL.PopMatrix();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //DifficultyComboBox.Location.Offset(new Point(_mForm.Width / 2 - 70, _mForm.Height / 2 - 10));

            //RedrawField();
        }

        private void Easy_Click(object sender, EventArgs e)
        {
            FieldData.FullyOpened = false;
            FieldData.Closed = true;
            FieldUtils.GenerateEmptyField(EnumData.EDifficulty.Easy);
            MainGlControl.Show();
            RedrawField(false);
        }

        private void Normal_Click(object sender, EventArgs e)
        {
            FieldData.FullyOpened = false;
            FieldData.Closed = true;
            FieldUtils.GenerateEmptyField(EnumData.EDifficulty.Normal);
            MainGlControl.Show();
            RedrawField(false);
        }

        private void Hard_Click(object sender, EventArgs e)
        {
            FieldData.FullyOpened = false;
            FieldData.Closed = true;
            FieldUtils.GenerateEmptyField(EnumData.EDifficulty.Hard);
            MainGlControl.Show();
            RedrawField(false);
        }

        private void Impossible_Click(object sender, EventArgs e)
        {
            FieldData.FullyOpened = false;
            FieldData.Closed = true;
            FieldUtils.GenerateEmptyField(EnumData.EDifficulty.Impossible);
            MainGlControl.Show();
            RedrawField(false);
        }

        private void ResultRichTextBox_TextChanged(object sender, EventArgs e)
        {
            ResultRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void ResultRichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            ResultRichTextBox.Hide();
            ResultRichTextBox.Clear();
        }
    }
}