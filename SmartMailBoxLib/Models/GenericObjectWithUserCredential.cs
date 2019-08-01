using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMailBoxLib.Models
{
    public class GenericObjectWithUserCredential<T>
    {
        public T t { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
