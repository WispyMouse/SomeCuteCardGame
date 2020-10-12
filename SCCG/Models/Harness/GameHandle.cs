using Models.Data;
using Models.Fundamentals;
using Models.GameplayModels;
using Models.Harness.GameObservation;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Models.Harness
{
    public class GameHandle : ICloneable
    {
        public Guid GameId;

        public Dictionary<int, DeckLoadout> StartingDecks = new Dictionary<int, DeckLoadout>();
        public Dictionary<int, DeckLoadoutCurrentStatus> CurrentDecks = new Dictionary<int, DeckLoadoutCurrentStatus>();

        public SortedDictionary<int, IGamePlayer> Players = new SortedDictionary<int, IGamePlayer>();
        int curPlayerIndex = -1;

        public IEnumerable<IGameObservation> GetAllObservations()
        {
            List<IGameObservation> observations = new List<IGameObservation>();

            foreach (int curIndex in Players.Keys)
            {
                observations.Add(new LoggingObservation($"Player {curIndex}; # Hand {CurrentDecks[curIndex].CurHand.Cards.Count}; # Numbers Deck {CurrentDecks[curIndex].NumberCards.Cards.Count}; # Tech Deck {CurrentDecks[curIndex].TechCards.Cards.Count}"));

                foreach (ICard curCard in CurrentDecks[curIndex].CurHand.Cards)
                {
                    Console.WriteLine($"* {curCard.ToString()}");
                }
            }

            return observations;
        }

        public void RegisterStartingDeck(DeckLoadout loadout, int playerSpot)
        {
            StartingDecks.Add(playerSpot, loadout);
            CurrentDecks.Add(playerSpot, new DeckLoadoutCurrentStatus(loadout));
        }

        public void AssignGamePlayer(IGamePlayer player, int playerSpot)
        {
            Players.Add(playerSpot, player);
        }

        public IGamePlayer NextPlayer()
        {
            Contract.Requires(Players.Any());

            if (Players.Keys.Max() <= curPlayerIndex)
            {
                curPlayerIndex = Players.Keys.Min();
            }
            else
            {
                curPlayerIndex = Players.Keys.Where(index => index > curPlayerIndex).Min();
            }

            return Players[curPlayerIndex];
        }

        public object Clone()
        {
            return new GameHandle()
            {
                GameId = this.GameId,

                StartingDecks = new Dictionary<int, DeckLoadout>(this.StartingDecks),

                Players = new SortedDictionary<int, IGamePlayer>(this.Players),
                curPlayerIndex = this.curPlayerIndex,
            };
        }
    }
}
