namespace OwnLang.AST
{
    public class NumberExpression : Expression
    {
        private double _val;

        public NumberExpression(double val)
        {
            _val = val;
        }

        public double Eval()
        {
            return _val;
        }
    }
}
