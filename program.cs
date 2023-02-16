// See https://aka.ms/new-console-template for more information
using System.Collections.Specialized;
using System;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Net.Http.Headers;
using System.Dynamic;
using System.ComponentModel;
using System.Linq.Expressions;

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
            Console.WriteLine(@"Type encrypt to encrypt or decrypt to decrypt");
            string strDirection = Console.ReadLine();
            if (strInput != null && !strInput.Equals(@"") && strDirection.Equals(@"encrypt"))
            {
                var result = await callS3cr3tx(strInput, "e");//client1.GetStringAsync(@"https://s3cr3tx.com/Values");
                Console.WriteLine(@"Your Encrypted Output is:");
                Console.WriteLine(result);
            }
            if (strInput != null && !strInput.Equals(@"") && strDirection.Equals(@"decrypt"))
            {
                var result2 = await callS3cr3tx(strInput, "d");//client1.GetStringAsync(@"https://s3cr3tx.com/Values");
                Console.WriteLine(@"Your Decrypted Output is:");
                Console.WriteLine(result2);
            }
            
           
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetBaseException().ToString);
            return @"";
        }
    }
}
