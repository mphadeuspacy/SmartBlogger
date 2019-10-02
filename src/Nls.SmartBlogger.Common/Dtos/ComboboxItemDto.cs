namespace Nls.SmartBlogger.Common.Dtos
{
    public class ComboboxItemDto
    {
        public ComboboxItemDto(){}

        public ComboboxItemDto
        (
            string value,
            string displayText
        )
        {
            Value = value;
            DisplayText = displayText;
        }

        public string Value { get; set; }
        public string DisplayText { get; set; }
        public bool IsSelected { get; set; }
    }
}
