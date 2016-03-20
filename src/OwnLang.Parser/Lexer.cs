using System.Collections.Generic;
using System.Text;

namespace OwnLang.Parser
{
    public class Lexer
    {
        private string _input;
        private List<Token> _tokens;
        private int _pos;

        public Lexer(string input)
        {
            _input = input;
            _pos = 0;
            _tokens = new List<Token>();
        }

        public List<Token> ToTokens()
        {
            while (_pos < _input.Length)
            {
                char cur = Peek(0);

                if (cur.IsDigit())
                {
                    TokenizeNumber();
                }
                else if (cur.IsHex())
                {
                    Next();
                    TokenizeHexNumber();
                }
                else if (cur.IsOperator())
                {
                    TokenizeOperator();
                }
                else
                {
                    Next();
                }
            }

            return _tokens;
        }

        private void TokenizeNumber()
        {
            StringBuilder buf = new StringBuilder();
            var cur = Peek(0);

            while (cur.IsDouble())
            {
                buf.Append(cur);
                cur = Next();
            }

            Add(TokenType.Number, buf.ToString());
        }

        private void TokenizeHexNumber()
        {
            StringBuilder buf = new StringBuilder();
            var cur = Peek(0);

            while (cur.IsHexDigit())
            {
                buf.Append(cur);
                cur = Next();
            }

            Add(TokenType.HexNumber, buf.ToString());
        }

        private void TokenizeOperator()
        {
            var cur = Peek(0);

            switch (cur)
            {
                case '*':
                    Add(TokenType.Mult);
                    break;
                case '/':
                    Add(TokenType.Div);
                    break;
                case '-':
                    Add(TokenType.Minus);
                    break;
                case '+':
                    Add(TokenType.Plus);
                    break;
                case '(':
                    Add(TokenType.LParen);
                    break;
                case ')':
                    Add(TokenType.RParen);
                    break;
            }

            Next();
        }

        private char Next()
        {
            _pos++;

            return Peek(0);
        }

        private char Peek(int relPosition)
        {
            int pos = _pos + relPosition;

            if (pos >= _input.Length)
            {
                return '\0';
            }

            return _input[pos];
        }
        
        private void Add(TokenType type)
        {
            _tokens.Add(new Token(type, ""));
        }

        private void Add(TokenType type, string val)
        {
            _tokens.Add(new Token(type, val));
        }
    }
}
