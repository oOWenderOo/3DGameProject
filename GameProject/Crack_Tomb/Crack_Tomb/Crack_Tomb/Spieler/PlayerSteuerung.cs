﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Crack_Tomb.Levelloader;

namespace Crack_Tomb.Spieler
{
    class PlayerSteuerung
    {
        Vector3 newposition;
        PlayerCollider playercollider;
        public float speed = 0.1f;
        bool isgedrücktD1 = false;
        bool isgedrücktD2 = false;
        bool isgedrücktD3 = false;
        bool isgedrücktD4 = false;
        bool isgedrücktD5 = false;
        bool isgedrücktD6 = false;
        bool isgedrücktE = false;
        SoundEffect farbkristallkramen, herausnehmen;

        public PlayerSteuerung(int LevelNummer, ref int[,] Säulen_Array, SoundEffect farbkristallkramen, SoundEffect herausnehmen)
        {
            this.farbkristallkramen = farbkristallkramen;
            this.herausnehmen = herausnehmen;
            playercollider = new PlayerCollider();
        }

        public Vector3 Update(GameTime gametime, Vector3 playerposition, ref int[,] Säulen_Array, ref Inventar inventar, ref Level_LoaderV2 levelloader, ref float playerRotation)
        {
            newposition = playerposition;

            //Bestimmung der neuen Position bei bestimmter Eingabe des Spielers
            bool nachOben = Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up);
            bool nachUnten = Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down);
            bool nachRechts = Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right);
            bool nachLinks = Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left);

            Vector3 bewegung = new Vector3(0, 0, 0);

            if (nachOben)
            {
                bewegung += (new Vector3(0, 0, -1));
                playerRotation = 0;
            }

            if (nachUnten)
            {
                bewegung += (new Vector3(0, 0, 1));
                playerRotation = 6.282f/2f;
            }

            if (nachLinks)
            {
                bewegung += (new Vector3(-1, 0, 0));
                playerRotation = 3.141f/2f;
            }

            if (nachRechts)
            {
                bewegung += (new Vector3(1, 0, 0));
                playerRotation = -3.141f / 2f;
            }

            if (nachLinks && nachOben)
            {
                playerRotation = 3.141f / 4f;
            }

            if (nachRechts && nachOben)
            {
                playerRotation = -3.141f / 4f;
            }

            if (nachLinks && nachUnten)
            {
                playerRotation = 3.141f / 4f + 3.141f / 2f;
            }

            if (nachRechts && nachUnten)
            {
                playerRotation = -3.141f / 4f - 3.141f / 2f;
            }

            if(bewegung.X != 0 || bewegung.Y != 0 || bewegung.Z != 0)
                bewegung.Normalize();

            newposition += (bewegung * speed);

            //Was wird reingesetzt:
            //nichts = 0, Säule = 1, Spiegel links unten nach rechts oben = 2, Spiegel rechts unten nach links oben = 3, Splittprisma = 4
            //Farbkristall:
            //Rot = 5
            //Gelb = 6
            //Grün = 7
            //Cyan = 8
            //Blau = 9
            //Magenta = 10
            int arrayposition_x = (int)Math.Floor(playerposition.X);
            int arrayposition_y = (int)Math.Floor(playerposition.Z);

            if (!inventar.drawFarbkristalle)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D1) && inventar.getNumSpiegel() >= 0 && !isgedrücktD2 && !isgedrücktD3)
                {
                    isgedrücktD1 = true;
                }
                else
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.D2) && inventar.getNumSplittPrisma() > 0 && !isgedrücktD1 && !isgedrücktD3)
                    {
                        isgedrücktD2 = true;
                    }
                    else
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.D3) && inventar.getNumFarbkristall() > 0 && !isgedrücktD2 && !isgedrücktD1)
                        {
                            isgedrücktD3 = true;
                        }
                        else
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.E) && !isgedrücktD1 && !isgedrücktD2 && !isgedrücktD3)
                            {
                                isgedrücktE = true;
                            }
                        }
                    }
                }

                if (isgedrücktD1 && Keyboard.GetState().IsKeyUp(Keys.D1)) //Spiegel einfügen
                {
                    isgedrücktD1 = false;
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
                                inventar.pushFarbkristallRed();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 2;
                            }
                            break;
                        case 6:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallYellow();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 2;
                            }
                            break;
                        case 7:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallGreen();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 2;
                            }
                            break;
                        case 8:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallCyan();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 2;
                            }
                            break;
                        case 9:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallBlue();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 2;
                            }
                            break;
                        case 10:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallMagenta();
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
                                inventar.pushFarbkristallRed();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 2;
                            }
                            break;
                        case 6:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallYellow();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 2;
                            }
                            break;
                        case 7:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallGreen();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 2;
                            }
                            break;
                        case 8:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallCyan();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 2;
                            }
                            break;
                        case 9:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallBlue();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 2;
                            }
                            break;
                        case 10:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallMagenta();
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
                                inventar.pushFarbkristallRed();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 2;
                            }
                            break;
                        case 6:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallYellow();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 2;
                            }
                            break;
                        case 7:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallGreen();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 2;
                            }
                            break;
                        case 8:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallCyan();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 2;
                            }
                            break;
                        case 9:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallBlue();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 2;
                            }
                            break;
                        case 10:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallMagenta();
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
                                inventar.pushFarbkristallRed();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 2;
                            }
                            break;
                        case 6:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallYellow();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 2;
                            }
                            break;
                        case 7:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallGreen();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 2;
                            }
                            break;
                        case 8:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallCyan();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 2;
                            }
                            break;
                        case 9:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallBlue();
                                inventar.pullSpiegel();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 2;
                            }
                            break;
                        case 10:
                            if (inventar.getNumSpiegel() != 0)
                            {
                                inventar.pushFarbkristallMagenta();
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
                    if (isgedrücktD2 && Keyboard.GetState().IsKeyUp(Keys.D2)) //Splittprisma einfügen
                    {
                        isgedrücktD2 = false;
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
                                inventar.pushFarbkristallRed();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 4;
                                break;
                            case 6:
                                inventar.pushFarbkristallYellow();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 4;
                                break;
                            case 7:
                                inventar.pushFarbkristallGreen();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 4;
                                break;
                            case 8:
                                inventar.pushFarbkristallCyan();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 4;
                                break;
                            case 9:
                                inventar.pushFarbkristallBlue();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 4;
                                break;
                            case 10:
                                inventar.pushFarbkristallMagenta();
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
                                inventar.pushFarbkristallRed();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 4;
                                break;
                            case 6:
                                inventar.pushFarbkristallYellow();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 4;
                                break;
                            case 7:
                                inventar.pushFarbkristallGreen();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 4;
                                break;
                            case 8:
                                inventar.pushFarbkristallCyan();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 4;
                                break;
                            case 9:
                                inventar.pushFarbkristallBlue();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 4;
                                break;
                            case 10:
                                inventar.pushFarbkristallMagenta();
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
                                inventar.pushFarbkristallRed();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 4;
                                break;
                            case 6:
                                inventar.pushFarbkristallYellow();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 4;
                                break;
                            case 7:
                                inventar.pushFarbkristallGreen();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 4;
                                break;
                            case 8:
                                inventar.pushFarbkristallCyan();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 4;
                                break;
                            case 9:
                                inventar.pushFarbkristallBlue();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 4;
                                break;
                            case 10:
                                inventar.pushFarbkristallMagenta();
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
                                inventar.pushFarbkristallRed();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 4;
                                break;
                            case 6:
                                inventar.pushFarbkristallYellow();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 4;
                                break;
                            case 7:
                                inventar.pushFarbkristallGreen();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 4;
                                break;
                            case 8:
                                inventar.pushFarbkristallCyan();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 4;
                                break;
                            case 9:
                                inventar.pushFarbkristallBlue();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 4;
                                break;
                            case 10:
                                inventar.pushFarbkristallMagenta();
                                inventar.pullSplittPrisma();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 4;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (isgedrücktD3 && Keyboard.GetState().IsKeyUp(Keys.D3)) //Farbkristalle anzeigen
                        {
                            isgedrücktD3 = false;
                            inventar.drawFarbkristalle = true;
                            farbkristallkramen.Play();
                        }
                        else
                        {
                            if (isgedrücktE && Keyboard.GetState().IsKeyUp(Keys.E)) //Objekt entfernen
                            {
                                isgedrücktE = false;
                                switch (Säulen_Array[arrayposition_x, arrayposition_y + 1])
                                {
                                    case 2:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 3:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 4:
                                        inventar.pushSplittPrisma();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 5:
                                        inventar.pushFarbkristallRed();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 6:
                                        inventar.pushFarbkristallYellow();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 7:
                                        inventar.pushFarbkristallGreen();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 8:
                                        inventar.pushFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 9:
                                        inventar.pushFarbkristallBlue();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 10:
                                        inventar.pushFarbkristallMagenta();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    default:
                                        break;
                                }

                                switch (Säulen_Array[arrayposition_x, arrayposition_y - 1])
                                {
                                    case 2:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 3:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 4:
                                        inventar.pushSplittPrisma();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 5:
                                        inventar.pushFarbkristallRed();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 6:
                                        inventar.pushFarbkristallYellow();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 7:
                                        inventar.pushFarbkristallGreen();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 8:
                                        inventar.pushFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 9:
                                        inventar.pushFarbkristallBlue();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 10:
                                        inventar.pushFarbkristallMagenta();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 1;
                                        herausnehmen.Play();
                                        break;
                                    default:
                                        break;
                                }

                                switch (Säulen_Array[arrayposition_x + 1, arrayposition_y])
                                {
                                    case 2:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 3:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 4:
                                        inventar.pushSplittPrisma();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 5:
                                        inventar.pushFarbkristallRed();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 6:
                                        inventar.pushFarbkristallYellow();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 7:
                                        inventar.pushFarbkristallGreen();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 8:
                                        inventar.pushFarbkristallCyan();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 9:
                                        inventar.pushFarbkristallBlue();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 10:
                                        inventar.pushFarbkristallMagenta();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    default:
                                        break;
                                }

                                switch (Säulen_Array[arrayposition_x - 1, arrayposition_y])
                                {
                                    case 2:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 3:
                                        inventar.pushSpiegel();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 4:
                                        inventar.pushSplittPrisma();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 5:
                                        inventar.pushFarbkristallRed();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 6:
                                        inventar.pushFarbkristallYellow();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 7:
                                        inventar.pushFarbkristallGreen();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 8:
                                        inventar.pushFarbkristallCyan();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 9:
                                        inventar.pushFarbkristallBlue();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    case 10:
                                        inventar.pushFarbkristallMagenta();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 1;
                                        herausnehmen.Play();
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            else //Farbkristalle einfügen
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D1) && inventar.getNumFarbkristallRed() > 0 && !isgedrücktD2 && !isgedrücktD3 && !isgedrücktD4 && !isgedrücktD5 && !isgedrücktD6)
                {
                    isgedrücktD1 = true;
                }
                else
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.D2) && inventar.getNumFarbkristallYellow() > 0 && !isgedrücktD1 && !isgedrücktD3 && !isgedrücktD4 && !isgedrücktD5 && !isgedrücktD6)
                    {
                        isgedrücktD2 = true;
                    }
                    else
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.D3) && inventar.getNumFarbkristallGreen() > 0 && !isgedrücktD2 && !isgedrücktD1 && !isgedrücktD4 && !isgedrücktD5 && !isgedrücktD6)
                        {
                            isgedrücktD3 = true;
                        }
                        else
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.D4) && inventar.getNumFarbkristallCyan() > 0 && !isgedrücktD1 && !isgedrücktD2 && !isgedrücktD3 && !isgedrücktD5 && !isgedrücktD6)
                            {
                                isgedrücktD4 = true;
                            }
                            else
                            {
                                if (Keyboard.GetState().IsKeyDown(Keys.D5) && inventar.getNumFarbkristallBlue() > 0 && !isgedrücktD1 && !isgedrücktD2 && !isgedrücktD3 && !isgedrücktD4 && !isgedrücktD6)
                                {
                                    isgedrücktD5 = true;
                                }
                                else
                                {
                                    if (Keyboard.GetState().IsKeyDown(Keys.D6) && inventar.getNumFarbkristallMagenta() > 0 && !isgedrücktD1 && !isgedrücktD2 && !isgedrücktD3 && !isgedrücktD4 && !isgedrücktD5)
                                    {
                                        isgedrücktD6 = true;
                                    }
                                    else
                                    {
                                        if (Keyboard.GetState().IsKeyDown(Keys.E) && isgedrücktD1 == false && isgedrücktD2 == false && isgedrücktD3 == false)
                                        {
                                            isgedrücktE = true;
                                        } 
                                    }
                                }
                            }
                        }
                    }
                }

                if (isgedrücktD1 && Keyboard.GetState().IsKeyUp(Keys.D1))
                {
                    isgedrücktD1 = false;
                    switch (Säulen_Array[arrayposition_x, arrayposition_y + 1])
                    {
                        case 1:
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 5;
                            break;
                        case 2:
                            inventar.pushSpiegel();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 5;
                            break;
                        case 3:
                            inventar.pushSpiegel();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 5;
                            break;
                        case 4:
                            inventar.pushSplittPrisma();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 5;
                            break;
                        case 6:
                            inventar.pushFarbkristallYellow();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 5;
                            break;
                        case 7:
                            inventar.pushFarbkristallGreen();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 5;
                            break;
                        case 8:
                            inventar.pushFarbkristallCyan();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 5;
                            break;
                        case 9:
                            inventar.pushFarbkristallBlue();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 5;
                            break;
                        case 10:
                            inventar.pushFarbkristallMagenta();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 5;
                            break;
                        default:
                            break;
                    }

                    switch (Säulen_Array[arrayposition_x, arrayposition_y - 1])
                    {
                        case 1:
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 5;
                            break;
                        case 2:
                            inventar.pushSpiegel();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 5;
                            break;
                        case 3:
                            inventar.pushSpiegel();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 5;
                            break;
                        case 4:
                            inventar.pushSplittPrisma();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 5;
                            break;
                        case 6:
                            inventar.pushFarbkristallYellow();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 5;
                            break;
                        case 7:
                            inventar.pushFarbkristallGreen();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 5;
                            break;
                        case 8:
                            inventar.pushFarbkristallCyan();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 5;
                            break;
                        case 9:
                            inventar.pushFarbkristallBlue();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 5;
                            break;
                        case 10:
                            inventar.pushFarbkristallMagenta();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 5;
                            break;
                        default:
                            break;
                    }

                    switch (Säulen_Array[arrayposition_x + 1, arrayposition_y])
                    {
                        case 1:
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 5;
                            break;
                        case 2:
                            inventar.pushSpiegel();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 5;
                            break;
                        case 3:
                            inventar.pushSpiegel();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 5;
                            break;
                        case 4:
                            inventar.pushSplittPrisma();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 5;
                            break;
                        case 6:
                            inventar.pushFarbkristallYellow();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 5;
                            break;
                        case 7:
                            inventar.pushFarbkristallGreen();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 5;
                            break;
                        case 8:
                            inventar.pushFarbkristallCyan();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 5;
                            break;
                        case 9:
                            inventar.pushFarbkristallBlue();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 5;
                            break;
                        case 10:
                            inventar.pushFarbkristallMagenta();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 5;
                            break;
                        default:
                            break;
                    }

                    switch (Säulen_Array[arrayposition_x - 1, arrayposition_y])
                    {
                        case 1:
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 5;
                            break;
                        case 2:
                            inventar.pushSpiegel();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 5;
                            break;
                        case 3:
                            inventar.pushSpiegel();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 5;
                            break;
                        case 4:
                            inventar.pushSplittPrisma();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 5;
                            break;
                        case 6:
                            inventar.pushFarbkristallYellow();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 5;
                            break;
                        case 7:
                            inventar.pushFarbkristallGreen();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 5;
                            break;
                        case 8:
                            inventar.pushFarbkristallCyan();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 5;
                            break;
                        case 9:
                            inventar.pushFarbkristallBlue();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 5;
                            break;
                        case 10:
                            inventar.pushFarbkristallMagenta();
                            inventar.pullFarbkristallRed();
                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 5;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (isgedrücktD2 && Keyboard.GetState().IsKeyUp(Keys.D2))
                    {
                        isgedrücktD2 = false;
                        switch (Säulen_Array[arrayposition_x, arrayposition_y + 1])
                        {
                            case 1:
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 6;
                                break;
                            case 2:
                                inventar.pushSpiegel();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 6;
                                break;
                            case 3:
                                inventar.pushSpiegel();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 6;
                                break;
                            case 4:
                                inventar.pushSplittPrisma();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 6;
                                break;
                            case 5:
                                inventar.pushFarbkristallRed();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 6;
                                break;
                            case 7:
                                inventar.pushFarbkristallGreen();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 6;
                                break;
                            case 8:
                                inventar.pushFarbkristallCyan();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 6;
                                break;
                            case 9:
                                inventar.pushFarbkristallBlue();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 6;
                                break;
                            case 10:
                                inventar.pushFarbkristallMagenta();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 6;
                                break;
                            default:
                                break;
                        }

                        switch (Säulen_Array[arrayposition_x, arrayposition_y - 1])
                        {
                            case 1:
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 6;
                                break;
                            case 2:
                                inventar.pushSpiegel();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 6;
                                break;
                            case 3:
                                inventar.pushSpiegel();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 6;
                                break;
                            case 4:
                                inventar.pushSplittPrisma();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 6;
                                break;
                            case 5:
                                inventar.pushFarbkristallRed();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 6;
                                break;
                            case 7:
                                inventar.pushFarbkristallGreen();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 6;
                                break;
                            case 8:
                                inventar.pushFarbkristallCyan();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 6;
                                break;
                            case 9:
                                inventar.pushFarbkristallBlue();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 6;
                                break;
                            case 10:
                                inventar.pushFarbkristallMagenta();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 6;
                                break;
                            default:
                                break;
                        }

                        switch (Säulen_Array[arrayposition_x + 1, arrayposition_y])
                        {
                            case 1:
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 6;
                                break;
                            case 2:
                                inventar.pushSpiegel();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 6;
                                break;
                            case 3:
                                inventar.pushSpiegel();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 6;
                                break;
                            case 4:
                                inventar.pushSplittPrisma();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 6;
                                break;
                            case 5:
                                inventar.pushFarbkristallRed();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 6;
                                break;
                            case 7:
                                inventar.pushFarbkristallGreen();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 6;
                                break;
                            case 8:
                                inventar.pushFarbkristallCyan();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 6;
                                break;
                            case 9:
                                inventar.pushFarbkristallBlue();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 6;
                                break;
                            case 10:
                                inventar.pushFarbkristallMagenta();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 6;
                                break;
                            default:
                                break;
                        }

                        switch (Säulen_Array[arrayposition_x - 1, arrayposition_y])
                        {
                            case 1:
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 6;
                                break;
                            case 2:
                                inventar.pushSpiegel();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 6;
                                break;
                            case 3:
                                inventar.pushSpiegel();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 6;
                                break;
                            case 4:
                                inventar.pushSplittPrisma();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 6;
                                break;
                            case 5:
                                inventar.pushFarbkristallRed();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 6;
                                break;
                            case 7:
                                inventar.pushFarbkristallGreen();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 6;
                                break;
                            case 8:
                                inventar.pushFarbkristallCyan();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 6;
                                break;
                            case 9:
                                inventar.pushFarbkristallBlue();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 6;
                                break;
                            case 10:
                                inventar.pushFarbkristallMagenta();
                                inventar.pullFarbkristallYellow();
                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 6;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (isgedrücktD3 && Keyboard.GetState().IsKeyUp(Keys.D3))
                        {
                            isgedrücktD3 = false;
                            switch (Säulen_Array[arrayposition_x, arrayposition_y + 1])
                            {
                                case 1:
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y + 1] = 7;
                                    break;
                                case 2:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y + 1] = 7;
                                    break;
                                case 3:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y + 1] = 7;
                                    break;
                                case 4:
                                    inventar.pushSplittPrisma();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y + 1] = 7;
                                    break;
                                case 5:
                                    inventar.pushFarbkristallRed();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y + 1] = 7;
                                    break;
                                case 6:
                                    inventar.pushFarbkristallYellow();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y + 1] = 7;
                                    break;
                                case 8:
                                    inventar.pushFarbkristallCyan();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y + 1] = 7;
                                    break;
                                case 9:
                                    inventar.pushFarbkristallBlue();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y + 1] = 7;
                                    break;
                                case 10:
                                    inventar.pushFarbkristallMagenta();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y + 1] = 7;
                                    break;
                                default:
                                    break;
                            }

                            switch (Säulen_Array[arrayposition_x, arrayposition_y - 1])
                            {
                                case 1:
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y - 1] = 7;
                                    break;
                                case 2:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y - 1] = 7;
                                    break;
                                case 3:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y - 1] = 7;
                                    break;
                                case 4:
                                    inventar.pushSplittPrisma();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y - 1] = 7;
                                    break;
                                case 5:
                                    inventar.pushFarbkristallRed();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y - 1] = 7;
                                    break;
                                case 6:
                                    inventar.pushFarbkristallYellow();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y - 1] = 7;
                                    break;
                                case 8:
                                    inventar.pushFarbkristallCyan();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y - 1] = 7;
                                    break;
                                case 9:
                                    inventar.pushFarbkristallBlue();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y - 1] = 7;
                                    break;
                                case 10:
                                    inventar.pushFarbkristallMagenta();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x, arrayposition_y - 1] = 7;
                                    break;
                                default:
                                    break;
                            }

                            switch (Säulen_Array[arrayposition_x + 1, arrayposition_y])
                            {
                                case 1:
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x + 1, arrayposition_y] = 7;
                                    break;
                                case 2:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x + 1, arrayposition_y] = 7;
                                    break;
                                case 3:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x + 1, arrayposition_y] = 7;
                                    break;
                                case 4:
                                    inventar.pushSplittPrisma();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x + 1, arrayposition_y] = 7;
                                    break;
                                case 5:
                                    inventar.pushFarbkristallRed();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x + 1, arrayposition_y] = 7;
                                    break;
                                case 6:
                                    inventar.pushFarbkristallYellow();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x + 1, arrayposition_y] = 7;
                                    break;
                                case 8:
                                    inventar.pushFarbkristallCyan();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x + 1, arrayposition_y] = 7;
                                    break;
                                case 9:
                                    inventar.pushFarbkristallBlue();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x + 1, arrayposition_y] = 7;
                                    break;
                                case 10:
                                    inventar.pushFarbkristallMagenta();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x + 1, arrayposition_y] = 7;
                                    break;
                                default:
                                    break;
                            }

                            switch (Säulen_Array[arrayposition_x - 1, arrayposition_y])
                            {
                                case 1:
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x - 1, arrayposition_y] = 7;
                                    break;
                                case 2:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x - 1, arrayposition_y] = 7;
                                    break;
                                case 3:
                                    inventar.pushSpiegel();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x - 1, arrayposition_y] = 7;
                                    break;
                                case 4:
                                    inventar.pushSplittPrisma();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x - 1, arrayposition_y] = 7;
                                    break;
                                case 5:
                                    inventar.pushFarbkristallRed();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x - 1, arrayposition_y] = 7;
                                    break;
                                case 6:
                                    inventar.pushFarbkristallYellow();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x - 1, arrayposition_y] = 7;
                                    break;
                                case 8:
                                    inventar.pushFarbkristallCyan();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x - 1, arrayposition_y] = 7;
                                    break;
                                case 9:
                                    inventar.pushFarbkristallBlue();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x - 1, arrayposition_y] = 7;
                                    break;
                                case 10:
                                    inventar.pushFarbkristallMagenta();
                                    inventar.pullFarbkristallGreen();
                                    Säulen_Array[arrayposition_x - 1, arrayposition_y] = 7;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            if (isgedrücktD4 && Keyboard.GetState().IsKeyUp(Keys.D4))
                            {
                                isgedrücktD4 = false;
                                switch (Säulen_Array[arrayposition_x, arrayposition_y + 1])
                                {
                                    case 1:
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 8;
                                        break;
                                    case 2:
                                        inventar.pushSpiegel();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 8;
                                        break;
                                    case 3:
                                        inventar.pushSpiegel();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 8;
                                        break;
                                    case 4:
                                        inventar.pushSplittPrisma();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 8;
                                        break;
                                    case 5:
                                        inventar.pushFarbkristallRed();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 8;
                                        break;
                                    case 6:
                                        inventar.pushFarbkristallYellow();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 8;
                                        break;
                                    case 7:
                                        inventar.pushFarbkristallGreen();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 8;
                                        break;
                                    case 9:
                                        inventar.pushFarbkristallBlue();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 8;
                                        break;
                                    case 10:
                                        inventar.pushFarbkristallMagenta();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y + 1] = 8;
                                        break;
                                    default:
                                        break;
                                }

                                switch (Säulen_Array[arrayposition_x, arrayposition_y - 1])
                                {
                                    case 1:
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 8;
                                        break;
                                    case 2:
                                        inventar.pushSpiegel();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 8;
                                        break;
                                    case 3:
                                        inventar.pushSpiegel();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 8;
                                        break;
                                    case 4:
                                        inventar.pushSplittPrisma();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 8;
                                        break;
                                    case 5:
                                        inventar.pushFarbkristallRed();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 8;
                                        break;
                                    case 6:
                                        inventar.pushFarbkristallYellow();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 8;
                                        break;
                                    case 7:
                                        inventar.pushFarbkristallGreen();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 8;
                                        break;
                                    case 9:
                                        inventar.pushFarbkristallBlue();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 8;
                                        break;
                                    case 10:
                                        inventar.pushFarbkristallMagenta();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x, arrayposition_y - 1] = 8;
                                        break;
                                    default:
                                        break;
                                }

                                switch (Säulen_Array[arrayposition_x + 1, arrayposition_y])
                                {
                                    case 1:
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 8;
                                        break;
                                    case 2:
                                        inventar.pushSpiegel();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 8;
                                        break;
                                    case 3:
                                        inventar.pushSpiegel();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 8;
                                        break;
                                    case 4:
                                        inventar.pushSplittPrisma();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 8;
                                        break;
                                    case 5:
                                        inventar.pushFarbkristallRed();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 8;
                                        break;
                                    case 6:
                                        inventar.pushFarbkristallYellow();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 8;
                                        break;
                                    case 7:
                                        inventar.pushFarbkristallGreen();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 8;
                                        break;
                                    case 9:
                                        inventar.pushFarbkristallBlue();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 8;
                                        break;
                                    case 10:
                                        inventar.pushFarbkristallMagenta();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x + 1, arrayposition_y] = 8;
                                        break;
                                    default:
                                        break;
                                }

                                switch (Säulen_Array[arrayposition_x - 1, arrayposition_y])
                                {
                                    case 1:
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 8;
                                        break;
                                    case 2:
                                        inventar.pushSpiegel();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 8;
                                        break;
                                    case 3:
                                        inventar.pushSpiegel();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 8;
                                        break;
                                    case 4:
                                        inventar.pushSplittPrisma();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 8;
                                        break;
                                    case 5:
                                        inventar.pushFarbkristallRed();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 8;
                                        break;
                                    case 6:
                                        inventar.pushFarbkristallYellow();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 8;
                                        break;
                                    case 7:
                                        inventar.pushFarbkristallGreen();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 8;
                                        break;
                                    case 9:
                                        inventar.pushFarbkristallBlue();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 8;
                                        break;
                                    case 10:
                                        inventar.pushFarbkristallMagenta();
                                        inventar.pullFarbkristallCyan();
                                        Säulen_Array[arrayposition_x - 1, arrayposition_y] = 8;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                if (isgedrücktD5 && Keyboard.GetState().IsKeyUp(Keys.D5))
                                {
                                    isgedrücktD5 = false;
                                    switch (Säulen_Array[arrayposition_x, arrayposition_y + 1])
                                    {
                                        case 1:
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 9;
                                            break;
                                        case 2:
                                            inventar.pushSpiegel();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 9;
                                            break;
                                        case 3:
                                            inventar.pushSpiegel();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 9;
                                            break;
                                        case 4:
                                            inventar.pushSplittPrisma();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 9;
                                            break;
                                        case 5:
                                            inventar.pushFarbkristallRed();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 9;
                                            break;
                                        case 6:
                                            inventar.pushFarbkristallYellow();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 9;
                                            break;
                                        case 7:
                                            inventar.pushFarbkristallGreen();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 9;
                                            break;
                                        case 8:
                                            inventar.pushFarbkristallCyan();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 9;
                                            break;
                                        case 10:
                                            inventar.pushFarbkristallMagenta();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y + 1] = 9;
                                            break;
                                        default:
                                            break;
                                    }

                                    switch (Säulen_Array[arrayposition_x, arrayposition_y - 1])
                                    {
                                        case 1:
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 9;
                                            break;
                                        case 2:
                                            inventar.pushSpiegel();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 9;
                                            break;
                                        case 3:
                                            inventar.pushSpiegel();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 9;
                                            break;
                                        case 4:
                                            inventar.pushSplittPrisma();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 9;
                                            break;
                                        case 5:
                                            inventar.pushFarbkristallRed();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 9;
                                            break;
                                        case 6:
                                            inventar.pushFarbkristallYellow();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 9;
                                            break;
                                        case 7:
                                            inventar.pushFarbkristallGreen();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 9;
                                            break;
                                        case 8:
                                            inventar.pushFarbkristallCyan();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 9;
                                            break;
                                        case 10:
                                            inventar.pushFarbkristallMagenta();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x, arrayposition_y - 1] = 9;
                                            break;
                                        default:
                                            break;
                                    }

                                    switch (Säulen_Array[arrayposition_x + 1, arrayposition_y])
                                    {
                                        case 1:
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 9;
                                            break;
                                        case 2:
                                            inventar.pushSpiegel();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 9;
                                            break;
                                        case 3:
                                            inventar.pushSpiegel();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 9;
                                            break;
                                        case 4:
                                            inventar.pushSplittPrisma();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 9;
                                            break;
                                        case 5:
                                            inventar.pushFarbkristallRed();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 9;
                                            break;
                                        case 6:
                                            inventar.pushFarbkristallYellow();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 9;
                                            break;
                                        case 7:
                                            inventar.pushFarbkristallGreen();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 9;
                                            break;
                                        case 8:
                                            inventar.pushFarbkristallCyan();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 9;
                                            break;
                                        case 10:
                                            inventar.pushFarbkristallMagenta();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x + 1, arrayposition_y] = 9;
                                            break;
                                        default:
                                            break;
                                    }

                                    switch (Säulen_Array[arrayposition_x - 1, arrayposition_y])
                                    {
                                        case 1:
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 9;
                                            break;
                                        case 2:
                                            inventar.pushSpiegel();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 9;
                                            break;
                                        case 3:
                                            inventar.pushSpiegel();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 9;
                                            break;
                                        case 4:
                                            inventar.pushSplittPrisma();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 9;
                                            break;
                                        case 5:
                                            inventar.pushFarbkristallRed();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 9;
                                            break;
                                        case 6:
                                            inventar.pushFarbkristallYellow();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 9;
                                            break;
                                        case 7:
                                            inventar.pushFarbkristallGreen();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 9;
                                            break;
                                        case 8:
                                            inventar.pushFarbkristallCyan();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 9;
                                            break;
                                        case 10:
                                            inventar.pushFarbkristallMagenta();
                                            inventar.pullFarbkristallBlue();
                                            Säulen_Array[arrayposition_x - 1, arrayposition_y] = 9;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    if (isgedrücktD6 && Keyboard.GetState().IsKeyUp(Keys.D6))
                                    {
                                        isgedrücktD6 = false;
                                        switch (Säulen_Array[arrayposition_x, arrayposition_y + 1])
                                        {
                                            case 1:
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 10;
                                                break;
                                            case 2:
                                                inventar.pushSpiegel();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 10;
                                                break;
                                            case 3:
                                                inventar.pushSpiegel();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 10;
                                                break;
                                            case 4:
                                                inventar.pushSplittPrisma();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 10;
                                                break;
                                            case 5:
                                                inventar.pushFarbkristallRed();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 10;
                                                break;
                                            case 6:
                                                inventar.pushFarbkristallYellow();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 10;
                                                break;
                                            case 7:
                                                inventar.pushFarbkristallGreen();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 10;
                                                break;
                                            case 8:
                                                inventar.pushFarbkristallCyan();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 10;
                                                break;
                                            case 9:
                                                inventar.pushFarbkristallBlue();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y + 1] = 10;
                                                break;
                                            default:
                                                break;
                                        }

                                        switch (Säulen_Array[arrayposition_x, arrayposition_y - 1])
                                        {
                                            case 1:
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 10;
                                                break;
                                            case 2:
                                                inventar.pushSpiegel();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 10;
                                                break;
                                            case 3:
                                                inventar.pushSpiegel();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 10;
                                                break;
                                            case 4:
                                                inventar.pushSplittPrisma();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 10;
                                                break;
                                            case 5:
                                                inventar.pushFarbkristallRed();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 10;
                                                break;
                                            case 6:
                                                inventar.pushFarbkristallYellow();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 10;
                                                break;
                                            case 7:
                                                inventar.pushFarbkristallGreen();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 10;
                                                break;
                                            case 8:
                                                inventar.pushFarbkristallCyan();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 10;
                                                break;
                                            case 9:
                                                inventar.pushFarbkristallBlue();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x, arrayposition_y - 1] = 10;
                                                break;
                                            default:
                                                break;
                                        }

                                        switch (Säulen_Array[arrayposition_x + 1, arrayposition_y])
                                        {
                                            case 1:
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 10;
                                                break;
                                            case 2:
                                                inventar.pushSpiegel();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 10;
                                                break;
                                            case 3:
                                                inventar.pushSpiegel();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 10;
                                                break;
                                            case 4:
                                                inventar.pushSplittPrisma();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 10;
                                                break;
                                            case 5:
                                                inventar.pushFarbkristallRed();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 10;
                                                break;
                                            case 6:
                                                inventar.pushFarbkristallYellow();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 10;
                                                break;
                                            case 7:
                                                inventar.pushFarbkristallGreen();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 10;
                                                break;
                                            case 8:
                                                inventar.pushFarbkristallCyan();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 10;
                                                break;
                                            case 9:
                                                inventar.pushFarbkristallBlue();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x + 1, arrayposition_y] = 10;
                                                break;
                                            default:
                                                break;
                                        }

                                        switch (Säulen_Array[arrayposition_x - 1, arrayposition_y])
                                        {
                                            case 1:
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 10;
                                                break;
                                            case 2:
                                                inventar.pushSpiegel();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 10;
                                                break;
                                            case 3:
                                                inventar.pushSpiegel();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 10;
                                                break;
                                            case 4:
                                                inventar.pushSplittPrisma();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 10;
                                                break;
                                            case 5:
                                                inventar.pushFarbkristallRed();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 10;
                                                break;
                                            case 6:
                                                inventar.pushFarbkristallYellow();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 10;
                                                break;
                                            case 7:
                                                inventar.pushFarbkristallGreen();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 10;
                                                break;
                                            case 8:
                                                inventar.pushFarbkristallCyan();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 10;
                                                break;
                                            case 9:
                                                inventar.pushFarbkristallBlue();
                                                inventar.pullFarbkristallMagenta();
                                                Säulen_Array[arrayposition_x - 1, arrayposition_y] = 10;
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        if (isgedrücktE && Keyboard.GetState().IsKeyUp(Keys.E))
                                        {
                                            isgedrücktE = false;
                                            inventar.drawFarbkristalle = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //Kollisionsprüfung
            if (!playercollider.IsColliding(playerposition, newposition, ref levelloader))
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
