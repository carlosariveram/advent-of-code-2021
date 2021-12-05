using AdventOfCode.Console.DecemberFirst;

var sweep = new SonarSweep();
var increments = sweep.GetNumberOfIncrements();
var slidingIncrement = sweep.GetSlidingIncrements();

Console.WriteLine($"Single Increment: ${increments}");
Console.WriteLine($"Sliding Increment: ${slidingIncrement}");
Console.ReadKey();