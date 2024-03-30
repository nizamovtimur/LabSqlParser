namespace LabSqlParser;
sealed record Binary(
	IExpression Left,
	BinaryOperator Op,
	IExpression Right
) : IExpression {
}
