module App

open Fable.Core.JsInterop
open Fable.Import

let window = Browser.Dom.window

let mutable myCanvas : Browser.Types.HTMLCanvasElement = unbox window.document.getElementById "myCanvas"

let ctx = myCanvas.getContext_2d()

let w = myCanvas.width
let h = myCanvas.height
let steps = 20
let squareSize = 20

let gridWidth = float (steps * squareSize) 

myCanvas.width <- gridWidth
myCanvas.height <- gridWidth

printfn "%i" steps

[0..steps]
|> Seq.iter (fun x ->
  let v = float ((x) * squareSize) 
  ctx.moveTo(v, 0.)
  ctx.lineTo(v, gridWidth)
  ctx.moveTo(0., v)
  ctx.lineTo(gridWidth, v)
) 

ctx.strokeStyle <- !^"#ddd"

// draw our grid
ctx.stroke() 

// write Fable
ctx.textAlign <- "center"
ctx.fillText("Fable on Canvas", gridWidth * 0.5, gridWidth * 0.5)

printfn "done!"
