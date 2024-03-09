namespace LabSqlParser.Nodes;
sealed record Number(
	string Lexeme
) : IExpression {
	public void AcceptVisitor(INodeVisitor visitor) {
		visitor.VisitNumber(this);
	}
	public string ToFormattedString() {
		return Lexeme;
	}
}
