using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LyricalApi
{
    public partial class frmMain : Form
    {
        HttpClient client = new HttpClient();

        public frmMain()
        {
            InitializeComponent();

            client.BaseAddress = 
                new Uri("https://api.lyrics.ovh/v1/"); // must add forward slash at the end of base address
            // Telling service how we want to accept data and other configuration options.
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
               
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string artist = txtArtistName.Text;
            string songTitle = txtSongTitle.Text;

            // note https://api.lyrics.ovh/v1/artistName/songTitle
            HttpResponseMessage response = client.GetAsync($"{artist}/{songTitle}").Result;

            if (response.IsSuccessStatusCode)
            {
                string output = response.Content.ReadAsStringAsync().Result;
                //MessageBox.Show(output);

                txtLyrics.Text = output.Replace("\\n", Environment.NewLine); // need to clean up so that it puts the new line on the new lines
            }
            else
            {
                txtLyrics.Text = "Artist or song not found";
                //MessageBox.Show("Not Found");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
