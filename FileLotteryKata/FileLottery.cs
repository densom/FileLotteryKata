using System;
using System.Collections;
using System.Collections.Generic;
using FileLotteryKata.Tests;

namespace FileLotteryKata
{
    public class FileLottery : IEnumerable<string>, IEnumerator<string>
    {
        private IRandomProvider _randomProvider;
        private IDirectoryProvider _directoryProvider;
        private readonly List<string> _randomizedItems;


        public FileLottery(IRandomProvider randomProvider, IDirectoryProvider directoryProvider)
        {
            _randomProvider = randomProvider;
            _directoryProvider = directoryProvider;
            Current = string.Empty;
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