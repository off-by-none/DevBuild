using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieApp;
using NUnit.Framework;
using Xunit;
using Assert = NUnit.Framework.Assert;
using TheoryAttribute = NUnit.Framework.TheoryAttribute;

namespace MovieApp
{
    class MovieTests
    {
        [Theory]
        [InlineData("The Shawshank Redemption", 1994, 142, 9.3, "Drama", "Frank Darabont", "Tim Robbins", "Morgan Freeman", "Bob Gunton", "Andy Dufresne", "Ellis Boyd 'Red' Redding", "Warden Norton", "The Shawshank Redemption")]
        public void PropertyTest_Title(string title, int year, int runTime, double imdbRating, string genre, string director,
                     string leadActor, string supportingActor, string thirdActor, string character1, string character2, string character3, string expected)
        {
            Movie m = new Movie(title, year, runTime, imdbRating, genre, director, leadActor, supportingActor, thirdActor, character1, character2, character3, new List<string>{ });
            string result = m.Title;
            Assert.AreEqual(expected, result);
        }

        [Theory]
        [InlineData("The Shawshank Redemption", 1994, 142, 9.3, "Drama", "Frank Darabont", "Tim Robbins", "Morgan Freeman", "Bob Gunton", "Andy Dufresne", "Ellis Boyd 'Red' Redding", "Warden Norton", 1994)]
        public void PropertyTest_Year(string title, int year, int runTime, double imdbRating, string genre, string director,
                     string leadActor, string supportingActor, string thirdActor, string character1, string character2, string character3, string expected)
        {
            Movie m = new Movie(title, year, runTime, imdbRating, genre, director, leadActor, supportingActor, thirdActor, character1, character2, character3, new List<string> { });
            int result = m.Year;
            Assert.AreEqual(expected, result);
        }

        [Theory]
        [InlineData("The Shawshank Redemption", 1994, 142, 9.3, "Drama", "Frank Darabont", "Tim Robbins", "Morgan Freeman", "Bob Gunton", "Andy Dufresne", "Ellis Boyd 'Red' Redding", "Warden Norton", 142)]
        public void PropertyTest_Runtime(string title, int year, int runTime, double imdbRating, string genre, string director,
                     string leadActor, string supportingActor, string thirdActor, string character1, string character2, string character3, string expected)
        {
            Movie m = new Movie(title, year, runTime, imdbRating, genre, director, leadActor, supportingActor, thirdActor, character1, character2, character3, new List<string> { });
            int result = m.RunTime;
            Assert.AreEqual(expected, result);
        }

        [Theory]
        [InlineData("The Shawshank Redemption", 1994, 142, 9.3, "Drama", "Frank Darabont", "Tim Robbins", "Morgan Freeman", "Bob Gunton", "Andy Dufresne", "Ellis Boyd 'Red' Redding", "Warden Norton", 9.3)]
        public void PropertyTest_imdbRating(string title, int year, int runTime, double imdbRating, string genre, string director,
                     string leadActor, string supportingActor, string thirdActor, string character1, string character2, string character3, string expected)
        {
            Movie m = new Movie(title, year, runTime, imdbRating, genre, director, leadActor, supportingActor, thirdActor, character1, character2, character3, new List<string> { });
            double result = m.ImdbRating;
            Assert.AreEqual(expected, result);
        }


        [Theory]
        [InlineData("The Shawshank Redemption", 1994, 142, 9.3, "Drama", "Frank Darabont", "Tim Robbins", "Morgan Freeman", "Bob Gunton", "Andy Dufresne", "Ellis Boyd 'Red' Redding", "Warden Norton", "Drama")]
        public void PropertyTest_Genre(string title, int year, int runTime, double imdbRating, string genre, string director,
                     string leadActor, string supportingActor, string thirdActor, string character1, string character2, string character3, string expected)
        {
            Movie m = new Movie(title, year, runTime, imdbRating, genre, director, leadActor, supportingActor, thirdActor, character1, character2, character3, new List<string> { });
            string result = m.Genre;
            Assert.AreEqual(expected, result);
        }

        [Theory]
        [InlineData("The Shawshank Redemption", 1994, 142, 9.3, "Drama", "Frank Darabont", "Tim Robbins", "Morgan Freeman", "Bob Gunton", "Andy Dufresne", "Ellis Boyd 'Red' Redding", "Warden Norton", "Frank Darabont")]
        public void PropertyTest_Director(string title, int year, int runTime, double imdbRating, string genre, string director,
                     string leadActor, string supportingActor, string thirdActor, string character1, string character2, string character3, string expected)
        {
            Movie m = new Movie(title, year, runTime, imdbRating, genre, director, leadActor, supportingActor, thirdActor, character1, character2, character3, new List<string> { });
            string result = m.Director;
            Assert.AreEqual(expected, result);
        }

