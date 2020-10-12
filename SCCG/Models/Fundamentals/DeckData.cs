using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Fundamentals
{
    public class DeckData<T> where T : ICard
    {
        public List<T> Cards = new List<T>();

        public void AddCard(T toAdd)
        {
            this.Cards.Add(toAdd);
        }
    }
}
