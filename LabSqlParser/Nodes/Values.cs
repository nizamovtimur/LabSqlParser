namespace LabSqlParser.Nodes;
sealed record Values(
	IExpression Expression,
	SortExpression? SortExpression,
	bool LimitAll
) : INode {
	public void AcceptVisitor(INodeVisitor visitor) {
		visitor.VisitValues(this);
	}
	public string ToFormattedString() {
		var sortExpression = "";
		if (SortExpression is not null) {
			sortExpression = $" ORDER BY {SortExpression.ToFormattedString()}";
		}
		return $"VALUES ({Expression.ToFormattedString()}){sortExpression}{(LimitAll ? " LIMIT ALL" : "")}";
	}
}
