Console.WriteLine("Enter numbers :");
string NumberArray = Console.ReadLine();

string[] numberStrings = NumberArray.Split(',');
int[] numbers = new int[numberStrings.Length];

for (int i = 0; i < numberStrings.Length; i++)
{
    if (int.TryParse(numberStrings[i], out int number))
    {
        numbers[i] = number;
    }
    else
    {
        Console.WriteLine($"Invalid input: {numberStrings[i]} is not a valid number.");
        return;
        Console.WriteLine( ' ');
    }
}

SortArray(numbers);

Console.WriteLine("Sorted array:");
foreach (double number in numbers)
{
    Console.Write(number + " ");
}
//method for sorting
    static void SortArray(int[] array)
{
    bool sorted = false;

    while (!sorted)
    {
        sorted = true;
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {

                int temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
                sorted = false;
            }
        }
    }
}






