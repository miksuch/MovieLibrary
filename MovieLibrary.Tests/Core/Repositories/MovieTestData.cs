using System.Collections;
using System.Collections.Generic;

namespace MovieLibrary.Tests.Core.Repositories
{
    public class MovieTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                
            },
            new object[]
            {
                
            }
        };

        public IEnumerator<object[]> GetEnumerator() =>
            _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}
