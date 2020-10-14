using Models.Fundamentals;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Models.GameplayModels
{
    public class DeckDataCurrentStatus<T> where T : Card
    {
        public List<T> Cards = new List<T>();

        public DeckDataCurrentStatus(DeckData<T> baseData)
        {
            this.Cards = new List<T>(baseData.Cards);
        }

        public void Shuffle()
        {
            Random newRandom = new Random();
            List<T> newDeck = new List<T>();
            List<T> oldDeck = new List<T>(Cards);

            while (oldDeck.Any())
            {
                int randomIndex = newRandom.Next(0, oldDeck.Count);
                newDeck.Add(oldDeck[randomIndex]);
                oldDeck.RemoveAt(randomIndex);
            }

            Cards = newDeck;
        }

        public void DealCard(Hand toHand)
        {
            Contract.Requires(Cards.Any());

            int lastCardIndex = Cards.Count - 1;
            toHand.AddCard(Cards[lastCardIndex]);
            Cards.RemoveAt(lastCardIndex);
        }
    }
}
