using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricalApi
{
    public class SongLyrics
    {
        [JsonProperty(PropertyName = "lyrics")]
        public string Lyrics { get; set; }
    }


}

