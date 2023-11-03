using System.Numerics;

namespace WinFormsApp1
{
    internal class NumericTypesSuggester
    {
        const string ImpossibleRepresentation = "";
        const string Decimal = "decimal";
        const string Float = "float";
        const string Double = "double";
        const string Byte = "byte";
        const string UShort = "ushort";
        const string UInt = "uint";
        const string ULong = "ulong";
        const string BigInteger = "biginteger";
        const string SByte = "sbyte";
        const string Short = "short";
        const string Int = "int";
        const string Long = "long";
        


        internal static string GetName(BigInteger minValue, BigInteger maxValue, bool integralOnly, bool mustBePrecise)
        {
            return integralOnly ? GetIntegralNumberName(minValue, maxValue) : GetFloatingPointNumberName(minValue, maxValue, mustBePrecise);
        }

        private static string GetFloatingPointNumberName(BigInteger minValue, BigInteger maxValue, bool mustBePrecise)
        {
            return mustBePrecise ? GetPreciseFloatingPointNumberName(minValue, maxValue) : GetImpreciseFloatingPointNumberName(minValue, maxValue);
        }

        private static string GetImpreciseFloatingPointNumberName(BigInteger minValue, BigInteger maxValue)
        {
            if(minValue>= new BigInteger(float.MinValue)  && maxValue <= new BigInteger(float.MaxValue))
            {
                return Float;
            }
            if (minValue >= new BigInteger(double.MinValue) && maxValue <= new BigInteger(double.MaxValue))
            {
                return Double;
            }
            return ImpossibleRepresentation;
        }

        private static string GetPreciseFloatingPointNumberName(BigInteger minValue, BigInteger maxValue)
        {
            if(minValue >= new BigInteger(decimal.MinValue) && maxValue <= new BigInteger(decimal.MaxValue))
            {
                return Decimal;
            }
            return ImpossibleRepresentation;
        }

        private static string GetIntegralNumberName(BigInteger minValue, BigInteger maxValue)
        {
            return minValue >= 0 ? GetUnsignedIntegralNumberName(maxValue) : GetSignedIntegralNumberName(minValue, maxValue);
        }

        private static string GetSignedIntegralNumberName(BigInteger minValue, BigInteger maxValue)
        {
            if(minValue >= sbyte.MinValue && maxValue <= sbyte.MaxValue)
            {
                return SByte;
            }
            if (minValue >= short.MinValue && maxValue <= short.MaxValue)
            {
                return Short;
            }
            if (minValue >= int.MinValue && maxValue <= int.MaxValue)
            {
                return Int;
            }
            if (minValue >= long.MinValue && maxValue <= long.MaxValue)
            {
                return Long;
            }
            return BigInteger;
        }

        private static string GetUnsignedIntegralNumberName(BigInteger maxValue)
        {
            if(maxValue <= byte.MaxValue)
            {
                return Byte;
            }
            if (maxValue <= ushort.MaxValue)
            {
                return UShort;
            }
            if (maxValue <= uint.MaxValue)
            {
                return UInt;
            }
            if (maxValue <= ulong.MaxValue)
            {
                return ULong;
            }
            return BigInteger;
        }
    }
}