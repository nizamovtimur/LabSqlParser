namespace LabSqlParser;
sealed record Token(
	TokenType Type,
	string Lexeme
) {
	public override string ToString() {
		return $"`{Lexeme}`: {Type}";
	}
}
