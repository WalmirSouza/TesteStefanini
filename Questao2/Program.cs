using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals =  getTotalScoredGoals(teamName, year).Result;

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year).Result;

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {

        using (var client = new HttpClient())
        {
            string url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page=1";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                int totalGoals = CalculateTotalGoals(responseBody, team);
                return totalGoals;
            }
            else
            {
                Console.WriteLine($"Failed to fetch data from API: {response.StatusCode}");
                return 0;
            }
        }
    }

    public static int CalculateTotalGoals(string responseBody, string team)
    {
        JObject json = JObject.Parse(responseBody);
        JArray matches = (JArray)json["data"];

        int totalGoals = 0;
        foreach (var match in matches) 
        {

            if (match["team1"].ToString() == team)
            {
                totalGoals += int.Parse(match["team1goals"].ToString());
            }
            if (match["team2"].ToString() == team)
            {
                totalGoals += int.Parse(match["team2goals"].ToString());
            }
        }

        return totalGoals;
    }
}