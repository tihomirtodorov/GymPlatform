using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Gym;
using Application.Exceptions;
using Application.Features.Gym.Commands.CreateGym;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Gym.Commands.DeleteGym
{
    public class DeleteGymCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public class DeleteGymHandler : IRequestHandler<DeleteGymCommand, Guid>
        {
            private readonly IGymRepository gymRepository;
            private readonly IMapper mapper;

            public DeleteGymHandler(IGymRepository gymRepository, IMapper mapper)
            {
                this.gymRepository = gymRepository;
                this.mapper = mapper;
            }

            public async Task<Guid> Handle(DeleteGymCommand request, CancellationToken cancellationToken)
            {
                var entity = await gymRepository.GetByIdAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException("Gym not found");
                }

                await gymRepository.DeleteAsync(request.Id);
                return request.Id;
            }
        }
    }
}
