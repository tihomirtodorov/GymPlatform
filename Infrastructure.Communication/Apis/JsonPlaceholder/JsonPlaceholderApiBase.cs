using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Post;
using Application.Interfaces.Apis;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Infrastructure.Communication.Utilities;
using Newtonsoft.Json;

namespace Infrastructure.Communication.Apis.JsonPlaceholder
{
    public class JsonPlaceholderApiBase : ExternalApiBase, IJsonPlaceholderApi
    {
        public override string BaseUrl => Constants.ApiUrl.JsonPlaceholderBasicUrl;

        public async Task<IEnumerable<PostResponse>> GetPosts()
        {
            var posts = await BaseUrl
                .AppendPathSegment("posts")
                .GetJsonAsync<IEnumerable<PostResponse>>();

            return posts;
        }
    }
}
