using System.IO;
using static System.Console;

namespace tortek
{
    internal class Program
    {
        private static void Main()
        {
            Feladat1();
            Feladat6();
            ReadLine();
        }

        private static void Feladat1()
        {
            Write("1.feladat \nAdja meg a számlálót:  ");
            var szam1 = int.Parse(ReadLine());
            Write("Adja meg a nevezőt:  ");
            var szam2 = int.Parse(ReadLine());
            WriteLine(szam1%szam2 == 0 ? (szam1/szam2).ToString() : "Nem egész");
            Feladat3(szam1, szam2);
        }

        public static int Lnko(int a, int b) => a == b ? a : a < b ? Lnko(a, b - a) : Lnko(a - b, b);
        private static int Lkkt(int a, int b) => a*b/Lnko(a, b);

        private static void Feladat3(int a, int b)
        {
            WriteLine(a + "/" + b + " = " + a/Lnko(a, b) + (b/Lnko(a, b) == 1 ? null : "/" + b/Lnko(a, b)));
            Feladat4(a, b);
        }

        private static void Feladat4(int a, int b)
        {
            Write("4.feladat \nAdjon meg egy számlálót:  ");
            var szam1 = int.Parse(ReadLine());
            Write("Adjon meg egy nevezőt:  ");
            var szam2 = int.Parse(ReadLine());
            WriteLine(Szoroz(a, b, szam1, szam2));
            WriteLine(Feladat5(a, b, szam1, szam2));
        }

        private static string Szoroz(int a, int b, int szam1, int szam2)
            =>
                a + "/" + b + " * " + szam1 + "/" + szam2 + " = " + a*szam1 + "/" + b*szam2 + " = " +
                a*szam1/Lnko(a*szam1, b*szam2) +
                (b*szam2/Lnko(a*szam1, b*szam2) == 1 ? null : "/" + b*szam2/Lnko(a*szam1, b*szam2));

        private static string Feladat5(int szam1, int nev1, int szam2, int nev2)
            =>
                szam1 + "/" + nev1 + " + " + szam2 + "/" + nev2 + " = " + szam1*(Lkkt(nev1, nev2)/nev1) + "/" +
                nev1*(Lkkt(nev1, nev2)/nev1) + " + " + szam2*(Lkkt(nev1, nev2)/nev2) + "/" +
                nev2*(Lkkt(nev1, nev2)/nev2) + " = " +
                ((szam1*(Lkkt(nev1, nev2)/nev1) + szam2*(Lkkt(nev1, nev2)/nev2))%Lkkt(nev1, nev2) == 0
                    ? ((szam1*(Lkkt(nev1, nev2)/nev1) + szam2*(Lkkt(nev1, nev2)/nev2))/Lkkt(nev1, nev2)).ToString()
                    : szam1*(Lkkt(nev1, nev2)/nev1) + szam2*(Lkkt(nev1, nev2)/nev2) + "/" + Lkkt(nev1, nev2));

        private static void Feladat6()
        {
            using (var writer = new StreamWriter("eredmeny.txt"))
            using (var reader = new StreamReader("adat.txt"))
                for (var i = 0; i < 100 && !reader.EndOfStream; i++)
                {
                    var sor = reader.ReadLine()?.Split(' ');
                    if (sor?[4] == "+")
                    {
                        writer.WriteLine(Feladat5(int.Parse(sor[0]), int.Parse(sor[1]), int.Parse(sor[2]),
                            int.Parse(sor[3])));
                    }
                    else if (sor?[4] == "*")
                    {
                        writer.WriteLine(Szoroz(int.Parse(sor[0]), int.Parse(sor[1]), int.Parse(sor[2]),
                            int.Parse(sor[3])));
                    }
                }
        }
    }
}