// See https://aka.ms/new-console-template for more information
using System.Collections.Specialized;
using System;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Net.Http.Headers;
using System.Dynamic;

public class s3cr3txCSharpTestApp
{
    private static string APIToken = @"";
    private static string AuthCode = @"";
    private static string strEmail = @"";
    public static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine(@"Welcome to the s3cr3tx C# Demo, please enter something to encrypt and decrypt: ");
            string strInput = Console.ReadLine();
            var client1 = new HttpClient();
            client1.DefaultRequestHeaders.Add("Email", strEmail);
            client1.DefaultRequestHeaders.Add("APIToken", APIToken);
            client1.DefaultRequestHeaders.Add("AuthCode", AuthCode);
            client1.DefaultRequestHeaders.Add("EorD", @"e");
            client1.DefaultRequestHeaders.Add("Input", strInput);
            var result = await client1.GetStringAsync(@"https://s3cr3tx.com/Values");
            Console.WriteLine(@"Your Encrypted Output is:");
            Console.WriteLine(result);
            Console.WriteLine(@"Your Decrypted Output is:");
            
            var client2 = new HttpClient();

            client2.DefaultRequestHeaders.Add("Email", strEmail);
            client2.DefaultRequestHeaders.Add("APIToken", APIToken);
            client2.DefaultRequestHeaders.Add("AuthCode", AuthCode);
            client2.DefaultRequestHeaders.Add("EorD", @"d");
            client2.DefaultRequestHeaders.Add("Input", result);
            var result2 = await client2.GetStringAsync(@"https://s3cr3tx.com/Values");
            Console.WriteLine(result2);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.GetBaseException().ToString());
        }


    }
    public async Task<string> Get(HttpClient client)
    {
        try
        {
            if (client.BaseAddress != null && !client.BaseAddress.Equals(@""))
            {
                var result = await client.GetStringAsync(client.BaseAddress);
                return result;
            }
            return @"";
        }
        catch (Exception ex){
                Console.WriteLine(ex.GetBaseException().ToString);
                return @"";
            }
        
    }
}
