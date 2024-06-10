namespace Domain
{
    public class Material : BaseEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string Format { get; set; }
        public int DyeId { get; set; }
        public Dye Dye { get; set; }
    }
}
