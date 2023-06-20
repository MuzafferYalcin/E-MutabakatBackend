using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet("getcompanylist")]
        public IActionResult GetCompanyList()
        {
            var result = _companyService.GetList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("getcompany")]
        public IActionResult GetCompanyById(int id)
        {
            var result = _companyService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost("updateCompany")]
        public IActionResult UpdateCompany(Company company)
        {
            var result = _companyService.Update(company);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost("addCompanyAndUserCompany")]
        public IActionResult AddCompanyAndUserCompany(CompanyDto  companyDto)
        {
            var result = _companyService.AddCompanyAndUserCompany(companyDto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
    }
}
