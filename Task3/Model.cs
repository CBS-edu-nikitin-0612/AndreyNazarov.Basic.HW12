using System;

namespace Task3
{
    class Model
    {
        private readonly Presenter presenter;
        public TimeSpan Timer { get; private set; }
        private TimeSpan elapsedTime;
        private DateTime currentElapsedTime;
        public Model(Presenter presenter)
        {
            this.presenter = presenter;
        }
        public void ArrangeNewTimer(string timer)
        {
            try
            {
                Timer = TimeSpan.Parse(timer);
                currentElapsedTime = DateTime.Now + Timer;
            }
            catch (Exception e)
            {
                presenter.CatchException(e);
            }
        }

        public double ElapsedTimeS()
        {
            elapsedTime = currentElapsedTime - DateTime.Now;
            return Math.Round(elapsedTime.TotalSeconds);
        }
        public void Reset()
        {
            elapsedTime = Timer;
            currentElapsedTime = DateTime.Now + Timer;
        }
    }
}
