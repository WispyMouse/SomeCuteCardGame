using Models.Data;
using Models.Fundamentals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.GameplayModels
{
    public class DeckLoadoutCurrentStatus
    {
        public DeckDataCurrentStatus<NumberCard> NumberCards;
        public DeckDataCurrentStatus<TechCard> TechCards;
        public Hand CurHand;

        public DeckLoadoutCurrentStatus(DeckLoadout baseData)
        {
            this.NumberCards = new DeckDataCurrentStatus<NumberCard>(baseData.NumberCards);
            this.TechCards = new DeckDataCurrentStatus<TechCard>(baseData.TechCards);
            this.CurHand = new Hand();
        }
    }
}
