using System;

namespace address
{
    class Name
    {
        public void Called(ref string msg, ref bool named)
        {
            string calling;
            named = false;
            if (msg.Length >= 5)
            {
                calling = msg.Substring(0, 3);
                if ((calling == "bot") || (calling == "бот"))
                {
                    msg = msg.Replace(calling, "");
                    named = true;
                }
            }
        }
        public void GetMode(ref string msg, ref int mode)
        {
            mode = 0;
            try
            {
                if (msg.Substring(0, 10) == " симтомы ")
                {
                    mode = 1;
                    msg = msg.Replace(" симптомы ", "");                            //избыточное выражение для понятности кода
                }
                if ((msg.Substring(0, 10) == " описание ") && (mode == 0))
                {
                    mode = 2;
                    msg = msg.Replace(" описание ", "");
                }
                if ((msg.Substring(0, 13)) == " все симптомы" && (mode == 0))
                {
                    mode = 3;
                    msg = msg.Replace(" все симптомы", "");
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Too short string");
            }
        }

        public void GetLow(ref string inp)
        {
            string copy = "";
            char letter;

            foreach (char symb in inp)                   // регистро-независимость

            {
                letter = Char.ToLower(symb);
                copy = copy + letter;
            }
            inp = copy;
        }
    }
}
