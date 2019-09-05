using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class AddressDto
    {
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }
}
