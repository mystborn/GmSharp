﻿namespace GmParser.Syntax
{
    public class FunctionCallNode : SyntaxNode
    {
        public override SyntaxType Type => SyntaxType.FunctionCall;

        public FunctionCallNode(string value) : base(value)
        {
        }

        public override void Accept(ISyntaxElementVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
