using Build_IT_Desktop.Data.Interfaces;
using Build_IT_Desktop.Models.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Build_IT_Desktop.Data.ScriptRepository.Scripts.Queries
{
    public class GetAllScriptsQuery : IRequest<IEnumerable<ScriptResource>>
    {
        private const string _url = "http://building-it.net/api/scripts";

        public async Task<IEnumerable<ScriptResource>> Execute()
        {
            using (WebClient webClient = new WebClient())
            {
                var json = await webClient.DownloadStringTaskAsync(_url);
                return JsonConvert.DeserializeObject<List<ScriptResource>>(json);
            }
        }
    }
}
