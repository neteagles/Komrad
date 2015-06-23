namespace Komrad.Features.Users.Entities
{
    public class Password
    {
        public virtual string Hash { get; set; }

        public virtual string Salt { get; set; }
    }
}