using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using FakerClass.generator;
using FakerClass.generator.impl;
using Microsoft.VisualBasic.FileIO;

namespace FakerClass
{
    public class Faker : IFaker
    {
        private readonly Dictionary<Type, IGenerator> _generators;
        private List<Type> _listType;
        private readonly string _pathPlugin = "F:\\spp\\second\\spp_2\\FakerClass\\plugins";

        public Faker()
        {
            _listType = new List<Type>();
            _generators = new Dictionary<Type, IGenerator>();
            loadGeneratorsFromDirectory();
            loadGeneratorsFromPackage();
        }

        private void loadGeneratorsFromDirectory()
        {
            var pluginDirectory = new DirectoryInfo(_pathPlugin);
            if (!pluginDirectory.Exists)
            {
                pluginDirectory.Create();
                return;
            }

            var pluginFiles = Directory.GetFiles(pluginDirectory.FullName, "*.dll");

            foreach (var pluginFile in pluginFiles)
            {
                var assembly = Assembly.LoadFrom(pluginFile);
                var types = assembly.GetTypes().Where(t => t.
                    GetInterfaces().Any(i => i.FullName == typeof(IGenerator).FullName));
                foreach (var type in types)
                {
                    if (type.FullName == null) continue;
                    if (!type.IsClass) continue;
                    if (assembly.CreateInstance(type.FullName) is IGenerator generatorPlugin)
                    {
                        _generators.TryAdd(generatorPlugin.GetGenType(), generatorPlugin);
                    }
                }
            }
        }

        private void loadGeneratorsFromPackage()
        {
            _generators.Add(typeof(string), new StringGenerator());
            _generators.Add(typeof(bool), new BoolGenerator());
            _generators.Add(typeof(byte), new ByteGenerator());
            _generators.Add(typeof(DateTime), new DateTimeGenerator());
            _generators.Add(typeof(double), new DoubleGenerator());
            _generators.Add(typeof(float), new FloatGenerator());
            _generators.Add(typeof(short), new ShortGenerator());
            _generators.Add(typeof(long), new LongGenerator());
            _generators.Add(typeof(List<int>), new ListGenerator<int>());
        }

        public T create<T>()
        {
            return (T)createByType(typeof(T));
        }

        public object createByType(Type type)
        {
            if (type.IsAbstract)
                return default;

            if (_generators.TryGetValue(type, out var _generator))
            {
                return _generator.Generate();
            }

            if (type.IsEnum)
            {
                Array enumValues = type.GetEnumValues();
                Random random = new Random();
                return enumValues.GetValue(random.Next(0, enumValues.Length));
            }
            if (type.IsClass)
            {
                if (_listType.Contains(type))
                {
                    return default;
                }
                _listType.Add(type);
                var inst = CreateThroughConstructor(type);
                if (inst == null)
                    return default;
                initFields(inst, type.GetFields());
                initProperties(inst, type.GetProperties());
                _listType.Remove(type);
                return inst;
            }

            return default;

        }

        private void initFields(object inst, FieldInfo[] fields)
        {
            var defaultConstr = inst.GetType().GetConstructors()[0];
            var defaultObj = defaultConstr.Invoke(new object[defaultConstr.GetParameters().Length]);
            foreach (var field in fields)
            {
                var defaultValue = field.GetValue(defaultObj);
                var value = field.GetValue(inst);
                if ((defaultValue != null && value != null)) continue;
                if (value != null && !defaultValue.Equals(value)) continue;
                field.SetValue(inst, createByType(field.FieldType));
            }
        }

        private void initProperties(object inst, PropertyInfo[] properties)
        {
            var defaultConstr = inst.GetType().GetConstructors()[0];
            var defaultObj = defaultConstr.Invoke(new object[defaultConstr.GetParameters().Length]);
            foreach (var property in properties)
            {
                var defaultValue = property.GetValue(defaultObj);
                var value = property.GetValue(inst);
                if ((defaultValue == null && value != null)) continue;
                if (value != null && !defaultValue.Equals(value)) continue;
                if (property.SetMethod != null && (property.SetMethod.IsPrivate | property.SetMethod.IsFamily))
                    continue;
                property.SetValue(inst, createByType(property.PropertyType));
            }
        }

        private object CreateThroughConstructor(Type type)
        {
            var constructors = type.GetConstructors();
            var constructor = GetMaxParametersCountConstructor(constructors);
            if (constructor == null) return null;
            var parametersInfo = constructor.GetParameters();
            return constructor.Invoke(setField(parametersInfo).ToArray());
        }

        private List<object> setField(ParameterInfo[] parameters)
        {
            var list = new List<object>();
            for (var i = 0; i < parameters.Length; i++)
            {
                var paramType = parameters[i].ParameterType;
                list.Add(createByType(paramType));
            }
            return list;
        }
        private ConstructorInfo GetMaxParametersCountConstructor(IReadOnlyList<ConstructorInfo> constructors)
        {
            if (constructors == null || constructors.Count <= 0) return null;

            var constructorInfo = constructors[0];
            foreach (var constructor in constructors)
            {
                if (constructor.IsPrivate) continue;
                if (constructor.GetParameters().Length > constructorInfo.GetParameters().Length)
                {
                    constructorInfo = constructor;
                }
            }

            return constructorInfo;
        }
    }
}