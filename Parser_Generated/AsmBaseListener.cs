//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Asm.g4 by ANTLR 4.5.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591


#pragma warning disable CS3021 // Type or member does not need a CLSCompliant attribute because the assembly does not have a CLSCompliant attribute


using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IAsmListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.1")]
[System.CLSCompliant(false)]
public partial class AsmBaseListener : IAsmListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.prog"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProg([NotNull] AsmParser.ProgContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.prog"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProg([NotNull] AsmParser.ProgContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.StmtBlank"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStmtBlank([NotNull] AsmParser.StmtBlankContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.StmtBlank"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStmtBlank([NotNull] AsmParser.StmtBlankContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.StmtEqu"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStmtEqu([NotNull] AsmParser.StmtEquContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.StmtEqu"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStmtEqu([NotNull] AsmParser.StmtEquContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.StmtData"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStmtData([NotNull] AsmParser.StmtDataContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.StmtData"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStmtData([NotNull] AsmParser.StmtDataContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.StmtOpcode"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStmtOpcode([NotNull] AsmParser.StmtOpcodeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.StmtOpcode"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStmtOpcode([NotNull] AsmParser.StmtOpcodeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.StmtLabel"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStmtLabel([NotNull] AsmParser.StmtLabelContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.StmtLabel"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStmtLabel([NotNull] AsmParser.StmtLabelContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.ArgumentExtendedOrDirect"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArgumentExtendedOrDirect([NotNull] AsmParser.ArgumentExtendedOrDirectContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.ArgumentExtendedOrDirect"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArgumentExtendedOrDirect([NotNull] AsmParser.ArgumentExtendedOrDirectContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.ArgumentImmediate"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArgumentImmediate([NotNull] AsmParser.ArgumentImmediateContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.ArgumentImmediate"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArgumentImmediate([NotNull] AsmParser.ArgumentImmediateContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.DataByteList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDataByteList([NotNull] AsmParser.DataByteListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.DataByteList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDataByteList([NotNull] AsmParser.DataByteListContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.DataByteExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDataByteExpr([NotNull] AsmParser.DataByteExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.DataByteExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDataByteExpr([NotNull] AsmParser.DataByteExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.DataByteString"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDataByteString([NotNull] AsmParser.DataByteStringContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.DataByteString"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDataByteString([NotNull] AsmParser.DataByteStringContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.DataWordList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDataWordList([NotNull] AsmParser.DataWordListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.DataWordList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDataWordList([NotNull] AsmParser.DataWordListContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.ExprParens"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExprParens([NotNull] AsmParser.ExprParensContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.ExprParens"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExprParens([NotNull] AsmParser.ExprParensContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.ExprIdentifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExprIdentifier([NotNull] AsmParser.ExprIdentifierContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.ExprIdentifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExprIdentifier([NotNull] AsmParser.ExprIdentifierContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.ExprUnaryOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExprUnaryOp([NotNull] AsmParser.ExprUnaryOpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.ExprUnaryOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExprUnaryOp([NotNull] AsmParser.ExprUnaryOpContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.ExprBinOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExprBinOp([NotNull] AsmParser.ExprBinOpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.ExprBinOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExprBinOp([NotNull] AsmParser.ExprBinOpContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.ExprLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExprLiteral([NotNull] AsmParser.ExprLiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.ExprLiteral"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExprLiteral([NotNull] AsmParser.ExprLiteralContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.LiteralHex"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLiteralHex([NotNull] AsmParser.LiteralHexContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.LiteralHex"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLiteralHex([NotNull] AsmParser.LiteralHexContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.LiteralDec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLiteralDec([NotNull] AsmParser.LiteralDecContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.LiteralDec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLiteralDec([NotNull] AsmParser.LiteralDecContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}