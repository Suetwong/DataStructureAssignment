using System;
using static System.Math;

namespace A2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Q1

            Console.WriteLine("Q1");
            Console.ReadLine();

            // create an arraystack with [a][b][c][d][e][_]
            Console.WriteLine("Create a Array Stack list with [a][b][c][d][e][_]");
            ArrayStack arrayStack = new ArrayStack(6, new char[] { 'a', 'b', 'c', 'd', 'e' });
            arrayStack.Print_all();
            Console.ReadLine();

            Console.WriteLine("using Set(1,'r') to modify the 1-th element in constant time");
            arrayStack.Set(1, 'r');
            arrayStack.Print_all();
            Console.ReadLine();

            Console.WriteLine($"using Get(1), a[1] = {arrayStack.Get(1)} in constant time");
            Console.ReadLine();

            Console.WriteLine("Add(0, 'k')");
            arrayStack.Add(0, 'k');

            Console.WriteLine("Remove 3-th element)");
            arrayStack.Remove(3);

            */

            //Q2

            Console.WriteLine("Q2");
            Console.ReadLine();
            
            // Create a empty backing array with size 6
            Console.WriteLine("Create a empty backing array with size 6");
            ArrayStack arrayStack2 = new ArrayStack(6);
            arrayStack2.Print_all(true);

            Console.WriteLine("Add(0, 'b')");
            arrayStack2.Add(0, 'b');

            Console.WriteLine("Add(1, 'r')");
            arrayStack2.Add(1, 'r');

            Console.WriteLine("Add(2, 'e')");
            arrayStack2.Add(2, 'e');

            Console.WriteLine("Add(3, 'd')");
            arrayStack2.Add(3, 'd');

            Console.WriteLine("Add(3, 'a')");
            arrayStack2.Add(3, 'a');

            Console.WriteLine("Add(5, 'f')");
            arrayStack2.Add(5, 'f');

            Console.WriteLine("Add(6, 'a')");
            arrayStack2.Add(6, 'a');

            Console.WriteLine("Add(7, 's')");
            arrayStack2.Add(7, 's');

            Console.WriteLine("Remove 7-th element");
            arrayStack2.Remove(7);

            Console.WriteLine("Remove 4-th element");
            arrayStack2.Remove(4);

            Console.WriteLine("Remove 3-th element");
            arrayStack2.Remove(3);

            Console.WriteLine("Remove 0-th element");
            arrayStack2.Remove(0);

            


        }


        public class ArrayStack
        {
            // a field that storing the actual array 
            private char[] _a;

            // a field that indicating the number of element are storing in the array
            private int _occupancy;

            // a contructor to initialize a empty arraystack with given size 
            public ArrayStack(int size)
            {
                _a = new char[size];
            }

            // a contructor to initialize a arraystack with given array and size
            public ArrayStack(int size, char[] chars)
            {
                _a = new char[size];
                for (int i = 0; i < chars.Length; i++)
                {
                    Set(i, chars[i]);
                }
                _occupancy = chars.Length;
            }

            // a method to get the occupancy
            public int Occupancy()
            {
                return _occupancy;
            }

            // to get the i-th element in the array, time complexity = O(1) 
            public char Get(int i)
            {
                return _a[i];
            }

            // to substitute 'x' for the i-th element, time complexity = O(1) 
            public char Set(int i, char x)
            {
                // move the original i-element to temporay char 'y'
                char y = _a[i];

                // substitute 'x' for the i-th element 
                _a[i] = x;

                if (y == '\0')
                    _occupancy++;

                // return the removed element 'y'
                return y;
            }

            // to insert 'x' at position i
            public void Add(int i, char x)
            {
                // check if the array have enough size to contain one more element
                if (_occupancy + 1 > _a.Length) Resize();

                // shift all element from i-th to the last element 
                // to position index by 1 poition to right
                // move from the last occupied postion(_occupancy) to the insert position(i)
                for (int j = _occupancy; j > i; j--)
                    _a[j] = _a[j - 1];

                // insert the new element 'x' in a[i]
                _a[i] = x;

                // the occupancy added by 1
                _occupancy++;
                Print_all(true);
            }

            // to remove the element from the position i
            public char Remove(int i)
            {
                // store the to-be-removed element 
                char x = _a[i];

                // shift all element from i-th to the last element 
                // to position index by 1 poition to left
                // move from the removed position(i) to the last occupied postion(_occupanct) 
                for (int j = i; j < _occupancy ; j++)
                {
                    _a[j] = '\0';
                    if (j < _occupancy - 1)
                    {
                        _a[j] = _a[j + 1];
                        _a[j + 1] = '\0';
                    }
                }

                // the occupancy reduced by 1
                _occupancy--;

                // the size of the array 
                // if the array size is more than 3-times of occupancy, then shrink the array
                if (_a.Length >= 3 * _occupancy)
                    Resize();

                Print_all(true);

                // return the removed element
                return x;

            }

            // to resize the array to maximum 2 times of occupancy
            private void Resize()
            {
                // check the new array size
                int arraysize = Max(_occupancy * 2, 1);
                // create a new array with new array size
                char[] b = new char[arraysize];

                // move all element from old array to new array
                for (int i = 0; i < _occupancy; i++)
                {
                    b[i] = _a[i];
                }

                // reset the private field array to the new resized array
                _a = b;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Resized the array with new size: {arraysize}");
                Print_all();
                Console.ResetColor();
            }

            // to print out the array _a
            public void Print_all(bool needInput = false)
            {
                // a new line for separation for read easier
                //Console.WriteLine();

                // print out the array
                for (int i = 0; i < _a.Length; i++)
                {
                    // if the array is not occupied, then print out '[_]'
                    if (_a[i] is '\0')
                        Console.Write($"[_]");
                    // else print out the element with square brackets
                    else
                        Console.Write($"[{_a[i]}]");
                }

                // show the occupany 
                Console.Write($"  occupancy = {_occupancy} \n");

                // a flag to trigger an input after print out the array
                if (needInput)
                {
                    Console.ReadLine();
                }
            }
        }

    }




}