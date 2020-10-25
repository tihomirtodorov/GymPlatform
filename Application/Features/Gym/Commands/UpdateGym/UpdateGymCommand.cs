using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Gym;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System.Text.Json.Serialization;
using Application.Enums.Gym;
using Application.Exceptions;

namespace Application.Features.Gym.Commands.UpdateGym
{
    public class UpdateGymCommand : IRequest<GymResponse>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public Status Status { get; set; } = Status.Open;

        public class UpdateGymCommandHandler : IRequestHandler<UpdateGymCommand, GymResponse>
        {
            private readonly IGymRepository gymRepository;
            private readonly IMapper mapper;

            public UpdateGymCommandHandler(IGymRepository gymRepository, IMapper mapper)
            {
                this.gymRepository = gymRepository;
                this.mapper = mapper;
            }

            public async Task<GymResponse> Handle(UpdateGymCommand request, CancellationToken cancellationToken)
            {
                var entity = await gymRepository.UpdateAsync(mapper.Map<Domain.Entities.Gym>(request), request.Id);
                if (entity == null)
                {
                    throw new NotFoundException("Gym not found");
                }

                return mapper.Map<GymResponse>(entity);
            }
        }
    }
}