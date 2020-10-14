using Models.GameplayModels.GameplayActions;
using Models.Harness;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Harness
{
    class HumanPlayer : IGamePlayer
    {
        public async Task<GameplayStartAction> GameplayStartAsync()
        {
            Console.WriteLine("This is where you would input your starting conditions and such.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            return new GameplayStartAction()
            {
                PlayerPlacements = new PlayerPlacement[] { }
            };
        }

        public async Task<GameplayAction> StartTurnAsync()
        {
            Console.Write("Press Enter to pass the turn:");
            Console.ReadLine();
            return new PassTheTurnAction();
        }
    }
}
