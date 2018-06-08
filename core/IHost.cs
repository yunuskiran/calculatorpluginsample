namespace Core
{
    public interface IHost
    {
        void Register(IPluginCore pluginCore);
        void Result(double value);
    }
}