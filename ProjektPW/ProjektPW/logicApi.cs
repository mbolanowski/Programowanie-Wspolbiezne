using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    public abstract class AbstractLogicApi
    {
        public abstract List<BallLogic> GetBalls();
        public abstract void StartUpdating(int height, int width, int numberOfBalls);
        public abstract void StopUpdating();
        public abstract bool IsUpdating();

        public static AbstractLogicApi API(AbstractDataApi abstractDataApi = null)
        {
            return new LogicApi(abstractDataApi);
        }

        internal class LogicApi : AbstractLogicApi
        {
            private List<BallLogic> balls = new();
            private AbstractDataApi dataApi;

            public LogicApi(AbstractDataApi abstractDataApi = null)
            {
                if (abstractDataApi == null)
                {
                    this.dataApi = AbstractDataApi.createApi();
                }
                else
                {
                    this.dataApi = abstractDataApi;
                }
            }
            public override List<BallLogic> GetBalls()
            {
                return this.balls;
            }

            public override void StartUpdating(int height, int width, int numberOfBalls)
            {
                this.dataApi.CreateBallArea(height, width, numberOfBalls);
                foreach (ballData ball in this.dataApi.GetBalls())
                {
                    this.balls.Add(new BallLogic(ball));
                    ball.PropertyChanged += touchBorder;
                }
            }
            public override void StopUpdating()
            {
                this.dataApi.StopUpdating();
                this.balls.Clear();
            }

            public override bool IsUpdating()
            {
                return dataApi.IsUpdating();
            }

            public void touchBorder(object sender, PropertyChangedEventArgs e)
            {
                ballData ball = (ballData)sender;
                if (e.PropertyName == nameof(ball.X) || e.PropertyName == nameof(ball.Y))
                {
                    Random r = new Random();
                    if (ball.X <= 0)
                    {
                        ball.setSpeed(r.Next(1, 4), ball.YSpeed);
                    }
                    if (ball.Y <= 0)
                    {
                        ball.setSpeed(ball.XSpeed, r.Next(1, 4));
                    }
                    if (ball.X >= this.dataApi.Area.Width - ball.Radius)
                    {
                        ball.setSpeed(r.Next(-4, -1), ball.YSpeed);
                    }
                    if (ball.Y >= this.dataApi.Area.Height - ball.Radius)
                    {
                        ball.setSpeed(ball.XSpeed, r.Next(-4, -1));
                    }
                }
            }
        }
    }
}
