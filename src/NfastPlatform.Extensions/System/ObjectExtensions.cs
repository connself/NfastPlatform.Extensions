using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace System
{
    public static class ObjectExtensions
    {
        #region Utility

        /// <summary>
        ///     An object extension method that converts the @this to string or return an empty string if the value is null.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a string or empty if the value is null.</returns>
        public static string ToStringSafe(this object @this)
        {
            return @this == null ? "" : @this.ToString();
        }

        #endregion

        #region Casting

        /// <summary>
        ///     An object extension method that cast anonymous type to the specified type.
        /// </summary>
        /// <typeparam name="T">Generic type parameter. The specified type.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The object as the specified type.</returns>
        public static T As<T>(this object @this)
        {
            return (T)@this;
        }

        /// <summary>
        ///     An object extension method that converts the @this to an or default.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>A T.</returns>
        public static T AsOrDefault<T>(this object @this)
        {
            try
            {
                return (T)@this;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        ///     An object extension method that converts the @this to an or default.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>A T.</returns>
        public static T AsOrDefault<T>(this object @this, T defaultValue)
        {
            try
            {
                return (T)@this;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        #endregion

        #region Convert

        #region ToValueType

        #region ToBoolean

        /// <summary>
        ///     An object extension method that converts the @this to a boolean.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a bool.</returns>
        public static bool ToBoolean(this object @this)
        {
            return Convert.ToBoolean(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a boolean or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a bool.</returns>
        public static bool ToBooleanOrDefault(this object @this)
        {
            try
            {
                return Convert.ToBoolean(@this);
            }
            catch (Exception)
            {
                return default(bool);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a boolean or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">true to default value.</param>
        /// <returns>The given data converted to a bool.</returns>
        public static bool ToBooleanOrDefault(this object @this, bool defaultValue)
        {
            try
            {
                return Convert.ToBoolean(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// An object extension method that converts this object to a boolean or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">true to default value.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a bool.</returns>
        public static bool ToBooleanOrDefault(this object @this, bool defaultValue, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToBoolean(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a boolean or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a bool.</returns>
        public static bool ToBooleanOrDefault(this object @this, Func<bool> defaultValueFactory)
        {
            try
            {
                return Convert.ToBoolean(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a boolean or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a bool.</returns>
        public static bool ToBooleanOrDefault(this object @this, Func<bool> defaultValueFactory, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValueFactory();
            }

            try
            {
                return Convert.ToBoolean(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        ///     An object extension method that converts the @this to a nullable boolean.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a bool?</returns>
        public static bool? ToNullableBoolean(this object @this)
        {
            if (@this == null || @this == DBNull.Value)
            {
                return null;
            }

            return Convert.ToBoolean(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable boolean or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a bool?</returns>
        public static bool? ToNullableBooleanOrDefault(this object @this)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToBoolean(@this);
            }
            catch (Exception)
            {
                return default(bool);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable boolean or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a bool?</returns>
        public static bool? ToNullableBooleanOrDefault(this object @this, bool? defaultValue)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToBoolean(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable boolean or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a bool?</returns>
        public static bool? ToNullableBooleanOrDefault(this object @this, Func<bool?> defaultValueFactory)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToBoolean(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        #endregion

        #region ToChar

        /// <summary>
        ///     An object extension method that converts the @this to a character.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a char.</returns>
        public static char ToChar(this object @this)
        {
            return Convert.ToChar(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a character or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a char.</returns>
        public static char ToCharOrDefault(this object @this)
        {
            try
            {
                return Convert.ToChar(@this);
            }
            catch (Exception)
            {
                return default(char);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a character or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a char.</returns>
        public static char ToCharOrDefault(this object @this, char defaultValue)
        {
            try
            {
                return Convert.ToChar(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a character or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a char.</returns>
        public static char ToCharOrDefault(this object @this, char defaultValue, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToChar(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a character or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a char.</returns>
        public static char ToCharOrDefault(this object @this, Func<char> defaultValueFactory)
        {
            try
            {
                return Convert.ToChar(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a character or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a char.</returns>
        public static char ToCharOrDefault(this object @this, Func<char> defaultValueFactory, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValueFactory();
            }

            try
            {
                return Convert.ToChar(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        ///     An object extension method that converts the @this to a nullable character.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a char?</returns>
        public static char? ToNullableChar(this object @this)
        {
            if (@this == null || @this == DBNull.Value)
            {
                return null;
            }

            return Convert.ToChar(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable character or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a char?</returns>
        public static char? ToNullableCharOrDefault(this object @this)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToChar(@this);
            }
            catch (Exception)
            {
                return default(char);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable character or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a char?</returns>
        public static char? ToNullableCharOrDefault(this object @this, char? defaultValue)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToChar(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable character or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a char?</returns>
        public static char? ToNullableCharOrDefault(this object @this, Func<char?> defaultValueFactory)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToChar(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        #endregion

        #region ToDateTime

        /// <summary>
        ///     An object extension method that converts the @this to a date time.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a DateTime.</returns>
        public static DateTime ToDateTime(this object @this)
        {
            return Convert.ToDateTime(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a date time or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a DateTime.</returns>
        public static DateTime ToDateTimeOrDefault(this object @this)
        {
            try
            {
                return Convert.ToDateTime(@this);
            }
            catch (Exception)
            {
                return default(DateTime);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a date time or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a DateTime.</returns>
        public static DateTime ToDateTimeOrDefault(this object @this, DateTime defaultValue)
        {
            try
            {
                return Convert.ToDateTime(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a date time or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a DateTime.</returns>
        public static DateTime ToDateTimeOrDefault(this object @this, DateTime defaultValue, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToDateTime(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a date time or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a DateTime.</returns>
        public static DateTime ToDateTimeOrDefault(this object @this, Func<DateTime> defaultValueFactory)
        {
            try
            {
                return Convert.ToDateTime(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a date time or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a DateTime.</returns>
        public static DateTime ToDateTimeOrDefault(this object @this, Func<DateTime> defaultValueFactory, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValueFactory();
            }

            try
            {
                return Convert.ToDateTime(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        ///     An object extension method that converts the @this to a nullable date time.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a DateTime?</returns>
        public static DateTime? ToNullableDateTime(this object @this)
        {
            if (@this == null || @this == DBNull.Value)
            {
                return null;
            }

            return Convert.ToDateTime(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable date time or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a DateTime?</returns>
        public static DateTime? ToNullableDateTimeOrDefault(this object @this)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToDateTime(@this);
            }
            catch (Exception)
            {
                return default(DateTime);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable date time or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a DateTime?</returns>
        public static DateTime? ToNullableDateTimeOrDefault(this object @this, DateTime? defaultValue)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToDateTime(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable date time or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a DateTime?</returns>
        public static DateTime? ToNullableDateTimeOrDefault(this object @this, Func<DateTime?> defaultValueFactory)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToDateTime(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }
        #endregion

        #region ToDateTimeOffSet

        /// <summary>
        ///     An object extension method that converts the @this to a date time off set.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a DateTimeOffset.</returns>
        public static DateTimeOffset ToDateTimeOffSet(this object @this)
        {
            return new DateTimeOffset(Convert.ToDateTime(@this), TimeSpan.Zero);
        }

        /// <summary>
        ///     An object extension method that converts this object to a date time off set or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a DateTimeOffset.</returns>
        public static DateTimeOffset ToDateTimeOffSetOrDefault(this object @this)
        {
            try
            {
                return new DateTimeOffset(Convert.ToDateTime(@this), TimeSpan.Zero);
            }
            catch (Exception)
            {
                return default(DateTimeOffset);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a date time off set or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a DateTimeOffset.</returns>
        public static DateTimeOffset ToDateTimeOffSetOrDefault(this object @this, DateTimeOffset defaultValue)
        {
            try
            {
                return new DateTimeOffset(Convert.ToDateTime(@this), TimeSpan.Zero);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a date time off set or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a DateTimeOffset.</returns>
        public static DateTimeOffset ToDateTimeOffSetOrDefault(this object @this, DateTimeOffset defaultValue, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValue;
            }

            try
            {
                return new DateTimeOffset(Convert.ToDateTime(@this), TimeSpan.Zero);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a date time off set or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a DateTimeOffset.</returns>
        public static DateTimeOffset ToDateTimeOffSetOrDefault(this object @this, Func<DateTimeOffset> defaultValueFactory)
        {
            try
            {
                return new DateTimeOffset(Convert.ToDateTime(@this), TimeSpan.Zero);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a date time off set or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a DateTimeOffset.</returns>
        public static DateTimeOffset ToDateTimeOffSetOrDefault(this object @this, Func<DateTimeOffset> defaultValueFactory, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValueFactory();
            }

            try
            {
                return new DateTimeOffset(Convert.ToDateTime(@this), TimeSpan.Zero);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        ///     An object extension method that converts the @this to a nullable date time off set.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a DateTimeOffset?</returns>
        public static DateTimeOffset? ToNullableDateTimeOffSet(this object @this)
        {
            if (@this == null || @this == DBNull.Value)
            {
                return null;
            }

            return new DateTimeOffset(Convert.ToDateTime(@this), TimeSpan.Zero);
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable date time off set or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a DateTimeOffset?</returns>
        public static DateTimeOffset? ToNullableDateTimeOffSetOrDefault(this object @this)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return new DateTimeOffset(Convert.ToDateTime(@this), TimeSpan.Zero);
            }
            catch (Exception)
            {
                return default(DateTimeOffset);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable date time off set or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a DateTimeOffset?</returns>
        public static DateTimeOffset? ToNullableDateTimeOffSetOrDefault(this object @this, DateTimeOffset? defaultValue)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return new DateTimeOffset(Convert.ToDateTime(@this), TimeSpan.Zero);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable date time off set or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a DateTimeOffset?</returns>
        public static DateTimeOffset? ToNullableDateTimeOffSetOrDefault(this object @this, Func<DateTimeOffset?> defaultValueFactory)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return new DateTimeOffset(Convert.ToDateTime(@this), TimeSpan.Zero);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        #endregion

        #region ToDecimal

        /// <summary>
        ///     An object extension method that converts the @this to a decimal.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a decimal.</returns>
        public static decimal ToDecimal(this object @this)
        {
            return Convert.ToDecimal(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a decimal or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a decimal.</returns>
        public static decimal ToDecimalOrDefault(this object @this)
        {
            try
            {
                return Convert.ToDecimal(@this);
            }
            catch (Exception)
            {
                return default(decimal);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a decimal or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a decimal.</returns>
        public static decimal ToDecimalOrDefault(this object @this, decimal defaultValue)
        {
            try
            {
                return Convert.ToDecimal(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a decimal or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a decimal.</returns>
        public static decimal ToDecimalOrDefault(this object @this, decimal defaultValue, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToDecimal(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a decimal or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a decimal.</returns>
        public static decimal ToDecimalOrDefault(this object @this, Func<decimal> defaultValueFactory)
        {
            try
            {
                return Convert.ToDecimal(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a decimal or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a decimal.</returns>
        public static decimal ToDecimalOrDefault(this object @this, Func<decimal> defaultValueFactory, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValueFactory();
            }

            try
            {
                return Convert.ToDecimal(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        ///     An object extension method that converts the @this to a nullable decimal.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a decimal?</returns>
        public static decimal? ToNullableDecimal(this object @this)
        {
            if (@this == null || @this == DBNull.Value)
            {
                return null;
            }

            return Convert.ToDecimal(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable decimal or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a decimal?</returns>
        public static decimal? ToNullableDecimalOrDefault(this object @this)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToDecimal(@this);
            }
            catch (Exception)
            {
                return default(decimal);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable decimal or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a decimal?</returns>
        public static decimal? ToNullableDecimalOrDefault(this object @this, decimal? defaultValue)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToDecimal(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable decimal or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a decimal?</returns>
        public static decimal? ToNullableDecimalOrDefault(this object @this, Func<decimal?> defaultValueFactory)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToDecimal(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        #endregion

        #region ToDouble

        /// <summary>
        ///     An object extension method that converts the @this to a double.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a double.</returns>
        public static double ToDouble(this object @this)
        {
            return Convert.ToDouble(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a double or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a double.</returns>
        public static double ToDoubleOrDefault(this object @this)
        {
            try
            {
                return Convert.ToDouble(@this);
            }
            catch (Exception)
            {
                return default(double);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a double or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a double.</returns>
        public static double ToDoubleOrDefault(this object @this, double defaultValue)
        {
            try
            {
                return Convert.ToDouble(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a double or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a double.</returns>
        public static double ToDoubleOrDefault(this object @this, double defaultValue, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToDouble(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a double or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a double.</returns>
        public static double ToDoubleOrDefault(this object @this, Func<double> defaultValueFactory)
        {
            try
            {
                return Convert.ToDouble(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a double or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a double.</returns>
        public static double ToDoubleOrDefault(this object @this, Func<double> defaultValueFactory, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValueFactory();
            }

            try
            {
                return Convert.ToDouble(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        ///     An object extension method that converts the @this to a nullable double.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a double?</returns>
        public static double? ToNullableDouble(this object @this)
        {
            if (@this == null || @this == DBNull.Value)
            {
                return null;
            }

            return Convert.ToDouble(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable double or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a double?</returns>
        public static double? ToNullableDoubleOrDefault(this object @this)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToDouble(@this);
            }
            catch (Exception)
            {
                return default(double);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable double or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a double?</returns>
        public static double? ToNullableDoubleOrDefault(this object @this, double? defaultValue)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToDouble(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable double or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a double?</returns>
        public static double? ToNullableDoubleOrDefault(this object @this, Func<double?> defaultValueFactory)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToDouble(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        #endregion

        #region ToFloat

        /// <summary>
        ///     An object extension method that converts the @this to a float.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a float.</returns>
        public static float ToFloat(this object @this)
        {
            return Convert.ToSingle(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a float or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a float.</returns>
        public static float ToFloatOrDefault(this object @this)
        {
            try
            {
                return Convert.ToSingle(@this);
            }
            catch (Exception)
            {
                return default(float);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a float or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a float.</returns>
        public static float ToFloatOrDefault(this object @this, float defaultValue)
        {
            try
            {
                return Convert.ToSingle(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a float or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a float.</returns>
        public static float ToFloatOrDefault(this object @this, float defaultValue, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToSingle(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a float or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a float.</returns>
        public static float ToFloatOrDefault(this object @this, Func<float> defaultValueFactory)
        {
            try
            {
                return Convert.ToSingle(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a float or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a float.</returns>
        public static float ToFloatOrDefault(this object @this, Func<float> defaultValueFactory, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValueFactory();
            }

            try
            {
                return Convert.ToSingle(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        ///     An object extension method that converts the @this to a nullable float.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a float?</returns>
        public static float? ToNullableFloat(this object @this)
        {
            if (@this == null || @this == DBNull.Value)
            {
                return null;
            }

            return Convert.ToSingle(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable float or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a float?</returns>
        public static float? ToNullableFloatOrDefault(this object @this)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToSingle(@this);
            }
            catch (Exception)
            {
                return default(float);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable float or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a float?</returns>
        public static float? ToNullableFloatOrDefault(this object @this, float? defaultValue)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToSingle(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable float or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a float?</returns>
        public static float? ToNullableFloatOrDefault(this object @this, Func<float?> defaultValueFactory)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToSingle(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        #endregion

        #region ToGuid

        /// <summary>
        ///     An object extension method that converts the @this to a unique identifier.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a GUID.</returns>
        public static Guid ToGuid(this object @this)
        {
            return new Guid(@this.ToString());
        }

        /// <summary>
        ///     An object extension method that converts this object to a unique identifier or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a GUID.</returns>
        public static Guid ToGuidOrDefault(this object @this)
        {
            try
            {
                return new Guid(@this.ToString());
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a unique identifier or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a GUID.</returns>
        public static Guid ToGuidOrDefault(this object @this, Guid defaultValue)
        {
            try
            {
                return new Guid(@this.ToString());
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a unique identifier or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a GUID.</returns>
        public static Guid ToGuidOrDefault(this object @this, Guid defaultValue, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValue;
            }

            try
            {
                return new Guid(@this.ToString());
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a unique identifier or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a GUID.</returns>
        public static Guid ToGuidOrDefault(this object @this, Func<Guid> defaultValueFactory)
        {
            try
            {
                return new Guid(@this.ToString());
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        /// An object extension method that converts this object to a unique identifier or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a GUID.</returns>
        public static Guid ToGuidOrDefault(this object @this, Func<Guid> defaultValueFactory, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValueFactory();
            }

            try
            {
                return new Guid(@this.ToString());
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        ///     An object extension method that converts the @this to a nullable unique identifier.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a Guid?</returns>
        public static Guid? ToNullableGuid(this object @this)
        {
            if (@this == null || @this == DBNull.Value)
            {
                return null;
            }

            return new Guid(@this.ToString());
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable unique identifier or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a Guid?</returns>
        public static Guid? ToNullableGuidOrDefault(this object @this)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return new Guid(@this.ToString());
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable unique identifier or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a Guid?</returns>
        public static Guid? ToNullableGuidOrDefault(this object @this, Guid? defaultValue)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return new Guid(@this.ToString());
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable unique identifier or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a Guid?</returns>
        public static Guid? ToNullableGuidOrDefault(this object @this, Func<Guid?> defaultValueFactory)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return new Guid(@this.ToString());
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        #endregion

        #region ToInt16

        /// <summary>
        ///     An object extension method that converts the @this to an int 16.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a short.</returns>
        public static short ToInt16(this object @this)
        {
            return Convert.ToInt16(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to an int 16 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a short.</returns>
        public static short ToInt16OrDefault(this object @this)
        {
            try
            {
                return Convert.ToInt16(@this);
            }
            catch (Exception)
            {
                return default(short);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to an int 16 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a short.</returns>
        public static short ToInt16OrDefault(this object @this, short defaultValue)
        {
            try
            {
                return Convert.ToInt16(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// An object extension method that converts this object to an int 16 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a short.</returns>
        public static short ToInt16OrDefault(this object @this, short defaultValue, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToInt16(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to an int 16 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a short.</returns>
        public static short ToInt16OrDefault(this object @this, Func<short> defaultValueFactory)
        {
            try
            {
                return Convert.ToInt16(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        /// An object extension method that converts this object to an int 16 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a short.</returns>
        public static short ToInt16OrDefault(this object @this, Func<short> defaultValueFactory, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValueFactory();
            }

            try
            {
                return Convert.ToInt16(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        ///     An object extension method that converts the @this to a nullable int 16.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a short?</returns>
        public static short? ToNullableInt16(this object @this)
        {
            if (@this == null || @this == DBNull.Value)
            {
                return null;
            }

            return Convert.ToInt16(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable int 16 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a short?</returns>
        public static short? ToNullableInt16OrDefault(this object @this)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToInt16(@this);
            }
            catch (Exception)
            {
                return default(short);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable int 16 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a short?</returns>
        public static short? ToNullableInt16OrDefault(this object @this, short? defaultValue)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToInt16(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable int 16 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a short?</returns>
        public static short? ToNullableInt16OrDefault(this object @this, Func<short?> defaultValueFactory)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToInt16(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        #endregion

        #region ToInt32

        /// <summary>
        ///     An object extension method that converts the @this to an int 32.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as an int.</returns>
        public static int ToInt32(this object @this)
        {
            return Convert.ToInt32(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to an int 32 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to an int.</returns>
        public static int ToInt32OrDefault(this object @this)
        {
            try
            {
                return Convert.ToInt32(@this);
            }
            catch (Exception)
            {
                return default(int);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to an int 32 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to an int.</returns>
        public static int ToInt32OrDefault(this object @this, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// An object extension method that converts this object to an int 32 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to an int.</returns>
        public static int ToInt32OrDefault(this object @this, int defaultValue, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToInt32(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to an int 32 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to an int.</returns>
        public static int ToInt32OrDefault(this object @this, Func<int> defaultValueFactory)
        {
            try
            {
                return Convert.ToInt32(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        /// An object extension method that converts this object to an int 32 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to an int.</returns>
        public static int ToInt32OrDefault(this object @this, Func<int> defaultValueFactory, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValueFactory();
            }

            try
            {
                return Convert.ToInt32(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        ///     An object extension method that converts the @this to a nullable int 32.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as an int?</returns>
        public static int? ToNullableInt32(this object @this)
        {
            if (@this == null || @this == DBNull.Value)
            {
                return null;
            }

            return Convert.ToInt32(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable int 32 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to an int?</returns>
        public static int? ToNullableInt32OrDefault(this object @this)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToInt32(@this);
            }
            catch (Exception)
            {
                return default(int);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable int 32 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to an int?</returns>
        public static int? ToNullableInt32OrDefault(this object @this, int? defaultValue)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToInt32(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable int 32 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to an int?</returns>
        public static int? ToNullableInt32OrDefault(this object @this, Func<int?> defaultValueFactory)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToInt32(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        #endregion

        #region ToInt64

        /// <summary>
        ///     An object extension method that converts the @this to an int 64.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a long.</returns>
        public static long ToInt64(this object @this)
        {
            return Convert.ToInt64(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to an int 64 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a long.</returns>
        public static long ToInt64OrDefault(this object @this)
        {
            try
            {
                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return default(long);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to an int 64 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a long.</returns>
        public static long ToInt64OrDefault(this object @this, long defaultValue)
        {
            try
            {
                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// An object extension method that converts this object to an int 64 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a long.</returns>
        public static long ToInt64OrDefault(this object @this, long defaultValue, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to an int 64 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a long.</returns>
        public static long ToInt64OrDefault(this object @this, Func<long> defaultValueFactory)
        {
            try
            {
                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        /// An object extension method that converts this object to an int 64 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a long.</returns>
        public static long ToInt64OrDefault(this object @this, Func<long> defaultValueFactory, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValueFactory();
            }

            try
            {
                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        ///     An object extension method that converts the @this to a nullable int 64.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a long?</returns>
        public static long? ToNullableInt64(this object @this)
        {
            if (@this == null || @this == DBNull.Value)
            {
                return null;
            }

            return Convert.ToInt64(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable int 64 or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a long?</returns>
        public static long? ToNullableInt64OrDefault(this object @this)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return default(long);
            }
        }

        #endregion

        #region ToLong

        /// <summary>
        ///     An object extension method that converts the @this to a long.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a long.</returns>
        public static long ToLong(this object @this)
        {
            return Convert.ToInt64(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a long or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a long.</returns>
        public static long ToLongOrDefault(this object @this)
        {
            try
            {
                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return default(long);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a long or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a long.</returns>
        public static long ToLongOrDefault(this object @this, long defaultValue)
        {
            try
            {
                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>An object extension method that converts this object to a long or default.</summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a long.</returns>
        public static long ToLongOrDefault(this object @this, long defaultValue, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a long or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a long.</returns>
        public static long ToLongOrDefault(this object @this, Func<long> defaultValueFactory)
        {
            try
            {
                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>An object extension method that converts this object to a long or default.</summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <param name="useDefaultIfNull">true to use default if null.</param>
        /// <returns>The given data converted to a long.</returns>
        public static long ToLongOrDefault(this object @this, Func<long> defaultValueFactory, bool useDefaultIfNull)
        {
            if (useDefaultIfNull && @this == null)
            {
                return defaultValueFactory();
            }

            try
            {
                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        /// <summary>
        ///     An object extension method that converts the @this to a nullable long.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>@this as a long?</returns>
        public static long? ToNullableLong(this object @this)
        {
            if (@this == null || @this == DBNull.Value)
            {
                return null;
            }

            return Convert.ToInt64(@this);
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable long or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The given data converted to a long?</returns>
        public static long? ToNullableLongOrDefault(this object @this)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return default(long);
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable long or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a long?</returns>
        public static long? ToNullableLongOrDefault(this object @this, long? defaultValue)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        ///     An object extension method that converts this object to a nullable long or default.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a long?</returns>
        public static long? ToNullableLongOrDefault(this object @this, Func<long?> defaultValueFactory)
        {
            try
            {
                if (@this == null || @this == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToInt64(@this);
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        #endregion

        #endregion

        #region IsValidValueType

        /// <summary>
        ///     An object extension method that query if '@this' is valid bool.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid bool, false if not.</returns>
        public static bool IsValidBoolean(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            bool result;
            return bool.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid byte.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid byte, false if not.</returns>
        public static bool IsValidByte(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            byte result;
            return byte.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid char.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid char, false if not.</returns>
        public static bool IsValidChar(this object @this)
        {
            char result;
            return char.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid System.DateTime.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid System.DateTime, false if not.</returns>
        public static bool IsValidDateTime(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            DateTime result;
            return DateTime.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid System.DateTimeOffset.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid System.DateTimeOffset, false if not.</returns>
        public static bool IsValidDateTimeOffSet(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            DateTimeOffset result;
            return DateTimeOffset.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid decimal.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid decimal, false if not.</returns>
        public static bool IsValidDecimal(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            decimal result;
            return decimal.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid double.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid double, false if not.</returns>
        public static bool IsValidDouble(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            double result;
            return double.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid float.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid float, false if not.</returns>
        public static bool IsValidFloat(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            float result;
            return float.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid System.Guid.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid System.Guid, false if not.</returns>
        public static bool IsValidGuid(this object @this)
        {
            Guid result;
            return Guid.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid short.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid short, false if not.</returns>
        public static bool IsValidInt16(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            short result;
            return short.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid int.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid int, false if not.</returns>
        public static bool IsValidInt32(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            int result;
            return int.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid long.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid long, false if not.</returns>
        public static bool IsValidInt64(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            long result;
            return long.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid long.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid long, false if not.</returns>
        public static bool IsValidLong(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            long result;
            return long.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid sbyte.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid sbyte, false if not.</returns>
        public static bool IsValidSByte(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            sbyte result;
            return sbyte.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid short.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid short, false if not.</returns>
        public static bool IsValidShort(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            short result;
            return short.TryParse(@this.ToString(), out result);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is valid float.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if valid float, false if not.</returns>
        public static bool IsValidSingle(this object @this)
        {
            if (@this == null)
            {
                return true;
            }

            float result;
            return float.TryParse(@this.ToString(), out result);
        }

        #endregion

        /// <summary>
        ///     Returns an object of the specified type whose value is equivalent to the specified object.
        /// </summary>
        /// <param name="value">An object that implements the  interface.</param>
        /// <param name="typeCode">The type of object to return.</param>
        /// <returns>
        ///     An object whose underlying type is  and whose value is equivalent to .-or-A null reference (Nothing in Visual
        ///     Basic), if  is null and  is , , or .
        /// </returns>
        public static Object ChangeType(this Object value, TypeCode typeCode)
        {
            return Convert.ChangeType(value, typeCode);
        }

        /// <summary>
        ///     Returns an object of the specified type whose value is equivalent to the specified object. A parameter
        ///     supplies culture-specific formatting information.
        /// </summary>
        /// <param name="value">An object that implements the  interface.</param>
        /// <param name="typeCode">The type of object to return.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        ///     An object whose underlying type is  and whose value is equivalent to .-or- A null reference (Nothing in
        ///     Visual Basic), if  is null and  is , , or .
        /// </returns>
        public static Object ChangeType(this Object value, TypeCode typeCode, IFormatProvider provider)
        {
            return Convert.ChangeType(value, typeCode, provider);
        }

        /// <summary>
        ///     Returns an object of the specified type and whose value is equivalent to the specified object.
        /// </summary>
        /// <param name="value">An object that implements the  interface.</param>
        /// <param name="conversionType">The type of object to return.</param>
        /// <returns>
        ///     An object whose type is  and whose value is equivalent to .-or-A null reference (Nothing in Visual Basic), if
        ///     is null and  is not a value type.
        /// </returns>
        public static Object ChangeType(this Object value, Type conversionType)
        {
            return Convert.ChangeType(value, conversionType);
        }

        /// <summary>
        ///     Returns an object of the specified type whose value is equivalent to the specified object. A parameter
        ///     supplies culture-specific formatting information.
        /// </summary>
        /// <param name="value">An object that implements the  interface.</param>
        /// <param name="conversionType">The type of object to return.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        ///     An object whose type is  and whose value is equivalent to .-or- , if the  of  and  are equal.-or- A null
        ///     reference (Nothing in Visual Basic), if  is null and  is not a value type.
        /// </returns>
        public static Object ChangeType(this Object value, Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(value, conversionType, provider);
        }

        /// <summary>
        ///     Returns an object of the specified type and whose value is equivalent to the specified object.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="value">An object that implements the  interface.</param>
        /// <returns>
        ///     An object whose type is  and whose value is equivalent to .-or-A null reference (Nothing in Visual Basic), if
        ///     is null and  is not a value type.
        /// </returns>
        public static Object ChangeType<T>(this Object value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        ///     Returns an object of the specified type whose value is equivalent to the specified object. A parameter
        ///     supplies culture-specific formatting information.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="value">An object that implements the  interface.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        ///     An object whose type is  and whose value is equivalent to .-or- , if the  of  and  are equal.-or- A null
        ///     reference (Nothing in Visual Basic), if  is null and  is not a value type.
        /// </returns>
        public static Object ChangeType<T>(this Object value, IFormatProvider provider)
        {
            return (T)Convert.ChangeType(value, typeof(T), provider);
        }

        /// <summary>
        ///     Returns the  for the specified object.
        /// </summary>
        /// <param name="value">An object that implements the  interface.</param>
        /// <returns>The  for , or  if  is null.</returns>
        public static TypeCode GetTypeCode(this Object value)
        {
            return Convert.GetTypeCode(value);
        }

        /// <summary>
        ///     A System.Object extension method that toes the given this.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">this.</param>
        /// <returns>A T.</returns>
        /// <example>
        ///     <code>
        ///       using System;
        ///       using Microsoft.VisualStudio.TestTools.UnitTesting;
        /// 
        /// 
        ///       namespace ExtensionMethods.Examples
        ///       {
        ///           [TestClass]
        ///           public class System_Object_To
        ///           {
        ///               [TestMethod]
        ///               public void To()
        ///               {
        ///                   string nullValue = null;
        ///                   string value = &quot;1&quot;;
        ///                   object dbNullValue = DBNull.Value;
        /// 
        ///                   // Exemples
        ///                   var result1 = value.To&lt;int&gt;(); // return 1;
        ///                   var result2 = value.To&lt;int?&gt;(); // return 1;
        ///                   var result3 = nullValue.To&lt;int?&gt;(); // return null;
        ///                   var result4 = dbNullValue.To&lt;int?&gt;(); // return null;
        /// 
        ///                   // Unit Test
        ///                   Assert.AreEqual(1, result1);
        ///                   Assert.AreEqual(1, result2.Value);
        ///                   Assert.IsFalse(result3.HasValue);
        ///                   Assert.IsFalse(result4.HasValue);
        ///               }
        ///           }
        ///       }
        /// </code>
        /// </example>
        /// <example>
        ///     <code>
        ///       using System;
        ///       using Microsoft.VisualStudio.TestTools.UnitTesting;
        ///       using Z.ExtensionMethods.Object;
        /// 
        ///       namespace ExtensionMethods.Examples
        ///       {
        ///           [TestClass]
        ///           public class System_Object_To
        ///           {
        ///               [TestMethod]
        ///               public void To()
        ///               {
        ///                   string nullValue = null;
        ///                   string value = &quot;1&quot;;
        ///                   object dbNullValue = DBNull.Value;
        /// 
        ///                   // Exemples
        ///                   var result1 = value.To&lt;int&gt;(); // return 1;
        ///                   var result2 = value.To&lt;int?&gt;(); // return 1;
        ///                   var result3 = nullValue.To&lt;int?&gt;(); // return null;
        ///                   var result4 = dbNullValue.To&lt;int?&gt;(); // return null;
        /// 
        ///                   // Unit Test
        ///                   Assert.AreEqual(1, result1);
        ///                   Assert.AreEqual(1, result2.Value);
        ///                   Assert.IsFalse(result3.HasValue);
        ///                   Assert.IsFalse(result4.HasValue);
        ///               }
        ///           }
        ///       }
        /// </code>
        /// </example>
        public static T To<T>(this Object @this)
        {
            if (@this != null)
            {
                Type targetType = typeof(T);

                if (@this.GetType() == targetType)
                {
                    return (T)@this;
                }

                TypeConverter converter = TypeDescriptor.GetConverter(@this);
                if (converter != null)
                {
                    if (converter.CanConvertTo(targetType))
                    {
                        return (T)converter.ConvertTo(@this, targetType);
                    }
                }

                converter = TypeDescriptor.GetConverter(targetType);
                if (converter != null)
                {
                    if (converter.CanConvertFrom(@this.GetType()))
                    {
                        return (T)converter.ConvertFrom(@this);
                    }
                }

                if (@this == DBNull.Value)
                {
                    return (T)(object)null;
                }
            }

            return (T)@this;
        }

        /// <summary>
        ///     A System.Object extension method that toes the given this.
        /// </summary>
        /// <param name="this">this.</param>
        /// <param name="type">The type.</param>
        /// <returns>An object.</returns>
        /// <example>
        ///     <code>
        ///       using System;
        ///       using Microsoft.VisualStudio.TestTools.UnitTesting;
        /// 
        /// 
        ///       namespace ExtensionMethods.Examples
        ///       {
        ///           [TestClass]
        ///           public class System_Object_To
        ///           {
        ///               [TestMethod]
        ///               public void To()
        ///               {
        ///                   string nullValue = null;
        ///                   string value = &quot;1&quot;;
        ///                   object dbNullValue = DBNull.Value;
        /// 
        ///                   // Exemples
        ///                   var result1 = value.To&lt;int&gt;(); // return 1;
        ///                   var result2 = value.To&lt;int?&gt;(); // return 1;
        ///                   var result3 = nullValue.To&lt;int?&gt;(); // return null;
        ///                   var result4 = dbNullValue.To&lt;int?&gt;(); // return null;
        /// 
        ///                   // Unit Test
        ///                   Assert.AreEqual(1, result1);
        ///                   Assert.AreEqual(1, result2.Value);
        ///                   Assert.IsFalse(result3.HasValue);
        ///                   Assert.IsFalse(result4.HasValue);
        ///               }
        ///           }
        ///       }
        /// </code>
        /// </example>
        /// <example>
        ///     <code>
        ///       using System;
        ///       using Microsoft.VisualStudio.TestTools.UnitTesting;
        ///       using Z.ExtensionMethods.Object;
        /// 
        ///       namespace ExtensionMethods.Examples
        ///       {
        ///           [TestClass]
        ///           public class System_Object_To
        ///           {
        ///               [TestMethod]
        ///               public void To()
        ///               {
        ///                   string nullValue = null;
        ///                   string value = &quot;1&quot;;
        ///                   object dbNullValue = DBNull.Value;
        /// 
        ///                   // Exemples
        ///                   var result1 = value.To&lt;int&gt;(); // return 1;
        ///                   var result2 = value.To&lt;int?&gt;(); // return 1;
        ///                   var result3 = nullValue.To&lt;int?&gt;(); // return null;
        ///                   var result4 = dbNullValue.To&lt;int?&gt;(); // return null;
        /// 
        ///                   // Unit Test
        ///                   Assert.AreEqual(1, result1);
        ///                   Assert.AreEqual(1, result2.Value);
        ///                   Assert.IsFalse(result3.HasValue);
        ///                   Assert.IsFalse(result4.HasValue);
        ///               }
        ///           }
        ///       }
        /// </code>
        /// </example>
        /// ###
        /// <typeparam name="T">Generic type parameter.</typeparam>
        public static object To(this Object @this, Type type)
        {
            if (@this != null)
            {
                Type targetType = type;

                if (@this.GetType() == targetType)
                {
                    return @this;
                }

                TypeConverter converter = TypeDescriptor.GetConverter(@this);
                if (converter != null)
                {
                    if (converter.CanConvertTo(targetType))
                    {
                        return converter.ConvertTo(@this, targetType);
                    }
                }

                converter = TypeDescriptor.GetConverter(targetType);
                if (converter != null)
                {
                    if (converter.CanConvertFrom(@this.GetType()))
                    {
                        return converter.ConvertFrom(@this);
                    }
                }

                if (@this == DBNull.Value)
                {
                    return null;
                }
            }

            return @this;
        }

        /// <summary>
        ///     A System.Object extension method that converts this object to an or default.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">this.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a T.</returns>
        /// <example>
        ///     <code>
        ///       using Microsoft.VisualStudio.TestTools.UnitTesting;
        ///       using Z.ExtensionMethods.Object;
        /// 
        ///       namespace ExtensionMethods.Examples
        ///       {
        ///           [TestClass]
        ///           public class System_Object_ToOrDefault
        ///           {
        ///               [TestMethod]
        ///               public void ToOrDefault()
        ///               {
        ///                   // Type
        ///                   object intValue = &quot;1&quot;;
        ///                   object invalidValue = &quot;Fizz&quot;;
        /// 
        ///                   // Exemples
        ///                   var result1 = intValue.ToOrDefault&lt;int&gt;(); // return 1;
        ///                   var result2 = invalidValue.ToOrDefault&lt;int&gt;(); // return 0;
        ///                   int result3 = invalidValue.ToOrDefault(3); // return 3;
        ///                   int result4 = invalidValue.ToOrDefault(() =&gt; 4); // return 4;
        /// 
        ///                   // Unit Test
        ///                   Assert.AreEqual(1, result1);
        ///                   Assert.AreEqual(0, result2);
        ///                   Assert.AreEqual(3, result3);
        ///                   Assert.AreEqual(4, result4);
        ///               }
        ///           }
        ///       }
        /// </code>
        /// </example>
        /// <example>
        ///     <code>
        ///       using Microsoft.VisualStudio.TestTools.UnitTesting;
        ///       using Z.ExtensionMethods.Object;
        /// 
        ///       namespace ExtensionMethods.Examples
        ///       {
        ///           [TestClass]
        ///           public class System_Object_ToOrDefault
        ///           {
        ///               [TestMethod]
        ///               public void ToOrDefault()
        ///               {
        ///                   // Type
        ///                   object intValue = &quot;1&quot;;
        ///                   object invalidValue = &quot;Fizz&quot;;
        /// 
        ///                   // Exemples
        ///                   var result1 = intValue.ToOrDefault&lt;int&gt;(); // return 1;
        ///                   var result2 = invalidValue.ToOrDefault&lt;int&gt;(); // return 0;
        ///                   int result3 = invalidValue.ToOrDefault(3); // return 3;
        ///                   int result4 = invalidValue.ToOrDefault(() =&gt; 4); // return 4;
        /// 
        ///                   // Unit Test
        ///                   Assert.AreEqual(1, result1);
        ///                   Assert.AreEqual(0, result2);
        ///                   Assert.AreEqual(3, result3);
        ///                   Assert.AreEqual(4, result4);
        ///               }
        ///           }
        ///       }
        /// </code>
        /// </example>
        /// <example>
        ///     <code>
        ///           using Microsoft.VisualStudio.TestTools.UnitTesting;
        ///           using Z.ExtensionMethods.Object;
        ///           
        ///           namespace ExtensionMethods.Examples
        ///           {
        ///               [TestClass]
        ///               public class System_Object_ToOrDefault
        ///               {
        ///                   [TestMethod]
        ///                   public void ToOrDefault()
        ///                   {
        ///                       // Type
        ///                       object intValue = &quot;1&quot;;
        ///                       object invalidValue = &quot;Fizz&quot;;
        ///           
        ///                       // Exemples
        ///                       var result1 = intValue.ToOrDefault&lt;int&gt;(); // return 1;
        ///                       var result2 = invalidValue.ToOrDefault&lt;int&gt;(); // return 0;
        ///                       int result3 = invalidValue.ToOrDefault(3); // return 3;
        ///                       int result4 = invalidValue.ToOrDefault(() =&gt; 4); // return 4;
        ///           
        ///                       // Unit Test
        ///                       Assert.AreEqual(1, result1);
        ///                       Assert.AreEqual(0, result2);
        ///                       Assert.AreEqual(3, result3);
        ///                       Assert.AreEqual(4, result4);
        ///                   }
        ///               }
        ///           }
        ///     </code>
        /// </example>
        public static T ToOrDefault<T>(this Object @this, Func<object, T> defaultValueFactory)
        {
            try
            {
                if (@this != null)
                {
                    Type targetType = typeof(T);

                    if (@this.GetType() == targetType)
                    {
                        return (T)@this;
                    }

                    TypeConverter converter = TypeDescriptor.GetConverter(@this);
                    if (converter != null)
                    {
                        if (converter.CanConvertTo(targetType))
                        {
                            return (T)converter.ConvertTo(@this, targetType);
                        }
                    }

                    converter = TypeDescriptor.GetConverter(targetType);
                    if (converter != null)
                    {
                        if (converter.CanConvertFrom(@this.GetType()))
                        {
                            return (T)converter.ConvertFrom(@this);
                        }
                    }

                    if (@this == DBNull.Value)
                    {
                        return (T)(object)null;
                    }
                }

                return (T)@this;
            }
            catch (Exception)
            {
                return defaultValueFactory(@this);
            }
        }

        /// <summary>
        ///     A System.Object extension method that converts this object to an or default.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">this.</param>
        /// <param name="defaultValueFactory">The default value factory.</param>
        /// <returns>The given data converted to a T.</returns>
        /// <example>
        ///     <code>
        ///       using Microsoft.VisualStudio.TestTools.UnitTesting;
        ///       using Z.ExtensionMethods.Object;
        /// 
        ///       namespace ExtensionMethods.Examples
        ///       {
        ///           [TestClass]
        ///           public class System_Object_ToOrDefault
        ///           {
        ///               [TestMethod]
        ///               public void ToOrDefault()
        ///               {
        ///                   // Type
        ///                   object intValue = &quot;1&quot;;
        ///                   object invalidValue = &quot;Fizz&quot;;
        /// 
        ///                   // Exemples
        ///                   var result1 = intValue.ToOrDefault&lt;int&gt;(); // return 1;
        ///                   var result2 = invalidValue.ToOrDefault&lt;int&gt;(); // return 0;
        ///                   int result3 = invalidValue.ToOrDefault(3); // return 3;
        ///                   int result4 = invalidValue.ToOrDefault(() =&gt; 4); // return 4;
        /// 
        ///                   // Unit Test
        ///                   Assert.AreEqual(1, result1);
        ///                   Assert.AreEqual(0, result2);
        ///                   Assert.AreEqual(3, result3);
        ///                   Assert.AreEqual(4, result4);
        ///               }
        ///           }
        ///       }
        /// </code>
        /// </example>
        /// <example>
        ///     <code>
        ///       using Microsoft.VisualStudio.TestTools.UnitTesting;
        ///       using Z.ExtensionMethods.Object;
        /// 
        ///       namespace ExtensionMethods.Examples
        ///       {
        ///           [TestClass]
        ///           public class System_Object_ToOrDefault
        ///           {
        ///               [TestMethod]
        ///               public void ToOrDefault()
        ///               {
        ///                   // Type
        ///                   object intValue = &quot;1&quot;;
        ///                   object invalidValue = &quot;Fizz&quot;;
        /// 
        ///                   // Exemples
        ///                   var result1 = intValue.ToOrDefault&lt;int&gt;(); // return 1;
        ///                   var result2 = invalidValue.ToOrDefault&lt;int&gt;(); // return 0;
        ///                   int result3 = invalidValue.ToOrDefault(3); // return 3;
        ///                   int result4 = invalidValue.ToOrDefault(() =&gt; 4); // return 4;
        /// 
        ///                   // Unit Test
        ///                   Assert.AreEqual(1, result1);
        ///                   Assert.AreEqual(0, result2);
        ///                   Assert.AreEqual(3, result3);
        ///                   Assert.AreEqual(4, result4);
        ///               }
        ///           }
        ///       }
        /// </code>
        /// </example>
        /// <example>
        ///     <code>
        ///           using Microsoft.VisualStudio.TestTools.UnitTesting;
        ///           using Z.ExtensionMethods.Object;
        ///           
        ///           namespace ExtensionMethods.Examples
        ///           {
        ///               [TestClass]
        ///               public class System_Object_ToOrDefault
        ///               {
        ///                   [TestMethod]
        ///                   public void ToOrDefault()
        ///                   {
        ///                       // Type
        ///                       object intValue = &quot;1&quot;;
        ///                       object invalidValue = &quot;Fizz&quot;;
        ///           
        ///                       // Exemples
        ///                       var result1 = intValue.ToOrDefault&lt;int&gt;(); // return 1;
        ///                       var result2 = invalidValue.ToOrDefault&lt;int&gt;(); // return 0;
        ///                       int result3 = invalidValue.ToOrDefault(3); // return 3;
        ///                       int result4 = invalidValue.ToOrDefault(() =&gt; 4); // return 4;
        ///           
        ///                       // Unit Test
        ///                       Assert.AreEqual(1, result1);
        ///                       Assert.AreEqual(0, result2);
        ///                       Assert.AreEqual(3, result3);
        ///                       Assert.AreEqual(4, result4);
        ///                   }
        ///               }
        ///           }
        ///     </code>
        /// </example>
        public static T ToOrDefault<T>(this Object @this, Func<T> defaultValueFactory)
        {
            return @this.ToOrDefault(x => defaultValueFactory());
        }

        /// <summary>
        ///     A System.Object extension method that converts this object to an or default.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">this.</param>
        /// <returns>The given data converted to a T.</returns>
        public static T ToOrDefault<T>(this Object @this)
        {
            return @this.ToOrDefault(x => default(T));
        }

        /// <summary>
        ///     A System.Object extension method that converts this object to an or default.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">this.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The given data converted to a T.</returns>
        public static T ToOrDefault<T>(this Object @this, T defaultValue)
        {
            return @this.ToOrDefault(x => defaultValue);
        }

        #endregion

        #region IsAssignableFrom

        /// <summary>
        ///     An object extension method that query if '@this' is assignable from.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if assignable from, false if not.</returns>
        public static bool IsAssignableFrom<T>(this object @this)
        {
            Type type = @this.GetType();
            return type.IsAssignableFrom(typeof(T));
        }

        /// <summary>
        ///     An object extension method that query if '@this' is assignable from.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <returns>true if assignable from, false if not.</returns>
        public static bool IsAssignableFrom(this object @this, Type targetType)
        {
            Type type = @this.GetType();
            return type.IsAssignableFrom(targetType);
        }

        #endregion

        #region Cloning

        /// <summary>
        ///     A T extension method that makes a deep copy of '@this' object.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>the copied object.</returns>
        public static T DeepClone<T>(this T @this)
        {
            IFormatter formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, @this);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        ///     A T extension method that shallow copy.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>A T.</returns>
        public static T ShallowCopy<T>(this T @this)
        {
            MethodInfo method = @this.GetType().GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);
            return (T)method.Invoke(@this, null);
        }

        #endregion
    }
}
