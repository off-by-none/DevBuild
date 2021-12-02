using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp
{
    public class Movie
    {
        #region fields
        private int id;
        private string title;
        private int year;
        private int runTime;
        private double imdbRating;
        private string genre;
        private string director;
        private string leadActor;
        private string supportingActor;
        private string thirdActor;
        private string character1;
        private string character2;
        private string character3;
        private List<string> messagePosts;
        private static int count = 1;
        #endregion  fields


        #region properties
        public int Id { get => id; }
        public string Title { get => title; set => title = value; }
        public int Year { get => year; set => year = value; }
        public int RunTime { get => runTime; set => runTime = value; }
        public double ImdbRating { get => imdbRating; set => imdbRating = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Director { get => director; set => director = value; }
        public string LeadActor { get => leadActor; set => leadActor = value; }
        public string SupportingActor { get => supportingActor; set => supportingActor = value; }
        public string ThirdActor { get => thirdActor; set => thirdActor = value; }
        public string Character1 { get => character1; set => character1 = value; }
        public string Character2 { get => character2; set => character2 = value; }
        public string Character3 { get => character3; set => character3 = value; }
        public List<string> MessagePosts { get => messagePosts; set => messagePosts = value; }
        #endregion properties


        #region constructors
        public Movie()
        {
        }


        public Movie(string title, int year, int runTime, double imdbRating, string genre, string director,
                     string leadActor, string supportingActor, string thirdActor, string character1, string character2, string character3, List<string> messagePosts)
        {
            this.id = count;
            this.title = title;
            this.year = year;
            this.runTime = runTime;
            this.imdbRating = imdbRating;
            this.genre = genre;
            this.director = director;
            this.leadActor = leadActor;
            this.supportingActor = supportingActor;
            this.thirdActor = thirdActor;
            this.character1 = character1;
            this.character2 = character2;
            this.character3 = character3;
            this.messagePosts = messagePosts;
            count++;
        }
        #endregion constructors


        #region methods
        public override string ToString()
        {
            if (title.Length >= 67)
            {
                title = title.Remove(66, title.Length - 67);
            }

            return $" ║ {Id,-6} ║ {title,-67} ║ {year,-5} ║ {runTime,-7} ║ {imdbRating,-11} ║";
        }
        #endregion methods
    }
}