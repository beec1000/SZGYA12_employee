using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;




namespace employee
{
    class Program
    {
        static double korAtlag(List<Employee> ave)
        {
            return ave.Average(d => d.Age);
        }




        static int akiBPen(List<Employee> bp)
        {
            return bp.Count(d => d.City == "Budapest");
        }




        static Employee legidosebb(List<Employee> l)
        {
            return l.OrderByDescending(e => e.Age).FirstOrDefault();
        }


        static (bool, string) otvenEvFeletti(List<Employee> f)
        {
            var otvenFelett = f.Any(e => e.Age > 50);
            var nev = otvenFelett ? f.First(e => e.Age > 50).Name : "N/A";
            return (otvenFelett, nev);
        }
        static int SzamoljAtEsValtsAt(Employee a)
        {
            int honapFizetesEuro = a.Salary;
            int eviFizetesEuro = SzamolEvFizetest(honapFizetesEuro);
            int eviFizetesHuf = AtvaltForintba(eviFizetesEuro);


            return eviFizetesHuf;
        }




        static int SzamolEvFizetest(int honapFizetesEuro)
        {
            return honapFizetesEuro * 12;
        }




        static int AtvaltForintba(int euroOsszeg)
        {
            //Tetszőleges átváltási árfolyam
            double arfolyam = 355.0;
            return (int)(euroOsszeg * arfolyam);
        }


        static string LegfiatalabbesLegidosebb(List<Employee> d)
        {
            var f13li = d.OrderByDescending(l => l.Age).Last();
            var f13lf = d.OrderByDescending(l => l.Age).First();


            var f13adatok = f13li.Name + f13li.Age + f13lf.Name + f13lf.Age;


            return f13adatok;
        }
        static void F15(EmployeeF15 a)
        {


        }

        static double fizetesAtlag(List<Employee> a)
        {
            var atlag = a.Average(ave => ave.Salary);
            return atlag;
        }

        //Készíts egy függvényt, amelynek visszatérési értéke egy objektumokat tartalmazó lista, amelyben szerepel az 5 millió forint éves fizetés feletti munkavállalók neve és az éves fizetésük forintban. (Az átszámításhoz használd az előző feladat függvényét.)  Az elkészült listát a főprogram írja ki egy új fájlba(a virtuális metódus segítségével)


