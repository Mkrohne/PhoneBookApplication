using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsolApp.Test_xUnit
{
    public class PhoneBook_Tests
    {
        private PhoneBook phoneBook;
        Contact contact;

        public PhoneBook_Tests()
        {
            //arrange
            phoneBook = new PhoneBook();
            contact = new Contact();
        }


        [Fact]
        public void Shuld_Add_Contact_To_List()
        {

            phoneBook.ContacList.Add(contact);
            phoneBook.ContacList.Add(contact);

            //assert
            Assert.Equal(2, phoneBook.ContacList.Count);

        }

        [Fact]
        public void Shuld_Remove_Contact_From_List()
        {
            //arrange
            phoneBook.ContacList.Add(contact);
            phoneBook.ContacList.Add(contact);

            //Act
            phoneBook.ContacList.Remove(contact);

            //assert
            Assert.Single(phoneBook.ContacList);
        }
    }
}
