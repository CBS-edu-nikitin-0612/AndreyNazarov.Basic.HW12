namespace Task2
{
    internal class Model
    {
        private string[] data;

        public string GetData(int id)
        {
            return data[id];
        }

        public Model()
        {
            data = new string[] { "Data 1", "Data2" };
        }
    }
}
