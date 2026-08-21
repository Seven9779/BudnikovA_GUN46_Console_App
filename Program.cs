class Program
{
    static void Main(string[] args)
    {
        // SECTION A

        // Array 1
        int[] fibonacci = { 0, 1, 1, 2, 3, 5, 8, 13 };

        // Array 2
        string[] months =
       {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };

        // Array 3
        int[,] matrix = new int[3,3];

        for (int i = 0; i < matrix.GetLength(0); i++) 
        {
            for (int j = 0; j < matrix.GetLength(1); j++) 
            {
                matrix[i, j] = (int)Math.Pow(2+j, 1+i);
            }
        }

        // Array 4
        double[][] jagged =
        {
           new double[5],
           new double[2],
           new double[4]
        };

        for (int i = 0; i < jagged[0].Length; i++)
        {
            jagged[0][i] = i + 1;
        }

        jagged[1][0] = Math.E;
        jagged[1][1] = Math.PI;

        for (int i = 0; i < jagged[2].Length; i++)
        {
            jagged[2][i] = Math.Log10(Math.Pow(10,i));
        }


        // SECTION B

        // Array 5
        int[] array = { 1, 2, 3, 4, 5 };
        int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };
        Array.Copy(array, array2, 3);
        for (int i = 0; i < array2.Length; i++)
        {
            Console.WriteLine(array2[i]);
        }
     
        // Array 6
        string[] sample = { "", "" };
        Array.Resize(ref sample, sample.Length * 2);

        for (int i = 0; i < sample.Length; i++)
        {
            Console.WriteLine(sample[i]);
        }

    
    }
    
}
