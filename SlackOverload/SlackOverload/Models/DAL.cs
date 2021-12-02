using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SlackOverload.Models
{
    public class DAL
    {
        private SqlConnection conn;

        public DAL(string connectionString)
        {
            conn = new SqlConnection(connectionString);
        }

        public int CreateQuestion(Question q, string login)
        {
            q.Posted = DateTime.Now;
            q.Status = 1; //always create status=1
            q.Username = login;

            string addQuery = "INSERT INTO Questions (Username, Title, Detail, Posted, Category, Tags, Status) ";
            addQuery += "VALUES (@Username, @Title, @Detail, @Posted, @Category, @Tags, @Status)"; 

            return conn.Execute(addQuery, q);
        }

        public IEnumerable<Answer> GetAnswersByQuestionId(int id)
        {
            string queryString = "SELECT * FROM Answers WHERE QuestionId = @id";
            return conn.Query<Answer>(queryString, new { id = id });
        }

        public Question GetQuestionById(int id)
        {
            string queryString = "SELECT * FROM Questions WHERE Id = @id";
            return conn.QueryFirstOrDefault<Question>(queryString, new { id = id });
        }

        public IEnumerable<Question> GetQuestionsMostRecent()
        {
            string queryString = "SELECT TOP 20 * FROM Questions ORDER BY Posted DESC";
            return conn.Query<Question>(queryString);
        }

        public int CreateAnswer(Answer a, int id, string login)
        {
            a.Posted = DateTime.Now;
            a.QuestionId = id;
            a.Upvotes = 0;
            a.Username = login;

            string addQuery = "INSERT INTO Answers (Username, Detail, QuestionId, Posted, Upvotes) ";
            addQuery += "VALUES (@Username, @Detail, @QuestionId, @Posted, @Upvotes)";

            return conn.Execute(addQuery, a);
        }

        public int EditQuestionById(Question q)
        {
            string editString = "UPDATE Questions SET Title = @Title, Detail = @Detail, Category = @Category, Tags = @Tags, Status = @Status WHERE Id = @Id";
            return conn.Execute(editString, q);
        }

        public Answer GetAnswerById(int id)
        {
            string queryString = "SELECT * FROM Answers WHERE Id = @id";
            return conn.QueryFirstOrDefault<Answer>(queryString, new { id = id });
        }

        public int EditAnswerById(Answer a)
        {
            string editString = "UPDATE Answers SET Detail = @Detail WHERE Id = @Id";
            return conn.Execute(editString, a);
        }

        public IEnumerable<Question> Search(string search)
        {
            search = '%' + search.ToLower() + '%';

            string queryString = "SELECT * FROM Questions WHERE Detail LIKE @search OR Title LIKE @search";
            return conn.Query<Question>(queryString, new { search = search });
        }
    }
}
