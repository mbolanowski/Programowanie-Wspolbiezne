using System.ComponentModel;

namespace Dane
{
    public class ballData : INotifyPropertyChanged
    {
        private int x;
        private int y;
        private int radius;
        private int xSpeed;
        private int ySpeed;

        public ballData(int x, int y)
        {
            this.x = x;
            this.y = y;
            radius = 30;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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


        public int XSpeed
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

        public int YSpeed
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

        public void updatePos(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void setSpeed(int x, int y)
        {
            XSpeed = x;
            YSpeed = y;
        }


    }
}