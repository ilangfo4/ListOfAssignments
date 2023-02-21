using System;
using System.Security.Cryptography;
using System.Collections.Generic;
public class PasswordHash
{
    public string hashPW(string plainText)
    {
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(plainText);
        byte[] hashBytes = md5.ComputeHash(inputBytes);
        string upperHash = Convert.ToHexString(hashBytes);
        return upperHash.ToLower();
    }
}

public class Driver
{
    static List<string> mylist = new List<string>();
    static int maxSize = 5;

    public static void makeWords(int n, string str)
    {
        char myChar = ' ' ;
        if (n > maxSize)
            return;

        for(int i = 0; i < 26; i++)
        {
            myChar = (char)((int)'Z' - i);
            mylist.Add(str + myChar);
            makeWords(n + 1,str + myChar);
        }
        

    }

    static void Main(string[] args)
    {
        string pw1 = "1c75d402fb481523acd44e9d8247bc80";
        string pw2 = "5b1d59b5451c06afb65ab1bc2713cfb4";
        makeWords(1, "");
        PasswordHash password = new PasswordHash();

        for (int i = 0; i < mylist.Count; i++)
        {
            Console.WriteLine(mylist[i]);
           
        }
        
    }
}