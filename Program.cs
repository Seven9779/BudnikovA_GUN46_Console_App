namespace HomeWork
{
    internal class Program
    {
        public static bool IsExit(string input) => input.Equals("exit", StringComparison.OrdinalIgnoreCase);
        private class ListString
        {
            private readonly List<string> _names = new List<string>() { "sss", "aaa" };
            public void TaskLoop()
            {
                while(true) 
                {
                    Console.WriteLine("Task started. Enter exit to quit");
                    Console.WriteLine("Please input a line");
                    string line = Console.ReadLine();

                    if (IsExit(line)) return;

                    _names.Add(line);
                    Console.WriteLine(string.Join("\n", _names));
                    Console.WriteLine("Enter another line to insert in the middle");
                    int middle = _names.Count / 2;
                    line = Console.ReadLine();

                    if (IsExit(line)) return;

                    _names.Insert(middle, line);
                    Console.WriteLine();
                    Console.WriteLine(string.Join("\n", _names));
                }
                
            }         
        }

        private class ListDictionary
        {
            public void TaskLoop()
            {
                Dictionary<string, int> students = new Dictionary<string, int>();

                while (true)
                {
                    Console.WriteLine("Task started. Enter exit to quit");
                    Console.WriteLine("Enter name student");

                    string name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name)) 
                    { 
                        Console.WriteLine("Incorrect Name Student"); 
                        continue; 
                    }

                    if (IsExit(name)) return;
                    Console.WriteLine("Enter grade student - from 2 to 5");

                    string grade = Console.ReadLine();
                    if (IsExit(grade)) return;
                    if (!int.TryParse(grade, out int a) || a < 2 || a > 5)
                    {
                        Console.WriteLine("Incorrect. grade student - from 2 to 5");
                        continue;
                    }


                    if (!students.TryAdd(name, a))
                    {
                        Console.WriteLine("This student already exists");
                    }

                    Console.WriteLine("Enter student name to find");

                    string result = Console.ReadLine();
                    if (string.IsNullOrEmpty(result))
                    {
                        Console.WriteLine("Incorrect Name Student");
                        continue;
                    }

                    if (IsExit(result)) return;

                    if (students.TryGetValue(result, out int b))
                    {
                        Console.WriteLine($"Name: {result}\nGrade: {b}");
                    }

                    else 
                    { 
                        Console.WriteLine("Incorrect input, this student doesn't exist");
                        continue;
                    }  
                }
            }
        }

        private class LinkedListTask
        {
            Node _tail;
            Node _head;
            private class Node
            {
                public Node(string data)
                {
                    Data = data;
                }

                public Node Next { get; set; }

                public Node Previous { get; set; }
                public string Data { get; set; }
            }

            public void TaskLoop()
            {

               
                Console.WriteLine("Task started. Enter exit to quit");
                Console.WriteLine("How many elements do you want to input? (3–6))");
                var result = Console.ReadLine();
                if(IsExit(result)) return;
                if (!int.TryParse(result, out int a) || a < 3 || a > 6)
                {
                    Console.WriteLine("Incorrect input. Min 3 elements, max 6 elements");
                    return;
                }

                for (int i = 0; i < a; i++)
                {
                    AddNode(Console.ReadLine());
                }
                Node current = _head;

                Console.WriteLine("\nList");

                while(current != null) 
                {
                    Console.WriteLine($"Node: {current.Data}");
                    if (current.Next != null) { Console.WriteLine($" Node Next:  {current.Next.Data}"); }
                    else { Console.WriteLine($"Node  {current.Data} does not have Next"); }
                    current = current.Next;
                }

                Console.WriteLine("\nReverse List");

                current = _tail;
                while (current != null)
                {
                    Console.WriteLine($"Node: {current.Data}");
                    if (current.Previous != null) { Console.WriteLine($" Node Previous:  {current.Previous.Data}"); }
                    else { Console.WriteLine($"Node  {current.Data} does not have Previous"); }
                    current = current.Previous;
                }

            }

            public void AddNode(string data)
            {
                Node node = new Node(data);

                if (_head == null)
                    _head = node;
                else
                {
                    _tail.Next = node;
                    node.Previous = _tail;
                }
                _tail = node;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1,2 or 3 to check task 1,2 or 3");
            Console.WriteLine("Or enter exit to quit");
            string input = Console.ReadLine();
            if(IsExit(input)) return;
            if (int.TryParse(input, out int task))
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

