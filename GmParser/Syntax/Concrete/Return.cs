﻿namespace GmParser.Syntax
{
    public class ReturnNode : SyntaxNode
    {
        public ISyntaxElement ReturnValue => Children[0];
        public override SyntaxType Type => SyntaxType.Return;

        public ReturnNode(string value) : base(value)
        {
        }

        public override void Accept(ISyntaxElementVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
