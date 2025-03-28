﻿namespace Task1;
class Array
{
    //Init private fields
    private double[] _arrayA;
    private double[] _arrayB;
    private double[] _arrayC;
    private double _a;
    private double _b;
    private double _c;
    //Get private double[] fields
    public double[] ArrayA => _arrayA;
    public double[] ArrayB => _arrayB;
    public double[] ArrayC => _arrayC;
    //Get and set private double fields
    public double A
    {
        get { return _a; }
        set { _a = value; }
    }
    public double B
    {
        get { return _b; }
        set { _b = value; }
    }
    public double C
    {
        get { return _c; } 
        set { _c = value; }
    }
    /// <summary>
    /// Constructor
    /// </summary>
    public Array()
    {
        _arrayA = InitArray("A");
        _arrayB = InitArray("B");
        _arrayC = InitArrayC(_arrayA, _arrayB);
    }
    /// <summary>
    /// Initialize Array A or B
    /// </summary>
    double[] InitArray(string name)
    {
        Console.Write($"Write array {name} (Like: 10.2 3 52): ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            throw new Exception("Error: Invalid input!");
        }
        string[] values = input.Split(' ');
        double[] array = System.Array.ConvertAll(values, double.Parse);
        return array;
    }
    /// <summary>
    /// Initialize Array C
    /// </summary>
    double[] InitArrayC(double[] arrayA, double[] arrayB)
    {
        List<double> listB = arrayA.ToList();
        int minBIndex = System.Array.IndexOf(arrayB, arrayB.Min()); //Left minimum index of B
        listB.RemoveRange(0, minBIndex + 1); //Prepared B
        
        Console.Write("Write index for array C: ");
        string? input = Console.ReadLine(); //InputIndex
        if (string.IsNullOrEmpty(input))
        {
            throw new Exception("Error: Invalid input!");
        }
        int inputIndex = int.Parse(input);
        
        List<double> listA = arrayA.ToList();
        int minAIndex = System.Array.LastIndexOf(arrayA, arrayA.Min()); //Right minimum index of A
        if (inputIndex > minAIndex)
        {
            listA = listA.GetRange(minAIndex + 1, inputIndex - 1);
        } else if (inputIndex < minAIndex)
        {
            listA = listA.GetRange(inputIndex + 1, minAIndex - 1);
        }
        else
        {
            return listB.ToArray();
        }
        return listB.Concat(listA).ToArray(); //Return ArrayC
    }
    /// <summary>
    /// The sum of positive elements after the second maximum
    /// </summary>
    public double GroupList(double[] array)
    {
        List<double> temp = array.ToList();
        double fMax = temp.Max(); //First Max
        temp.Remove(fMax);
        double sMax = temp.Max(); //Second Max
        int sMaxIndex = temp.IndexOf(sMax); //Second Max Index
        
        List<double> list = array.ToList();
        list.RemoveRange(0, sMaxIndex + 1); //Delete all left from second max
        List<double> sumList = new List<double>();
        foreach (double element in list)
        {
            if (element > 0) //Sum of all positive
            {
                sumList.Add(element);
            }
        }
        return sumList.Sum();
    }
    /// <summary>
    /// Calculate function
    /// </summary>
    public double Calculate(double a, double b, double c)
    {
        return (2.0 * Math.Sin(a)) + (3.0 * b * Math.Pow(Math.Cos(c), 3)) / (a + b);
    }
}

class Task1
{
    static void Main()
    {
        //Init MyObject
        Array myObject = new Array();
        //Init A, B and C
        myObject.A = myObject.GroupList(myObject.ArrayA);
        myObject.B = myObject.GroupList(myObject.ArrayB) * 2.0;
        myObject.C = myObject.GroupList(myObject.ArrayC) / 2.0;
        //Calculate function
        double result = myObject.Calculate(myObject.A, myObject.B, myObject.C);
        //Print Result
        Console.WriteLine($"Result: {result}");
    }
}