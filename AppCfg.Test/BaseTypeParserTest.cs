﻿using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AppCfg.Test
{
    public interface ITypeParserItemSetting
    {
        bool DemoBoolean { get; }
        DateTime DemoDateTime { get; }

        [Option(InputFormat = "dd+MM/yyyy")]
        DateTime DemoDateTimeWithFormat { get; }

        decimal DemoDecimal { get; }
        double DemoDouble { get; }
        Guid DemoGuid { get; }

        [Option(DefaultValue = 77)]
        int DemoInt { get; }

        long DemoLong { get; }

        string DemoString { get; }
        TimeSpan DemoTimeSpanFirst { get; }
        TimeSpan DemoTimeSpanSecond { get; }

        [Option(Separator = "^")]
        List<int> Numbers { get; }

        [Option(RawValue = "1;2;3;4;5", Separator = ";")]
        List<int> NumbersWithInitialRawValue { get; }

        [Option(Separator = "~")]
        List<string> Strings { get; }
    }

    [TestFixture]
    public class BaseTypeParserTest
    {
        ITypeParserItemSetting settings = MyAppCfg.Get<ITypeParserItemSetting>();

        [Test]
        public void TypeParserValueTest()
        {
            Assert.AreEqual(settings.DemoBoolean, true);
            Assert.AreEqual(settings.DemoDateTime, new DateTime(2017, 11, 29, 23, 39, 03));
            Assert.AreEqual(settings.DemoDateTimeWithFormat, new DateTime(2015, 09, 24));
            Assert.AreEqual(settings.DemoDecimal, -12336.8999);
            Assert.AreEqual(settings.DemoDouble, 1.7E+3);
            Assert.AreEqual(settings.DemoGuid, new Guid("8ff3a01d-1884-4ebd-b787-d5980aa94899"));
            Assert.AreEqual(settings.DemoInt, 17);
            Assert.AreEqual(settings.DemoLong, 9223372036854775807);
            Assert.AreEqual(settings.DemoString, "hello, I'm a string ");
            Assert.AreEqual(settings.DemoTimeSpanFirst, new TimeSpan(01, 02, 03));
            Assert.AreEqual(settings.DemoTimeSpanSecond, new TimeSpan(01, 02, 03, 04));

            Assert.AreEqual(settings.Numbers, new List<int> { 1, 99, 123456789 });
            Assert.AreEqual(settings.NumbersWithInitialRawValue, new List<int> { 1,2,3,4,5 });
            Assert.AreEqual(settings.Strings, new List<string> { "luong ", "son", " ba ", "chuc anh dai  " });
        }
    }
}
