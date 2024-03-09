namespace LabSqlParser.Nodes;
interface INode {
	void AcceptVisitor(INodeVisitor visitor);
	string ToFormattedString();
}
