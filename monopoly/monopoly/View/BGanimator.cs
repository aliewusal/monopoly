using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace monopoly.View
{
    public class BGanimator
    {
        private Image BG;
        private Task task;
        CancellationTokenSource cancelTokenSource;
        CancellationToken token;
        public BGanimator(Image bg)
        {
            BG = bg;
            task = new Task(() => someF());
        }
        public void animationStart()
        {
            if (task.Status != TaskStatus.Running)
            {
                BG.ScaleTo(1.3, 5000);
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    task.Dispose();
                    cancelTokenSource.Dispose();
                    task = new Task(() => someF());
                }
                cancelTokenSource = new CancellationTokenSource();
                token = cancelTokenSource.Token;
                task.Start();
            } else
            {
                cancelTokenSource.Dispose();
                cancelTokenSource = new CancellationTokenSource();
                token = cancelTokenSource.Token;
            }
        }
        private void someF()
        {
            //BG.Scale = 1.3;
            while (true)
            {
                BG.TranslateTo(-45, 0, 5000, Easing.SinInOut).Wait();

                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана токеном");
                    return;
                }

                BG.TranslateTo(0, 45, 5000, Easing.SinInOut).Wait();
                BG.TranslateTo(45, 0, 5000, Easing.SinInOut).Wait();

                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана токеном");
                    return;
                }

                BG.TranslateTo(0, -45, 5000, Easing.SinInOut).Wait();
            }
        }
        public void animationStop()
        {
            BG.ScaleTo(1.2, 250);
            cancelTokenSource.Cancel();
        }


    }
}
