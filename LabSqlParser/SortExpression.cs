namespace LabSqlParser;
sealed record SortExpression(
	IExpression Expression,
	SortDirection? Direction
) : INode {
}
