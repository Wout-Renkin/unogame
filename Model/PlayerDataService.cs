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
    class PlayerDataService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        private static IDbConnection db = new SqlConnection(connectionString);

        public int InsertPlayer(Player player)
        {

        //SQL statement --> insert
        string sql = "INSERT INTO Player (Nickname) OUTPUT Inserted.* VALUES (@nickname)";

          var id =  db.ExecuteScalar(sql, new
            {
                player.Nickname,
            });

            return (int)id;
        }

        public Player GetPlayer(int id)
        {
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = $"SELECT * FROM Player WHERE Id={id}";
            
            //Uitvoeren SQL statement op db instance 
            //Type casten van het generieke return type naar een collectie van contactpersonen
            //ObservableCollection<Player> player = db.Query<Player>(sql).ToObservableCollection();
            Player player = db.QuerySingle<Player>(sql);
            return player;
        }

        public void UpdatePlayer(Player player)
        {
            // SQL statement update 
            string sql = "Update Player set Nickname = @Nickname where Id = @id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { player.Nickname, player.Id });
        }

        public void DeletePlayer(Player player)
        {
            //SQL statement --> delete
            string sql = "DELETE Player WHERE Id = @id";
            db.Execute(sql, new
            {
                player.Id
            });

        }

    }
}
