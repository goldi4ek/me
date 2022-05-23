using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace Console_Lab1
{
    public class Item
    {
        public Item(int dt)
        {
            data = dt;
            next = null;
        }
        public int data;
        public Item next;
    }

    class Program
    {
        #region //Masive start ----------------------------------------------------
        static void Generate_matrix(int width, int[]arr)
        {
            Random random = new Random();

            for (int i = 0; i < width; i++)
            {
                arr[i] = random.Next(10000);
            }
        }
        static void Output_matrix(int width, int[] arr)
        {
            Console.WriteLine("10 midele elements of your matrix is:");
            for (int i = width/2; i < width/2+10; i++)
            {
                if (i % 15 == 0) Console.WriteLine();
                Console.Write(arr[i] + ", ");
            }
        }
        static void Enumeration_search(int width, int[] arr)
        {
            var sw = new Stopwatch();
            int target,i;
            Console.WriteLine("Write elemetn which you need to find:");
            target = int.Parse(Console.ReadLine());

            sw.Start();
            for (i = 0; i < width; i++)
            {
                if (arr[i] == target)
                {
                    Console.WriteLine("Index of " + target + " = " + i);
                    break;
                }
            }
            if (i >= width) Console.WriteLine("No element in matrix");
            sw.Stop();
            Console.WriteLine($"Time Spent for find: {sw.ElapsedTicks} miliseconds");

            Console.ReadKey();
            sw.Restart();
            Choose(width, arr);
        }
        static void ReplaceMatrix(int width, int[] arr, int[] Extra)
        {
            for (int i = 0; i < width; i++)
            {
                Extra[i] = arr[i];
            }
        }

        static int[] Sort(int minel, int maxel, int[] arr)
        {
            if (minel >= maxel) return arr;

            int pivot = getPivot(minel, maxel, arr);

            Sort(minel, pivot - 1, arr);
            Sort(pivot + 1, maxel, arr);

            return arr;

        }

        static int getPivot(int minel, int maxel, int[] arr)
        {

            int pivot = minel - 1;
            for (int i = minel; i <= maxel; i++)
            {
                if (arr[i] < arr[maxel])
                {
                    pivot++;
                    Change(ref arr[pivot], ref arr[i]);
                }
            }
            pivot++;
            Change(ref arr[pivot], ref arr[maxel]);
            return pivot;

        }

        static void Change(ref int left, ref int right)
        {
            int time = left;
            left = right;
            right = time;
        }

        static int Binare_work(int width, int[] arr, int target)
        {
            int midle;
            int left = 0, right = width - 1;
            while (left <= right)
            {
                midle = (left + right) / 2;

                if (arr[midle] == target)
                {
                    return midle;
                }
                else if (arr[midle] < target)
                    left = midle + 1;
                else right = midle - 1;

            }
            return -1;
        }
        static void Binare_search(int width,int[] arr)
        {
            Stopwatch sw = new Stopwatch();
            int[] arrExtra = new int[1000000];
            ReplaceMatrix(width, arr, arrExtra);
            Sort(0, width, arrExtra);

            int target;
            Console.WriteLine(" ");
            Console.WriteLine("Write elemetn which you need to find:");
            target = int.Parse(Console.ReadLine());
            sw.Start();
            int i = Binare_work(width, arrExtra, target);
            sw.Stop();
            if (i == -1) Console.WriteLine("No element in matrix");
            else
            {
                Console.WriteLine("Index of " + target + " = " + i);
            }
            Console.WriteLine($"Time Spent for find: {sw.ElapsedTicks} miliseconds");

            Console.ReadKey();
            sw.Restart();
            Choose(width, arr);
        }

        static int Gold_work(int width, int[] arr, int target)
        {
            int midle;
            int left = 0, right = width - 1;
            midle = ((left + right) * 5) / 8;

            while (left <= right)
            {
                if (arr[midle] == target)
                {
                    return midle;
                }
                else if (arr[midle] < target)
                {
                    left = midle + 1;
                    midle += ((right-left) * 5) / 8;
                }
                else
                {
                    
                    right = midle - 1;
                    midle -= ((right-left) * 5) / 8;
                   
                }
            }
            return -1;
        }
        static void With_goldcut(int width, int[] arr)
        {
            var sw = new Stopwatch();

            int[] arrExtra = new int[1000000];
            
            ReplaceMatrix(width, arr, arrExtra);
            Sort(0, width, arrExtra);

            int target;
            Console.WriteLine(" ");
            Console.WriteLine("Write element which you need to find:");
            target = int.Parse(Console.ReadLine());

            sw.Start();
            int i = Gold_work(width, arrExtra, target);
            sw.Stop();
            if (i == -1) Console.WriteLine("No element in matrix");
            else
            {
                Console.WriteLine("Index of " + target + " = " + i);
            }
            Console.WriteLine($"Time Spent for find: {sw.ElapsedTicks} miliseconds");

            Console.ReadKey();
            sw.Restart();
            Choose(width, arr);
        }

        static void With_barrier(int width, int[] arr)
        {
            var sw = new Stopwatch();

            int target;
            Console.WriteLine(" ");
            Console.WriteLine("Write element which you need to find:");
            target = int.Parse(Console.ReadLine());

            sw.Start();
            arr[width]=target;
            int i = 0;
            while (arr[i] != target) 
                { 
                 i++; 
                }
            if(i>=width) Console.WriteLine("No element in matrix");
            sw.Stop();
            Console.WriteLine("Index of " + target + " = " + i);
            Console.WriteLine($"Time Spent for find: {sw.ElapsedTicks} miliseconds");

            Console.ReadKey();
            sw.Restart();
            Choose(width, arr);
        }

        static void Choose(int width, int[] arr)
        {
            Console.Clear();
            Output_matrix(width, arr);
            Console.WriteLine();
            int choose;
            Console.WriteLine("Find method choose:");
            Console.WriteLine("Enumeration search   - 1");
            Console.WriteLine("Search with barrier  - 2");
            Console.WriteLine("Binare search        - 3");
            Console.WriteLine("Search with gold cut - 4");
            choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1: Enumeration_search(width, arr); break;
                case 2: With_barrier(width, arr); break;
                case 3: Binare_search(width, arr); break;
                case 4: With_goldcut(width, arr); break;
            }
        }
        static void Matrix()
        {
            Console.Clear();
            int[] arr = new int[1000000];


            Console.WriteLine("Enter width of matrix");
            int width= int.Parse(Console.ReadLine());

            Generate_matrix(width, arr);
            Console.WriteLine();

            Choose(width, arr);

        }
        #endregion
        #region//String start -----------------------------------------------------
        static void Linked_list()
        {
            int largeoflist;
            int rangeofvalues;
            Item head;
            Console.Clear();
            Console.WriteLine("\nLinked list");
            Console.WriteLine("Enter width");
            largeoflist = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter range of list");
            rangeofvalues = Convert.ToInt32(Console.ReadLine());
            head = null;
            NumberGenerator(ref head, ref largeoflist, ref rangeofvalues);
            Console.WriteLine("\nGenerated!");
            //Listoutput(head);
            menu();
            //--------------------Меню для лініних звʼязних списків--------------------
            void menu()
            {
                Console.Clear();
                Console.WriteLine("Output list - 0");
                Console.WriteLine("Enumeration search   - 1");
                Console.WriteLine("Search with barrier  - 2");
                Console.WriteLine("Binare search        - 3");
                Console.WriteLine("Binare search with gold cut - 4");
                int key = int.Parse(Console.ReadLine());
                switch (key)
                {
                    case 0: Listoutput(head); menu(); break;
                    case 1: Roughsearch(head, largeoflist); menu(); break;
                    case 2: Searchwithbarrier(head); menu(); break;
                    case 3: sortList(head); StandartBinarySearch(head); menu(); break;
                    case 4: sortList(head); BinarySearchbygoldensection(head); menu(); break;
                    default: Main(); break;
                }
            }
        }
        //                      generate list
        static Item push(Item head, int data)
        {
            Item newItem = new Item(data);
            newItem.next = head;
            head = newItem;
            return head;
        }
        //                      Generating numbers
        static void NumberGenerator(ref Item head, ref int large, ref int range)
        {
            Random aRand = new Random();
            for (int i = 0; i < large; i++)
                head = push(head, (aRand.Next(range)));
        }
        //                      Output
        static void Listoutput(Item head)
        {
            Console.WriteLine("\nЗгенерований список: ");
            Item element = head;
            while (element != null)
            {
                Console.Write(" " + element.data);
                element = element.next;
            }
        }
        //Enumeration search
        static void Roughsearch(Item head, int size)
        {
            Console.WriteLine("\nEnumeration search\n");
            Console.WriteLine("Enter search element");
            int x = Convert.ToInt32(Console.ReadLine());
            Item current = head;
            bool found = false;
            int i = 0;
            var timer = new Stopwatch();
            timer.Start();
            while ((i <= size) && (found == false))
            {
                if (current.data == x)
                {
                    found = true;
                }
                else
                    current = current.next;
            }
            timer.Stop();
            if (found)
                Console.WriteLine("Found !");
            else
                Console.WriteLine("Not found !!!");
            Console.WriteLine("Spent time in miliseconds: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        //Search with barrier
        static void Searchwithbarrier(Item head)
        {
            Console.WriteLine("\nSearch with barrier\n");
            Console.WriteLine("Enter search element");
            int x = Convert.ToInt32(Console.ReadLine());
            Item current = head;
            var timer = new Stopwatch();
            timer.Start();
            while (current.data != x)
                current = current.next;
            timer.Stop();
            if (current.data == x)
                Console.WriteLine("Found !");
            else
                Console.WriteLine("Not found !!!");
            Console.WriteLine("Spent time in miliseconds: " + timer.ElapsedTicks);
            Console.ReadKey();
        }

        //Sorting by inputs порівняння поточного елемента з наступним
        static void sortList(Item head)
        {
            Item current = head, index = null;
            int temp;

            if (head == null)
            {
                return;
            }
            else
            {
                while (current != null)
                {
                    index = current.next;
                    while (index != null)
                    {
                        if (current.data.CompareTo(index.data) > 0)
                        {
                            temp = current.data;
                            current.data = index.data;
                            index.data = temp;
                        }
                        index = index.next;
                    }
                    current = current.next;
                }
            }
        }

        //Searching of midle element
        static Item StandartMiddleItem(Item start, Item last)
        {
            if (start == null)
                return null;
            Item slow = start;
            Item fast = start.next;
            while (fast != last)
            {
                fast = fast.next;
                if (fast != last)
                {
                    slow = slow.next;
                    fast = fast.next;
                }
            }
            return slow;
        }
        //Binare search
        public static void StandartBinarySearch(Item head)
        {
            Console.WriteLine("\nBinare search\n");
            Console.WriteLine("Enter search element");
            int value = Convert.ToInt32(Console.ReadLine());
            Item start = head;
            Item last = null;
            bool searchedvalue = false;
            var timer = new Stopwatch();
            timer.Start();
            do
            {
                Item mid = StandartMiddleItem(start, last);
                if (mid.data == value)
                {
                    searchedvalue = true;
                    break;
                }
                else if (mid.data < value)
                {
                    start = mid.next;
                }
                else
                    last = mid;
            } while (last == null || last != start);
            timer.Stop();

            if (searchedvalue)
                Console.WriteLine("Found !");
            else
                Console.WriteLine("Not found !!!");
            Console.WriteLine("Spent time in miliseconds: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        //Searching of midle element by gold cut
        static Item Middlenodebygoldensection(Item start, Item last)
        {
            if (start == null)
                return null;
            Item slow = start;
            Item fast = start.next;
            while (fast != last)
            {
                fast = fast.next;
                if (fast != last)
                {
                    fast = fast.next;
                    if (fast != last)
                    {
                        fast = fast.next;
                        if (fast != last)
                        {
                            fast = fast.next;
                            if (fast != last)
                            {
                                fast = fast.next;
                                if (fast != last)
                                {
                                    fast = fast.next;
                                    if (fast != last)
                                    {
                                        slow = slow.next;
                                        fast = fast.next;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return slow;
        }
        //Binare search with gold cut
        public static void BinarySearchbygoldensection(Item head)
        {
            Console.WriteLine("\nBinare search with gold cut\n");
            Console.WriteLine("Enter search element");
            int value = Convert.ToInt32(Console.ReadLine());
            Item start = head;
            Item last = null;
            bool searchedvalue = false;
            var timer = new Stopwatch();
            timer.Start();
            do
            {
                Item mid = Middlenodebygoldensection(start, last);
                if (mid.data == value)
                {
                    searchedvalue = true;
                    break;
                }
                else if (mid.data < value)
                {
                    start = mid.next;
                }
                else
                    last = mid;
            } while (last == null || last != start);
            timer.Stop();

            if (searchedvalue)
                Console.WriteLine("Found !");
            else
                Console.WriteLine("Not found !!!");
            Console.WriteLine("Spent time in miliseconds: " + timer.ElapsedTicks);
            Console.ReadKey();
        }
        #endregion
        //Main
        static void Main()
        {
          

            Console.WriteLine("Work with  matrix enter 1;");
            Console.WriteLine("Work with linked list enter 2;");
            int choose;
            choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1: Matrix(); break;
                case 2: Linked_list(); break;
                default: break;
            }
         
        }
    }
}
