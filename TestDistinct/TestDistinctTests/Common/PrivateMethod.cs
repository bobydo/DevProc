using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestDistinctTests.Common
{
    public class PrivateMethod
    {
        static internal TR CallPrivateMethod<TInstance, T, TR>(
            TInstance instance,
            string methodName,
            T parameter)
        {
            Type type = instance.GetType();
            BindingFlags bindingAttr = BindingFlags.NonPublic | BindingFlags.Instance;
            MethodInfo method = type.GetMethod(methodName, bindingAttr);
            return (TR)method.Invoke(instance, new object[] { parameter });
        }
    }
}
