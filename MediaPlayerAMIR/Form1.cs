using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace MediaPlayerAMIR
{
    public partial class Form1 : Form
    {
        List<string> path = new List<string>();


        public Form1()
        {
            InitializeComponent();
            MPlayer.uiMode = "none";
            timer1.Enabled = true;


        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

          
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "All Files| *.*";
            openFileDialog1.Title = "Select a media file";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path.Add(openFileDialog1.FileName);
                MPlayer.URL = openFileDialog1.FileName;

            }
            

        }

        private void MPlayer_Enter(object sender, EventArgs e)
        {
      
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
           MPlayer.Ctlcontrols.play();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            MPlayer.Ctlcontrols.pause();
        }
       





        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MPlayer.URL = path[listBox1.SelectedIndex];
            }
            catch(Exception e5) 
            {
                MessageBox.Show(e5.Message);
            
            }   
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
              listBox1.SelectedIndex = listBox1.SelectedIndex - 1;
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            MPlayer.Ctlcontrols.currentPosition -= 5;
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            MPlayer.Ctlcontrols.currentPosition += 5;
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "All Files| *.*";
            openFileDialog1.Title = "Select a media file";
            openFileDialog1.Multiselect = true;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for(int i = 0; i < openFileDialog1.FileNames.Length; i++) {
                    path.Add(openFileDialog1.FileNames[i]);
                    listBox1.Items.Add(Path.GetFileNameWithoutExtension(openFileDialog1.FileNames[i]));
                }
                MPlayer.URL = openFileDialog1.FileName;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label2.Text = MPlayer.Ctlcontrols.currentPositionString;
            int currentMediaPosition = (int)MPlayer.Ctlcontrols.currentPosition;
            bunifuHSlider2.Value = currentMediaPosition;

        }

        private void bunifuHSlider2_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            MPlayer.Ctlcontrols.currentPosition = bunifuHSlider2.Value;
        }
        private void StartMediaPlayback()
        {
            MPlayer.Ctlcontrols.play();
            // Kode untuk memulai pemutaran media (misalnya, windowsMediaPlayer.Play())
            timer1.Start();
        }
        private void StopMediaPlayback()
        {
            MPlayer.Ctlcontrols.pause();
            // Kode untuk menghentikan pemutaran media (misalnya, windowsMediaPlayer.Stop())
            timer1.Stop();
        }

        private void bunifuHSlider1_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            MPlayer.settings.volume = bunifuHSlider1.Value;
            label1.Text = bunifuHSlider1.Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

