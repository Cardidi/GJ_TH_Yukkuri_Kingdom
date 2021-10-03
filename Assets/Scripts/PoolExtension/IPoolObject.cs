namespace Environment.Pool
{
    public interface IPoolObject
    {
        public bool Free { get; }
        public PoolRoot Pool { get; }
        public void OnInstanced(PoolRoot pool);
        public void OnUsed();
        public void OnFree();
    }
}