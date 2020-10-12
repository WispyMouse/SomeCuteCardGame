using Models.Harness;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.GameplayModels.GameplayActions
{
    public interface IGameplayAction
    {
        void DoTheThing(GameHandle handle);
    }
}
