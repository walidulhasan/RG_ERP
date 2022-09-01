using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using RG.Application.Common.DevExtremeModelBinds;
using RG.Application.Interfaces.Services.AlgoHR.Setup;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Setups.UserDepartmentAccess.Queries
{
    public class GetUserDepartmentAccessListQuery : IRequest<LoadResult>
    {
        public int UserID { get; set; }
        public DataSourceLoadOptions LoadOptions { get; set; }
    }
    public class GetUserDepartmentAccessListQueryHandler : IRequestHandler<GetUserDepartmentAccessListQuery, LoadResult>
    {
        private readonly IUserDepartmentAccessService userDepartmentAccessService;

        public GetUserDepartmentAccessListQueryHandler(IUserDepartmentAccessService _userDepartmentAccessService)
        {
            userDepartmentAccessService = _userDepartmentAccessService;
        }
        public async Task<LoadResult> Handle(GetUserDepartmentAccessListQuery request, CancellationToken cancellationToken)
        {
            request.LoadOptions.PrimaryKey = new[] { "SectionID" };
            request.LoadOptions.PaginateViaPrimaryKey = true;
            var data = userDepartmentAccessService.GetUserDepartmentAccessList(request.UserID);
            return await DataSourceLoader.LoadAsync(data, request.LoadOptions);

        }
    }
}
