using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

namespace ContactList.Tests.Services
{
    public class FileService_Tests
    {
        [Fact]
        public void SaveListToFile_ShouldSaveListToJsonFile()
        {
            // arrange
            var mockFileService = new Mock<IFileService>();
            var contactService = new ContactService(mockFileService.Object);

            var contacts = new List<ContactModel>
            {
                ContactFactory.CreateContact(
                    "Bert",
                    "Johansson",
                    "bert.johansson@domain.com",
                    "0724624911",
                    "Testgatan",
                    "Teststad",
                    "70349"
                ),
            };

            // act
            contactService.Add(contacts.First());

            // assert
            mockFileService.Verify(
                fs =>
                    fs.SaveListToFile(
                        It.Is<List<ContactModel>>(List =>
                            List.Count == contacts.Count && List.First().FirstName == "Bert"
                        )
                    ),
                Times.Once
            );
        }

        [Fact]
        public void GetListFromFile_ShouldReturnListFromJsonFile()
        {
            // arrange
            var mockFileService = new Mock<IFileService>();
            var contactService = new ContactService(mockFileService.Object);

            var contacts = new List<ContactModel>
            {
                ContactFactory.CreateContact(
                    "Bert",
                    "Johansson",
                    "bert.johansson@domain.com",
                    "0724624911",
                    "Testgatan",
                    "Teststad",
                    "70349"
                ),
            };

            mockFileService.Setup(fs => fs.GetListFromFile()).Returns(contacts);

            // act
            var result = contactService.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Equal(contacts.Count, result.Count());
            Assert.Contains(result, c => c.FirstName == "Bert" && c.LastName == "Johansson");
            mockFileService.Verify(fs => fs.GetListFromFile(), Times.Once);
        }
    }
}
