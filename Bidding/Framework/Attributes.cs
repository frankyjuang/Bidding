using System;

namespace Bidding.Framework
{
    [AttributeUsage(AttributeTargets.Field)]
    class ColorAttribute : Attribute
    {
        public string AnsiCode { get; }

        public ColorAttribute(string ansiCode)
        {
            AnsiCode = ansiCode;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    class MajorAttribute : Attribute
    {
        public MajorAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Field)]
    class MinorAttribute : Attribute
    {
        public MinorAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Field)]
    class HcpAttribute : Attribute
    {
        public int Point { get; }

        public HcpAttribute(int point)
        {
            Point = point;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    class SymbolAttribute : Attribute
    {
        public string Symbol { get; }

        public SymbolAttribute(string symbol)
        {
            Symbol = symbol;
        }
    }
}