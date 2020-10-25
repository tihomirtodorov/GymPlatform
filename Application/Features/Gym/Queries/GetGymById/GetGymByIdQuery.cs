using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Gym;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Gym.Queries.GetGymById
{
    public class GetGymByIdQuery : IRequest<GymResponse>
    {
        public Guid Id { get; set; }

        public class GetGymByIdQueryHandler : IRequestHandler<GetGymByIdQuery, GymResponse>
        {
            private readonly IGymRepository gymRepository;
            private readonly IMapper mapper;

            public GetGymByIdQueryHandler(IGymRepository gymRepository, IMapper mapper)
            {
                this.mapper = mapper;
                this.gymRepository = gymRepository;
            }

            public async Task<GymResponse> Handle(GetGymByIdQuery query, CancellationToken cancellationToken)
            {
                var entity = await gymRepository.GetByIdAsync(query.Id);

                if(entity == null)
                {
                    throw new NotFoundException("Gym not found");
                }

                return mapper.Map<GymResponse>(entity);
            }
        }
    }
}
