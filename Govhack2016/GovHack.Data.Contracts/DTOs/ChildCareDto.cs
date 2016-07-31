using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using GovHack.Data.Entities;

namespace GovHack.Data.Contracts.DTOs
{
    public class ChildCareDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<Vacancies> Availability { get; set; }
    }
}
