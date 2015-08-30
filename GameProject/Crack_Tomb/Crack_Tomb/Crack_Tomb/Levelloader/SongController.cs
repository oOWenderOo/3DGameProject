using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using MainMenuCo;
using Crack_Tomb.Menuestruktur;

namespace Crack_Tomb.Levelloader
{
    class SongController
    {
        Song titelscreenSong;
        Song menuSong;
        Song inGameSong;
        Song gewonnenSong;
        Song verlorenSong;
        int anzahllevel;

        public SongController(ContentManager content, int anzahllevel)
        {
            this.anzahllevel = anzahllevel;
            titelscreenSong = content.Load<Song>("Audio/titelscreenSong");
            menuSong = content.Load<Song>("Audio/menuSong");
            inGameSong = content.Load<Song>("Audio/inGameSong");
            gewonnenSong = content.Load<Song>("Audio/gewonnenSong");
            verlorenSong = content.Load<Song>("Audio/verlorenSong");

            MediaPlayer.IsRepeating = true;
        }

        public void checkSong(GameState state, GameState oldstate)
        {
            if (Object.ReferenceEquals(state.GetType(), new Titlescreen(anzahllevel).GetType()))
            {
                MediaPlayer.Play(titelscreenSong);
            }
            else
            {
                if (Object.ReferenceEquals(state.GetType(), new Gewonnen().GetType()))
                {
                    MediaPlayer.Play(gewonnenSong);
                }
                else
                {
                    if (Object.ReferenceEquals(state.GetType(), new GameOver().GetType()))
                    {
                        MediaPlayer.Play(verlorenSong);
                    }
                    else
                    {
                        if (Object.ReferenceEquals(state.GetType(), new InGame().GetType()))
                        {
                            MediaPlayer.Play(inGameSong);
                        }
                        else
                        {
                            if (Object.ReferenceEquals(state.GetType(), new MainMenu(anzahllevel).GetType()) || Object.ReferenceEquals(state.GetType(), new Rangliste(anzahllevel).GetType()) || Object.ReferenceEquals(state.GetType(), new Levelauswahl(anzahllevel).GetType()) || Object.ReferenceEquals(state.GetType(), new Credits(anzahllevel).GetType()))
                            {
                                if (Object.ReferenceEquals(oldstate.GetType(), new MainMenu(anzahllevel).GetType()) || Object.ReferenceEquals(oldstate.GetType(), new Rangliste(anzahllevel).GetType()) || Object.ReferenceEquals(oldstate.GetType(), new Levelauswahl(anzahllevel).GetType()) || Object.ReferenceEquals(oldstate.GetType(), new Credits(anzahllevel).GetType()))
                                { }
                                else
                                {
                                    MediaPlayer.Play(menuSong);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
