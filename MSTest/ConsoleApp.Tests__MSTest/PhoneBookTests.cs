using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp.Tests__MSTest
{
    [TestClass]
    public class PhoneBookTests
    {
        [TestMethod]
        public void Shuld_Add_Contact_To_List()
        {
            //arrange
            PhoneBook phoneBook = new PhoneBook();            
            Contact contact = new Contact();

            //Act
            phoneBook.ContacList.Add(contact);


            //assert
            Assert.AreEqual(1, phoneBook.ContacList.Count);
        }

        [TestMethod]
        public void Shuld_Remove_Contact_From_List()
        {
            //arrange
            PhoneBook phoneBook = new PhoneBook();  
            Contact contact = new Contact();
            phoneBook.ContacList.Add(contact);

            //Act
            phoneBook.ContacList.Remove(contact);            


            //assert
            Assert.AreEqual(0, phoneBook.ContacList.Count);
        }


    }
}
