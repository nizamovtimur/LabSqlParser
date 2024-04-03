namespace LabSqlParser.Nodes;
sealed record Identifier(
	string Name
) : IExpression {
	public void AcceptVisitor(INodeVisitor visitor) {
		visitor.VisitIdentifier(this);
	}
	public string ToFormattedString() {
		return Name;
	}
}
