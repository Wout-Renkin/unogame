using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame2.Model
{
    class GameCard : BaseModel
    {
        private int id;
        private int gameId;
        private int cardId;
        private int? playerId;
        private bool isPlayed;

        public GameCard()
        {

        }

        public GameCard(int cardId, int gameId, int? playerId)
        {
            GameId = gameId;
            CardId = cardId;
            PlayerId = PlayerId;
        }

        public int Id
        {

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

        public int GameId
        {

            get
            {
                return gameId;
            }

            set
            {
                gameId = value;
                NotifyPropertyChanged();
            }
        }

        public int CardId
        {

            get
            {
                return cardId;
            }

            set
            {
                cardId = value;
                NotifyPropertyChanged();
            }
        }

        public int? PlayerId
        {

            get
            {
                return playerId;
            }

            set
            {        
                playerId = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsPlayed
        {

            get
            {
                return isPlayed;
            }

            set
            {
                isPlayed = value;
                NotifyPropertyChanged();
            }
        }
    }
}
