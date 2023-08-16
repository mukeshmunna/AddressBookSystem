using System;
using System.Collections.Generic;

namespace AddressBook
{
    public class Program
    {
        static string file_path = @"D:\Problem statemets\AddressBookSystem\AddressBookSystem\AddressBookSystem\AddressBookData.json";
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book program");
            Addressbook addressbook = new Addressbook();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1.Create Contact\n2.Add to Dictionary\n3.Edit Contact\n4.Display Contacts\n5.Delete Contact\n6.Serialize dict to JSON\n7.Search From state using dictionary\n8.Search From cityusing dictionary\n9.Number of contact in state\n10.Number of contact in city\n11.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                string key;
                switch (choice)
                {
                    case 1:
                        addressbook.CreateContact();
                        break;
                    case 2:
                        addressbook.AddAddressBookToDictionary();
                        break;
                    case 3:
                        Console.WriteLine("Enter key");
                        key = Console.ReadLine();
                        Console.WriteLine("Enter the first name");
                        string fname = Console.ReadLine();
                        addressbook.EditContact(key, fname);
                        break;
                    case 4:
                        addressbook.DisplayContacts();
                        break;
                    case 5:
                        Console.WriteLine("Enter key");
                        key = Console.ReadLine();
                        Console.WriteLine("Enter name");
                        string name = Console.ReadLine();
                        addressbook.DeleteContact(key, name);
                        break;
                    case 6:
                        addressbook.WriteToJsonFile(file_path);
                        break;
                    case 7:
                        Console.WriteLine("Enter state name");
                        string input = Console.ReadLine();
                        addressbook.GetDetailsFromState(input);
                        break;
                    case 8:
                        Console.WriteLine("Enter city");
                        string city = Console.ReadLine();
                        addressbook.GetDetailsFromCity(city);
                        break;
                    case 9:
                        Console.WriteLine("Enter state name");
                        string statename = Console.ReadLine();
                        addressbook.GetContactCountFromState(statename);
                        break;
                    case 10:
                        Console.WriteLine("Enter city");
                        string cityname = Console.ReadLine();
                        addressbook.GetContactCountFromCity(cityname);
                        break;
                    case 11:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Enter correct choice");
                        break;
                }
            }
        }
    }
}
