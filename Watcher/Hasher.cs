namespace Watcher
{
    internal class Hasher
    {
        private readonly string file;

        public Hasher(string file)
        {
            this.file = file;
        }

        internal string GetHash()
        {
            return HashStr();
        }

        private string HashStr()
        {
            using (var crypt = System.Security.Cryptography.SHA384Managed.Create())
            {
                return System.Convert.ToBase64String(crypt.ComputeHash(GetFile()));
            }
        }

        private byte[] GetFile()
        {
            return ToByteArray(System.IO.File.ReadAllText(file));
        }

        private byte[] ToByteArray(string str)
        {
            return System.Text.Encoding.UTF8.GetBytes(str);
        }
    }
}
