﻿using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Transaction;
using Core.Aspects.AutoFac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IMailTemplateService _mailTemplateService;

        public CompanyManager(ICompanyDal companyDal, IOperationClaimService operationClaimService, IUserOperationClaimService userOperationClaimService, IMailTemplateService mailTemplateService)
        {
            _companyDal = companyDal;
            _operationClaimService = operationClaimService;
            _userOperationClaimService = userOperationClaimService;
            _mailTemplateService = mailTemplateService;
        }
        public IDataResult<List<Company>> GetList()
        {
            return new SuccesDataResult<List<Company>>(_companyDal.GetList(), "listeleme işlemi başarılı");
        }
        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult(Messages.AddedCompany);
        }

        public IResult CompanyExists(Company company)
        {
            var result = _companyDal.Get(c => c.Name == company.Name && c.TaxDepartment == company.TaxDepartment &&
                            c.TaxIdNumber == company.TaxIdNumber && c.IdentityNumber == company.IdentityNumber);

            if (result != null)
            {
                return new ErrorResult(Messages.CompanyAlreadyExists);
            }

            return new SuccessResult();
        }

        public IResult UserCompanyAdd(int userId, int companyId)
        {
            _companyDal.UserCompanyAdd(userId, companyId);
            return new SuccessResult();
        }

        public IDataResult<UserCompany> GetCompany(int userId)
        {
            return new SuccesDataResult<UserCompany>(_companyDal.GetCompany(userId));
        }
        [ValidationAspect(typeof(CompanyValidator))]
        [TransactionScopeAspect]
        public IResult AddCompanyAndUserCompany(CompanyDto companyDto)
        {
            _companyDal.Add(companyDto.Company);
            _companyDal.UserCompanyAdd(companyDto.UserId, companyDto.Company.Id);
            return new SuccessResult(Messages.AddedCompany);
        }

        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult(Messages.UpdatedCompany);
        }

        public IDataResult<Company> GetById(int id)
        {
            return new SuccesDataResult<Company>(_companyDal.Get(c => c.Id == id));
        }
    }
}
