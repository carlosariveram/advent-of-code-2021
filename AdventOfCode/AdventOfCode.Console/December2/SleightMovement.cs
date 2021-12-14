using AdventOfCode.Console.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Console.December2
{
    internal record class SleightPosition
    {
        public int X;
        public int Y;
    }

    internal record class AdvancedSleightPosition : SleightPosition
    {
        public int Aim;
    }

    internal class SleightMovement
    {
        private const string FileName = "SonarSweepPosition.txt";

        private static Dictionary<string, Func<int, int, int>> VerticalMovementCommands = new Dictionary<string, Func<int, int, int>>()
        {
            {"up", MoveUp },
            {"down",  MoveDown }
        };

        private static Dictionary<string, Func<int, int, int>> HorizontalMovementCommands = new Dictionary<string, Func<int, int, int>>()
        {
            { "forward", MoveForward },
        };

        private static int MoveForward(int currentHorizontalPosition, int horizontalOffset)
        {
            return currentHorizontalPosition + horizontalOffset;
        }

        private static int MoveUp(int currentVerticalPosition, int verticalOffset)
        {
            return currentVerticalPosition - verticalOffset;
        }

        private static int MoveDown(int currentVerticalPosition, int verticalOffset)
        {
            return currentVerticalPosition + verticalOffset;
        }

        public SleightPosition GetPosition()
        {
            var input = FileHelper.GetInputFromFile(FileName);
            var seedPosition = new SleightPosition()
            {
                X = 0,
                Y = 0
            };

            var position = input.Aggregate<string, SleightPosition>(seedPosition, CalculatePosition);

            return position;
        }

        public AdvancedSleightPosition GetAdvancedSleightPosition()
        {
            var input = FileHelper.GetInputFromFile(FileName);
            var seedPosition = new AdvancedSleightPosition()
            {
                X = 0,
                Y = 0,
                Aim = 0
            };

            var position = input.Aggregate<string, AdvancedSleightPosition>(seedPosition, CalculateAdvancedPosition);

            return position;
        }

        private SleightPosition CalculatePosition(SleightPosition position, string command)
        {
            var parsedCommand = ParseCommandInformation(command);

            if (VerticalMovementCommands.ContainsKey(parsedCommand.command))
            {
                position.Y = VerticalMovementCommands[parsedCommand.command](position.Y, parsedCommand.offset);
            }
            else if (HorizontalMovementCommands.ContainsKey(parsedCommand.command))
            {
                position.X = HorizontalMovementCommands[parsedCommand.command](position.X, parsedCommand.offset);
            }

            return position;
        }

        private AdvancedSleightPosition CalculateAdvancedPosition(AdvancedSleightPosition position, string command)
        {
            var parsedCommand = ParseCommandInformation(command);

            if (VerticalMovementCommands.ContainsKey(parsedCommand.command))
            {
                position.Aim = VerticalMovementCommands[parsedCommand.command](position.Aim, parsedCommand.offset);
            }
            else if (HorizontalMovementCommands.ContainsKey(parsedCommand.command))
            {
                position.X = HorizontalMovementCommands[parsedCommand.command](position.X, parsedCommand.offset);
                position.Y += (parsedCommand.offset * position.Aim);
            }

            return position;
        }

        private (string command, int offset) ParseCommandInformation(string command)
        {
            var commandRegex = new Regex("(\\w+)\\s(\\d+)");
            var match = commandRegex.Match(command);

            if (!match.Success)
            {
                throw new ArgumentException("Unrecognized format of command");
            }

            return (match.Groups[1].Value, int.Parse(match.Groups[2].Value));
        }
    }
}
