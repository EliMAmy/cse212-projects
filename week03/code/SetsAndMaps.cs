using System.Text.Json;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

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
        // TODO Problem 1 - ADD YOUR CODE HERE
        // Use a HashSet to store the words for O(1) lookups
        var wordSet = new HashSet<string>(words);
        // Use a HashSet to keep track of processed words to avoid duplicates in the result
        var processed = new HashSet<string>();
        // Use a list to store the resulting pairs
        var result = new List<string>();
        // Loop through each word in the input array
        foreach (var word in words)
        {
            // Check if the first and second characters are the same, if so skip this word
            if (word[0] == word[1]) 
                continue;
            // Check if the word has already been processed, if so skip this word
            if (!processed.Add(word)) 
                continue;
            // the variable 'reversed' is used to store the reversed version of the current word, which is created by concatenating the second character and the first character of the word
            var reversed = $"{word[1]}{word[0]}";
            // here use the if statement to check if the reversed word is in the HashSet of words, if it is then we add the pair to the result list and mark both words as processed
            if (wordSet.Contains(reversed))
            {   
                // we add the pair to the result list in the format "word & reversed"
                result.Add($"{word} & {reversed}");
                processed.Add(word);
                processed.Add(reversed);

            }
        }
        // Finally, we convert the result list to an array and return it 
        return result.ToArray();

    }


    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        // here we will use a dictionary to count the occurrences of each degree
        var degrees = new Dictionary<string, int>();
        //then we will read the file line by line, split each line by commas, and extract the degree from the 4th column (index 3)
        foreach (var line in File.ReadLines(filename))
        {
            // using the Split method to split the line by commas and get the degree from the 4th column (index 3)
            var fields = line.Split(",");
            // then we will trim the degree to remove any leading or trailing whitespace
            var degree = fields[3].Trim();
            // here we will check if the degree is already in the dictionary, if it is we will increment the count, if not we will add it to the dictionary with a count of 1
            if (degrees.ContainsKey(degree))
            {
                // if the degree is already in the dictionary, we will increment the count in the dictionary by 1
                degrees[degree]++;
            }
            else
            {
                // if the degree is not in the dictionary, we will add it to the dictionary with a count of 1
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        //we need to remove spaces and convert to lower case to ignore spaces and cases
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();
        //Then is important to check if the lengths of the two words are equal, if not they cannot be anagrams
        if (word1.Length != word2.Length)
            return false;
        // using a dictionary to count the occurrences of each letter in word1, 
        // using foreach loop to iterate through each letter in word1 and add it to the dictionary with a count of 1 if it is not already in the dictionary, or increment the count if it is already in the dictionary
        var letterCount = new Dictionary<char, int>();
        foreach (char letter in word1)
        {                       
            //this part checks if the letter is already in the dictionary, if it is we increment the count, if not we add it to the dictionary with a count of 1
            if (letterCount.ContainsKey(letter))
                letterCount[letter]++;
            else
                letterCount[letter] = 1;
        }
        // In this part we will iterate through each letter in word2 and check if it is in the dictionary, if it is we decrement the count, if not we return false.
        foreach (char letter in word2)
        {
            // this part checks if the letter is in the dictionary, if it is we decrement the count, if not we return false
            if (!letterCount.TryGetValue(letter, out int count))
                return false;
            //the count variable is used to keep track of the number of occurrences of each letter in word1
            count--;
            //if the count is less than 0, it means that word2 has more occurrences of that letter than word1, so we return false
            if (count < 0)
                return false;
            //if the count is not less than 0, we update the count in the dictionary
            letterCount[letter] = count;
        }
        // Finally, we check if all the counts in the dictionary are 0, if they are we return true, if not we return false
        return letterCount.Values.All(v => v == 0);
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
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

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}