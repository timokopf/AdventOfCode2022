namespace AdventOfCode2022.Day5
{
    internal class CrateStack
    {
        private LinkedListNode? _top;

        public void Push(char crate)
        {
            _top = new LinkedListNode(crate)
            {
                Next = _top
            };
        }

        public char Pop()
        {
            if (_top is null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            char crate = _top.Value;
            _top = _top.Next;

            return crate;
        }

        public void Move(int topN, CrateStack target)
        {
            LinkedListNode? cursor = _top;
            while (topN-- > 1)
            {
                cursor = cursor!.Next;
            }

            var targetTop = target._top;
            target._top = _top;
            _top = cursor!.Next;
            cursor.Next = targetTop;
        }

        internal char Peek()
        {
            if (_top is null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _top.Value;
        }

        private class LinkedListNode
        {
            public char Value { get; }

            public LinkedListNode? Next { get; set; }

            public LinkedListNode(char value)
            {
                Value = value;
            }
        }
    }
}
