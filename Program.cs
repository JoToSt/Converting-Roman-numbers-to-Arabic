using System;

namespace ConvertingArabicToRoman
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
                        Console.WriteLine("TO nie jest znak liczb rzymskich!!!");
                    break;
                }
                i++;
                if (i < len)
                    ch = Roman[i];  // sprawdzanie czy nie wyszlismy poza zakres stringu z l. rzymskimi
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
            Random generator = new Random();    //  random number generator
            int points = 0;

            Console.BackgroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine(" You  will  get 10 random  arabic  numbers  to  convert\n\n\n");
            Console.WriteLine(" !!!!    P L E A S E    C O N V E R T    A R A B I C  number TO    R O M A N  number     !!!!\n\n");
            Console.ResetColor();
            for (int i = 1; i <= 10; i++)
            {
                ushort arabic = (ushort)generator.Next(1, 4000);   //  grandom number generator from 1 to 3999
                Console.Write(" \n Convert " + arabic + "    into roman number:   ");

                string answer = Console.ReadLine(); //  
                string roman = "";

                while (arabic >= 1000)
                    ar_ro(ref arabic, ref roman, 1000, "M");
                if (arabic >= 900)
                    ar_ro(ref arabic, ref roman, 900, "CM");
                if (arabic >= 500)
                    ar_ro(ref arabic, ref roman, 500, "D");
                if (arabic >= 400)
                    ar_ro(ref arabic, ref roman, 400, "CD");
                while (arabic >= 100)
                    ar_ro(ref arabic, ref roman, 100, "C");
                if (arabic >= 90)
                    ar_ro(ref arabic, ref roman, 90, "XC");
                if (arabic >= 50)
                    ar_ro(ref arabic, ref roman, 50, "L");
                if (arabic >= 40)
                    ar_ro(ref arabic, ref roman, 40, "XL");
                while (arabic >= 10)
                    ar_ro(ref arabic, ref roman, 10, "X");
                if (arabic == 9)
                    ar_ro(ref arabic, ref roman, 9, "IX");
                if (arabic >= 5)
                    ar_ro(ref arabic, ref roman, 5, "V");
                if (arabic == 4)
                    ar_ro(ref arabic, ref roman, 4, "IV");
                while (arabic >= 1)
                    ar_ro(ref arabic, ref roman, 1, "I");

                //  LICZBA RZYMSKA  JEST  JUZ  WYZNACZONA

                if (roman == answer)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("    !!! CONGRATULATIONS     !!!!!!!");
                    Console.ResetColor();
                    points++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("    !!! UNFORTUNATELY   !!!  ");
                    Console.ResetColor();
                    Console.WriteLine("correct Roman number: " + roman);
                }
            }
            Console.WriteLine("\n     You scored  " + points + "  points");

            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(" !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! R Z Y M S K I E    NA   A R A B S K I E    !!!!!!!");
            Console.ResetColor();
            string rzym2 = "MMMCMXCIX";
            Console.WriteLine("LICZBA  RZYMSKA: " + rzym2 + " to liczba arabska = " + ro_ar(rzym2));

            rzym2 = "LXXIX";
            Console.WriteLine("LICZBA  RZYMSKA: " + rzym2 + " to liczba arabska = " + ro_ar(rzym2));

            rzym2 = "MCM";
            Console.WriteLine("LICZBA  RZYMSKA: " + rzym2 + " to liczba arabska = " + ro_ar(rzym2));

            rzym2 = "I";
            Console.WriteLine("LICZBA  RZYMSKA: " + rzym2 + " to liczba arabska = " + ro_ar(rzym2));

        }
    }
}

