namespace IoCExample;

public interface IContainer
{
    void Register(Type from, Type to, string? instanceName = null); 
    void Register<TFrom, TTo>(string? instanceName = null) where TTo : TFrom;
    void Register(Type type, Func<object>? createInstanceDelegate, string? instanceName = null);
    void Register<T>(Func<T> createInstanceDelegate, string? instanceName = null);
    bool IsRegistered(Type type, string? instanceName = null);
    bool IsRegistered<T>(string? instanceName = null);
    object Resolve(Type type, string? instanceName = null);
    T Resolve<T>(string? instanceName = null);
}