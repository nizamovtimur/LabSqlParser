using System;
namespace LabSqlParser.Nodes;
sealed record SortExpression(
	IExpression Expression,
	SortDirection? Direction
) : INode {
	public void AcceptVisitor(INodeVisitor visitor) {
		visitor.VisitSortExpression(this);
	}
	public string ToFormattedString() {
		var direction = Direction switch {
			null => $"",
			SortDirection.Asc => " ASC",
			SortDirection.Desc => " DESC",
			_ => throw new NotSupportedException(),
		};
		return $"{Expression.ToFormattedString()}{direction}";
	}
}
