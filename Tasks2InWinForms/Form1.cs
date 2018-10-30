using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Tasks2InWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int resultFromLongRunning = -1;

            Task t1 = new Task(() =>
            {
                int iterations = Convert.ToInt32(numericUpDown1.Value);
                resultFromLongRunning = LongRunning(iterations);
            });
            t1.Start();

            t1.ContinueWith(task =>
            {
                textBox1.AppendText($"Result from long running {resultFromLongRunning}\r\n");
                textBox1.AppendText("---------------------------------------------\r\n");
            });
        }

        private int LongRunning(int iterations)
        {

            textBox1.AppendText($"Starting processing {iterations} iterations\r\n");
            int accumulator = 0;
            for (int i = 1; i <= iterations; i++)
            {
                string message = $@"Iteration {i} of {iterations} on thread Id {Thread.CurrentThread.ManagedThreadId}";
                textBox1.AppendText($"      {message}\r\n");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                accumulator += i;
            }
            textBox1.AppendText("Done\r\n\r\n");

            return accumulator;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
