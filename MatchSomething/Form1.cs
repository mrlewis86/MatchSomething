using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MatchSomething
{
    public partial class Form1 : Form
    {
        private SoundPlayer _soundPlayer = new SoundPlayer(@"C: \Users\mrlew\Downloads\bicycle_bell.wav");

        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "e","e","s","s","o","o","r","r","f","f",
            "j","j","k","k","b","b"
        };

        Label firstclicked, secondclicked;


        public Form1()
        {
            InitializeComponent();
            AssignIcons();
            
        }

        private void label_click(object sender, EventArgs e)
        {
            if(firstclicked != null && secondclicked != null)
            {
                return;
            }

            Label clickedLabel = sender as Label;

            if(clickedLabel == null)
            {
                return;
            }
            if(clickedLabel.ForeColor == Color.Black)
            {
                return;
            }
            if(firstclicked == null)
            {
                firstclicked = clickedLabel;
                firstclicked.ForeColor = Color.Black;
                return;
            }
            secondclicked = clickedLabel;
            secondclicked.ForeColor = Color.Black;

            CheckWinner();

            if(firstclicked.Text == secondclicked.Text)
            {
                firstclicked = null;
                secondclicked = null; 
            }

            else

            timer1.Start();
        }

        private void CheckWinner()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;


            }

            _soundPlayer.Play();
            MessageBox.Show("Congrats!!! Not As Smart As You Thought You Were Are Ya?!?!? ");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstclicked.ForeColor = firstclicked.BackColor;
            secondclicked.ForeColor = secondclicked.BackColor;

            firstclicked = null;
            secondclicked = null;
        }

        private void AssignIcons()
        {
            Label label;
            int randomNumber;

            for(int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    label = (Label)tableLayoutPanel1.Controls[i];
                }
                else
                    continue;
                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];

                icons.RemoveAt(randomNumber);
            }
        }
    }
}
