namespace Core.Entities
{
   public class research : EntityBase
    {
        public string ResearchName { get; set; }
        public string Discription { get; set; }
        public int year { get; set; }
        public string link { get; set; }
        public int reads { get; set; }
        public string owner { get; set; }

    }
}
