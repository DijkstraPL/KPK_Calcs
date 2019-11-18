using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Build_IT_Application.Application.User.Commands.GetToken
{
    [JsonObject(MemberSerialization.OptOut)]
    public class TokenResponseQuery
    {
        #region Properties
        
        public string token { get; set; }
        public int expiration { get; set; }
        public string refresh_token { get; set; }

        #endregion // Properties
    }
}
