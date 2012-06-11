module HtmlAgilityExtensions

open Microsoft.FSharp.Text.Lexing
open HtmlAgilityPack
open Ast
open Lexer
open Parser

//
//let parseStatement selector = 
//    let lexbuff = LexBuffer<char>.FromString(selector)
//    let selectorsGroup = Parser.start Lexer.tokenize lexbuff
//
//    []
//
//let rec evalSelector (context:HtmlNode) = function
//    | SelectorSequence (selSeq, comb, selector) ->  evalSimpleSelectorSequence context selSeq :: evalSelector context selector
//    | Selector selSeq -> evalSimpleSelectorSequence context selSeq
//
//and evalSimpleSelectorSequence (context:HtmlNode) = function
//    | SimpleSelectorSeq s -> s |> List.map (fun x-> x)
//
//and evalSimpleSelector = function
//    | Global -> ()
//
//
//
//let rec walkDom (node:HtmlNode) = 
//    match node with
//    | node when node.HasChildNodes -> node.ChildNodes |> Seq.map walkDom
//    | _ -> node

//must return a list of all nodes that match the specified selector. List must be unique (set -> list perhaps?)

//selector groups are independent - evaluate each one and group the results (unique mind you!)

//for each simple sequence, start at the context node (root if first in sequence and not querying a specific node)
    //for a class, look for all nodes with that class (should we look at descendants or children?)
    //for universal - all
    //for a tag - just those with that element
    //for a attribute- same
//for simple sequence chains, they are going to be acting on the same context. For combinators, each element becomes the context of the query in the child query

//for each selector combinator, start at the begining of the chain, then look at the combinator to find out where next to apply it
//when performing the child query, 

//let rec evaluateSelectorGroup sg = 
//    match sg with
//    | Selector list -> ()




//extension methods
//type HtmlDocument with
//    member this.CssSelect selector = 
//        parseSelector selector

    