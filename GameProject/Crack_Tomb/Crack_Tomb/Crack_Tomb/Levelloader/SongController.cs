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

        public SongController(ContentManager content)
        {
            titelscreenSong = content.Load<Song>("Audio/song");
            menuSong = content.Load<Song>("Audio/song");
            inGameSong = content.Load<Song>("Audio/song");
            gewonnenSong = content.Load<Song>("Audio/song");
            verlorenSong = content.Load<Song>("Audio/song");
        }

        public void checkSong(GameState state, GameState oldstate)
        {
            if (Object.ReferenceEquals(state.GetType(), new Titlescreen().GetType()))
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
                            if (Object.ReferenceEquals(state.GetType(), new MainMenu().GetType()) || Object.ReferenceEquals(state.GetType(), new Rangliste().GetType()) || Object.ReferenceEquals(state.GetType(), new Levelauswahl().GetType()) || Object.ReferenceEquals(state.GetType(), new Credits().GetType()))
                            {
                                if (Object.ReferenceEquals(oldstate.GetType(), new MainMenu().GetType()) || Object.ReferenceEquals(oldstate.GetType(), new Rangliste().GetType()) || Object.ReferenceEquals(oldstate.GetType(), new Levelauswahl().GetType()) || Object.ReferenceEquals(oldstate.GetType(), new Credits().GetType()))
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
