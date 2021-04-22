using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame2.Model
{
    class Player:BaseModel
    {
        private int id;
        private string nickname;

      
        public int Id { 

            get 
            { 
                return id; 
            } 

            set 
            { 
                id = value;
                NotifyPropertyChanged();
            } 
        }
        public string Nickname
        {

            get
            {
                return nickname;
            }

            set
            {
                nickname = value;
                NotifyPropertyChanged();
            }
        }

    }
}
