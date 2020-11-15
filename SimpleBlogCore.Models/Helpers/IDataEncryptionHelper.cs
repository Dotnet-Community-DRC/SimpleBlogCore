namespace SimpleBlogCore.Web.Helpers
{
    public interface IDataEncryptionHelper
    {
        string Encrypt(string clearText);

        string Decrypt(string cypherText);
    }
}