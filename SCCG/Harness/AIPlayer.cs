using Models.GameplayModels.GameplayActions;
using Models.Harness;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Harness
{
    class AIPlayer : IGamePlayer
    {
        public async Task<GameplayStartAction> GameplayStartAsync()
        {
            Console.WriteLine("The AI would now prepare their side of the field.");
            return new GameplayStartAction()
            {
                  PlayerPlacements = new PlayerPlacement[] {}
            };
        }

        public async Task<GameplayAction> StartTurnAsync()
        {
            Console.WriteLine("The AI passes the turn, doing nothing!");
            return new PassTheTurnAction();
        }
    }
}
