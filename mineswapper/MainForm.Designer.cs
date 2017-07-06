namespace mineswapper
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainGlControl = new OpenTK.GLControl();
            this.Easy = new System.Windows.Forms.Button();
            this.Normal = new System.Windows.Forms.Button();
            this.Hard = new System.Windows.Forms.Button();
            this.ResultRichTextBox = new System.Windows.Forms.RichTextBox();
            this.Impossible = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainGlControl
            // 
            this.MainGlControl.BackColor = System.Drawing.Color.Black;
            this.MainGlControl.Location = new System.Drawing.Point(12, 12);
            this.MainGlControl.Name = "MainGlControl";
            this.MainGlControl.Size = new System.Drawing.Size(290, 290);
            this.MainGlControl.TabIndex = 0;
            this.MainGlControl.VSync = false;
            this.MainGlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.MainGlControl_Paint);
            this.MainGlControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainGlControl_MouseClick);
            // 
            // Easy
            // 
            this.Easy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Easy.BackColor = System.Drawing.Color.White;
            this.Easy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Easy.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Easy.ForeColor = System.Drawing.Color.Green;
            this.Easy.Location = new System.Drawing.Point(13, 13);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(288, 67);
            this.Easy.TabIndex = 2;
            this.Easy.Text = "Легко";
            this.Easy.UseVisualStyleBackColor = false;
            this.Easy.Click += new System.EventHandler(this.Easy_Click);
            // 
            // Normal
            // 
            this.Normal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Normal.BackColor = System.Drawing.Color.White;
            this.Normal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Normal.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Normal.ForeColor = System.Drawing.Color.Orange;
            this.Normal.Location = new System.Drawing.Point(13, 86);
            this.Normal.Name = "Normal";
            this.Normal.Size = new System.Drawing.Size(288, 67);
            this.Normal.TabIndex = 3;
            this.Normal.Text = "Нормально";
            this.Normal.UseVisualStyleBackColor = false;
            this.Normal.Click += new System.EventHandler(this.Normal_Click);
            // 
            // Hard
            // 
            this.Hard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Hard.BackColor = System.Drawing.Color.White;
            this.Hard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Hard.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Hard.ForeColor = System.Drawing.Color.Red;
            this.Hard.Location = new System.Drawing.Point(12, 159);
            this.Hard.Name = "Hard";
            this.Hard.Size = new System.Drawing.Size(288, 67);
            this.Hard.TabIndex = 4;
            this.Hard.Text = "Сложно";
            this.Hard.UseVisualStyleBackColor = false;
            this.Hard.Click += new System.EventHandler(this.Hard_Click);
            // 
            // ResultRichTextBox
            // 
            this.ResultRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultRichTextBox.BackColor = System.Drawing.Color.AliceBlue;
            this.ResultRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ResultRichTextBox.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultRichTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ResultRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.ResultRichTextBox.Name = "ResultRichTextBox";
            this.ResultRichTextBox.ReadOnly = true;
            this.ResultRichTextBox.Size = new System.Drawing.Size(290, 290);
            this.ResultRichTextBox.TabIndex = 5;
            this.ResultRichTextBox.Text = "";
            this.ResultRichTextBox.SelectionChanged += new System.EventHandler(this.ResultRichTextBox_SelectionChanged);
            this.ResultRichTextBox.TextChanged += new System.EventHandler(this.ResultRichTextBox_TextChanged);
            // 
            // Impossible
            // 
            this.Impossible.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Impossible.BackColor = System.Drawing.Color.White;
            this.Impossible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Impossible.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Impossible.ForeColor = System.Drawing.Color.Maroon;
            this.Impossible.Location = new System.Drawing.Point(12, 232);
            this.Impossible.Name = "Impossible";
            this.Impossible.Size = new System.Drawing.Size(288, 67);
            this.Impossible.TabIndex = 6;
            this.Impossible.Text = "Невозможно";
            this.Impossible.UseVisualStyleBackColor = false;
            this.Impossible.Click += new System.EventHandler(this.Impossible_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(314, 311);
            this.Controls.Add(this.ResultRichTextBox);
            this.Controls.Add(this.MainGlControl);
            this.Controls.Add(this.Impossible);
            this.Controls.Add(this.Hard);
            this.Controls.Add(this.Normal);
            this.Controls.Add(this.Easy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(330, 350);
            this.Name = "MainForm";
            this.Text = "Mineswapper";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl MainGlControl;
        private System.Windows.Forms.Button Easy;
        private System.Windows.Forms.Button Normal;
        private System.Windows.Forms.Button Hard;
        private System.Windows.Forms.RichTextBox ResultRichTextBox;
        private System.Windows.Forms.Button Impossible;
    }
}

