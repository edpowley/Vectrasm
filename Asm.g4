grammar Asm;

@header {
#pragma warning disable CS3021 // Type or member does not need a CLSCompliant attribute because the assembly does not have a CLSCompliant attribute
}

// Parser rules

prog			: statement* ;

statement		: NEW_LINE													# StmtBlank
				| name=IDENTIFIER ('EQU' | 'equ') value=expr NEW_LINE		# StmtEqu
				| ('DB' | 'db') db=data_byte_list NEW_LINE					# StmtData
				| ('FCB' | 'fcb') db=data_byte_list NEW_LINE				# StmtData
				| ('FCC' | 'fcc') db=data_byte_list NEW_LINE				# StmtData
				| ('DW' | 'dw') dw=data_word_list NEW_LINE					# StmtData
				| ('FDB' | 'fdb') dw=data_word_list NEW_LINE				# StmtData
				| opcode=IDENTIFIER argument? NEW_LINE						# StmtOpcode
				| IDENTIFIER ':'											# StmtLabel
				;

argument		: expr			# ArgumentExtendedOrDirect
				| '#' expr		# ArgumentImmediate
				;

data_byte_list	: data_byte (',' data_byte)*	# DataByteList
				;

data_byte		: expr					# DataByteExpr
				| LITERAL_STRING		# DataByteString
				;

data_word_list	: expr (',' expr)*		# DataWordList
				;

expr			: '(' expr ')'						# ExprParens
				| 			oper=ADD_OP	rhs=expr	# ExprUnaryOp
				| 			oper=NOT_OP	rhs=expr	# ExprUnaryOp
				| lhs=expr	oper=MUL_OP	rhs=expr	# ExprBinOp
				| lhs=expr	oper=ADD_OP	rhs=expr	# ExprBinOp
				| lhs=expr	oper='&&'	rhs=expr	# ExprBinOp
				| lhs=expr	oper='||'	rhs=expr	# ExprBinOp
				| literal							# ExprLiteral
				| IDENTIFIER						# ExprIdentifier
				;

literal			: LITERAL_HEX						# LiteralHex
				| LITERAL_DEC						# LiteralDec
				;

// Lexer rules

LITERAL_HEX		: '$' [0-9A-Fa-f]+ ;
LITERAL_DEC		: [0-9]+ ;
LITERAL_STRING	: '"' ~["]* '"' ;

IDENTIFIER		: [A-Za-z_] [A-Za-z0-9_]* ;

MUL_OP			: '*' | '/' ;
ADD_OP			: '+' | '-' ;
NOT_OP			: '~' | '!' ;

NEW_LINE		: [\r\n]+ ;
WHITESPACE		: [ \t]+					-> skip;
LINE_COMMENT	: ';' ~[\r\n]*				-> skip;
