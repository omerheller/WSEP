﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for GameChat.xaml
    /// </summary>
    public partial class GameChat : Page
    {
        private GameFrame gameFrame;
        public GameChat(GameFrame gf)
        {
            gameFrame = gf;
            InitializeComponent();
        }

        private void SendMessageToChat_Click(object sender, RoutedEventArgs e)
        {
            if (!message.Text.Equals(""))
            {
                int gameID = gameFrame.getGame().GamePref.GameID;
                if (Communication.GameFunctions.Instance.postMessage(message.Text, gameID))
                {
                    message.Text = "";
                    message.Focus();
                }
            }
        }

        public void PushMessage(string sender, string message)
        {
            messages.AppendText(sender+ ": " +message + "\n");
            messages.Focus();
            messages.CaretIndex = messages.Text.Length;
            messages.ScrollToEnd();
        }
    }
}