using Models.Fundamentals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.GameplayModels
{
    public class Hand
    {
        public List<ICard> Cards = new List<ICard>();

        public void AddCard(ICard newCard)
        {
            Cards.Add(newCard);
        }
    }
}
