using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoGame2.Extensions;

namespace UnoGame2.Model
{
    class GameCardDataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        private static IDbConnection db = new SqlConnection(connectionString);

/*        public ObservableCollection<GameCard> GetGames()
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from Game";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            ObservableCollection<Game> games = db.Query<Game>(sql).ToObservableCollection();

            return games;
        }*/

        public void InsertGameCard(GameCard gamecard)
        {
        //SQL statement --> insert
        string sql = "INSERT INTO GameCard (GameId, CardId, PlayerId , IsPlayed) OUTPUT Inserted.* VALUES (@gameid, @cardId, @playerid, @isplayed)";

            db.Execute(sql, new
            {
                gamecard.GameId,
                gamecard.CardId,
                gamecard.PlayerId,
                gamecard.IsPlayed
              
            });

        }

        public ObservableCollection<GameCard> GetPlayerHand(int playerId, int gameId)
        {
            string sql = $"SELECT * FROM GameCard WHERE PlayerId = {playerId} AND GameId = {gameId}";
            ObservableCollection<GameCard> playerHand = db.Query<GameCard>(sql).ToObservableCollection();
            return playerHand;
        }

        public void UpdateGameCard(GameCard card)
        {
            // SQL statement update 
            string sql = "Update GameCard set IsPlayed = @isPlayed where PlayerId = @playerId AND CardId = @cardId";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { card.IsPlayed, card.PlayerId, card.CardId });
        }
        public void UpdatePlayedGameCard(GameCard card, int gameId)
        {
            // SQL statement update 
            string sql = $"Update GameCard set IsPlayed = @isPlayed, PlayerId = @playerId where Id = @id AND GameId = {gameId}";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { card.IsPlayed, card.PlayerId, card.Id});
        }

        public ObservableCollection<GameCard> getDeck(int gameId)
        {
            string sql = $"SELECT * FROM GameCard WHERE PlayerId IS NULL AND IsPlayed = 0 AND GameId = {gameId}";
            ObservableCollection<GameCard> cards = db.Query<GameCard>(sql).ToObservableCollection();

            return cards;

        }

        public ObservableCollection<GameCard> getDiscardDeck(int gameId)
        {
            string sql = $"SELECT * FROM GameCard WHERE PlayerId IS NULL AND IsPlayed = 1 AND GameId = {gameId}";
            ObservableCollection<GameCard> cards = db.Query<GameCard>(sql).ToObservableCollection();
            return cards;

        }

        //SQL statement --> delete
        public void DeleteCard(GameCard card)
        {
            //SQL statement --> delete
            string sql = "DELETE GameCard WHERE GameId = @gameId";
            db.Execute(sql, new
            {
                card.GameId,
            });

        }

    }
}
