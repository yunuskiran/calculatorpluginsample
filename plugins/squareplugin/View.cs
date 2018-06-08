using System;
using System.Windows.Forms;
using Core;

namespace SquarePlugin
{
    public  class View : IPluginCore
    {
        IHost host;

        public double Operate(double a) => Math.Sqrt(a);

        public void SetHost(IHost host)
        {
            this.host = host ?? throw new ArgumentNullException(nameof(host));
            host.Register(this);
        }

        public string PluginName => "Square";
    }
}
