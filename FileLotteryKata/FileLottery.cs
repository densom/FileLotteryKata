using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FileLotteryKata
{
    public class FileLottery : IEnumerable<string>, IEnumerator<string>
    {
        private IRandomProvider _randomProvider;
        private IDirectoryProvider _directoryProvider;
        private readonly List<string> _randomizedItems;
        private readonly List<string> _items; 
        private int _currentItem = 0;


        public FileLottery(IRandomProvider randomProvider, IDirectoryProvider directoryProvider)
        {
            _randomProvider = randomProvider;
            _directoryProvider = directoryProvider;
            _items = directoryProvider.GetFiles().ToList();
        }

        public IEnumerator<string> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_items.Count == 0)
            {
                Current = string.Empty;
                return true;
            }

            Current = _items[_currentItem];
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public string Current { get; private set; }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}