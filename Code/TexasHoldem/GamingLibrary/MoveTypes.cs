﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming
{
    public class NewCardMove : Move
    {
        Card[] cards;
        public NewCardMove(Card[] cards)
        {
            this.cards = cards;
        }

        public override void update(ref IDictionary<string, int> playerBets, ref Card[] cards, ref IDictionary<string, PlayerHand> playerHands)
        {
            cards = this.cards;
        }
    }
    public class GameStartMove : Move
    {
        IDictionary<string, int> playerBets;
        
        public GameStartMove(IDictionary<string, int> playerBets)
        {
            this.playerBets = playerBets;
        }

        public override void update(ref IDictionary<string, int> playerBets, ref Card[] cards, ref IDictionary<string, PlayerHand> playerHands)
        {
            playerBets = this.playerBets;
        }
    }

    public class RevealCardsMove : Move
    {
        IDictionary<string, PlayerHand> playerHands;

        public RevealCardsMove(IDictionary<string, PlayerHand> playerHands)
        {
            this.playerHands = playerHands;
        }

        public override void update(ref IDictionary<string, int> playerBets, ref Card[] cards, ref IDictionary<string, PlayerHand> playerHands)
        {
            playerHands = this.playerHands;
        }
    }

    public class BetMove : Move
    {
        IDictionary<string, int> playerBets;

        public BetMove(IDictionary<string, int> playerBets)
        {
            this.playerBets = playerBets;
        }

        public override void update(ref IDictionary<string, int> playerBets, ref Card[] cards, ref IDictionary<string, PlayerHand> playerHands)
        {
            playerBets = this.playerBets;
        }
    }

}
