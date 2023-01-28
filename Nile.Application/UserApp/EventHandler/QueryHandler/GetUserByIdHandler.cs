using Nile.Application.UserApplication.Queries;
using Nile.Application.UserServicves;
using Nile.Domain.EntityModel;

namespace Nile.Application.UserApplication.EventHandler.QueryHandler
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        public GetUserByIdHandler(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User user = await _userServices.GetUserById(request.UserId);
            if (user == null)
            {
                return null;
            }

            /*UserBasicDto returnedUser = _mapper.Map<UserBasicDto>(user);*/
            return user;
        }
    }
}
