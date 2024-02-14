using Microsoft.Win32.SafeHandles;
using BindingFlags = System.Reflection.BindingFlags;

namespace IoCExample;

public class Container : IContainer
{
    private readonly Dictionary<(Type, string?), Func<object>> _mapper = new();
    private readonly HashSet<(Type, string)> _resolving = new(); 
    public void Register(Type from, Type to, string? instanceName = null)
    {
        if (!(from.IsInterface && to.GetInterfaces().Contains(from)) 
            && to.IsSubclassOf(from)) throw new ArgumentException();
        
        var ctor = to.GetConstructors().Single();
        var args = ctor.GetParameters();

        _mapper[(from, instanceName)] = () =>
        {
            return ctor.Invoke(args.Select(arg =>
            {
                if (_resolving.Contains((arg.ParameterType, null))) 
                    throw new InvalidOperationException();
                
                return Resolve(arg.ParameterType);
            }).ToArray());
        };
    }

    public void Register<TFrom, TTo>(string? instanceName = null) where TTo : TFrom
    {
        Register(typeof(TFrom), typeof(TTo), instanceName);
    }

    public void Register(Type type, Func<object> createInstanceDelegate, string? instanceName = null)
    {
        _mapper[(type, instanceName)] = createInstanceDelegate;
    }

    public void Register<T>(Func<T> createInstanceDelegate, string? instanceName = null)
    {
        Register(typeof(T), (createInstanceDelegate as Func<object>)!, instanceName);
    }

    public bool IsRegistered(Type type, string? instanceName = null)
    {
        return _mapper.ContainsKey((type, instanceName));
    }

    public bool IsRegistered<T>(string? instanceName = null)
    {
        return IsRegistered(typeof(T), instanceName);
    }

    public object Resolve(Type type, string? instanceName = null)
    {
        if (!_mapper.ContainsKey((type, instanceName)))
        {
            throw new KeyNotFoundException($"{instanceName} of type {type} not found");
        }

        _resolving.Add((type, instanceName));
        var inst = _mapper[(type, instanceName)].Invoke();
        _resolving.Remove((type, instanceName));
        return inst;
    }

    public T Resolve<T>(string? instanceName = null)
    {
        return (T)Resolve(typeof(T), instanceName);
    }
}