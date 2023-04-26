using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ViewModel
{
    public class createBall : INotifyPropertyChanged
    {
        private ObservableCollection<ballModel> balls = new();
        private AbstractModelApi api;
        private int numberOfBalls;


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public createBall()
        {
            startMove = new StartMove(this);
            stopMove = new StopMove(this);
            this.api = AbstractModelApi.API();
        }

        public ObservableCollection<ballModel> Balls
        {
            get { return balls; }
            set
            {
                if (balls != value)
                {
                    balls = value;
                    OnPropertyChanged(nameof(balls));
                }
            }
        }
        public int NumberOfBalls
        {
            get {
                    return numberOfBalls;
            }
            set
            {
                    if (numberOfBalls != value)
                    {
                        numberOfBalls = value;
                        OnPropertyChanged(nameof(numberOfBalls));
                    }
                
            }
        }
        public void StartUpdating()
        {
            if (numberOfBalls != 0)
            {
                this.api.StartUpdating(numberOfBalls);
                this.Balls = api.GetBalls();
            }
        }

        public void StopUpdating()
        {
            this.api.StopUpdating();
        }

        public bool IsUpdating()
        {
            return this.api.IsUpdating();
        }

        public StartMove startMove { get; set; }
        public StopMove stopMove { get; set; }
    }
}