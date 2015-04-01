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
            }
            else
            {
                Current = _items[0];
            }
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            _index++;
            Current = _items[_index];
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