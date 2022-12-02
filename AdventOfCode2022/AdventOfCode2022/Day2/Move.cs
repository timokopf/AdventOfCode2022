namespace AdventOfCode2022.Day2
{
    internal class Move
    {
        private readonly Shape _opponent;
        private readonly Outcome _desiredOutcome;

        public Move(Shape left, Outcome desiredOutcome)
        {
            _opponent = left;
            _desiredOutcome = desiredOutcome;
        }

        public static Move ParseInputLine(string inputLine)
        {
            Shape left = inputLine[0] switch
            {
                'A' => Shape.Rock,
                'B' => Shape.Paper,
                'C' => Shape.Scissors,
                _ => throw new NotSupportedException()
            };
            Outcome desiredOutcome = inputLine[2] switch
            {
                'X' => Outcome.Lose,
                'Y' => Outcome.Draw,
                'Z' => Outcome.Win,
                _ => throw new NotSupportedException()
            };

            return new Move(left, desiredOutcome);
        }

        public Round Play()
        {
            Shape player = _desiredOutcome == Outcome.Draw ? _opponent : _opponent switch
            {
                Shape.Rock => _desiredOutcome switch
                {
                    Outcome.Lose => Shape.Scissors,
                    Outcome.Win => Shape.Paper,
                    _ => throw new NotSupportedException()
                },
                Shape.Paper => _desiredOutcome switch
                {
                    Outcome.Lose => Shape.Rock,
                    Outcome.Win => Shape.Scissors,
                    _ => throw new NotSupportedException()
                },
                Shape.Scissors => _desiredOutcome switch
                {
                    Outcome.Lose => Shape.Paper,
                    Outcome.Win => Shape.Rock,
                    _ => throw new NotSupportedException()
                },
                _ => throw new NotSupportedException()
            };

            return new Round(_opponent, player);
        }

        /*public Round Play()
        {
            Shape player = _desiredOutcome == Outcome.Draw ? _opponent : (_opponent, _desiredOutcome) switch
            {
                (Shape.Rock, Outcome.Lose) => Shape.Scissors,
                (Shape.Rock, Outcome.Win) => Shape.Paper,
                (Shape.Paper, Outcome.Lose) => Shape.Rock,
                (Shape.Paper, Outcome.Win) => Shape.Scissors,
                (Shape.Scissors, Outcome.Lose) => Shape.Paper,
                (Shape.Scissors, Outcome.Win) => Shape.Rock,
                _ => throw new UnreachableException()
            };
            return new Round(_opponent, player);
        }*/
    }
}
