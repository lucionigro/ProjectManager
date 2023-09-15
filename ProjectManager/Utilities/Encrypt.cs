using System.Text;

namespace ProjectManager.Utilities
{
    public static class Encrypt
    {
        public static string EncryptPassword(string password)
        {
            byte[] encryted = Encoding.Unicode.GetBytes(password);
            string result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string DecryptPassword(string password) 
        {
            byte[] decryted = Convert.FromBase64String(password);
            string result = Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
