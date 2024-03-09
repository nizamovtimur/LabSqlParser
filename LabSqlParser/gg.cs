interface INode { }
interface IExpression : INode { }
record Select(IExpression Expression, string TableName) : INode { }
record Number(string Lexeme) : IExpression { }
record Identifier(string Lexeme) : IExpression { }
record Parentheses(IExpression Child) : IExpression { }
record ScalarSubquery(Select Child) : IExpression { }
enum BinaryOperator { Plus, Minus, Or, }
record Binary(IExpression Left, BinaryOperator Operator, IExpression Right) : IExpression { }
