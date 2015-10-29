//* Matric Rain Application
//* Niall Curran 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRainApplication
{
    class Matrix
    {
        //Create Console
        static int Counter;
        static Random code = new Random();

        static int Stand = 180; //Standard
        static int High = Stand + 20; //Fast
        static int Med = Stand + 20; //Medium Speed


        static String TextInput = "Arsenal Danger";
        static ConsoleColor NormColor = ConsoleColor.DarkGreen;
        static ConsoleColor HighlightColor = ConsoleColor.Green;
        static ConsoleColor TrimColor = ConsoleColor.Green;



        //Develop Randomised Ascii Characters to create matrix rain
        static char AsciiCharacter
        {
            get
            {
                int T = code.Next(12);

                if (T <= 3)
                    return (char)('$' + code.Next(5));
                else if (T <= 6)
                    return (char)('%' + code.Next(10));
                else if (T <= 9)
                    return (char)('&' + code.Next(12));
                else
                    return (char)(code.Next(33, 155));
            }
        }
        static void Main()
        {

            Console.CursorVisible = false;

            Console.ForegroundColor = NormColor;

            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.SetWindowPosition(0, 0);

            int width, height;
            int[] y;
            Initialize(out width, out height, out y);//Set the cursor Start point

            while (true)
            {

                Counter = Counter + 1;
                UpdateAllColumns(width, height, y);
                if (Counter > (3 * Stand))
                    Counter = 0;

            }
        }
        private static void UpdateAllColumns(int width, int height, int[] y)
        {
            int x;
            if (Counter < Stand)
            {
                for (x = 0; x < width; ++x)
                {
                    if (x % 10 == 1)//This is going to Randomly set up White Location
                        Console.ForegroundColor = TrimColor;
                    else
                        Console.ForegroundColor = HighlightColor;
                    Console.SetCursorPosition(x, y[x]);
                    Console.Write(AsciiCharacter);

                    if (x % 10 == 9)
                        Console.ForegroundColor = TrimColor;
                    else
                        Console.ForegroundColor = NormColor;
                    int temp = y[x] - 2;
                    Console.SetCursorPosition(x, inScreenYPosition(temp, height));
                    Console.Write(AsciiCharacter);

                    int temp1 = y[x] - 20;
                    Console.SetCursorPosition(x, inScreenYPosition(temp1, height));
                    Console.Write(' ');


                    y[x] = inScreenYPosition(y[x] + 1, height);

                }
            }
            else if (Counter > Stand && Counter < High)
            {
                for (x = 0; x < width; ++x)
                {

                    Console.SetCursorPosition(x, y[x]);
                    if (x % 10 == 9)
                        Console.ForegroundColor = TrimColor;
                    else
                        Console.ForegroundColor = NormColor;

                    Console.Write(AsciiCharacter);//Prints the Characters at Fixed locations

                    y[x] = inScreenYPosition(y[x] + 1, height);
                }
            }
           
        }
        public static int inScreenYPosition(int yPosition, int height)
        {
            if (yPosition < 0)//When there is negative value
                return yPosition + height;
            else if (yPosition < height)//Normal 
                return yPosition;
            else// When Cursor goes out of screen autoincrement
                return 0;

        }
        private static void Initialize(out int width, out int height, out int[] y)
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;
            y = new int[width];
            Console.Clear();

            for (int x = 0; x < width; ++x)//Sets Cursor
            {
                y[x] = code.Next(height);
            }
        }

    }
}
