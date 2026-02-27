using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie_1_Zuev
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Peaple> people = new List<Peaple>();


            if (File.Exists("Peaple.txt"))
            {
                using (StreamReader sr = new StreamReader("Peaple.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] parts = line.Split(' ');

                        if (parts.Length >= 5)
                        {
                            people.Add(new Peaple { SurName = parts[0], Name = parts[1], Otchestvo = parts[2], Age = int.Parse(parts[3]), Weight = double.Parse(parts[4]) });
                        }
                    }
                }

                var youngPeople = from p in people
                                  where p.Age < 40
                                  select p;

                Console.WriteLine("Люди младше 40 лет:");
                foreach (var p in youngPeople)
                {
                    Console.WriteLine($"{p.SurName} {p.Name} — {p.Age} лет");
                }
            }
            else
            {
                Console.WriteLine("Файла нет.");
            }

            Console.ReadKey();
        }
    }
}
