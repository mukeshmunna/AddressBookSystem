using AddressBookProblem;

internal class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("Welcome to Address book Problem :");
        bool flag = true;
        AddressBook addressBook = new AddressBook();
        while (flag)
        {
            Console.WriteLine("Enter the option to proceed \n1. Create Contact \n2. Edit Details \n3. View \n4. Exit");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("Creating contact : -->\n");
                    addressBook.CreateContact();
                    break;
                case 2:
                    Console.WriteLine("Enter name to Edit Contact details\n");
                    string input = Console.ReadLine();
                    addressBook.EditContact(input);
                    break;
                case 3:
                    addressBook.Display();
                    break;

                case 4:
                    flag = false;
                    break;
            }
        }

    }
}