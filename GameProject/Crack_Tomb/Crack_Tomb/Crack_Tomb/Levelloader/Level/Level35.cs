﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Crack_Tomb.Levelloader.Level
{
    class Level35 : ALevel
    {
        int[,] My_Level_Array = {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
                                {0,0,1,0,3,0,5000011,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5001000,1,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,3,0,5100000,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,3,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,5011000,1,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,3,0,5000110,0,0,0,0,0,3,0,0,0,0,0,0,0,3,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,1,1,1,1,1,2,1,1,1,1,1,1,1,5000001,1,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,3,0,5001000,0,3,0,0,0,3,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,1,1,1,1,1,5110000,1,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,3,0,2,0,3,0,1,0,3,0,1,0,3,0,2,0,9,0,5000011,0,3,0,1,0,3,0,2,0,3,0,2,0,3,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,1,5000011,1,1,1,1,1,1,1,1,1,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,3,0,0,0,3,0,0,0,0,0,5000100,0,3,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,1,5010000,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,3,0,5000001,0,3,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,5000110,0,3,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,1,5011000,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,0,0,0,1,0,3,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,5110000,0,3,0,1,0,0},
                                {0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0},
                                {0,0,1,1,5000001,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
                                {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
                                {0,0,1,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,1,0,0},
                                {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
                                {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};

        public Level35()
        {
            minuten = 10;
            sekunden = 0;
            anzahlSpiegel = 8;
            anzahlSplittPrisma = 0;
            anzahlRed = 1;
            anzahlYellow = 1;
            anzahlGreen = 0;
            anzahlCyan = 0;
            anzahlBlue = 0;
            anzahlMagenta = 0;

            Licht_Richtung = new Vector3(0, 0, -1);

            Level_Array = My_Level_Array;
        }
    }
}
