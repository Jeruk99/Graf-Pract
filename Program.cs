using System;

namespace Graf_Pract
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] M = new bool[4, 4]
            {
                { false, true, false, true },
                { true, false, false, false },
                {true, true, false, true },
                {false, true, false, false }
            };
            Graf G = new Graf(4, M);
            G.MatrAchieve();
            G.TrassDepth(0);
        }
    }
}
