using LabSqlParser.Nodes;
using System;
namespace LabSqlParser;
static class Program {
	static void Main() {
		var source = "VALUES ( ( 1 ) AND a ) ORDER BY 2 ASC LIMIT ALL";
		var tree = new Values(
			new Binary(
				new Parentheses(
					new Number("1")
				),
				BinaryOperator.And,
				new Identifier("a")
			),
			new SortExpression(
				new Number("2"),
				SortDirection.Asc
			),
			LimitAll: true
		);
		Console.WriteLine(source);
		Console.WriteLine(tree.ToFormattedString());
	}
}
