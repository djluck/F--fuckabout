// Implementation file for parser generated by fsyacc
module Parser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"


open Ast


# 12 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | IDENT of (System.String)
  | STAR
  | HASH
  | DOT
  | COMMA
  | GREATER
  | PLUS
  | S
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_IDENT
    | TOKEN_STAR
    | TOKEN_HASH
    | TOKEN_DOT
    | TOKEN_COMMA
    | TOKEN_GREATER
    | TOKEN_PLUS
    | TOKEN_S
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_Init
    | NONTERM_SimpleSelectorSeq
    | NONTERM_SimpleSelector

// This function maps tokens to integers indexes
let tagOfToken (t:token) = 
  match t with
  | IDENT _ -> 0 
  | STAR  -> 1 
  | HASH  -> 2 
  | DOT  -> 3 
  | COMMA  -> 4 
  | GREATER  -> 5 
  | PLUS  -> 6 
  | S  -> 7 

// This function maps integers indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_IDENT 
  | 1 -> TOKEN_STAR 
  | 2 -> TOKEN_HASH 
  | 3 -> TOKEN_DOT 
  | 4 -> TOKEN_COMMA 
  | 5 -> TOKEN_GREATER 
  | 6 -> TOKEN_PLUS 
  | 7 -> TOKEN_S 
  | 10 -> TOKEN_end_of_input
  | 8 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startstart 
    | 1 -> NONTERM_start 
    | 2 -> NONTERM_Init 
    | 3 -> NONTERM_SimpleSelectorSeq 
    | 4 -> NONTERM_SimpleSelectorSeq 
    | 5 -> NONTERM_SimpleSelector 
    | 6 -> NONTERM_SimpleSelector 
    | 7 -> NONTERM_SimpleSelector 
    | 8 -> NONTERM_SimpleSelector 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 10 
let _fsyacc_tagOfErrorTerminal = 8

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | IDENT _ -> "IDENT" 
  | STAR  -> "STAR" 
  | HASH  -> "HASH" 
  | DOT  -> "DOT" 
  | COMMA  -> "COMMA" 
  | GREATER  -> "GREATER" 
  | PLUS  -> "PLUS" 
  | S  -> "S" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | IDENT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | STAR  -> (null : System.Object) 
  | HASH  -> (null : System.Object) 
  | DOT  -> (null : System.Object) 
  | COMMA  -> (null : System.Object) 
  | GREATER  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | S  -> (null : System.Object) 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 1us; 65535us; 0us; 2us; 1us; 65535us; 0us; 3us; 2us; 65535us; 0us; 4us; 3us; 5us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 5us; 7us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 1us; 1us; 2us; 2us; 4us; 1us; 3us; 1us; 4us; 1us; 5us; 1us; 6us; 1us; 7us; 1us; 7us; 1us; 8us; 1us; 8us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 6us; 9us; 11us; 13us; 15us; 17us; 19us; 21us; 23us; |]
let _fsyacc_action_rows = 12
let _fsyacc_actionTableElements = [|4us; 32768us; 0us; 7us; 1us; 6us; 2us; 10us; 3us; 8us; 0us; 49152us; 0us; 16385us; 4us; 16386us; 0us; 7us; 1us; 6us; 2us; 10us; 3us; 8us; 0us; 16387us; 0us; 16388us; 0us; 16389us; 0us; 16390us; 1us; 32768us; 0us; 9us; 0us; 16391us; 1us; 32768us; 0us; 11us; 0us; 16392us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 5us; 6us; 7us; 12us; 13us; 14us; 15us; 16us; 18us; 19us; 21us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 1us; 1us; 1us; 2us; 1us; 1us; 2us; 2us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 3us; 3us; 4us; 4us; 4us; 4us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 16385us; 65535us; 16387us; 16388us; 16389us; 16390us; 65535us; 16391us; 65535us; 16392us; |]
let _fsyacc_reductions ()  =    [| 
# 121 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data :  Ast.simpleSelectorSeq )) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startstart));
# 130 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Init)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                                          _1 
                   )
# 46 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                 :  Ast.simpleSelectorSeq ));
# 141 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'SimpleSelectorSeq)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                                                   Ast.SimpleSelectorSeq _1 
                   )
# 48 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                 : 'Init));
# 152 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'SimpleSelector)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                                          [_1] 
                   )
# 52 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                 : 'SimpleSelectorSeq));
# 163 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'SimpleSelectorSeq)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'SimpleSelector)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                                                           _2 :: _1 
                   )
# 53 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                 : 'SimpleSelectorSeq));
# 175 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 56 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                                  Ast.Global 
                   )
# 56 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                 : 'SimpleSelector));
# 185 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : System.String)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                                   Ast.Tag(_1) 
                   )
# 57 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                 : 'SimpleSelector));
# 196 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : System.String)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                                      Ast.Class(_2) 
                   )
# 58 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                 : 'SimpleSelector));
# 207 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : System.String)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                                      Ast.Id(_2) 
                   )
# 59 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fsy"
                 : 'SimpleSelector));
|]
# 219 "F:\Workspace\HtmlAgilityCssSelector\HtmlAgilityCssSelectors\Parser.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 11;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let start lexer lexbuf :  Ast.simpleSelectorSeq  =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
