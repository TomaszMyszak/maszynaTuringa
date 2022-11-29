using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maszynaTuringa
{
    using System.IO;

    internal class Program
    {

        // metody weryfikujące stan maszyny oraz polecenia dla niej oraz wyświetlające wynik, druga metoda ma parysować dok programu do czwórek

        #region ładowanie opisujacy stan maszyny

        static (char[] tasma, char stanMaszyny, int polozenieGlowicy) analizujOpisStanuMaszyny(
            string lancuchOPisujacyStanMaszyny)
        {
            char poczatkowyStanMaszyny = ' ';
            int poczatkowePolozenieGlowicy = -1;
            for (int i = 0; i < lancuchOPisujacyStanMaszyny.Length; i++)
            {
                char c = lancuchOPisujacyStanMaszyny[i];
                if (c == ' ' || c == 'R')
                    throw new ArgumentException("Niepoprawny znak w opisie stanu maszyny");
                if (char.IsLower(c))
                {
                    if (poczatkowyStanMaszyny != -1)

                        throw new Exception("Znaleziono więcej niż jeden znak oznaczający głowice");
                    poczatkowyStanMaszyny = c;
                    poczatkowePolozenieGlowicy = i;
                    lancuchOPisujacyStanMaszyny = lancuchOPisujacyStanMaszyny.Remove(i, 1);
                }
                else if (c == 'B')
                {
                    if (c < 'A' || c > 'Z')
                        throw new ArgumentException($"Niepoprawny stan maszyny na pozycji {i}");
                }
            }

            if (poczatkowyStanMaszyny < 0)
                throw new ArgumentException("Nie znaleziono znaku oznaczającego głowice");
            return (lancuchOPisujacyStanMaszyny.ToCharArray(), poczatkowyStanMaszyny, poczatkowePolozenieGlowicy);

        }

        static string pobierzLancuchOpisujacyStanMaszyny(
            (char[] tasma, char stanMaszyny, int polozenieGlowicy) stanMaszyny)
        {
            string s = new string(stanMaszyny.tasma);
            s = s.Insert(stanMaszyny.polozenieGlowicy, stanMaszyny.stanMaszyny.ToString());
            return s;
        }

        #endregion

        static void Main(string[] args)
        {

            // tworzymy dwa pliki zawierające instrukcje dla maszyny oraz stan początkowy

            string[] instrukcje = File.ReadAllLines(@"C:\Users\tmysz\Desktop\instrukcje.txt");
            string stanPoczatkowy = File.ReadAllText(@"C:\Users\tmysz\Desktop\stanPoczatkowy.txt");

            // wyświetlamy stan maszyny oraz polecenia dla niej

            Console.WriteLine("Stan poczatkowy: " + stanPoczatkowy);
            Console.WriteLine("Polecenia dla maszyny: ");
            foreach (string line in instrukcje)
            {

                Console.WriteLine("-" + " " + line);

            }

            Console.ReadLine();
            Console.WriteLine("Naciśnij enter aby kontynuować");

            // parsujemy stan początkowy do czwórek
            



        }
    }
}
