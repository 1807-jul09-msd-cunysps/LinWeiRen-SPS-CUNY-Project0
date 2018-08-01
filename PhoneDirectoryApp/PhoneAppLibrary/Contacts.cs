using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneAppLibrary
{
    public enum State{

    }
    public enum Country
    {

    }
    public class Contacts
    {
        public long cid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Address address { get; set; }
        public Phone phoneNum { get; set; }

        //Contacts(string fname, string lname, int zip, string city, long phone)
        //{
        //    firstName = fname;
        //    lastName = lname;
        //    zipCode = zip;
        //    cityName = city;
        //    phoneNum = phone;
        //}

        //Contacts(string fname, int zip, string city, long phone)
        //{
        //    firstName = fname;
        //    zipCode = zip;
        //    cityName = city;
        //    phoneNum = phone;
        //}

        //Contacts(string fname, string city, long phone)
        //{
        //    firstName = fname;
        //    cityName = city;
        //    phoneNum = phone;
        //}

        //Contacts(string fname, long phone)
        //{
        //    firstName = fname;
        //    phoneNum = phone;
        //}
    }
    public class Address
    {
        public long cid { get; set; }
        public string address { get; set; }
        public string city { get; set;}
        public State state { get; set; }
        public int zip { get; set; }
        public string country { get; set; }
    }
    public class Phone
    {
        public long cid { get; set; }
        public long numb { get; set; }
        public Country countryCode { get; set; }
        public int ext { get; set; }

    }
}
