using System;
using Engine;
using Models.Harness.GameObservation;
using Models.Harness;
using Harness;

namespace SCCG
{
    class Program
    {
        static void Main(string[] args)
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

            GameHandle newGameHandle = EntryPoint.CreateNewGame();
            newGameHandle.AssignGamePlayer(MakeHumanPlayer(), 0);
            newGameHandle.AssignGamePlayer(MakeAIPlayer(), 1);

            PrintGameState(newGameHandle);
            EntryPoint.BeginNewGame(newGameHandle);
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
