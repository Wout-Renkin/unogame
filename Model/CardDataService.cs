using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoGame2.Extensions;
using System.Configuration;

namespace UnoGame2.Model
{
    class CardDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString = ConfigurationManager.ConnectionStrings["local"].ConnectionString;

        // Aanmaken van een object uit de IDbConnection class en instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);


        public ObservableCollection<Card> GetCards()
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Card";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            ObservableCollection<Card> cards = db.Query<Card>(sql).ToObservableCollection();

            return cards;
        }

        public Card GetCard(int cardId)
        {
            string sql = $"SELECT * FROM Card WHERE Id = {cardId}";
            Card card = db.QuerySingle<Card>(sql);
            return card;
        }



    }
}
