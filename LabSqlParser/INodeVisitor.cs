using LabSqlParser.Nodes;
namespace LabSqlParser;
interface INodeVisitor {
	void VisitValues(Values values);
	void VisitSortExpression(SortExpression sortExpression);
	void VisitBinary(Binary binary);
	void VisitNumber(Number number);
	void VisitIdentifier(Identifier identifier);
	void VisitParentheses(Parentheses parentheses);
}
