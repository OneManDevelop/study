
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;
using sign;
using System;
using System.IO;
using hash;
using address;
using System.Threading;
using logs;

namespace chatbot
{
    class Chat
    {
        public static void Main(string[] args)
        {
            int logLength = 0;
            string path1 = @"C:\bot_data\msg.txt";
            string path2 = @"C:\bot_data\auth.txt";
            string logPath = @"C:\bot_data\log.txt";
            string logLengthPath = @"C:\bot_data\log_length.txt";
            string lastMessage = "empty";
            string output = "test";
            string input = "empty";
            string input_c = "";
            bool sending = false;
            bool opened = false;
            long dialogID = 199245750;                           // ID диалога   
            char s;
            FileStream file2 = new FileStream(path2, FileMode.OpenOrCreate);
            StreamReader reader2 = new StreamReader(file2);           
            string email = reader2.ReadLine();         // email или телефон
            string pass = reader2.ReadLine();               // пароль для авторизации       
            string dialog_ID = reader2.ReadLine();     // ID диалога
            reader2.Close();
            ulong appID = 6108951;                      // ID приложения
            Console.SetWindowSize(80, 30);
            Console.Title = "c#at";
            email = email.Replace("login: ", "");
            pass = pass.Replace("password: ", "");
            dialog_ID = dialog_ID.Replace("dialog_id: ", "");
            try
            {
                dialogID = Convert.ToInt64(dialog_ID);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n" + "incorrect dialog_id in auth.txt");
            }           
            Settings scope = Settings.All;      // Приложение имеет доступ ко всему
            var vk = new VkApi();
            Hash hs = new Hash();
            Signature sign = new Signature();
            Name nm = new Name();
            Log wLog = new Log();



            vk.Authorize(new ApiAuthParams
            {
                ApplicationId = appID,
                Login = email,
                Password = pass,
                Settings = scope
            });







            while (true)//start:loop
            {
                



                FileStream file1 = new FileStream(path1, FileMode.OpenOrCreate);
                StreamReader reader1 = new StreamReader(file1);
                lastMessage = reader1.ReadToEnd();
                reader1.Close();
                var mess = vk.Messages.GetHistory(new MessagesGetHistoryParams
                {
                    UserId = dialogID,
                    Count = 1,

                });



                foreach (var message2 in mess.Messages)
                {                    
                    input = message2.Body;
                }

                input_c = "";

                foreach (char symb in input)

                {
                    s = Char.ToLower(symb);
                    input_c = input_c + s;
                }

                input = input_c;

                nm.Called(input, ref sending);

                if ((input != lastMessage) && (sending == true))
                {
                    hs.GetAns(input, ref output);
                    File.WriteAllText(path1, input);
                }
                else
                {
                    sending = false;
                    output = "old or not named";
                }
                



                sign.MakeSign(ref output);                                    // giving colored list of in/out messages
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n" + "in:" + "\n" + input);
                wLog.AddLog(ref opened, ref logLength, logLengthPath, logPath, "in: " + input);
                if (sending == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                Console.WriteLine("\n" + "out:" + "\n" + output + "\n" + "send: " + sending);
                wLog.AddLog(ref opened, ref logLength, logLengthPath, logPath, "out: " + output + "||" + "send: " + sending);



                if (sending)
                {
                    var send = vk.Messages.Send(new MessagesSendParams
                    {
                        UserId = dialogID,
                        Message = output
                    });
                }
                Console.ReadLine();
                Thread.Sleep(5000);               
            }
            //end:loop


        }
    }
}//git second