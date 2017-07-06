using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mineswapper
{
    internal class FieldUtils
    {
        public static void GenerateEmptyField(EnumData.EDifficulty difficulty)
        {
            int cellsWight = 0;
            int cellsHeight = 0;
            FieldData.Difficulty = difficulty;
            int mines = 0;
            switch (FieldData.Difficulty)
            {
                case EnumData.EDifficulty.Easy:
                    cellsWight = cellsHeight = 9;
                    break;

                case EnumData.EDifficulty.Normal:
                    cellsWight = cellsHeight = 16;
                    break;

                case EnumData.EDifficulty.Hard:
                    cellsWight = 30;
                    cellsHeight = 16;
                    break;

                case EnumData.EDifficulty.Impossible:
                    cellsWight = 50;
                    cellsHeight = 30;
                    break;
            }
            MainForm.SetMainGlControlSize(cellsWight, cellsHeight);
            FieldData.MinesCount
                     = (int)Math.Round(cellsWight * cellsHeight * ((10 + Convert.ToDouble($"{cellsWight * cellsHeight}") / 50) / 100), MidpointRounding.AwayFromZero);
            FieldData.FieldArray = new FieldData.FieldItem[cellsWight, cellsHeight];
            FieldData.CellsCountWight = cellsWight;
            FieldData.CellsCountHeight = cellsHeight;
            for (int x = 0; x < FieldData.CellsCountWight; x++)
            {
                for (int y = 0; y < FieldData.CellsCountHeight; y++)
                {
                    FieldData.FieldArray[x, y] = new FieldData.FieldItem(false, false, false, 0);
                }
            }
        }

        public static void FillField(int sX, int sY)
        {
            int mines = FieldData.MinesCount;
            Random rnd = new Random();
            do
            {
                for (int x = 0; x < FieldData.CellsCountWight; x++)
                {
                    for (int y = 0; y < FieldData.CellsCountHeight; y++)
                    {
                        if (mines == 0) break;
                        var num = rnd.Next(0, 5);
                        if (num == 4 && x != sX && y != sY)
                        {
                            FieldData.FieldArray[x, y].Mined = true;
                            mines--;
                        }
                    }
                }
            } while (mines != 0);

            for (int x = 0; x < FieldData.CellsCountWight; x++)
            {
                for (int y = 0; y < FieldData.CellsCountHeight; y++)
                {
                    if (FieldData.FieldArray[x, y].Mined)
                    {
                        FieldData.FieldArray[x, y].MinesNear = -1;
                        continue;
                    }
                    int minesNear = 0;
                    if (x - 1 >= 0)
                        if (FieldData.FieldArray[x - 1, y].Mined) minesNear++;
                    if (x - 1 >= 0 && y + 1 < FieldData.CellsCountHeight)
                        if (FieldData.FieldArray[x - 1, y + 1].Mined) minesNear++;
                    if (y + 1 < FieldData.CellsCountHeight)
                        if (FieldData.FieldArray[x, y + 1].Mined) minesNear++;
                    if (x + 1 < FieldData.CellsCountWight && y + 1 < FieldData.CellsCountHeight)
                        if (FieldData.FieldArray[x + 1, y + 1].Mined) minesNear++;
                    if (x + 1 < FieldData.CellsCountWight)
                        if (FieldData.FieldArray[x + 1, y].Mined) minesNear++;
                    if (x + 1 < FieldData.CellsCountWight && y - 1 >= 0)
                        if (FieldData.FieldArray[x + 1, y - 1].Mined) minesNear++;
                    if (y - 1 >= 0)
                        if (FieldData.FieldArray[x, y - 1].Mined) minesNear++;
                    if (x - 1 >= 0 && y - 1 >= 0)
                        if (FieldData.FieldArray[x - 1, y - 1].Mined) minesNear++;
                    FieldData.FieldArray[x, y].MinesNear = minesNear;
                }
            }
        }

        public static void OpenCell(int x, int y)
        {
            if (FieldData.FieldArray[x, y].MinesNear > 0 && FieldData.FieldArray[x, y].Opened)
            {
                OpenNearestCells(x, y);
            }
            FieldData.FieldArray[x, y].Opened = true;
            FieldData.FieldArray[x, y].Marked = false;
            if (FieldData.FieldArray[x, y].MinesNear == 0)
            {
                OpenNearCells(x, y);
            }
        }

        private static void OpenNearCells(int x, int y)
        {
            if (x - 1 >= 0)
                if (!FieldData.FieldArray[x - 1, y].Mined && !FieldData.FieldArray[x - 1, y].Opened && !FieldData.FieldArray[x - 1, y].Marked)
                    OpenCell(x - 1, y);
            if (x - 1 >= 0 && y + 1 < FieldData.CellsCountHeight)
                if (!FieldData.FieldArray[x - 1, y + 1].Mined && !FieldData.FieldArray[x - 1, y + 1].Opened && !FieldData.FieldArray[x - 1, y + 1].Marked)
                    OpenCell(x - 1, y + 1);
            if (y + 1 < FieldData.CellsCountHeight)
                if (!FieldData.FieldArray[x, y + 1].Mined && !FieldData.FieldArray[x, y + 1].Opened && !FieldData.FieldArray[x, y + 1].Marked)
                    OpenCell(x, y + 1);
            if (x + 1 < FieldData.CellsCountWight && y + 1 < FieldData.CellsCountHeight)
                if (!FieldData.FieldArray[x + 1, y + 1].Mined && !FieldData.FieldArray[x + 1, y + 1].Opened && !FieldData.FieldArray[x + 1, y + 1].Marked)
                    OpenCell(x + 1, y + 1);
            if (x + 1 < FieldData.CellsCountWight)
                if (!FieldData.FieldArray[x + 1, y].Mined && !FieldData.FieldArray[x + 1, y].Opened && !FieldData.FieldArray[x + 1, y].Marked)
                    OpenCell(x + 1, y);
            if (x + 1 < FieldData.CellsCountWight && y - 1 >= 0)
                if (!FieldData.FieldArray[x + 1, y - 1].Mined && !FieldData.FieldArray[x + 1, y - 1].Opened && !FieldData.FieldArray[x + 1, y - 1].Marked)
                    OpenCell(x + 1, y - 1);
            if (y - 1 >= 0)
                if (!FieldData.FieldArray[x, y - 1].Mined && !FieldData.FieldArray[x, y - 1].Opened && !FieldData.FieldArray[x, y - 1].Marked)
                    OpenCell(x, y - 1);
            if (x - 1 >= 0 && y - 1 >= 0)
                if (!FieldData.FieldArray[x - 1, y - 1].Mined && !FieldData.FieldArray[x - 1, y - 1].Opened && !FieldData.FieldArray[x - 1, y - 1].Marked)
                    OpenCell(x - 1, y - 1);
        }

        public static void OpenNearestCells(int x, int y)
        {
            int marksNear = 0;
            if (x - 1 >= 0)
                if (FieldData.FieldArray[x - 1, y].Marked) marksNear++;
            if (x - 1 >= 0 && y + 1 < FieldData.CellsCountHeight)
                if (FieldData.FieldArray[x - 1, y + 1].Marked) marksNear++;
            if (y + 1 < FieldData.CellsCountHeight)
                if (FieldData.FieldArray[x, y + 1].Marked) marksNear++;
            if (x + 1 < FieldData.CellsCountWight && y + 1 < FieldData.CellsCountHeight)
                if (FieldData.FieldArray[x + 1, y + 1].Marked) marksNear++;
            if (x + 1 < FieldData.CellsCountWight)
                if (FieldData.FieldArray[x + 1, y].Marked) marksNear++;
            if (x + 1 < FieldData.CellsCountWight && y - 1 >= 0)
                if (FieldData.FieldArray[x + 1, y - 1].Marked) marksNear++;
            if (y - 1 >= 0)
                if (FieldData.FieldArray[x, y - 1].Marked) marksNear++;
            if (x - 1 >= 0 && y - 1 >= 0)
                if (FieldData.FieldArray[x - 1, y - 1].Marked) marksNear++;

            if (FieldData.FieldArray[x, y].MinesNear != marksNear) return;

            if (x - 1 >= 0)
                if (!FieldData.FieldArray[x - 1, y].Opened && !FieldData.FieldArray[x - 1, y].Marked)
                    OpenCell(x - 1, y);
            if (x - 1 >= 0 && y + 1 < FieldData.CellsCountHeight)
                if (!FieldData.FieldArray[x - 1, y + 1].Opened && !FieldData.FieldArray[x - 1, y + 1].Marked)
                    OpenCell(x - 1, y + 1);
            if (y + 1 < FieldData.CellsCountHeight)
                if (!FieldData.FieldArray[x, y + 1].Opened && !FieldData.FieldArray[x, y + 1].Marked)
                    OpenCell(x, y + 1);
            if (x + 1 < FieldData.CellsCountWight && y + 1 < FieldData.CellsCountHeight)
                if (!FieldData.FieldArray[x + 1, y + 1].Opened && !FieldData.FieldArray[x + 1, y + 1].Marked)
                    OpenCell(x + 1, y + 1);
            if (x + 1 < FieldData.CellsCountWight)
                if (!FieldData.FieldArray[x + 1, y].Opened && !FieldData.FieldArray[x + 1, y].Marked)
                    OpenCell(x + 1, y);
            if (x + 1 < FieldData.CellsCountWight && y - 1 >= 0)
                if (!FieldData.FieldArray[x + 1, y - 1].Opened && !FieldData.FieldArray[x + 1, y - 1].Marked)
                    OpenCell(x + 1, y - 1);
            if (y - 1 >= 0)
                if (!FieldData.FieldArray[x, y - 1].Opened && !FieldData.FieldArray[x, y - 1].Marked)
                    OpenCell(x, y - 1);
            if (x - 1 >= 0 && y - 1 >= 0)
                if (!FieldData.FieldArray[x - 1, y - 1].Opened && !FieldData.FieldArray[x - 1, y - 1].Marked)
                    OpenCell(x - 1, y - 1);
        }

        public static void MarkCell(int x, int y)
        {
            if (FieldData.FieldArray[x, y].Opened) return;
            FieldData.FieldArray[x, y].Marked ^= true;
        }

        public static bool CheckWin()
        {
            int cellsComplite = 0;
            for (int x = 0; x < FieldData.CellsCountWight; x++)
            {
                for (int y = 0; y < FieldData.CellsCountHeight; y++)
                {
                    if ((FieldData.FieldArray[x, y].Opened && !FieldData.FieldArray[x, y].Mined) ||
                        (FieldData.FieldArray[x, y].Marked && FieldData.FieldArray[x, y].Mined))
                        cellsComplite++;
                }
            }
            if (FieldData.FieldArray == null) return false;
            return FieldData.FieldArray.Length == cellsComplite;
        }

        public static bool CheckLose()
        {
            for (int x = 0; x < FieldData.CellsCountWight; x++)
            {
                for (int y = 0; y < FieldData.CellsCountHeight; y++)
                {
                    if (FieldData.FieldArray[x, y].Opened && FieldData.FieldArray[x, y].Mined)
                        return true;
                }
            }
            return false;
        }

        public static void OpenAllCells()
        {
            foreach (var cell in FieldData.FieldArray)
            {
                cell.Opened = true;
            }
            FieldData.FullyOpened = true;
        }

        public static EnumData.EGameResult CheckGameResult()
        {
            if (CheckWin())
                return EnumData.EGameResult.Win;
            if (CheckLose())
                return EnumData.EGameResult.Lose;
            return EnumData.EGameResult.None;
        }
    }
}