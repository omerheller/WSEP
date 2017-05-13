﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Gaming;

namespace GameSystem
{
    public class UserProfile
    {
        private string username;
        private string password;
        private Image avatar;
        private int credit;
        private League league;
        private List<Notification> notifications = new List<Notification>();
        private Statistics userStat;

        public string Username
        {
            get{ return username;}
            set{username = value;}
        }

        public string Password
        {
            get{return password;}
            set {password = value; }
        }

        public Image Avatar
        {
            get {return avatar;}
            set {avatar = value;}
        }

        public int Credit
        {
            get { return credit; }
            set { credit = value; }
        }

        public League League
        {
            get
            {
                return league;
            }

            set
            {
                league = value;
            }
        }

        public Statistics UserStat
        {
            get
            {
                return userStat;
            }

            set
            {
                userStat = value;
            }
        }

        public UserProfile(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            userStat = new Statistics();
        }
        public UserProfile(string username,string password,Image avatar)
        {
            this.Username = username;
            this.Password = password;
            this.Avatar = avatar;
            userStat = new Statistics();
        }

        public void addNotify(String message)
        {
            Notification notification = new Notification(message);
            notifications.Add(notification);
        }

        public void setUserLeague(League league)
        {
            this.league = league;
        }

        public void updateStatistics(PlayingUser user)
        {
            userStat.Winnings += user.Winnings;
            userStat.Losses += user.Losses;
            userStat.BiggestWin = (userStat.BiggestWin > user.BiggestWin) ? userStat.BiggestWin : user.BiggestWin;
            userStat.HighestHand = (userStat.HighestHand < user.HighestHand) ? userStat.HighestHand : user.HighestHand;
            userStat.BiggestWallet = (Credit > userStat.BiggestWallet) ? Credit : userStat.BiggestWallet;
        }
    }
}
