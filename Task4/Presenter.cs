using System;

namespace Task4
{
    internal class Presenter
    {
        private readonly MainWindow view;
        private readonly Model model;

        public Presenter(MainWindow view)
        {
            model = new Model(this);
            this.view = view;
            this.view.Add += new EventHandler(Add);
            this.view.Sub += new EventHandler(Sub);
            this.view.Div += new EventHandler(Div);
            this.view.Mult += new EventHandler(Mult);
            this.view.Enter += new EventHandler(Enter);
        }
        private void Add(object sender, EventArgs e)
        {
            model.PrepareOperation(view.GetOperand(), Model.Operation.Addtional);
        }
        private void Sub(object sender, EventArgs e)
        {
            model.PrepareOperation(view.GetOperand(), Model.Operation.Subtraction);
        }
        private void Div(object sender, EventArgs e)
        {
            model.PrepareOperation(view.GetOperand(), Model.Operation.Division);
        }
        private void Mult(object sender, EventArgs e)
        {
            model.PrepareOperation(view.GetOperand(), Model.Operation.Multiplication);
        }
        private void Enter(object sender, EventArgs e)
        {
            model.operandRight = view.GetOperand();
            double? result = null;
            try
            {
                result = model.GetResult();
            }
            catch (Exception exception)
            {
                view.TextBlockExceprion.Text = exception.Message;
            }

            if (result != null)
            {
                view.TextBoxMain.Text = result.ToString();
                view.TextBlockExceprion.Text = "";
            }
        }
    }
}
