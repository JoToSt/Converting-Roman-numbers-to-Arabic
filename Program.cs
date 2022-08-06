using System;

namespace ConvertingRomanToArabic
{
    

    class Program
    {
        static public void ar_ro(ref ushort licz, ref string rom, ushort war_let, string lett)
        {
            licz -= war_let;
            rom += lett;
        }

        //  function which converts Roman number to Arabic
        static ushort ro_ar(string Roman)
        {
            ushort Arabic = 0;
            char ch = Roman[0];
            byte i = 0;
            byte len = (byte)Roman.Length;
            while (i < len)
            {
                switch (ch)
                {
                    case 'I':
                        if 
                        if ((i + 1 < len) && (Roman[i + 1] == 'X')) { Arabic += 9; i++; }
                        else if ((i + 1 < len) && (Roman[i + 1] == 'V')) { Arabic += 4; i++; }
                        else Arabic += 1;
                        break;
                    case 'V':
                        Arabic += 5;
                        break;
                    case 'X':
                        if ((i + 1 < len) && (Roman[i + 1] == 'C')) { Arabic += 90; i++; }
                        else if ((i + 1 < len) && (Roman[i + 1] == 'L')) { Arabic += 40; i++; }
                        else Arabic += 10;
                        break;
                    case 'L':
                        Arabic += 50;
                        break;
                    case 'C':
                        if ((i + 1 < len) && (Roman[i + 1] == 'M')) { Arabic += 900; i++; }
                        else if ((i + 1 < len) && (Roman[i + 1] == 'D')) { Arabic += 400; i++; }
                        else Arabic += 100;
                        break;
                    case 'D':
                        Arabic += 500;
                        break;
                    case 'M':
                        Arabic += 1000;
                        break;
                    default:
                        Console.WriteLine("THIS is not a sign of Roman numbers!!!");
                        break;
                }
                i++;
                if (i < len)
                    ch = Roman[i];  // checking whether we have gone beyond the range of the string of  Roman number
            }   
            return Arabic;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("  \n");
            Console.WriteLine("     I  -     1                        V  -  5    ");
            Console.WriteLine("     X  -    10                        L -  50     ");
            Console.WriteLine("     C  -   100                        D - 500    ");
            Console.WriteLine("     M  -  1000              ");
            Console.WriteLine("\n ");
           
            int points = 0;

            Console.BackgroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine(" You  will  get 10 roman  numbers  to  convert");
            Console.WriteLine(" !!!!    P L E A S E    C O N V E R T    R O M A N  number TO    A R A B I C  number     !!!!\n");
            Console.ResetColor();

            List<string> Roman_to_convert = new List<string> { "MMMCMXCIX", "LXXIX", "MMI","MMXLIX", 
                "MCM", "MMCMI", "DCCCXL","CMXCIX",  "MMMCCCXXXIII", "CXXV"};

            int l = 1;
            foreach(var it in Roman_to_convert)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n "+ l++ + " / " + Roman_to_convert.Count + "  ");
                Console.ResetColor(); 
                
                Console.Write("  Convert " + it + "    into arabic number:   ");

                ushort answer = ushort.Parse(Console.ReadLine()) ; //  

                ushort arabic = (ro_ar(it));

                if (arabic == answer)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("    !!! CONGRATULATIONS     !!!!!!!");
                    Console.ResetColor();
                    points++;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("    !!! UNFORTUNATELY   !!!  ");
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("correct Arabic number: " + arabic);
                    Console.ResetColor();
                }
            }
            Console.WriteLine("\n     You scored  " + points + "  points");

            Console.ReadKey();
        }
    }
}

