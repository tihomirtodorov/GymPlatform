using Application.DTOs.Gym;
using Application.Features.Gym.Commands.CreateGym;
using Application.Features.Gym.Commands.UpdateGym;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateGymCommand, Gym>();
            CreateMap<UpdateGymCommand, Gym>();

            CreateMap<Gym, GymResponse>();
        }
    }
}