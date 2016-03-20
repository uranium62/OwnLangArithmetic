namespace OwnLang.AST
{
    public class BinaryExpression : Expression
    {
        private Expression _expr1;
        private Expression _expr2;
        private char _oper;

        public BinaryExpression(char oper, Expression expr1, Expression expr2)
        {
            _expr1 = expr1;
            _expr2 = expr2;
            _oper = oper;
        }

        public double Eval()
        {
            switch (_oper)
            {
                case '+':
                    return _expr1.Eval() + _expr2.Eval();
                case '-':
                    return _expr1.Eval() - _expr2.Eval();
                case '/':
                    return _expr1.Eval() / _expr2.Eval();
                case '*':
                    return _expr1.Eval() * _expr2.Eval();
                default:
                    return _expr1.Eval() + _expr2.Eval();
            }
        }
    }
}
