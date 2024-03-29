// Signature file for parser generated by fsyacc
module Parser
type token = 
  | IDENT of (System.String)
  | SINGLEQOUTE
  | EQUALS
  | RBRACKET
  | LBRACKET
  | EOF
  | STAR
  | HASH
  | DOT
  | COMMA
  | GREATER
  | PLUS
  | S
type tokenId = 
    | TOKEN_IDENT
    | TOKEN_SINGLEQOUTE
    | TOKEN_EQUALS
    | TOKEN_RBRACKET
    | TOKEN_LBRACKET
    | TOKEN_EOF
    | TOKEN_STAR
    | TOKEN_HASH
    | TOKEN_DOT
    | TOKEN_COMMA
    | TOKEN_GREATER
    | TOKEN_PLUS
    | TOKEN_S
    | TOKEN_end_of_input
    | TOKEN_error
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_Init
    | NONTERM_SelectorsGroup
    | NONTERM_Selector
    | NONTERM_FullSimpleSelectorSeq
    | NONTERM_SimpleSelectorSeq
    | NONTERM_SimpleSelector
    | NONTERM_AttributeValue
    | NONTERM_AttributeComparison
    | NONTERM_Combinator
/// This function maps integers indexes to symbolic token ids
val tagOfToken: token -> int

/// This function maps integers indexes to symbolic token ids
val tokenTagToTokenId: int -> tokenId

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
val prodIdxToNonTerminal: int -> nonTerminalId

/// This function gets the name of a token as a string
val token_to_string: token -> string
val start : (Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> token) -> Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> ( Ast.selectorsGroup ) 
