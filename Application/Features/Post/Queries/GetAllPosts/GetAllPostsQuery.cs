using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Gym;
using Application.DTOs.Post;
using Application.Interfaces.Apis;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Queries.GetAllPosts
{
    public class GetAllPostsQuery : IRequest<IEnumerable<PostResponse>>
    {
        public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<PostResponse>>
        {
            private readonly IJsonPlaceholderApi api;
            private readonly IMapper mapper;

            public GetAllPostsQueryHandler(IJsonPlaceholderApi api, IMapper mapper)
            {
                this.mapper = mapper;
                this.api = api;
            }

            public async Task<IEnumerable<PostResponse>> Handle(GetAllPostsQuery query, CancellationToken cancellationToken)
            {
                var posts = await api.GetPosts();

                return posts;
            }
        }
    }
}
