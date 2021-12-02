using DuoVia.FuzzyStrings;
using Figgle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace MovieApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            MovieDB movies = new MovieDB();
            MovieDB searchedMovies = new MovieDB();
            UserDB users = new UserDB();
            string breadcrumb = "  ";
            int index = 0;

            Console.BackgroundColor = ConsoleColor.Black;
            PopulateMovieDB(movies);
            PopulateUserDB(users);
            PrintLogoAnimation(movies.Movies.Count);
            PrintMainMenu(movies, searchedMovies, index, breadcrumb, users);
        }


        static void AdminAddMovie(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            bool isType;
            int year;
            int runTime;
            double imdbRating;
            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorVisible = true;
            Console.WriteLine(" Enter the following information to add a movie (enter \"\\N\" if null).\n");
            
            Console.Write(" Title: ");
            string title = Console.ReadLine();

            do
            {
                Console.Write(" Year: ");
                isType = int.TryParse(Console.ReadLine(), out year);
            } while (!isType);

            do
            {
                Console.Write(" Runtime: ");
                isType = int.TryParse(Console.ReadLine(), out runTime);
            } while (!isType);

            do
            {
                Console.Write(" IMDb Rating: ");
                isType = double.TryParse(Console.ReadLine(), out imdbRating);
            } while (!isType);

            Console.Write(" Genre: ");
            string genre = Console.ReadLine();
            Console.Write(" Director: ");
            string director = Console.ReadLine();
            Console.Write(" Lead Actor: ");
            string leadActor = Console.ReadLine();
            Console.Write(" Supporting Actor: ");
            string supportingActor = Console.ReadLine();
            Console.Write(" Third Actor: ");
            string thirdActor = Console.ReadLine();
            Console.Write(" Lead Character: ");
            string character1 = Console.ReadLine();
            Console.Write(" Supporting Character: ");
            string character2 = Console.ReadLine();
            Console.Write(" Third Character: ");
            string character3 = Console.ReadLine();

            movies.AddMovie(new Movie(title, year, runTime, imdbRating, genre, director, leadActor, supportingActor, thirdActor, character1, character2, character3, new List<string>{ }));
            
            for (int i = 0; i < 7; i++)
            {
                Console.Clear();
                PrintLogo(movies.Movies.Count);
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($" Adding {title} to the OMDb" + String.Concat(Enumerable.Repeat(".", i)));
                System.Threading.Thread.Sleep(200);
            }

            PrintLogo(movies.Movies.Count);
            PrintAdminMenu(movies, searchedMovies, index, breadcrumb, users);
        }


        static void AdminModifyMovie(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            int movieID;
            bool isInt;
            bool movieExists = false;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorVisible = true;

            do
            {
                Console.Write(" Enter the Movie ID to modify: ");
                isInt = int.TryParse(Console.ReadLine(), out movieID);
            } while (!isInt || movieID < 1);

            foreach (Movie m in movies.Movies)
            {
                if (m.Id == movieID)
                {
                    movieExists = true;
                    PrintLogo(movies.Movies.Count);
                    PrintModifyMenu(movies, searchedMovies, index, breadcrumb, m);
                    PrintLogo(movies.Movies.Count);
                    PrintAdminMenu(movies, searchedMovies, index, breadcrumb, users);
                    break;
                }
            }

            if (!movieExists)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n UNKNOWN MOVIE ID");
                System.Threading.Thread.Sleep(2000);
                PrintLogo(movies.Movies.Count);
                PrintAdminMenu(movies, searchedMovies, index, breadcrumb, users);
            }
        }


        static void AdminRemoveMovie(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            int movieID;
            bool isInt;
            bool movieExists = false;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorVisible = true;

            do
            {
                Console.Write(" Enter the Movie ID to remove: ");
                isInt = int.TryParse(Console.ReadLine(), out movieID);
            } while (!isInt || movieID < 1);

            foreach (Movie m in movies.Movies)
            {
                if (m.Id == movieID)
                {
                    movieExists = true;
                    Console.WriteLine($"\n {m.Title} has been removed from the OMDb!");
                    System.Threading.Thread.Sleep(2000);
                    movies.RemoveMovie(m);
                    PrintLogo(movies.Movies.Count);
                    PrintAdminMenu(movies, searchedMovies, index, breadcrumb, users);
                    break;
                }
            }

            if (!movieExists)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n UNKNOWN MOVIE ID");
                System.Threading.Thread.Sleep(2000);
                PrintLogo(movies.Movies.Count);
                PrintAdminMenu(movies, searchedMovies, index, breadcrumb, users);
            }
        }


        public static string AskForCredential(MovieDB movies, UserDB users)
        {
            string userLoginInput;
            string userPasswordInput = null;
            bool isUser = false;

            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = true;
            Console.Write(" Enter User Name (or enter \"USER\"): ");
            userLoginInput = Console.ReadLine().Trim().ToLower();
            Console.Write(" Enter Password (or enter \"password\"): ");

            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) { break; }
                if (key.Key == ConsoleKey.Backspace && userPasswordInput.Length > 0)
                {
                    Console.Write("\b \b");
                    userPasswordInput = userPasswordInput.Substring(0, userPasswordInput.Length - 1);
                    continue;
                }
                Console.Write("*");
                userPasswordInput += key.KeyChar;
            }

            foreach (UserCredentials u in users.User)
            {
                if (u.UserLogin.ToLower() == userLoginInput)
                {
                    if (u.Password == userPasswordInput)
                    {
                        isUser = true;
                        PrintLogo(movies.Movies.Count);
                        return u.UserName;
                    }
                }
            }
            return "Not Found";
        }


            static void AskForCredential(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            string userLoginInput;
            string userPasswordInput = null;
            bool isUser = false;

            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = true;
            Console.Write(" Enter User Name (or enter \"USER\"): ");
            userLoginInput = Console.ReadLine().Trim().ToLower();
            Console.Write(" Enter Password (or enter \"password\"): ");

            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) { break; }
                if (key.Key == ConsoleKey.Backspace && userPasswordInput.Length > 0) 
                { 
                    Console.Write("\b \b"); 
                    userPasswordInput = userPasswordInput.Substring(0, userPasswordInput.Length - 1); 
                    continue; 
                }
                Console.Write("*");
                userPasswordInput += key.KeyChar;
            }
            
            foreach (UserCredentials u in users.User)
            {
                if (u.UserLogin.ToLower() == userLoginInput)
                {
                    if (u.Password == userPasswordInput)
                    {
                        isUser = true;
                        PrintLogo(movies.Movies.Count);
                        PrintAdminMenu(movies, searchedMovies, index, breadcrumb, users);
                        break;
                    }
                }
            }

            if (!isUser)
            {
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n UNKNOWN USER");
                System.Threading.Thread.Sleep(2000);
                PrintLogo(movies.Movies.Count);
                PrintMainMenu(movies, searchedMovies, index, breadcrumb, users);
            }
        }


        static void CreateAccount(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = true;
            string password = null;
            Console.Write(" Enter your First Name: ");
            string firstName = Console.ReadLine().Trim();
            Console.Write("\n Enter your Last Name: ");
            string lastName = Console.ReadLine().Trim();
            string fullName = firstName + " " + lastName;
            Console.Write("\n Enter User Name: ");
            string userName = Console.ReadLine().Trim();
            Console.Write("\n Enter Password: ");
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) { break; }
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password.Substring(0, password.Length - 1);
                    continue;
                }
                Console.Write("*");
                password += key.KeyChar;
            }

            users.AddUser(new UserCredentials(fullName, userName, password));
            string newUser = "\n" + fullName + "," + userName + "," + password;
            File.AppendAllText(@"userDB.txt", newUser + password + Environment.NewLine);
            PrintLogo(movies.Movies.Count);
            PrintMainMenu(movies, searchedMovies, index, breadcrumb, users);
        }


        static void GetAdminMenuInput(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            char input;
            List<char> validInput = new List<char> { '1', '2', '3', '4' };
            do
            {
                Console.CursorVisible = false;
                input = Console.ReadKey().KeyChar;
                Console.Write("\b \b");
            } while (!validInput.Contains(input));

            if (input == '1') { PrintLogo(movies.Movies.Count); AdminAddMovie(movies, searchedMovies, index, breadcrumb, users); }
            else if (input == '2') { PrintLogo(movies.Movies.Count); AdminRemoveMovie(movies, searchedMovies, index, breadcrumb, users); }
            else if (input == '3') { PrintLogo(movies.Movies.Count); AdminModifyMovie(movies, searchedMovies, index, breadcrumb, users); }
            else if (input == '4') { PrintLogo(movies.Movies.Count); PrintMainMenu(movies, searchedMovies, index, breadcrumb, users); }
        }


        static void GetFinalMenuInput(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            char input;
            List<char> validInput = new List<char> { '1', '2', '3', '4', '5', 'u', 'd' };
            do
            {
                Console.CursorVisible = false;
                input = Console.ReadKey().KeyChar;
                Console.Write("\b \b");
            } while (!validInput.Contains(input));

            if (input == '1')
            {
                PrintLogo(movies.Movies.Count);
                PrintSearchedResultsNoMenu(movies, searchedMovies, index, breadcrumb, users);
            }
            else if (input == '2') { PrintLogo(movies.Movies.Count); PrintSortMenu(movies, searchedMovies, index, breadcrumb, users); }
            else if (input == '3') { PrintLogo(movies.Movies.Count); PrintSearchMenu(searchedMovies, searchedMovies, index, breadcrumb, users); }
            else if (input == '4') 
            {
                if (movies.Movies.Count < 185000)
                {
                    MovieDB movies2 = new MovieDB();
                    PopulateMovieDB(movies2);
                    PrintLogo(movies2.Movies.Count);
                    PrintMainMenu(movies2, searchedMovies, index, breadcrumb, users);
                }
                else
                {
                    PrintLogo(movies.Movies.Count);
                    PrintMainMenu(movies, searchedMovies, index, breadcrumb, users);
                }
            }
            else if (char.Parse(input.ToString().ToLower()) == 'u') 
            {
                if ((Math.Floor(index / 7.0) + 1) < (Math.Ceiling(searchedMovies.Movies.Count / 7.0)))
                {
                    index += 7;
                }
                PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
            }
            else if (char.Parse(input.ToString().ToLower()) == 'd') 
            {
                if (index != 0)
                {
                    index -= 7;
                }
                PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
            }
        }


        static void GetMainMenuInput(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            char input;
            List<char> validInput = new List<char> { '1', '2', '3', '4' };
            do
            {
                input = Console.ReadKey().KeyChar;
                Console.Write("\b \b");
            } while (!validInput.Contains(input));

            if (input == '1') { SearchMovies(movies, searchedMovies, index, breadcrumb, users); }
            else if (input == '2') { AskForCredential(movies, searchedMovies, index, breadcrumb, users); }
            else if (input == '3') { CreateAccount(movies, searchedMovies, index, breadcrumb, users); }
            else if (input == '4') { return; }
        }


        static void GetModifyMenuInput(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, Movie m)
        {
            char input;
            bool isType;

            List<char> validInput = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 's', 't', 'a', 'S', 'T', 'A' };

            do
            {
                input = Console.ReadKey().KeyChar;
                Console.Write("\b \b");
            } while (!validInput.Contains(input));

            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorVisible = true;

            if (input == '1') 
            {
                Console.Write(" New Title: ");
                string newValue = Console.ReadLine();
                m.Title = newValue;
                Console.WriteLine($"\n Title has been changed to {newValue}!");
                System.Threading.Thread.Sleep(2000);
            }
            else if (input == '2')
            {
                int newValue;
                do
                {
                    Console.Write(" New Year: ");
                    isType = int.TryParse(Console.ReadLine(), out newValue);
                } while (!isType || newValue > 2025 || newValue < 1870);
                m.Year = newValue;
                Console.WriteLine($"\n Year has been changed to {newValue}!");
                System.Threading.Thread.Sleep(2000);
            }
            else if (input == '3')
            {
                Console.Write(" New Genre: ");
                string newValue = Console.ReadLine();
                m.Genre = newValue;
                Console.WriteLine($"\n Genre has been changed to {newValue}!");
                System.Threading.Thread.Sleep(2000);
            }
            else if (input == '4')
            {
                double newValue;
                do
                {
                    Console.Write(" IMDb Rating: ");
                    isType = double.TryParse(Console.ReadLine(), out newValue);
                } while (!isType || newValue > 10.0 || newValue < 0.0);
                m.ImdbRating = newValue;
                Console.WriteLine($"\n IMDb Rating has been changed to {newValue}!");
                System.Threading.Thread.Sleep(2000);
            }
            else if (input == '5')
            {
                int newValue;
                do
                {
                    Console.Write(" New Runtime: ");
                    isType = int.TryParse(Console.ReadLine(), out newValue);
                } while (!isType || newValue > 2000 || newValue < 0);
                m.RunTime = newValue;
                Console.WriteLine($"\n Runtime has been changed to {newValue}!");
                System.Threading.Thread.Sleep(2000);
            }
            else if (input == '6')
            {
                Console.Write(" New Director: ");
                string newValue = Console.ReadLine();
                m.Director = newValue;
                Console.WriteLine($"\n Director has been changed to {newValue}!");
                System.Threading.Thread.Sleep(2000);
            }
            else if (input == '7')
            {
                Console.Write(" New Lead Actor: ");
                string newValue = Console.ReadLine();
                m.LeadActor = newValue;
                Console.WriteLine($"\n Lead Acctor has been changed to {newValue}!");
                System.Threading.Thread.Sleep(2000);
            }
            else if (input == '8')
            {
                Console.Write(" New Supporting Actor: ");
                string newValue = Console.ReadLine();
                m.SupportingActor = newValue;
                Console.WriteLine($"\n Supporting Actor has been changed to {newValue}!");
                System.Threading.Thread.Sleep(2000);
            }
            else if (input == '9')
            {
                Console.Write(" New Third Actor: ");
                string newValue = Console.ReadLine();
                m.ThirdActor = newValue;
                Console.WriteLine($"\n Third Actor has been changed to {newValue}!");
                System.Threading.Thread.Sleep(2000);
            }
            else if (input == '0')
            {
                Console.Write(" New Lead Character: ");
                string newValue = Console.ReadLine();
                m.Character1 = newValue;
                Console.WriteLine($"\n Lead Character has been changed to {newValue}!");
                System.Threading.Thread.Sleep(2000);
            }
            else if (input == 's' || input == 'S')
            {
                Console.Write(" New Supporting Character: ");
                string newValue = Console.ReadLine();
                m.Character2 = newValue;
                Console.WriteLine($"\n Supporting Character has been changed to {newValue}!");
                System.Threading.Thread.Sleep(2000);
            }
            else if (input == 't' || input == 'T')
            {
                Console.Write(" New Third Character: ");
                string newValue = Console.ReadLine();
                m.Character3 = newValue;
                Console.WriteLine($"\n Third Character has been changed to {newValue}!");
                System.Threading.Thread.Sleep(2000);
            }
            else if (input == 'a' || input == 'A') { return; }
        }


        static void GetMoviePage(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users, int i, int movieID)
        {
            bool movieFound = false;
            char input;
            PrintLogo(i);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" Hit [B] to go Back");
            foreach (Movie m in movies.Movies)
            {
                if (m.Id == movieID)
                {
                    int stars = (int)Math.Floor(m.ImdbRating);
                    string starStr = String.Concat(Enumerable.Repeat("*", stars));
                    movieFound = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (m.Title.Length > 25)
                    {
                        Console.WriteLine(
                            FiggleFonts.Straight.Render(m.Title) + $" IMDb Rating: { starStr + " " + m.ImdbRating + " " + starStr}");
                    }
                    else
                    {
                        Console.WriteLine(
                            FiggleFonts.Small.Render(m.Title) + $" IMDb Rating: { starStr + " " + m.ImdbRating + " " + starStr}");
                    }
                    Console.WriteLine();
                    Console.WriteLine($" Year: {m.Year}");
                    Console.WriteLine($" Genre: {m.Genre}");
                    Console.WriteLine($" Runtime: {m.RunTime} minutes");
                    Console.WriteLine();
                    Console.WriteLine($" Director: {m.Director}");
                    Console.WriteLine();
                    Console.WriteLine($" ════════════════════════ CAST ════════════════════════");
                    if (m.LeadActor != @"\N") { Console.WriteLine($" {m.LeadActor,-24} .... {m.Character1}"); }
                    if (m.SupportingActor != @"\N") { Console.WriteLine($" {m.SupportingActor,-24} .... {m.Character2}"); }
                    if (m.ThirdActor != @"\N") { Console.WriteLine($" {m.ThirdActor,-24} .... {m.Character3}"); }
                    Console.WriteLine($" ══════════════════════════════════════════════════════");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(" Hit [P] to Post");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($" ════════════════════ MESSAGE BOARD ════════════════════");
                    if (m.MessagePosts.Count > 0)
                    {
                        for (int x = 0; x < m.MessagePosts.Count; x++)
                        {
                            string[] strArray = m.MessagePosts[x].Split(',');
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"\n {strArray[0]} said:");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($" {strArray[1]}");
                        }
                    }
                    Console.WriteLine($" ═══════════════════════════════════════════════════════");
                    Console.SetCursorPosition(0, 0);
                    break;
                }
            }

            if (!movieFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n MOVIE PAGE NOT FOUND");
            }

            do
            {
                Console.CursorVisible = false;
                input = Console.ReadKey().KeyChar;
                Console.Write("\b \b");
            } while (input != 'b' && input != 'B' && input != 'p' && input != 'P');

            if (input == 'b' || input == 'B') { PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users); }
            if (input == 'p' || input == 'P')
            {
                string userName = AskForCredential(movies, users);
                if (userName == "Not Found")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n USER NOT FOUND");
                    System.Threading.Thread.Sleep(2000);
                    GetMoviePage(movies, searchedMovies, index, breadcrumb, users, i, movieID);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.CursorVisible = true;
                    Console.WriteLine(" New Post:\n");
                    Console.Write(" ");
                    string messagePost = Console.ReadLine();
                    messagePost = $"{userName},{messagePost}";
                    foreach (Movie m in movies.Movies)
                    {
                        if (m.Id == movieID)
                        {
                            m.MessagePosts.Add(messagePost);
                            break;
                        }
                    }
                    GetMoviePage(movies, searchedMovies, index, breadcrumb, users, i, movieID);
                }
            }
        }


        static void GetSearchActorMenuInput(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            char input;
            List<char> validInput = new List<char> { '1', '2', '3', '4', '5' };
            do
            {
                input = Console.ReadKey().KeyChar;
                Console.Write("\b \b");
            } while (!validInput.Contains(input));

            if (input == '1') { SearchLeadActor(movies, index, breadcrumb, users); }
            else if (input == '2') { SearchSupportingActor(movies, index, breadcrumb, users); }
            else if (input == '3') { SearchThirdActor(movies, index, breadcrumb, users); }
            else if (input == '4') { SearchAnyActor(movies, index, breadcrumb, users); }
            else if (input == '5') { PrintLogo(movies.Movies.Count); PrintMainMenu(movies, searchedMovies, index, breadcrumb, users); }
        }


        static void GetSearchMenuInput(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            char input;
            List<char> validInput = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            do
            {
                input = Console.ReadKey().KeyChar;
                Console.Write("\b \b");
            } while (!validInput.Contains(input));

            if (input == '1') { SearchTitle(movies, index, breadcrumb, users); }
            else if (input == '2') { SearchYear(movies, index, breadcrumb, users); }
            else if (input == '3') { SearchGenre(movies, index, breadcrumb, users); }
            else if (input == '4') { SearchImdbRating(movies, index, breadcrumb, users); }
            else if (input == '5') { SearchRuntime(movies, index, breadcrumb, users); }
            else if (input == '6') { SearchDirector(movies, index, breadcrumb, users); }
            else if (input == '7') { SearchActor(movies, searchedMovies, index, breadcrumb, users); }
            else if (input == '8') { SearchCharacter(movies, index, breadcrumb, users); }
            else if (input == '9') 
            {
                MovieDB movies2 = new MovieDB();
                PopulateMovieDB(movies2); 
                PrintLogo(movies.Movies.Count); 
                PrintMainMenu(movies, searchedMovies, index, breadcrumb, users); 
            }
        }


        static void GetSortMenuInput(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            char input;
            List<char> validInput = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            do
            {
                input = Console.ReadKey().KeyChar;
                Console.Write("\b \b");
            } while (!validInput.Contains(input));

            if (input == '1') { searchedMovies = searchedMovies.SortMovies(searchedMovies, "Title", "asc"); }
            else if (input == '2') { searchedMovies = searchedMovies.SortMovies(searchedMovies, "Title", "desc"); }
            else if (input == '3') { searchedMovies = searchedMovies.SortMovies(searchedMovies, "Year", "asc"); }
            else if (input == '4') { searchedMovies = searchedMovies.SortMovies(searchedMovies, "Year", "desc"); }
            else if (input == '5') { searchedMovies = searchedMovies.SortMovies(searchedMovies, "Runtime", "asc"); }
            else if (input == '6') { searchedMovies = searchedMovies.SortMovies(searchedMovies, "Runtime", "desc"); }
            else if (input == '7') { searchedMovies = searchedMovies.SortMovies(searchedMovies, "IMDb Rating", "asc"); }
            else if (input == '8') { searchedMovies = searchedMovies.SortMovies(searchedMovies, "IMDb Rating", "desc"); }
            else if (input == '9') { PrintLogo(movies.Movies.Count); PrintMainMenu(movies, searchedMovies, index, breadcrumb, users); }

            PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
        }


        static void PopulateMovieDB(MovieDB movies)
        {
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
        }


        static void PopulateUserDB(UserDB users)
        {
            using (StreamReader sr = new StreamReader(@"userDB.txt"))
            {
                sr.ReadLine();
                string s;
                string[] sArray;
                while (sr.Peek() >= 0)
                {
                    s = sr.ReadLine();
                    sArray = s.Split(',');
                    users.AddUser(new UserCredentials(sArray[0], sArray[1], sArray[2]));
                }
            }
        }


        static void PrintAdminMenu(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ╔═════════════════════════╗");
            Console.WriteLine(" ║       Admin Menu        ║");
            Console.WriteLine(" ╠═════════════════════════╣");
            Console.WriteLine(" ║   [1] Add Movie         ║");
            Console.WriteLine(" ║   [2] Remove Movie      ║");
            Console.WriteLine(" ║   [3] Modify Movie      ║");
            Console.WriteLine(" ║   [4] Main Menu         ║");
            Console.WriteLine(" ╚═════════════════════════╝");
            GetAdminMenuInput(movies, searchedMovies, index, breadcrumb, users);
        }


        static void PrintFinalMenu(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" ╔══════════════════════════╗");
            Console.WriteLine(" ║           Menu           ║");
            Console.WriteLine(" ╠══════════════════════════╣");
            Console.WriteLine(" ║   [1] Go to Movie Page   ║");
            Console.WriteLine(" ║   [2] Sort               ║");
            Console.WriteLine(" ║   [3] Add to Search      ║");
            Console.WriteLine(" ║   [4] Main Menu          ║");
            Console.WriteLine(" ╚══════════════════════════╝");
            GetFinalMenuInput(movies, searchedMovies, index, breadcrumb, users);
        }


        static void PrintGenreMenu()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" ╔═══════════════════════════════════════╗");
            Console.WriteLine(" ║            Possible Genres            ║");
            Console.WriteLine(" ╠═══════════════════════════════════════╣");
            Console.WriteLine(" ║   Action      Fantasy     Romance     ║");
            Console.WriteLine(" ║   Adult       Film-Noir   Sci-Fi      ║");
            Console.WriteLine(" ║   Adventure   Game-Show   Short       ║");
            Console.WriteLine(" ║   Animation   History     Sport       ║");
            Console.WriteLine(" ║   Biography   Horror      Talk-Show   ║");
            Console.WriteLine(" ║   Comedy      Music       Thriller    ║");
            Console.WriteLine(" ║   Crime       Musical     War         ║");
            Console.WriteLine(" ║   Documentary Mystery     Western     ║");
            Console.WriteLine(" ║   Drama       News                    ║");
            Console.WriteLine(" ║   Family      Reality-TV              ║");
            Console.WriteLine(" ╚═══════════════════════════════════════╝");
            Console.WriteLine();
        }


        static void PrintLogo(int i)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine(@" ██████████████████████████████        __                              _          __     __       __");
            Console.WriteLine(@" ██ / _ \|  \/  |  _ \| |__ ███  ___  / /_____ ___ __  __ _  ___ _  __(_)__   ___/ /__ _/ /____ _/ /  ___ ____ ___");
            Console.WriteLine(@" ██| | | | |\/| | | | | '_ \███ / _ \/  '_/ _ `/ // / /  ' \/ _ \ |/ / / -_) / _  / _ `/ __/ _ `/ _ \/ _ `(_-</ -_)");
            Console.WriteLine(@" ██| |_| | |  | | |_| | |_) ███ \___/_/\_\\_,_/\_, / /_/_/_/\___/___/_/\__/  \_,_/\_,_/\__/\_,_/_.__/\_,_/___/\__/");
            Console.WriteLine(@" ██ \___/|_|  |_|____/|_.__/███               /___/");
            Console.WriteLine($" ██████████████████████████████ ^v^v^v^v^v^v^v^v^v^v^v^v^v^ Home to {String.Format("{0:n0}", i)} okay movies ^v^v^v^v^v^v^v^v^v^v^v^v^v^");
            Console.WriteLine();
        }


        static void PrintLogoAnimation(int i)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.movie_projector);
            player.Play();
            System.Threading.Thread.Sleep(500);
            for (int x = 90; x >= 0; x -= 2)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(String.Concat(Enumerable.Repeat(" ", x)) + @" ██████████████████████████████");
                Console.WriteLine(String.Concat(Enumerable.Repeat(" ", x)) + @" ██ / _ \|  \/  |  _ \| |__ ███");
                Console.WriteLine(String.Concat(Enumerable.Repeat(" ", x)) + @" ██| | | | |\/| | | | | '_ \███");
                Console.WriteLine(String.Concat(Enumerable.Repeat(" ", x)) + @" ██| |_| | |  | | |_| | |_) ███");
                Console.WriteLine(String.Concat(Enumerable.Repeat(" ", x)) + @" ██ \___/|_|  |_|____/|_.__/███");
                Console.WriteLine(String.Concat(Enumerable.Repeat(" ", x)) + @" ██████████████████████████████");
                System.Threading.Thread.Sleep(15);
            }

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(@" ██████████████████████████████        __");
            Console.WriteLine(@" ██ / _ \|  \/  |  _ \| |__ ███  ___  / /_____ ___ __");
            Console.WriteLine(@" ██| | | | |\/| | | | | '_ \███ / _ \/  '_/ _ `/ // /");
            Console.WriteLine(@" ██| |_| | |  | | |_| | |_) ███ \___/_/\_\\_,_/\_, /");
            Console.WriteLine(@" ██ \___/|_|  |_|____/|_.__/███               /___/");
            Console.WriteLine(@" ██████████████████████████████");
            System.Threading.Thread.Sleep(700);

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(@" ██████████████████████████████        __                              _");
            Console.WriteLine(@" ██ / _ \|  \/  |  _ \| |__ ███  ___  / /_____ ___ __  __ _  ___ _  __(_)__");
            Console.WriteLine(@" ██| | | | |\/| | | | | '_ \███ / _ \/  '_/ _ `/ // / /  ' \/ _ \ |/ / / -_)");
            Console.WriteLine(@" ██| |_| | |  | | |_| | |_) ███ \___/_/\_\\_,_/\_, / /_/_/_/\___/___/_/\__/");
            Console.WriteLine(@" ██ \___/|_|  |_|____/|_.__/███               /___/");
            Console.WriteLine(@" ██████████████████████████████");
            System.Threading.Thread.Sleep(700);

            PrintLogo(i);
        }


        static void PrintMainMenu(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            index = 0;
            breadcrumb = "  ";
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" ╔═════════════════════════╗");
            Console.WriteLine(" ║        Main Menu        ║");
            Console.WriteLine(" ╠═════════════════════════╣");
            Console.WriteLine(" ║   [1] Search Movies     ║");
            Console.WriteLine(" ║   [2] Admin Mode        ║");
            Console.WriteLine(" ║   [3] Create Account    ║");
            Console.WriteLine(" ║   [4] Quit              ║");
            Console.WriteLine(" ╚═════════════════════════╝");
            GetMainMenuInput(movies, searchedMovies, index, breadcrumb, users);
        }


        static void PrintModifyMenu(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, Movie m)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ╔═════════════════════════════╗");
            Console.WriteLine(" ║  Select a Property to Edit  ║");
            Console.WriteLine(" ╠═════════════════════════════╣");
            Console.WriteLine(" ║   [1] Title                 ║");
            Console.WriteLine(" ║   [2] Year                  ║");
            Console.WriteLine(" ║   [3] Genre                 ║");
            Console.WriteLine(" ║   [4] IMDb Rating           ║");
            Console.WriteLine(" ║   [5] Runtime               ║");
            Console.WriteLine(" ║   [6] Director              ║");
            Console.WriteLine(" ║   [7] Lead Actor            ║");
            Console.WriteLine(" ║   [8] Supporting Actor      ║");
            Console.WriteLine(" ║   [9] Third Actor           ║");
            Console.WriteLine(" ║   [0] Lead Character        ║");
            Console.WriteLine(" ║   [S] Supporting Character  ║");
            Console.WriteLine(" ║   [T] Third Character       ║");
            Console.WriteLine(" ║   [A] Admin Menu            ║");
            Console.WriteLine(" ╚═════════════════════════════╝");
            GetModifyMenuInput(movies, searchedMovies, index, breadcrumb, m);
        }


        static void PrintSearchedResults(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users) 
        {
            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(breadcrumb);
            if (searchedMovies.Movies.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  NO MOVIES FOUND\n");
            }
            else
            {
                Console.WriteLine(" ╔════════╦═════════════════════════════════════════════════════════════════════╦═══════╦═════════╦═════════════╗");
                Console.WriteLine($" ║ {"ID",-6} ║ {"Title",-67} ║ {"Year",-5} ║ {"Runtime",-7} ║ {"IMDb Rating",-11} ║");
                Console.WriteLine(" ╠════════╬═════════════════════════════════════════════════════════════════════╬═══════╬═════════╬═════════════╣");
                searchedMovies.ListMovies(index);
                Console.WriteLine(" ╚════════╩═════════════════════════════════════════════════════════════════════╩═══════╩═════════╩═════════════╝");
                Console.WriteLine($"{"[U] Page Up   [D] Page Down",100}   [{Math.Floor(index / 7.0) + 1} of {Math.Ceiling(searchedMovies.Movies.Count / 7.0)}]");
            }
            PrintFinalMenu(movies, searchedMovies, index, breadcrumb, users);
        }


        static void PrintSearchedResultsNoMenu(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            int movieID;
            bool isInt;
            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(breadcrumb);
            if (searchedMovies.Movies.Count == 0)
            {
                Console.WriteLine(" NO MOVIES FOUND\n");
            }
            else
            {
                Console.WriteLine(" ╔════════╦═════════════════════════════════════════════════════════════════════╦═══════╦═════════╦═════════════╗");
                Console.WriteLine($" ║ {"ID",-6} ║ {"Title",-67} ║ {"Year",-5} ║ {"Runtime",-7} ║ {"IMDb Rating",-11} ║");
                Console.WriteLine(" ╠════════╬═════════════════════════════════════════════════════════════════════╬═══════╬═════════╬═════════════╣");
                searchedMovies.ListMovies(index);
                Console.WriteLine(" ╚════════╩═════════════════════════════════════════════════════════════════════╩═══════╩═════════╩═════════════╝");
                Console.WriteLine($"{"[U] Page Up   [D] Page Down",100}   [{Math.Floor(index / 7.0) + 1} of {Math.Ceiling(searchedMovies.Movies.Count / 7.0)}]");
            }

            do
            {
                Console.CursorVisible = true;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(" Enter a Movie ID: ");
                isInt = int.TryParse(Console.ReadLine().Trim(), out movieID);
            } while (isInt == false || movieID < 1);

            GetMoviePage(movies, searchedMovies, index, breadcrumb, users, movies.Movies.Count, movieID);
        }


        static void PrintSearchMenu(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            index = 0;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" ╔═════════════════════════╗");
            Console.WriteLine(" ║       Search Menu       ║");
            Console.WriteLine(" ╠═════════════════════════╣");
            Console.WriteLine(" ║   [1] Title             ║");
            Console.WriteLine(" ║   [2] Year              ║");
            Console.WriteLine(" ║   [3] Genre             ║");
            Console.WriteLine(" ║   [4] IMDb Rating       ║");
            Console.WriteLine(" ║   [5] Runtime           ║");
            Console.WriteLine(" ║   [6] Director          ║");
            Console.WriteLine(" ║   [7] Actor             ║");
            Console.WriteLine(" ║   [8] Character         ║");
            Console.WriteLine(" ║   [9] Main Menu         ║");
            Console.WriteLine(" ╚═════════════════════════╝");
            GetSearchMenuInput(movies, searchedMovies, index, breadcrumb, users);
        }


        static void PrintSearchActorMenu(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" ╔══════════════════════════╗");
            Console.WriteLine(" ║    Search Actor Menu     ║");
            Console.WriteLine(" ╠══════════════════════════╣");
            Console.WriteLine(" ║   [1] Lead Actor         ║");
            Console.WriteLine(" ║   [2] Supporting Actor   ║");
            Console.WriteLine(" ║   [3] Third Actor        ║");
            Console.WriteLine(" ║   [4] Any Actor          ║");
            Console.WriteLine(" ║   [5] Main Menu          ║");
            Console.WriteLine(" ╚══════════════════════════╝");
            GetSearchActorMenuInput(movies, searchedMovies, index, breadcrumb, users);
        }


        static void PrintSortMenu(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" ╔════════════════════════════╗");
            Console.WriteLine(" ║         Sort Menu          ║");
            Console.WriteLine(" ╠════════════════════════════╣");
            Console.WriteLine(" ║   [1] Title       (asc)    ║");
            Console.WriteLine(" ║   [2] Title       (desc)   ║");
            Console.WriteLine(" ║   [3] Year        (asc)    ║");
            Console.WriteLine(" ║   [4] Year        (desc)   ║");
            Console.WriteLine(" ║   [5] Runtime     (asc)    ║");
            Console.WriteLine(" ║   [6] Runtime     (desc)   ║");
            Console.WriteLine(" ║   [7] IMDb Rating (asc)    ║");
            Console.WriteLine(" ║   [8] IMDb Rating (desc)   ║");
            Console.WriteLine(" ║   [9] Main Menu            ║");
            Console.WriteLine(" ╚════════════════════════════╝");
            GetSortMenuInput(movies, searchedMovies, index, breadcrumb, users);
        }


        static void SearchActor(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            PrintLogo(movies.Movies.Count);
            PrintSearchActorMenu(movies, searchedMovies, index, breadcrumb, users);
        }


        static void SearchAnyActor(MovieDB movies, int index, string breadcrumb, UserDB users)
        {
            MovieDB searchedMovies = new MovieDB();
            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = true;
            Console.Write(" Enter an Actor: ");
            string input = Console.ReadLine().Trim().ToLower();
            foreach (Movie m in movies.Movies)
            {
                if (m.LeadActor.ToLower() == input)
                {
                    searchedMovies.AddMovie(m);
                }
            }
            foreach (Movie m in movies.Movies)
            {
                if (m.SupportingActor.ToLower() == input)
                {
                    searchedMovies.AddMovie(m);
                }
            }
            foreach (Movie m in movies.Movies)
            {
                if (m.ThirdActor.ToLower() == input)
                {
                    searchedMovies.AddMovie(m);
                }
            }
            breadcrumb += $"Any Actor: {input} | ";
            PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
        }


        static void SearchCharacter(MovieDB movies, int index, string breadcrumb, UserDB users)
        {
            MovieDB searchedMovies = new MovieDB();

            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = true;
            Console.Write(" Enter a Character: ");
            string input = Console.ReadLine().Trim().ToLower();
            foreach (Movie m in movies.Movies)
            {
                if (m.Character1.ToLower().Contains(input))
                {
                    searchedMovies.AddMovie(m);
                }
            }

            foreach (Movie m in movies.Movies)
            {
                if (m.Character2.ToLower().Contains(input))
                {
                    searchedMovies.AddMovie(m);
                }
            }

            foreach (Movie m in movies.Movies)
            {
                if (m.Character3.ToLower().Contains(input))
                {
                    searchedMovies.AddMovie(m);
                }
            }
            breadcrumb += $"Character: {input} | ";
            PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
        }


        static void SearchDirector(MovieDB movies, int index, string breadcrumb, UserDB users)
        {
            MovieDB searchedMovies = new MovieDB();
            bool isMatch = false;

            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = true;
            Console.Write(" Enter a Director: ");
            string input = Console.ReadLine().Trim().ToLower();
            foreach (Movie m in movies.Movies)
            {
                if (m.Director.ToLower().Contains(input))
                {
                    isMatch = true;
                    searchedMovies.AddMovie(m);
                }
            }

            if (!isMatch)
            {
                List<string> directors = new List<string>();
                double coefficient;

                Console.WriteLine("\n Director not found. Did you mean:\n");
                Console.ForegroundColor = ConsoleColor.Yellow;

                foreach (Movie m in movies.Movies)
                {
                    if (!directors.Contains(m.Director)) 
                    {
                        directors.Add(m.Director);
                        coefficient = input.LevenshteinDistance(m.Director);
                        if(coefficient < 4)
                        {
                            Console.WriteLine($" {m.Director}");
                        }
                    }
                }

                char cont;
                do
                {
                    Console.WriteLine("\nHit [C] to continue");
                    cont = Console.ReadKey().KeyChar;
                } while (cont != 'C' && cont != 'c'); 
            }

            breadcrumb += $"Director: {input} | ";
            PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
        }


        static void SearchGenre(MovieDB movies, int index, string breadcrumb, UserDB users)
        {
            MovieDB searchedMovies = new MovieDB();
            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintGenreMenu();
            Console.CursorVisible = true;
            Console.Write(" Enter a Genre: ");
            string input = Console.ReadLine().Trim().ToLower();
            foreach (Movie m in movies.Movies)
            {
                if (m.Genre.ToLower().Contains(input))
                {
                    searchedMovies.AddMovie(m);
                }
            }
            breadcrumb += $"Genre: {input} | ";
            PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
        }


        static void SearchImdbRating(MovieDB movies, int index, string breadcrumb, UserDB users)
        {
            MovieDB searchedMovies = new MovieDB();
            bool isInt;
            int inputLowerBound;
            int inputUpperBound;
            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = true;

            do
            {
                Console.Write(" Enter a Lower Bound IMDb Rating: ");
                isInt = int.TryParse(Console.ReadLine().Trim(), out inputLowerBound);
            } while (!isInt || inputLowerBound < 0 || inputLowerBound > 10);

            do
            {
                Console.Write("\n Enter a Upper Bound IMDb Rating: ");
                isInt = int.TryParse(Console.ReadLine().Trim(), out inputUpperBound);
            } while (!isInt || inputUpperBound < 0 || inputUpperBound > 10);

            foreach (Movie m in movies.Movies)
            {
                if (m.ImdbRating >= inputLowerBound && m.ImdbRating <= inputUpperBound)
                {
                    searchedMovies.AddMovie(m);
                }
            }
            breadcrumb += $"IMDb Rating: {inputLowerBound}-{inputUpperBound} | ";
            PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
        }


        static void SearchLeadActor(MovieDB movies, int index, string breadcrumb, UserDB users)
        {
            MovieDB searchedMovies = new MovieDB();
            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = true;
            Console.Write(" Enter a Lead Actor: ");
            string input = Console.ReadLine().Trim().ToLower();
            foreach (Movie m in movies.Movies)
            {
                if (m.LeadActor.ToLower() == input)
                {
                    searchedMovies.AddMovie(m);
                }
            }
            breadcrumb += $"Lead Actor: {input} | ";
            PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
        }


        static void SearchRuntime(MovieDB movies, int index, string breadcrumb, UserDB users)
        {
            MovieDB searchedMovies = new MovieDB();
            bool isInt;
            int inputLowerBound;
            int inputUpperBound;
            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = true;

            do
            {
                Console.Write(" Enter a Lower Bound Runtime: ");
                isInt = int.TryParse(Console.ReadLine().Trim(), out inputLowerBound);
            } while (!isInt || inputLowerBound < 0 || inputLowerBound > 999);

            do
            {
                Console.Write("\n Enter a Upper Bound Runtime: ");
                isInt = int.TryParse(Console.ReadLine().Trim(), out inputUpperBound);
            } while (!isInt || inputUpperBound < 0 || inputUpperBound > 999);

            foreach (Movie m in movies.Movies)
            {
                if (m.RunTime >= inputLowerBound && m.RunTime <= inputUpperBound)
                {
                    searchedMovies.AddMovie(m);
                }
            }
            breadcrumb += $"Runtime: {inputLowerBound}mins-{inputUpperBound}mins | ";
            PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
        }


        static void SearchSupportingActor(MovieDB movies, int index, string breadcrumb, UserDB users)
        {
            MovieDB searchedMovies = new MovieDB();
            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = true;
            Console.Write(" Enter a Supporting Actor: ");
            string input = Console.ReadLine().Trim().ToLower();
            foreach (Movie m in movies.Movies)
            {
                if (m.SupportingActor.ToLower() == input)
                {
                    searchedMovies.AddMovie(m);
                }
            }
            breadcrumb += $"Supporting Actor: {input} | ";
            PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
        }


        static void SearchMovies(MovieDB movies, MovieDB searchedMovies, int index, string breadcrumb, UserDB users)
        {
            PrintLogo(movies.Movies.Count);
            PrintSearchMenu(movies, searchedMovies, index, breadcrumb, users);
        }


        static void SearchThirdActor(MovieDB movies, int index, string breadcrumb, UserDB users)
        {
            MovieDB searchedMovies = new MovieDB();
            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = true;
            Console.Write(" Enter a Third Actor: ");
            string input = Console.ReadLine().Trim().ToLower();
            foreach (Movie m in movies.Movies)
            {
                if (m.ThirdActor.ToLower() == input)
                {
                    searchedMovies.AddMovie(m);
                }
            }
            breadcrumb += $"Third Actor: {input} | ";
            PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
        }


        static void SearchTitle(MovieDB movies, int index, string breadcrumb, UserDB users)
        {
            MovieDB searchedMovies = new MovieDB();

            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = true;
            Console.Write(" Enter a Title: ");
            string input = Console.ReadLine().Trim().ToLower();
            foreach (Movie m in movies.Movies)
            {
                if (m.Title.ToLower().Contains(input))
                {
                    searchedMovies.AddMovie(m);
                }
            }
            breadcrumb += $"Title: {input} | ";
            PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
        }


        static void SearchYear(MovieDB movies, int index, string breadcrumb, UserDB users)
        {
            MovieDB searchedMovies = new MovieDB();
            bool isInt;
            int inputLowerBound;
            int inputUpperBound;
            PrintLogo(movies.Movies.Count);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = true;

            do
            {
                Console.Write(" Enter a Lower Bound Year: ");
                isInt = int.TryParse(Console.ReadLine().Trim(), out inputLowerBound);
            } while (!isInt || inputLowerBound < 1850 || inputLowerBound > 2025);

            do
            {
                Console.Write("\n Enter a Upper Bound Year: ");
                isInt = int.TryParse(Console.ReadLine().Trim(), out inputUpperBound);
            } while (!isInt || inputUpperBound < 1850 || inputUpperBound > 2025);

            foreach (Movie m in movies.Movies)
            {
                if (m.Year >= inputLowerBound && m.Year <= inputUpperBound)
                {
                    searchedMovies.AddMovie(m);
                }
            }
            breadcrumb += $"Year: {inputLowerBound}-{inputUpperBound} | ";
            PrintSearchedResults(movies, searchedMovies, index, breadcrumb, users);
        }
    }
}