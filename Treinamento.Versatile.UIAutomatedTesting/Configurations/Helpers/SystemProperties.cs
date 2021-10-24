using System;

namespace Treinamento.Versatile.UIAutomatedTesting.Configurations.Helpers
{
    public class SystemProperties
    {
        public static string PathProject = AppDomain.CurrentDomain.BaseDirectory.ToString().Remove(AppDomain.CurrentDomain.BaseDirectory.ToString().LastIndexOf("\\") - 23);
    }
}