using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrik_Élményfürdő
{
    internal class Program
    {
        static void MenuKiir()
        {
            Console.WriteLine("=== PETRIK ÉLMÉNYFÜRDŐ ===");
            Console.WriteLine();
            Console.WriteLine("1.) Belépőjegy vásárlása");
            Console.WriteLine("2.) Csúszdapark ellenőrzés");
            Console.WriteLine("3.) Éttermi kedvezmény kalkulátor");
            Console.WriteLine("4.) Napi bevétel");
            Console.WriteLine("5.) Kilépés");
            Console.WriteLine();
            Console.Write("Választás: ");
        }

        static string JegyTipus(int eletkor)
        {
            if (eletkor < 6)
            {
                return "Baba jegy";
            }
            else if (eletkor < 14)
            {
                return "Gyerekjegy";
            }
            else if (eletkor < 18)
            {
                return "Diákjegy";
            }
            else if (eletkor < 65)
            {
                return "Felnőttjegy";
            }
            else
            {
                return "Nyugdíjas jegy";
            }
            
        }

        static int JegyAr(int eletkor)
        {
            if (eletkor < 6)
            {
                return 0;
            }
            else if (eletkor < 14)
            {
                return 1800;
            }
            else if (eletkor < 18)
            {
                return 2400;
            }
            else if (eletkor < 65)
            {
                return 3900;
            }
            else
            {
                return 2000;
            }
        }

        static void CsuszdaEllenorzes()
        {
            Console.WriteLine("=== CSÚSZDAPARK ===");
            Console.WriteLine();
            Console.WriteLine("1.) Mini Csúszda");
            Console.WriteLine("2.) Kamikaze");
            Console.WriteLine("3.) Black Hole");
            Console.WriteLine();
            Console.WriteLine("Melyik csúszdát választod: ");

            int valasztas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hány centi magas vagy? ");
            int magassag = Convert.ToInt32(Console.ReadLine());
            switch (valasztas)
            {
                case 1:
                    if (magassag >= 100)
                    {
                        Console.WriteLine("Használhatod a Mini Csúszdát!");
                        
                    }
                    else
                    {
                        Console.WriteLine("Sajnos túl alacsony vagy ehhez a csúszdához!");
                    }
                    break;
                case 2:
                    if (magassag >= 140)
                    {
                        Console.WriteLine("Használhatod a Kamikaze-t!");
                        
                    }
                    else
                    {
                        Console.WriteLine("Sajnos túl alacsony vagy ehhez a csúszdához!");
                    }
                    break;
                case 3:
                    if (magassag >= 120)
                    {
                        Console.WriteLine("Használhatod a Black Hole-t!");
                        
                    }
                    else
                    {
                        Console.WriteLine("Sajnos túl alacsony vagy ehhez a csúszdához!");
                    }
                    break;
                default:
                    Console.WriteLine("Nincs ilyen csúszda");
                    break;
            }
        }

        static int KedvezmenyesAr(int osszeg, int kedvezmeny)
        {
            switch (kedvezmeny)
            {
                case 1:
                    return osszeg;

                case 2:
                    return osszeg - ((osszeg / 100) * 15);

                case 3:
                    return osszeg - ((osszeg / 100) * 20);

                default:
                    return osszeg;

            }
        }

        static void EttermiKalkulator()
        {
            Console.WriteLine("=== ÉTTERMI KEDVEZMÉNY ===");
            Console.WriteLine();
            Console.WriteLine("1.) Nincs kedvezmény");
            Console.WriteLine("2.) Diákkedvezmény");
            Console.WriteLine("3.) Családi kedvezmény");
            Console.WriteLine();

            Console.WriteLine("Eredeti összeg: ");
            int ar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kedvezmény: ");
            int kedvezmeny = Convert.ToInt32(Console.ReadLine());

            if (kedvezmeny == 1 || kedvezmeny == 2 || kedvezmeny == 3)
            {
                int fizetendo = KedvezmenyesAr(ar, kedvezmeny);
                Console.WriteLine();
                Console.WriteLine($"Fizetendő összeg: {KedvezmenyesAr(ar, kedvezmeny)} Ft");
            }
            else
            {
                Console.WriteLine("Nincs ilyen kedvezménytípus!");
            }
        } 




        static void Main(string[] args)
        {
            int bevetel = 0;
            int valasztas = 0;

            do
            {
                Console.Clear();
                MenuKiir();
                try
                {
                    valasztas = Convert.ToInt32(Console.ReadLine());
                    switch (valasztas)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("===BELÉPŐJEGY VÁSÁRLÁSA===");
                            Console.WriteLine();
                            Console.Write("Név: ");
                            string nev = Console.ReadLine();
                            Console.Write("Életkor: ");
                            int eletkor = Convert.ToInt32(Console.ReadLine());

                            if (eletkor < 0 || eletkor > 120)
                            {
                                Console.WriteLine("Hibás életkor!");
                            }
                            else
                            {
                                string jegyTipus = JegyTipus(eletkor);
                                int ar = JegyAr(eletkor);
                                Console.WriteLine();
                                Console.WriteLine($"Szia {nev}!");
                                Console.WriteLine($"Jegytípus: {jegyTipus}");
                                Console.WriteLine($"Fizetendő: {ar}");

                                bevetel += ar;

                            }
                            Console.ReadLine();
                            break;

                        case 2:
                            Console.Clear();
                            CsuszdaEllenorzes();
                            Console.ReadLine();
                            break;

                        case 3:
                            Console.Clear() ;
                            EttermiKalkulator();
                            Console.ReadLine();
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("===NAPI BEVÉTEL===");
                            Console.WriteLine();
                            Console.WriteLine($"A fürdő mai bevétele: {bevetel} Ft");
                            Console.ReadLine();
                            break;

                        case 5:
                            Console.WriteLine("Viszlát!");
                            Console.ReadLine();
                            break;

                        default:
                            Console.WriteLine("Válassz a lehetőségek közül!");
                            Console.ReadLine();
                            break;

                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Hiba! Számot kell megadni!");
                    Console.ReadLine();
                }



            } while (valasztas != 5);





        }
    }
}
