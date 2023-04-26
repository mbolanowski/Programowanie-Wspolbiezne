using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class StopMove : ICommand
    {
        createBall generateBalls;
        public StopMove(createBall generateBalls)
        {
            this.generateBalls = generateBalls;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (this.generateBalls.IsUpdating())
            {
                this.generateBalls.StopUpdating();
            }

        }
    }
}
