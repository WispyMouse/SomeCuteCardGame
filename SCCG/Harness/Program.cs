using System;
using Engine;
using Models.Harness.GameObservation;
using Models.Harness;
using Harness;
using System.Threading.Tasks;
using Data;
using Models.Data;

namespace SCCG
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            Console.WriteLine(@"
========================= 
SCCG: Some Cute Card Game
by Mint Gould
*************************
SCCG is our attempt at making a bot-friendly trading card game, that fits our ethics standards.
This Harness creates an instance of the game, either for you to play or for a bot to play.
This Harness was intended to be used as a development tool for the game.
=========================");

            Console.WriteLine(">> Creating Game        <<");

            DeckLoadout humanPlayerDeck = await MockupDataGenerator.GetSimpleDeck();
            DeckLoadout aiPlayerDeck = await MockupDataGenerator.GetSimpleDeck();
            GameHandle newGameHandle = EntryPoint.CreateNewGame(humanPlayerDeck, aiPlayerDeck);
            newGameHandle.AssignGamePlayer(MakeHumanPlayer(), 0);
            newGameHandle.AssignGamePlayer(MakeAIPlayer(), 1);

            PrintGameState(newGameHandle);

            Task gameplayTask = EntryPoint.BeginNewGame(newGameHandle);
            gameplayTask.Wait();
            Console.WriteLine("Press anything to end");

            return await Task.FromResult(0);
        }

        static void PrintGameState(GameHandle state)
        {
            foreach (IGameObservation observation in state.GetAllObservations())
            {
                Console.WriteLine(observation.GetShortInformalDescription());
            }
        }

        static IGamePlayer MakeHumanPlayer()
        {
            return new HumanPlayer();
        }

        static IGamePlayer MakeAIPlayer()
        {
            return new AIPlayer();
        }
    }
}
