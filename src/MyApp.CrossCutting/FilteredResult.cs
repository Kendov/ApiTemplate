using System.Collections.Generic;

namespace MyApp.CrossCutting
{
    public class FilteredResult<T>
    {
        public long Total { get; set; }
        public IEnumerable<T> Result { get; set; }
    }
}