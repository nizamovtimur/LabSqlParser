namespace LabSqlParser.Nodes;
sealed record Parentheses(
	IExpression Child
) : IExpression {
	public string ToFormattedString() {
		return $"({Child.ToFormattedString()})";
	}
}
