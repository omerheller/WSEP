﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gaming;

namespace GameSystem
{
    public class League
    {
        int minimumRank;
        string name; 
        HashSet<UserProfile> users;
        Game[] games;

        public League(int minimumRank,string name)
        {
            this.name = name;
            this.minimumRank = minimumRank;
            users = new HashSet<UserProfile>();
            games = new Game[50];
        }
        public int MinimumRank
        {
            set { minimumRank = value; }
            get { return minimumRank; }
        }

        public bool addUser(UserProfile user)
        {
            if (users.Contains(user))
                return false;
            users.Add(user);
            user.League = this;
            TexasHoldemSystem.userSystemFactory.getInstance().notify(user.Username, "You Added to League " + name + " with rank " + minimumRank + " !");
            return true;
        }

        public bool removeUser(UserProfile user)
        {
            if (!users.Contains(user))
                return false;
            users.Remove(user);
            return true;
        }
        public List<UserProfile> update(int newRank)
        {
            List<UserProfile> UserToRemove = new List<UserProfile>();
            foreach(UserProfile user in users)
            {
                if (user.Credit < newRank)
                    UserToRemove.Add(user);
            }
            foreach(UserProfile user in UserToRemove)
            {
                users.Remove(user);
            }
            minimumRank = newRank;
            return UserToRemove;
        }
        public bool isUser(UserProfile user)
        {
            return users.Contains(user);
        }

        public Game[] getGames()
        {
            return games;
        }

        public void addGame(Game g)
        {
            for(int i = 0; i < 50; i++)
            {
                if(games[i] == null)
                {
                    g.setID(i);
                    games[i] = g;    
                    break;
                }
            }
        }

        public void removeGame(int gameID)
        {
            games[gameID] = null;
        }
    }
}
