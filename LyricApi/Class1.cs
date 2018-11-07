using LyricalApi;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace LyricApi
{
    
    public class LyricService
    {
        HttpClient client = new HttpClient();


        /// <summary>
        /// Gets song lyrics based on artist and song title.
        /// Returns null if lyrics not found, could be by artist or song.
        /// </summary>
        /// <param name="artist">Case insensitive artist name</param>
        /// <param name="songTitle">Case insensitive song title</param>
        /// <returns></returns>
        public SongLyrics GetLyrics(string artist, string songTitle)
        {
            client.BaseAddress = new Uri("https://api.lyrics.ovh/v1/");
            // note https://api.lyrics.ovh/v1/artistName/songTitle
            HttpResponseMessage response = client.GetAsync($"{artist}/{songTitle}").Result;

            if (response.IsSuccessStatusCode)
            {
                string output = response.Content.ReadAsStringAsync().Result;
                output = output.Replace("\\n", Environment.NewLine);
                SongLyrics SL = JsonConvert.DeserializeObject<SongLyrics>(output);

                return SL;
            }
            else
            {
                return null; // || or throw new ArgumentException("Song or artist does not exist");
            }
        }
    }
}
