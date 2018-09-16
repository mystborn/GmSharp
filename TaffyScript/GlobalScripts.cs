﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaffyScript
{
    /// <summary>
    /// Provides an implementation for all of the global scripts in TaffyScript.
    /// </summary>
    public static class GlobalScripts
    {
        // This class privodes the implementation of all of the
        // scripts in the global namespace. In an effort to not pollute
        // the c# global namespace, all of the scripts are explicitly defined
        // in Resources/SpecialImports.resource

        [TaffyScriptMethod]
        public static TsObject array_copy(TsObject[] args)
        {
            Array.Copy(args[0].GetArray(), (int)args[1], args[2].GetArray(), (int)args[3], (int)args[4]);
            return TsObject.Empty;
        }

        [TaffyScriptMethod]
        public static TsObject array_create(TsObject[] args)
        {
            var size = args[0].GetInt();
            var value = args.Length > 1 ? args[1] : TsObject.Empty;
            var result = new TsObject[size];
            for (var i = 0; i < size; ++i)
                result[i] = value;

            return result;
        }

        [TaffyScriptMethod]
        public static TsObject array_equals(TsObject[] args)
        {
            var left = args[0].GetArray();
            var right = args[1].GetArray();
            if (left.Length != right.Length)
                return false;
            for(var i = 0; i < left.Length; i++)
            {
                if (left[i] != right[i])
                    return false;
            }

            return true;
        }

        [TaffyScriptMethod]
        public static TsObject array_length(TsObject[] args)
        {
            switch(args.Length)
            {
                case 1:
                    return args[0].GetArray().Length;
                case 2:
                    return args[0].GetArray((int)args[1]).Length;
                case 3:
                    return args[0].GetArray((int)args[1], (int)args[2]).Length;
                default:
                    var indeces = new int[args.Length - 1];
                    var i = 0;
                    while (i < indeces.Length)
                        indeces[i++] = (int)args[i];
                    return args[0].GetArray(indeces).Length;
            }
        }

        [TaffyScriptMethod]
        public static TsObject print(TsObject[] args)
        {
            if(args is null)
            {
                Console.WriteLine();
                return TsObject.Empty;
            }

            switch(args.Length)
            {
                case 0:
                    Console.WriteLine();
                    break;
                case 1:
                    Console.WriteLine(args[0]);
                    break;
                case 2:
                    Console.WriteLine((string)args[0], args[1]);
                    break;
                case 3:
                    Console.WriteLine((string)args[0], args[1], args[2]);
                    break;
                case 4:
                    Console.WriteLine((string)args[0], args[1], args[2], args[3]);
                    break;
                default:
                    var arr = new object[args.Length - 1];
                    Array.Copy(args, 1, arr, 0, arr.Length);
                    Console.WriteLine((string)args[0], arr);
                    break;
            }
            return TsObject.Empty;
        }

        [TaffyScriptMethod]
        public static TsObject real(TsObject[] args)
        {
            return float.Parse((string)args[0]);
        }

        [TaffyScriptMethod]
        public static TsObject show_error(TsObject[] args)
        {
            var error = new UserDefinedException((string)args[0]);
            if ((bool)args[1])
                throw error;

            System.Diagnostics.Debug.WriteLine(error);
            return TsObject.Empty;
        }

        [TaffyScriptMethod]
        public static TsObject ToString(TsObject[] args)
        {
            return args[0].ToString();
        }

        [TaffyScriptMethod]
        public static TsObject Typeof(TsObject[] args)
        {
            switch (args[0].Type)
            {
                case VariableType.Array:
                    return new TsType(typeof(TsObject[]), "array");
                case VariableType.Null:
                    return new TsType(typeof(void), "null");
                case VariableType.Real:
                    return new TsType(typeof(float), "number");
                case VariableType.String:
                    return new TsType(typeof(string), "string");
                case VariableType.Delegate:
                    return new TsType(typeof(TsDelegate), "script");
                case VariableType.Instance:
                    var inst = args[0].GetInstance();
                    return new TsType(inst.GetType(), inst.ObjectType);
                default:
                    throw new ArgumentException("Unknown type value");
            }
        }
    }
}
