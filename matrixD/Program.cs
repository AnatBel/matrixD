using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixD
{
    class Program
    {
        /// <summary>
        /// Safely Get int from kb
        /// </summary>
        /// <returns>int number only</returns>
        static void ReadInt(ref int number)
        {
            string str = null;
            while (!int.TryParse(str, out number))
            {
                str = Console.ReadLine();
            }
            
        }

        static void Main(string[] args)
        {
            Console.Write("Input size of your matrix\nrows:");
            int rows=0; 
            ReadInt(ref rows);
            Console.Write("columns:");
            int columns=0;
            ReadInt(ref columns);
            int[,] mmtr = new int[rows, columns];
            Console.WriteLine("select how do u wanna fill matrix");
            Console.WriteLine("vs-vertical snake");
            Console.WriteLine("hs-horizontal snake");
            Console.WriteLine("s-simple");
            Console.WriteLine("rnd-random");
            Console.Write("your choise:");
            string select = Console.ReadLine().ToLower();
            switch (select)
            {
                case "s": mmtr = SimpleFill(rows, columns); break;
                case "vs": mmtr = VerticalSnakeFill(rows, columns); break;
                case "hs": mmtr = HorisontalSnakeFill(rows, columns); break;
                case "rnd": mmtr = RandomFill(rows, columns); break;
                default: Console.WriteLine("error"); break;
            }

            PrintMatrix(mmtr);
            Console.Write("do u wanna sort array?y/n>");
            select = Console.ReadLine().ToLower();
            if (select=="y")
            {
                SortMatrix(ref mmtr);
                PrintMatrix(mmtr);
            }
            Console.ReadKey();

        }

        /// <summary>
        /// Sorting matrix from lowest to highest
        /// </summary>
        /// <param name="mtrx"></param>
        public static void SortMatrix(ref int[,] mtrx)
        {
            //transform matrix to line array
            int k = 0;
            int[] tmtr = new int[mtrx.Length];
            for (int i = 0; i < mtrx.GetLength(0); i++)
			{
                for (int j = 0; j < mtrx.GetLength(1); j++)
                {
                    tmtr[k++] = mtrx[i, j];
                }			 
			}
            //sort
            MyQuickSort(tmtr,0,tmtr.Length-1);
            //back to matrix
            k = 0;
            //sorted
         
            Console.Write("sorted ");
            for (int i = 0; i < mtrx.GetLength(0); i++)
            {
                for (int j = 0; j < mtrx.GetLength(1); j++)
                {
                    mtrx[i, j] = tmtr[k++];
                }
            }
        }


        public static int Part(int[] mtr, int start, int end)
        {
             int marker = start;//divides left and right subarrays
            for (int i = start; i <= end; i++)
            {
                if (mtr[i] < mtr[end]) //array[end] is pivot
                {
                    Swap(ref mtr[marker], ref mtr[i]);
                    marker++;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            Swap(ref mtr[marker], ref mtr[end]);
            
            return marker;
        }

        public static void MyQuickSort(int[] mtr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Part(mtr, start, end);
            MyQuickSort(mtr, start, pivot - 1);
            MyQuickSort(mtr, pivot + 1, end);
        }

        /// <summary>
        /// Swap 2 numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;

        }
        
        /// <summary>
        /// Output matrix
        /// </summary>
        /// <param name="mmtr"></param>
        public static void PrintMatrix(int[,] mmtr)
        {
            //print matrix
            Console.WriteLine("matrix:");
            for (int i = 0; i < mmtr.GetLength(0); i++)
            {
                for (int j = 0; j < mmtr.GetLength(1); j++)
                {
                    Console.Write("{0}\t", mmtr[i, j]);
                }
                Console.Write("\n");
            }
            Console.WriteLine("end;");

        }

        /// <summary>
        /// Filling matrix by vertical snake
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static int[,] VerticalSnakeFill(int row, int col)
        {
            int[,] mmtr = new int[row, col];
            //fill by veertical snake
            Console.WriteLine("Vertical Snake fill");
            for (int j = 0; j < mmtr.GetLength(1); j++)
            {
                //if even column
                if (j % 2 == 0)
                {
                    for (int i = 0; i < mmtr.GetLength(0); i++)
                    {
                        Console.Write("mmtr[{0},{1}]=", i, j);
                        ReadInt(ref mmtr[i, j]); ;
                    }
                }
                else //if odd column
                {
                    for (int i = mmtr.GetLength(0) - 1; i >= 0; i--)
                    {
                        Console.Write("mmtr[{0},{1}]=", i, j);
                        ReadInt(ref mmtr[i, j]); ;
                    }
                }
            }

            return mmtr;
        }

        /// <summary>
        /// Filling matrix by horizontal snake
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static int[,] HorisontalSnakeFill(int row, int col)
        {
            int[,] mmtr = new int[row, col];
            //fill by horizontal snake
            Console.WriteLine("Horisontal Snake fill:");
            for (int i = 0; i < mmtr.GetLength(0); i++)
            {
                //if even row
                if (i % 2 == 0) for (int j = 0; j < mmtr.GetLength(1); j++)
                    {
                        Console.Write("mmtr[{0},{1}]=", i, j);
                        ReadInt(ref mmtr[i, j]); ;
                    }
                else //if odd row
                    for (int j = mmtr.GetLength(1) - 1; j >= 0; j--)
                    {
                        Console.Write("mmtr[{0},{1}]=", i, j);
                        ReadInt(ref mmtr[i, j]); ;
                    }
            }

            return mmtr;
        }

        /// <summary>
        /// Filling matrix by rows(simple fill)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static int[,] SimpleFill(int row, int col)
        {
            //simple fill by rows
            int[,] mmtr = new int[row, col];
            Console.WriteLine("Simple fill by rows:");
            for (int i = 0; i < mmtr.GetLength(0); i++)
            {
                for (int j = 0; j < mmtr.GetLength(1); j++)
                {
                    Console.Write("mmtr[{0},{1}]=", i, j);
                    ReadInt(ref mmtr[i, j]); ;
                }
            }

            return mmtr;
        }

        /// <summary>
        /// Filling matrix by random numbers
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static int[,] RandomFill(int row, int col)
        {
            Random rnd = new Random();
            int[,] mmtr = new int[row, col];
            Console.WriteLine("fill by random:");
            for (int i = 0; i < mmtr.GetLength(0); i++)
            {
                for (int j = 0; j < mmtr.GetLength(1); j++)
                {
                    mmtr[i, j] = rnd.Next(-100, 100);
                }
            }
            Console.WriteLine("Filled");

            return mmtr;
        }              
    }
}
