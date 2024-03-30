interface INode { }
interface IExpression : INode { }
record Values(IExpression Expression, SortExpression? SortExpression, bool LimitAll) : INode { }
record Number(string Lexeme) : IExpression { }
record Identifier(string Name) : IExpression { }
record Parentheses(IExpression Child) : IExpression { }
record Binary(IExpression Left, BinaryOperator Op, IExpression Right) : IExpression { }
enum BinaryOperator { And, }
enum SortDirection { Asc, Desc, }
record SortExpression(IExpression Expression, SortDirection? Direction) : INode { }
