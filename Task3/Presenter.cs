using System;
using System.Threading;

namespace Task3
{
    class Presenter
    {
        private readonly MainWindow view;
        private readonly Model model;
        private Thread thread;
        private bool isStop;
        public Presenter(MainWindow view)
        {
            this.view = view;
            model = new Model(this);
            view.Start += new EventHandler(InvokeStart);
            view.Stop += new EventHandler(InvokeStop);
            view.Reset += new EventHandler(InvokeReset);
        }
        public void InvokeStart(object sender, EventArgs e)
        {
            model.ArrangeNewTimer(view.TextBoxStart.Text);
            view.ProgressBar.Maximum = model.Timer.TotalSeconds;
            thread = new Thread(Run);
            thread.Start();
        }
        public void InvokeStop(object sender, EventArgs e)
        {
            isStop = true;
        }
        public void InvokeReset(object sender, EventArgs e)
        {
            model.Reset();
        }

        public void CatchException(Exception e)
        {
            view.PrintException(e.Message);
        }        

        private void Run()
        {
            while (true)
            {
                Thread.Sleep(100); // Почему без этой строчки все зависает?
                if (isStop)
                {
                    view.UpdateProgressBar(0);
                    view.UpdateTextBoxElapsed("");
                    isStop = false;
                    break;
                }

                if (model.ElapsedTimeS() <= 0)
                {
                    view.UpdateProgressBar(0);
                    view.UpdateTextBoxElapsed("");
                    break;
                }

                view.UpdateProgressBar(model.ElapsedTimeS());
                view.UpdateTextBoxElapsed(model.ElapsedTimeS().ToString());
            }
        }
    }
}
