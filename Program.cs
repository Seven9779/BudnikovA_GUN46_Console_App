namespace HomeWork
{
    internal class Program
    {
        public static bool InputOrExit(string input) { return input == "exit"; }
        private class ListString
        {
            private readonly List<string> list = new List<string>() { "sss", "aaa" };
            public void TaskLoop()
            {
                Console.WriteLine("Task started. Enter exit to quit");
                Console.WriteLine("Please input a line");
                string line = Console.ReadLine();

                if (InputOrExit(line)) return;

                list.Add(line);
                Console.WriteLine(string.Join("\n", list));
                Console.WriteLine("Enter another line to insert in the middle");
                int middle = list.Count / 2;
                line = Console.ReadLine();

                if (InputOrExit(line)) return; 

                list.Insert(middle, line);
                Console.WriteLine("\n");
                Console.WriteLine(string.Join("\n", list));
            }         
        }

        private class ListDictionary
        {
            public void TaskLoop()
            {
                Console.WriteLine("Task started. Enter exit to quit");
                Dictionary<string, int> students = new Dictionary<string, int>();
                Console.WriteLine("Enter name student");
                string name = Console.ReadLine();
                if (InputOrExit(name)) return;
                students.Add(name, 0);


                Console.WriteLine("Enter grade student - from 2 to 5");
                string grade = Console.ReadLine();
                if (InputOrExit(grade)) return;

                if (!int.TryParse(grade, out int a) || a < 2 || a > 5)
                {
                    Console.WriteLine("Incorrect. grade student - from 2 to 5");
                    return;
                }

                students[name] = a;

                Console.WriteLine("Enter name student");

                var result = Console.ReadLine();
                if (InputOrExit(result)) return;
                if (students.ContainsKey(result))
                {
                    Console.WriteLine($"Name: {result}\nGrade: {students[result]}");
                }

                else { Console.WriteLine("Incorrect input, this student doesn't exist"); } 
            }
        }

        private class LinkedListTask
        {
            private class Node
            {
                public Node next;
                public int value;
            }

            public void TaskLoop()
            {
                Console.WriteLine("Task started. Enter exit to quit");
                Console.WriteLine("How elements you want to input? (3-6)");
                var result = Console.ReadLine();
                if(InputOrExit(result)) return;
                if (!int.TryParse(result, out int a) || a < 3 || a > 6)
                {
                    Console.WriteLine("Incorrect input. Min 3 elements, max 6 elements");
                    return;
                }

                List<Node> nodes = Enumerable.Range(0, a).Select(_ => new Node()).ToList();

                for (int i = 0; i < nodes.Count; i++)
                {
                    Console.WriteLine($"Input {i+1} element");
                    result = Console.ReadLine();
                    if (InputOrExit(result)) return;
                    if (int.TryParse(result, out int n))
                    {
                        nodes[i].value = n;
                        if (i + 1 < nodes.Count) nodes[i].next = nodes[i + 1];

                    }
                }

                Console.WriteLine("\nList");

                for (int i = 0; i < nodes.Count; i++)
                {
                    Console.WriteLine($"\nvalue {nodes[i].value}");
                    if (nodes[i].next != null) { Console.WriteLine($"next {nodes[i].next.value}"); }
                }


                Console.WriteLine("\nReverse List");
                nodes.Reverse();

                for (int i = 0; i < nodes.Count; i++)
                {
                    Console.WriteLine($"\nvalue {nodes[i].value}");
                    if (nodes[i].next != null) { Console.WriteLine($"next {nodes[i].next.value}"); }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1,2 or 3 to check task 1,2 or 3");
            if (int.TryParse(Console.ReadLine(), out int task))
            {
                switch (task)
                {
                    case 1:
                        CheckTaskFirst();
                        break;
                    case 2:
                        CheckTaskSecond();
                        break;
                    case 3:
                        CheckTaskThird();
                        break;
                    default: 
                        Console.WriteLine("Incorrect Input, task doesn't exist");
                        break;
                }
            }

            else { Console.WriteLine("Incorrect Input, this is not a number"); }
        }

        private static void CheckTaskFirst()
        {
            var listTask = new ListString();
            listTask.TaskLoop();
        }

        private static void CheckTaskSecond()
        {
            var listTask = new ListDictionary();
            listTask.TaskLoop();
        }

        private static void CheckTaskThird()
        {
            var listTask = new LinkedListTask();
            listTask.TaskLoop();
        }
    }
}

