
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProblem
{
    public class AddressBook
    {
        List<Contact> addressBook = new List<Contact>(); //created list to store multiple contact
        public void CreateContact()
        {
            Console.WriteLine("Enter the detais :\n 1.First Name \n2.Last name \n3.Address \n4.City Name \n5.State Name \n.6.Zip code \n7.Phone Number \n8.Email Address ");
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
            Console.WriteLine(contact.FirstName + "\n " + contact.LastName + "\n " + contact.Address + "\n " + contact.City + "\n " + contact.State + "\n " + contact.Zip + "\n " + contact.PhoneNumber + "\n " + contact.Email);
            addressBook.Add(contact);

        }
        public void EditContact(string name)
        {
            foreach (var contact in addressBook)
            {
                if (contact.FirstName.Equals(name) || contact.LastName.Equals(name))
                {
                    Console.WriteLine("Enter the option to Edit -->  \n1.Last name \n2.Address \n3.City Name \n4.State Name \n.5.Zip code \n6.Phone Number \n7.Email Address ");
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
                    }
                }
                else { Console.WriteLine("Not name found"); }
            }
        }

        public void Display()
        {
            foreach (var data in addressBook)
            {
                Console.WriteLine("View Details \n");
                Console.WriteLine(data.FirstName + "\n" + data.LastName + "\n" + data.Address + "\n" + data.City + "\n" + data.State + "\n" + data.Zip + "\n" + data.PhoneNumber + "\n" + data.Email + "\n");
            }
        }
    }
}