namespace LabSqlParser.Nodes;
sealed record Parentheses(
	IExpression Child
) : IExpression {
	public void AcceptVisitor(INodeVisitor visitor) {
		visitor.VisitParentheses(this);
	}
	public string ToFormattedString() {
		return $"({Child.ToFormattedString()})";
	}
}
