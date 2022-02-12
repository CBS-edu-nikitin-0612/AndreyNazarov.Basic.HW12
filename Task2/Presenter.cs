namespace Task2
{
    internal class Presenter
    {
        private Model model;
        private View view;
        public event EventRun eventRun = null;

        public Presenter()
        {
            model = new Model();
            view = new View();
            eventRun += Run;
        }

        private void Run()
        {
            string data = model.GetData(1);
            view.PrintData(data);
        }

        public void InvokeRun()
        {
            eventRun.Invoke();
        }
    }
}
