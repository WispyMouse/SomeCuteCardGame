using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Models.Harness;

namespace Engine
{
    public static class EntryPoint
    {
        public static GameHandle CreateNewGame()
        {
            GameHandle newGame = new GameHandle();
            newGame.GameId = Guid.NewGuid();
            return newGame;
        }

        public static async void BeginNewGame(GameHandle handle)
        {
            while (true)
            {
                IGamePlayer player = handle.NextPlayer();
                await player.StartTurnAsync();
                Thread.Sleep(100);
            }
        }
    }
}
