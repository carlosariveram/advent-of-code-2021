using AdventOfCode.Console.December1;
using AdventOfCode.Console.December2;

RunDecember2();

void RunDecember1()
{
    var sweep = new SonarSweep();
    var increments = sweep.GetNumberOfIncrements();
    var slidingIncrement = sweep.GetSlidingIncrements();

    Console.WriteLine($"Single Increment: {increments}");
    Console.WriteLine($"Sliding Increment: {slidingIncrement}");
    Console.ReadKey();
}

void RunDecember2()
{
    var sleight = new SleightMovement();
    var position = sleight.GetPosition();
    var advancedPosition = sleight.GetAdvancedSleightPosition();

    Console.WriteLine($"Position X:{position.X}, Y:{position.Y}");
    Console.WriteLine($"Result: {position.X * position.Y}");
    Console.WriteLine("*********** Advanced Position ****************");
    Console.WriteLine($"Position X:{advancedPosition.X}, Y:{advancedPosition.Y}, Aim:{advancedPosition.Aim}");
    Console.WriteLine($"Result: {advancedPosition.X * advancedPosition.Y}");
    Console.ReadKey();
}