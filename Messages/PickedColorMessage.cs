using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame2.Messages
{
    class PickedColorMessage
    {
        private string color;

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public PickedColorMessage(string color)
        {
            Color = color;
        }
    }
}
