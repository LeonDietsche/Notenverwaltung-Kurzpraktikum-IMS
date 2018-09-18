using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    class Program
    {


        static void Main(string[] args)
        {



            for (int i = 1; i > 0; i++)
            {
                noteEinlesen(Fach());
               
                
            }

            string Fach()
            {
                Console.WriteLine("Für welches Fach wollen sie die Noten erfassen (mathe) (franz)");
                string Menue = Console.ReadLine();

                if (Menue == "mathe")
                {
                    return "Mathe";
                }
                else if (Menue == "franz")
                {
                    return "Franz";
                }

                else
                {
                    return "";
                }
            }




            void noteEinlesen(string Subject)
            {
                Console.WriteLine("Wollen sie eine Note eingeben (eingeben) oder, das File clearen? (clear)");
                string Auswahl = Console.ReadLine();
                if (Auswahl == "eingeben")
                {
                    string Eingabe = "";
                    Console.Write("Bitte Note eingeben;  ");
                    Eingabe = Console.ReadLine();
                   
                    double EingabeZahl = 0;
                    bool istZahl = double.TryParse(Eingabe, out EingabeZahl);

                    if (EingabeZahl < 1 || EingabeZahl > 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bitte Zahl zwischen 1 und 6 eingeben");
                        Console.ForegroundColor = ConsoleColor.White;

                    }

                    else
                    {
                     
                        using (var NotenWriter = new StreamWriter("C: \\Users\\diets\\Documents\\PraktikumEgeli\\" + Subject + "File.txt", true))
                        {
                            NotenWriter.WriteLine(Eingabe);
                            NotenWriter.Close();

                        }

                        StreamReader dateiLeser = File.OpenText(@"C: \\Users\\diets\\Documents\\PraktikumEgeli\\" + Subject + "File.txt");

                        List<double> werte = new List<double>();

                        while (!dateiLeser.EndOfStream)
                        {

                            werte.Add(Convert.ToDouble(dateiLeser.ReadLine()));
                        }
                        dateiLeser.Close();

                        if (werte.Count != 0)
                        {
                            double average = werte.Average();
                            Console.WriteLine("Dein Durchschnitt von " + Subject + " ist  " + average);
                        }
                        else
                        {
                            Console.WriteLine("Durchschnitt konnte nicht berechnet werden da keine Noten vorhanden ist");
                        }

                    }
                }

                else if (Auswahl == "clear")
                {
                    System.IO.File.WriteAllText(@"C: \\Users\\diets\\Documents\\PraktikumEgeli\" + Subject + "File.txt", string.Empty);

                }

                



                string[] Textlesen = File.ReadAllLines("C: \\Users\\diets\\Documents\\PraktikumEgeli\\" + Subject + "File.txt");

                foreach (var note in Textlesen)
                {
                    Console.WriteLine(note);

                }
                

             

            }

            
        
        





        }





    }
      
        }
    

