using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.Imoveis.Core.Extensions
{
    public static class ExtensionMethods
    {
        public static string ObterTextoSimplificado(this string value, int length = 0)
        {
            string end = string.Empty;

            if (length >0 && length <= value.Length)
            {
                end = value.Substring(0, length);
            }
            else
            {
                if (value.Length > 20)
                {
                    end = value.Substring(0, 20);
                }

                else
                    return value;
            }

            return end;
        }

        public static async Task<string> GetBase64FromFile(this IFormFile formFile)
        {
            if (formFile != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await formFile.CopyToAsync(ms);

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
            else
                return string.Empty;
        }

        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
        public static List<string> GetValuesEnum(this Type tipo)
        {
            var valores = Enum.GetValues(tipo);

            List<string> result;

            if (valores.Length > 0)
            {
                result = new List<string>();
                foreach (Enum x in valores)
                {
                    result.Add(x.GetEnumDescription());
                }
                return result;
            }
            return null;
        }
    }
}
