using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mineswapper
{
    internal class EnumData
    {
        internal enum EDifficulty
        {
            Easy,
            Normal,
            Hard,
            Impossible,
        }

        internal enum ETexturesTypes
        {
            Empty,
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Mine,
            Mark,
        }

        internal enum EGameResult
        {
            Win,
            Lose,
            None,
        }
    }
}