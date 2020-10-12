using Models.Data;
using Models.Fundamentals;
using System;
using System.Threading.Tasks;

namespace Data
{
    public static class MockupDataGenerator
    {
        public static async Task<DeckLoadout> GetSimpleDeck()
        {
            DeckLoadout newDeck = new DeckLoadout();

            newDeck.TechCards = await GetSimpleTechDeck();
            newDeck.NumberCards = await GetSimpleNumbersDeck();

            return newDeck;
        }

        public static async Task<DeckData<TechCard>> GetSimpleTechDeck()
        {
            var newDeck = new DeckData<TechCard>();

            for (int ii = 0; ii <= 10; ii++)
            {
                newDeck.AddCard(new TechCard());
            }

            return newDeck;
        }

        public static async Task<DeckData<NumberCard>> GetSimpleNumbersDeck()
        {
            var newDeck = new DeckData<NumberCard>();

            for (int ii = 2; ii <= 10; ii++)
            {
                newDeck.AddCard(new NumberCard(ii));
                newDeck.AddCard(new NumberCard(ii));
                newDeck.AddCard(new NumberCard(ii));
                newDeck.AddCard(new NumberCard(ii));
            }

            return newDeck;
        }
    }
}
