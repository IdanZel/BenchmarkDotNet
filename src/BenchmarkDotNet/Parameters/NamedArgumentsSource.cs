using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace BenchmarkDotNet.Parameters
{
    public class NamedArgumentsSource<T> : IEnumerable<NamedArgument>
    {
        private readonly List<NamedArgument> arguments;

        private NamedArgumentsSource()
        {
            arguments = new List<NamedArgument>();
        }

        [PublicAPI]
        public static NamedArgumentsSource<T> CreateNew() => new NamedArgumentsSource<T>();

        [PublicAPI]
        public NamedArgumentsSource<T> Add(T value, string name)
        {
            arguments.Add(new NamedArgument(value, name));
            return this;
        }

        public IEnumerator<NamedArgument> GetEnumerator() => arguments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class NamedArgument
    {
        public object Value { get; }

        public string Name { get; }

        internal NamedArgument(object value, string name)
        {
            Value = value;
            Name = name;
        }
    }
}