using System.Diagnostics;

namespace AdventOfCode2022.Day2
{
    internal class Round
    {
        private readonly Shape _opponent;
        private readonly Shape _player;

        public static Round ParseInputLine(string inputLine)
        {
            Shape opponent = inputLine[0] switch
            {
                'A' => Shape.Rock,
                'B' => Shape.Paper,
                'C' => Shape.Scissors,
                _ => throw new NotSupportedException()
            };
            Shape player = inputLine[2] switch
            {
                'X' => Shape.Rock,
                'Y' => Shape.Paper,
                'Z' => Shape.Scissors,
                _ => throw new NotSupportedException()
            };

            return new Round(opponent, player);
        }

        public Round(Shape opponent, Shape player)
        {
            _opponent = opponent;
            _player = player;
        }

        public int CalculateScore()
        {
            int selectedShapeScore = (int)_player;
            int outcomeScore = CalculateOutcome() switch
            {
                Outcome.Lose => 0,
                Outcome.Draw => 3,
                Outcome.Win => 6,
                _ => throw new UnreachableException()
            };

            return selectedShapeScore + outcomeScore;
        }

        private Outcome CalculateOutcome()
        {
            if (_opponent == _player)
            {
                return Outcome.Draw;
            }

            return (_opponent, _player) switch
            {
                (Shape.Rock, Shape.Paper) => Outcome.Win,
                (Shape.Rock, Shape.Scissors) => Outcome.Lose,
                (Shape.Paper, Shape.Rock) => Outcome.Lose,
                (Shape.Paper, Shape.Scissors) => Outcome.Win,
                (Shape.Scissors, Shape.Rock) => Outcome.Win,
                (Shape.Scissors, Shape.Paper) => Outcome.Lose,
                _ => throw new UnreachableException()
            };
        }
    }
}

