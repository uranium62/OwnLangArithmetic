using NUnit.Framework;
using OwnLang.Parser;

namespace OwnLang.Test.Parser
{
    [TestFixture]
    public class LexerTest
    {
        [Test]
        public void SplitEmpty()
        {
            string str = "";

            var tokens = new Lexer(str).ToTokens().ToArray();

            Assert.That(tokens.Length == 0);
        }

        [Test]
        public void SplitSimple()
        {
            string str = "2 + 2";

            var tokens = new Lexer(str).ToTokens().ToArray();

            Assert.That(tokens.Length == 3);
            Assert.That(tokens[0].Type == TokenType.Number);
            Assert.That(tokens[1].Type == TokenType.Plus);
            Assert.That(tokens[2].Type == TokenType.Number);
        }

        [Test]
        public void SplitMulti()
        {
            string str = "2 + 1 * 9 / 98.22 - 11.3 + 3";

            var tokens = new Lexer(str).ToTokens().ToArray();

            Assert.That(tokens.Length == 11);
            Assert.That(tokens[0].Type == TokenType.Number);
            Assert.That(tokens[1].Type == TokenType.Plus);
            Assert.That(tokens[2].Type == TokenType.Number);
            Assert.That(tokens[3].Type == TokenType.Mult);
            Assert.That(tokens[4].Type == TokenType.Number);
            Assert.That(tokens[5].Type == TokenType.Div);
            Assert.That(tokens[6].Type == TokenType.Number);
            Assert.That(tokens[7].Type == TokenType.Minus);
            Assert.That(tokens[8].Type == TokenType.Number);
            Assert.That(tokens[9].Type == TokenType.Plus);
            Assert.That(tokens[10].Type == TokenType.Number);
        }

        [Test]
        public void SplitMultiLevels()
        {
            var str = "2.3 * ((5 + 3.1) / 9) - 1.5";

            var tokens = new Lexer(str).ToTokens().ToArray();

            Assert.That(tokens.Length == 13);
            Assert.That(tokens[0].Type == TokenType.Number);
            Assert.That(tokens[1].Type == TokenType.Mult);
            Assert.That(tokens[2].Type == TokenType.LParen);
            Assert.That(tokens[3].Type == TokenType.LParen);
            Assert.That(tokens[4].Type == TokenType.Number);
            Assert.That(tokens[5].Type == TokenType.Plus);
            Assert.That(tokens[6].Type == TokenType.Number);
            Assert.That(tokens[7].Type == TokenType.RParen);
            Assert.That(tokens[8].Type == TokenType.Div);
            Assert.That(tokens[9].Type == TokenType.Number);
            Assert.That(tokens[10].Type == TokenType.RParen);
            Assert.That(tokens[11].Type == TokenType.Minus);
            Assert.That(tokens[12].Type == TokenType.Number);
        }

        [Test]
        public void SplitHex()
        {
            var str = "#0F + 1.23";

            var tokens = new Lexer(str).ToTokens().ToArray();

            Assert.That(tokens.Length == 3);
            Assert.That(tokens[0].Type == TokenType.HexNumber);
            Assert.That(tokens[1].Type == TokenType.Plus);
            Assert.That(tokens[2].Type == TokenType.Number);
        }

        [Test]
        public void SplitCrazy()
        {
            string str = "3 23.2 11.1 + - / * tr dm lt 21.1";

            var tokens = new Lexer(str).ToTokens().ToArray();

            Assert.That(tokens.Length == 8);
            Assert.That(tokens[0].Type == TokenType.Number);
            Assert.That(tokens[1].Type == TokenType.Number);
            Assert.That(tokens[2].Type == TokenType.Number);
            Assert.That(tokens[3].Type == TokenType.Plus);
            Assert.That(tokens[4].Type == TokenType.Minus);
            Assert.That(tokens[5].Type == TokenType.Div);
            Assert.That(tokens[6].Type == TokenType.Mult);
            Assert.That(tokens[7].Type == TokenType.Number);
        }
    }
}
