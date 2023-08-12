using System;
using System.Collections.Generic;

namespace AddressBook
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book program");
            Addressbook addressbook = new Addressbook();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1.Create Contact\n2.Add to Dictionary\n3.Edit Contact\n4.Display Contacts\n5.Delete Contact\n6.Serialize dict to JSON\n7.Exit");
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