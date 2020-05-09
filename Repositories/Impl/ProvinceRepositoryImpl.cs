using MvcCustomerManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MvcCustomerManager.Repositories.Impl
{
    public class ProvinceRepositoryImpl : GeneralRepositoryImpl<Province, DataContext>, IProvinceRepository
    {
        public ProvinceRepositoryImpl(DataContext context) : base(context)
        {

        }
    }
}
