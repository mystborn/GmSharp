﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TaffyScript.DotNet
{
    public class DotNetTypeParser
    {
        private Regex _typeRegex = new Regex(@"(?<Base>[a-zA-Z_][a-zA-Z0-9_.]*)\s*(\<(?<Generic>(\s*,?\s*[a-zA-Z_][a-zA-Z0-9_]*\s*(\<.+\>)?(\[(\s*,)*\s*\])?)+)\>)?\s*(?<Rank>\[(\s*,)*\s*\])?", RegexOptions.Compiled);
        private Dictionary<string, Type> _typeNames = new Dictionary<string, Type>();
        private DotNetAssemblyLoader _assemblies;

        public Dictionary<string, Type> TypeNames => _typeNames;

        public DotNetTypeParser(DotNetAssemblyLoader assemblyLoader)
        {
            _assemblies = assemblyLoader;
            InitTypes();
        }

        public Type GetType(string typeName)
        {
            typeName = typeName.Replace(" ", "");

            if (TypeAlreadyDefined(typeName, out var type))
                return type;

            var match = _typeRegex.Match(typeName);
            var basic = match.Groups["Base"].Value.Replace(" ", "");
            if (match.Success && match.Length == typeName.Length)
            {
                var generic = match.Groups["Generic"];
                if (generic.Success)
                {
                    var innerTypes = _typeRegex.Matches(generic.Value);
                    TryGetTypeName($"{basic}`{innerTypes.Count}", out type);
                    var typeArgs = new Type[innerTypes.Count];
                    var count = 0;
                    foreach (Match inner in innerTypes)
                    {
                        typeArgs[count++] = GetType(inner.Value);
                    }
                    type = type.MakeGenericType(typeArgs);
                }
                else
                    TryGetTypeName(basic, out type);
                if (type == null)
                    throw new InvalidOperationException($"The type {typeName} could not be found.");

                var rank = match.Groups["Rank"];
                if (rank.Success)
                {
                    var ranks = rank.Value.Count(c => c == ',');
                    //If you supply a rank argument, it cannot be zero.
                    type = ranks == 0 ? type.MakeArrayType() : type.MakeArrayType(ranks);
                }

                TypeDef(type, typeName);

                return type;

            }
            else throw new InvalidOperationException($"The type {typeName} could not be found.");
        }

        public bool TryGetTypeName(string typeName, out Type type)
        {
            if (TypeAlreadyDefined(typeName, out type))
                return true;

            type = Type.GetType(typeName, false);
            if (type != null)
                return true;

            foreach (var asm in _assemblies.LoadedAssemblies.Values)
            {
                type = asm.GetType(typeName);
                if (type != null)
                    return true;
            }

            foreach (var ns in _assemblies.Namespaces)
            {
                var name = $"{ns.Key}.{typeName}";
                foreach (var asm in ns.Value)
                {
                    type = asm.GetType(name);
                    if (type != null)
                        return true;
                }
            }

            return false;
        }

        private bool TypeAlreadyDefined(string type_name, out Type type)
        {
            if (!_typeNames.TryGetValue(type_name, out type))
                return false;

            return true;
        }

        private bool TypeDef(Type type, string nickname)
        {
            if (!_typeNames.ContainsKey(nickname))
            {
                _typeNames.Add(nickname, type);
                return true;
            }

            return false;
        }

        private void InitTypes()
        {
            TypeDef(typeof(Char), "char");
            TypeDef(typeof(Byte), "byte");
            TypeDef(typeof(SByte), "sbyte");
            TypeDef(typeof(Decimal), "decimal");
            TypeDef(typeof(Int16), "short");
            TypeDef(typeof(Int32), "int");
            TypeDef(typeof(Int64), "long");
            TypeDef(typeof(String), "string");
            TypeDef(typeof(UInt16), "ushort");
            TypeDef(typeof(UInt32), "uint");
            TypeDef(typeof(UInt64), "ulong");
            TypeDef(typeof(Single), "float");
            TypeDef(typeof(Double), "double");
            TypeDef(typeof(Boolean), "bool");
            TypeDef(typeof(Object), "object");
            TypeDef(typeof(void), "void");
        }
    }
}
