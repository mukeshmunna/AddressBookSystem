using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AddressBook
{
    public class Addressbook
    {
        List<Contact> addressbooklist = new List<Contact>();
        Dictionary<string, List<Contact>> dict = new Dictionary<string, List<Contact>>();
        public void CreateContact()
        {
            Console.WriteLine("Enter the details\n1.First Name\n2.Last Name\n3.Address \n4.City Name \n5.State Name \n6.Zip code \n7.Phone Number \n8.Email Address ");
            Contact contact = new Contact()
            {
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
                Address = Console.ReadLine(),
                City = Console.ReadLine(),
                State = Console.ReadLine(),
                Zip = Convert.ToInt32(Console.ReadLine()),
                PhoneNumber = Convert.ToInt32(Console.ReadLine()),
                Email = Console.ReadLine(),
            };
            if (CheckName(contact))
            {
                Console.WriteLine("Name is already present");
            }
            else
            {
                Console.WriteLine("Added Contact :");
                Console.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip + "\n" + contact.PhoneNumber + "\n" + contact.Email);
                addressbooklist.Add(contact);
            }
        }
        public void AddAddressBookToDictionary()
        {
            Console.WriteLine("Enter a unique key");
            string uniquename = Console.ReadLine();
            dict.Add(uniquename, addressbooklist);
            addressbooklist = new List<Contact>();
        }
        public void EditContact(string name, string contactname)
        {
            foreach (var data in dict)
            {
                if (data.Key.Equals(name))
                {
                    foreach (Contact contact in data.Value)
                    {
                        if (contact.FirstName.Equals(contactname) || contact.LastName.Equals(contactname))
                        {
                            Console.WriteLine("Enter what to edit\n1.Last Name\n2.Address \n3.City Name \n4.State Name \n5.Zip code \n6.Phone Number \n7.Email Address ");
                            int option = Convert.ToInt32(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                    contact.LastName = Console.ReadLine();
                                    break;
                                case 2:
                                    contact.Address = Console.ReadLine();
                                    break;
                                case 3:
                                    contact.City = Console.ReadLine();
                                    break;
                                case 4:
                                    contact.State = Console.ReadLine();
                                    break;
                                case 5:
                                    contact.Zip = Convert.ToInt32(Console.ReadLine());
                                    break;
                                case 6:
                                    contact.PhoneNumber = Convert.ToInt32(Console.ReadLine());
                                    break;
                                case 7:
                                    contact.Email = Console.ReadLine();
                                    break;
                                default:
                                    break;
                            }
                            Console.WriteLine("Edited Details");
                            Console.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip + "\n" + contact.PhoneNumber + "\n" + contact.Email);
                        }
                    }
                }
            }
        }

        public void DeleteContact(string name, string contactname)
        {
            Contact contact = new Contact();
            foreach (var item in dict)
            {
                if (item.Key.Equals(name))
                {
                    foreach (var data in item.Value)
                    {
                        if (data.FirstName.Equals(contactname) || data.LastName.Equals(contactname))
                        {
                            contact = data;
                        }
                    }
                    item.Value.Remove(contact);
                    Console.WriteLine("Contact Removed");
                }
                else
                {
                    Console.WriteLine("No dictionary with key exists");
                }
            }
        }

        public void DisplayContacts()
        {
            foreach (var data in dict)
            {
                Console.WriteLine(data.Key);
                int c = 1;
                foreach (Contact contact in data.Value)
                {
                    Console.WriteLine("Contact " + c + ":");
                    Console.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip + "\n" + contact.PhoneNumber + "\n" + contact.Email);
                    c++;
                }
            }
        }
        public void WriteToJsonFile(string filepath)
        {
            var json = JsonConvert.SerializeObject(dict);
            File.WriteAllText(filepath, json);
        }

        public bool CheckName(Contact contact)
        {
            string name = contact.FirstName;
            List<Contact> list2 = null;
            foreach (var data in dict)
            {
                list2 = data.Value.Where(x => x.FirstName.Equals(name)).ToList();
            }
            if (list2 == null)
            {
                return false;
            }
            return true;
        }
    }
}
