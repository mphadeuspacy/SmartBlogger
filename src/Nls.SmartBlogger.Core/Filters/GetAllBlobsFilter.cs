namespace Nls.SmartBlogger.Core.Filters
{
    public class GetAllBlobsFilter
    {
        public ushort Skip { get; }
        public ushort Take { get; }

        public GetAllBlobsFilter
        (
            ushort skip = 0, 
            ushort take = 0
        )
        {
            Skip = skip;
            Take = take;
        }

        public GetAllBlobsFilter()
        {
            Skip = default;
            Take = default;
        }
    }
}
