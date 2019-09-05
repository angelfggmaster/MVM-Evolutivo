using System;
using System.Configuration;
using System.Globalization;

namespace PruebaMVM
{
    public class AppSettings
    {
        public double Probability => Convert.ToDouble(ConfigurationManager.AppSettings["Probability"], CultureInfo.InvariantCulture);

        public string ValidCharacters => ConfigurationManager.AppSettings["ValidCharacters"];

        public string TargetString => ConfigurationManager.AppSettings["TargetString"];

        public int CopyRange => Convert.ToInt32(ConfigurationManager.AppSettings["CopyRange"], CultureInfo.InvariantCulture);
    }
}
