using System.Collections.Specialized;
using System;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Net.Http.Headers;
using System.Dynamic;
using System.ComponentModel;
using System.Linq.Expressions;

public class s3cr3txCSharpNET_protect_OpenAI_API_Key_Demo
{
    private static string APIToken = Environment.GetEnvironmentVariable(@"s3cr3tx_APIToken");
    private static string AuthCode = Environment.GetEnvironmentVariable(@"s3cr3tx_AuthCode");
    private static string strEmail = Environment.GetEnvironmentVariable(@"s3cr3tx_Email");

    public static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine(@"Welcome to the s3cr3tx C# Demo of protecting OpenAI API Keys");
            string strOpenAI_URL = @"https://api.openai.com/v1/models";
            var api_client = new HttpClient();
            var auth_header = "Bearer " + Environment.GetEnvironmentVariable(@"OPENAI_API_KEY");
            api_client.DefaultRequestHeaders.Add("Authorization", auth_header);
            var result1 = await api_client.GetStringAsync(strOpenAI_URL);
            Console.WriteLine(@"OpenAI response: " + result1);

            Environment.SetEnvironmentVariable(@"s3cr3tx_OpenAI_API_Key", await callS3cr3tx(Environment.GetEnvironmentVariable(@"OPENAI_API_KEY"), "e"));
            Console.WriteLine(@"Press enter to see the results using a s3cr3tx protected version of the API_Key");
            Console.ReadLine();
            var api_client2 = new HttpClient();
            api_client2.DefaultRequestHeaders.Add("Authorization", "Bearer " + await callS3cr3tx(Environment.GetEnvironmentVariable(@"s3cr3tx_OpenAI_API_KEY"), "d"));
            var result2 = await api_client.GetStringAsync(strOpenAI_URL);
            Console.WriteLine(@"OpenAI response after protecting OpenAI API Key with s3cr3tx: " + result2);
            Console.WriteLine(@"Press any key to exit");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetBaseException().ToString());
        }
    }

    private static async Task<string> callS3cr3tx(string strInput, string strDirection)
    {
        try
        {
            if (APIToken is not null && AuthCode is not null && strEmail is not null)
            {
                if (strDirection.Equals(@"e"))
                {
                    var client1 = new HttpClient();
                    client1.DefaultRequestHeaders.Add("Email", strEmail);
                    client1.DefaultRequestHeaders.Add("APIToken", APIToken);
                    client1.DefaultRequestHeaders.Add("AuthCode", AuthCode);
                    client1.DefaultRequestHeaders.Add("EorD", @"e");
                    client1.DefaultRequestHeaders.Add("Input", strInput);
                    var result = await client1.GetStringAsync(@"https://s3cr3tx.com/Values");
                    return result;
                }
                else
                {
                    var client1 = new HttpClient();
                    client1.DefaultRequestHeaders.Add("Email", strEmail);
                    client1.DefaultRequestHeaders.Add("APIToken", APIToken);
                    client1.DefaultRequestHeaders.Add("AuthCode", AuthCode);
                    client1.DefaultRequestHeaders.Add("EorD", @"d");
                    client1.DefaultRequestHeaders.Add("Input", strInput);
                    var result = await client1.GetStringAsync(@"https://s3cr3tx.com/Values");
                    return result;
                }
            }
            else
            {
                var result = @"Unable to complete. Please set the environment variables: s3cr3tx_APIToken, s3cr3tx_AuthCode, and s3cr3tx_Email";
                return result;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetBaseException().ToString);
            return @"";
        }
    }
}