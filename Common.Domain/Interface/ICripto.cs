using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Interface
{
    public interface ICripto
    {
        string TripleDESCripto(string value, string salt);
        string Encrypt(string text, string keyString);
        string Decrypt(string cipherText, string keyString);
    }
}
