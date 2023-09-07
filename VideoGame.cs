using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1___C__Review
{
    public class VideoGame : IComparable<VideoGame>
    {
        public string Name { get; set; }
        public string Platform { get; set; }
        public double Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public decimal NA_Sales { get; set; }
        public decimal EU_Sales { get; set; }
        public decimal JP_Sales { get; set; }
        public decimal Other_Sales { get; set; }
        public decimal Global_Sales { get; set; }

        public VideoGame(string name, string platform, double year, string genre, string publisher, decimal nA_Sales, decimal eU_Sales, decimal jP_Sales, decimal other_Sales, decimal global_Sales)
        {
            Name = name;
            Platform = platform;
            Year = year;
            Genre =genre;
            Publisher = publisher;
            NA_Sales = nA_Sales;
            EU_Sales = eU_Sales;
            JP_Sales = jP_Sales;
            Other_Sales = other_Sales;
            Global_Sales = global_Sales;
        }

        public VideoGame()
        {
            // Default constructor
            Name = "";
            Platform = "";
            Year = 0;
            Genre = "";
            Publisher = "";
            NA_Sales = 0.0m;
            EU_Sales = 0.0m;
            JP_Sales = 0.0m;
            Other_Sales = 0.0m;
            Global_Sales = 0.0m;
        }

        public int CompareTo(VideoGame? other)
        {
            int result = Name.CompareTo(other.Name);

            return result;
        }


        public override string ToString()
        {
            return $"{Name}, {Platform}, {Year}, {Genre}, {Publisher}, {NA_Sales}, {EU_Sales}, {JP_Sales}, {Other_Sales}, {Global_Sales}";
        }


    
    }
}
