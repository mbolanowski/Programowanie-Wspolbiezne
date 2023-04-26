using Logika;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class AbstractModelApi
    {
        public static AbstractModelApi API(AbstractLogicApi abstractLogicApi = null)
        {
            return new ModelApi();
        }

        public abstract void StartUpdating(int amountOfBalls);
        public abstract void StopUpdating();
        public abstract bool IsUpdating();
        public abstract ObservableCollection<ballModel> GetBalls();


        public class ModelApi : AbstractModelApi
        {
            private ObservableCollection<ballModel> balls = new();
            private AbstractLogicApi logicApi = AbstractLogicApi.API(null);

            public ModelApi(AbstractLogicApi abstractLogicApi = null)
            {
                if (abstractLogicApi == null)
                {
                    this.logicApi = AbstractLogicApi.API();
                }
                else
                {
                    this.logicApi = abstractLogicApi;
                }
            }

            public ObservableCollection<ballModel> Balls
            {
                get { return balls; }
                set { balls = value; }
            }

            public override void StartUpdating(int amountOfBalls)
            {
                logicApi.StartUpdating(500, 500, amountOfBalls);
            }

            public override void StopUpdating()
            {
                logicApi.StopUpdating();
            }

            public override bool IsUpdating()
            {
                return logicApi.IsUpdating();
            }

            public override ObservableCollection<ballModel> GetBalls()
            {
                List<BallLogic> logicBalls = logicApi.GetBalls();
                Balls.Clear();
                foreach (BallLogic ball in logicBalls)
                {
                    Balls.Add(new ballModel(ball));
                }
                return Balls;
            }

        }
    }
}
