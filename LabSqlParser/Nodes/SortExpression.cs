namespace LabSqlParser.Nodes;
sealed record SortExpression(
	IExpression Expression,
	SortDirection? Direction
) : INode {
	public string ToFormattedString() {
		return Direction switch {
			SortDirection.Asc => $"{Expression.ToFormattedString()} ASC",
			SortDirection.Desc => $"{Expression.ToFormattedString()} DESC",
			_ => $"{Expression.ToFormattedString()}",
		};
	}
}
