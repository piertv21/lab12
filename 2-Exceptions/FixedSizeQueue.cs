namespace Exceptions
{
    public class FixedSizeQueue : IFixedSizeQueue
    {
        private object[] _items;
        private int _firstIndex = 0;
        private int _lastIndex = 0;
        
        public FixedSizeQueue(uint capacity)
        {
            Capacity = capacity;
            _items = new object[capacity];
        }
        
        public uint Capacity { get; }

        public uint Count => (uint) (_lastIndex - _firstIndex);

        public object GetFirst()
        {
            if (Count == 0)
            {
                throw new EmptyQueueException("The queue is currently empty. No item can be retrieved.");
            }
            var first = _items[_firstIndex % Capacity];
            _firstIndex++;
            return first;
        }

        public void AddLast(object item)
        {
            if (Count == Capacity)
            {
                throw new FullQueueException("The queue is currently full. No more items can be appended.");
            }
            _items[_lastIndex % Capacity] = item;
            _lastIndex++;
        }
    }
}