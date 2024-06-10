namespace Domain
{
    public class Edition : BaseEntity
    {
        public int Count { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PrintingPressId { get; set; }
        public PrintingPress PrintingPress{ get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
