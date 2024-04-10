using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public class Phone
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Phone(string name, string phoneNumber) 
        { 
            Name = name;
            PhoneNumber = phoneNumber;
        }
        public override string ToString()
        {
            return $"{Name}, serialNo {PhoneNumber}";
        }
    }
}
