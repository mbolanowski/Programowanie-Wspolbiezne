using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Text.Json;

namespace Dane
{
    internal class Log
    {
        private string directory = "C:\\WspolbiezneRepo\\ProjektPW";
        private Timer timer;
        private List<ballData> balls;

        public Log(List<ballData> balls)
        {
            this.balls = balls;
            timer = new Timer(1000);
            timer.Elapsed += TimerElapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void TimerElapsed(Object source, ElapsedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(directory + "\\Log.txt", true))
            {
                string logMess = ("Log: " + e.SignalTime + " ");
                foreach (ballData ball in balls)
                {
                    writer.WriteLine(logMess + JsonSerializer.Serialize(ball));
                }
            }
        }

        public void Stop()
        {
            timer.Stop();
        }


    }
}
