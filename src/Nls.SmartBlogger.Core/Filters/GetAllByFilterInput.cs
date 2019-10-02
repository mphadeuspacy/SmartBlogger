namespace Nls.SmartBlogger.Core.Filters
{
    public class GetAllByFilterInput
    {
        public ushort Skip { get; }
        public ushort Take { get; }

        public GetAllByFilterInput
        (
            ushort skip = 0, 
            ushort take = 0
        )
        {
            Skip = skip;
            Take = take;
        }

        public GetAllByFilterInput()
        {
            Skip = default;
            Take = default;
        }
    }
}
