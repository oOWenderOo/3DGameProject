﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Crack_Tomb.Levelloader.Level
{
    class Level12 : ALevel
    {
        public int[,] My_Level_Array = {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,9,0,0,0,0,0,5000001,0,3,0,0,0,3,0,5000010,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,3,0,0,0,0,0,1,0,3,0,0,0,3,0,5000001,0,0,0,0,0,3,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,1,5000001,1,1,1,1,1,1,0,0,0,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,3,0,0,0,0,0,0,0,3,0,5000001,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,1,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,1,5000001,1,1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,3,0,0,0,3,0,1,0,3,0,5000001,0,3,0,5000001,0,3,0,0,0,0,0,0,0,3,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,1,5000011,1,1,0,0,0,1,1,1,1,1,0,0,0,1,1,5000011,1,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,3,0,0,0,3,0,5000001,0,3,0,0,0,3,0,5000001,0,0,0,0,0,3,0,5000011,0,3,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,1,5000011,1,1,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,3,0,0,0,0,0,0,0,0,0,1,0,8,0,1,0,0,0,0,0,3,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,3,0,0,0,3,0,5000010,0,3,0,5000010,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1,1,5000010,1,1,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,3,0,0,0,0,0,0,0,3,0,1,0,3,0,0,0,0,0,0,0,3,0,0,0,3,0,0,0,3,0,1,0,0,0,0},
                                    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                                    {0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};

        public Level12()
        {
            minuten = 2;
            sekunden = 10;
            anzahlSpiegel = 15;
            anzahlSplittPrisma = 0;
            anzahlRed = 3;
            anzahlYellow = 2;
            anzahlGreen = 0;
            anzahlCyan = 0;
            anzahlBlue = 0;
            anzahlMagenta = 0;

            Licht_Richtung = new Vector3(-1, 0, 0);

            Level_Array = My_Level_Array;
        }
    }
}
