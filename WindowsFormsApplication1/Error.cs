using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Error
    {
        internal static string Format(string format, params object[] args)
        {
            return String.Format(CultureInfo.CurrentCulture, format, args);
        }
        internal static ArgumentNullException ArgumentNull(string parameterName)
        {
            return new ArgumentNullException(parameterName);
        }
    }
}
