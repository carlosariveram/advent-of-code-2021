using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Console.DecemberFirst;

internal class SonarSweep
{
    private static string GetSonarSweepInputFilePath() => Path.Combine(Directory.GetCurrentDirectory(), "Resources", "SonarSweepInput.txt");

    private bool ShouldIncrementSonarCounter((int? previousValue, int totalIncrements) previousAccumulatedValue, string newValue) => previousAccumulatedValue.previousValue.HasValue 
        && int.Parse(newValue) > previousAccumulatedValue.Item1.Value;

    public int GetNumberOfIncrements()
    {
        var measurements = GetMeasurements();
        var seedValue = (default(int?), 0);

        var incrementsAccumulated = measurements.Aggregate<string, (int? previousValue, int totalIncrements)>(seedValue, CalculateIncrements);

        return incrementsAccumulated.totalIncrements;
    }

    public int GetSlidingIncrements()
    {
        var measurements = GetMeasurements();
        var seedValue = (default(int?[]), 0);

        var incrementsAccumulated = measurements.Aggregate<string, (int?[] previousValue, int totalIncrements)>(seedValue, CalculateSlidingIncrements);

        return incrementsAccumulated.totalIncrements;
    }

    private (int? previousValue, int totalIncrements) CalculateIncrements((int? previousValue, int totalIncrements) previousAccumulatedValue, string newValue)
    {
        if (ShouldIncrementSonarCounter(previousAccumulatedValue, newValue))
        {
            previousAccumulatedValue.totalIncrements++;
        }

        previousAccumulatedValue.previousValue = int.Parse(newValue);

        return previousAccumulatedValue;
    }
    private (int?[] previousValue, int totalIncrements) CalculateSlidingIncrements((int?[] previousValue, int totalIncrements) previousAccumulatedValue, string newValue)
    {
        if (previousAccumulatedValue.previousValue == default(int?[]))
        {
            previousAccumulatedValue.previousValue = new int?[3];
        }

        var newAccumulatedValue = new int?[3]
        {
            previousAccumulatedValue.previousValue[1],
            previousAccumulatedValue.previousValue[2],
            int.Parse(newValue)
        };

        if (previousAccumulatedValue.previousValue.All(value => value.HasValue))
        {
            if (newAccumulatedValue.Sum() > previousAccumulatedValue.previousValue.Sum())
            {
                previousAccumulatedValue.totalIncrements++;
            }
        }
        
        previousAccumulatedValue.previousValue = newAccumulatedValue;
        return previousAccumulatedValue;
    }

    private string[] GetMeasurements()
    {
        var filePath = GetSonarSweepInputFilePath();
        var measurements = File.ReadAllLines(filePath);
        return measurements;
    }

}
