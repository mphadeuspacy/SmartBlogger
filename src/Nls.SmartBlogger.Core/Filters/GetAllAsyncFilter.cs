namespace Nls.SmartBlogger.Core.Filters
{
    public class GetAllAsyncFilter
    {
        public ushort Skip { get; }
        public ushort Take { get; }

        public GetAllAsyncFilter
        (
            ushort skip = 0, 
            ushort take = 0
        )
        {
            Skip = skip;
            Take = take;
        }
    }
}
