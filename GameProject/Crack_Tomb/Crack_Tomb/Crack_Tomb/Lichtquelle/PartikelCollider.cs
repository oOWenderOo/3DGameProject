using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Lichtquelle;
using Crack_Tomb.Spieler;

namespace Crack_Tomb.Lichtquelle
{
    class PartikelCollider
    {
        int[,] Level_Array;
        int arrayposition_x;
        int arrayposition_y;

        public PartikelCollider(int LevelNummer)
        {
            switch (LevelNummer)
            {
                case 1:
                    Level_Array = new Level1().Level_Array;
                    break;
                case 2:
                    Level_Array = new Level2().Level_Array;
                    break;
                case 3:
                    Level_Array = new Level3().Level_Array;
                    break;
                case 4:
                    Level_Array = new Level4().Level_Array;
                    break;
                default:
                    Level_Array = new Level0().Level_Array;
                    break;
            }
        }

        //Kollisionsabfrage mit Spieler und Umgebung
        public void colliding(Lichtquelle_Partikel partikel, Vector3 newposition, ref Player player)
        {
            arrayposition_x = (int)Math.Floor(partikel.getPosition().X);
            arrayposition_y = (int)Math.Floor(partikel.getPosition().Z);

            if (arrayposition_x != (int)Math.Floor(newposition.X) || arrayposition_y != (int)Math.Floor(newposition.Z))
            {
                int objectAtnew = Level_Array[(int)Math.Floor(newposition.X), (int)Math.Floor(newposition.Z)];

                switch (objectAtnew)
                {
                    case 1:
                        partikel.setRichtung(new Vector3(0, 0, 0));
                        break;
                    case 2:
                        partikel.setPosition(newposition);
                        break;
                    case 3:
                        switch (player.getSäulenArray()[(int)Math.Floor(newposition.X), (int)Math.Floor(newposition.Z)])
                        {
                            case 1:
                                partikel.setPosition(newposition);
                                break;
                            case 2:
                                partikel.setRichtung(new Vector3(0, 0, -1));
                                partikel.setPosition(newposition);
                                newposition = partikel.getPosition() + partikel.getRichtung();
                                partikel.setPosition(newposition);
                                break;
                            case 3:
                                partikel.setRichtung(new Vector3(1, 0, 0));
                                partikel.setPosition(newposition);
                                newposition = partikel.getPosition() + partikel.getRichtung();
                                partikel.setPosition(newposition);
                                break;
                            case 4:
                                partikel.setRichtung(new Vector3(0, 0, 1));
                                partikel.setPosition(newposition);
                                newposition = partikel.getPosition() + partikel.getRichtung();
                                partikel.setPosition(newposition);
                                break;
                            case 5:
                                partikel.setRichtung(new Vector3(-1, 0, 0));
                                partikel.setPosition(newposition);
                                newposition = partikel.getPosition() + partikel.getRichtung();
                                partikel.setPosition(newposition);
                                break;
                            default:
                                //partikel.setPosition(newposition);
                                break;
                        }
                        break;
                    default:
                        partikel.setPosition(newposition);
                        break;
                }
            }
        }
    }
}
