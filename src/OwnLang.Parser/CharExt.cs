namespace OwnLang.Parser
{
    public static class CharExt
    {
        public static bool IsOperator(this char ch)
        {
            switch (ch)
            {
                case '*':
                case '/':
                case '-':
                case '+':
                case '(':
                case ')':
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsDigit(this char ch)
        {
            return char.IsDigit(ch);
        }

        public static bool IsDouble(this char ch)
        {
            return ch.IsDigit() || ch.IsPoint();
        }

        public static bool IsHexDigit(this char ch)
        {
            return ch.IsDigit() ||
                   ch == 'a' || ch == 'A' ||
                   ch == 'b' || ch == 'B' ||
                   ch == 'c' || ch == 'C' ||
                   ch == 'd' || ch == 'D' ||
                   ch == 'e' || ch == 'E' ||
                   ch == 'f' || ch == 'F';
        }

        public static bool IsPoint(this char ch)
        {
            return ch == '.';
        }

        public static bool IsHex(this char ch)
        {
            return ch == '#';
        }
    }
}
