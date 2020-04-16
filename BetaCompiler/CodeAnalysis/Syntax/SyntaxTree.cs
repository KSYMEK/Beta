using System.Collections.Generic;
using System.Linq;

namespace BetaCompiler.CodeAnalysis.Syntax {
	public sealed class SyntaxTree {
		public SyntaxTree(IReadOnlyList<string> diagnostic, ExpressionSyntax root, SyntaxToken endOfFileToken) {
			Diagnostics = diagnostic.ToArray();
			Root = root;
			EndOfFileToken = endOfFileToken;
		}

		public IReadOnlyList<string> Diagnostics { get; }
		public ExpressionSyntax Root { get; }
		public SyntaxToken EndOfFileToken { get; }

		public static SyntaxTree Parse(string text) {
			var parser = new Parser(text);
			return parser.Parse();
		}
	}
}