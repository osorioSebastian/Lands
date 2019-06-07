﻿using System;
namespace Lands.Models
{
    using System;
    using Newtonsoft.Json;


    public class TokenResponse
    {
        #region Properties


        [JsonProperty(PropertyName = "acces_token")]
        public string AccesToken { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = ".issued")]
        public DateTime Issued { get; set; }

        [JsonProperty(PropertyName = ".expires")]
        public DateTime Expires { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }

       /* public bool IsRemembered
        {
            get;
            set;
        }

        public String Password
        {
            get;
            set;

        }*/
        #endregion
    }
}
