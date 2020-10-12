using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Models.Data;
using Models.GameplayModels.GameplayActions;
using Models.Harness;

namespace Engine
{
    public static class EntryPoint
    {
        public static GameHandle CreateNewGame(DeckLoadout teamAlpha, DeckLoadout teamBeta)
        {
            GameHandle newGame = new GameHandle();
            newGame.GameId = Guid.NewGuid();
            newGame.RegisterStartingDeck(teamAlpha, 0);
            newGame.RegisterStartingDeck(teamBeta, 1);
            return newGame;
        }

        public static async Task BeginNewGame(GameHandle handle)
        {
            await DealStartingHands(handle);

            IGamePlayer player = handle.NextPlayer();
            IGameplayAction actionTaken = await player.StartTurnAsync();
            await TakeAction(handle, actionTaken);
        }

        private static async Task DealStartingHands(GameHandle handle)
        {
            foreach (int curIndex in handle.CurrentDecks.Keys)
            {
                handle.CurrentDecks[curIndex].NumberCards.Shuffle();
                handle.CurrentDecks[curIndex].TechCards.Shuffle();

                handle.CurrentDecks[curIndex].NumberCards.DealCard(handle.CurrentDecks[curIndex].CurHand);
                handle.CurrentDecks[curIndex].NumberCards.DealCard(handle.CurrentDecks[curIndex].CurHand);
                handle.CurrentDecks[curIndex].NumberCards.DealCard(handle.CurrentDecks[curIndex].CurHand);
                handle.CurrentDecks[curIndex].NumberCards.DealCard(handle.CurrentDecks[curIndex].CurHand);
                handle.CurrentDecks[curIndex].NumberCards.DealCard(handle.CurrentDecks[curIndex].CurHand);

                handle.CurrentDecks[curIndex].TechCards.DealCard(handle.CurrentDecks[curIndex].CurHand);
                handle.CurrentDecks[curIndex].TechCards.DealCard(handle.CurrentDecks[curIndex].CurHand);
                handle.CurrentDecks[curIndex].TechCards.DealCard(handle.CurrentDecks[curIndex].CurHand);
                handle.CurrentDecks[curIndex].TechCards.DealCard(handle.CurrentDecks[curIndex].CurHand);
                handle.CurrentDecks[curIndex].TechCards.DealCard(handle.CurrentDecks[curIndex].CurHand);
            }
        }

        public static async Task TakeAction(GameHandle handle, IGameplayAction action)
        {
            action.DoTheThing(handle);
            IGamePlayer player = handle.NextPlayer();
            IGameplayAction actionTaken = await player.StartTurnAsync();
            await TakeAction(handle, actionTaken);
        }
    }
}
