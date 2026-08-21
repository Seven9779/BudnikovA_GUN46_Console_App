class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Please input two numbers for bit operations");
        Console.WriteLine("First number: ");
        if (!int.TryParse(Console.ReadLine(), out int a)) 
        {
            Console.WriteLine("Incorrect. Please enter number");
            return;
        }
       

        Console.WriteLine("Second number: ");
        if (!int.TryParse(Console.ReadLine(), out int b)) 
        {
            Console.WriteLine("Incorrect. Please enter number");
            return;
        }


        Console.WriteLine("Enter operation (&, |, ^): ");
        if (!char.TryParse(Console.ReadLine(), out char c)) 
        {
            return;
        }

        if(!TryBitOperation(a, b, c, out int result)) 
        {
            return;
        }

        Console.WriteLine("\nResult\n");
        Console.WriteLine($"decimal: {result}");
        Console.WriteLine($"binary: {result:b8}");
        Console.WriteLine($"hexadecimal: {result:X}");


    }



    static bool TryBitOperation(int a, int b, char op, out int result)
    {
        switch (op)
        {
            case '&':
                 result = a & b;
                return true;
            case '|':
                result = a | b;
                return true;
            case '^':
                result = a ^ b;
                return true;
            default:
                Console.WriteLine("Incorrect, please try again. Valid operation - (&, |, ^)");
                result = 0;
                return false;   
        }
    }

}



  



