using LyricApi;
using Newtonsoft.Json;
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
            // notes
            //client.BaseAddress = 
            //    new Uri("https://api.lyrics.ovh/v1/"); // must add forward slash at the end of base address
            //// Telling service how we want to accept data and other configuration options.
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
               
        private void btnSearch_Click(object sender, EventArgs e)
        {

            txtLyrics.Clear();
            string artist = txtArtistName.Text;
            string songTitle = txtSongTitle.Text;
            LyricService LS = new LyricService();
            SongLyrics result = LS.GetLyrics(artist, songTitle);

            if (result != null) {
                txtLyrics.Text = result.Lyrics;
            }
            else
            {
                MessageBox.Show("No lyrics found");
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" This was a basic api learning tool for my ADV .NET WEB PROGRAMMING class. 11/5/18 At Clover Park Technical College." +
                "\n Robert M. Wood Jr.");
        }
    }

}
