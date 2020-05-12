# Problems

## 001 - Get first non repeating character from a list of characters

### Descriptions:

Using and algorithm O(n), create a function that returns the first non-repeating character of a sequence of characters

### Solution:

1. Create a hash table to store the number of times a character (the key) is repeated
2. While iterating the list of characters\
    2.1. Add the key (character) to the hast table and the value (1). If the key is already in the hast table, increase the number by 1\
    2.2. Create an array with unique characters (if the character exists, dont added it again)
3. Iterate the array and use each element as the key to get to the value of the dictionary
4. Return the character when the first occurrence of  value equal to 1 in the dictionary appears. It indicates it is the first character with only one repetition.  


## 002 - One away string

### Description: 

Use an O(n) algorithm to compare to string and determine if they are one away strings. Return true if they are

One away strings have the following properties:

1. Change: change one string in any of the two strings and then both strings are the same\
2. Add: add a character to one of the strings then both strings are the same\
3. Remove: remove a character from one of the string then both string are the same\
4. Same strings: They are one away strings automatically.

### Solution:

1. Evaluate whether both strings have more than 2 characters in lenght difference. If not go 2\
1.1 Return "false"
2. Evaluate if both string have the same lenght. If not go to 3\
2.1. Create a flag diff to store amount of different characters\
2.2. Iterate both strings\
2.2.1. increase diff if characters are not equal\
2.2.2. if diff is bigger than 1, return "false"\
2.3. if iteration gets to the end, return "true"
3. One of the strings is 1 character larger. Determine which of the strings is larger. If string #1 is larger go to 3.1 otherwise 3.2\
3.1. The String 1 is larger\
3.1.1. Create a flag "pad" and use it as index padding\
3.1.2. Iterate both strings using the same index, but use the "pad" flag in addition to the index in the larger string\
3.1.3. If element are not equal, increase the "pad" flag and run the cycle without increase the index, otherwise run 3.2.3\
3.1.4. increase the index\
3.1.5. evaluate the flag "pad", if bigger than 1 then return "false". Otherwise, continue the cycle\
3.1.6. if the iteration complets, return true\
3.2. Same as with 3.1, but the String 2 is the largest


## 003 - Assing numbers in minesweeper

### Description:

1. Create a function mine_sweeper(position_of_bombs, num_rows, num_columns)	
2. The function returns a matrix with the position of the bombs indicated with -1 and every other cell indicates the number of bombs sourrounding that cell.

### Solution:
1. Create a matrix with the size of row and column filled with zeroes
2. Iterate over the array of tuples where each tupple is: (position x, position y)
	2.1. Find the position in the matrix and assign the value -1\
2.2. Iterate over the 9 sourrounding blocks given the position x,y and increment the value to 1 if:\
2.2.1. The position is not -1\
2.2.2. The position is withing the valid range of the matrix (row/colums)

## 004 - Where to expand minesweeper

### Description:

1. Create a function in mine_sweeper named click that takes 5 arguments (detailed_matrix, num_rows, num_columns, given i, givem j)	
2. if the user clicks in a position that has a bomb or a number bigger than 0 then return the same matrix
3. if the user click in a position that has zero value then indicates with -2 all the positions that are expanded. These positions are next to each other. Note that diagonal positions are consider next to each other as well.

### Solution:
1. If the cell value is not equal to zero then return the matrix
2. Create a Queue "NextPos" to add more cells to be mark as the search continues
3. We know the cell is equal to zero then change the value to -2.
4. Explore the 8 cells around the current position and everytime a zero is found, add the position to the NextPos queue
5. Repeat until there is no more positions in the Queue

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
