using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mineswapper
{
    internal class FieldData
    {
        public static EnumData.EDifficulty Difficulty { get; set; }
        public static int MinesCount { get; set; }
        public static int CellsCountHeight { get; set; }
        public static int CellsCountWight { get; set; }
        public static bool Closed { get; set; } = true;
        public static bool FullyOpened { get; set; } = false;

        //public static bool Completed { get; set; } = false;
        public static FieldItem[,] FieldArray;

        public class FieldItem
        {
            public FieldItem(bool mined, bool opened, bool marked, int minesNear)
            {
                Mined = mined;
                Opened = opened;
                Marked = marked;
                MinesNear = minesNear;
            }

            public bool Mined { get; set; }
            public bool Opened { get; set; }
            public bool Marked { get; set; }
            public int MinesNear { get; set; }
        }
    }
}