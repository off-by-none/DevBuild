using System;
using System.Collections.Generic;
using System.Text;

namespace Lab42_Movies
{
    class Movie
    {
        #region fields
        private string title;
        private string category;
        private int runTime;
        private int yearReleased;
        private double imdbRating;
        #endregion fields

        #region properties
        public string Title { get => title; set => title = value; }
        public string Category { get => category; set => category = value; }
        public int RunTime { get => runTime; set => runTime = value; }
        public int YearReleased { get => yearReleased; set => yearReleased = value; }
        public double ImdbRating { get => imdbRating; set => imdbRating = value; }
        #endregion properties

        #region constructors
        public Movie(string title, string category, int runTime, int yearReleased, double imdbRating)
        {
            this.title = title;
            this.category = category;
            this.runTime = runTime;
            this.yearReleased = yearReleased;
            this.imdbRating = imdbRating;
        }
        #endregion constructors






    }
}
