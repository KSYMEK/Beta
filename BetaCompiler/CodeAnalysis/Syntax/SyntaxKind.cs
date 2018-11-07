namespace Beta.CodeAnalysis.Syntax {
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