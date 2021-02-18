using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSharpier.Core
{
    public partial class Printer
    {
        private Doc PrintUsingStatementSyntax(UsingStatementSyntax node)
        {
            var parts = new Parts(
                this.PrintSyntaxToken(node.UsingKeyword, " "),
                this.PrintSyntaxToken(node.OpenParenToken),
                node.Declaration != null ? this.PrintVariableDeclarationSyntax(node.Declaration) : null,
                node.Expression != null ? this.Print(node.Expression) : null,
                this.PrintSyntaxToken(node.CloseParenToken)
            );
            var statement = this.Print(node.Statement);
            if (node.Statement is UsingStatementSyntax) {
                parts.Push(HardLine, statement);
            } else if (node.Statement is BlockSyntax) {
                parts.Push(statement);
            } else {
                parts.Push(Indent(Concat(HardLine, statement)));
            }
            return Concat(parts);
        }
    }
}