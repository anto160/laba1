using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace laba1
{
    class Program
    {
        public static char otvet; 
        public static string s; 
        static void Main(string[] args)
        {
            string chislo = null; 
            while (chislo != "4")
            {
                do
                {
                    Console.WriteLine("Меню");
                    Console.WriteLine(" 1 - Посмотреть все контакты\n" +
                        " 2 - Поиск\n" +
                        " 3 - Добавить контакт\n" +
                        " 4 - Выход\n"); 
                    chislo = Console.ReadLine(); 
                    switch (chislo)
                    {
                        case "1":
                            StreamReader sr = File.OpenText("addressbook.csv");  
                            int sch = 0;
                            string tmpname, tmpsurname, tmpphone, tmpmail = null;
                            while (true)
                            {
                                string st = sr.ReadLine();
                                if (st == null)
                                    break;
                                if (st == "##nextcontack")
                                {
                                    tmpname = sr.ReadLine();
                                    tmpsurname = sr.ReadLine();
                                    tmpphone = sr.ReadLine();
                                    tmpmail = sr.ReadLine();
                                    sch++;
                                    addressbook.WriteContact(sch, tmpname, tmpsurname, tmpphone, tmpmail);
                                 }
                            } 
                            sr.Close();
                                break;
                        case "2":
                                string n = null;
                                Console.WriteLine("Поиск по");
                                Console.WriteLine(" 1 - Имени\n" +
                                    " 2 - Фамилии\n" +
                                    " 3 - Имени и фамилии\n" +
                                    " 4 - Телефону\n" +
                                    " 5 - E-mail\n");
                                chislo = Console.ReadLine();
                                switch (chislo)
                                {
                                    case "1":
                                        Console.WriteLine("Введите имя: ");
                                        n = Console.ReadLine();
                                        addressbook.Addressbook(n, chislo);
                                        break;
                                    case "2":
                                        Console.WriteLine("Введите фамилию: ");
                                        n = Console.ReadLine();
                                        addressbook.Addressbook(n, chislo);
                                        break;
                                    case "3":
                                        Console.WriteLine("Введите имя и фамилию: ");
                                        n = Console.ReadLine();
                                        addressbook.Addressbook(n, chislo);
                                        break;
                                    case "4":
                                        Console.WriteLine("Введите телефон: ");
                                        n = Console.ReadLine();
                                        addressbook.Addressbook(n, chislo);
                                        break;
                                    case "5":
                                        Console.WriteLine("Введите e-mail: ");
                                        n = Console.ReadLine();
                                        addressbook.Addressbook(n, chislo);
                                        break;
                                }
                                break;
                        case "3":
                            addressbook temp = new addressbook();
                            Console.WriteLine("Введите имя: ");
                            temp.Name = Console.ReadLine();
                            Console.WriteLine("Введите фамилию: ");
                            temp.Surname = Console.ReadLine();
                            Console.WriteLine("Введите телефон: ");
                            temp.Phone = Console.ReadLine();
                            Console.WriteLine("Введите e-mail: ");
                            temp.Mail = Console.ReadLine();
                            temp.Writeaddressbook();
                            Console.WriteLine("\n Запись добавлена!"); 
                            break;
                        case "4": 
                            //Console.ReadKey(); 
                            return;
                    }
                    do
                    {
                        Console.WriteLine("\nПродолжить работу y/n");
                        s = Console.ReadLine(); 
                        try 
                        {
                            otvet = char.Parse(s);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ошибка при вводе!!! ");
                        }
                    }
                    while (otvet != 'y' && otvet != 'n'); 
                    Console.Clear();
                }while (otvet == 'y'); 
                if (otvet == 'n')
                {
                    
                    break;
                }
            }
            Console.ReadLine();
        }
    }
    class addressbook
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public addressbook(){}
        public void Writeaddressbook()
        {
            using (StreamWriter sw = File.AppendText("addressbook.csv"))
            {
                sw.WriteLine("##nextcontack");
                sw.WriteLine(this.Name);
                sw.WriteLine(this.Surname);
                sw.WriteLine(this.Phone);
                sw.WriteLine(this.Mail);}}
        public static void Addressbook(string name, string chislo)
        {
            Console.WriteLine(String.Format("\nПоиск..."));
            using (StreamReader sr = File.OpenText("addressbook.csv"))
            {

                string temp = null;
                int sch = 0;
                string tmpname, tmpsurname, tmpphone, tmpmail = null;
                switch (chislo)
                {
                    case "1":
                        sch=0;
                        temp = sr.ReadLine();
                        while (temp != null)
                        {
                            if (temp == "##nextcontack")
                            {
                                tmpname = sr.ReadLine();
                                tmpsurname = sr.ReadLine();
                                tmpphone = sr.ReadLine();
                                tmpmail = sr.ReadLine();
                                if (tmpname.Contains(name))
                                {
                                    sch++;
                                    addressbook.WriteContact(sch, tmpname, tmpsurname, tmpphone, tmpmail);
                                }

                            }
                            else
                                if (sch == 0)
                                {
                                    Console.WriteLine("Такой контакт не найден . .");
                                    break;
                                }
                            temp = sr.ReadLine();
                        }
                        break;
                    case "2":
                        sch = 0;
                        temp = sr.ReadLine();
                        while (temp != null)
                        {
                            if (temp == "##nextcontack")
                            {
                                tmpname = sr.ReadLine();
                                tmpsurname = sr.ReadLine();
                                tmpphone = sr.ReadLine();
                                tmpmail = sr.ReadLine();
                                if (tmpsurname.Contains(name))
                                {
                                    sch++;
                                    addressbook.WriteContact(sch, tmpname, tmpsurname, tmpphone, tmpmail);
                                }

                            }
                            else
                                if (sch == 0)
                                {
                                    Console.WriteLine("Такой контакт не найден . .");
                                    break;
                                }
                            temp = sr.ReadLine();
                        }
                        break;
                    case "3":
                        sch = 0;
                        temp = sr.ReadLine();
                        while (temp != null)
                        {
                            if (temp == "##nextcontack")
                            {
                                tmpname = sr.ReadLine();
                                tmpsurname = sr.ReadLine();
                                tmpphone = sr.ReadLine();
                                tmpmail = sr.ReadLine();
                                if ((String.Format(tmpname + " " + tmpsurname).Contains(name)) || (String.Format(tmpsurname + " " + tmpname).Contains(name)))
                                {
                                    sch++;
                                    addressbook.WriteContact(sch, tmpname, tmpsurname, tmpphone, tmpmail);
                                }

                            }
                            else
                                if (sch == 0)
                                {
                                    Console.WriteLine("Такой контакт не найден . .");
                                    break;
                                }
                            temp = sr.ReadLine();
                        }
                        break;
                    case "4":
                        sch = 0;
                        temp = sr.ReadLine();
                        while (temp != null)
                        {
                            if (temp == "##nextcontack")
                            {
                                tmpname = sr.ReadLine();
                                tmpsurname = sr.ReadLine();
                                tmpphone = sr.ReadLine();
                                tmpmail = sr.ReadLine();
                                if (tmpphone.Contains(name))
                                {
                                    sch++;
                                    addressbook.WriteContact(sch, tmpname, tmpsurname, tmpphone, tmpmail);
                                }

                            }
                            else
                                if (sch == 0)
                                {
                                    Console.WriteLine("Такой контакт не найден . .");
                                    break;
                                }
                            temp = sr.ReadLine();
                        }
                        break;
                    case "5":
                        sch = 0;
                        temp = sr.ReadLine();
                        while (temp != null)
                        {
                            if (temp == "##nextcontack")
                            {
                                tmpname = sr.ReadLine();
                                tmpsurname = sr.ReadLine();
                                tmpphone = sr.ReadLine();
                                tmpmail = sr.ReadLine();
                                if (tmpmail.Contains(name))
                                {
                                    sch++;
                                    addressbook.WriteContact(sch, tmpname, tmpsurname, tmpphone, tmpmail);
                                }

                            }
                            else
                                if (sch == 0)
                                {
                                    Console.WriteLine("Такой контакт не найден . .");
                                    break;
                                }
                            temp = sr.ReadLine();
                        }
                        break;
                }

                        
            }
        }
        public static void WriteContact(int sch, string name, string surname, string phone, string mail)
        {
            Console.WriteLine(String.Format("\n#" + sch));
            Console.WriteLine(String.Format("Имя: " + name));
            Console.WriteLine(String.Format("Фамилия: " + surname));
            Console.WriteLine(String.Format("Телефон: " + phone));
            Console.WriteLine(String.Format("E-mail: " + mail));
        }
        public override string ToString()
        {
            return String.Format("{0,-15} {1,-15} {2,-15} {3,-15}", Name, Surname, Phone, Mail);
        }
    }
}