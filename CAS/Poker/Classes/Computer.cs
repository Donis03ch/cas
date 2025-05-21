using CAS.Poker.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CAS.Poker.Classes
{
    class Computer : Player
    {
        #region Constructors
        public Computer(List<string> names)
        {
            Name = SetComputerName(names);
        }
        #endregion

        #region Methods
        private string SetComputerName(List<string> names)
        {
            Random rand = new Random();
            string name = names[rand.Next(0, names.Count)];
            names.Remove(name);  // To avoid duplicate computer names.

            return name;
        }
        #endregion
    }
}
