using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Lichtquelle;
using Crack_Tomb.Spieler;
using Crack_Tomb.Menuestruktur;

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
                case 5:
                    Level_Array = new Level5().Level_Array;
                    break;
                case 6:
                    Level_Array = new Level6().Level_Array;
                    break;
                case 7:
                    Level_Array = new Level7().Level_Array;
                    break;
                case 8:
                    Level_Array = new Level8().Level_Array;
                    break;
                case 9:
                    Level_Array = new Level9().Level_Array;
                    break;
                default:
                    Level_Array = new Level0().Level_Array;
                    break;
            }
        }

        //Kollisionsabfrage mit Spieler und Umgebung
        public void colliding(Lichtquelle_Partikel partikel, Vector3 newposition, ref Player player, ref bool gewonnen)
        {
            arrayposition_x = (int)Math.Floor(partikel.getPosition().X);
            arrayposition_y = (int)Math.Floor(partikel.getPosition().Z);

            if (arrayposition_x != (int)Math.Floor(newposition.X) || arrayposition_y != (int)Math.Floor(newposition.Z))
            {
                int objectAtnew = Level_Array[(int)Math.Floor(newposition.X), (int)Math.Floor(newposition.Z)];

                switch (objectAtnew)
                {
                    case 1: //Kollision Wand
                        partikel.setRichtung(new Vector3(0, 0, 0));
                        break;
                    case 2: //Wand mit Loch
                        partikel.setPosition(newposition);
                        break;
                    case 3: //Kollision Säule
                        Vector3 partikelrichtung = partikel.getRichtung();
                        Vector3 oben = new Vector3(0, 0, -1);
                        Vector3 unten = new Vector3(0, 0, 1);
                        Vector3 rechts = new Vector3(1, 0, 0);
                        Vector3 links = new Vector3(-1, 0, 0);
                        partikelrichtung.Normalize();

                        switch (player.getSäulenArray()[(int)Math.Floor(newposition.X), (int)Math.Floor(newposition.Z)])
                        {
                            case 1:
                                partikel.setPosition(newposition);
                                break;
                            case 2:
                                if (partikelrichtung == oben)
                                {
                                    partikel.setRichtung(links);
                                    partikel.setPosition(newposition);
                                    newposition = partikel.getPosition() + partikel.getRichtung();
                                    partikel.setPosition(newposition);
                                }

                                if (partikelrichtung == unten)
                                {
                                    partikel.setRichtung(rechts);
                                    partikel.setPosition(newposition);
                                    newposition = partikel.getPosition() + partikel.getRichtung();
                                    partikel.setPosition(newposition);
                                }

                                if (partikelrichtung == rechts)
                                {
                                    partikel.setRichtung(unten);
                                    partikel.setPosition(newposition);
                                    newposition = partikel.getPosition() + partikel.getRichtung();
                                    partikel.setPosition(newposition);
                                }

                                if (partikelrichtung == links)
                                {
                                    partikel.setRichtung(oben);
                                    partikel.setPosition(newposition);
                                    newposition = partikel.getPosition() + partikel.getRichtung();
                                    partikel.setPosition(newposition);
                                }
                                break;
                            case 3:
                                if (partikelrichtung == oben)
                                {
                                    partikel.setRichtung(rechts);
                                    partikel.setPosition(newposition);
                                    newposition = partikel.getPosition() + partikel.getRichtung();
                                    partikel.setPosition(newposition);
                                }

                                if (partikelrichtung == unten)
                                {
                                    partikel.setRichtung(links);
                                    partikel.setPosition(newposition);
                                    newposition = partikel.getPosition() + partikel.getRichtung();
                                    partikel.setPosition(newposition);
                                }

                                if (partikelrichtung == rechts)
                                {
                                    partikel.setRichtung(oben);
                                    partikel.setPosition(newposition);
                                    newposition = partikel.getPosition() + partikel.getRichtung();
                                    partikel.setPosition(newposition);
                                }

                                if (partikelrichtung == links)
                                {
                                    partikel.setRichtung(unten);
                                    partikel.setPosition(newposition);
                                    newposition = partikel.getPosition() + partikel.getRichtung();
                                    partikel.setPosition(newposition);
                                }
                                break;
                            case 4:
                                if (partikelrichtung == oben || partikelrichtung == unten)
                                {
                                    partikel.setPosition(newposition);
                                    partikel.setNachfolger(new Lichtquelle_Partikel(partikel.getModel(), partikel.getPosition(), links, partikel, partikel.getNachfolger(), new MyColor(partikel.getFarbe().mycolor)));
                                    partikel.getNachfolger().getNachfolger().setVorgänger(partikel.getNachfolger());
                                    partikel.setNachfolger(new Lichtquelle_Partikel(partikel.getModel(), partikel.getPosition(), rechts, partikel, partikel.getNachfolger(), new MyColor(partikel.getFarbe().mycolor)));
                                    partikel.getNachfolger().getNachfolger().setVorgänger(partikel.getNachfolger());
                                }

                                if (partikelrichtung == rechts || partikelrichtung == links)
                                {
                                    partikel.setPosition(newposition);
                                    partikel.setNachfolger(new Lichtquelle_Partikel(partikel.getModel(), partikel.getPosition(), oben, partikel, partikel.getNachfolger(), new MyColor(partikel.getFarbe().mycolor)));
                                    partikel.getNachfolger().getNachfolger().setVorgänger(partikel.getNachfolger());
                                    partikel.setNachfolger(new Lichtquelle_Partikel(partikel.getModel(), partikel.getPosition(), unten, partikel, partikel.getNachfolger(), new MyColor(partikel.getFarbe().mycolor)));
                                    partikel.getNachfolger().getNachfolger().setVorgänger(partikel.getNachfolger());
                                }
                                break;
                            case 5:
                                partikel.setPosition(newposition);
                                break;
                            case 6:
                                partikel.setPosition(newposition);
                                break;
                            case 7:
                                partikel.setPosition(newposition);
                                break;
                            case 8:
                                partikel.setPosition(newposition);
                                break;
                            case 9:
                                partikel.setPosition(newposition);
                                break;
                            case 10:
                                partikel.setPosition(newposition);
                                break;
                            case 11:
                                partikel.setPosition(newposition);
                                break;
                            case 12:
                                partikel.setPosition(newposition);
                                break;
                            default:
                                //partikel.setPosition(newposition);
                                break;
                        }
                        break;
                    case 9: //Kollision Ziel
                        partikel.setRichtung(new Vector3(0, 0, 0));
                        gewonnen = true;
                        break;
                    case 5000000:
                        if (partikel.getFarbe().mycolor == 000000)
                        {
                            partikel.setPosition(newposition);
                        }
                        else
                        {
                            partikel.setRichtung(new Vector3(0, 0, 0));
                        }
                        break;
                    case 5000001:
                        if (partikel.getFarbe().mycolor == 000001)
                        {
                            partikel.setPosition(newposition);
                        }
                        else
                        {
                            partikel.setRichtung(new Vector3(0, 0, 0));
                        }
                        break;
                    case 5000010:
                        if (partikel.getFarbe().mycolor == 000010)
                        {
                            partikel.setPosition(newposition);
                        }
                        else
                        {
                            partikel.setRichtung(new Vector3(0, 0, 0));
                        }
                        break;
                    case 5000100:
                        if (partikel.getFarbe().mycolor == 000100)
                        {
                            partikel.setPosition(newposition);
                        }
                        else
                        {
                            partikel.setRichtung(new Vector3(0, 0, 0));
                        }
                        break;
                    case 5001000:
                        if (partikel.getFarbe().mycolor == 001000)
                        {
                            partikel.setPosition(newposition);
                        }
                        else
                        {
                            partikel.setRichtung(new Vector3(0, 0, 0));
                        }
                        break;
                    case 5010000:
                        if (partikel.getFarbe().mycolor == 010000)
                        {
                            partikel.setPosition(newposition);
                        }
                        else
                        {
                            partikel.setRichtung(new Vector3(0, 0, 0));
                        }
                        break;
                    case 5100000:
                        if (partikel.getFarbe().mycolor == 100000)
                        {
                            partikel.setPosition(newposition);
                        }
                        else
                        {
                            partikel.setRichtung(new Vector3(0, 0, 0));
                        }
                        break;
                    case 5000011:
                        if (partikel.getFarbe().mycolor == 000011)
                        {
                            partikel.setPosition(newposition);
                        }
                        else
                        {
                            partikel.setRichtung(new Vector3(0, 0, 0));
                        }
                        break;
                    case 5000110:
                        if (partikel.getFarbe().mycolor == 000110)
                        {
                            partikel.setPosition(newposition);
                        }
                        else
                        {
                            partikel.setRichtung(new Vector3(0, 0, 0));
                        }
                        break;
                    case 5001100:
                        if (partikel.getFarbe().mycolor == 001100)
                        {
                            partikel.setPosition(newposition);
                        }
                        else
                        {
                            partikel.setRichtung(new Vector3(0, 0, 0));
                        }
                        break;
                    case 5011000:
                        if (partikel.getFarbe().mycolor == 011000)
                        {
                            partikel.setPosition(newposition);
                        }
                        else
                        {
                            partikel.setRichtung(new Vector3(0, 0, 0));
                        }
                        break;
                    case 5110000:
                        if (partikel.getFarbe().mycolor == 110000)
                        {
                            partikel.setPosition(newposition);
                        }
                        else
                        {
                            partikel.setRichtung(new Vector3(0, 0, 0));
                        }
                        break;
                    case 5100001:
                        if (partikel.getFarbe().mycolor == 100001)
                        {
                            partikel.setPosition(newposition);
                        }
                        else
                        {
                            partikel.setRichtung(new Vector3(0, 0, 0));
                        }
                        break;
                    default:
                        partikel.setPosition(newposition);
                        break;
                }
            }
            else
            {
                partikel.setPosition(newposition);
            }
        }
    }
}
