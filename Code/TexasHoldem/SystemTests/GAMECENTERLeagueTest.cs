﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GameSystem;
using System;
using Gaming;

namespace SystemTests
{
    [TestFixture]
    public class GameCenterLeagueTest
    {
        GameCenter gc;
        TexasHoldemSystem us;

        [SetUp]
        public void before()
        {
            gc = GameCenter.GameCenterFactory.getInstance();
            us = TexasHoldemSystem.userSystemFactory.getInstance();
            us.register("user", "123");
            us.login("user", "123");
        }

        [TearDown]
        public void after()
        {
            gc.getLeagues().Clear();
            gc.createNewLeague(0);
            us.clearUsers();
        }

        [TestCase]
        public void hasDefaultLeague()
        {
            Assert.AreEqual(1, gc.getLeagues().Count);
        }

        [TestCase]
        public void CreateNewLeagueTest()
        {
            Assert.True(gc.createNewLeague(1000));
            Assert.True(gc.getLeagues().Keys.Contains(0));
            Assert.True(gc.getLeagues().Keys.Contains(1000));
        }

        [TestCase]
        public void CreateNewLeagueWithSameRankTest()
        {
            Assert.False(gc.createNewLeague(0));
            Assert.AreEqual(1, gc.getLeagues().Count);
        }

        [TestCase]
        public void CreateNewLeagueWithSameRangeRankTest()
        {
            Assert.False(gc.createNewLeague(100));
            Assert.AreEqual(1, gc.getLeagues().Count);
        }

        [TestCase]
        public void addUserToAppropriateLeague()
        {
            Assert.True(gc.getLeagueByRank(0).isUser(us.getUser("user")));
        }

        [TestCase]
        public void removeExistedUser()
        {
            League league = gc.getLeagueByRank(0);
            UserProfile user = us.getUser("user");

            Assert.True(league.isUser(user));
            Assert.True(gc.removeUserFromLeague(user, league));
            Assert.False(league.isUser(user));
        }

        [TestCase]
        public void removeUnExistedUser()
        {
            gc.createNewLeague(1000);
            League league = gc.getLeagueByRank(1000);
            UserProfile user = us.getUser("user");

            Assert.False(league.isUser(user));
            Assert.False(gc.removeUserFromLeague(user, league));
        }  

        [TestCase]
        public void updateLeagueWhenCreditChange()
        {
            gc.createNewLeague(1000);
            League league1 = gc.getLeagueByRank(0);
            League league2 = gc.getLeagueByRank(1000);
            UserProfile user = us.getUser("user");
            PlayingUser player = new PlayingUser(user.Username, 5, null);
            user.Credit = 999;
            user.UserStat.Losses = 10;

            Assert.True(league1.isUser(user));
            Assert.False(league2.isUser(user));
            gc.updateLeagueToUser(player);
            Assert.False(league1.isUser(user)); 
            Assert.True(league2.isUser(user));
        }

        [TestCase]
        public void updateLeagueWhenCreditChange_UpNewLeague()
        {
            League league1 = gc.getLeagueByRank(0);
            
            UserProfile user = us.getUser("user");
            PlayingUser player = new PlayingUser(user.Username, 5, null);
            user.Credit = 999;
            user.UserStat.Losses = 10;

            Assert.True(league1.isUser(user));
            Assert.AreEqual(null, gc.getLeagueByRank(1000));

            gc.updateLeagueToUser(player);

            Assert.False(league1.isUser(user));
            Assert.AreEqual(2, gc.getLeagues().Count);

            League league2 = gc.getLeagueByRank(1000);
            
            Assert.True(league2.isUser(user));
        }

        [TestCase]
        public void unknownPlayerSuccessChangeLeague()
        {
            gc.createNewLeague(1000);
            League league2 = gc.getLeagueByRank(1000);
            UserProfile user = us.getUser("user");
            Assert.True(gc.unknownUserEditLeague(user, league2));
        }

        [TestCase]
        public void notUnknownPlayerUnsuccessChangeLeague()
        {
            gc.createNewLeague(1000);
            League league2 = gc.getLeagueByRank(1000);
            UserProfile user = us.getUser("user");
            user.UserStat.Winnings = 12;
            Assert.False(gc.unknownUserEditLeague(user, league2));
        }
    }
}
