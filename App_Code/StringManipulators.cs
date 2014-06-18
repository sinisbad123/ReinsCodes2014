using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using BCryptEncryption;

/// <summary>
/// For Use in various applications regarding string manipulation
/// </summary>
namespace CustomStrings
{
    public static class StringCustomizers
    {
        //For Trimming Strings
        public static string TrimToMaxSize(string input, int max)
        {
            return ((input != null) && (input.Length > max)) ?
                input.Substring(0, max) : input;
        }
        //Generates Random Strings..
        public static string RandomStr()
        {
            string rStr = Path.GetRandomFileName();
            rStr = rStr.Replace(".", "");
            return rStr;
        }
        //Cuts Strings, then adds a "..." if string char content exceeds max
        public static string CutIfLong(string input, int max)
        {
            if (input.Length > max)
            {
                string splittedstring = TrimToMaxSize(input, max) + "...";
                return splittedstring;
            }
            else
            {
                return input;
            }
        }

        public static double CheckMoney(double _input)
        {
            if (_input >= 0)
            {
                return _input;
            }
            else
            {
                return 0;
            }
        }

        public static bool checkDate(string _inDate)
        {
            try
            {
                DateTime.Parse(_inDate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string dateStampNoID = DateTime.Now.Year.ToString() + DateTime.Now.Month + DateTime.Now.Day + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

    }

    public static class AntiXSSMethods
    {
        //prevents scripts from being inserted into the DB - Anti-XSS Feature
        public static string StripHTML(string htmlString)
        {

            string pattern = @"<(.|\n)*?>";

            return Regex.Replace(htmlString, pattern, string.Empty);
        }

        public static string CleanString(string _input)
        {
            return StripHTML(_input.Trim());
        }

        public static string MakeStringSafeForSQL(string _input)
        {
            string raw = _input.Replace("'", "''");
            return raw.Replace("--", "");
        }

    }

    public static class Encryption
    {
        //for generating hashcode equivalent
        public static string MD5(string _input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] originalBytes = ASCIIEncoding.Default.GetBytes(_input);
            byte[] encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes).Replace("-", "");
        }

        public static string GenerateBCryptHash(string _input)
        {
            //adjust salt level here below"
            string salt = BCrypt.GenerateSalt();

            return BCrypt.HashPassword(AntiXSSMethods.CleanString(_input), salt);
        }

    }
}