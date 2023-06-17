using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBaBsRecoinciliationDal : EfEntityRepositoryBase<BaBsReconciliation, ContextDb>, IBaBsRecoinciliationDal
    {
        
    }
}
