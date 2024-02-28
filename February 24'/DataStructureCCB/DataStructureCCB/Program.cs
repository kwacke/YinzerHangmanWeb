public class Program
{
    public static void Main(string[] args)
    {
        // create an array that holds 5 integers
        int[] numbers = new int[5];

        int howMany = 0;
        Console.WriteLine("How many numbers in the array: ");
        howMany = int.Parse(Console.ReadLine());

        int[] numberArray = new int[howMany];
        Console.WriteLine($"This array holds {numberArray.Length} elements");

        for (int i = 0; i < numberArray.Length; i++)
        {
            Console.Write("Enter a number: ");
            numberArray[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("The array is " );

        foreach(int n in numberArray)
        {
            Console.WriteLine($"{n}");
        }

        // find the minimum value
        int max = numberArray[0];
        for (int i = 1; i < numberArray.Length; i++)
        {
            if (max < numberArray[i])
            {
                max = numberArray[i];
            }
            
        }

        Console.WriteLine($"The maximum value is {max}");
        // find the maximum value
        int min = numberArray[0];
        for (int i = 1; i < numberArray.Length; i++)
        {
            if (min > numberArray[i])
            {
                min = numberArray[i];
            }

        }
        Console.WriteLine($"The minumum value is {min}");
        // find the average

        int sum = 0;
        foreach(int n in numberArray)
        {
            sum += n;
        }

        double average = (double)sum / numberArray.Length;
        Console.WriteLine($"The average is {average}");

        // sort the array -- bubble sort!
        // 45 23 67 12 1
        for (int i = 0; i < numberArray.Length; i++)
        {
            for (int j = 0; j < numberArray.Length - 1; j++)
            {
                if (numberArray[j] > numberArray[j+1])
                {
                    // swap the values!
                    int temp = numberArray[j];
                    numberArray[j] = numberArray[j + 1];
                    numberArray[j+1] = temp;
                }
            }
        }

        Console.WriteLine("The sorted array is ");

        foreach (int n in numberArray)
        {
            Console.WriteLine($"{n}");
        }

        Dictionary<string, int> map = new Dictionary<string, int>();

        bool isDone = false;
        while (!isDone)
        {
            Console.Write("Enter a name: ");
            string name = Console.ReadLine();
            if (map.ContainsKey(name))
            {
                map[name] = ++map[name];
            } else
            { 
               map[name] = 1;
            }
            Console.Write("Enter more? (y/n) ");
            if (Console.ReadLine() == "n")
            {
                isDone = true;
            }
        }
        foreach(KeyValuePair<string, int> n in map)
        {
            Console.Write($"{n.Key}={n.Value}, ");
        }
    }
}