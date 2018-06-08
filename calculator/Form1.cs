using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form, IHost
    {
        IList<IPluginCore> pluginCores;
        public Form1()
        {
            pluginCores = new List<IPluginCore>();
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Result: ";
            new Bootstrapper(this);

            int i = 0;
            foreach (var p in pluginCores)
            {
                var b = new Button
                {
                    Name = "btn" + p.PluginName.Trim(),
                    BackColor = Color.AliceBlue,
                    Height = 30,
                    Width = 70,
                    Location = new Point(5, (i * 30) + 5),
                    Text = p.PluginName
                };

                b.Click += (s, o) =>
                {
                    var result = p.Operate(Convert.ToDouble(textBox1.Text));
                    if (result != -1)
                        label1.Text = label1.Text + result.ToString("#.##");
                };

                Container.Controls.Add(b);
                i++;
            }
        }

        public void Register(IPluginCore pluginCore)
        {
            pluginCores.Add(pluginCore);
        }

        public void Result(double value)
        {
            throw new NotImplementedException();
        }
    }
}
