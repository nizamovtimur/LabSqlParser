namespace LabSqlParser.Nodes;
sealed record Binary(
	IExpression Left,
	BinaryOperator Op,
	IExpression Right
) : IExpression {
	public void AcceptVisitor(INodeVisitor visitor) {
		visitor.VisitBinary(this);
	}
	public string ToFormattedString() {
		return Op switch {
			BinaryOperator.And => $"{Left.ToFormattedString()} AND {Right.ToFormattedString()}",
			_ => "",
		};
	}
}
