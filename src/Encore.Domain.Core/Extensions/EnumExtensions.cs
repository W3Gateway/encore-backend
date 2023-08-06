using System;
using System.ComponentModel;
using System.Reflection;

namespace Encore.Domain.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            Type enumType = value.GetType();
            string name = Enum.GetName(enumType, value);

            if (name != null)
            {
                FieldInfo field = enumType.GetField(name);
                if (field != null)
                {
                    if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                    {
                        return attribute.Description;
                    }
                }
            }

            return value.ToString();
        }
    }
}
