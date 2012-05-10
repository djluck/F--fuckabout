#light

namespace Ast
open System


//http://www.w3.org/TR/css3-selectors/#w3cselgrammar



//type PseudoClass = 
//    | AttrEquals of string
//
//type SimpleSelector =
//    | Class of string
//    | Id of string
//    | Attrib
//    | Negation
//
//type SequenceStart =
//    | Universal
//    | Tag of string
//
//type SequencePrefix =
//    | Universal
//    | Tag of string
//
//type Sequence = 
//    | Prefix of SequencePrefix
//    | Single of SequencePrefix * SimpleSelector
//    | Many of SequencePrefix * SimpleSelector list
//
//type Selector = Single of string
//    | Single of Sequence
//    | Combined of Sequence * Combinator * Selector



type combinator = 
    | Descendant 
    | Child


type simpleSelectors = 
    | Global
    | Tag of string
    | Class of string
    | Id of string

type simpleSelectorSeq = 
    | SimpleSelectorSeq of simpleSelectors list

type selector = 
    | Selector of simpleSelectorSeq
    | SelectorSequence of simpleSelectorSeq * combinator * selector

type selectorsGroup =
    | SelectorsGroup of selector list

