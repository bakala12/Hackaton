﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Shared
{
    public class EnumToDescriptionConverter : IValueConverter
    {
        /// <summary>
        /// Konwertuje enum do jego opisu.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return DependencyProperty.UnsetValue;
            Enum @enum = (Enum)value;
            return @enum.GetDescription();
        }
        /// <summary>
        /// Konwertuje spowrotem z opisu do enuma.
        /// </summary>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.ToObject(targetType, value);
        }
    }
}
