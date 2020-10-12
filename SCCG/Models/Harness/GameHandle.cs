using Models.Harness.GameObservation;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Models.Harness
{
    public class GameHandle
    {
        public Guid GameId;

        public SortedDictionary<int, IGamePlayer> Players = new SortedDictionary<int, IGamePlayer>();
        int curPlayerIndex = -1;

        public IEnumerable<IGameObservation> GetAllObservations()
        {
            List<IGameObservation> observations = new List<IGameObservation>();
            return observations;
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
    }
}
