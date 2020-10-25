using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Post;

namespace Application.Interfaces.Apis
{
    public interface IJsonPlaceholderApi
    {
        Task<IEnumerable<PostResponse>> GetPosts();
    }
}
