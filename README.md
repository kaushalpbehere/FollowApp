SortItOut - Challenge 1
- To get a list of string, with each individual string from comma-seperated-string. 
- Validating the list of elements, as there should more than 1 element in the list to compare. 
- Setting up the culture info, to GB for United Kingdom.
-  Starting BubbleSort: (sorting the list of string elements, based on number of passes.)
- ForLoop for Number of passes will be the number of times this loop will get executed.
- ForLoop for Number of string, in the list of elements.
- Comparing the 2 items based on the SortKeys, defined in the CultureInfo
- Swapping the positions of the items if the comparison is returned as -1.
- End Bubble sort.


Psychic Software - Challenge 2
- Get the lower upper bound, ideally as a input, if no input then hardcode for now. 
- Using RandomNumber.Next() within the lowerbound and upperbound generate the number. 
- Check whether the Generated number is already present in the List of Int, 'GuessHistory', if already present then generate a new one. 
- Ask the user whether the generated number is their number? if yes, end the game. 
- If its not their number, then check whether the user's number is within the range or not.  
 -- If their number higher than the range, set lowerbound =higher bound, and higher bound will be set to +15 (This should ideally be taken as input, as lower the range of addition, will have more number of iterations). 
-- If thier number is lower than the range, set the higherbound=lower bound, and then decrease the lower bound by 15. (This again should be taken as input)
 
