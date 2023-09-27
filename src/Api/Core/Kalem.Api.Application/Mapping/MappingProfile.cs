using AutoMapper;
using Kalem.Api.Application.Features.Commands.Product.Create;
using Kalem.Api.Application.Features.Commands.Product.Update;
using Kalem.Api.Application.Features.Commands.User.Create;
using Kalem.Api.Application.Features.Commands.User.Login;
using Kalem.Api.Application.Features.Commands.User.Update;
using Kalem.Api.Application.Features.Queries.User;
using Kalem.Api.Application.Models.Queries;
using Kalem.Api.Domain.Models;


namespace Test.Api.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            CreateMap<User, CreateUserCommand>()
            .ReverseMap();

            //CreateMap<User, CreateLoginCommand>()
            //       .ReverseMap();

            CreateMap<User,UpdateUserCommand>()
                   .ReverseMap();

            CreateMap<User, GetLoginViewModel>()
             .ReverseMap();




            CreateMap<User, LoginUserViewModel>()
             .ReverseMap();

            CreateMap<UpdateUserCommand, User>();


            CreateMap<Product, CreateProductCommand>()
              .ReverseMap();
            CreateMap<Product, UpdateProductCommand>()
            .ReverseMap();


        }

        
    }
}
