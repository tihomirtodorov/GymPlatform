using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Gym;
using Application.Enums.Gym;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Gym.Commands.CreateGym
{
    public class CreateGymCommand : IRequest<GymResponse>
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public Status Status { get; set; } = Status.Open;

        public class CreateGymCommandHandler : IRequestHandler<CreateGymCommand, GymResponse>
        {
            private readonly IGymRepository gymRepository;
            private readonly IMapper mapper;

            public CreateGymCommandHandler(IGymRepository gymRepository, IMapper mapper)
            {
                this.gymRepository = gymRepository;
                this.mapper = mapper;
            }

            public async Task<GymResponse> Handle(CreateGymCommand request, CancellationToken cancellationToken)
            {
                var entity = mapper.Map<Domain.Entities.Gym>(request);
                await gymRepository.AddAsync(entity);

                return mapper.Map<GymResponse>(entity);
            }
        }
    }
}
