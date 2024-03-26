namespace CustomLib.Interfaces
{
    public interface AbstractInterface<ResourceRead, ResourceQuery, ResourceCreate, ResourceUpdate>
    {
        public Task<List<ResourceRead>> Find(ResourceQuery query);
        public Task<ResourceRead> Create(ResourceCreate data);
        public Task<ResourceRead> Read(string id);
        public Task<ResourceRead> Update(string id, ResourceUpdate data);
        public Task<ResourceRead> Delete(string id);
    }
}
