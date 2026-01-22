using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var results = new List<string>();

        foreach (var word in words)
        {
            // Skip special case like "aa"
            if (word[0] == word[1])
            {
                seen.Add(word);
                continue;
            }

            var reversed = $"{word[1]}{word[0]}";

            if (seen.Contains(reversed))
            {
                results.Add($"{reversed} & {word}");
            }

            seen.Add(word);
        }

        return results.ToArray();
    }

  public static Dictionary<string, int> SummarizeDegrees(string filename)
{
    var degrees = new Dictionary<string, int>();

    foreach (var line in File.ReadLines(filename))
    {
        var fields = line.Split(",");

        // Degree is in column 4 (index 3)
        var degree = fields[3];

        if (degrees.ContainsKey(degree))
        {
            degrees[degree]++;
        }
        else
        {
            degrees[degree] = 1;
        }
    }

    return degrees;
}

   public static bool IsAnagram(string word1, string word2)
{
    var counts = new Dictionary<char, int>();

    // Normalize both words: lowercase and ignore spaces
    word1 = word1.ToLower();
    word2 = word2.ToLower();

    // Count letters in word1
    foreach (var ch in word1)
    {
        if (ch == ' ') continue;

        if (counts.ContainsKey(ch))
        {
            counts[ch]++;
        }
        else
        {
            counts[ch] = 1;
        }
    }

    // Subtract letters using word2
    foreach (var ch in word2)
    {
        if (ch == ' ') continue;

        if (!counts.ContainsKey(ch))
        {
            return false;
        }

        counts[ch]--;

        if (counts[ch] < 0)
        {
            return false;
        }
    }

    // Ensure all counts are zero
    foreach (var value in counts.Values)
    {
        if (value != 0)
        {
            return false;
        }
    }

    return true;
}


    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5
        return [];
    }
}
