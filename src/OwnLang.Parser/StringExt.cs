using System.Collections.Generic;

namespace OwnLang.Parser
{
    public static class StringExt
    {
        public static List<Token> ToTokens(this string str)
        {
            return new Lexer(str).ToTokens();
        } 

    }
}
