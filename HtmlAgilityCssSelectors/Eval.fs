module Eval
open HtmlAgilityPack
open System.Text.RegularExpressions
open Ast

let matchStr (s1:string) (s2:string) =
    s1.ToLower() = s2.ToString().ToLower()

let filterNode filterFunc (node:HtmlNode option) = 
    match node with
    |Some(n) when filterFunc n -> Some(n)
    |_ -> None

let hasAttribute attrName (node:HtmlNode) =
    node.Attributes.Contains(attrName:string)

let matchAttribute attrName matchFunc node =
    (hasAttribute attrName node) && (matchFunc node.Attributes.[attrName].Value)

let attributeExists attrName node = 
    filterNode (hasAttribute attrName) node

//let attributeContains attrName value node =
//    let filterFunc = matchAttribute attrName (fun x-> x.Split([|' '|]) |> Seq.exists (matchStr value))
//    filterNode filterFunc node

//let attributeEquals attrName value node =
//    let filterFunc = matchAttribute attrName (matchStr value)
//    filterNode filterFunc node

let attrContains compareTo (attrValue:string) = 
    attrValue.Split([|' '|]) 
    |> Seq.exists (matchStr compareTo)

let hasClass className node =
    matchAttribute "class" (attrContains className) node

//TODO- rewrite using seq expression
let findSiblings (start:HtmlNode) =
    let rec findSiblingsInDir nextSiblingFun (node:HtmlNode) =
        match (nextSiblingFun node) with
        | null -> []
        | nextSibling -> node :: findSiblingsInDir nextSiblingFun nextSibling

    start 
        :: findSiblingsInDir (fun x-> x.NextSibling) start 
        @ findSiblingsInDir (fun x-> x.PreviousSibling) start
        |> List.toSeq




let evalAttrComparison value = function
    | Equals -> matchStr value
    | Similar -> attrContains value

let evalSimpleSelector = function
    | Global -> filterNode (fun x-> true)
    | Tag(name) -> filterNode (fun x-> matchStr x.Name name)
    | Id(id) -> filterNode (fun x-> matchStr x.Id id)
    | Class(className) -> filterNode (hasClass className)
    | Attribute(attrName) -> filterNode (hasAttribute attrName)
    | AttributeComparsion(attrName, comparison, value) ->
        filterNode (matchAttribute attrName (evalAttrComparison value comparison))

let evalSimpleSelectorSeq = function
    | SimpleSelectorSeq(selectors) -> 
        selectors 
        |> List.map evalSimpleSelector
        |> List.reduce (fun acc x-> acc >> x)

let evalCombinator comb =
    let outerFn fn (node:HtmlNode option) : HtmlNode seq option = 
        match node with
        | Some(n) -> Some(fn n)
        | None -> None

    match comb with
    | Child -> outerFn (fun x-> x.ChildNodes.Elements())
    | Descendant -> outerFn (fun x-> x.DescendantNodes())
    | Sibling -> outerFn findSiblings


let evalSelectorsGroup sg (node:HtmlNode) =
    match sg with
    | SelectorsGroup(selectors) -> 
        selectors
        |> List.map evalSelector

//let rec evalSelector = function
//    | CombinedSelectors (s1, comb, s2) -> evalCombinator (s1 (evalSelector s2))
//    | Selector(s) -> evalSimpleSelectorSeq s






    
    

