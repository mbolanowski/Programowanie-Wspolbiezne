﻿using System.ComponentModel;
using Logika;

namespace Model
{
    public class ballModel : INotifyPropertyChanged
    {
        private int x;
        private int y;
        private int radius;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                if (y != value)
                {
                    y = value;
                    OnPropertyChanged(nameof(Y));
                }
            }
        }

        public int Radius
        {
            get { return radius; }
            set
            {
                if (radius != value)
                {
                    radius = value;
                    OnPropertyChanged(nameof(Radius));
                }
            }
        }

        public ballModel(BallLogic ball)
        {
            this.x = ball.X;
            this.y = ball.Y;
            this.radius = ball.Radius;
            ball.PropertyChanged += changePos;
        }

        private void changePos(object sender, PropertyChangedEventArgs e)
        {
            BallLogic ball = (BallLogic)sender;
            if (e.PropertyName == nameof(ball.X)){this.X = ball.X;}
            if (e.PropertyName == nameof(ball.Y)) { this.Y = ball.Y; }
        }
    }
}