        [Theory]
        [InlineData("The Shawshank Redemption", 1994, 142, 9.3, "Drama", "Frank Darabont", "Tim Robbins", "Morgan Freeman", "Bob Gunton", "Andy Dufresne", "Ellis Boyd 'Red' Redding", "Warden Norton", "Tim Robbins")]
        public void PropertyTest_LeadActor(string title, int year, int runTime, double imdbRating, string genre, string director,
                     string leadActor, string supportingActor, string thirdActor, string character1, string character2, string character3, string expected)
        {
            Movie m = new Movie(title, year, runTime, imdbRating, genre, director, leadActor, supportingActor, thirdActor, character1, character2, character3, new List<string> { });
            string result = m.LeadActor;
            Assert.AreEqual(expected, result);
        }

        [Theory]
        [InlineData("The Shawshank Redemption", 1994, 142, 9.3, "Drama", "Frank Darabont", "Tim Robbins", "Morgan Freeman", "Bob Gunton", "Andy Dufresne", "Ellis Boyd 'Red' Redding", "Warden Norton", "Morgan Freeman")]
        public void PropertyTest_SupportingActor(string title, int year, int runTime, double imdbRating, string genre, string director,
                     string leadActor, string supportingActor, string thirdActor, string character1, string character2, string character3, string expected)
        {
            Movie m = new Movie(title, year, runTime, imdbRating, genre, director, leadActor, supportingActor, thirdActor, character1, character2, character3, new List<string> { });
            string result = m.SupportingActor;
            Assert.AreEqual(expected, result);
        }

        [Theory]
        [InlineData("The Shawshank Redemption", 1994, 142, 9.3, "Drama", "Frank Darabont", "Tim Robbins", "Morgan Freeman", "Bob Gunton", "Andy Dufresne", "Ellis Boyd 'Red' Redding", "Warden Norton", "Bob Gunton")]
        public void PropertyTest_ThirdActor(string title, int year, int runTime, double imdbRating, string genre, string director,
                     string leadActor, string supportingActor, string thirdActor, string character1, string character2, string character3, string expected)
        {
            Movie m = new Movie(title, year, runTime, imdbRating, genre, director, leadActor, supportingActor, thirdActor, character1, character2, character3, new List<string> { });
            string result = m.ThirdActor;
            Assert.AreEqual(expected, result);
        }

        [Theory]
        [InlineData("The Shawshank Redemption", 1994, 142, 9.3, "Drama", "Frank Darabont", "Tim Robbins", "Morgan Freeman", "Bob Gunton", "Andy Dufresne", "Ellis Boyd 'Red' Redding", "Warden Norton", "Andy Dufresne")]
        public void PropertyTest_LeadCharacter(string title, int year, int runTime, double imdbRating, string genre, string director,
                     string leadActor, string supportingActor, string thirdActor, string character1, string character2, string character3, string expected)
        {
            Movie m = new Movie(title, year, runTime, imdbRating, genre, director, leadActor, supportingActor, thirdActor, character1, character2, character3, new List<string> { });
            string result = m.Character1;
            Assert.AreEqual(expected, result);
        }

        [Theory]
        [InlineData("The Shawshank Redemption", 1994, 142, 9.3, "Drama", "Frank Darabont", "Tim Robbins", "Morgan Freeman", "Bob Gunton", "Andy Dufresne", "Ellis Boyd 'Red' Redding", "Warden Norton", "Ellis Boyd 'Red' Redding")]
        public void PropertyTest_SupportingCharacter(string title, int year, int runTime, double imdbRating, string genre, string director,
                     string leadActor, string supportingActor, string thirdActor, string character1, string character2, string character3, string expected)
        {
            Movie m = new Movie(title, year, runTime, imdbRating, genre, director, leadActor, supportingActor, thirdActor, character1, character2, character3, new List<string> { });
            string result = m.Character2;
            Assert.AreEqual(expected, result);
        }

        [Theory]
        [InlineData("The Shawshank Redemption", 1994, 142, 9.3, "Drama", "Frank Darabont", "Tim Robbins", "Morgan Freeman", "Bob Gunton", "Andy Dufresne", "Ellis Boyd 'Red' Redding", "Warden Norton", "Warden Norton")]
        public void PropertyTest_ThirdCharacter(string title, int year, int runTime, double imdbRating, string genre, string director,
                    string leadActor, string supportingActor, string thirdActor, string character1, string character2, string character3, string expected)
        {
            Movie m = new Movie(title, year, runTime, imdbRating, genre, director, leadActor, supportingActor, thirdActor, character1, character2, character3, new List<string> { });
            string result = m.Character3;
            Assert.AreEqual(expected, result);
        }
    }
}
