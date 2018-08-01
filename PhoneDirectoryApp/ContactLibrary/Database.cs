using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ContactLibrary
{
    public static class Database
    {
        internal static List<Person> pList;
        static Database()
        {
            pList = new List<Person>();
        }
        public static void Add(Person p)
        {
            pList.Add(p);
            Console.WriteLine("\n\nContact Added");
        }
        public static List<Person> GetList()
        {
            return pList;
        }
        public static void Read()
        {
            Stream open = File.OpenRead(Environment.CurrentDirectory + "\\PeopleList.xml");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            pList = (List<Person>)xmlSerializer.Deserialize(open);
            open.Close();
            Console.WriteLine("\n\nRead Successful");
        }
        public static void Edit(ref int i, ref int p, string c)
        {
            switch (p)
            {
                case 1:
                    pList[i].firstName = c;
                    break;
                case 2:
                    pList[i].lastName = c;
                    break;
                case 3:
                    pList[i].address.houseNum = c;
                    break;
                case 4:
                    pList[i].address.street = c;
                    break;
                case 5:
                    pList[i].address.city = c;
                    break;
                case 6:
                    pList[i].address.State = (State)Enum.Parse(typeof(State), c);
                    break;
                case 7:
                    pList[i].address.Country = (Country)Enum.Parse(typeof(Country), c);
                    break;
                case 8:
                    pList[i].address.zipcode = c;
                    break;
                case 9:
                    pList[i].phone.areaCode = c;
                    break;
                case 10:
                    pList[i].phone.number = c;
                    break;
                case 11:
                    pList[i].phone.ext = c;
                    break;
                case 12:
                    Console.WriteLine("\n\nCannot change ID");
                    break;
                default:
                    break;
            }
            Console.WriteLine("\n\nUpdate Successful");
        }
        public static void Del(ref int i)
        {
            pList.RemoveAt(i);
            Console.WriteLine("\n\nRemove Successful");
        }
        public static dynamic Search(ref int i, string s)
        {
            switch (i)
            {
                case 1:
                    return from p in pList where p.firstName.StartsWith(s) select p;
                case 2:
                    return from p in pList where p.lastName.StartsWith(s) select p;
                case 3:
                    return from p in pList where p.address.houseNum.Equals(s) select p;
                case 4:    
                    return from p in pList where p.address.street.StartsWith(s) select p;
                case 5:    
                    return from p in pList where p.address.city.StartsWith(s) select p;
                case 6:    
                    return from p in pList where p.address.State.Equals((State)Enum.Parse(typeof(State), s)) select p;
                case 7:    
                    return from p in pList where p.address.Country.Equals((Country)Enum.Parse(typeof(Country), s)) select p;
                case 8:    
                    return from p in pList where p.address.zipcode.StartsWith(s) select p;
                case 9:    
                    return from p in pList where p.phone.areaCode.Equals(s) select p;
                case 10:   
                    return from p in pList where p.phone.number.Equals(s) select p;
                case 11:   
                    return from p in pList where p.phone.ext.Equals(s) select p;
                case 12:   
                    return from p in pList where p.Pid == Convert.ToInt64(s) select p;
            }
            return null;
        }
        public static void Save()
        {

            Stream create = File.Create(Environment.CurrentDirectory + "\\PeopleList.xml");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            xmlSerializer.Serialize(create, pList);
            create.Close();
            Console.WriteLine("\n\nSave Successful");
            Read();
        }
    }
}

