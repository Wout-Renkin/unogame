using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame2.Model
{
    class CombinedPlayerCard:BaseModel
    {
        private GameCard gameCard;
        private Card card;

        public CombinedPlayerCard(GameCard gameCard)
        {
            GameCard = gameCard;
            AddCard();
        }

        public GameCard GameCard { 
            get 
            {
                return gameCard;
            }
            set 
            {
                gameCard = value;
                NotifyPropertyChanged();
            } 
        }

        public Card Card
        {
            get
            {
                return card;
            }
            set
            {
                card = value;
                NotifyPropertyChanged();
            }
        }

        public void AddCard() {
            CardDataService ds = new CardDataService();
            Card = ds.GetCard(GameCard.CardId);
        }
    }
}
