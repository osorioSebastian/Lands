using System;


namespace Lands.Models
{
    using Newtonsoft.Json;
    public class RegionalBloc
    {

        [JsonProperty(PropertyName = "acronym")]
        public string Acronym { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Name { get; set; }

    }
}
