using System.Text;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConcatenateStrings("gf", "vbv"));
            Console.WriteLine(GreetUser("qwerty", 87));
            Console.WriteLine(StringInformation("qweasd"));
            Console.WriteLine(FirstFiveCharString("qweasd"));
            Console.WriteLine(MergeSentences(new string[3] { "x", "y", "z" }));
            Console.WriteLine(ReplaceWords("Hello World", "World", "User"));
        }


        public static string ConcatenateStrings(string inputString1, string inputString2)
        {
            return inputString1 + inputString2;
        }

        public static string GreetUser(string name, int age)
        {
            return $"Hello, {name}!\nYou are {age} years old.";
        }

        public static string StringInformation(string inputString)
        {
            return $"Length: {inputString.Length}, Upper: {inputString.ToUpper()}, Lower: {inputString.ToLower()}";
        }

        public static string FirstFiveCharString(string inputString)
        {
            return inputString.Substring(0, 5);
        }

        public static StringBuilder MergeSentences(string[] inputArrayString)
        {
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < inputArrayString.Length; i++)
            {
                sBuilder.Append(inputArrayString[i]);

                if (i < inputArrayString.Length - 1) { sBuilder.Append(" "); }
            }

            return sBuilder;
        }

        public static string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
        {
            return inputString.Replace(wordToReplace, replacementWord);
        }
    }
}


