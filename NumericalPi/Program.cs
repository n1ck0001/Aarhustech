﻿
using System.Diagnostics;

Stopwatch watch = new Stopwatch();
PiCalc calculator = new PiCalc();

Console.WriteLine("Started");
watch.Start();
double numPi = calculator.Calculate(100000000);
watch.Stop();
Console.WriteLine("Done");

Console.WriteLine($"Numeric PI = {numPi:0.000000}");
Console.WriteLine($"Real PI    = {Math.PI:0.000000}");
Console.WriteLine($"Took {watch.ElapsedMilliseconds} milliSecs");
Console.WriteLine();
