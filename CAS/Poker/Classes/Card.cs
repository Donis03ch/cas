using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.Poker.Classes
{
    sealed class Card
    {
        #region Properties
        public string CardValue { get; set; }

        public string CardSuit { get; set; }
        #endregion

        #region Constructors
        public Card(string value, string suit)
        {
            CardValue = value;
            CardSuit = suit;
        }
        #endregion
    }
}
