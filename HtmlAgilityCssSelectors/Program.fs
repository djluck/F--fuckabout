
open System
open Microsoft.FSharp.Text.Lexing

open Ast
open Lexer
open Parser
open System.Diagnostics


let time f = 
    let timer = Stopwatch.StartNew()
    let r = f()
    timer.Stop()
    printfn "Took %d ms, %d ticks, frequency = %d" timer.ElapsedMilliseconds timer.ElapsedTicks Stopwatch.Frequency
    r

let lexbuff = LexBuffer<char>.FromString("E")
let r = Lexer.tokenize lexbuff

let result = time (fun ()-> Parser.start Lexer.tokenize lexbuff)

let lexbuff2 = LexBuffer<char>.FromString("*.every.class + a,* p.classes , *")
let result2 = time (fun ()-> Parser.start Lexer.tokenize lexbuff2)
let x = 1       
