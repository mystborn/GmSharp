using System.Collections.Generic;

namespace TaffyScript.Compiler.Syntax
{
    public class ObjectNode : SyntaxNode
    {
        public override SyntaxType Type => SyntaxType.Object;
        public string Name { get; }
        public string Inherits { get; }
        public List<ScriptNode> Scripts { get; }

        public ObjectNode(string name, string inherits, List<ScriptNode> scripts, TokenPosition position)
            : base(position)
        {
            Name = name;
            Inherits = inherits;
            Scripts = scripts;
        }

        public override void Accept(ISyntaxElementVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
