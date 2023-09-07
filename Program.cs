using System.Threading.Channels;

namespace Lab_1___C__Review
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<VideoGame> gamesList = new List<VideoGame>();


            string rootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string filePath = $"{rootFolder}{Path.DirectorySeparatorChar}videogames.csv";


            using (var sr = new StreamReader(filePath))
            {
                string[] fileReader = File.ReadAllLines(filePath);

                // Display the contents of the file
                for (int i = 1; i < fileReader.Length; i++)
                {
                    string line = fileReader[i];
                    // 1. Create the object from the line (which is a string)

                    string? lineDos = sr.ReadLine();

                    // 1a. Split the line on comma (CSV)

                    string[] lineElements = line.Split(',');

                    // 2. Add that object to your list (gamesList.Add)

                    VideoGame games = new VideoGame
                    {
                        Name = lineElements[0],
                        Platform = lineElements[1],
                        Year = double.Parse(lineElements[2]),
                        Genre = lineElements[3],
                        Publisher = lineElements[4],
                        NA_Sales = decimal.Parse(lineElements[5]),
                        EU_Sales = decimal.Parse(lineElements[6]),
                        JP_Sales = decimal.Parse(lineElements[7]),
                        Other_Sales = decimal.Parse(lineElements[8]),
                        Global_Sales = decimal.Parse(lineElements[9])
                    };
                    gamesList.Add(games);


                }

                // 3. Uncomment this
                gamesList = gamesList.OrderBy(record => record.Name).ToList();

                // 4. uncomment this
                //  Console.WriteLine($"File Contents: {fileReader[0]} ");
                Console.WriteLine("File Contents:");
                foreach (var g in gamesList) Console.WriteLine(g);

            }

            Console.WriteLine("Continue? If so press Enter.");
            Console.Read();
            Console.Clear();



            using (var sr = new StreamReader(filePath))
            {
                try
                {
                    // Use Where to filter games published by "Nintendo"
                    var nintendoGames = gamesList.Where(game => game.Publisher.Equals("Nintendo", StringComparison.OrdinalIgnoreCase));

                    // Display the filtered games
                    foreach (var game in nintendoGames)
                    {

                        Console.WriteLine($"Title: {game.Name}, Publisher: {game.Publisher}");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

            }

            Console.WriteLine("To continue press ENTER");
            Console.Read();
            Console.Clear();


            ////////////// PERCENTAGE PART (PUBLISHER) /////////////

            using (var sr = new StreamReader(filePath))
            {
                try
                {

                    // Choose the publisher you want to calculate for
                    string chosenPublisher = "Nintendo"; // Replace with your chosen publisher

                    // Filter games published by the chosen publisher
                    var publisherGames = gamesList.Where(game => game.Publisher.Equals(chosenPublisher, StringComparison.OrdinalIgnoreCase)).ToList();

                    int totalGames = gamesList.Count;
                    int publisherGamesCount = publisherGames.Count;

                    // Calculate the percentage
                    double percentage = (double)publisherGamesCount / totalGames * 100;
                    percentage = Math.Round(percentage, 2);

                    // Display the results
                    Console.WriteLine($"Out of {totalGames} games, {publisherGamesCount} are developed by {chosenPublisher}, which is {percentage}%.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }


            ////////////// GENRE PART /////////////////

            Console.WriteLine("Press Enter to continue");
            Console.Read();
            Console.Clear();


            using (var sr = new StreamReader(filePath))
            {
                try
                {
                    var genreType = gamesList.Where(game => game.Genre.Equals("Fighting", StringComparison.OrdinalIgnoreCase));

                    foreach (var game in genreType)
                    {

                        Console.WriteLine($"Title: {game.Name}, Publisher: {game.Publisher}, Genre: {game.Genre}");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }


            Console.WriteLine("Press Enter to continue");
            Console.Read();
            Console.Clear();

            ////////////// PERCENTAGE PART (GENRE) /////////////

            using (var sr = new StreamReader(filePath))
            {
                try
                {

                    // Choose the genre you want to calculate for
                    string chosenGenre = "Fighting";

                    // Filter games published by the chosen genre
                    var gameGenre = gamesList.Where(game => game.Genre.Equals(chosenGenre, StringComparison.OrdinalIgnoreCase)).ToList();

                    int totalGenres = gamesList.Count;
                    int genreGamesCount = gameGenre.Count;

                    // Calculate the percentage
                    double percentage = (double)genreGamesCount / totalGenres * 100;
                    percentage = Math.Round(percentage, 2);

                    // Display the results
                    Console.WriteLine($"Out of {totalGenres} games, {genreGamesCount} are {chosenGenre}, which is {percentage}%.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }



            try
            {

                // Prompt the user for the publisher name
                Console.Write("Enter the publisher name: ");
                string chosenPublisher = Console.ReadLine();

                // Call the PublisherData method to calculate and display data
                PublisherData(gamesList, chosenPublisher);
              
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }




            ////////////////// USER CHOOSES THE PUBLISHER /////////////////////////

            Console.WriteLine("Press Enter to continue");
            Console.Read();
            Console.Clear();


            static void PublisherData(List<VideoGame> gamesList, string chosenPublisher)
            {
                // Filter games published by the chosen publisher
                var publisherGames = gamesList
                    .Where(games => games.Publisher.Equals(chosenPublisher, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Filter all games
                var allGames = gamesList;

                // Count the total number of games and the number of games from the chosen publisher
                int totalGames = allGames.Count;
                int publisherGamesCount = publisherGames.Count;

                // Calculate the percentage
                double percentage = (double)publisherGamesCount / totalGames * 100;
                percentage= Math.Round(percentage, 2);

                // Display the results
                foreach (var game in publisherGames)
                {
                    Console.WriteLine($"Title: {game.Name}, Publisher: {game.Publisher}");
                }
                Console.WriteLine($"Out of {totalGames} games, {publisherGamesCount} are developed by {chosenPublisher}, which is {percentage}%.");

            }


            ////////////////// USER INPUTS GENRE PART //////////////////////

            Console.WriteLine("Press Enter to continue");
            Console.Read();
            Console.Clear();

            try
            {

                // Prompt the user for the genre
                Console.Write("Enter the genre: ");
                string chosenGenre = Console.ReadLine();

                // Call the GenreData method to calculate and display data
                GenreData(gamesList, chosenGenre);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }



            static void GenreData(List<VideoGame> gamesList, string chosenGenre)
            {
                // Filter games of the chosen genre
                var genreGames = gamesList
                    .Where(game => game.Genre.Equals(chosenGenre, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Filter all games of any genre
                var allGames = gamesList;

                // Count the total number of games and the number of games of the chosen genre
                int totalGames = allGames.Count;
                int genreGamesCount = genreGames.Count;

                // Calculate the percentage
                double percentage = (double)genreGamesCount / totalGames * 100;
                percentage= Math.Round(percentage, 2);

                foreach(var game in genreGames) 
                {
                    Console.WriteLine($"Title: {game.Name}, Publisher: {game.Genre}");
                }

                // Display the results
                Console.WriteLine($"Out of {totalGames} games, {genreGamesCount} are of the genre {chosenGenre}, which is {percentage}%.");



            }

        }
    }
}