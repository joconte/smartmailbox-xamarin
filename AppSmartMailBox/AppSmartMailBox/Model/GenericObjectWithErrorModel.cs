using System;
using System.Collections.Generic;
using System.Text;

namespace AppSmartMailBox.Model
{
    public class GenericObjectWithErrorModel<T>
    {
        public T t { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
