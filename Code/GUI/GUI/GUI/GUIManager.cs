﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using GUI.Models;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Threading;
using System.Threading;

namespace GUI
{
    public class GUIManager : ServerToClientFunctions
    {
        Models.ClientUserProfile profile = null;
        Status status;
        private MainWindow mainWindow;
        Status statusWindow;
        Dictionary<int, int> mutexLocks = new Dictionary<int, int>();
        public GUIManager(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.status = new Status(this);
            gameList = new List<GameFrame>();
            gamesList = new List<ClientGame>();
            statusWindow = new Status(this);
            Communication.GameFunctions.Instance.serverToClient = this;
            Communication.GameCenterFunctions.Instance.serverToClient = this;
            Communication.AuthFunctions.Instance.serverToClient = this;
        }

        public List<GameFrame> gameList { get; set; }
        public List<ClientGame> gamesList { get; set; }

        public void AddGame(ClientGame game)
        {
            gamesList.Add(game);
        }

        public void RemoveGame(ClientGame game)
        {
            gamesList.Remove(game);
        }

        public void AddGameFrame(GameFrame gameFrame)
        {
            gameList.Add(gameFrame);
            status.AddGameToList(gameFrame.gameID);
        }


        public void RemoveGameFrame(GameFrame gf)
        {
            if (gameList.Contains(gf))
            {
                gameList.Remove(gf);
                status.AddGameToList(gf.gameID);
            }
        }

        internal void ConnectToServer()
        {
        TRY_AGAIN:
            if (!(Communication.Server.Instance.connect()))
            {
                MessageBoxResult rs = MessageBox.Show("Could not connect.\nClick Yes to try again or No to quit", "No Connection", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No);
                if (rs == MessageBoxResult.Yes)
                {
                    goto TRY_AGAIN;
                }
                else
                {
                    mainWindow.Close();
                }
            }
            else
            {

                mainWindow.mainFrame.NavigationService.Navigate(new Login(this));

                profile = new Models.ClientUserProfile();
            }
        }

        internal IEnumerable<ClientUserProfile> GetSpectators(int gameID)
        {
            return findGame(gameID).spectators;
        }

