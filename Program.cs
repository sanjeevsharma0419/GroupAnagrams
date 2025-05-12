namespace GroupAnagrams;

public class Program
{
    public static void Main(string[] args)
    {
        List<string> inputList = ["eat", "tea", "tan", "ate", "nat", "bat"];

        // Call the method to group anagrams and print it in the desired format
        GroupedAnagramsUsingSortingWithDictionary(inputList);

        // call the LINQ method to group anagrams and print it in the desired format
        GroupedAnagramsUsingLinq(inputList);
    }
    
    // Method to group anagrams
    private static void GroupedAnagramsUsingSortingWithDictionary(List<string> words)
    {
        // Step 1: Create a dictionary to group words by their sorted character form
        var anagramGroups = new Dictionary<string, List<string>>();
    
        foreach (var word in words)
        {
            // Step 2: Sort the word's characters to get the key
            var sortedKey = new string(word.OrderBy(c => c).ToArray());
    
            // Step 3: Add the original word to the corresponding group in the dictionary
            if (!anagramGroups.ContainsKey(sortedKey))
            {
                anagramGroups[sortedKey] = new List<string>();
            }
            anagramGroups[sortedKey].Add(word);
        }
    
        // Step 4: Return the grouped anagrams as a list of lists
        var groupedAnagrams = anagramGroups.Values.ToList();

        // Create a list of string representations of each group
        List<string> groups = new List<string>();

        foreach (var group in groupedAnagrams)
        {
            // Join the words in the group with commas and wrap them in quotes
            string groupString = "[" + string.Join(", ", group.Select(w => $"\"{w}\"")) + "]";
            groups.Add(groupString);
        }

        // Join all groups with a comma and print them in the final format
        Console.WriteLine("[" + string.Join(", ", groups) + "]");
    }

    private static void GroupedAnagramsUsingLinq(List<string> inputList)
    {
        var grouped = inputList
            .GroupBy(word => string.Concat(word.OrderBy(c => c)))  // Group by sorted characters
            .Select(group => group.OrderBy(w => inputList.IndexOf(w)).ToList()) // Preserve input order within groups
            .ToList();

        // Print result in desired format
        Console.WriteLine("[" + string.Join(", ", grouped.Select(group => "[" + string.Join(", ", group.Select(w => $"\"{w}\"")) + "]")) + "]");
    }
}