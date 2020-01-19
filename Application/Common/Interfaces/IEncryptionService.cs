namespace Application.Common.Interfaces
{
    public interface IEncryptionService
    {
        string Encrypt<T>(T input);
        T Decrypt<T>(string encryptedCode);
    }
}
