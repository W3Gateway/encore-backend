namespace Encore.Domain.ValueObjects
{
    public class EsusIntegrationBase<T> where T : EsusIntegrationBase<T>, new()
    {
        public int Code { get; set; }
        public string Description { get; set; }

        public static T Get(long code)
        {
            var instance = new T();
            foreach (var property in typeof(T).GetProperties())
            {
                var staticProperty = property.GetValue(instance) as T;
                if (staticProperty != null && staticProperty.Code == code)
                    return staticProperty;
            }
            throw new Exception($"There is no instance of {typeof(T).Name} with Code: {code}");
        }
    }

}
