namespace LabSqlParser;
sealed record Values(
	IExpression Expression,
	SortExpression? SortExpression,
	bool LimitAll
) : INode {
}
