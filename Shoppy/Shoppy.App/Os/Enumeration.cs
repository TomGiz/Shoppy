namespace Shoppy.App.Os
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public abstract class Enumeration<TKey> : IComparable
        where TKey : IComparable
    {
        protected Enumeration(TKey id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Name { get; }

        public TKey Id { get; }

        public int CompareTo(object other)
        {
            return this.Id.CompareTo(((Enumeration<TKey>)other).Id);
        }

        public override string ToString()
        {
            return this.Name;
        }

        public static IEnumerable<T> GetAll<T>()
            where T : Enumeration<TKey>
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration<TKey>;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = this.GetType().Equals(obj.GetType());
            var valueMatches = this.Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Id);
        }

        // Other utility methods ...
    }
}
