namespace OOPHomeworkTwo
{
    using System;

    [AttributeUsage(AttributeTargets.Struct
        | AttributeTargets.Class
        | AttributeTargets.Interface
        | AttributeTargets.Method
        | AttributeTargets.Enum
        , AllowMultiple = true)]

    public class VersionAttribute
        : Attribute
    {
        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major { get; private set; }
        public int Minor { get; private set; }

        public override string ToString()
        {
            return this.Major.ToString() + "." + this.Minor.ToString();
        }
    }

}
