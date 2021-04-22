using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoGame2.Model;

namespace UnoGame2.Messages
{
    class WinnerMessage
    {
        private Player winner;

        public Player Winner
        {
            get
            {
                return winner;
            }
            set
            {
                winner = value;
            }
        }
        public WinnerMessage(Player winner)
        {
            Winner = winner;
        }
    }

}
