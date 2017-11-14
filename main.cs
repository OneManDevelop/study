
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
using System.Xml;
using System.Data;
using engines;

namespace chatbot
{
    class Chat
    {
        public static void Main(string[] args)
        {
            /*XmlDocument Data;
            DataTable Emptable;
            DataSet disease;*/
            int logLength = 0;
            int maximum = 0;
            string xmlpath = @"C:\bot_data\diseases.xml";
            string path1 = @"C:\bot_data\msg.txt";
            string path2 = @"C:\bot_data\auth.txt";
            string logPath = @"C:\bot_data\log.txt";
            string logLengthPath = @"C:\bot_data\log_length.txt";
            string lastMessage = "empty";
            string output = "test";
            string input = "empty";
            bool sending = false;
            bool opened = false;
            long dialogID;                         

            string[] outputArr = new string[5];

            XmlTextReader readerr = new XmlTextReader(xmlpath); // testing feature

            FileStream file2 = new FileStream(path2, FileMode.OpenOrCreate);
            StreamReader reader2 = new StreamReader(file2);           
            string email = reader2.ReadLine();        
            string pass = reader2.ReadLine();                  
            string dialog_ID = reader2.ReadLine();    
            reader2.Close();
            ulong appID = 6108951;                     
            Console.SetWindowSize(80, 30);
            Console.Title = "c#at";
            email = email.Replace("login: ", "");
            pass = pass.Replace("password: ", "");
            dialog_ID = dialog_ID.Replace("dialog_id: ", "");
            try
            {
                dialogID = Convert.ToInt64(dialog_ID);
                Console.WriteLine("ID converted");
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n" + "incorrect dialog_id in auth.txt");
                dialogID = 199245750;
            }           
            Settings scope = Settings.All;      // Приложение имеет доступ ко всему
            var vk = new VkApi();               // ссылки на статические классы
            Signature sign = new Signature();
            Name nm = new Name();
            Log wLog = new Log();
            Search engine = new Search();



            vk.Authorize(new ApiAuthParams
            {
                ApplicationId = appID,
                Login = email,
                Password = pass,
                Settings = scope
            });
         

            while (true)
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



                foreach (var message_txt in mess.Messages)            
                {                    
                    input = message_txt.Body;
                }

                nm.GetLow(ref input);

                nm.Called(ref input, ref sending);            // проверка наличия обращения "bot"

                if ((input != lastMessage) && (sending == true))  // проверка сообщения на совпадение с последним
                {
                    //hs.GetAns(input, ref output);                  // осталось с лета, удалить 
                    //Console.WriteLine(outputArr[1]);
                    File.WriteAllText(path1, input);
                    output = "";
                    engine.CountMatches(input, xmlpath, ref maximum);              // счетчик совпадений
                    engine.FindOut(maximum, ref outputArr, input, xmlpath);       // вывод при макс. кол-ве совпадений


                    foreach (string vers in outputArr)
                    {
                        // Console.WriteLine("xml found");
                        output = output + " " + vers;
                    }

                    sign.MakeSign(ref output);                         // подпись

                    var send = vk.Messages.Send(new MessagesSendParams
                    {
                        UserId = dialogID,
                        Message = output
                    });
                }
                else
                {
                    sending = false;
                    output = "old or not named";
                }
                



                                                  // giving colored list of in/out messages
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



                Console.ReadLine();
                Thread.Sleep(5000);               
            }
            


        }
    }
}