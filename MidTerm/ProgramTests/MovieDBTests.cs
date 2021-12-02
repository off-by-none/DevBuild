using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieApp;
using NUnit.Framework;
using Xunit;
using Assert = NUnit.Framework.Assert;
using TheoryAttribute = NUnit.Framework.TheoryAttribute;

namespace MovieAppUnitTests
{
    [TestClass]
    public class MoviedbTests
    {
        [Theory]
        [InlineData("Title", "desc", "? 2 heures de Paris")]
        public void SortMovie_Sorted_SortedMovies(string cat, string sortOrder, string expected)
        {
            MovieDB movies = new MovieDB();
            string result = "";
            using (StreamReader sr = new StreamReader(@"movieDB.tsv"))
            {
                string headerLine = sr.ReadLine();
                string s;
                string[] sArray;
                while (sr.Peek() >= 0)
                {
                    s = sr.ReadLine();
                    sArray = s.Split('\t');
                    movies.AddMovie(new Movie(sArray[1], int.Parse(sArray[2]), int.Parse(sArray[3]), double.Parse(sArray[4]), sArray[5],
                                              sArray[6], sArray[7], sArray[8], sArray[9], sArray[10], sArray[11], sArray[12], new List<string> { }));
                }
            }
            movies.SortMovies(movies, cat, sortOrder);
            foreach (Movie m in movies.Movies)
            {
                result = m.Title;
            }

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ListMovies_MoviesPrint_SevenMovies()
        {
            MovieDB movies = new MovieDB();
            int index = 0;
            List<string> result = new List<string>();

            foreach (Movie m in movies.Movies)
            {
                movies.ListMovies(index);
            }
            Assert.AreEqual(0, result.Count);
        }
    }
}