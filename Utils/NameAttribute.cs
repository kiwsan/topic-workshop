using System;

namespace Topic.Utils
{
    public class NameAttribute : Attribute
    {
        public NameAttribute(string name)
        {
            PropertyName = name;
        }

        public string PropertyName { get; set; }
    }
}