using Models.GameplayModels;
using Models.GameplayModels.GameplayActions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Harness
{
    public interface IGamePlayer
    {
        Task<IGameplayAction> StartTurnAsync();
    }
}
