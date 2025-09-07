namespace KwikNesta.Contracts.Extensions
{
    public static class EnumMapper
    {
        public static TTarget Map<TSource, TTarget>(TSource source)
            where TSource : struct, Enum
            where TTarget : struct, Enum
        {
            if (Enum.TryParse<TTarget>(source.ToString(), out var target))
            {
                return target;
            }

            var underlying = Convert.ToInt32(source);
            if (Enum.IsDefined(typeof(TTarget), underlying))
            {
                return (TTarget)Enum.ToObject(typeof(TTarget), underlying);
            }

            throw new ArgumentException(
                $"Cannot map {typeof(TSource).Name}.{source} to {typeof(TTarget).Name}");
        }
    }
}
