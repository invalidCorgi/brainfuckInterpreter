using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brainfuckInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length!=1)
            {
                Console.WriteLine("Usage: brainfuckInterpreter.exe <filename>");
                return;
            }

            Stack<int> stack = new Stack<int>();
            char c;
            int ptr = 0;
            int[] registers = new int[512];
            for (int i = 0; i < registers.Length; i++)
            {
                registers[i] = 0;
            }

            StreamReader file = new StreamReader(args[0]);
            string str = file.ReadToEnd();
            file.Close();

            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '>':
                        ptr++;
                        break;
                    case '<':
                        ptr--;
                        break;
                    case '+':
                        registers[ptr]++;
                        break;
                    case '-':
                        registers[ptr]--;
                        break;
                    case ',':
                        registers[ptr] = Console.Read();
                        break;
                    case '.':
                        Console.Write((char)registers[ptr]);
                        break;
                    case '[':
                        if (registers[ptr] != 0)
                            stack.Push(i);
                        else
                        {
                            int nawiasy = 1;
                            while (nawiasy>0)
                            {
                                i++;
                                switch (str[i])
                                {
                                    case '[':
                                        nawiasy++;
                                        break;
                                    case ']':
                                        nawiasy--;
                                        break;
                                }
                            }
                        }
                        break;
                    case ']':
                        i = stack.Pop() - 1;
                        break;
                }
            } 
        }
    }
}
