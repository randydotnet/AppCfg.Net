﻿using AppCfg.TypeParsers;
using System;
using System.Collections.Generic;

namespace AppCfg
{
    public partial class MyAppCfg
    {
        public class TypeParsers
        {
            private static readonly IDictionary<Type, object> _parserStore;

            static TypeParsers()
            {
                _parserStore = new Dictionary<Type, object>();

                // initial default parsers
                Register(new BooleanParser());
                Register(new DateTimeParser());
                Register(new DecimalParser());
                Register(new DoubleParser());
                Register(new GuidParser());                
                Register(new IntParser());
                Register(new LongParser());
                Register(new StringParser());
                Register(new TimeSpanParser());

                Register(new ListBooleanParser());
                Register(new ListDateTimeParser());
                Register(new ListDecimalParser());
                Register(new ListDoubleParser());
                Register(new ListGuidParser());
                Register(new ListIntParser());
                Register(new ListLongParser());
                Register(new ListStringParser());
                Register(new ListTimespanParser());

                Register(new IReadOnlyListBooleanParser());
                Register(new IReadOnlyListDateTimeParser());
                Register(new IReadOnlyListDecimalParser());
                Register(new IReadOnlyListDoubleParser());
                Register(new IReadOnlyListGuidParser());
                Register(new IReadOnlyListIntParser());
                Register(new IReadOnlyListLongParser());
                Register(new IReadOnlyListStringParser());
                Register(new IReadOnlyListTimespanParser());

                Register(new ConnectionStringParser());
            }

            public static void Register<T>(ITypeParser<T> parser)
            {
                var key = typeof(T);

                if (!_parserStore.ContainsKey(key))
                {
                    _parserStore.Add(key, parser);
                }
                else
                {
                    _parserStore[key] = parser;
                }
            }

            internal static void Register(Type key, object parser)
            {
                if (!_parserStore.ContainsKey(key))
                {
                    _parserStore.Add(key, parser);
                }
                else
                {
                    _parserStore[key] = parser;
                }
            }

            internal static object Get(Type propertyType)
            {
                if (!_parserStore.ContainsKey(propertyType))
                {
                    return null;
                }

                return _parserStore[propertyType];
            }
        }
    }
}
