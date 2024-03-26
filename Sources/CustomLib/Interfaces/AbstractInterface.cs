namespace CustomLib.Interfaces
{
    public interface AbstractInterface<GetType, QueryType, PostType, PutType>
    {
        public Task<List<GetType>> List(QueryType query);
        public Task<GetType> Post(PostType data);
        public Task<GetType> Get(string id);
        public Task<GetType> Put(string id, PutType data);
        public Task<GetType> Delete(string id);
    }
}
