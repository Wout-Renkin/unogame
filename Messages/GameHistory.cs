using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoGame2.Model;

namespace UnoGame2.Messages
{
    class GameHistory
    {
        private Player player;

        public Player Player {
            get 
            {
                return player;
            }
            set
            {
                player = value;
            }
        }

        public GameHistory(Player player)
        {
            Player = player;
        }
    }
}
