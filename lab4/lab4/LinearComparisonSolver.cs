namespace lab4
{
    public class LinearComparisonSolver
    {
        private int _a;
        private int _b;
        private int _n;

        public LinearComparisonSolver(int a, int b, int n)
        {
            _a = a;
            _b = b;
            _n = n;
        }

        public ComparisonSolution SolveComparison()
        {
            List<int> answers = new List<int>();
            int x = 0, y = 0, rootAnswer;
            int n = _n;
            int g = GCD(_a, n, ref x, ref y);
            if (_b % g != 0)
                throw new InvalidOperationException("Решений нет");
            while (true)
            {
                _a /= g;
                _b /= g;
                n /= g;
                g = GCD(_a, n, ref x, ref y);
                if (g == 1)
                {
                    rootAnswer = (x * _b) % n;
                    for (int i = rootAnswer; i < _n; i += n)
                    {
                        if (i < _n && i >= 0)
                            answers.Add(i);
                    }
                    return new ComparisonSolution
                    {
                        Answers = answers,
                        RootGCD = 1,
                        XCoefficient = x,
                        YCoefficient = y
                    };
                }
            }
        }

        private int GCD(int a, int b, ref int x, ref int y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }
            int x1 = 1, y1 = 1;
            int gcd = GCD(b % a, a, ref x1, ref y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return gcd;

        }
    }
}
