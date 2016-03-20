namespace OwnLang.AST
{
    public class UnaryExpression : Expression
    {
        private Expression _expr;
        private char _oper;

        public UnaryExpression(char oper, Expression expr)
        {
            _expr = expr;
            _oper = oper;
        }

        public double Eval()
        {
            switch (_oper)
            {
                case '+':
                    return _expr.Eval();
                case '-':
                    return -_expr.Eval();
                default:
                    return _expr.Eval();
            }
        }
    }
}
