class Program 
{
    static void Main(string[] args)
    {
        string input;

        // cycle 1
        int[] fibonacci = new int[10] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };
        
        for (int i = 0; i < fibonacci.Length; i++)
        {
            Console.WriteLine(fibonacci[i] + "\n");
        }

        Console.WriteLine("--------\n");
        // cycle 2
        for (int i = 1; i <= 20; i++) 
        {
            if(i%2 == 0)
            Console.WriteLine(i + "\n");
        }
        Console.WriteLine("--------\n");
        //cycle 3

        for (int i = 1; i <= 5; i++)
        { 
            Console.WriteLine();
            for (int j = 1; j <= 10; j++)
            {
                Console.Write(i*j+" ");
            }
        }
        Console.WriteLine("\n--------\n");
        // cycle 4

        do 
        {
            Console.WriteLine("Please input password");
            input = Console.ReadLine();
            if (input != "qwerty") { Console.WriteLine("Wrong Password"); }
           
        } while (input != "qwerty");
            
        

    }
}