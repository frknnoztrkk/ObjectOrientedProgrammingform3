using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/*
Nesneye Dayalı Programlama Kafa Topu Ödevi
Furkan Öztürk
B201200038
Muhammed Kotan
Tuşlar : Oyuncu1 =  W ve S tuşu ,Oyuncu2 = Aşağı ve Yukarı yön tuşları 
*/




 namespace ConsoleApp8
{
        class pong
        {
            int a;
            int b;
            Tahta tahta;
            çubuk direk;
            çubuk direk1;
            top x;


            ConsoleKeyInfo keyInfo;
            ConsoleKey consoleKey;


            public pong(int en, int boy)
            {
                this.a = en;
                this.b = boy;
                tahta = new Tahta(en, boy);
                x = new top(en / 2, boy / 2, boy, en);
            }
            public void kur()
            {
            direk = new çubuk(2, b);
            direk1 = new çubuk(a - 2, b);
                keyInfo = new ConsoleKeyInfo();

                consoleKey = new ConsoleKey();

                x.X = a / 2;
                x.Y = b / 2;
                x.yön = 0;
            }
            public void skor()
            {
                x.skorHesapla();
            if (x.skor1 == 3 || x.skor2 ==3)
                {
                    Console.Clear();
                    Console.WriteLine(x.skor1.ToString() + "\t\t\t : \t\t\t" + x.skor2.ToString());
                    devam();
                }


            }
            void input()
            {
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(true);
                    consoleKey = keyInfo.Key;
                }
            }
            public void yurut()
            {
                while (true)
                {
                    Console.Clear();
                    skor();
                    kur();
                    tahta.ciz();
                direk.ciz();
                direk1.ciz();
                    x.ciz();

                    while (x.X != 1 && x.X != a - 1)
                    {
                        input();
                        switch (consoleKey)
                        {
                            case ConsoleKey.W:
                            direk.yukarı();

                                break;
                            case ConsoleKey.UpArrow:
                            direk1.yukarı();
                                break;
                            case ConsoleKey.S:
                            direk.asagi();
                                break;
                            case ConsoleKey.DownArrow:
                            direk1.asagi();
                                break;
                        }

                        consoleKey = ConsoleKey.A;
                        x.mantik(direk, direk1);
                        x.ciz();

                        Thread.Sleep(50);


                    }
                }
            }
            public void devam()
            {
                while (true)
                {
                    Console.Write("Oyuna devam etmek istiyor musunuz :  ");
                    string cevap = Console.ReadLine();

                    if (cevap == "E" || cevap == "e")
                    {
                        yurut();
                        Console.Write("Oyuna devam etmek istiyor musunuz : ");
                        cevap = Console.ReadLine();

                    }
                    else if (cevap == "H" || cevap == "h")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Write("Oyuna devam etmek istiyor musunuz : ");
                        cevap = Console.ReadLine();
                    }

                }
            }
            class top
            {
                public int X { get; set; }
                public int Y { get; set; }
                public int skor1 { get; set; }
                public int skor2 { get; set; }

                int yönX;

                int yönY;



                int tahtaBoy;
                int tahtaEn;
                public int yön { get; set; }

                public top(int x, int y, int tahtaboy, int tahtaa)
                {
                    X = x;
                    Y = y;
                    tahtaBoy = tahtaboy;
                    tahtaEn = tahtaa;
                    yönX = -1;  
                    yönY = 1;
                }
                public void ciz()
                {
                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.SetCursorPosition(X, Y);

                    Console.Write("O");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                public void mantik(çubuk çubuk1, çubuk çubuk2)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write("\0");

                    if (Y <= 1 || Y >= tahtaBoy)
                    {
                        yönY *= -1;
                    }
                    if ((X == 3) && (çubuk1.Y - (çubuk1.uzunluk / 2)) <= Y && (çubuk1.Y + (çubuk1.uzunluk / 2)) > Y)
                    {

                        yönX *= -1;
                        if (Y == çubuk1.Y)
                        {
                            yön = 0;

                        }
                        if ((Y >= (çubuk1.Y - (çubuk1.uzunluk / 2)) && Y < çubuk1.Y) || (Y > çubuk1.Y && Y < (çubuk1.Y + (çubuk1.uzunluk / 2))))
                        {
                            yön = 1;
                        }
                    }

                    if ((X == tahtaEn - 3) && (çubuk2.Y - (çubuk2.uzunluk / 2)) <= Y && (çubuk2.Y + (çubuk2.uzunluk / 2)) > Y)
                    {
                        yönX *= -1;

                        if (Y == çubuk2.Y)
                        {
                            yön = 0;
                        }
                        if ((Y >= (çubuk2.Y - (çubuk2.uzunluk / 2)) && Y < çubuk2.Y) || (Y > çubuk2.Y && Y < (çubuk2.Y + (çubuk2.uzunluk / 2))))
                        {
                            yön = 1;
                        }

                    }
                    switch (yön)
                    {
                        case 0:
                            X += yönX;

                            break;

                        case 1:
                            X += yönX;
                            Y += yönY;

                            break;

                    }
                }
                public void skorHesapla()
                {
                    if (X == tahtaEn - 1)
                    {
                        skor1++;


                    }
                    if (X == 1)
                    {
                        skor2++;
                    }
                }



            }
            public class Tahta
            {
                int i;
                public int boy { get; set; }
                public int en { get; set; }

                public Tahta()
                {
                    en = 20;
                    boy = 60;
                }
                public Tahta(int en, int boy)
                {
                    this.en = en;
                    this.boy = boy;
                }
                public void ciz()
                {

                    for (int i = 0; i <= en + 1; i++)
                    {
                        Console.SetCursorPosition(i, 0);
                        Console.Write("─");

                    }
                    for (int i = 0; i <= en + 1; i++)
                    {
                        Console.SetCursorPosition(i, (boy + 1));
                        Console.Write("─");
                    }

                    for (int i = 0; i <= boy + 1; i++)
                    {
                        Console.SetCursorPosition(0, i);
                        Console.Write("│");

                    }
                    for (int i = 0; i <= boy + 1; i++)
                    {
                        Console.SetCursorPosition((en + 1), i);
                        Console.Write("│");
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("┌");
                    Console.SetCursorPosition(en + 1, 0);
                    Console.WriteLine("┐");
                    Console.SetCursorPosition(0, boy + 1);
                    Console.WriteLine("└");
                    Console.SetCursorPosition(en + 1, boy + 1);
                    Console.WriteLine("┘");
                }

            }

            class çubuk
            {
                public int X { get; set; }
                public int Y { get; set; }

                public int uzunluk { get; set; }

                public int tahtaBoy { get; set; }

                public çubuk(int x, int tahtaBoy)
                {
                    this.tahtaBoy = tahtaBoy;
                    X = x;
                    Y = tahtaBoy / 2;

                    uzunluk = tahtaBoy / 3;

                }
                public void yukarı()
                {

                    if ((Y - 1 - (uzunluk / 2)) != 0)
                    {
                        Console.SetCursorPosition(X, (Y + (uzunluk / 2)) - 1);

                        Console.Write("\0");
                        Y--;
                        ciz();
                    }

                }

                public void asagi()
                {
                    if ((Y + 1 + (uzunluk / 2)) != tahtaBoy + 2)
                    {
                        Console.SetCursorPosition(X, (Y - (uzunluk / 2)));

                        Console.Write("\0");
                        Y++;
                        ciz();
                    }
                }
                public void ciz()
                {
                    Console.ForegroundColor = ConsoleColor.Red;


                    for (int i = (Y - (uzunluk / 2)); i < (Y + (uzunluk / 2)); i++)
                    {

                        Console.SetCursorPosition(X, i);
                        Console.Write("│");

                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            }
        }
    }