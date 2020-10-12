using Models.Harness;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Harness
{
    class AIPlayer : IGamePlayer
    {
        public async Task StartTurnAsync()
        {
            Console.WriteLine("The AI passes the turn, doing nothing!");
            await Task.CompletedTask;
        }
    }
}
