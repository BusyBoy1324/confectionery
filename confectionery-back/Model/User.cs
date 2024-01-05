namespace confectionery_back.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string ?UserName { get; set; }
        public int OrderCounter { get; set; }
    }
}
