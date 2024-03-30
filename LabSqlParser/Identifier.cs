namespace LabSqlParser;
sealed record Identifier(
	string Name
) : IExpression {
}
