using System;
using System.IO;
using System.Threading;

namespace WriteMap
{
    class Program
    {
        static private int X = 0;
        static private int Y = 0;

        static private int Xpos = 0;
        static private int Ypos = 0;

        static private bool ActiveX = false;

        static ConsoleKey cki;

        static void Main(string[] args)
        {

            cki = Console.ReadKey(true).Key;

            do
            {
                Update();

                Console.Clear();

                Write();

                Thread.Sleep(100);

            } while (true);
        }

        static void Update()
        {
            if (Console.KeyAvailable)
            {
                cki = Console.ReadKey(true).Key;
            }

            if (ActiveX)
            {
                Console.SetCursorPosition(Xpos, Ypos);
                Console.Write("X");
            }

            if (cki == ConsoleKey.W)
            {
                Y--;
            }
            else if (cki == ConsoleKey.S)
            {
                Y++;
            }
            else if (cki == ConsoleKey.D)
            {
                X++;
            }
            else if (cki == ConsoleKey.A)
            {
                X--;
            }
            else if (cki == ConsoleKey.Spacebar)
            {
                ActiveX = true;
                Xpos = X;
                Ypos = Y;
            }
            else if (cki == ConsoleKey.Escape)
            {
                WriteFile();
                Environment.Exit(0);
            }

            cki = ConsoleKey.J;
        }

        static void Write()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("P");
        }

        static void WriteFile()
        {
            FileStream fs = File.OpenWrite("example.dat");

            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(Xpos);
            bw.Write(Ypos);

            bw.Close();
            fs.Close();
        }
    }
}
