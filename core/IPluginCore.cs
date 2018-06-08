namespace Core
{
    public interface IPluginCore
    {
        double Operate(double a);

        void SetHost(IHost host);

        string PluginName { get; }
    }
}
