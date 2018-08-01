using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactLibrary;

namespace PhoneContactsTesting
{
    [TestClass]
    public class MethodTesting
    {
        [TestMethod]
        public void AddMethodTest()
        {
            //Arrange
            string f = "Joann";
            string l = "Alvarez";
            string expected = "Joann Alvarez";
            string actual="";

            //Act
            Person person = new Person
            {
                firstName = f,
                lastName = l
            };
            DatabaseAction.AddToDatabase(person);
            DatabaseAction.Save();
            var people = DatabaseAction.Search(1, "Joann");
            foreach(Person p in people)
            {
                actual = p.firstName + " " + p.lastName;
            }
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateMethodTest()
        {
            //Arrange
            string change = "David";
            int opt = 1;
            string expected = "David Alvarez";
            string actual = "";

            //Act
            var people = DatabaseAction.Search(1, "Joann");
            Person person = new Person();
            foreach (Person p in people)
            {
                person = p;
            }
            DatabaseAction.Edit(ref opt, person, change);
            var newPeople = DatabaseAction.Search(1, "David");
            foreach (Person p1 in newPeople)
            {
                actual = p1.firstName + " " + p1.lastName;
            }

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteMethodTest()
        {
            //Arrange
            Person person=new Person();
            var newPeople = DatabaseAction.Search(1, "David");
            foreach (Person p in newPeople)
            {
                person = p;
            }

            //Act
            DatabaseAction.Del(person);

            //Assert
            Assert.AreEqual(null, DatabaseAction.Search(1, "David"));
        }
    }
}
