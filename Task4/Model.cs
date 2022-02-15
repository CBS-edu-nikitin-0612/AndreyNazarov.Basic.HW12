using System;

namespace Task4
{
    internal class Model
    {
        private Presenter presenter;
        public double? operandLeft;
        public double? operandRight;
        public Model(Presenter presenter)
        {
            this.presenter = presenter;
        }
        public Operation? CurrentOperation { get; set; } = null;

        public enum Operation
        {
            Addtional,
            Subtraction,
            Division,
            Multiplication
        }
        public double? GetResult()
        {
            double? result = null;
            if (CurrentOperation != null)
            {
                switch (CurrentOperation)
                {
                    case Operation.Addtional:
                        result = operandLeft + operandRight;
                        break;
                    case Operation.Subtraction:
                        result = operandLeft - operandRight;
                        break;
                    case Operation.Division:
                        if (operandRight == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        result = operandLeft / operandRight;
                        break;
                    case Operation.Multiplication:
                        result = operandLeft * operandRight;
                        break;
                }
            }
            return result;
        }
        public void PrepareOperation(double? operandLeft, Operation operation)
        {
            if (operandLeft != null)
            {
                this.operandLeft = operandLeft;
                CurrentOperation = operation;
            }
        }
    }
}
