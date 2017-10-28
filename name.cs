

namespace address
{
    class Name
    {
        public void Called(string msg, ref bool named)
        {           
            string calling = "empty";
            named = false;
            if (msg.Length >= 5)
            {
                calling = msg.Substring(0, 4);
                if ((calling == "bot ") || (calling == "бот "))
                {
                    named = true;
                }
            }
        }
    }
}
