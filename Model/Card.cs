using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame2.Model
{
    class Card:BaseModel
    {
        private int id;
        private string color;
        private string kind;
        private string image;

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

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                NotifyPropertyChanged();
            }
        }

        public string Kind
        {
            get
            {
                return kind;
            }
            set
            {
                kind = value;
                NotifyPropertyChanged();
            }
        }

        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = AppDomain.CurrentDomain.BaseDirectory + "Images\\UNOCards\\" + value + ".png";
                NotifyPropertyChanged();
            }
        }

    }
}
