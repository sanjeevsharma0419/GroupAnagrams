# Grouped Anagrams
This solution is to group given list of string, which are anagrams.
Anagrams are words which have same number of characters, same characters but in different order, i.e., ate, eat, tea are anagram words.

Input  => ["eat", "tea", "tan", "ate", "nat", "bat"]

Output => [["ate", "eat", "tea"], ["nat", "tan"], ["bat"]]

This solution provides with 2 options:
1. Traditional way: To sort the given string and then group the anagrams using dictionary.
2. LINQ way: To sort the given string using LINQ functions
