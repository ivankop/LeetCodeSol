using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class getNumberOfMoviesSol
    {
        public static int getNumberOfMovies(string substr)
        {
            /*
             * Endpoint: "https://jsonmock.hackerrank.com/api/moviesdata/search/?Title=substr"
             */

            using (var httpClient = new HttpClient())
            {
                var apiUrl = $"https://jsonmock.hackerrank.com/api/moviesdata/search/?Title={substr}";
                var response = httpClient.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = response.Content.ReadAsStringAsync().Result;
                    // Console.WriteLine(jsonContent);
                    var searchResult = JsonConvert.DeserializeObject<MoviesDataSearchResult>(jsonContent);
                    
                    return searchResult.total;
                }
                else
                {
                    throw new Exception($"getNumberOfMovies Failed. StatusCode: {response.StatusCode}");
                }
            }
            
        }

        class MoviesDataSearchResult
        {
            public int page { get; set; }
            public int total { get; set; }
            public int per_page { get; set; }
            public int total_page { get; set; }
            public List<MoviesData> data { get; set; }
            public MoviesDataSearchResult(int page, int total, int per_page, int total_page, List<MoviesData> data)
            {
                this.page = page;
                this.total = total;
                this.per_page = per_page;
                this.total_page = total_page;
                this.data = data;
            }
        }
        class MoviesData
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string imdbID { get; set; }
            public MoviesData(string title, string year, string imdbID)
            {
                Title = title;
                Year = year;
                this.imdbID = imdbID;
            }
        }
    }
}
