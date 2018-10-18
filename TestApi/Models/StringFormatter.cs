using System;

namespace TestApi.Models
{
    internal class BracketsStringFormatter : IStringFormatter
    {
        public string Format(string value)
        {
            return "(" + value + ")";
        }
    }

    internal class FullStopStringFormatter : IStringFormatter
    {
        public string Format(string value)
        {
            return value + ".";
        }
    }

    internal class CustomStringFormatter : IStringFormatter, IDisposable
    {
        private string _append;

        public CustomStringFormatter(string append)
        {
            _append = append;
        }

        public void Dispose()
        {
            var i = 0;
            i++;
        }

        public string Format(string value)
        {
            return value + _append;
        }
    }
}