using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nile.Application.Query.ForUser;
using Nile.Application.UserServicves;
using Nile.Domain.EntityModel;

namespace Nile.Application.Handler.QueryHandler.ForUser
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        public GetUsersHandler(IServiceProvider serviceProvider)
        {
            _userServices = serviceProvider.GetRequiredService<IUserServices>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> users = await _userServices.GetUsers();

            return users;
        }
    }
}
