using Models.Fundamentals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.GameplayModels
{
    public class Hand
    {
        public List<Card> Cards = new List<Card>();

        public void AddCard(Card newCard)
        {
            Cards.Add(newCard);
        }
    }
}
