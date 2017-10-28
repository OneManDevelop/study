using System.Collections;

namespace hash
{
    class Hash
    {
        public void GetAns(string ask, ref string ans)
        {
            ask = ask.Replace("bot ", "");   //name(calling) deleting
            ask = ask.Replace("бот ", "");
            string ask_code = "no code";


            int size = 1;
            int attach_size = 0;
            string[] hello = new string[] { "привет","hello","hi","hi!","хай" };
            string[] by = new string[] { "пока","by","good luck" };
            string[][] arr = new string[size+1][];
            arr = new string[size+1][];
            arr[0] = hello;
            arr[1] = by;


            for(int i=0; i<=size; i++)
            {
                attach_size = (arr[i].Length);
                for(int g=0; g<attach_size ; g++)
                {
                    if(ask == arr[i][g])
                    {
                        ask_code = arr[i][0];
                        System.Console.ForegroundColor = System.ConsoleColor.DarkYellow;
                        System.Console.WriteLine("keygen: " + ask_code);                       
                    }
                }
            }
            if (ask_code != "no code")
            {
                ans = ask_code;
            }
            else
            {
                ans = "unexpected word";
            }
        }
    }
}
