namespace CustomLib.Interfaces
{
    public interface AbstractInterface<GetType, PostType, PutType>
    {
        public Task<List<GetType>?> List();
        public Task<GetType?> Post(PostType data);
        public Task<GetType?> Get(string id);
        public Task<GetType?> Put(string id, PutType data);
        public Task<GetType?> Delete(string id);
    }
}
