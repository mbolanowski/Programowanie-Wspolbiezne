using System.ComponentModel;

namespace Dane
{
    public class ballData : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double radius;
        private double xSpeed;
        private double ySpeed;
        private double weight;

        public ballData(double x, double y, double weight)
        {
            this.x = x;
            this.y = y;
            this.weight = weight;
            radius = 15;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public double Radius
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

        public double X
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

        public double Y
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


        public double XSpeed
        {
            get { return xSpeed; }
            set
            {
                if (xSpeed != value)
                {
                    xSpeed = value;
                    OnPropertyChanged(nameof(XSpeed));
                }
            }
        }

        public double YSpeed
        {
            get { return ySpeed; }
            set
            {
                if (ySpeed != value)
                {
                    ySpeed = value;
                    OnPropertyChanged(nameof(YSpeed));
                }
            }
        }
        public double Weight
        {
            get { return weight; }
        }

        public double newX()
        {
            return X + XSpeed;
        }
        public double newY()
        {
            return Y + YSpeed;
        }

        public void updatePos(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void setSpeed(double x, double y)
        {
            XSpeed = x;
            YSpeed = y;
        }


    }
}