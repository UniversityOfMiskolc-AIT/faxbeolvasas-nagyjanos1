namespace FaxReader.Lib
{
    public interface IAccountFactory
    {
        Account Create(params string[] rows);
        Account Create(string account);
    }
}
