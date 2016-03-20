using System.Diagnostics.CodeAnalysis;

namespace OwnLang.AST
{
    public interface Expression
    {
        double Eval();
    }
}
