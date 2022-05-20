using Business.Models;
using DataLayer;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Business.UsualQueryService
{
    public class UsualQueryService : IUsualQueryService
    {
        private IAppRepository repository;

        public UsualQueryService(IServiceProvider serviceProvider)
        {
            repository = serviceProvider.GetService<IAppRepository>();
        }

        public async Task<UsualQueryModels.Response> QueryAsync(UsualQueryModels.Request request)
        {
            var predicate = repository.Query<Table1>();
            if (request.IntProp != null)
            {
                predicate = predicate.Where(x => x.Tbl1Prp1 == request.IntProp);
            }
            if (request.DateTimeProp != null)
            {
                predicate = predicate.Where(x => x.Tbl1Prp3 > request.DateTimeProp);
            }
            var result = await predicate.Include(x => x.Table2Properties).ThenInclude(x => x.Table3Properties).ToListAsync();
            return new UsualQueryModels.Response
            {
                Table = result
            };
        }
    }
}
