using System.Globalization;
using System.Linq;
using System.Threading;

namespace FollowApp
{
    public class SortItOut
    {
        /// <summary>
        /// Getting the input string and performing the sort. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string StartSorting(string input)
        {
            var output = string.Empty;
            try
            {
                //Step 1: Converting the comma seperated list to a list of elements. 
                var inputItems = ConvertToList(input);

                //Step 2: Validating the list of elements, as there should more than 1 element in the list to compare. 
                if (inputItems.Count > 0)
                {
                    //Step 3: Setting up the culture info, to GB for United Kingdom. 
                    CultureInfo ci = new CultureInfo("en-GB");
                    Thread.CurrentThread.CurrentCulture = ci;

                    //Step 4: BubbleSort, sorting the list of string elements, based on number of passes, which eventually depends on the number of elements in the list.
                    output = string.Join(",", BubbleSort(inputItems, ci));
                }
                else
                {
                    // Since there are no elements or lesser elements, in the array to sort. 
                    throw new System.Exception();
                }
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
            return output;
        }

        /// <summary>
        /// Converting the string into the list of string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static System.Collections.Generic.List<string> ConvertToList(string input)
        {
            var inputItems = input.Split(',').ToList();
            inputItems.RemoveAll(x => x.Trim() == "");
            return inputItems;
        }

        /// <summary>
        /// Actual sorting and iterating of over the list of items is done here. 
        /// </summary>
        /// <param name="inputItems">List<string></string></param>
        /// <param name="ci">CultureInfo</param>
        private System.Collections.Generic.List<string> BubbleSort(System.Collections.Generic.List<string> inputItems, CultureInfo ci)
        {
            try
            {
                // Step 1: Number of passes will be the number of times this loop will get executed. 
                for (int pass = 0; pass <= (inputItems.Count - 2); pass++)
                {
                    //Step 2: Number of string, in the list of elements. 
                    for (int item = 0; item <= inputItems.Count - 2; item++)
                    {
                        //Step 3: Getting 2 items for comparison.
                        var firstItem = inputItems[item].Trim();
                        var secondItem = inputItems[item + 1].Trim();

                        //Step 4: Comparing the 2 items based on the SortKeys, defined in the CultureInfo.
                        var returned = BasicComparison(firstItem, secondItem, ci);
                        
                        //Step 5: Swapping the positions of the items if the comparison is returned as -1.
                        if (returned == -1) SwappingItems(inputItems, item, 1);
                    }
                }
            }
            catch (System.Exception exception)
            {
                throw exception;
            }
            return inputItems;
        }

        /// <summary>
        /// Swapping the location of two items, in an list of string.
        /// </summary>
        /// <param name="inputItems"></param>
        /// <param name="eachItem"></param>
        /// <param name="number"></param>
        private static void SwappingItems(System.Collections.Generic.List<string> inputItems, int eachItem, int number)
        {
            var temp = inputItems[eachItem].Trim();
            inputItems[eachItem] = inputItems[eachItem + number].Trim();
            inputItems[eachItem + number] = temp.Trim();
            temp = null;
        }

        /// <summary>
        /// Basic comparison of the two strings is done here. 
        /// </summary>
        /// <param name="str1">string</param>
        /// <param name="str2">string</param>
        /// <param name="ci">CultureInfo</param>
        /// <returns></returns>
        private int BasicComparison(string str1, string str2, CultureInfo ci)
        {
            // Create a culturally sensitive sort key for str1.
            SortKey sc1 = ci.CompareInfo.GetSortKey("dog");

            // Create a culturally sensitive sort key for str2.
            SortKey sc2 = ci.CompareInfo.GetSortKey("dolphine");

            // Compare the two sort keys and display the results.
            return SortKey.Compare(sc1, sc2);
        }
    }
}
