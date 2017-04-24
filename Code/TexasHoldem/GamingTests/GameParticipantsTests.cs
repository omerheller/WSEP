﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Gaming;
using User;

namespace Gaming
{

    /**
     * 
     * Class for testing players and spectators
     * 
     * */

    [TestFixture]

    class GameParticipantsTests
    {

        [TestCase]
        public void AddPlayerToGame()
        {
            Game g = new Game(new GamePreferences());
            UserProfile Niv = new UserProfile("Niv", "123");
            PlayingUser nivPlayer = new PlayingUser(Niv, 1000, g);

            Assert.IsEmpty(g.GetPlayers());
            g.addPlayer(nivPlayer);
            Assert.Contains(nivPlayer, g.GetPlayers());
        }

        [TestCase]
        public void AddSpectatorToGame()
        {
            Game g = new Game(new GamePreferences());
            UserProfile Niv = new UserProfile("Niv", "123");
            SpectatingUser nivPlayer = new SpectatingUser(Niv, g);

            Assert.IsEmpty(g.GetSpectators());
            g.addSpectator(nivPlayer);
            Assert.Contains(nivPlayer, g.GetSpectators());
        }

        [TestCase]
        public void RemovePlayerFromGame()
        {
            Game g = new Game(new GamePreferences());
            UserProfile Niv = new UserProfile("Niv", "123");
            PlayingUser nivPlayer = new PlayingUser(Niv, 1000, g);

            g.addPlayer(nivPlayer);
            Assert.IsNotEmpty(g.GetPlayers());
            g.removePlayer(nivPlayer);
            Assert.IsEmpty(g.GetPlayers());
        }

        [TestCase]
        public void RemoveSpectatorFromGame()
        {
            Game g = new Game(new GamePreferences());
            UserProfile Niv = new UserProfile("Niv", "123");
            SpectatingUser nivPlayer = new SpectatingUser(Niv, g);

            g.addSpectator(nivPlayer);
            Assert.IsNotEmpty(g.GetSpectators());
            g.removeSpectator(nivPlayer);
            Assert.IsEmpty(g.GetSpectators());
        }




    }
}