using LabSqlParser.Nodes;
using System.IO;
namespace LabSqlParser;
sealed class DebugPrintingVisitor : INodeVisitor {
	readonly TextWriter output;
	int indent;
	public DebugPrintingVisitor(TextWriter output, int indent = 0) {
		this.output = output;
		this.indent = indent;
	}
	public void WriteLine(INode node) {
		WriteNode(node);
		Write("\n");
	}
	void WriteNode(INode node) {
		node.AcceptVisitor(this);
	}
	void Write(string s) {
		output.Write(s);
	}
	void WriteIndent() {
		Write(new string(' ', indent * 2));
	}
	void INodeVisitor.VisitValues(Values values) {
		Write($"new {nameof(Values)}(\n");
		{
			indent += 1;
			WriteIndent();
			WriteNode(values.Expression);
			Write(",\n");
			WriteIndent();
			if (values.SortExpression is not null) {
				WriteNode(values.SortExpression);
			}
			else {
				Write($"{nameof(values.SortExpression)}: null");
			}
			Write(",\n");
			WriteIndent();
			if (values.LimitAll) {
				Write($"{nameof(values.LimitAll)}: true");
			}
			else {
				Write($"{nameof(values.LimitAll)}: false");
			}
			Write("\n");
			indent -= 1;
		}
		WriteIndent();
		Write(")");
	}
	void INodeVisitor.VisitSortExpression(SortExpression sortExpression) {
		Write($"new {nameof(SortExpression)}(\n");
		{
			indent += 1;
			WriteIndent();
			WriteNode(sortExpression.Expression);
			Write(",\n");
			WriteIndent();
			if (sortExpression.Direction is null) {
				Write($"{nameof(sortExpression.Direction)}: null");
			}
			else {
				Write($"{nameof(SortDirection)}.{sortExpression.Direction}");
			}
			Write("\n");
			indent -= 1;
		}
		WriteIndent();
		Write(")");
	}
	void INodeVisitor.VisitBinary(Binary binary) {
		Write($"new {nameof(Binary)}(\n");
		{
			indent += 1;
			WriteIndent();
			WriteNode(binary.Left);
			Write(",\n");
			WriteIndent();
			Write($"{nameof(BinaryOperator)}.{binary.Op}");
			Write(",\n");
			WriteIndent();
			WriteNode(binary.Right);
			Write("\n");
			indent -= 1;
		}
		WriteIndent();
		Write(")");
	}
	void INodeVisitor.VisitParentheses(Parentheses parenthesis) {
		Write($"new {nameof(Parentheses)}(\n");
		{
			indent += 1;
			WriteIndent();
			WriteNode(parenthesis.Child);
			Write("\n");
			indent -= 1;
		}
		WriteIndent();
		Write(")");
	}
	void INodeVisitor.VisitIdentifier(Identifier identifier) {
		Write($"new {nameof(Identifier)}(\"{identifier.Name}\")");
	}
	void INodeVisitor.VisitNumber(Number number) {
		Write($"new {nameof(Number)}(\"{number.Lexeme}\")");
	}
}
