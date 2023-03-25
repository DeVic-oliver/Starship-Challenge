namespace Assets.Scripts.Service
{
    public static class Fibonacci
    {
        private static int _n1 = 0;
        private static int _n2 = 1;

        private static int _fibonacci = 0;
        private static int _count = 0;

        public static long Fibbonacci(int n)
        {
            if(n < 2)
            {
                return 1;
            }

            _fibonacci = n;
            int result = _n1 + _n2;
            return FibbonacciAux(_n1, _n2, result);
        }

        private static long FibbonacciAux(long n1, long n2, long nextTerm)
        {
            _count++;
            if (_count < _fibonacci)
            {
                long result = n1 + n2;
                n1 = n2;
                n2 = result;
                return FibbonacciAux(n1, n2, result);
            }

            return nextTerm;
        }
    }
}