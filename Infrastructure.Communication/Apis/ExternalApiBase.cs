using System;
using System.Collections.Generic;
using System.Text;
using Flurl.Http;
using Flurl.Http.Configuration;
using Infrastructure.Communication.Utilities;
using Newtonsoft.Json;

namespace Infrastructure.Communication.Apis
{
    public abstract class ExternalApiBase
    {
        public virtual string BaseUrl { get; set; }

        public ExternalApiBase()
        {
            FlurlHttp.Configure(c => {
                c.AllowedHttpStatusRange = "200-299";

                var jsonSettings = new JsonSerializerSettings();
                jsonSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

                c.JsonSerializer = new NewtonsoftJsonSerializer(jsonSettings);
            });
        }
    }
}
