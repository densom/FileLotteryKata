using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FileLotteryKata
{
    public class FileLottery : IEnumerator<string>
    {
        private IRandomProvider _randomProvider;
        private IDirectoryProvider _directoryProvider;
        private List<string> _randomizedItems;
        private readonly List<string> _items; 
        private int _index = 0;


        public FileLottery(IRandomProvider randomProvider, IDirectoryProvider directoryProvider)
        {
            _randomProvider = randomProvider;
            _directoryProvider = directoryProvider;
            _items = directoryProvider.GetFiles().ToList();

            if (_items.Count == 0)
            {
                Current = string.Empty;
                return;
            }

            _randomizedItems = Randomize();
            Current = _randomizedItems[0];
            
            
        }

        private List<string> Randomize()
        {
            var sortedList = new List<string>(_items.Count);

            _randomProvider.SetMaxIndex = _items.Count - 1;
            foreach (var randomUniqueValue in _randomProvider.GetRandomUniqueValues())
            {
                sortedList.Add(_items[randomUniqueValue]);
            }

            return sortedList;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            _index++;
            Current = _randomizedItems[_index];
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