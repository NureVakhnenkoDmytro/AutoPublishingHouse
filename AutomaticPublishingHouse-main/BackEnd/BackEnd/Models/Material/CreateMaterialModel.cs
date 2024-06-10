namespace BackEnd.Models.Material
{
    public class CreateMaterialModel
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string Format { get; set; }
        public int DyeId { get; set; }
    }
}
