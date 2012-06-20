module Eval
open HtmlAgilityPack
open System.Text.RegularExpressions
open Ast
open Util


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

let evalSimpleSelectorSeq simpleSelSeq (node:HtmlNode) = 
    match simpleSelSeq with
    | SimpleSelectorSeq(selectors) -> 
        let filterNodeFun = 
            selectors 
            |> List.map evalSimpleSelector
            |> List.reduce (fun acc x-> acc >> x)

        node.DescendantsAndSelf()
        |> Seq.choose (fun x-> filterNodeFun (Some x))

let evalCombinator combinator (node:HtmlNode) =
    match combinator with
    | Child -> node.ChildNodes.Elements() |> Seq.cast
    | Descendant -> node.DescendantNodes() |> Seq.cast
    | Sibling -> 
        node.ParentNode.ChildNodes.Nodes() 
        |> Seq.filter (fun y-> not (y.Equals(node)))



    

let rec evalSelector node = function
    | CombinedSelectors (s1, comb, s2) -> 
        evalSimpleSelectorSeq s1 node
        |> Seq.map (fun x -> set (evalCombinator comb x |> Seq.map (fun x-> RefEquality(x) )))
        |> Set.intersectMany
        |> Set.toSeq
        |> Seq.map (fun x-> x.Item)
    | Selector(s) -> evalSimpleSelectorSeq s node


let evalSelectorsGroup sg (node:HtmlNode) =
    match sg with
    | SelectorsGroup(selectors) -> 
        selectors
        |> List.map evalSelector

//let rec evalSelector = function
//    | CombinedSelectors (s1, comb, s2) -> evalCombinator (s1 (evalSelector s2))
//    | Selector(s) -> evalSimpleSelectorSeq s






    
    

