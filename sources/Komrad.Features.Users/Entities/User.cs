namespace Komrad.Features.Users.Entities
{
    public abstract class User<TCredentials>
    {
        public virtual TCredentials Credentials { get; set; }
    }
}