namespace BackEnd.Models.Editions
{
    public class CreateEditionModel
    {
        public int Count { get; set; }
        public int UserId { get; set; }
        public int PrintingPressId { get; set; }
        public int MaterialId { get; set; }
    }
}
