namespace Komrad.Features.Users.Entities
{
    public class BasicCredentials : Credentials
    {
        public override string Login
            => Email;

        public virtual string Email { get; set; }

        public virtual Password Password { get; set; }
    }
}