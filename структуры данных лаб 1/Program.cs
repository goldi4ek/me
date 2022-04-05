using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace Console_Lab1
{
class Program
    {
        static void Generate_matrix(int width, int[]arr)
        {
            Random random = new Random();

            for (int i = 0; i < width; i++)
            {
                arr[i] = random.Next(1000);
            }
        }
        static void Output_matrix(int width, int[] arr)
        {
            Console.WriteLine("Your matrix is:");
            for (int i = 0; i < width; i++)
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
            Console.WriteLine($"Time Spent for find:{sw.ElapsedMilliseconds} ");

            Console.ReadKey();
            sw.Restart();
            Choose(width, arr);
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
            var sw = new Stopwatch();
            int choose;
            Console.WriteLine("Binare search work only with sotrted matrix");
            Console.WriteLine("Need to sort?");
            Console.WriteLine("Yes - 1");
            Console.WriteLine("No  - 2");

            choose = int.Parse(Console.ReadLine());
            if (choose == 1)
            {
                Console.WriteLine("Let's sort it:");
                Console.WriteLine(" ");
                sw.Start();
                Sort(0, width, arr);
                sw.Stop();
                Output_matrix(width, arr);
                Console.WriteLine($"Time Spent for sort: {sw.ElapsedMilliseconds} ");
            } 
            
            
            int target;
            Console.WriteLine(" ");
            Console.WriteLine("Write elemetn which you need to find:");
            target = int.Parse(Console.ReadLine());
            sw.Start();
            int i = Binare_work(width, arr, target);
            sw.Stop();
            if (i == -1) Console.WriteLine("No element in matrix");
            else
            {
                Console.WriteLine("Index of " + target + " = " + i);
            }
            Console.WriteLine($"Time Spent for sort + find: {sw.ElapsedMilliseconds} ");

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

            int choose; 
            Console.WriteLine("Binare search with gold cut work only with sotrted matrix");
            Console.WriteLine("Need to sort?");
            Console.WriteLine("Yes - 1");
            Console.WriteLine("No  - 2");

            choose = int.Parse(Console.ReadLine());
            if (choose == 1)
            {
                Console.WriteLine("Let's sort it:");
                Console.WriteLine(" ");
                sw.Start();
                Sort(0, width, arr);
                sw.Stop();
                Output_matrix(width, arr);
                Console.WriteLine($"Time Spent for sort: {sw.ElapsedMilliseconds} ");
            }

            int target;
            Console.WriteLine(" ");
            Console.WriteLine("Write element which you need to find:");
            target = int.Parse(Console.ReadLine());

            sw.Start();
            int i = Gold_work(width, arr, target);
            sw.Stop();
            if (i == -1) Console.WriteLine("No element in matrix");
            else
            {
                Console.WriteLine("Index of " + target + " = " + i);
            }
            Console.WriteLine($"Time Spent for sort + find: {sw.ElapsedMilliseconds} ");

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
            Console.WriteLine($"Time Spent for find: {sw.ElapsedMilliseconds} ");

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
            Console.WriteLine("Sort method choose:");
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

        static void generate_string(LinkedList<int> list, int width)
        {
            Random random = new Random();
            list.AddFirst(random.Next(1000));
            for (int i=0; i<width; i++)
            {
                list.AddLast(random.Next(1000));
            }
        }
        static void Linear_string()
        {
            Console.Clear();
            LinkedList<int> list = new LinkedList<int>();
            Console.WriteLine("Enter width of list");
            int width = int.Parse(Console.ReadLine());
            generate_string(list, width);

            Console.WriteLine();
        }
        
        static void Main()
        {
          

            Console.WriteLine("If you want to work with linear matrix enter 1;");
            Console.WriteLine("If you want to work with linear string enter 2;");
            int choose;
            choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1: Matrix(); break;
                case 2: Linear_string(); break;
                default: break;
            }
         
        }
    }
}
