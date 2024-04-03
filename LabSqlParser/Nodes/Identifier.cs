namespace LabSqlParser.Nodes;
sealed record Identifier(
	string Name
) : IExpression {
	public string ToFormattedString() {
		return Name;
	}
}
