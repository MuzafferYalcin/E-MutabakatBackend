using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
    public class CurrencyAccountExcelDto : IDto
    {
        public IFormFile file {  get; set; }
        public int CompanyId { get; set; }
    }
}
