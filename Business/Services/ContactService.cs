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
        private readonly List<ContactModel> _contact = [];

        public void Add(ContactModel contact)
        {
            _contact.Add(contact);
        }

        public IEnumerable<ContactModel> GetAll()
        {
            return _contact;
        }
    }
}
