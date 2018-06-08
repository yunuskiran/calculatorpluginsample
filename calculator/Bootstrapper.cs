using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Bootstrapper
    {
        public Bootstrapper(IHost host)
        {
            List<string> ddls = new List<string>();
            ddls.Add(@"C:\dev\CalculatorPlugin\Plugins\SquarePlugin\bin\Debug\SquarePlugin.dll");
            foreach (var ddlpath in ddls)
            {
                var assem = Assembly.LoadFrom(ddlpath);
                var plgType = assem.GetTypes().SingleOrDefault(x => x.GetInterface(typeof(IPluginCore).Name) != null);
                IPluginCore plgIns = Activator.CreateInstance(plgType) as IPluginCore;
                plgIns.SetHost(host);
            }
        }
    }
}
