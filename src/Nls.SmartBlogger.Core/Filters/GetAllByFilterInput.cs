namespace Nls.SmartBlogger.Core.Filters
{
    public class GetAllByFilterInput
    {
        public ushort Skip { get; set;  }
        public ushort Take { get; set;  }

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
