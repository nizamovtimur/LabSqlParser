using LabSqlParser.Nodes;
namespace LabSqlParser;
interface INodeVisitor {
	void VisitValues(Values values);
	void VisitSortExpression(SortExpression sortExpression);
	void VisitBinary(Binary binary);
	void VisitParentheses(Parentheses parentheses);
	void VisitIdentifier(Identifier identifier);
	void VisitNumber(Number number);
}
