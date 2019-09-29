using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLineCharOutput.Release {
    public static class ExtensionMethods {

        public static string ToFixedString(this string str, int len) {
            return str.PadRight(len);
        }

        public static string ToFixedString(this int anInt, int len) {
            return anInt.ToString().ToFixedString(len);
        }
        public static string ToFixedStringRight(this int anInt, int len, char fill = ' ') {
            return anInt.ToString().PadLeft(len, fill);
        }
        public static string ToFixedStringRight(this decimal aDecimal, int len, char fill = ' ') {
            return aDecimal.ToString().PadLeft(len, fill);
        }
    }
}
