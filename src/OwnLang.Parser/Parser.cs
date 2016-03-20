using System;
using System.Collections.Generic;
using System.Globalization;
using OwnLang.AST;


namespace OwnLang.Parser
{
    public class Parser
    {
        private readonly List<Token> _tokens;
        private int _pos;

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
            _pos = 0;
        }

        public List<Expression> Parse()
        {
            List<Expression> res = new List<Expression>();

            while (!Match(TokenType.EOF))
            {
                res.Add(Expression());
            }

            return res;
        }

        private Expression Expression()
        {
            return Additive();
        }

        private Expression Additive()
        {
            Expression res = Multiplicative();

            while (true)
            {
                if (Match(TokenType.Plus))
                {
                    res = new BinaryExpression('+', res, Multiplicative());
                    continue;
                }
                if (Match(TokenType.Minus))
                {
                    res = new BinaryExpression('-', res, Multiplicative());
                    continue;
                }
                break;
            }

            return res;
        }

        private Expression Multiplicative()
        {
            Expression res = Unary();

            while (true)
            {
                if (Match(TokenType.Mult))
                {
                    res = new BinaryExpression('*', res, Unary());
                    continue;
                }
                if (Match(TokenType.Div))
                {
                    res = new BinaryExpression('/', res, Unary());
                    continue;
                }
                break;
            }

            return res;
        }

        private Expression Unary()
        {
            if (Match(TokenType.Minus))
            {
               return new UnaryExpression('-', Primary());
            }

            if (Match(TokenType.Plus))
            {
                return Primary();
            }

            return Primary();
        }

        private Expression Primary()
        {
            var cur = Get(0);

            if (Match(TokenType.Number))
            {
                return new NumberExpression(double.Parse(cur.Value, CultureInfo.InvariantCulture));
            }
            if (Match(TokenType.HexNumber))
            {
                return new NumberExpression(ulong.Parse(cur.Value, NumberStyles.AllowHexSpecifier));
            }
            if (Match(TokenType.LParen))
            {
                Expression exp = Expression();
                Match(TokenType.RParen);
                return exp;
            }

            throw new InvalidOperationException("unknow expression");
        }

        private bool Match(TokenType type)
        {
            Token cur = Get(0);

            if (type != cur.Type)
            {
                return false;
            }

            _pos++;

            return true;
        }

        private Token Get(int relPosition)
        {
            int pos = _pos + relPosition;

            if (pos >= _tokens.Count)
            {
                return new Token(TokenType.EOF, "");
            }

            return _tokens[pos];
        }
    }
}
