using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMailBoxLib.Models
{
    public class GenericObjectWithErrorModel<T>
    {
        public T t { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
