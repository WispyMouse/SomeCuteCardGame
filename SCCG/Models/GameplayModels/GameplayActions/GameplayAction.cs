using Models.Harness;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.GameplayModels.GameplayActions
{
    public abstract class GameplayAction
    {
        public abstract void DoTheThing(GameHandle handle);
    }
}
