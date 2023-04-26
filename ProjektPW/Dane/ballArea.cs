using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class ballArea : INotifyPropertyChanged
    {
        private double height;
        private double width;
        private readonly List<ballData> balls = new();

        public ballArea(double height, double width, int numberOfBalls)
        {
            this.height = height;
            this.width = width;
            initializeBalls(numberOfBalls);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (height != value)
                {
                    height = value;
                    OnPropertyChanged(nameof(Height));
                }
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (width != value)
                {
                    width = value;
                    OnPropertyChanged(nameof(Width));
                }
            }
        }

        public ballData CreateBall()
        {
            Random r = new Random();
            int x = r.Next(20, (int)this.Width - 20);
            int y = r.Next(20, (int)this.Height - 20);
            int xSpeed = 0;
            int ySpeed = 0;

            while (xSpeed == 0)
            {
                xSpeed = r.Next(-3, 4);
            }
            while (ySpeed == 0)
            {
                ySpeed = r.Next(-3, 4);
            }

            ballData createdBall = new ballData(x, y);

            createdBall.setSpeed(xSpeed, ySpeed);
            return createdBall;
        }
        public void initializeBalls(int numberOfBalls)
        {
            this.balls.Clear();
            for (int i = 0; i < numberOfBalls; i++)
            {
                this.balls.Add(CreateBall());
            }
        }
        public List<ballData> Balls
        {
            get { return balls; }
        }
    }
}
