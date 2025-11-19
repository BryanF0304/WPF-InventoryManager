using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventarioConSistemaDePrestamos.Models
{
    public class UserModel
    {
        private string _firstname;
        private string _lastname;
        private string _email;
        private string _id;

        public string Firstname 
        { 
            get => _firstname;
            set 
            {
                if (_firstname != value)
                {
                    _firstname = value;
                } 
                    }
        }
        public string Lastname 
        { 
            get => _lastname;
            set
            {
                if (_lastname != value)
                {
                    _lastname = value;
                }
            }
        }
        public string Email 
        { 
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                }
            }
        }
        public string Id 
        { 
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
            }
        }
    }
}
