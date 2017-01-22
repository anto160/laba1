using System;

//public class Class1
//{
//	public Class1()
//	{
//	}
//}
namespace AddressBook
{
    class addressbook
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Birthdate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public addressbook() { }
        public void Writeaddressbook()
        {
            using (StreamWriter sw = File.AppendText("addressbook.csv"))
            {
                sw.WriteLine(this.Firstname);
                sw.WriteLine(this.Lastname);
                sw.WriteLine(this.Birthdate);
                sw.WriteLine(this.Phone);
                sw.WriteLine(this.Address);
            }
        }
        public static void Addressbook(string name)
        {
            using (StreamReader sr = File.OpenText("addressbook.csv"))
            {
                string temp = null;
                while ((temp = sr.ReadLine()) != name && temp != null) ;
                if (temp == name)
                {
                    Console.WriteLine(String.Format("\nИмя: " + temp));
                    Console.WriteLine(String.Format("Фамилия: " + sr.ReadLine()));
                    Console.WriteLine(String.Format("Дата рождения: " + sr.ReadLine()));
                    Console.WriteLine(String.Format("Телефон: " + sr.ReadLine()));
                    Console.WriteLine(String.Format("Адрес: \n" + sr.ReadLine()));
                }
                else Console.WriteLine("Такой сотрудник не найден . .");
            }
        }
        public override string ToString()
        { return String.Format("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15}", Firstname, Lastname, Birthdate, Phone, Address); }
    }
}