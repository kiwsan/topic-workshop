namespace Topic.Options
{
    public partial class ParameterOptions
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public partial class ParameterOptions<TValue>
    {
        public string Name { get; set; }
        public TValue Value { get; set; }
    }
}