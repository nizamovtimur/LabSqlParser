namespace LabSqlParser;
sealed record Number(
	string Lexeme
) : IExpression {
}
