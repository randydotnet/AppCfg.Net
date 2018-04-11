﻿namespace AppCfg.TypeParsers
{
    internal class DoubleParser : ITypeParser<double>
    {
        public double Parse(string rawValue)
        {
            return double.Parse(rawValue, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}