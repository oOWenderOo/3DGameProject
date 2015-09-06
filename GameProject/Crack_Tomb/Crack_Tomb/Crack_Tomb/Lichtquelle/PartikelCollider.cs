using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Lichtquelle;
using Crack_Tomb.Spieler;
using Crack_Tomb.Menuestruktur;
using Crack_Tomb.Levelloader;
using Microsoft.Xna.Framework.Audio;

namespace Crack_Tomb.Lichtquelle
{
    class PartikelCollider
    {
        int arrayposition_x;
        int arrayposition_y;
        SoundEffect türöffnet;

        public PartikelCollider(SoundEffect türöffnet)
        {
            this.türöffnet = türöffnet;
        }

        //Kollisionsabfrage mit Spieler und Umgebung
        public void colliding(Lichtquelle_Partikel partikel, Vector3 newposition, ref Player player, ref bool gewonnen, ref Level_LoaderV2 levelloader)
        {
            arrayposition_x = (int)Math.Floor(partikel.getPosition().X);
            arrayposition_y = (int)Math.Floor(partikel.getPosition().Z);

            if (arrayposition_x != (int)Math.Floor(newposition.X) || arrayposition_y != (int)Math.Floor(newposition.Z))
            {
                int objectAtnew = levelloader.Level_Array[(int)Math.Floor(newposition.X), (int)Math.Floor(newposition.Z)];

                switch (objectAtnew)
                {
                    case 1: //Kollision Wand
                        partikel.setRichtung(new Vector3(0, 0, 0));
                        break;
                    case 10:
                        partikel.setRichtung(new Vector3(0, 0, 0));
                        break;
                    case 11:
                        partikel.setRichtung(new Vector3(0, 0, 0));
                        break;
                    case 12:
                        partikel.setRichtung(new Vector3(0, 0, 0));
                        break;
                    case 13:
                        partikel.setRichtung(new Vector3(0, 0, 0));
                        break;
                    case 14:
                        partikel.setRichtung(new Vector3(0, 0, 0));
                        break;
                    case 15:
                        partikel.setRichtung(new Vector3(0, 0, 0));
                        break;
                    case 16:
                        partikel.setRichtung(new Vector3(0, 0, 0));
                        break;
                    case 17:
                        partikel.setRichtung(new Vector3(0, 0, 0));
                        break;
                    case 18:
                        partikel.setRichtung(new Vector3(0, 0, 0));
                        break;
                    case 19:
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
                                    colliding(partikel, partikel.getPosition() + partikel.getRichtung(), ref player, ref gewonnen, ref levelloader);
                                }

                                if (partikelrichtung == unten)
                                {
                                    partikel.setRichtung(rechts);
                                    partikel.setPosition(newposition);
                                    colliding(partikel, partikel.getPosition() + partikel.getRichtung(), ref player, ref gewonnen, ref levelloader);
                                }

                                if (partikelrichtung == rechts)
                                {
                                    partikel.setRichtung(unten);
                                    partikel.setPosition(newposition);
                                    colliding(partikel, partikel.getPosition() + partikel.getRichtung(), ref player, ref gewonnen, ref levelloader);
                                }

                                if (partikelrichtung == links)
                                {
                                    partikel.setRichtung(oben);
                                    partikel.setPosition(newposition);
                                    colliding(partikel, partikel.getPosition() + partikel.getRichtung(), ref player, ref gewonnen, ref levelloader);
                                }
                                break;
                            case 3:
                                if (partikelrichtung == oben)
                                {
                                    partikel.setRichtung(rechts);
                                    partikel.setPosition(newposition);
                                    colliding(partikel, partikel.getPosition() + partikel.getRichtung(), ref player, ref gewonnen, ref levelloader);
                                }

                                if (partikelrichtung == unten)
                                {
                                    partikel.setRichtung(links);
                                    partikel.setPosition(newposition);
                                    colliding(partikel, partikel.getPosition() + partikel.getRichtung(), ref player, ref gewonnen, ref levelloader);
                                }

                                if (partikelrichtung == rechts)
                                {
                                    partikel.setRichtung(oben);
                                    partikel.setPosition(newposition);
                                    colliding(partikel, partikel.getPosition() + partikel.getRichtung(), ref player, ref gewonnen, ref levelloader);
                                }

                                if (partikelrichtung == links)
                                {
                                    partikel.setRichtung(unten);
                                    partikel.setPosition(newposition);
                                    colliding(partikel, partikel.getPosition() + partikel.getRichtung(), ref player, ref gewonnen, ref levelloader);
                                }
                                break;
                            case 4:
                                if (partikelrichtung == oben || partikelrichtung == unten)
                                {
                                    partikel.setPosition(newposition);
                                    partikel.setNachfolger(new Lichtquelle_Partikel(partikel.getModel(), partikel.getPosition(), links, partikel, partikel.getNachfolger(), new MyColor(partikel.getFarbe().mycolor), partikel.effect));
                                    partikel.getNachfolger().getNachfolger().setVorgänger(partikel.getNachfolger());
                                    partikel.setNachfolger(new Lichtquelle_Partikel(partikel.getModel(), partikel.getPosition(), rechts, partikel, partikel.getNachfolger(), new MyColor(partikel.getFarbe().mycolor), partikel.effect));
                                    partikel.getNachfolger().getNachfolger().setVorgänger(partikel.getNachfolger());
                                }

                                if (partikelrichtung == rechts || partikelrichtung == links)
                                {
                                    partikel.setPosition(newposition);
                                    partikel.setNachfolger(new Lichtquelle_Partikel(partikel.getModel(), partikel.getPosition(), oben, partikel, partikel.getNachfolger(), new MyColor(partikel.getFarbe().mycolor), partikel.effect));
                                    partikel.getNachfolger().getNachfolger().setVorgänger(partikel.getNachfolger());
                                    partikel.setNachfolger(new Lichtquelle_Partikel(partikel.getModel(), partikel.getPosition(), unten, partikel, partikel.getNachfolger(), new MyColor(partikel.getFarbe().mycolor), partikel.effect));
                                    partikel.getNachfolger().getNachfolger().setVorgänger(partikel.getNachfolger());
                                }
                                break;
                            case 5:
                                if (partikel.getFarbe().mycolor == 000000)
                                {
                                    partikel.setFarbe(new MyColor(000001));
                                }
                                else
                                {
                                    partikel.setFarbe(new MyColor(MyColor.mixColor(partikel.getFarbe(), new MyColor(000001))));
                                }
                                partikel.setPosition(newposition);
                                break;
                            case 6:
                                if (partikel.getFarbe().mycolor == 000000)
                                {
                                    partikel.setFarbe(new MyColor(000010));
                                }
                                else
                                {
                                    partikel.setFarbe(new MyColor(MyColor.mixColor(partikel.getFarbe(), new MyColor(000010))));
                                }
                                partikel.setPosition(newposition);
                                break;
                            case 7:
                                if (partikel.getFarbe().mycolor == 000000)
                                {
                                    partikel.setFarbe(new MyColor(000100));
                                }
                                else
                                {
                                    partikel.setFarbe(new MyColor(MyColor.mixColor(partikel.getFarbe(), new MyColor(000100))));
                                }
                                partikel.setPosition(newposition);
                                break;
                            case 8:
                                if (partikel.getFarbe().mycolor == 000000)
                                {
                                    partikel.setFarbe(new MyColor(001000));
                                }
                                else
                                {
                                    partikel.setFarbe(new MyColor(MyColor.mixColor(partikel.getFarbe(), new MyColor(001000))));
                                }
                                partikel.setPosition(newposition);
                                break;
                            case 9:
                                if (partikel.getFarbe().mycolor == 000000)
                                {
                                    partikel.setFarbe(new MyColor(010000));
                                }
                                else
                                {
                                    partikel.setFarbe(new MyColor(MyColor.mixColor(partikel.getFarbe(), new MyColor(010000))));
                                }
                                partikel.setPosition(newposition);
                                break;
                            case 10:
                                if (partikel.getFarbe().mycolor == 000000)
                                {
                                    partikel.setFarbe(new MyColor(100000));
                                }
                                else
                                {
                                    partikel.setFarbe(new MyColor(MyColor.mixColor(partikel.getFarbe(), new MyColor(100000))));
                                }
                                partikel.setPosition(newposition);
                                break;
                            default:
                                //partikel.setPosition(newposition);
                                break;
                        }
                        break;
                    case 70: //geschlossene Tür
                        partikel.setRichtung(new Vector3(0, 0, 0));
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

                if (objectAtnew >= 600000 && objectAtnew <= 604141)
                {
                    objectAtnew -= 600000;

                    string strX;
                    string strY;

                    if (objectAtnew < 1000)
                    {
                        strX = objectAtnew.ToString().Substring(0, 1);
                        strY = objectAtnew.ToString().Substring(1, 2);
                    }
                    else
                    {
                        strX = objectAtnew.ToString().Substring(0, 2);
                        strY = objectAtnew.ToString().Substring(2, 2);
                    }

                    int x = Convert.ToInt32(strX);
                    int y = Convert.ToInt32(strY);

                    if (levelloader.Level_Array[y, x] == 70)
                    {
                        türöffnet.Play();
                        levelloader.Level_Array[y, x] = 71;
                    }

                    objectAtnew += 610000;

                    levelloader.Level_Array[(int)Math.Floor(newposition.X), (int)Math.Floor(newposition.Z)] = objectAtnew;
                }
            }
            else
            {
                partikel.setPosition(newposition);
            }
        }
    }
}
