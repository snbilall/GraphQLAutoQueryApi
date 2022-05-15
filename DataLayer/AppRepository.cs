using DataLayer.GenericRepositoryBase;

namespace DataLayer
{
    public class AppRepository : RepositoryBase<AppDbContext>, IAppRepository
    {
        public AppRepository(AppDbContext context) : base(context)
        {
        }
    }
}
