namespace Beta.CodeAnalysis {
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

        // Expressions
        LiteralExpression,
        BinaryExpression,
        ParenthesizedExpression
    }
}