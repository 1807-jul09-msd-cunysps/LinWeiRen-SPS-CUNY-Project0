using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLibrary
{
    public static class UserInterface
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Menu()
        {
            int opt = 0;
            do
            {
                Console.WriteLine("Welcome to the Phone Directory App");
                Console.WriteLine("\n");
                Console.WriteLine("1. Add Contact Information");
                Console.WriteLine("2. Show/Update Information");
                Console.WriteLine("3. Search Contact");
                Console.WriteLine("4. EXIT");
                switch (opt = ConvertCheck())
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        PrintCompleteRecord();
                        UpdateContact();
                        break;
                    case 3:
                        Console.WriteLine("Select Search Field:");
                        AllOpt();
                        int i = ConvertCheck();
                        if (i <14 && i>0)
                        {
                            string s = Add("Search Text");
                            PrintSearch(i, s);
                        }
                        else if (i == 14)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Option!");
                        }
                        break;
                    case 4:
                        Console.WriteLine("\nSerializing...");
                        DatabaseAction.SerializePeople();
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            } while (opt != 4);
        }
        public static int ConvertCheck()
        {
            int i = 0;
            while (i == 0)
            {
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "UserInterface.Convert NonOption Error");
                    Console.WriteLine("Invalid Input!");
                    i = 0;
                }
            }
            return i;
        }
        public static int ConvertCheck(string s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "UserInterface.Convert NonOption Error");
                Console.WriteLine("Invalid Input!");
                return -1;
            }
        }

        public static string Add(string v)
        {
            Console.WriteLine($"Enter {v}: ");
            return Console.ReadLine().ToUpper();
        }
        public static string Add<T>(string v)
        {
            Console.WriteLine($"Enter {v}:\n");
            foreach (var item in Enum.GetNames(typeof(T)))
            {
                Console.WriteLine(item);
            }
            return Console.ReadLine().ToUpper();
        }
        public static void AllOpt()
        {
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. House Number");
            Console.WriteLine("4. Street Name");
            Console.WriteLine("5. City");
            Console.WriteLine("6. State");
            Console.WriteLine("7. Country");
            Console.WriteLine("8. ZipCode");
            Console.WriteLine("9. CountryCode");
            Console.WriteLine("10. AreaCode");
            Console.WriteLine("11. Phone Number");
            Console.WriteLine("12. Extension");
            Console.WriteLine("13. Search all on Person ID");
            Console.WriteLine("14. BACK");
            Console.WriteLine();
        }
        public static int PersonOpt()
        {
            int opt = 0;
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            return opt = ConvertCheck();
        }
        public static int PhoneOpt()
        {
            int opt = 0;
            Console.WriteLine("1. CountryCode");
            Console.WriteLine("2. AreaCode");
            Console.WriteLine("3. Phone Number");
            Console.WriteLine("4. Extension");
            opt = ConvertCheck();
            if(opt == 1)
            {
                foreach (var item in Enum.GetNames(typeof(Country)))
                {
                    Console.WriteLine(item);
                }
            }
            return opt;
        }
        public static int AddressOpt()
        {
            int opt = 0;
            Console.WriteLine("1. House Number");
            Console.WriteLine("2. Street Name");
            Console.WriteLine("3. City");
            Console.WriteLine("4. State");
            Console.WriteLine("5. Country");
            Console.WriteLine("6. ZipCode");
            opt = ConvertCheck();
            if (opt == 4)
            {
                foreach (var item in Enum.GetNames(typeof(State)))
                {
                    Console.WriteLine(item);
                }
            }
            else if (opt == 5)
            {
                foreach (var item in Enum.GetNames(typeof(Country)))
                {
                    Console.WriteLine(item);
                }
            }
            return opt;
        }
        public static void PrintCompleteRecord()
        {
            Console.WriteLine("Loading...");
            foreach (Person item in DatabaseAction.GetPeople())
            {
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine($"ID: {item.Pid}  Name: {item.firstName} {item.lastName}");
                PrintAddress(item);
                PrintPhone(item);
                Console.WriteLine("--------------------------------------------------------------");

            }
            
        }
        public static void PrintPeople()
        {
            if (DatabaseAction.GetPeople() != null)
            {
                foreach (Person item in DatabaseAction.GetPeople())
                {
                    Console.WriteLine("------------");
                    Console.WriteLine($"ID: {item.Pid}  Name: {item.firstName} {item.lastName}");
                    Console.WriteLine("------------");
                }
            }
            else
            {
                Console.WriteLine("No Records Found!");
            }
        }
        public static void PrintPeople(dynamic p)
        {
            if (p != null)
            {
                foreach (Person item in p)
                {
                    Console.WriteLine("------------");
                    Console.WriteLine($"ID: {item.Pid}  Name: {item.firstName} {item.lastName}");
                    Console.WriteLine("------------");
                }
            }
            else
            {
                Console.WriteLine("No Records Found!");
            }
        }
        public static void PrintPeople(Person p)
        {
            if (p != null)
            {
                Console.WriteLine("------------");
                Console.WriteLine($"ID: {p.Pid}  Name: {p.firstName} {p.lastName}");
                Console.WriteLine("------------");
                PrintAddress(p);
                PrintPhone(p);
            }
            else
            {
                Console.WriteLine("No Records Found!");
            }

        }
        public static void PrintAddress(Person p)
        {
            if (p != null)
            {
                Console.WriteLine("  Address Info:");
                foreach (Person_address item1 in p.Person_address)
                {
                    Console.WriteLine($"    Address ID: {item1.Aid} | Address: {item1.houseNum} {item1.street}, {item1.address_city}, {item1.address_state}, {item1.address_country}, {item1.zipcode}");
                }
            }
            else
            {
                Console.WriteLine("No Records Found!");
            }
        }
        public static void PrintAddress(dynamic address)
        {
            if (address != null)
            {
                foreach (Person_address item1 in address)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine($"Address ID: {item1.Aid} | Address: {item1.houseNum} {item1.street}, {item1.address_city}, {item1.address_state}, {item1.address_country}, {item1.zipcode}");
                    Console.WriteLine("---------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No Records Found!");
            }
        }
        public static void PrintPhone(Person p)
        {
            if (p != null)
            {
                Console.WriteLine("  Phone Info:");
                foreach (Person_phone item2 in p.Person_phone)
                {
                    Console.WriteLine($"    Phone ID: {item2.PHid} | Phone: +{item2.countryCode} {item2.areaCode}-{item2.number} ext:{item2.ext}");
                }
            }
            else
            {
                Console.WriteLine("No Records Found!");
            }
        }
        public static void PrintPhone(dynamic phone)
        {
            if (phone != null)
            {
                foreach (Person_phone item2 in phone)
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine($"Phone ID: {item2.PHid} | Phone: +{item2.countryCode} {item2.areaCode}-{item2.number} ext:{item2.ext}");
                    Console.WriteLine("---------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No Records Found!");
            }
        }
        public static void AddContact()
        {
            int opt = 0;
            do
            {
                Console.WriteLine("\n1. Add a new Person");
                Console.WriteLine("2. Add to a existing Contact Person");
                Console.WriteLine("3. BACK");
                Console.WriteLine();
                opt = ConvertCheck();
                switch (opt)
                {
                    case 1:
                        AddAdditionalContactInfo(AddNewPerson());
                        break;
                    case 2:
                        PrintPeople();
                        Console.WriteLine("\nEnter Person ID:");
                        int id = ConvertCheck();
                        AddAdditionalContactInfo(DatabaseAction.FindPersonID(id));
                        break;
                    case 3:
                        break;
                }
            } while (opt != 3);
        }
        public static Person AddNewPerson()
        {
            string fn = Add("First Name");
            string ln = Add("Last Name");
            return DatabaseAction.AddNewContact(fn, ln);
        }
        public static Person_address AddNewAddress(Person p)
        {
            string hnum = Add("House Number");
            string street = Add("Street Name");
            string city = Add("City");
            string state = Enum.GetName(typeof(State), Enum.Parse(typeof(State), Add<State>("State")));
            string country = Enum.GetName(typeof(Country), Enum.Parse(typeof(Country), Add<Country>("State")));
            string zip = Add("ZipCode");

            return DatabaseAction.AddNewContact(p, hnum, street, city, state, country, zip);
        }
        public static Person_phone AddNewPhone(Person p)
        {

            int cc = (int)Enum.Parse(typeof(Country), Add<Country>("Country Code"));
            string area = Add("AreaCode");
            string number = Add("Phone Number (Exclude AreaCode)");
            string ext = Add("Extension");
            return DatabaseAction.AddNewContact(p, cc, area, number, ext);
        }
        public static void AddAdditionalContactInfo(Person p)
        {
            int opt = 0;
            do
            {
                Console.WriteLine("\nAdd to a existing Contact Person:");
                Console.WriteLine("1.PHONE | 2.ADDRESS | 3. BACK");
                switch (opt = ConvertCheck())
                {
                    case 1:
                        DatabaseAction.AddToDatabase(AddNewPhone(p));
                        break;
                    case 2:
                        DatabaseAction.AddToDatabase(AddNewAddress(p));
                        break;
                    case 3:
                        Console.WriteLine(DatabaseAction.Save());
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            } while (opt != 3);
        }
        public static void UpdateContact()
        {
            int opt = 0;
            do
            {
                Console.WriteLine("1. UPDATE | 2. DELETE | 3. BACK");
                opt = ConvertCheck();
                if (opt != 3)
                {
                    UpdateOption(opt);
                }
            } while (opt != 3);
        }
        public static void UpdateOption(int up_del)
        {
            int opt = 0;
            int id;
            int updateOpt;
            string updateText;
            do
            {
                if(up_del == 1)
                {
                    Console.WriteLine("\nUpdate:");
                }
                else
                {
                    Console.WriteLine("\nDelete:");
                }
                Console.WriteLine("1. PERSON | 2. PHONE | 3. ADDRESS | 4.BACK");
                switch (opt = ConvertCheck())
                {
                    case 1:
                        Console.WriteLine("\nEnter Person ID: ");
                        id = ConvertCheck();
                        Person p = DatabaseAction.FindPersonID(id);
                        if (p != null && up_del == 1)
                        {
                            Console.WriteLine("Select Following Fields:");
                            updateOpt = PersonOpt();
                            updateText = Add("Text");
                            Console.WriteLine(DatabaseAction.Edit(ref updateOpt, p, updateText));
                        }
                        else if (p != null && up_del == 2)
                        {
                            Console.WriteLine(DatabaseAction.Del(p));
                        }
                        else if (p == null)
                        {
                            Console.WriteLine("No Records Found!");
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nEnter Phone ID: ");
                        id = ConvertCheck();
                        Person_phone pp = DatabaseAction.FindPhoneID(id);
                        if (pp != null && up_del == 1)
                        {
                            Console.WriteLine("Select Following Fields:");
                            updateOpt = PhoneOpt();
                            updateText = Add("Text");
                            Console.WriteLine(DatabaseAction.Edit(ref updateOpt, pp, updateText));
                        }
                        else if (pp != null && up_del == 2)
                        {
                            Console.WriteLine(DatabaseAction.Del(pp));
                        }
                        else if (pp == null)
                        {
                            Console.WriteLine("No Records Found!");
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nEnter Address ID: ");
                        id = ConvertCheck();
                        Person_address pa = DatabaseAction.FindAddressID(id);
                        if (pa != null && up_del == 1)
                        {
                            Console.WriteLine("Select Following Fields:");
                            updateOpt = AddressOpt();
                            updateText = Add("Text");
                            Console.WriteLine(DatabaseAction.Edit(ref updateOpt, pa, updateText));
                        }
                        else if (pa != null && up_del == 2)
                        {
                            Console.WriteLine(DatabaseAction.Del(pa));
                        }
                        else if (pa == null)
                        {
                            Console.WriteLine("\nNo Records Found!");
                        }
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            } while (opt != 4);
        }
        public static void PrintSearch(int i, string s)
        {
            switch (i)
            {
                case 1:
                case 2:
                    Console.WriteLine("Loading...\n");
                    PrintPeople(DatabaseAction.Search(i, s));
                    Console.WriteLine("Press ANY to continue");
                    Console.ReadLine();
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    Console.WriteLine("Loading...");
                    PrintAddress(DatabaseAction.Search(i, s));
                    Console.WriteLine("Press ANY to continue");
                    Console.ReadLine();
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                    Console.WriteLine("Loading...");
                    PrintPhone(DatabaseAction.Search(i, s));
                    Console.WriteLine("Press ANY to continue");
                    Console.ReadLine();
                    break;
                case 13:
                    int pid = ConvertCheck(s);
                    if (pid != -1)
                    {
                        Console.WriteLine("Loading...");
                        PrintPeople(DatabaseAction.FindPersonID(pid));
                        Console.WriteLine("Press ANY to continue");
                        Console.ReadLine();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
    }
}
