namespace BetaCompiler.CodeAnalysis.Syntax {
	public enum SyntaxKind {
		// Tokens      
		BadToken,
		EndOfFileToken,
		NumberToken,
		WhitespaceToken,
		PlusToken,
		MinusToken,
		StarToken,
		SlashToken,
		OpenParenthesisToken,
		CloseParenthesisToken,
		IdentifierToken,
		BangToken,
		AmpersandAmpersandToken,
		PipePipeToken,
		EqualsEqualsToken,
		BangEqualsToken,

		// Expressions
		LiteralExpression,
		BinaryExpression,
		ParenthesizedExpression,
		UnaryExpression,

		// Keywords
		TrueKeyword,
		FalseKeyword
	}
}