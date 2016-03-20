using System;
using NUnit.Framework;
using OwnLang.Parser;


namespace OwnLang.Test.Parser
{
    [TestFixture]
    public class ParserTest
    {
        private const double EPS = 0.0000000001;

        [Test]
        public void ParseSimple()
        {
            var tokens = "2 + 2".ToTokens();

            var ast = tokens.ToAST().ToArray();

            Assert.That(ast.Length == 1);
            Assert.That(Math.Abs(4 - ast[0].Eval()) < EPS);
        }

        [Test]
        public void ParseOneNumber()
        {
            var tokens = "12.34".ToTokens();

            var ast = tokens.ToAST().ToArray();

            Assert.That(ast.Length == 1);
            Assert.That(Math.Abs(12.34 - ast[0].Eval()) < EPS);
        }

        [Test]
        public void ParseHexNumber()
        {
            var tokens = "#64".ToTokens();

            var ast = tokens.ToAST().ToArray();

            Assert.That(ast.Length == 1);
            Assert.That(Math.Abs(100 - ast[0].Eval()) < EPS);
        }

        [Test]
        public void ParseUnary()
        {
            var tokens = "-12.34".ToTokens();

            var ast = tokens.ToAST().ToArray();

            Assert.That(ast.Length == 1);
            Assert.That(Math.Abs(-12.34 - ast[0].Eval()) < EPS);
        }

        [Test]
        public void ParseMulti()
        {
            var tokens = "1 + 2 * 4 / (1 + 2 * (2 - 2))".ToTokens();

            var ast = tokens.ToAST().ToArray();

            Assert.That(ast.Length == 1);
            Assert.That(Math.Abs(9 - ast[0].Eval()) < EPS);
        }
    }
}
