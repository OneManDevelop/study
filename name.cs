

namespace address
{
    class Name
    {
        public void Called( ref string msg, ref bool named)
        {           
            string calling = "empty";
            named = false;
            if (msg.Length >= 5)
            {
                calling = msg.Substring(0, 4);
                if ((calling == "bot ") || (calling == "бот "))
                {
                    msg = msg.Replace(calling, "");
                    named = true;
                }
            }
        }
    }
}
//git first
