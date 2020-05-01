# Problems
## 001 - Get first non repeating character from a list of characters
>Using and algorithm O(n), create a function that returns the fulfills the followig use cases:\
>UC1) non_repeating("aabcb") -> c\
>UC2) non_repeating("xxyz") -> y\
>UC3) non_repeating("aabb")-> null

>**Solution:**
>1- Create a hash table to store the number of times a character (the key) is repeated\
>2 - While iterating the list of characters\
>2.1 - add the key (character) to the hast table and the value (1). If the key is already in the hast table, increase the number by 1\
>2.2 - Create an array with unique characters (if the character exists, dont added it again)\
>3 - Iterate the array and use each element as the key to get to the value of the dictionary\
>4.- Return the character when the first occurrence of  value equal to 1 in the dictionary appears. It indicates it is the first character with only one repetition.  


## 002 - One away string
> Use an O(n) algorithm to find if two strings are one away strings. Return true if it is\
> One away strings have the following properties:\
>1) Change: change one string in any of the two strings and then both strings are the same\
>2) Add: add a character to one of the strings then both strings are the same\
>3) Remove: remove a character from one of the string then both string are the same\
>4) Same strings: They are one away strings automatically.

>**Solution**
>1) Evaluate of both strings are equal or more than 2 characters different. If not go 2\
>1.1) Return false\
>2) Evaluate if both string have the same lenght. If not go to 3\
>2.1) Create a flag diff to store amount of different characters\
>2.2) Iterate both strings\ 
>2.2.1) increase diff if characters are not equal\
>2.2.2) if diff is bigger than 1, return "false"\
>2.3) if iteration gets to the end, return "true\
>3) Determine which of the strings have the extra character. If string #1 go to 3.1 otherwise 3.2
>3.1) AreDiffLenghtStringOneAway(string1, string2)
>3.2) ArediffLenghtStringOneAwat(string2, string1)

# Algorithms
001 - Binary Search Tree


# Notes
## Data Structures in the .Net framework
- https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=netframework-4.8
- Here the Binary search tree is implemented in two ways, SortedDictionary and SortedList 

## Markups in github
Markup github: https://pandao.github.io/editor.md/en.html

## Types in C#
C# draft speciication (Types): https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types
