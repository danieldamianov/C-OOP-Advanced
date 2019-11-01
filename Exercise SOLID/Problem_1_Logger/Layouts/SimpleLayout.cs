namespace Problem_1_Logger.Layouts
{
    using Contracts;

    public class SimpleLayout : ILayout
    {
        public SimpleLayout()
        {
            this.Format = "{0} - {1} - {2}";
        }

        public string Format { get; }
    }
}
