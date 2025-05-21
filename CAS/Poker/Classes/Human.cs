using CAS.Poker.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CAS.Poker.Users
{
    class Human : Player
    {
        #region Constructors
        public Human(string name, int playerNum)
        {
            Name = (name != "") ? name : $"Player {playerNum}";
        }
        #endregion
    }
}
