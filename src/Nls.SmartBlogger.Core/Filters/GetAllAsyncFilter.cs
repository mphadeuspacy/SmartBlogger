namespace Nls.SmartBlogger.Core.Filters
{
    public class GetAllAsyncFilter
    {
        public int Take { get; }

        public GetAllAsyncFilter(int take)
        {
            Take = take;
        }
    }
}
