using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Crack_Tomb.Spieler
{
    class PlayerSteuerung
    {
        Vector3 newposition;
        PlayerCollider playercollider;
        public float speed = 0.1f;

        public PlayerSteuerung(int LevelNummer, ref int[,] Säulen_Array)
        {
            playercollider = new PlayerCollider(LevelNummer, ref Säulen_Array);
        }

        public Vector3 Update(GameTime gametime, Vector3 playerposition, ref int[,] Säulen_Array, ref Inventar inventar)
        {
            //Bestimmung der neuen Position bei bestimmter Eingabe des Spielers
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                newposition = playerposition + new Vector3(0, 0, speed * -1);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                newposition = playerposition + new Vector3(0, 0, speed);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                newposition = playerposition + new Vector3(speed * -1, 0, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                newposition = playerposition + new Vector3(speed, 0, 0);
            }

            //Was wird reingesetzt:
            //nichts = 0, Säule = 1, Spiegel links unten nach rechts oben = 2, Spiegel rechts unten nach links oben = 3, Splittprisma = 4, Farbkristall = 5
            int arrayposition_x = (int)Math.Floor(playerposition.X);
            int arrayposition_y = (int)Math.Floor(playerposition.Z);

            if (((int)gametime.TotalGameTime.Milliseconds) % 10 == 0)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D1) && inventar.getNumSpiegel() >= 0) //Spiegel einfügen
                {
                    switch (Säulen_Array[arrayposition_x, arrayposition_y + 1])
                    {
                        case 1:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 2;
                            }
                            break;
                        case 2:
                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 3;
                            break;
                        case 3:
                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 2;
                            break;
                        case 4:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushSplittPrisma();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 2;
                            }
                            break;
                        case 5:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristall();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 2;
                            }
                            break;
                        default:
                            break;
                    }

                    switch (Säulen_Array[arrayposition_x, arrayposition_y - 1])
                    {
                        case 1:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 2;
                            }
                            break;
                        case 2:
                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 3;
                            break;
                        case 3:
                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 2;
                            break;
                        case 4:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushSplittPrisma();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 2;
                            }
                            break;
                        case 5:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristall();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 2;
                            }
                            break;
                        default:
                            break;
                    }

                    switch (Säulen_Array[arrayposition_x + 1, arrayposition_y])
                    {
                        case 1:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 2;
                            }
                            break;
                        case 2:
                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 3;
                            break;
                        case 3:
                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 2;
                            break;
                        case 4:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushSplittPrisma();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 2;
                            }
                            break;
                        case 5:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristall();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 2;
                            }
                            break;
                        default:
                            break;
                    }

                    switch (Säulen_Array[arrayposition_x - 1, arrayposition_y])
                    {
                        case 1:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 2;
                            }
                            break;
                        case 2:
                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 3;
                            break;
                        case 3:
                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 2;
                            break;
                        case 4:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushSplittPrisma();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 2;
                            }
                            break;
                        case 5:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristall();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 2;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.D2) && inventar.getNumSplittPrisma() > 0) //Splittprisma einfügen
                    {
                        switch (Säulen_Array[arrayposition_x, arrayposition_y + 1])
                        {
                            case 1:
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 4;
                                break;
                            case 2:
                                inventar.pushSpiegel();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 4;
                                break;
                            case 3:
                                inventar.pushSpiegel();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 4;
                                break;
                            case 4:
                                break;
                            case 5:
                                inventar.pushFarbkristall();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 4;
                                break;
                            default:
                                break;
                        }

                        switch (Säulen_Array[arrayposition_x, arrayposition_y - 1])
                        {
                            case 1:
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 4;
                                break;
                            case 2:
                                inventar.pushSpiegel();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 4;
                                break;
                            case 3:
                                inventar.pushSpiegel();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 4;
                                break;
                            case 4:
                                break;
                            case 5:
                                inventar.pushFarbkristall();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 4;
                                break;
                            default:
                                break;
                        }

                        switch (Säulen_Array[arrayposition_x + 1, arrayposition_y])
                        {
                            case 1:
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 4;
                                break;
                            case 2:
                                inventar.pushSpiegel();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 4;
                                break;
                            case 3:
                                inventar.pushSpiegel();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 4;
                                break;
                            case 4:
                                break;
                            case 5:
                                inventar.pushFarbkristall();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 4;
                                break;
                            default:
                                break;
                        }

                        switch (Säulen_Array[arrayposition_x - 1, arrayposition_y])
                        {
                            case 1:
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 4;
                                break;
                            case 2:
                                inventar.pushSpiegel();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 4;
                                break;
                            case 3:
                                inventar.pushSpiegel();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 4;
                                break;
                            case 4:
                                break;
                            case 5:
                                inventar.pushFarbkristall();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 4;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.D3) && inventar.getNumFarbkristall() > 0) //Farbkristall einfügen
                        {
                            switch (Säulen_Array[arrayposition_x, arrayposition_y + 1])
                            {
                                case 1:
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x, arrayposition_y + 1] = 5;
                                    break;
                                case 2:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x, arrayposition_y + 1] = 5;
                                    break;
                                case 3:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x, arrayposition_y + 1] = 5;
                                    break;
                                case 4:
                                    inventar.pullSplittPrisma();
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x, arrayposition_y + 1] = 5;
                                    break;
                                case 5:
                                    break;
                                default:
                                    break;
                            }

                            switch (Säulen_Array[arrayposition_x, arrayposition_y - 1])
                            {
                                case 1:
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x, arrayposition_y - 1] = 5;
                                    break;
                                case 2:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x, arrayposition_y - 1] = 5;
                                    break;
                                case 3:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x, arrayposition_y - 1] = 5;
                                    break;
                                case 4:
                                    inventar.pullSplittPrisma();
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x, arrayposition_y - 1] = 5;
                                    break;
                                case 5:
                                    break;
                                default:
                                    break;
                            }

                            switch (Säulen_Array[arrayposition_x + 1, arrayposition_y])
                            {
                                case 1:
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x + 1, arrayposition_y] = 5;
                                    break;
                                case 2:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x + 1, arrayposition_y] = 5;
                                    break;
                                case 3:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x + 1, arrayposition_y] = 5;
                                    break;
                                case 4:
                                    inventar.pullSplittPrisma();
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x + 1, arrayposition_y] = 5;
                                    break;
                                case 5:
                                    break;
                                default:
                                    break;
                            }

                            switch (Säulen_Array[arrayposition_x - 1, arrayposition_y])
                            {
                                case 1:
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x - 1, arrayposition_y] = 5;
                                    break;
                                case 2:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x - 1, arrayposition_y] = 5;
                                    break;
                                case 3:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x - 1, arrayposition_y] = 5;
                                    break;
                                case 4:
                                    inventar.pullSplittPrisma();
                                    inventar.pullFarbkristall();
                                    Säulen_Array[arrayposition_x - 1, arrayposition_y] = 5;
                                    break;
                                case 5:
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            if(Keyboard.GetState().IsKeyDown(Keys.E))
                            {
                                switch (Säulen_Array[arrayposition_x, arrayposition_y + 1])
                                {
                                    case 2:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 1;
                                        break;
                                    case 3:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 1;
                                        break;
                                    case 4:
                                        inventar.pushSplittPrisma();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 1;
                                        break;
                                    case 5:
                                        inventar.pushFarbkristall();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 1;
                                        break;
                                    default:
                                        break;
                                }

                                switch (Säulen_Array[arrayposition_x, arrayposition_y - 1])
                                {
                                    case 2:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 1;
                                        break;
                                    case 3:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 1;
                                        break;
                                    case 4:
                                        inventar.pushSplittPrisma();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 1;
                                        break;
                                    case 5:
                                        inventar.pushFarbkristall();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 1;
                                        break;
                                    default:
                                        break;
                                }

                                switch (Säulen_Array[arrayposition_x + 1, arrayposition_y])
                                {
                                    case 2:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 1;
                                        break;
                                    case 3:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 1;
                                        break;
                                    case 4:
                                        inventar.pushSplittPrisma();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 1;
                                        break;
                                    case 5:
                                        inventar.pushFarbkristall();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 1;
                                        break;
                                    default:
                                        break;
                                }

                                switch (Säulen_Array[arrayposition_x - 1, arrayposition_y])
                                {
                                    case 2:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 1;
                                        break;
                                    case 3:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 1;
                                        break;
                                    case 4:
                                        inventar.pushSplittPrisma();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 1;
                                        break;
                                    case 5:
                                        inventar.pushFarbkristall();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 1;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            //Kollisionsprüfung
            if (!playercollider.IsColliding(playerposition, newposition))
            {
                return newposition;
            }
            else
            {
                return playerposition;
            }
        }
    }
}
