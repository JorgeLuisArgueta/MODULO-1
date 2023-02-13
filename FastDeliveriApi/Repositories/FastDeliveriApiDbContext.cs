namespace FastDeliveriApi.Repositories
{
    internal class FastDeliveriApiDbContext
    {
        public object ChangeTracker { get; internal set; }

        internal Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        internal object Set<T>()
        {
            throw new NotImplementedException();
        }
    }
}