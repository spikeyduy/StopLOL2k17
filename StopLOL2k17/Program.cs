﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace StopLOL2k17
{
    // Simple program to stop the League of legends program
    class Program
    {
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.Run(new Form());  
            KillApp();
        } 

        static void KillApp()
        {
            Console.WriteLine("This program will always be looking to see if " +
                "League of Legends is running, and if it is, to stop it.");

            // Method to create a lasting program that doesn't suck up
            // all the CPU. One method is to use WaitHandle
            bool createdNew; // make sure there is a new waitHandle being made
            var waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, "1111", out createdNew);
            var signaled = false;
            int amount = 0;
            // start a new thread that will kill the process
            //var timer = new Timer(OnTimerElapsed, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            do
            {
                signaled = waitHandle.WaitOne(TimeSpan.FromSeconds(10));
                if (procs != null)
                {
                    foreach (Process p in procs)
                    {
                        p.Kill();
                        amount++;
                        if (amount > 1)
                        {
                            Console.WriteLine("Killed " + amount + " Apps");
                        }
                        else
                        {
                            Console.WriteLine("Killed 1 App");
                        }
                    }
                }
            } while (!signaled);
        }

        // This should give a pop up menu every time user tries to close it 
        static void FormCloser(object sender, EventArgs e)
        {
            Console.WriteLine("exit");
        }
    }
}
