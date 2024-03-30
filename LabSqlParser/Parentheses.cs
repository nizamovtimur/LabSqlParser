namespace LabSqlParser;
sealed record Parentheses(
	IExpression Child
) : IExpression {
}
