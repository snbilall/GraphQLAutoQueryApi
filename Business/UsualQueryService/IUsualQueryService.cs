using Business.Models;
using System.Threading.Tasks;

namespace Business.UsualQueryService
{
    public interface IUsualQueryService
    {
        Task<UsualQueryModels.Response> QueryAsync(UsualQueryModels.Request request);
    }
}
