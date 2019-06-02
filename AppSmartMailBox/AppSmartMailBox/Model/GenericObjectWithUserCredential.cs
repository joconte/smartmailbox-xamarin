using System;
using System.Collections.Generic;
using System.Text;

namespace AppSmartMailBox.Model
{
    public class GenericObjectWithUserCredential<T>
    {
        public T t { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
