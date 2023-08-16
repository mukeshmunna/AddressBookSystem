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
        public Dictionary<string, List<Contact>> dict = new Dictionary<string, List<Contact>>();
        public Dictionary<string, List<Contact>> stateDict = new Dictionary<string, List<Contact>>();
        public Dictionary<string, List<Contact>> cityDict = new Dictionary<string, List<Contact>>();
        int stateCount, cityCount;
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
            foreach (var data in dict)
            {
                foreach (var item in data.Value)
                {
                    if (item.FirstName.Equals(name))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public void SearchByState()
        {
            foreach (var data in dict.Values)
            {
                foreach (var item in data)
                {
                    if (!stateDict.Keys.Equals(item.State) && !stateDict.ContainsKey(item.State))
                    {
                        List<Contact> list = new List<Contact>();
                        list.Add(item);
                        stateDict.Add(item.State, list);
                    }
                    else
                    {
                        foreach (var states in stateDict)
                        {
                            if (states.Key.Equals(item.State))
                            {
                                states.Value.Add(item);
                            }
                        }
                    }

                }
            }
        }

        public void SearchByCity()
        {
            foreach (var data in dict.Values)
            {
                foreach (var item in data)
                {
                    if (!cityDict.Keys.Equals(item.City))
                    {
                        List<Contact> list = new List<Contact>();
                        list.Add(item);
                        cityDict.Add(item.City, list);
                    }
                    else
                    {
                        foreach (var cities in cityDict)
                        {
                            if (cities.Key.Equals(item.City))
                            {
                                cities.Value.Add(item);
                            }
                        }
                    }
                }
            }
        }

        public void GetDetailsFromState(string input)
        {
            stateCount = 0;
            foreach (var data in stateDict)
            {
                if (data.Key.Equals(input))
                {
                    Console.WriteLine("State : " + data.Key);
                    var slist = stateDict.GetValueOrDefault(data.Key);
                    DisplayList(slist.ToList());
                    stateCount = slist.Count;
                }
            }
        }
        public void GetDetailsFromCity(string input)
        {
            cityCount = 0;
            foreach (var data in cityDict)
            {
                if (data.Key.Equals(input))
                {
                    Console.WriteLine("City : " + data.Key);
                    var clist = cityDict.GetValueOrDefault(data.Key);
                    DisplayList(clist.ToList());
                    cityCount = clist.Count;
                }
            }
        }
        public void GetContactCountFromState(string input)
        {
            GetDetailsFromState(input);
            Console.WriteLine("Count : " + stateCount);

        }
        public void GetContactCountFromCity(string input)
        {
            GetDetailsFromCity(input);
            Console.WriteLine("Count : " + cityCount);

        }
        public void DisplayDict(Dictionary<string, List<Contact>> dict)
        {
            foreach (var data in dict)
            {
                Console.WriteLine("Key : " + data.Key);
                foreach (var contact in data.Value)
                {
                    Console.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip + "\n" + contact.PhoneNumber + "\n" + contact.Email);
                }
            }
        }

        public void DisplayList(List<Contact> list)
        {
            foreach (var contact in list)
            {
                Console.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip + "\n" + contact.PhoneNumber + "\n" + contact.Email);
                Console.WriteLine();
            }
        }

    }
}