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
            Console.WriteLine("Incorrect. Plese Enter bit operation: ");
            return;
        }

        int? result = BitOperation(a,b,c);

        if(result == null) { return; }


        Console.WriteLine("\nResult\n");
        Console.WriteLine($"decimal: {result}");
        Console.WriteLine($"binary: {result:b8}");
        Console.WriteLine($"hexadecimal: {result:X}");


    }



    static int? BitOperation(int firstNumber, int secondNumber, char bitOperation) 
    {
        switch (bitOperation)
        {
            case '&':
                return firstNumber & secondNumber;
            case '|':
                return firstNumber | secondNumber;
            case '^':
                return firstNumber ^ secondNumber;
            default:
                Console.WriteLine("Incorrect, please try again. Valid operation - (&, |, ^)");
                return null;   
        }
    }

}



  



