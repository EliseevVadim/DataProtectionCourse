namespace lab4
{
    public class ComparisonSolution
    {
        public List<int> Answers { get; set; } = new List<int>();
        public int RootGCD { get; set; }
        public int XCoefficient { get; set; }
        public int YCoefficient { get; set; }

        public override string ToString()
        {
            string root = $"НОД корневого решения: {RootGCD}, X = {XCoefficient}, Y = {YCoefficient}\n" +
                $"Решения:\n";
            foreach (int item in Answers)
            {
                root += item.ToString() + Environment.NewLine;
            }
            return root;
        }
    }
}