        static void Main(string[] args)
        {
            //Az alábbiakban egy feladatsort kell megoldanod, ami alkalmazottak adatait tartalmazza.
            //A forrás fájlban a mezők jelentése: name, age, city, department, position, gender, marital status, salary (EUR)
            //1. Készíts egy osztályt, amely tartalmazza a szükséges mezőket.Nem kötelező kidolgozni a property - ket.
            //2. Írd meg a konstruktort.
            //3. Készíts egy osztályon belüli virtuális metódust az adatok kiírására.
            //4. Propertyk kidolgozása(Szorgalmi feladat)
            //Dolgozd ki a property-ket is, és használd őket az adatokhoz való korrekt hozzáférésre és módosításra.
            //5. Hibakezelés(Szorgalmi feladat)
            //Implementálj hibakezelést az alkalmazásban, például az adatok beolvasásakor vagy a fájlba írás során.
            //6. Az osztály segítségével hozz létre egy listát, amely objektumpéldányokat tartalmaz a forrásfájlból beolvasott adatokkal.
            Console.WriteLine("6. feladat");

            var dolgozok = new List<Employee>();
            foreach (var i in File.ReadAllLines(@"..\..\..\src\employeedata.txt"))
            {
                dolgozok.Add(new Employee(i));
            }

            //7. A virtuális metódus segítségével írd ki az összes adatot.
            //A következő feladatokat a program osztályban elhelyezett statikus metódusokkal oldd meg. (Aki szeret kísérletezni, teheti ezeket a metódusokat egy újabb osztályba.) Egyes feladatokat meg lehet oldani LINQ-val is, de ha belefér az időbe, kódoljátok le hagyományosan is.Ha van olyan feladat, ami nem egyértelmű, pl.az, hogyan kell kiírni, ott rád van bízva a megoldás.
            Console.WriteLine("7. feladat");

            for (int i = 0; i < dolgozok.Count; i++)
            {
                dolgozok[i].kiir();
            }


            //8. Függvény segítségével írd ki az életkorok átlagát.
            Console.WriteLine("8. feladat");

            Console.WriteLine($"Az életkorok átlaga: {korAtlag(dolgozok)}");

            //9. Függvény segítségével írd ki azon személyek számát, akiknek a városa 'Budapest'.
            Console.WriteLine("9. feladat");

            Console.WriteLine(akiBPen(dolgozok));

            //10. Függvény segítségével keresd ki, majd a virtuális metódus segítségével írd ki a legidősebb személy adatait.
            Console.WriteLine("10. feladat");
            var legidosebbDolgozo = legidosebb(dolgozok);
            legidosebbDolgozo.kiir();

            //11. Függvény segítségével döntsd el, majd a főprogramban írd ki, hogy van - e 50 év fölötti személy, és emellett írd ki a nevét is. (Ez a függvény tehát két értéket kell, hogy generáljon, ezt egyetlen szövegként add vissza a főprogramnak, és a főprogram bontsa szét az adatokat, majd utána írja ki.)
            Console.WriteLine("11. feladat");

            var (van50felett, neve) = otvenEvFeletti(dolgozok);
            if (van50felett)
            {
                Console.WriteLine($"Van 50 év feletti személy: {neve}");
            }
            else
            {
                Console.WriteLine("Nincs 50 év feletti személy.");
            }

            //12. Függvénnyel válogasd ki azon személyek nevét egy új tömbbe(nem listába), akik 30 évnél fiatalabbak. Ennek a tömbnek a hasznos tartalmát írd ki a főprogramban.
            Console.WriteLine("12. feladat");

            string[] tomb = dolgozok.Where(d => d.Age < 30).Select(d => d.Name).ToArray();
            Console.WriteLine("A 30 év alatti dolgozók nevei:");
            foreach (var i in tomb)
            {
                Console.WriteLine(i);
            }

            //13. Egyetlen függvénnyel keresd meg a legfiatalabb és a legidősebb személyt. A függvénynek legyen két olyan paramétere, amiben az eredményt vissza lehet juttatni a főprogramba, és ott ki lehet írni a nevüket és a korukat. A függvény visszatérési értéke pedig képes legyen azt jelezni, hogy van-e több ugyanolyan korú legfiatalabb személy.
            Console.WriteLine("13. feladat");


            var f13li = dolgozok.OrderByDescending(l => l.Age).Last();


            Console.WriteLine($"A legfiatalabb neve: {LegfiatalabbesLegidosebb(dolgozok).Substring(0, 4)}, kora: {LegfiatalabbesLegidosebb(dolgozok).Substring(4, 2)} " +
                $"\nA legidősebb neve: {LegfiatalabbesLegidosebb(dolgozok).Substring(6, 5)}, kora: {LegfiatalabbesLegidosebb(dolgozok).Substring(11, 2)}");


            //14. Készíts egy függvényt, ami átszámolja az euróban megadott havi fizetést éves fizetéssé, és az eredményt még váltsd át magyar forintba is.
            Console.WriteLine("14. feladat");


            //SzamoljAtEsValtsAt()


            //15. Készíts egy függvényt, amelynek visszatérési értéke egy objektumokat tartalmazó lista, amelyben szerepel az 5 millió forint éves fizetés feletti munkavállalók neve és az éves fizetésük forintban. (Az átszámításhoz használd az előző feladat függvényét.)  Az elkészült listát a főprogram írja ki egy új fájlba (a virtuális metódus segítségével).
            Console.WriteLine("15. feladat");


            //16. Írj egy függvényt, aminek a paramétere az eredeti adatokat tartalmazó listának megfelelő típusú. Ennek segítségével számold ki az összes alkalmazott átlagfizetését.
            Console.WriteLine("16. feladat");

            Console.WriteLine("Az alkalmazottak átlag fizetése: ");

            foreach (var i in dolgozok)
            {
                Console.WriteLine($"{i.Name} átlag fizetése: {fizetesAtlag(i.Salary)}");
            }


            //17. Készíts a főprogramban egy olyan listát, amiben csak a developer beosztásúak találhatók, minden tulajdonságukkal. Hívd meg újra a főprogramból az előző függvényt, de most ez az új lista legyen a paramétere. A főprogram írja ki a developerek átlagfizetését.
            Console.WriteLine("17. feladat");

            var devs = dolgozok.Where(d => d.Position == "Developer");

            var DevLista = new List<Employee>(devs);



            //18. Számold ki a férfi és női alkalmazottak átlagfizetését tetszőleges módszerrel.
            Console.WriteLine("18. feladat");

            var f18m = dolgozok.Where(ave => ave.Gender == "Male").Average(ave => ave.Salary);
            var f18f = dolgozok.Where(ave => ave.Gender == "Female").Average(ave => ave.Salary);

            Console.WriteLine($"A férfi alkalmazottak havi átlagfizetése: {Math.Round(f18m)}EUR");
            Console.WriteLine($"A női alkalmazottak havi átlagfizetése: {Math.Round(f18f)}EUR");

        }

    }
}
