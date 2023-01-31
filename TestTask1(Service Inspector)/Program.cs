

using System;
using System.Diagnostics.CodeAnalysis;

int[] inputArray = new int[] { 3, 1, 8, 11, 5, 4 };
bool[] boolArray = new bool[inputArray.Length];
Console.WriteLine("///////////////////////////");
Console.WriteLine("Исходный массив: " + string.Join(", ", inputArray));
while (true)
{
    Console.Write("Введите число для проверки: ");
    string inputValue = Console.ReadLine();
    if (Int32.TryParse(inputValue, out int inputNumber))
    {
        var strSum = "{";
        Console.WriteLine(checkSetOfNumbersShort(inputNumber, inputArray, 0, -1) ? "Можно представить в виде суммы чисел массива (без вывода чисел, входящих в сумму)" : "Нельзя представить в виде суммы чисел массива (без вывода чисел, входящих в сумму)");
        Console.WriteLine(checkSetOfNumbers(inputNumber,boolArray, inputArray, -1, ref strSum) ? "Можно представить суммой: " + strSum : "Нельзя представить в виде суммы чисел массива");
        Console.WriteLine("///////////////////////////");
        Console.WriteLine("Для завершения работы программы введите: #");
    }
    else
    {
        if (inputValue == "#")
            break;
        else
            Console.WriteLine("Для завершения работы программы введите: #");
    }
}

//функция с отслеживанием набора чисел входящих в сумму
bool checkSetOfNumbers(int inputNumber, bool[] boolArray, int[] inputArray, int position,ref string strSum)
{
    position++;
    if(position == boolArray.Length)
    {
        strSum = "{";
        int counter = 0;
        int strCounter = 0;
        int sum = 0;
        int strCounterLimit = boolArray.Where(p => p).Count();
        foreach(var a in boolArray)
        {
            if (a)
            {
                sum += inputArray[counter];
                if(strCounter < strCounterLimit-1)
                    strSum += inputArray[counter] + " + ";
                else
                    strSum += inputArray[counter] + "}";
                strCounter++;
            }
            counter++;
        }
        if (inputNumber == sum)
            return true;
        else
            return false;
    }
    var boolArrayFirstBranch = new bool[boolArray.Length];
    boolArray.CopyTo(boolArrayFirstBranch, 0);
    boolArrayFirstBranch[position] = true;
    var boolArraySecondBranch = new bool[boolArray.Length];
    boolArray.CopyTo(boolArraySecondBranch, 0);
    boolArraySecondBranch[position] = false;
    return checkSetOfNumbers(inputNumber, boolArrayFirstBranch,inputArray, position, ref strSum) || checkSetOfNumbers(inputNumber, boolArraySecondBranch, inputArray, position, ref strSum);
}

//функция без отслеживания набора чисел входящих в сумму
bool checkSetOfNumbersShort(int inputNumber, int[] inputArray,int sum, int position)
{
    position++;
    if (position == inputArray.Length)
    {
        if(sum == inputNumber)
            return true;
        else
            return false;
    }
    return checkSetOfNumbersShort(inputNumber, inputArray,sum+inputArray[position], position) || checkSetOfNumbersShort(inputNumber, inputArray,sum, position);
}