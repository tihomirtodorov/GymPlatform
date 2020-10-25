using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Gym;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Gym.Queries.GetAllGyms
{
    public class GetAllGymsQuery : IRequest<IEnumerable<GymResponse>>
    {
        public class GetAllGymsQueryHandler : IRequestHandler<GetAllGymsQuery, IEnumerable<GymResponse>>
        {
            private readonly IGymRepository gymRepository;
            private readonly IMapper mapper;

            public GetAllGymsQueryHandler(IGymRepository gymRepository, IMapper mapper)
            {
                this.mapper = mapper;
                this.gymRepository = gymRepository;
            }

            public async Task<IEnumerable<GymResponse>> Handle(GetAllGymsQuery query, CancellationToken cancellationToken)
            {
                var entity = await gymRepository.GetAllAsync();

                return entity.Select(x => mapper.Map<GymResponse>(x));
            }
        }
    }
}