using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab152_CreatingAPI.Models
{
    public class Movie
    {
        private string tconst;
        private string title;
        private int startYear;
        private int runtimeMinutes;
        private double averageRating;
        private string genres;
        private string director;
        private string leadActor;
        private string supportingActor;
        private string thirdActor;
        private string character1;
        private string character2;
        private string character3;
        private int numVotes;

        public string Tconst { get => tconst; set => tconst = value; }
        public string Title { get => title; set => title = value; }
        public int StartYear { get => startYear; set => startYear = value; }
        public int RuntimeMinutes { get => runtimeMinutes; set => runtimeMinutes = value; }
        public double AverageRating { get => averageRating; set => averageRating = value; }
        public string Genres { get => genres; set => genres = value; }
        public string Director { get => director; set => director = value; }
        public string LeadActor { get => leadActor; set => leadActor = value; }
        public string SupportingActor { get => supportingActor; set => supportingActor = value; }
        public string ThirdActor { get => thirdActor; set => thirdActor = value; }
        public string Character1 { get => character1; set => character1 = value; }
        public string Character2 { get => character2; set => character2 = value; }
        public string Character3 { get => character3; set => character3 = value; }
        public int NumVotes { get => numVotes; set => numVotes = value; }
    }
}