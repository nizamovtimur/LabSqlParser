interface INode { }
interface IExpression : INode { }
interface ISortExpression : INode { }
record Values(IExpression Expression, ISortExpression SortExpression, string Limit) : INode { }
record Number(string Lexeme) : IExpression { }
record Identifier(string Lexeme) : IExpression { }
record Parentheses(IExpression Child) : IExpression { }
enum SortOperator { ASC, DESC, }
record Order(IExpression Expression, SortOperator Operator) : ISortExpression { }
