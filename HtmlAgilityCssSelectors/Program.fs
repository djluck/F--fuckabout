
open System
open Microsoft.FSharp.Text.Lexing

open Ast
open Lexer
open Parser
open System.Diagnostics

let rec printBuff (b:LexBuffer<char>) =
    try
        let t = Lexer.tokenize b 
        printfn "Token is %A" t
        printBuff b
    with 
        _ -> ()
    ()

let time f = 
    let timer = Stopwatch.StartNew()
    let r = f()
    timer.Stop()
    printfn "Took %d ms, %d ticks, frequency = %d" timer.ElapsedMilliseconds timer.ElapsedTicks Stopwatch.Frequency
    r

let lexbuff = LexBuffer<char>.FromString("E")

let result = time (fun ()-> Parser.start Lexer.tokenize lexbuff)

let parse = "*.every.class[me='them'] + a,*[type] p.classes"
let lexbuffPrin = LexBuffer<char>.FromString(parse)
//printBuff lexbuffPrin

let lexbuff2 = LexBuffer<char>.FromString(parse)  //*.every.class + a,* p.classes , *


    

let result2 = time (fun ()-> Parser.start Lexer.tokenize lexbuff2)
let x = 1       
