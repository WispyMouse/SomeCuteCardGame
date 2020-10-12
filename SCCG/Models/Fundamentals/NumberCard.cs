using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Fundamentals
{
    public class NumberCard : ICard
    {
        public int FaceValue;

        public NumberCard()
        {

        }

        public NumberCard(int faceValue)
        {
            this.FaceValue = faceValue;
        }
    }
}
