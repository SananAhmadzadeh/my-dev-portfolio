namespace Core.Utilities.Result.Abstract
{
    public interface IDataResult<T>
    {
        public T Data { get; }
        public bool Success { get; }
        public string Message { get; }
    }
}
