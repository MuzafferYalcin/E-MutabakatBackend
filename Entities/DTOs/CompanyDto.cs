using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CompanyDto : IDto
    {
        public Company Company { get; set; }
        public int UserId { get; set; }
    }
}
