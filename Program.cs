class Program
{

    static void Main(string[] args)
    {
        int result = 0;
        if (int.TryParse(Console.ReadLine(), out int a) && int.TryParse(Console.ReadLine(), out int b))
        {
            Console.WriteLine("Valid operation & | ^");
            switch (Console.ReadLine())
            {
                case "&":
                    result = a & b;
                    break;
                case "|":
                    result = a | b;
                    break;
                case "^":
                    result = a ^ b;
                    break;

                default:
                    Console.WriteLine("Invalid input, please try again. Valid operation - &, |, ^");
                    return;

            }
        }

        else
        {
            Console.WriteLine("Invalid Input. Please enter a number");
            return;
        }

        Console.WriteLine("\nCorrect\n");
        Console.WriteLine($"decimal {result}");
        Console.WriteLine($"binary {result:b8}");
        Console.WriteLine($"hexadecimal {result:X}");


    }
}


