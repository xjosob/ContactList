using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Services
{
    public class ContactService
    {
        private List<ContactModel> _contacts = [];
        private readonly FileService _fileService = new();

        public void Add(ContactModel contact)
        {
            try
            {
                _contacts.Add(contact);
                _fileService.SaveListToFile(_contacts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerable<ContactModel> GetAll()
        {
            try
            {
                _contacts = _fileService.GetListFromFile();
                return _contacts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return [];
            }
        }
    }
}
