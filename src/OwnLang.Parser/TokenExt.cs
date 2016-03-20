using System.Collections.Generic;
using OwnLang.AST;


namespace OwnLang.Parser
{
    public static class TokenExt
    {
        public static List<Expression> ToAST(this List<Token> tokens)
        {
            return new Parser(tokens).Parse();
        }
    }
}
