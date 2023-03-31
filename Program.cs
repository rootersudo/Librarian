using System;
using System.Collections.Generic;
namespace library
{
    class libr
    {
        List<magazine> mgzes = new List<magazine>();
        List<book> bks = new List<book>();
        public libr() {  }
        public void find_by_name(string name)
        {
            foreach (var n in mgzes)
            {
                if (n.get_f().name == name) show_mag(n);
                else
                {
                    foreach (var m in bks)
                    {
                        if (m.get_f().name == name) show_bks(m);
                        else Console.WriteLine("Ничего не найдено");
                    }
                    
                }
            }
            
        }
        public void ad_mag(string name)
        {
            f_mag f = new f_mag();
            f.set(name, "SuperIzdat");
            magazine m = new magazine(f);
            if (!mgzes.Contains(m))
            {
                mgzes.Add(m);
            }
            else
            {
                magazine c_m = new magazine();
                c_m=m;
                mgzes.Remove(m);
                f.kol += c_m.get_f().kol;
                mgzes.Add(c_m);
            }
        }
        public void ad_book(string name,string ganr,int kol,int year,string izdat,string author)
        {
            f_book f = new f_book();
            f.set(name, ganr, kol, year, izdat, author);
            book m = new book(f);
            if (!bks.Contains(m))
            {
                bks.Add(m);
            }
            else
            {
                book c_m = new book();
                c_m = m;
                bks.Remove(m);
                f.kol += c_m.get_f().kol;
                bks.Add(c_m);
            }

        }
        public void ad_book(string name,string ganr,string author)
        {
            f_book f = new f_book();
            f.set(name, ganr,author);
            book m = new book(f);
            if (!bks.Contains(m))
            {
                bks.Add(m);
            }
            else
            {
                book c_m = new book();
                c_m = m;
                bks.Remove(m);
                f.kol += c_m.get_f().kol;
                bks.Add(c_m);
            }
        }
        public void show_bks(book m)
        {

            Console.Clear();
            Console.WriteLine("\nname: " + m.get_f().name + "\nkol-vo: " + Convert.ToString(m.get_f().kol) + "\nyear: " + Convert.ToString(m.get_f().year) + "\nganre: " + Convert.ToString(m.get_f().ganr) + "\nkod: " + Convert.ToString(m.get_f().kod));

        }
        public void show_bks()
        {
            foreach(var m in bks)
            {
                Console.WriteLine("\nname: " + m.get_f().name + "\nkol-vo: " + Convert.ToString(m.get_f().kol) + "\nyear: " + Convert.ToString(m.get_f().year) + "\nganre: " + Convert.ToString(m.get_f().ganr) + "\nkod: " + Convert.ToString(m.get_f().kod));
            }
        }
        public void show_mag(magazine m)
        {

            Console.Clear();
           Console.WriteLine("\nname: "+m.get_f().name+"\nnum: "+Convert.ToString(m.get_f().num)+"\nyear: "+Convert.ToString(m.get_f().year)+"\nperiod: "+Convert.ToString(m.get_f().period)+"\nkol-vo: "+Convert.ToString(m.get_f().kol));
           
        }
        public void show_mag()
        {

            foreach (var m in mgzes)
            {
                //Console.Clear();
                Console.WriteLine("\nname: " + m.get_f().name + "\nnum: " + Convert.ToString(m.get_f().num) + "\nyear: " + Convert.ToString(m.get_f().year) + "\nperiod: " + Convert.ToString(m.get_f().period) + "\nkol-vo: " + Convert.ToString(m.get_f().kol));
            }
        }

    }
    class magazine
    {
        f_mag f;
        public magazine() { }
        public f_mag get_f()
        {
            return f;
        }
        public magazine(f_mag f)
        {
            this.f = f;
        }

    }

    class book
    {
        f_book f;
        public book() { }
        public book(f_book f)
        {
            this.f = f;
        }
        public f_book get_f()
        {
            return f;
        }
    }


    struct f_mag
    {
        public
            int kod, period, kol, year, num;
        public
            string name, izdat_name;

        public void set(string name, string izdat)
        {
            Random r = new Random();

            this.kod = r.Next(1000, 99999);
            this.period = r.Next(1, 123);
            this.kol = r.Next(0, 100);
            this.year = 2023 - r.Next(0, 15);
            this.num = r.Next(1, 21);
            this.name = name;
            this.izdat_name = izdat;
        }

    }
    struct f_book
    {
        public int kod, kol, year;
        public string name, ganr,author, izdat_name;
        
        public void set(string name,string ganr,int kol,int year,string izdat,string author)
        {
            Random r = new Random();
            this.name = name;
            this.ganr = ganr;
            this.kol = kol;
            this.year = year;
            this.izdat_name = izdat;
            this.author = author;
            this.kod = r.Next(1000, 99999);
        }
        public void set(string name, string ganr,string author)
        {

            Random r = new Random();
            this.kod = r.Next(1000, 99999);
            this.ganr = ganr;
            //this.kod = r.Next(0, 100);
            this.year = 2023 - r.Next(0, 15);
            this.kol = r.Next(1, 100);
            this.name = name;
            this.izdat_name = "InTIzdat";
            this.author = author;
        }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            
            bool a = true;
            
           
            
            libr l=new libr();
            l.ad_mag("Pixel");
            l.ad_mag("Routine");
            l.ad_mag("Pleasure");
            l.ad_book("Samaritan", "thebestganreoftheworld:)","Petr_Stepanich");
            l.ad_book("Missing...", "drama","Cool_Girl");

            while (a == true)
            {
                Console.Write("Введите комманду -> ");
                string cmd = Console.ReadLine();
                if (cmd == "-help")
                {
                    Console.Clear();
                    Console.WriteLine("-help(Вывод комманд)\n-end(Выход)\n-show_mag(Вывод списка журналов)\n-show_bks(Вывод списка книг)\n-find_by_name(Поиск по названию)\n-add_mgz(Добавить журнал)\n-add_bks(Добавить книгу)");
                }
                else if (cmd == "-show_mag")
                {
                    Console.Clear();
                    l.show_mag();
                }
                else if (cmd == "-show_bks")
                {
                    Console.Clear();
                    l.show_bks();
                }
                else if (cmd == "-add_bks")
                {
                    Console.Clear();
                    
                    Console.WriteLine("Введите данные:\n1)название\n2)жанр\n3)количество\n4)год\n5)издательство\n6)автор");
                    Console.WriteLine("Название: ");
                    string name = Console.ReadLine();Console.WriteLine("Жанр: ");
                    string ganr = Console.ReadLine();Console.WriteLine("Кол-во: ");
                    int kol = Convert.ToInt32(Console.ReadLine());Console.WriteLine("Год: ");
                    int year = Convert.ToInt32(Console.ReadLine());Console.WriteLine("Издательство: ");
                    string izdat = Console.ReadLine();Console.WriteLine("Автор: ");
                    string author = Console.ReadLine();
                    l.ad_book(name, ganr, kol, year, izdat, author);
                }
                else if (cmd == "-find_by_name")
                {
                    Console.Clear();
                    Console.Write("Введите название -> ");
                    string name = Console.ReadLine();
                    l.find_by_name(name);
                }
                else if (cmd == "-end")
                {
                    a = false;
                }
            }
        }
    }
}
