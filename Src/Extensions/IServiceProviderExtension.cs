namespace System
{
    public static class IServiceProviderExtension
    {
        public static void InjectProperties(this IServiceProvider serviceProvider, object value)
        {
            foreach (var prop in value.GetType().GetProperties())
            {
                if (!prop.CanWrite)
                    continue;

                object pValue = serviceProvider.GetService(prop.PropertyType);
                prop.SetValue(value, pValue);
            }
        }
    }
}
