using System;
using System.Text;

namespace Encore.Domain.Core.Extensions
{    
    public static class StringBuilderExtensions
    {
        public static StringBuilder ToString<T>(this T value, StringBuilder stringBuilder)
        {
            // Verifica se o StringBuilder é nulo
            if (stringBuilder == null)
                throw new ArgumentNullException(nameof(stringBuilder));

            // Adiciona a representação de string do valor ao StringBuilder
            stringBuilder.Append(value.ToString());

            // Retorna o StringBuilder modificado
            return stringBuilder;
        }
    }

}
