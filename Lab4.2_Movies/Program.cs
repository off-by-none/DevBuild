using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab42_Movies
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();
            Dictionary<int, string> categories = new Dictionary<int, string>();

            movies = AddMovie(movies);
            AddCategories(categories);

            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Movie List Application!");
                Console.WriteLine($"\nThere are {movies.Count} movies in this list.");
                PrintCategory(categories);
                GetMovie(categories[GetInput()], movies);
            } while (WantCont());
        }


        static void AddCategories(Dictionary<int, string> categories)
        {
            categories.Add(1, "Action");
            categories.Add(2, "Animation");
            categories.Add(3, "Biography");
            categories.Add(4, "Comedy");
            categories.Add(5, "Crime");
            categories.Add(6, "Drama");
            categories.Add(7, "Family");
            categories.Add(8, "Fantasy");
            categories.Add(9, "Mystery");
            categories.Add(10, "Sci-Fi");
            categories.Add(11, "Thriller");
            categories.Add(12, "War");
            categories.Add(13, "Western");
        }
        static void PrintCategory(Dictionary<int, string> categories)
        {
            Console.WriteLine("\nWhat category are you interested in?");
            foreach (KeyValuePair<int, string> kvp in categories)
            {
                Console.WriteLine($"[{kvp.Key}]:\t{kvp.Value}");
            } 
        }

        static int GetInput()
        {
            int catNum;
            Console.Write("Enter the number of the category: ");
            bool isInt = int.TryParse(Console.ReadLine(), out catNum);
            do
            {
                if (isInt == false)
                {
                    Console.Write("Please enter a number: ");
                    isInt = int.TryParse(Console.ReadLine(), out catNum);
                }
                else if (catNum < 1 || catNum > 13)
                {
                    Console.Write("Please enter a number between 1 and 13: ");
                    isInt = int.TryParse(Console.ReadLine(), out catNum);
                }
            } while (catNum < 1 || catNum > 13);
            return catNum;
        }

        static void GetMovie(string category, List<Movie> movies)
        {
            Console.WriteLine($"\nHere are all the {category} movies in the list:\n");
            Console.WriteLine($"{"Title",-50} | {"Run Time",-10} | {"Year",-6} | {"Imdb Rating",-5}");
            Console.WriteLine(String.Concat(Enumerable.Repeat("-", 86)));
            foreach (Movie m in movies)
            {
                if (m.Category == category)
                {
                    Console.WriteLine($"{m.Title, -50} | {m.RunTime + " mins", -10} | {m.YearReleased, -6} | {m.ImdbRating, -5}");
                }
            }
            Console.WriteLine();
        }

        static bool WantCont()
        {
            char cont;

            do
            {
                Console.Write("\nContinue? (y/n): ");
                cont = Console.ReadKey().KeyChar;
                if (cont == 'n' || cont == 'N')
                {
                    Console.WriteLine();
                    return false;
                }
            } while (cont != 'y' && cont != 'Y');
            return true;
        }

        static List<Movie> AddMovie(List<Movie> movies)
        {
            movies.Add(new Movie("The Shawshank Redemption", "Drama", 142, 1994, 9.3));
            movies.Add(new Movie("The Godfather", "Drama", 175, 1972, 9.2));
            movies.Add(new Movie("The Godfather: Part II", "Drama", 202, 1974, 9));
            movies.Add(new Movie("The Dark Knight", "Action", 152, 2008, 9));
            movies.Add(new Movie("12 Angry Men", "Drama", 96, 1957, 8.9));
            movies.Add(new Movie("Schindler's List", "Biography", 195, 1993, 8.9));
            movies.Add(new Movie("The Lord of the Rings: The Return of the King", "Fantasy", 201, 2003, 8.9));
            movies.Add(new Movie("Pulp Fiction", "Crime", 154, 1994, 8.9));
            movies.Add(new Movie("The Good, the Bad and the Ugly", "Western", 178, 1966, 8.8));
            movies.Add(new Movie("The Lord of the Rings: The Fellowship of the Ring", "Fantasy", 178, 2001, 8.8));
            movies.Add(new Movie("Fight Club", "Drama", 139, 1999, 8.8));
            movies.Add(new Movie("Forrest Gump", "Drama", 142, 1994, 8.8));
            movies.Add(new Movie("Inception", "Sci-Fi", 148, 2010, 8.7));
            movies.Add(new Movie("Star Wars: Episode V - The Empire Strikes Back", "Fantasy", 124, 1980, 8.7));
            movies.Add(new Movie("The Lord of the Rings: The Two Towers", "Fantasy", 179, 2002, 8.7));
            movies.Add(new Movie("The Matrix", "Sci-Fi", 136, 1999, 8.6));
            movies.Add(new Movie("Goodfellas", "Crime", 146, 1990, 8.6));
            movies.Add(new Movie("One Flew Over the Cuckoo's Nest", "Drama", 133, 1975, 8.6));
            movies.Add(new Movie("Seven Samurai", "Action", 207, 1954, 8.6));
            movies.Add(new Movie("Se7en", "Mystery", 127, 1995, 8.6));
            movies.Add(new Movie("City of God", "Crime", 130, 2002, 8.6));
            movies.Add(new Movie("Life Is Beautiful", "Comedy", 116, 1997, 8.6));
            movies.Add(new Movie("The Silence of the Lambs", "Thriller", 118, 1991, 8.6));
            movies.Add(new Movie("It's a Wonderful Life", "Family", 130, 1946, 8.6));
            movies.Add(new Movie("Star Wars: Episode IV - A New Hope", "Fantasy", 121, 1977, 8.6));
            movies.Add(new Movie("Parasite", "Drama", 132, 2019, 8.6));
            movies.Add(new Movie("Saving Private Ryan", "War", 169, 1998, 8.6));
            movies.Add(new Movie("Spirited Away", "Animation", 125, 2001, 8.5));
            movies.Add(new Movie("The Green Mile", "Drama", 189, 1999, 8.5));
            movies.Add(new Movie("Interstellar", "Sci-Fi", 169, 2014, 8.5));
            movies.Add(new Movie("Leon: The Professional", "Crime", 110, 1994, 8.5));
            movies.Add(new Movie("The Usual Suspects", "Thriller", 106, 1995, 8.5));
            movies.Add(new Movie("Harakiri", "Action", 133, 1962, 8.5));
            movies.Add(new Movie("Joker", "Thriller", 122, 2019, 8.5));
            movies.Add(new Movie("The Lion King", "Animation", 88, 1994, 8.5));
            movies.Add(new Movie("American History X", "Drama", 119, 1998, 8.5));
            movies.Add(new Movie("Terminator 2: Judgment Day", "Sci-Fi", 137, 1991, 8.5));
            movies.Add(new Movie("Back to the Future", "Sci-Fi", 116, 1985, 8.5));
            movies.Add(new Movie("The Pianist", "Biography", 150, 2002, 8.5));
            movies.Add(new Movie("Modern Times", "Comedy", 87, 1936, 8.5));
            movies.Add(new Movie("Psycho", "Mystery", 109, 1960, 8.5));
            movies.Add(new Movie("Gladiator", "Action", 155, 2000, 8.5));
            movies.Add(new Movie("City Lights", "Comedy", 87, 1931, 8.5));
            movies.Add(new Movie("The Intouchables", "Biography", 112, 2011, 8.5));
            movies.Add(new Movie("The Departed", "Thriller", 151, 2006, 8.5));
            movies.Add(new Movie("Whiplash", "Drama", 106, 2014, 8.5));
            movies.Add(new Movie("Once Upon a Time in the West", "Western", 165, 1968, 8.5));
            movies.Add(new Movie("The Prestige", "Mystery", 130, 2006, 8.5));
            movies.Add(new Movie("Casablanca", "War", 102, 1942, 8.4));
            movies.Add(new Movie("1917", "War", 119, 2019, 8.4));

            return movies.OrderBy(m => m.Title).ToList();
        }
    }
}
