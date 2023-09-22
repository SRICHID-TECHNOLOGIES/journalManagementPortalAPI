using System;

namespace db
{
    internal class Register_Table
    {
        public string Password { get; internal set; }
        public string Email { get; internal set; }

        internal static object ToList()
        {
            throw new NotImplementedException();
        }
    }
}