using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public static class Test
    {
        public static string Convert(object obj)
        {
            Type type = obj.GetType();
            StringBuilder sb = new StringBuilder();
            sb = sb.AppendLine($"<{type.Name}>");
            sb = Check(obj, sb, 4);
            sb = sb.Append($"</{type.Name}>");
            return sb.ToString();
        }
        private static StringBuilder Check(object obj, StringBuilder s,int space)
        {
            if (obj == null)
                return s;

            Type type = obj.GetType();
            if (type.IsValueType || type.Name == "String")
            {
                s = s.Append($"{obj}");
            }
            else if (IsAList(obj))
            {
                var vtype = obj.GetType();
                int count = 0;
                PropertyInfo? itemProperty = null;
                MethodInfo? itemMethod = null;
                if (vtype.IsArray)
                {
                    count = (int)vtype.GetProperty("Length").GetValue(obj);
                    itemMethod = vtype.GetMethod("GetValue", new[] { typeof(int) });
                }
                else
                {
                    count = (int)vtype.GetProperty("Count").GetValue(obj);
                    itemProperty = vtype.GetProperty("Item");
                }
                for (int i = 0; i < count; i++)
                {
                    object? item = null;
                    if (itemProperty != null)
                    {
                        item = itemProperty.GetValue(obj, new object[] { i });
                    }
                    else if (itemMethod != null)
                    {
                        item = itemMethod.Invoke(obj, new object[] { i });
                    }
                    Type itemType = item.GetType();
                    if (item != null)
                    {
                        AddSpace(s, space);
                        s = s.Append($"<{itemType.Name}>");
                        if (itemType != null && !itemType.IsValueType && itemType.Name != "String")
                        {
                            s = s.AppendLine();
                        }
                        s = Check(item, s, space + space);
                        if (itemType != null && !itemType.IsValueType && itemType.Name != "String")
                        {
                            AddSpace(s, space);
                        }
                        
                        s = s.AppendLine($"</{itemType.Name}>");
                    }
                }
            }
            else
            {
                PropertyInfo[] properties = type.GetProperties();
                foreach (var property in properties)
                {
                    string propName = property.Name;
                    object? value = property.GetValue(obj);
                    Type? valueType = value?.GetType();

                    AddSpace(s, space);
                    s = s.Append($"<{propName}>");
                    if (valueType != null && !valueType.IsValueType && valueType.Name != "String")
                    {
                        s = s.AppendLine();
                    }
                    s = Check(value, s, space + space);
                    if (valueType != null && !valueType.IsValueType && valueType.Name != "String")
                    {
                        AddSpace(s, space);
                    }
                    
                    s = s.AppendLine($"</{propName}>");
                }
            }
            return s;
        }

        private static bool IsAList(object obj)
        {
            if (obj == null) return false;
            Type t = obj.GetType();
            Type[] types = t.GetInterfaces();
            bool isAList = t.Name != "String" && types.Any(x => x.Name == "IEnumerable");
            return isAList == true;
        }

        private static void AddSpace(StringBuilder s,int space)
        {
            for (int i = 1; i <= space; i++)
            {
                s = s.Append(' ');
            }
        }
    }
}
