namespace Nls.SmartBlogger.Core.Filters
{
    public class GetAllByFilterAsyncInput
    {
        public ushort Skip { get; }
        public ushort Take { get; }

        public GetAllByFilterAsyncInput
        (
            ushort skip = 0, 
            ushort take = 0
        )
        {
            Skip = skip;
            Take = take;
        }

        public GetAllByFilterAsyncInput()
        {
            Skip = default;
            Take = default;
        }
    }
}
