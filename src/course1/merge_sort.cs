////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : merge_sort.cs
//Author      : Travis Mann
//Date        : 01/03/2023
//Description : Script for running the merge sort algorithm
////////////////////////////////////////////////////////////////////////////////////////////////////////

// --- funcs --- 
static int[] MergeSort(int[] arrayToSort)
{
    /// <summary>
    /// Perform recursive merge sort algorithm -> O(nlogn) computations
    /// </summary>
    /// <param name="arrayToSort">Array of random ints to sort</param>
    /// <returns>
    /// mergedArray: sorted array from merging firstArray and secondArray
    /// </returns>

    // base case: ArrayToSort has only 1 element
    if (arrayToSort.Length <= 1)
    {
        return arrayToSort;
    }

    // step 0: split array
    int[][] splitArrays = SplitArray(arrayToSort);

    // step 1: 1st half recursive sort
    int[] firstHalfSorted = MergeSort(splitArrays[0]);

    // step 2:  2nd half recursive sort
    int[] secondHalfSorted = MergeSort(splitArrays[1]);

    // step 3: merge 1st and 2nd half
    return Merge(firstHalfSorted, secondHalfSorted);
}

static int[] Merge(int[] firstArray, int[] secondArray)
{
    /// <summary>
    /// Merge functionality for MergeSort.
    /// </summary>
    /// <param name="firstArray">Sorted array to merge with secondArray.</param>
    /// <param name="secondArray">Sorted array to merge with firstArray.</param>
    /// <returns>
    /// mergedArray: sorted array from merging firstArray and secondArray
    /// </returns>

    // declare final array
    int totalLength = firstArray.Length + secondArray.Length;
    int[] mergedArray = new int[totalLength];

    // set array indecies
    int firstArrayIndex = 0;
    int secondArrayIndex = 0;

    // loop through arrays
    for (int mergedArrayIndex = 0; mergedArrayIndex < totalLength; mergedArrayIndex++)
    {
        // handle cases with remaining elements in both arrays
        // add next element from 1st array if 2nd array is out of elements or if 1st array still has elements 
        // and the next element from the 1st array is less than the next element from the 2nd array
        if (secondArrayIndex >= secondArray.Length || firstArrayIndex < firstArray.Length && firstArray[firstArrayIndex] < secondArray[secondArrayIndex])
        {
            // add next element from 1st array to final array
            mergedArray[mergedArrayIndex] = firstArray[firstArrayIndex];
            // increment 1st array index now that the current element has been handled
            firstArrayIndex++;
        }
        else  // next element in 2nd array is smaller
        {
            // add next element from 2nd array to final array
            mergedArray[mergedArrayIndex] = secondArray[secondArrayIndex];
            // increment 1st array index now that the current element has been handled
            secondArrayIndex++;
        }

    }

    // output merged array
    return mergedArray;
}

static int[][] SplitArray(int[] arrayToSplit)
{
    /// <summary>
    /// Splits a given array into 2 arrays roughly in the center
    /// </summary>
    /// <param name="arrayToSplit">Single array to split in 2</param>
    /// <returns>
    /// <param name="splitArrays">Array of 2 arrays which together form the original array</param>
    /// </returns>

    // split array in half (roughly)
    int splitIndex = arrayToSplit.Length / 2;
    int[] firstHalfArray = new int[splitIndex];
    int[] secondHalfArray;
    // second array will be one element longer if the array is odd
    if (arrayToSplit.Length % 2 == 0)  // even arrayToSort
    {
        secondHalfArray = new int[splitIndex];
    }
    else  // odd arrayToSort
    {
        secondHalfArray = new int[splitIndex + 1];
    }

    // track index to add element
    int firstArrayIndex = 0;
    int secondArrayIndex = 0;

    // populate arrays
    for (int ArrayToSortIndex = 0; ArrayToSortIndex < arrayToSplit.Length; ArrayToSortIndex++)
    {
        // extract next element to add
        int elementToAdd = arrayToSplit[ArrayToSortIndex];

        // determine if element goes in 1st half list or 2nd half based on split index
        if (ArrayToSortIndex < splitIndex)
        {
            // add element to array
            firstHalfArray[firstArrayIndex] = elementToAdd;
            // increment index to add next element to further in the array
            firstArrayIndex++;
        }
        else
        {
            // add element to array
            secondHalfArray[secondArrayIndex] = elementToAdd;
            // increment index to add next element to further in the array
            secondArrayIndex++;
        }
    }

    // package and output split arrays
    int[][] splitArrays = { firstHalfArray, secondHalfArray };
    return splitArrays;
}

static void PrintIntArray(int[] arrayToPrint, string label = "", bool newLine = true)
{
    /// <summary>
    /// Splits a given array into 2 arrays roughly in the center
    /// </summary>
    /// <param name="arrayToPrint">Single array to print contents</param>
    /// <param name="label">Label to show before array contents</param>
    /// <param name="newLine">moves cursor to new line after printing array contents</param>
    /// <returns>
    /// None
    /// </returns>

    // print label before array contents
    Console.Write(label);

    // print array contents
    foreach (int element in arrayToPrint)
    {
        Console.Write("{0} ", element);
    }

    // move to new line if specified
    if (newLine)
    {
        Console.WriteLine();
    }
}

// --- main ---
// test merge sort
int[] arrayToSort = { 10, 9, 7, 6, 5, 54, 101, 2, 0 };
int[] sortedArray = MergeSort(arrayToSort);

// show array before and after merge sort
PrintIntArray(arrayToSort, "Array to Sort: ");
PrintIntArray(sortedArray, "Sorted Array: ");
