using LabSqlParser.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
namespace LabSqlParser;
sealed class Parser {
	readonly IReadOnlyList<Token> tokens;
	int pos;
	public Parser(IReadOnlyList<Token> tokens) {
		this.tokens = tokens;
	}
	#region common
	Exception MakeError(string message) {
		throw new InvalidOperationException($"{message} at {pos}");
	}
	void ReadNextToken() {
		pos++;
	}
	Token CurrentToken => tokens[pos];
	void Expect(string s) {
		if (CurrentToken.Lexeme != s) {
			throw MakeError($"Expected {s}");
		}
		ReadNextToken();
	}
	bool SkipIf(string s) {
		if (CurrentToken.Lexeme == s) {
			ReadNextToken();
			return true;
		}
		return false;
	}
	void ExpectEof() {
		if (CurrentToken.Type != TokenType.EndOfFile) {
			throw MakeError($"Expected end of file, got {CurrentToken}");
		}
	}
	#endregion
	public static Values Parse(IEnumerable<Token> tokens) {
		var tokenList = tokens
			.Where(token => token.Type != TokenType.Spaces)
			.Append(new Token(TokenType.EndOfFile, ""))
			.ToList();
		var parser = new Parser(tokenList);
		var values = parser.ParseValues();
		parser.ExpectEof();
		return values;
	}
	Values ParseValues() {
		Expect("VALUES");
		Expect("(");
		var expression = ParseExpression();
		Expect(")");
		SortExpression? sortExpression = null;
		if (SkipIf("ORDER")) {
			Expect("BY");
			sortExpression = ParseSortExpression();
		}
		var limitAll = false;
		if (SkipIf("LIMIT")) {
			Expect("ALL");
			limitAll = true;
		}
		return new Values(expression, sortExpression, limitAll);
	}
	SortExpression ParseSortExpression() {
		var expression = ParseExpression();
		SortDirection? direction = null;
		if (SkipIf("ASC")) {
			direction = SortDirection.Asc;
		}
		else if (SkipIf("DESC")) {
			direction = SortDirection.Desc;
		}
		return new SortExpression(expression, direction);
	}
	IExpression ParseExpression() {
		return ParseConditionalAnd();
	}
	IExpression ParseConditionalAnd() {
		var left = ParsePrimary();
		while (SkipIf("AND")) {
			var right = ParsePrimary();
			left = new Binary(left, BinaryOperator.And, right);
		}
		return left;
	}
	IExpression ParsePrimary() {
		if (SkipIf("(")) {
			var primary = ParseExpression();
			Expect(")");
			return new Parentheses(primary);
		}
		if (CurrentToken.Type == TokenType.Number) {
			return ParseNumber();
		}
		if (CurrentToken.Type == TokenType.Identifier) {
			return ParseIdentifier();
		}
		throw MakeError("Expected Number, Identifier or Expression in Parentheses");
	}
	Number ParseNumber() {
		if (CurrentToken.Type != TokenType.Number) {
			throw MakeError($"Expected Number, but encountered {CurrentToken}");
		}
		var number = new Number(CurrentToken.Lexeme);
		ReadNextToken();
		return number;
	}
	Identifier ParseIdentifier() {
		if (CurrentToken.Type != TokenType.Identifier) {
			throw MakeError($"Expected Identifier, but encountered {CurrentToken}");
		}
		var identifier = new Identifier(CurrentToken.Lexeme);
		ReadNextToken();
		return identifier;
	}
}
