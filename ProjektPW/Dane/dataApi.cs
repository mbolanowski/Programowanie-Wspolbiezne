using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class AbstractDataApi
    {
        public abstract void CreateBallArea(int height, int width, int numberOfBalls);
        public abstract List<ballData> GetBalls();
        public abstract void StopUpdating();
        public abstract bool IsUpdating();
        public abstract ballArea Area { get; }

        public static AbstractDataApi createApi()
        {
            return new DataApi();
        }

        internal class DataApi : AbstractDataApi
        {
            private ballArea field;
            private bool update;
            private readonly object locked = new();

            public bool Updating
            {
                get { return update; }
                set { update = value; }
            }

            public override ballArea Area
            {
                get { return field; }
            }

            public override void CreateBallArea(int height, int width, int numberOfBalls)
            {
                this.field = new ballArea(height, width, numberOfBalls);
                this.Updating = true;
                List<ballData> balls = GetBalls();

                foreach (ballData ball in balls)
                {
                    Task t = new Task(async () =>
                    {
                        while (update)
                        {
                            lock (locked)
                            {
                                ball.updatePos(ball.newX(), ball.newY());
                            }
                            await Task.Delay(2);
                        }
                    });
                    t.Start();
                }
            }

            public override void StopUpdating()
            {
                this.Updating = false;
            }

            public override bool IsUpdating()
            {
                return this.Updating;
            }

            public override List<ballData> GetBalls()
            {
                return this.field.Balls;
            }
        }
    }
}
