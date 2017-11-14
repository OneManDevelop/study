

using System;

namespace address
{
    class Name
    {
        public void Called( ref string msg, ref bool named)        
        {           
            string calling;
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
        public void GetMode(string msg, ref int mode)
        {
            mode = 0;
            if(msg.Substring(0, 8) == "симтомы")
            {
                mode = 0;                            //избыточное выражение для понятности кода
            }
            if (msg.Substring(0, 8) == "описание")
            {
                mode = 1;
            }
            if (msg.Substring(0, 6) == "узнать")
            {
                mode = 2;
            }
        }

        public void GetLow(ref string input)
        {
            string copy = "";
            char letter;

            foreach (char symb in input)                   // регистро-независимость

            {
                letter = Char.ToLower(symb);
                copy = copy + letter;
            }
            input = copy;
        }
    }
}
