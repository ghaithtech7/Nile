
using AutoMapper;
using MediatR;
using Nile.Application.DtoModels;
using Nile.Application.Query.ForUser;
using Nile.Application.UserServicves;
using Nile.Domain.EntityModel;

namespace Nile.Application.Handler.QueryHandler.ForUser
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserBasicDto>
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        public GetUserByIdHandler(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        public async Task<UserBasicDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User user = await _userServices.GetUserById(request.UserId);
            if (user == null)
            {
                return null;
            }

            UserBasicDto returnedUser = _mapper.Map<UserBasicDto>(user);
            return returnedUser;
        }
    }
}