        public void RemovePlayer(int gameID,string username)
        {
            Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                GameFrame gameFrame = findGameFrame(gameID);
                gameFrame.RemovePlayer(username);
                ClientGame game = findGame(gameID);
                foreach (ClientUserProfile prof in game.players)
                    if (prof.username.Equals(username))
                        game.players.Remove(prof);
            });
        }

        internal async Task<List<ClientGame>> SearchGames(string criterion,object parameter)
        {
            return await Communication.GameCenterFunctions.Instance.getActiveGames(criterion,parameter);
        }

        internal async Task<List<ClientGame>> SearchGamesToSpectate()
        {
            return await Communication.GameCenterFunctions.Instance.getAllSpectatingGames();
        }

        internal void disconnectFromServer()
        {
            Communication.Server.Instance.disconnect();
        }

        internal async void EditProfile(string username, string password, BitmapImage avatar,UserMainPage mainPage)
        {
            bool changed = false;
            if (!password.Equals(""))
            {
                if (await Communication.AuthFunctions.Instance.editPassword(password))
                {
                    MessageBox.Show("Password Changed!");
                    changed = true;
                }
            }
            if (!username.Equals(""))
            {
                if (await Communication.AuthFunctions.Instance.editUserName(username))
                {
                    MessageBox.Show("Username Changed!");
                    changed = true;
                }
            }
            if (avatar != null)
            {
                byte[] data;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(avatar));
                using(MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                }

                if (data.Length > 32000)
                {
                    MessageBox.Show("Avatar size too big!");
                }
                else
                {
                    if (await Communication.AuthFunctions.Instance.editAvatar(data))
                    {
                        mainPage.ShowAvatar();
                        MessageBox.Show("Avatar Changed!");
                        changed = true;

                    }
                }

            }

            if (changed)
            {
                await RefreshProfile();
                mainWindow.mainFrame.NavigationService.GoBack();
            }
        }

        internal async void Register(string username, string password)
        {
            if (await Communication.AuthFunctions.Instance.register(username, password))
            {
                MessageBox.Show("You can now login with you credentials.", "Registration Successful!", MessageBoxButton.OK, MessageBoxImage.Information);
                mainWindow.mainFrame.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Bad Input, Please try again with different username.", "Registration Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        internal void ClearStatusFrame()
        {
            mainWindow.statusFrame.Content = null;
        }

        internal ClientUserProfile GetProfile()
        {
            return profile;
        }

        internal async Task<bool> PostChatMessage(string message, int gameID)
        {
            return await Communication.GameFunctions.Instance.postMessage(message, gameID);
        }

        internal IEnumerable<ClientUserProfile> GetPlayers(int gameID)
        {
            return findGame(gameID).players;
        }

        private ClientGame findGame(int gameID)
        {
            ClientGame game = null;
            //while (gameList.Count == 0) ;
            foreach (ClientGame g in gamesList)
            {
                if (g.id == gameID)
                {
                    game = g;
                }
            }
            return game;
        }

        private GameFrame findGameFrame(int gameID)
        {
            GameFrame gameFrame = null;
            //while (gameList.Count == 0) ;
            foreach (GameFrame g in gameList)
            {
                if (g.getGame().id == gameID)
                {
                    gameFrame = g;
                }
            }
            return gameFrame;
        }

        internal async void CreateGame(GamePreferences pref)
        {
            Models.ClientGame newGame = await Communication.GameCenterFunctions.Instance.createGame(pref);
            if (newGame == null)
            {
                MessageBox.Show("Something went wrong!", "Oh Oh!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("New game created successfuly!", "New Game Created!", MessageBoxButton.OK, MessageBoxImage.Information);
                mainWindow.mainFrame.NavigationService.GoBack();

            }
        }

        internal IEnumerable<GameFrame> GetGameFrameList()
        {
            return gameList;
        }

        public async Task RefreshProfile()
        {
            profile = await Communication.AuthFunctions.Instance.getClientUser();
            statusWindow.RefreshStatus();
        }

        public async Task Login(string username, string password)
        {
            //main.mainFrame.NavigationService.Navigate(new UserMainPage(main));
            //main.statusFrame.NavigationService.Navigate(new Status(main));
            if (await Communication.AuthFunctions.Instance.login(username, password))
            {
                await RefreshProfile();
                Status status = statusWindow;
                UserMainPage umP = new UserMainPage(this);
                mainWindow.statusFrame.NavigationService.Navigate(status);
                mainWindow.mainFrame.NavigationService.Navigate(umP);
            }
            else
            {
                MessageBox.Show("Bad Input", "    WARNING    ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async Task<bool> SendPMMessage(string to, string message, int gameID)
        {
            return await Communication.GameFunctions.Instance.postWhisperMessage(to, message, gameID);
        }

        public void NavigateToGameFrame(int selectedIndex)
        {
            NavigateToGameFrame(gameList[selectedIndex]);
        }

        public void NotifyTurn(int minimumBet, int gameID)
        {
            Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                Monitor.Enter(mutexLocks[gameID]);
                try
                {
                    GameFrame wantedFrame = findGameFrame(gameID);
                    wantedFrame.GameWindow.MyTurn(minimumBet);
                }
                finally
                {
                    Monitor.Exit(mutexLocks[gameID]);
                }
            });
        }

        internal async void JoinGame(int gameID, int credit)
        {
            int mutexLock = new int();
            mutexLocks.Add(gameID,mutexLock);
            Monitor.Enter(mutexLocks[gameID]);
            try
            {
                Models.ClientGame game = await Communication.GameCenterFunctions.Instance.joinGame(gameID, credit);
                if (game != null)
                {
                    AddGame(game);
                    await RefreshProfile();
                    GameFrame gameFrame = new GameFrame(this, game);
                    AddGameFrame(gameFrame);
                    gameFrame.Init();
                    NavigateToGameFrame(gameFrame);
                }
                else
                {
                    MessageBox.Show("something went wrong:(");
                }
            }
            finally
            {
                Monitor.Exit(mutexLocks[gameID]);
            }
        }

        private void NavigateToGameFrame(GameFrame gameFrame)
        {
            mainWindow.mainFrame.NavigationService.Navigate(gameFrame);
        }

        public void PushHand(Models.PlayerHand hand, int gameID)
        {
            Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                Monitor.Enter(mutexLocks[gameID]);
                try
                {
                    GameFrame wantedFrame = findGameFrame(gameID);
                    wantedFrame.GameWindow.DealCards(hand);
                }
                finally
                {
                    Monitor.Exit(mutexLocks[gameID]);
                }
            });
        }

        public void PushWinners(List<string> winners,int gameID)
        {
            Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                Monitor.Enter(mutexLocks[gameID]);
                try
                {
                    GameFrame gameFrame = findGameFrame(gameID);
                    gameFrame.GameWindow.PushWinners(winners);
                }
                finally
                {
                    Monitor.Exit(mutexLocks[gameID]);
                }
            });
        }

        public void Notify(string message)
        {
            Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                MessageBox.Show("System Message:\n"+message);
            });
        }

        public void PushMoveToGame(Models.Move move, int gameID)
        {
            Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                Monitor.Enter(mutexLocks[gameID]);
                try
                {
                    GameFrame wantedFrame = findGameFrame(gameID);
                    if (move is Models.BetMove)
                    {
                        wantedFrame.GameWindow.PushBetMove((Models.BetMove)move);
                    }
                    else if (move is Models.FoldMove)
                    {
                        wantedFrame.GameWindow.PushFoldMove((Models.FoldMove)move);
                    }
                    else if (move is Models.GameStartMove)
                    {
                        wantedFrame.GameWindow.PushGameStartMove((Models.GameStartMove)move);
                    }
                    else if (move is Models.NewCardMove)
                    {
                        wantedFrame.GameWindow.NewCardMove((Models.NewCardMove)move);
                    }
                    else if (move is Models.EndGameMove)
                    {
                        wantedFrame.GameWindow.PushEndGameMove((Models.EndGameMove)move);
                    }
                }
                finally
                {
                    Monitor.Exit(mutexLocks[gameID]);
                }
        });
        }

        internal async void QuitGame(int gameID)
        {
            MessageBoxResult rs = MessageBox.Show("Are you sure you want to quit?", "Quit", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No);
            if (rs == MessageBoxResult.Yes)
            {
                if (await Communication.GameFunctions.Instance.removePlayer(gameID))
                {
                    RemoveGame(findGame(gameID));
                    RemoveGameFrame(findGameFrame(gameID));
                    await RefreshProfile();
                    mainWindow.mainFrame.NavigationService.GoBack();
             
                }
                else
                    MessageBox.Show("Something went wrong", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        internal async void Bet(int gameID, int amount, int minimumBet, Game gameWindow)
        {
            if (amount >= minimumBet)
            {
                if (await Communication.GameFunctions.Instance.bet(gameID, amount.ToString()))
                {
                    gameWindow.HideBetElements();
                    //MessageBox.Show("Bet Accepted", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Minimum bet is " + minimumBet + "! please try again.", "Too Low!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        internal async void Fold(int gameID, Game gameWindow)
        {
            if (await Communication.GameFunctions.Instance.bet(gameID, "Fold"))
            {
                gameWindow.HideBetElements();
                MessageBox.Show("You have folded", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        internal void GoToGameCenter()
        {
            mainWindow.mainFrame.NavigationService.Navigate(new GameCenter(this));
        }

        private Status GetStatusFrame()
        {
            return status;
        }

        public void PlayerJoinedGame(int gameID,Models.ClientUserProfile prof)
        {
            Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                Monitor.Enter(mutexLocks[gameID]);
                try
                {
                    GameFrame gameFrame = findGameFrame(gameID);
                    if (gameFrame != null)
                    {
                        gameFrame.GamePM.AddPlayer(prof);

                        gameFrame.getGame().AddPlayer(prof);
                    }
                }
                finally
                {
                    Monitor.Exit(mutexLocks[gameID]);
                }
        });
        }

        public void PushPMMessage(int gameId, string sender, string message)
        {
            Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                Monitor.Enter(mutexLocks[gameId]);
                try
                {
                    GameFrame gameFrame = findGameFrame(gameId);
                    gameFrame.GamePM.PushMessage(sender, message);
                }
                finally
                {
                    Monitor.Exit(mutexLocks[gameId]);
                }

            });
        }

        public void PushChatMessage(int gameId, string sender, string message)
        {
            Dispatcher.CurrentDispatcher.InvokeAsync(() =>
            {
                Monitor.Enter(mutexLocks[gameId]);
                try
                {
                    GameFrame gameFrame = findGameFrame(gameId);
                    gameFrame.GameChat.PushMessage(sender, message);
                }
                finally
                {
                    Monitor.Exit(mutexLocks[gameId]);
                }
            });
        }
    }
}
