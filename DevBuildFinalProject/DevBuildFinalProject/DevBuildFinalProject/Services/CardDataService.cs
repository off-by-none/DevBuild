using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DevBuildFinalProject.Models;

namespace DevBuildFinalProject.Services
{
    public class CardDataService : ICardDataService
    {
        private readonly string connString;

        public CardDataService(IConfiguration config)
        {
            connString = config.GetConnectionString("default");
        }

        public IEnumerable<Card> GetAllCards()
        {
            SqlConnection conn = new SqlConnection(connString);

            string command = "SELECT * FROM Card";

            IEnumerable<Card> result = conn.Query<Card>(command);

            conn.Close();

            return result;
        }

        public IEnumerable<Card> GetAllCardsOwnedById(int id)
        {
            SqlConnection conn = new SqlConnection(connString);

            string command = "select Character.CharName, Card.* from Deck ";
            command += "left join Card on Card.Id = Deck.CardId	left join ";
            command += "Character on Character.Id = Deck.CharId where CharId = @val";

            IEnumerable<Card> result = conn.Query<Card>(command, new { val = id });

            conn.Close();

            return result;
        }

        public Card ReturnCardById(int id)
        {
            SqlConnection conn = new SqlConnection(connString);

            string command = "select * from card where id = @val";

            Card result = conn.QueryFirstOrDefault<Card>(command, new { val = id });

            return result;
        }

    }
}
