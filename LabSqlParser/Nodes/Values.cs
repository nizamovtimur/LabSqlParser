namespace LabSqlParser.Nodes;
sealed record Values(
	IExpression Expression,
	SortExpression? SortExpression,
	bool LimitAll
) : INode {
	public string ToFormattedString() {
		if (SortExpression is null) {
			return $"VALUES ({Expression.ToFormattedString()}) {(LimitAll ? "LIMIT ALL" : "")}".Trim();
		}
		else {
			return $"VALUES ({Expression.ToFormattedString()}) ORDER BY {SortExpression.ToFormattedString()} {(LimitAll ? "LIMIT ALL" : "")}".Trim();
		}
	}
}
