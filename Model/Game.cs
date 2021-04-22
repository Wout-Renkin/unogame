using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame2.Model
{
    class Game:BaseModel
    {
        private int id;
        private int playerId;
        private DateTime startTime;
        private DateTime endTime;
        private string result;
        private int totalCardsPlayed;
        private int totalTurns;

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
        public int PlayerId
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

        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
                NotifyPropertyChanged();
            }
        }

        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                NotifyPropertyChanged();
            }
        }

        public int TotalCardsPlayed
        {
            get
            {
                return totalCardsPlayed;
            }
            set
            {
                totalCardsPlayed = value;
                NotifyPropertyChanged();
            }
        }

        public int TotalTurns
        {
            get
            {
                return totalTurns;
            }
            set
            {
                totalTurns = value;
                NotifyPropertyChanged();
            }
        }
    }
}
