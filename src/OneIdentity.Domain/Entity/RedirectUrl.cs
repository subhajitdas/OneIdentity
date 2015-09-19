namespace OneIdentity.Domain.Entity
{
    public class RedirectUrl
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        public virtual Client Client { get; set; }
    }
}
        