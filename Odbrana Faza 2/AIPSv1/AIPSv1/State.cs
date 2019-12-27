using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIPSv1
{
    public class State
    {
        public int plOneId;
        public int plTwoId;

        public int playerOneLifePoints;
        public int playerTwoLifePoints;

        public List<Card> playerOneHand;
        public List<Card> playerTwoHand;

        public List<Card> playerOneTable;
        public List<Card> playerTwoTable;

        public List<Card> playerOneDeck;
        public List<Card> playerTwoDeck;

        public State()
        {
            playerOneHand = new List<Card>(); 
            playerTwoHand = new List<Card>();
                 
            playerOneTable = new List<Card>();
            playerTwoTable = new List<Card>();
                   
            playerOneDeck = new List<Card>();
            playerTwoDeck = new List<Card>();
        }

        public void InitDeckOne(List<Card> karte)
        {
            this.playerOneDeck.AddRange(karte);
        }

        public void InitDeckTwo(List<Card> karte)
        {
            this.playerTwoDeck.AddRange(karte);
        }

        public void drawCardOne(int nmb)
        {
            this.playerOneHand.AddRange(this.playerOneDeck.GetRange(0, nmb));
            playerOneDeck.RemoveRange(0, nmb);
        }

        public void drawCardTwo(int nmb)
        {
            this.playerTwoHand.AddRange(this.playerTwoDeck.GetRange(0, nmb));
            playerTwoDeck.RemoveRange(0, nmb);
        }

        public List<Card> Shuffle(List<Card> lsc)
        {
            Random rnd = new Random();
            var count = lsc.Count;
            var last = count - 1;
            for(var i = 0; i< last; i++)
            {
                var r = rnd.Next(i, count);
                var tmp = lsc[i];
                lsc[i] = lsc[r];
                lsc[r] = tmp;
            }
            return lsc;
        }

        public void ShuffleOne()
        {
            playerOneDeck = Shuffle(playerOneDeck);
        }

        public void ShuffleTwo()
        {
            playerTwoDeck = Shuffle(playerTwoDeck);
        }

        public void AddCardToHandOne(Card card)
        {
            playerOneHand.Add(card);
        }

        public void AddCardToHandTwo(Card card)
        {
            playerTwoHand.Add(card);
        }

        public void DamageLifePointsOne(int n)
        {
            playerOneLifePoints -= n;
        }

        public void DamageLifePointsTwo(int n)
        {
            playerTwoLifePoints -= n;
        }

        public void HealLifePointsOne(int n)
        {
            playerOneLifePoints += n;
        }

        public void HealLifePointsTwo(int n)
        {
            playerTwoLifePoints += n;
        }

        public void AddCardToTableOne(Card card)
        {
            playerOneTable.Add(card);
        }

        public void AddCardToTableTwo(Card card)
        {
            playerTwoTable.Add(card);
        }
    }
}
