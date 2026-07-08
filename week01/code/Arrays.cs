public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>

    public static double[] MultiplesOf(double number, int length)
    {
        // Comments
        // step 1: To solve this problem, We need first to remember about what is multiples of a number. A multiple of a number is the product of that number and an integer. 
        // Knowing this, we need to create an array of doubles with the specified length.
        //In this array we are going to store the multiples of the number.

        var multiples= new double[length];
        
        //step 2: Then,we need a "for" loop to iterate through the array and calculate each multiple by multiplying the number by the index + 1 (to start from 1 instead of 0). 
        // This process will continue until we reach the specified length. Finally, we will return the array containing the multiples of the number.

        for (var i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples; // replace this return statement with your own
    }


    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        //the length of the list is needed to calculate the new index for each element after rotation
        var length = data.Count;
        // Step 1: Create a new list to hold the rotated values.        
        var rotatedList = new List<int>(new int[length]);
        // Step 2:Then we need iterate through the original list(data) and calculate the new index for each element
        for (var i = 0; i < length; i++)
        {
            // Step 3: To calculate the new index we adding the amount to the current index and taking the modulus with the length of the list
            //This module makes sure that the new index wraps around to the beginning of the list if it exceeds the length of the list.
            var newIndex = (i + amount) % length;
            // Step 4: Here we need to assign the value from the original list to the new index in the rotated list
            rotatedList[newIndex] = data[i];
        }
        // Step 5: Finally, we need to clear the original list and add the rotated values back into it. This will modify the original list to reflect the rotation.
        data.Clear();
        data.AddRange(rotatedList);
    }
}
    