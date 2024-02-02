using System;

public abstract class BaseArray
{
    public abstract void Initialize(bool userFill = false);
    public abstract void Print();
    public abstract decimal Average();
}


public sealed class OneDimensionalArray : BaseArray
{
    private int[] numbers;

    public OneDimensionalArray(int length, bool user)
    {
        numbers = new int[length];
        Initialize(user);
    }

    public override void Initialize(bool user)
    {
        if (user)
        {
            UserFill();
        }
        else
        {
            RandomFill();
        }
    }

    private void RandomFill()
    {
        Random random = new Random();
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(-200, 200);
        }
    }

    private void UserFill()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
    }

    public override void Print()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
    }

    public override decimal Average()
    {
        decimal sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum / numbers.Length;
    }

    public int[] Morethenhundred()
    {
        int n2 = numbers.Length;
        string line = "";
        for (int i = 0; i < numbers.Length; i++)
        {
            if (Math.Abs(numbers[i]) > 100)
            {
                n2 -= 1;
            }
            if (Math.Abs(numbers[i]) < 100)
            {
                line += i.ToString();
            }
        }
        int[] numbers2 = new int[n2];
        for (int i = 0; i < line.Length; i++)
        {
            string newline = line[i].ToString();
            int num = int.Parse(newline);
            numbers2[i] = numbers[num];
        }
        return numbers2;
    }

    public void RemoveDuplicateAndOriginal()
    {
        int newSize = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            bool isDuplicate = false;
            for (int j = 0; j < numbers.Length; j++)
            {
                if (i != j && numbers[i] == numbers[j])
                {
                    isDuplicate = true;
                    break;
                }
            }
            if (!isDuplicate)
            {
                newSize++;
            }
        }

        int[] newArray = new int[newSize];

        int newIndex = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            bool isDuplicate = false;
            for (int j = 0; j < numbers.Length; j++)
            {
                if (i != j && numbers[i] == numbers[j])
                {
                    isDuplicate = true;
                    break;
                }
            }
            if (!isDuplicate)
            {
                newArray[newIndex] = numbers[i];
                newIndex++;
            }
        }

        numbers = newArray;
    }
}


public class ClassForMain
{
    static void Main(string[] args)
    {
        Console.WriteLine("Вы хотите заполнить массив с консоли? Введите true если да, если случайными то false.");
        bool user = bool.Parse(Console.ReadLine());
        Console.WriteLine("Введите длину массива.");
        int n = int.Parse(Console.ReadLine());
        OneDimensionalArray array = new OneDimensionalArray(n, user);
        decimal average = array.Average();
        int[] morethenhundred = new int[n];
        morethenhundred = array.Morethenhundred();
        int[] sameelements = new int[n];
        Console.WriteLine("1 Массив");
        array.Print();
        Console.WriteLine();
        Console.WriteLine("среднее значение");
        Console.WriteLine(average);
        Console.WriteLine();
        Console.WriteLine("Массив с значениями меньшими 100 по модулю");
        for (int i = 0; i < morethenhundred.Length; i++)
        {
            Console.Write(morethenhundred[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Массив без повторяющихся элементов");
        array.RemoveDuplicateAndOriginal();
        array.Print();
    }
}