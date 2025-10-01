using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class AuthenticateUserRequestProfile : Profile
    {
        public AuthenticateUserRequestProfile()
        {
            CreateMap<AuthenticateUserResult, AuthenticateUserResponse>();
            CreateMap<AuthenticateUserRequest, AuthenticateUserCommand>();
        }
    }
}
