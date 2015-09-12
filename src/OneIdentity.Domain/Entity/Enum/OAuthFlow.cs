namespace OneIdentity.Domain.Entity.Enum
{
    public enum OAuthFlow : byte
    {
        AuthorizationCode = 1,
        Implicit = 2,
        ResourceOwnerPasswordCredentials = 3,
        ClientCredentials = 4
    }
}