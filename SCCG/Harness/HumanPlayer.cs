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
        public async Task<IGameplayAction> StartTurnAsync()
        {
            Console.Write("Press Enter to pass the turn:");
            Console.ReadLine();
            return new PassTheTurnAction();
        }
    }
}
