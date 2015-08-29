using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Crack_Tomb.Levelloader.Level
{
    abstract class ALevel
    {
        public int minuten;
        public int sekunden;
        public int anzahlSpiegel;
        public int anzahlSplittPrisma;
        public int anzahlRed;
        public int anzahlYellow;
        public int anzahlGreen;
        public int anzahlCyan;
        public int anzahlBlue;
        public int anzahlMagenta;

        public Vector3 Licht_Start;
        public Vector3 Licht_Richtung;

        public int[,] Level_Array;
    }
}
