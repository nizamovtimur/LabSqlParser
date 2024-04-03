namespace LabSqlParser.Nodes;
sealed record Binary(
	IExpression Left,
	BinaryOperator Op,
	IExpression Right
) : IExpression {
	public string ToFormattedString() {
		return Op switch {
			BinaryOperator.And => $"{Left.ToFormattedString()} AND {Right.ToFormattedString()}",
			_ => "",
		};
	}
}
