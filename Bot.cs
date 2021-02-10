using System;
using System.Text;
using System.Threading;
using System.Net.Http;
using System.Collections.Generic;

namespace Discord_Chat_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sentences = new List<string>() { "sup", "uh no", "yup", "don't know about that", "what", "wym", "that's cool", "why", "because", "ok", "but", "I don't get it", "I get it", "I guess", "that's him", "oops", "wrong", "correct", "on discord", "where", "then", "that", "there", "now", "later" };
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "MjQ0NTM2OTc4MDA2MjEyNjA5.YB6SbQ.aYa4frEMJRnxLE20qXxK7qNO928");
            while (true)
            {
                try
                {
                    string sentence = sentences[new Random().Next(sentences.Count)];
                    Console.WriteLine($"Sentence chosen: {sentence}\nSending request...");
                    HttpResponseMessage reqresult = client.PostAsync("https://discord.com/api/v8/channels/585923458974875660/messages", new StringContent("{\"content\":\"" + sentence + "\"}", Encoding.UTF8, "application/json")).Result;
                    Console.WriteLine(reqresult.Content.ReadAsStringAsync().Result);
                }catch(Exception ex)
                {
                    Console.WriteLine($"There has been an error: {ex.Message}");
                }
                Thread.Sleep(60000); //60s
            }
        }
    }
}
