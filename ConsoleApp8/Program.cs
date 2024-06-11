using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Nesneye Dayalı Programlama Kafa Topu Ödevi
Furkan Öztürk
B201200038
Muhammed Kotan
Tuşlar : Oyuncu1 =  W ve S tuşu ,Oyuncu2 = Aşağı ve Yukarı yön tuşları 
*/

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            pong pong1 = new pong(60, 20);
            pong1.yurut();
            Console.ReadKey();
        
    }
    }
}
