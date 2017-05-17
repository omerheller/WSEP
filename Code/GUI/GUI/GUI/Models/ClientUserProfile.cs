﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Models
{
    public class ClientUserProfile
    {
        private string username;
        private byte [] avatar;
        private int credit;
        private int leagueId;
        private Statistics userStat;


        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public byte [] Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }

        public int Credit
        {
            get { return credit; }
            set { credit = value; }
        }

        public int LeagueId
        {
            get { return leagueId; }
            set { leagueId = value; }
        }

        public Statistics UserStat
        {
            get { return userStat; }
            set { userStat = value; }
        }
    }
}

