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
    class GameDataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        private static IDbConnection db = new SqlConnection(connectionString);

        public ObservableCollection<Game> GetGames(int playerId)
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = $"Select * from Game where PlayerId = {playerId}";

            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            ObservableCollection<Game> games = db.Query<Game>(sql).ToObservableCollection();

            return games;
        }

        public int InsertGame(Game game)
        {
            //SQL statement --> insert
            string sql = "INSERT INTO Game (PlayerId, StartTime, EndTime, Result, TotalTurns, TotalCardsPlayed) OUTPUT Inserted.* VALUES (@playerId, @starttime, @endtime, @result, @totalturns, @totalCardsPlayed)";

            var id = db.ExecuteScalar(sql, new
            {
                game.PlayerId,
                game.StartTime,
                game.EndTime,
                game.Result,
                game.TotalTurns,
                game.TotalCardsPlayed
            });

            return (int)id;
        }

        public void UpdateGame(Game game)
        {
            // SQL statement update 
            string sql = $"Update Game set EndTime = @endTime, Result = @result, TotalTurns = @totalTurns, TotalCardsPlayed = @totalCardsPlayed where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                game.EndTime,
                game.Result,
                game.TotalTurns,
                game.TotalCardsPlayed,
                game.Id
            });
        }

        public void DeleteGame(Game game)
        {
            string sql = "DELETE Game WHERE Id = @id";
            db.Execute(sql, new
            {
                game.Id
            }); 
        }





    }
}
