using LabSqlParser.Nodes;
using System;
namespace LabSqlParser;
static class Program {
	static void Main() {
		string[] sources = [
			"VALUES ( ( 1 ) AND a ) ORDER BY 2 ASC LIMIT ALL",
			"VALUES ( 1 ) ORDER BY 2 DESC",
			"VALUES ( 1 ) ORDER BY 2",
			"VALUES ( 1 )",
			"VALUES ( ( 1 ) AND ( 2 ) ) LIMIT    ALL",
		];
		Console.WriteLine(sources[0]);
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
		Console.WriteLine(tree.ToFormattedString());
		foreach (var source in sources) {
			Console.WriteLine();
			Console.WriteLine(source);
			var tokens = Lexer.GetTokens(source);
			if (!true) {
				Console.WriteLine(string.Join("\n", tokens));
			}
			if (true) {
				var parsedTree = Parser.Parse(tokens);
				Console.WriteLine(parsedTree.ToFormattedString());
				if (true) {
					new DebugPrintingVisitor(Console.Out).WriteLine(parsedTree);
				}
			}
		}
	}
}
