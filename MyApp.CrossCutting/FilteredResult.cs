using System.Collections.Generic;

namespace MyApp.CrossCutting
{
    public class FilteredResult<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Result { get; set; }
    }
}