using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
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
            private readonly object locked = new object();

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
                    ball.PropertyChanged += ballCollision;
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
                        ball.setSpeed(Math.Abs(ball.XSpeed), ball.YSpeed);
                        ball.X = 1;
                    }
                    if (ball.Y <= 0)
                    {
                        ball.setSpeed(ball.XSpeed, Math.Abs(ball.YSpeed));
                        ball.Y = 1;
                    }
                    if (ball.X >= this.dataApi.Area.Width - ball.Radius)
                    {
                        ball.setSpeed(-Math.Abs(ball.XSpeed), ball.YSpeed);
                        ball.X = dataApi.Area.Width - ball.Radius - 1;

                    }
                    if (ball.Y >= this.dataApi.Area.Height - ball.Radius)
                    {
                        ball.setSpeed(ball.XSpeed, -Math.Abs(ball.YSpeed));
                        ball.Y = dataApi.Area.Height - ball.Radius - 1;
                    }
                }
            }

            private SemaphoreSlim semaphore = new SemaphoreSlim(1);

            public async void ballCollision(object sender, PropertyChangedEventArgs e)
            {
                ballData ball1 = (ballData)sender;
                if (e.PropertyName == nameof(ball1.X) || e.PropertyName == nameof(ball1.Y))
                {
                    foreach (ballData ball2 in dataApi.GetBalls())
                    {
                        if (ball2 == ball1)
                        {
                            continue;
                        }

                        double ball2XSpeed, ball1XSpeed, ball2YSpeed, ball1YSpeed;
                        double ball1X = ball1.X + ball1.Radius / 2;
                        double ball1Y = ball1.Y + ball1.Radius / 2;
                        double ball2X = ball2.X + ball2.Radius / 2;
                        double ball2Y = ball2.Y + ball2.Radius / 2;

                        if (Math.Pow(Math.Pow((ball1X + ball1.XSpeed) - (ball2X + ball2.XSpeed), 2) + Math.Pow(((ball1Y + ball1.YSpeed) - (ball2Y + ball2.YSpeed)), 2), 0.5) < ((ball1.Radius / 2) + (ball2.Radius / 2)))
                        {
                            if (ball1.Weight == ball2.Weight)
                            {
                                ball1XSpeed = ball2.XSpeed;
                                ball1YSpeed = ball2.YSpeed;
                                ball2XSpeed = ball1.XSpeed;
                                ball2YSpeed = ball1.YSpeed;
                            }
                            else 
                            {
                                ball1XSpeed =(ball1.XSpeed * (ball1.Weight - ball2.Weight) + (ball2.Weight * ball2.XSpeed * 2)) / (ball1.Weight + ball2.Weight);
                                ball1YSpeed = (ball1.YSpeed * (ball1.Weight - ball2.Weight) + (ball2.Weight * ball2.YSpeed * 2)) / (ball1.Weight + ball2.Weight);
                                ball2XSpeed = (ball2.XSpeed * (ball2.Weight - ball1.Weight) + (ball1.Weight * ball1.XSpeed * 2)) / (ball2.Weight + ball1.Weight);
                                ball2YSpeed = (ball2.YSpeed * (ball2.Weight - ball1.Weight) + (ball1.Weight * ball1.YSpeed * 2)) / (ball2.Weight + ball1.Weight);
                            }
                            await semaphore.WaitAsync();

                            try
                            {
                                ball1.setSpeed(ball1XSpeed, ball1YSpeed);
                                ball2.setSpeed(ball2XSpeed, ball2YSpeed);
                            }
                            finally
                            {
                                semaphore.Release();
                            }
                        }
                    }
                }
            }

        }
    }
}
