using System;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Crypt
{
    public class Module
    {
        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        public static string GetMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static string ComputeHash(string plainText)
        {
            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];          

            HashAlgorithm hash = new SHA256Managed();

            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            byte[] hashWithSaltBytes = new byte[hashBytes.Length];

            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];            

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            return hashValue;
        }

        public static string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        public static string CreateEncodedString(string inptString)
        {
            CryptorEngine criptor = new CryptorEngine();

            string result = string.Empty;

            result = criptor.Encrypt(inptString.Trim(), true);

            return result;
        }

        public static string DecodeCriptedString(string inptString)
        {
            CryptorEngine criptor = new CryptorEngine();

            string result = string.Empty;

            result = criptor.Decrypt(inptString.Trim(), true);

            return result;
        }  
    }

    public class Utils
    {
        #region  Convert Valuta in Words

        //private static string GetNameOfSimpleNumber(int inputNumber, int languageID, bool MaculGen)
        //{
        //    string result = string.Empty;

        //    switch (languageID)
        //    {
        //        case (int)Constants.Constants.Classifiers.Romanian_Language:

        //            switch (inputNumber)
        //            {
        //                case 0:
        //                    result = "zero";
        //                    break;

        //                case 1:
        //                    if (MaculGen)
        //                        result = "unu";
        //                    else
        //                        result = "una";
        //                    break;

        //                case 2:
        //                    if(MaculGen)
        //                        result = "doi";
        //                    else
        //                        result = "două";
        //                    break;

        //                case 3:
        //                    result = "trei";
        //                    break;

        //                case 4:
        //                    result = "patru";
        //                    break;

        //                case 5:
        //                    result = "cinci";
        //                    break;

        //                case 6:
        //                    result = "șase";
        //                    break;

        //                case 7:
        //                    result = "șapte";
        //                    break;

        //                case 8:
        //                    result = "opt";
        //                    break;

        //                case 9:
        //                    result = "nouă";
        //                    break;

        //                case 10:
        //                    result = "zece";
        //                    break;

        //                case 11:
        //                    result = "unsprezece";
        //                    break;

        //                case 12:
        //                    result = "douăsprezece";
        //                    break;

        //                case 13:
        //                    result = "treisprezece";
        //                    break;

        //                case 14:
        //                    result = "paisprezece";
        //                    break;

        //                case 15:
        //                    result = "cincisprezece";
        //                    break;

        //                case 16:
        //                    result = "șaisprezece";
        //                    break;

        //                case 17:
        //                    result = "șaptesprezece";
        //                    break;

        //                case 18:
        //                    result = "optsprezece";
        //                    break;

        //                case 19:
        //                    result = "nouăsprezece";
        //                    break;

        //                case 20:
        //                    result = "douăzeci";
        //                    break;  

        //                case 30:
        //                    result = "treizeci";
        //                    break;

        //                case 40:
        //                    result = "patruzeci";
        //                    break;

        //                case 50:
        //                    result = "cincizeci";
        //                    break;

        //                case 60:
        //                    result = "șaizeci";
        //                    break;

        //                case 70:
        //                    result = "șaptezeci";
        //                    break;

        //                case 80:
        //                    result = "optzeci";
        //                    break;

        //                case 90:
        //                    result = "nouăzeci";
        //                    break;
        //            }

        //            break;


        //        case (int)Constants.Constants.Classifiers.Russian_Language:

        //            switch (inputNumber)
        //            {
        //                case 0:
        //                    result = "ноль";
        //                    break;

        //                case 1:
        //                    if (MaculGen)
        //                        result = "один";
        //                    else
        //                        result = "одна";
        //                    break;

        //                case 2:
        //                    if (MaculGen)
        //                        result = "два";
        //                    else
        //                        result = "две";
        //                    break;

        //                case 3:
        //                    result = "три";
        //                    break;

        //                case 4:
        //                    result = "четыре";
        //                    break;

        //                case 5:
        //                    result = "пять";
        //                    break;

        //                case 6:
        //                    result = "шесть";
        //                    break;

        //                case 7:
        //                    result = "семь";
        //                    break;

        //                case 8:
        //                    result = "восемь";
        //                    break;

        //                case 9:
        //                    result = "девять";
        //                    break;

        //                case 10:
        //                    result = "десять";
        //                    break;

        //                case 11:
        //                    result = "одиннадцать";
        //                    break;

        //                case 12:
        //                    result = "двенадцать";
        //                    break;

        //                case 13:
        //                    result = "тринадцать";
        //                    break;

        //                case 14:
        //                    result = "четырнадцать";
        //                    break;

        //                case 15:
        //                    result = "пятнадцать";
        //                    break;

        //                case 16:
        //                    result = "шестнадцать";
        //                    break;

        //                case 17:
        //                    result = "семнадцать";
        //                    break;

        //                case 18:
        //                    result = "восемнадцать";
        //                    break;

        //                case 19:
        //                    result = "девятнадцать";
        //                    break;

        //                case 20:
        //                    result = "двадцать";
        //                    break;

        //                case 30:
        //                    result = "тридцать";
        //                    break;

        //                case 40:
        //                    result = "сорок";
        //                    break;

        //                case 50:
        //                    result = "пятьдесят";
        //                    break;

        //                case 60:
        //                    result = "шестьдесят";
        //                    break;

        //                case 70:
        //                    result = "семьдесят";
        //                    break;

        //                case 80:
        //                    result = "восемьдесят";
        //                    break;

        //                case 90:
        //                    result = "девяносто";
        //                    break;  
        //            }

        //            break;

        //        case (int)Constants.Constants.Classifiers.English_Language:

        //            switch (inputNumber)
        //            {
        //                case 0:
        //                    result = "zero";
        //                    break;

        //                case 1:
        //                    result = "one";
        //                    break;

        //                case 2:
        //                    result = "two";
        //                    break;

        //                case 3:
        //                    result = "three";
        //                    break;

        //                case 4:
        //                    result = "four";
        //                    break;

        //                case 5:
        //                    result = "five";
        //                    break;

        //                case 6:
        //                    result = "six";
        //                    break;

        //                case 7:
        //                    result = "seven";
        //                    break;

        //                case 8:
        //                    result = "eight";
        //                    break;

        //                case 9:
        //                    result = "nine";
        //                    break;

        //                case 10:
        //                    result = "ten";
        //                    break;

        //                case 11:
        //                    result = "eleven";
        //                    break;

        //                case 12:
        //                    result = "twelve";
        //                    break;

        //                case 13:
        //                    result = "thirteen";
        //                    break;

        //                case 14:
        //                    result = "fourteen";
        //                    break;

        //                case 15:
        //                    result = "fifteen";
        //                    break;

        //                case 16:
        //                    result = "sixteen";
        //                    break;

        //                case 17:
        //                    result = "seventeen";
        //                    break;

        //                case 18:
        //                    result = "eighteen";
        //                    break;

        //                case 19:
        //                    result = "nineteen";
        //                    break;

        //                case 20:
        //                    result = "twenty";
        //                    break;

        //                case 30:
        //                    result = "thirty";
        //                    break;

        //                case 40:
        //                    result = "Forty";
        //                    break;

        //                case 50:
        //                    result = "fifty";
        //                    break;

        //                case 60:
        //                    result = "sixty";
        //                    break;

        //                case 70:
        //                    result = "seventy";
        //                    break;

        //                case 80:
        //                    result = "eighty";
        //                    break;

        //                case 90:
        //                    result = "ninety";
        //                    break;
        //            }

        //            break;
        //    }

        //    return result;
        //}

        //private static string GetErrorMessage(int languageID)
        //{
        //    string result = string.Empty;

        //    switch (languageID)
        //    {
        //        case (int)Constants.Constants.Classifiers.Romanian_Language:
        //            result = "Numarul introdus este prea mare";
        //            break;

        //        case (int)Constants.Constants.Classifiers.Russian_Language:
        //            result = "Введенный номер слишком большой";
        //            break;

        //        case (int)Constants.Constants.Classifiers.English_Language:
        //            result = "The number entered is too large";
        //            break;
        //    }

        //    return result;
        //}

        //private static string GetAndWord(int languageID)
        //{
        //    string result = string.Empty;

        //    switch (languageID)
        //    {
        //        case (int)Constants.Constants.Classifiers.Romanian_Language:
        //            result = "și";
        //            break;

        //        case (int)Constants.Constants.Classifiers.Russian_Language:
        //            result = "";
        //            break;

        //        case (int)Constants.Constants.Classifiers.English_Language:
        //            result = "";
        //            break;
        //    }

        //    return result;
        //}


        private static string GetValutaWord(int languageID)
        {
            string valutaWord = string.Empty;

            switch (languageID)
            {
                case (int)Constants.Constants.Classifiers.Romanian_Language:
                    valutaWord = "lei";
                    break;

                case (int)Constants.Constants.Classifiers.Russian_Language:
                    valutaWord = "рублей";
                    break;

            }

            return valutaWord;
        }

        private static string GetValutaWord(int languageID, int amount)
        {
            string valutaWord = string.Empty;

            switch (languageID)
            {
                case (int)Constants.Constants.Classifiers.Romanian_Language:
                    switch (amount)
                    {
                        default:
                            valutaWord = "lei";
                            break;
                    }
                    break;

                case (int)Constants.Constants.Classifiers.Russian_Language:
                    switch (amount)
                    {
                        case 1:
                            valutaWord = "рубль";
                            break;
                        case 2:
                            valutaWord = "рубля";
                            break;
                        case 3:
                            valutaWord = "рубля";
                            break;
                        case 4:
                            valutaWord = "рубля";
                            break;
                        default:
                            valutaWord = "рублей";
                            break;
                    }
                    break;
            }

            return valutaWord;
        }

        private static string GetValutaCentWord(int languageID)
        {
            string valutaCentWord = string.Empty;

            switch (languageID)
            {
                case (int)Constants.Constants.Classifiers.Romanian_Language:
                    valutaCentWord = "bani";
                    break;

                case (int)Constants.Constants.Classifiers.Russian_Language:
                    valutaCentWord = "копеек";
                    break;
            }

            return valutaCentWord;
        }

        private static string GetWordsAfterPoint(int languageID, int dupaVirgula)
        {
            string result = string.Empty;

            string valutaWord = GetValutaWord(languageID);
            string valutaCentWord = GetValutaCentWord(languageID);

            result = valutaWord + " " + (dupaVirgula == 0 ? "00" : (dupaVirgula < 10 ? "0" + dupaVirgula.ToString() : dupaVirgula.ToString())) + " " + valutaCentWord;

            return result;
        }

        #region Romanian Translate

        private const int ZeciKeyWord = 2;
        private const int SuteKeyWord = 3;
        private const int MiiKeyWord = 4;
        private const int MilioaneKeyWord = 7;
        private const int MiliardeKeyWord = 10;

        private static string GetSuteMiiKeyWord_ROM(int suteMiiKeyNumber, bool plural)
        {
            string result = string.Empty;

            switch (suteMiiKeyNumber)
            {
                case 2:
                    result = "zeci";
                    break;

                case 3:
                    if (plural)
                        result = "sute";
                    else
                        result = "sută";
                    break;

                case 4:
                    if (plural)
                        result = "mii";
                    else
                        result = "mie";
                    break;

                case 5:
                    result = "mii";
                    break;

                case 6:
                    result = "mii";
                    break;

                case 7:
                    if (plural)
                        result = "milioane";
                    else
                        result = "milion";
                    break;

                case 8:
                    result = "milioane";
                    break;

                case 9:
                    result = "milioane";
                    break;

                case 10:
                    if (plural)
                        result = "miliarde";
                    else
                        result = "miliard";
                    break;

                case 11:
                    result = "miliarde";
                    break;

                case 12:
                    result = "miliarde";
                    break;
            }

            return result;
        }

        private static string GeSimpleNumberWord_ROM(int inputNumber, bool MaculGen)
        {
            string result = string.Empty;

            switch (inputNumber)
            {
                case 0:
                    result = "zero";
                    break;

                case 1:
                    if (MaculGen)
                        result = "unu";
                    else
                        result = "una";
                    break;

                case 2:
                    if (MaculGen)
                        result = "doi";
                    else
                        result = "două";
                    break;

                case 3:
                    result = "trei";
                    break;

                case 4:
                    result = "patru";
                    break;

                case 5:
                    result = "cinci";
                    break;

                case 6:
                    result = "șase";
                    break;

                case 7:
                    result = "șapte";
                    break;

                case 8:
                    result = "opt";
                    break;

                case 9:
                    result = "nouă";
                    break;

                case 10:
                    result = "zece";
                    break;

                case 11:
                    result = "unsprezece";
                    break;

                case 12:
                    result = "douăsprezece";
                    break;

                case 13:
                    result = "treisprezece";
                    break;

                case 14:
                    result = "paisprezece";
                    break;

                case 15:
                    result = "cincisprezece";
                    break;

                case 16:
                    result = "șaisprezece";
                    break;

                case 17:
                    result = "șaptesprezece";
                    break;

                case 18:
                    result = "optsprezece";
                    break;

                case 19:
                    result = "nouăsprezece";
                    break;
            }

            return result;
        }

        private static string GetSumInWords_ROM(int pinaLaVirgula)
        {
            string result = string.Empty;

            int lenghtOfNumber = pinaLaVirgula.ToString().Length;

            bool genMasculin = true;
            bool genFemenin = false;

            bool plural = true;
            bool singular = false;

            switch (lenghtOfNumber)
            {
                case 1: // 5
                    result = GeSimpleNumberWord_ROM(pinaLaVirgula, genMasculin);
                    break;

                case 2: // 50
                    {
                        if (pinaLaVirgula < 20)
                        {
                            result = GeSimpleNumberWord_ROM(pinaLaVirgula, genMasculin);
                        }
                        else
                        {
                            int firstNumber = pinaLaVirgula / 10;
                            int lastNumber = pinaLaVirgula % 10;

                            result = GeSimpleNumberWord_ROM(firstNumber, genFemenin) + GetSuteMiiKeyWord_ROM(ZeciKeyWord, plural) + (lastNumber > 0 ? " și " + GeSimpleNumberWord_ROM(lastNumber, genMasculin) : string.Empty);
                        }
                    }
                    break;

                case 3: // 500
                    {
                        int suteNumber = pinaLaVirgula / 100;
                        int zeciNumber = pinaLaVirgula % 100;

                        result = GeSimpleNumberWord_ROM(suteNumber, genFemenin) + " " + (suteNumber == 1 ? GetSuteMiiKeyWord_ROM(SuteKeyWord, singular) : GetSuteMiiKeyWord_ROM(SuteKeyWord, plural)) + " " + GetSumInWords_ROM(zeciNumber);
                    }
                    break;

                case 4: // 5 000                
                    {
                        int miiNumber = pinaLaVirgula / 1000;
                        int suteNumber = pinaLaVirgula % 1000;

                        result = GeSimpleNumberWord_ROM(miiNumber, genFemenin) + " " + (miiNumber == 1 ? GetSuteMiiKeyWord_ROM(MiiKeyWord, singular) : GetSuteMiiKeyWord_ROM(MiiKeyWord, plural)) + " " + GetSumInWords_ROM(suteNumber);
                    }
                    break;

                case 5: // 50 000
                case 6: // 500 000
                    {
                        int miiNumber = pinaLaVirgula / 1000;
                        int suteNumber = pinaLaVirgula % 1000;

                        result = GetSumInWords_ROM(miiNumber) + " " + GetSuteMiiKeyWord_ROM(MiiKeyWord, plural) + " " + GetSumInWords_ROM(suteNumber);
                    }
                    break;

                case 7: // 5 000 000
                    {
                        int milionNumber = pinaLaVirgula / 1000000;
                        int miiiNumber = pinaLaVirgula % 1000000;

                        result = GeSimpleNumberWord_ROM(milionNumber, genFemenin) + " " + (milionNumber == 1 ? GetSuteMiiKeyWord_ROM(MilioaneKeyWord, singular) : GetSuteMiiKeyWord_ROM(MilioaneKeyWord, plural)) + " " + GetSumInWords_ROM(miiiNumber);
                    }
                    break;

                case 8: // 50 000 000
                case 9: // 500 000 000
                    {
                        int milionNumber = pinaLaVirgula / 1000000;
                        int miiiNumber = pinaLaVirgula % 1000000;

                        result = GetSumInWords_ROM(milionNumber) + " " + GetSuteMiiKeyWord_ROM(MilioaneKeyWord, plural) + " " + GetSumInWords_ROM(miiiNumber);
                    }
                    break;

                case 10: // 5 000 000 000
                    {
                        int milionNumber = pinaLaVirgula / 1000000000;
                        int miiiNumber = pinaLaVirgula % 1000000000;

                        result = GeSimpleNumberWord_ROM(milionNumber, genFemenin) + " " + (milionNumber == 1 ? GetSuteMiiKeyWord_ROM(MiliardeKeyWord, singular) : GetSuteMiiKeyWord_ROM(MiliardeKeyWord, plural)) + " " + GetSumInWords_ROM(miiiNumber);
                    }
                    break;

                case 11: // 50 000 000 000
                case 12: // 500 000 000 000
                    {
                        int milionNumber = pinaLaVirgula / 1000000000;
                        int miiiNumber = pinaLaVirgula % 1000000000;

                        result = GetSumInWords_ROM(milionNumber) + " " + GetSuteMiiKeyWord_ROM(MiliardeKeyWord, plural) + " " + GetSumInWords_ROM(miiiNumber);
                    }
                    break;

                default:
                    break;
            }

            return result;
        }

        #endregion Romanian Translate

        public static string GetSumInWord(decimal number, int languageID, int numberWordMode)
        {
            string result = string.Empty;

            switch (languageID)
            {
                case (int)Constants.Constants.Classifiers.Romanian_Language:

                    int pinaLaVirgula = (int)(Math.Abs(number));
                    int dupaVirgula = (int)((Math.Abs(number) - pinaLaVirgula) * 100);

                    switch (numberWordMode)
                    {
                        case (int)Constants.Constants.NumberWordMode.Money:
                            result = GetSumInWords_ROM(pinaLaVirgula) + " " + GetWordsAfterPoint(languageID, dupaVirgula);
                            break;

                        case (int)Constants.Constants.NumberWordMode.SimpleNumber:
                            result = GetSumInWords_ROM(pinaLaVirgula) + " intreg , " + (dupaVirgula == 0 ? "00" : (dupaVirgula < 10 ? "0" + dupaVirgula.ToString() : dupaVirgula.ToString()));
                            break;

                        case (int)Constants.Constants.NumberWordMode.Percent:
                            result = GetSumInWords_ROM(pinaLaVirgula) + " intreg , " + (dupaVirgula == 0 ? "00" : (dupaVirgula < 10 ? "0" + dupaVirgula.ToString() : dupaVirgula.ToString())) + " procente";
                            break;
                    }

                    break;

                case (int)Constants.Constants.Classifiers.Russian_Language:

                    break;

                case (int)Constants.Constants.Classifiers.English_Language:

                    break;
            }

            return result;
        }

        public static string GetValutaNameInWords(int languageID, int valutaID, bool infinitiv)
        {
            string result = string.Empty;

            switch (languageID)
            {
                case (int)Constants.Constants.Classifiers.Romanian_Language:
                    switch (valutaID)
                    {
                        case (int)Constants.Constants.CurrencyList.MDL:
                            result = infinitiv ? "lei moldovenesti" : "leului moldovenesc";
                            break;
                        case (int)Constants.Constants.CurrencyList.USD:
                            result = infinitiv ? "dolari SUA" : "dolarului SUA";
                            break;
                        case (int)Constants.Constants.CurrencyList.EURO:
                            result = infinitiv ? "EURO" : "EURO";
                            break;
                    }
                    break;

                case (int)Constants.Constants.Classifiers.Russian_Language:
                    switch (valutaID)
                    {
                        case (int)Constants.Constants.CurrencyList.MDL:
                            break;
                        case (int)Constants.Constants.CurrencyList.USD:
                            break;
                        case (int)Constants.Constants.CurrencyList.EURO:
                            break;
                    }
                    break;

                case (int)Constants.Constants.Classifiers.English_Language:
                    switch (valutaID)
                    {
                        case (int)Constants.Constants.CurrencyList.MDL:
                            break;
                        case (int)Constants.Constants.CurrencyList.USD:
                            break;
                        case (int)Constants.Constants.CurrencyList.EURO:
                            break;
                    }
                    break;
            }

            return result;
        }

        public static string GetCurrencyChangeValutaSimbols(int firstValuta, int secondValuta)
        {
            string result = string.Empty;

            if (firstValuta == (int)Constants.Constants.CurrencyList.MDL && secondValuta == (int)Constants.Constants.CurrencyList.USD)
            {
                result = "MDL/USD";
            }
            else
                if (firstValuta == (int)Constants.Constants.CurrencyList.USD && secondValuta == (int)Constants.Constants.CurrencyList.MDL)
                {
                    result = "USD/MDL";
                }
                else
                    if (firstValuta == (int)Constants.Constants.CurrencyList.MDL && secondValuta == (int)Constants.Constants.CurrencyList.EURO)
                    {
                        result = "MDL/EURO";
                    }
                    else
                        if (firstValuta == (int)Constants.Constants.CurrencyList.EURO && secondValuta == (int)Constants.Constants.CurrencyList.MDL)
                        { result = "EURO/MDL"; }

            return result;
        }


        public static string GetNameOfMonthBymonthNumber(int languageID, int montNumber)
        {
            string result = string.Empty;

            switch (languageID)
            {
                case (int)Constants.Constants.Classifiers.Romanian_Language:

                    switch (montNumber)
                    {
                        case 1:
                            result = "Ianuarie";
                            break;
                        case 2:
                            result = "Februarie";
                            break;
                        case 3:
                            result = "Martie";
                            break;
                        case 4:
                            result = "Aprilie";
                            break;
                        case 5:
                            result = "Mai";
                            break;
                        case 6:
                            result = "Iunie";
                            break;
                        case 7:
                            result = "Iulie";
                            break;
                        case 8:
                            result = "August";
                            break;
                        case 9:
                            result = "Septembrie";
                            break;
                        case 10:
                            result = "Octombrie";
                            break;
                        case 11:
                            result = "Noiembrie";
                            break;
                        case 12:
                            result = "Decembrie";
                            break;
                    }

                    break;

                case (int)Constants.Constants.Classifiers.Russian_Language:

                    switch (montNumber)
                    {
                        case 1:
                            result = "Январь";
                            break;
                        case 2:
                            result = "Февраль";
                            break;
                        case 3:
                            result = "Март";
                            break;
                        case 4:
                            result = "Апрель";
                            break;
                        case 5:
                            result = "Май";
                            break;
                        case 6:
                            result = "Июнь";
                            break;
                        case 7:
                            result = "Июль";
                            break;
                        case 8:
                            result = "Август";
                            break;
                        case 9:
                            result = "Сентябрь";
                            break;
                        case 10:
                            result = "Октябрь";
                            break;
                        case 11:
                            result = "Ноябрь";
                            break;
                        case 12:
                            result = "Декабрь";
                            break;
                    }

                    break;

                case (int)Constants.Constants.Classifiers.English_Language:

                    switch (montNumber)
                    {
                        case 1:
                            result = "January";
                            break;
                        case 2:
                            result = "February";
                            break;
                        case 3:
                            result = "March";
                            break;
                        case 4:
                            result = "April";
                            break;
                        case 5:
                            result = "May";
                            break;
                        case 6:
                            result = "June";
                            break;
                        case 7:
                            result = "July";
                            break;
                        case 8:
                            result = "August";
                            break;
                        case 9:
                            result = "September";
                            break;
                        case 10:
                            result = "October";
                            break;
                        case 11:
                            result = "November";
                            break;
                        case 12:
                            result = "December";
                            break;
                    }

                    break;
            }

            return result;
        }

        public static string GetDateTimeInSpecialFormat(DateTime inputDate)
        {
            string result = string.Empty;

            if (inputDate != null && !inputDate.Equals(DateTime.MinValue))
            {
                int inputData_Day = inputDate.Day;
                int inputData_Month = inputDate.Month;
                int inputData_Year = inputDate.Year;

                result = " " + inputData_Day.ToString() + " " + GetNameOfMonthBymonthNumber((int)Constants.Constants.Classifiers.Romanian_Language, inputData_Month) + " " + inputData_Year.ToString();
            }

            return result;
        }

        public static string GetDateTimeInFullWordsFormat(DateTime inputDate)
        {
            string result = string.Empty;

            if (inputDate != null && !inputDate.Equals(DateTime.MinValue))
            {
                int inputData_Day = inputDate.Day;
                int inputData_Month = inputDate.Month;
                int inputData_Year = inputDate.Year;

                string dayWordString = Crypt.Utils.GetSumInWord(inputData_Day, (int)Constants.Constants.Classifiers.Romanian_Language, (int)Constants.Constants.NumberWordMode.SimpleNumber);
                string yearWordString = Crypt.Utils.GetSumInWord(inputData_Year, (int)Constants.Constants.Classifiers.Romanian_Language, (int)Constants.Constants.NumberWordMode.SimpleNumber);

                result = " " + dayWordString + " " + GetNameOfMonthBymonthNumber((int)Constants.Constants.Classifiers.Romanian_Language, inputData_Month) + " anul " + yearWordString;
            }

            return result;
        }

        #endregion  Convert Valuta in Words

        //public static bool IsDirectoryEmpty(string path)
        //{
        //    return !Directory.EnumerateFileSystemEntries(path).Any();
        //}

        public static DateTime ToDateTime(string inputString, string format)
        {
            DateTime result = DateTime.MinValue;

            if (!inputString.Equals(String.Empty))
            {
                DateTime.TryParseExact(inputString, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out result);
            }

            return result;
        }

        public static decimal MyDecimalParce(string value)
        {
            decimal defaultValue = 0m;

            decimal result = 0;
            if (!string.IsNullOrEmpty(value))
            {
                string output;

                // check if last seperator==groupSeperator
                string groupSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;
                if (value.LastIndexOf(groupSep) + 4 == value.Count())
                {
                    bool tryParse = decimal.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
                    result = tryParse ? result : defaultValue;
                }
                else
                {
                    // unify string (no spaces, only . )     
                    output = value.Trim().Replace(" ", string.Empty).Replace(",", ".");

                    // split it on points     
                    string[] split = output.Split('.');

                    if (split.Count() > 1)
                    {
                        // take all parts except last         
                        output = string.Join(string.Empty, split.Take(split.Count() - 1).ToArray());

                        // combine token parts with last part         
                        output = string.Format("{0}.{1}", output, split.Last());
                    }
                    // parse double invariant     
                    result = decimal.Parse(output, System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            return result;
        }

        public static string ReplaceAcronim(string sourceText)
        {           
            string result = sourceText;

            result = result.Replace((char)92, ' ');  // \ 
            result = result.Replace((char)94, ' ');  // ^ 
            result = result.Replace((char)96, ' ');  // ` 
            result = result.Replace((char)126, ' ');  // ~ 

            result = result.Replace((char)161, '.');  // ¡ INVERTED EXCLAMATION MARK
            result = result.Replace((char)162, '.');  // ¢ CENT SIGN 
            result = result.Replace((char)163, '.');  // £ CENT SIGN 
            result = result.Replace((char)164, '.');  // ¤ CURRENCY SIGN 
            result = result.Replace((char)165, '.');  // ¥ YEN SIGN
            result = result.Replace((char)166, '.');  // ¦ 
            result = result.Replace((char)167, '.');  // § SECTION SIGN 
            result = result.Replace((char)168, '.');  // ¨ 
            result = result.Replace((char)169, '.');  // © COPYRIGHT SIGN 
            result = result.Replace((char)170, 'a');  // ª FEMININE ORDINAL INDICATOR 
            // result = result.Replace((char)171, ' ');  //  « LEFT-POINTING DOUBLE ANGLE QUOTATION MARK 
            result = result.Replace((char)172, ' ');  // ¬ NOT SIGN
            result = result.Replace((char)174, ' ');  // ® REGISTERED SIGN 
            result = result.Replace((char)175, '-');  // ¯ MACRON 
            result = result.Replace((char)176, ' ');  // ° DEGREE SIGN
            result = result.Replace((char)177, ' ');  // ± PLUS-MINUS SIGN 
            result = result.Replace((char)178, '2');  // ² SUPERSCRIPT TWO
            result = result.Replace((char)179, '3');  // ³ SUPERSCRIPT THREE
            result = result.Replace((char)180, ' ');  // ´ ACUTE ACCENT
            result = result.Replace((char)181, 'm');  // µ MICRO SIGN 
            result = result.Replace((char)182, '.'); // ¶ PILCROW SIGN
            result = result.Replace((char)183, '.'); // · MIDDLE DOT
            result = result.Replace((char)184, '.'); // ¸ CEDILLA
            result = result.Replace((char)185, '.'); // ¹ SUPERSCRIPT ONE
            result = result.Replace((char)186, ' '); // º MASCULINE ORDINAL INDICATOR
            result = result.Replace((char)187, '.'); // » RIGHT- POINTING DOUBLE ANGLE QUOTATION MARK
            result = result.Replace((char)188, '.'); // ¼ VULGAR FRACTION ONE QUARTER
            result = result.Replace((char)189, '.'); // ½ VULGAR FRACTION ONE HALF
            result = result.Replace((char)190, '.'); // ¾ VULGAR FRACTION THREE QUARTERS
            result = result.Replace((char)191, '.'); // ¿ INVERTED QUESTION MARK
            result = result.Replace((char)192, 'A'); // À LATIN CAPITAL LETTER A WITH GRAVE
            result = result.Replace((char)193, 'A'); // Á LATIN CAPITAL LETTER A WITH ACUTE
            result = result.Replace((char)194, 'A'); // Â LATIN CAPITAL LETTER A WITH CIRCUMFLEX
            result = result.Replace((char)195, 'A'); // Ã LATIN CAPITAL LETTER A WITH TILDE
            result = result.Replace((char)196, 'A'); // Ä LATIN CAPITAL LETTER A WITH DIAERESIS
            result = result.Replace((char)197, 'A'); // Å LATIN CAPITAL LETTER A WITH RING ABOVE
            result = result.Replace((char)198, 'A'); // Æ LATIN CAPITAL LETTER AE
            result = result.Replace((char)199, 'C'); // Ç LATIN CAPITAL LETTER C WITH CEDILLA
            result = result.Replace((char)200, 'E'); // È LATIN CAPITAL LETTER E WITH GRAVE
            result = result.Replace((char)201, 'E'); // É LATIN CAPITAL LETTER E WITH ACUTE
            result = result.Replace((char)202, 'E'); // Ê LATIN CAPITAL LETTER E WITH CIRCUMFLEX
            result = result.Replace((char)203, 'E'); // Ë LATIN CAPITAL LETTER E WITH DIAERESIS
            result = result.Replace((char)204, 'I'); // Ì LATIN CAPITAL LETTER I WITH GRAVE
            result = result.Replace((char)205, 'I'); // Í LATIN CAPITAL LETTER I WITH ACUTE
            result = result.Replace((char)206, 'I'); // Î LATIN CAPITAL LETTER I WITH CIRCUMFLEX
            result = result.Replace((char)207, 'I'); // Ï LATIN CAPITAL LETTER I WITH DIAERESIS
            result = result.Replace((char)208, 'D'); // Ð LATIN CAPITAL LETTER ETH
            result = result.Replace((char)209, 'N'); // Ñ LATIN CAPITAL LETTER N WITH TILDE
            result = result.Replace((char)210, 'O'); // Ò LATIN CAPITAL LETTER O WITH GRAVE
            result = result.Replace((char)211, 'O'); // Ó LATIN CAPITAL LETTER O WITH ACUTE
            result = result.Replace((char)212, 'O'); // Ô LATIN CAPITAL LETTER O WITH CIRCUMFLEX
            result = result.Replace((char)213, 'O'); // Õ LATIN CAPITAL LETTER O WITH TILDE
            result = result.Replace((char)214, 'O'); // Ö LATIN CAPITAL LETTER O WITH DIAERESIS
            result = result.Replace((char)215, 'X'); // × MULTIPLICATION SIGN
            result = result.Replace((char)216, '0'); // Ø LATIN CAPITAL LETTER O WITH STROKE
            result = result.Replace((char)217, 'U'); // Ù LATIN CAPITAL LETTER U WITH GRAVE
            result = result.Replace((char)218, 'U'); // Ú LATIN CAPITAL LETTER U WITH ACUTE
            result = result.Replace((char)219, 'U'); // Û LATIN CAPITAL LETTER U WITH CIRCUMFLEX
            result = result.Replace((char)220, 'U'); // Ü LATIN CAPITAL LETTER U WITH DIAERESIS
            result = result.Replace((char)221, 'Y'); // Ý LATIN CAPITAL LETTER Y WITH ACUTE
            result = result.Replace((char)222, '.'); // Þ LATIN CAPITAL LETTER THORN
            result = result.Replace((char)223, 'b'); // ß LATIN SMALL LETTER SHARP S
            result = result.Replace((char)224, 'a'); // à LATIN SMALL LETTER A WITH GRAVE
            result = result.Replace((char)225, 'a'); // á LATIN SMALL LETTER A WITH ACUTE
            result = result.Replace((char)226, 'a'); // â LATIN SMALL LETTER A WITH CIRCUMFLEX
            result = result.Replace((char)227, 'a'); // ã LATIN SMALL LETTER A WITH TILDE
            result = result.Replace((char)228, 'a'); // ä LATIN SMALL LETTER A WITH DIAERESIS
            result = result.Replace((char)229, 'a'); // å LATIN SMALL LETTER A WITH RING ABOVE
            result = result.Replace((char)230, 'a'); // æ LATIN SMALL LETTER AE
            result = result.Replace((char)231, 'c'); // ç LATIN SMALL LETTER C WITH CEDILLA
            result = result.Replace((char)232, 'e'); // è LATIN SMALL LETTER E WITH GRAVE
            result = result.Replace((char)233, 'e'); // é LATIN SMALL LETTER E WITH ACUTE
            result = result.Replace((char)234, 'e'); // ê LATIN SMALL LETTER E WITH CIRCUMFLEX
            result = result.Replace((char)235, 'e'); // ë LATIN SMALL LETTER E WITH DIAERESIS
            result = result.Replace((char)236, 'i'); // ì LATIN SMALL LETTER I WITH GRAVE
            result = result.Replace((char)237, 'i'); // í LATIN SMALL LETTER I WITH ACUTE
            result = result.Replace((char)238, 'i'); // î LATIN SMALL LETTER I WITH CIRCUMFLEX
            result = result.Replace((char)239, 'i'); // ï LATIN SMALL LETTER I WITH DIAERESIS
            result = result.Replace((char)240, 'o'); // ð LATIN SMALL LETTER ETH
            result = result.Replace((char)241, 'n'); // ñ LATIN SMALL LETTER N WITH TILDE
            result = result.Replace((char)242, 'o'); // ò LATIN SMALL LETTER O WITH GRAVE
            result = result.Replace((char)243, 'o'); // ó LATIN SMALL LETTER O WITH ACUTE
            result = result.Replace((char)244, 'o'); // ô LATIN SMALL LETTER O WITH CIRCUMFLEX
            result = result.Replace((char)245, 'o'); // õ LATIN SMALL LETTER O WITH TILDE
            result = result.Replace((char)246, 'o'); // ö LATIN SMALL LETTER O WITH DIAERESIS
            result = result.Replace((char)247, '.'); // ÷ DIVISION SIGN
            result = result.Replace((char)248, 'o'); // ø LATIN SMALL LETTER O WITH STROKE
            result = result.Replace((char)249, 'u'); // ù LATIN SMALL LETTER U WITH GRAVE
            result = result.Replace((char)250, 'u'); // ú LATIN SMALL LETTER U WITH ACUTE
            result = result.Replace((char)251, 'u'); // û LATIN SMALL LETTER U WITH CIRCUMFLEX
            result = result.Replace((char)252, 'u'); // ü LATIN SMALL LETTER U WITH DIAERESIS
            result = result.Replace((char)253, 'y'); // ý LATIN SMALL LETTER Y WITH ACUTE
            result = result.Replace((char)254, 'p'); // þ LATIN SMALL LETTER THORN
            result = result.Replace((char)255, 'y'); // ÿ LATIN SMALL LETTER Y WITH DIAERESIS
            result = result.Replace((char)256, 'A'); // Ā 
            result = result.Replace((char)257, 'a'); // ā 
            result = result.Replace((char)258, 'A'); // Ă 
            result = result.Replace((char)259, 'a'); // ă 
            result = result.Replace((char)260, 'A'); // Ą 
            result = result.Replace((char)261, 'a'); // ą 
            result = result.Replace((char)262, 'C'); // Ć 
            result = result.Replace((char)263, 'c'); // ć 
            result = result.Replace((char)264, 'C'); // Ĉ 
            result = result.Replace((char)265, 'c'); // ĉ 
            result = result.Replace((char)266, 'C'); // Ċ 
            result = result.Replace((char)267, 'c'); // ċ 
            result = result.Replace((char)268, 'C'); // Č 
            result = result.Replace((char)269, 'c'); // č 
            result = result.Replace((char)270, 'D'); // Ď 
            result = result.Replace((char)271, 'd'); // ď 
            result = result.Replace((char)272, 'D'); // Đ 
            result = result.Replace((char)273, 'd'); // đ 
            result = result.Replace((char)274, 'E'); // Ē 
            result = result.Replace((char)275, 'e'); // ē 
            result = result.Replace((char)276, 'E'); // Ĕ 
            result = result.Replace((char)277, 'e'); // ĕ 
            result = result.Replace((char)278, 'E'); // Ė 
            result = result.Replace((char)279, 'e'); // ė 
            result = result.Replace((char)280, 'E'); // Ę 
            result = result.Replace((char)281, 'e'); // ę 
            result = result.Replace((char)282, 'E'); // Ě 
            result = result.Replace((char)283, 'e'); // ě 
            result = result.Replace((char)284, 'G'); // Ĝ 
            result = result.Replace((char)285, 'g'); // ĝ 
            result = result.Replace((char)286, 'G'); // Ğ 
            result = result.Replace((char)287, 'g'); // ğ 
            result = result.Replace((char)288, 'G'); // Ġ 
            result = result.Replace((char)289, 'g'); // ġ 
            result = result.Replace((char)290, 'G'); // Ģ 
            result = result.Replace((char)291, 'g'); // ģ 
            result = result.Replace((char)292, 'H'); // Ĥ 
            result = result.Replace((char)293, 'h'); // ĥ 
            result = result.Replace((char)294, 'H'); // Ħ 
            result = result.Replace((char)295, 'h'); // ħ 
            result = result.Replace((char)296, 'I'); // Ĩ 
            result = result.Replace((char)297, 'i'); // ĩ 
            result = result.Replace((char)298, 'I'); // Ī 
            result = result.Replace((char)299, 'i'); // ī 
            result = result.Replace((char)300, 'I'); // Ĭ 
            result = result.Replace((char)301, 'i'); // ĭ 
            result = result.Replace((char)302, 'I'); // Į 
            result = result.Replace((char)303, 'i'); // į 
            result = result.Replace((char)304, 'I'); // İ 
            result = result.Replace((char)305, 'i'); // ı 
            result = result.Replace((char)306, 'I'); // Ĳ 
            result = result.Replace((char)307, 'i'); // ĳ 
            result = result.Replace((char)308, 'J'); // Ĵ 
            result = result.Replace((char)309, 'j'); // ĵ 
            result = result.Replace((char)310, 'K'); // Ķ 
            result = result.Replace((char)311, 'k'); // ķ 
            result = result.Replace((char)312, 'k'); // ĸ 
            result = result.Replace((char)313, 'L'); // Ĺ 
            result = result.Replace((char)314, 'l'); // ĺ 
            result = result.Replace((char)315, 'L'); // Ļ 
            result = result.Replace((char)316, 'l'); // ļ 
            result = result.Replace((char)317, 'L'); // Ľ 
            result = result.Replace((char)318, 'l'); // ľ 
            result = result.Replace((char)319, 'L'); // Ŀ 
            result = result.Replace((char)320, 'l'); // ŀ 
            result = result.Replace((char)321, 'L'); // Ł 
            result = result.Replace((char)322, 'l'); // ł 
            result = result.Replace((char)323, 'N'); // Ń 
            result = result.Replace((char)324, 'n'); // ń 
            result = result.Replace((char)325, 'N'); // Ņ 
            result = result.Replace((char)326, 'n'); // ņ 
            result = result.Replace((char)327, 'N'); // Ň 
            result = result.Replace((char)328, 'n'); // ň 
            result = result.Replace((char)329, 'n'); // ŉ 
            result = result.Replace((char)330, 'N'); // Ŋ 
            result = result.Replace((char)331, 'n'); // ŋ 
            result = result.Replace((char)332, 'O'); // Ō 
            result = result.Replace((char)333, 'o'); // ō 
            result = result.Replace((char)334, 'O'); // Ŏ 
            result = result.Replace((char)335, 'o'); // ŏ 
            result = result.Replace((char)336, 'O'); // Ő 
            result = result.Replace((char)337, 'o'); // ő 
            result = result.Replace((char)338, 'O'); // Œ 
            result = result.Replace((char)339, 'o'); // œ
            result = result.Replace((char)340, 'R'); // Ŕ 
            result = result.Replace((char)341, 'r'); // ŕ 
            result = result.Replace((char)342, 'R'); // Ŗ 
            result = result.Replace((char)343, 'r'); // ŗ 
            result = result.Replace((char)344, 'R'); // Ř 
            result = result.Replace((char)345, 'r'); // ř 
            result = result.Replace((char)346, 'S'); // Ś 
            result = result.Replace((char)346, 'S'); // Ś
            result = result.Replace((char)347, 's'); // ś
            result = result.Replace((char)348, 'S'); // Ŝ 
            result = result.Replace((char)349, 's'); // ŝ 
            result = result.Replace((char)350, 'S'); // Ş 
            result = result.Replace((char)351, 's'); // ş 
            result = result.Replace((char)352, 'S'); // Š 
            result = result.Replace((char)353, 's'); // š 
            result = result.Replace((char)354, 'T'); // Ţ 
            result = result.Replace((char)355, 't'); // ţ 
            result = result.Replace((char)356, 'T'); // Ť 
            result = result.Replace((char)357, 't'); // ť 
            result = result.Replace((char)358, 'T'); // Ŧ 
            result = result.Replace((char)359, 't'); // ŧ 
            result = result.Replace((char)360, 'U'); // Ũ 
            result = result.Replace((char)361, 'u'); // ũ 
            result = result.Replace((char)362, 'U'); // Ū 
            result = result.Replace((char)363, 'u'); // ū 
            result = result.Replace((char)364, 'U'); // Ŭ 
            result = result.Replace((char)365, 'u'); // ŭ 
            result = result.Replace((char)366, 'U'); // Ů 
            result = result.Replace((char)367, 'u'); // ů 
            result = result.Replace((char)368, 'U'); // Ű 
            result = result.Replace((char)369, 'u'); // ű 
            result = result.Replace((char)370, 'U'); // Ų 
            result = result.Replace((char)371, 'u'); // ų 
            result = result.Replace((char)372, 'W'); // Ŵ 
            result = result.Replace((char)373, 'w'); // ŵ 
            result = result.Replace((char)374, 'Y'); // Ŷ 
            result = result.Replace((char)375, 'y'); // ŷ 
            result = result.Replace((char)376, 'Y'); // Ÿ
            result = result.Replace((char)377, 'Z'); // Ź
            result = result.Replace((char)378, 'z'); // ź
            result = result.Replace((char)379, 'Z'); // Ż
            result = result.Replace((char)380, 'z'); // ż
            result = result.Replace((char)381, 'Z'); // Ž 
            result = result.Replace((char)382, 'z'); // ž 
            result = result.Replace((char)383, '.'); // ſ 
            result = result.Replace((char)384, '.'); // ƀ 
            result = result.Replace((char)385, 'B'); // Ɓ 
            result = result.Replace((char)386, '.'); // Ƃ 
            result = result.Replace((char)387, '.'); // ƃ 
            result = result.Replace((char)388, 'b'); // Ƅ 
            result = result.Replace((char)389, 'b'); // ƅ 
            result = result.Replace((char)390, '.'); // Ɔ 
            result = result.Replace((char)391, 'C'); // Ƈ 
            result = result.Replace((char)392, 'C'); // ƈ 
            result = result.Replace((char)393, 'D'); // Ɖ 
            result = result.Replace((char)394, 'D'); // Ɗ 
            result = result.Replace((char)395, '.'); // Ƌ 
            result = result.Replace((char)396, '.'); // ƌ 
            result = result.Replace((char)397, '.'); // ƍ 
            result = result.Replace((char)398, '.'); // Ǝ 
            result = result.Replace((char)399, '.'); // Ə 
            result = result.Replace((char)400, '.'); // Ɛ 
            result = result.Replace((char)401, 'F'); // Ƒ 
            result = result.Replace((char)402, 'f'); // ƒ 
            result = result.Replace((char)403, 'G'); // Ɠ 
            result = result.Replace((char)404, '.'); // Ɣ 
            result = result.Replace((char)405, '.'); // ƕ 
            result = result.Replace((char)406, 'l'); // Ɩ 
            result = result.Replace((char)407, 'I'); // Ɨ 
            result = result.Replace((char)408, 'K'); // Ƙ 
            result = result.Replace((char)409, 'k'); // ƙ 
            result = result.Replace((char)410, 'l'); // ƚ 
            result = result.Replace((char)411, '.'); // ƛ 
            result = result.Replace((char)412, '.'); // Ɯ 
            result = result.Replace((char)413, 'N'); // Ɲ 
            result = result.Replace((char)414, 'n'); // ƞ 
            result = result.Replace((char)415, 'O'); // Ɵ 
            result = result.Replace((char)416, 'O'); // Ơ 
            result = result.Replace((char)417, 'o'); // ơ 
            result = result.Replace((char)418, '.'); // Ƣ 
            result = result.Replace((char)419, '.'); // ƣ 
            result = result.Replace((char)420, 'p'); // Ƥ 
            result = result.Replace((char)421, 'p'); // ƥ 
            result = result.Replace((char)422, 'R'); // Ʀ 
            result = result.Replace((char)423, 'S'); // Ƨ 
            result = result.Replace((char)424, 's'); // ƨ 
            result = result.Replace((char)425, '.'); // Ʃ 
            result = result.Replace((char)426, '.'); // ƪ 
            result = result.Replace((char)427, 't'); // ƫ 
            result = result.Replace((char)428, 'T'); // Ƭ 
            result = result.Replace((char)429, 't'); // ƭ 
            result = result.Replace((char)430, 'T'); // Ʈ 
            result = result.Replace((char)431, 'U'); // Ư 
            result = result.Replace((char)432, 'u'); // ư 
            result = result.Replace((char)433, 'V'); // Ʊ 
            result = result.Replace((char)434, 'v'); // Ʋ 
            result = result.Replace((char)435, 'Y'); // Ƴ 
            result = result.Replace((char)436, 'y'); // ƴ 
            result = result.Replace((char)437, 'Z'); // Ƶ 
            result = result.Replace((char)438, 'z'); // ƶ 
            result = result.Replace((char)439, '.'); // Ʒ 
            result = result.Replace((char)440, '.'); // Ƹ 
            result = result.Replace((char)441, '.'); // ƹ 
            result = result.Replace((char)442, '.'); // ƺ 
            result = result.Replace((char)443, '.'); // ƻ 
            //result = result.Replace((char)444, ' '); // Ƽ 
            //result = result.Replace((char)445, ' '); // ƽ 
            //result = result.Replace((char)446, ' '); // ƾ 
            result = result.Replace((char)447, 'p'); // ƿ 
            result = result.Replace((char)448, '.'); // ǀ 
            result = result.Replace((char)449, '.'); // ǁ 
            result = result.Replace((char)450, '.'); // ǂ 
            result = result.Replace((char)451, '.'); // ǃ 
            result = result.Replace((char)452, 'D'); // Ǆ 
            result = result.Replace((char)453, 'D'); // ǅ 
            result = result.Replace((char)454, 'd'); // ǆ 
            result = result.Replace((char)455, 'L'); // Ǉ 
            result = result.Replace((char)456, 'l'); // ǈ 
            result = result.Replace((char)457, 'l'); // ǉ 
            result = result.Replace((char)458, 'N'); // Ǌ 
            result = result.Replace((char)459, 'N'); // ǋ 
            result = result.Replace((char)460, 'n'); // ǌ 
            result = result.Replace((char)461, 'A'); // Ǎ 
            result = result.Replace((char)462, 'a'); // ǎ 
            result = result.Replace((char)463, 'I'); // Ǐ 
            result = result.Replace((char)464, 'I'); // ǐ 
            result = result.Replace((char)465, 'O'); // Ǒ 
            result = result.Replace((char)466, 'o'); // ǒ 
            result = result.Replace((char)467, 'U'); // Ǔ 
            result = result.Replace((char)468, 'u'); // ǔ 
            result = result.Replace((char)469, 'U'); // Ǖ 
            result = result.Replace((char)470, 'u'); // ǖ 
            result = result.Replace((char)471, 'U'); // Ǘ 
            result = result.Replace((char)472, 'u'); // ǘ 
            result = result.Replace((char)473, 'U'); // Ǚ 
            result = result.Replace((char)474, 'u'); // ǚ 
            result = result.Replace((char)475, 'U'); // Ǜ 
            result = result.Replace((char)476, 'u'); // ǜ 
            result = result.Replace((char)477, '.'); // ǝ 
            result = result.Replace((char)478, 'A'); // Ǟ 
            result = result.Replace((char)479, 'a'); // ǟ 
            result = result.Replace((char)480, 'A'); // Ǡ 
            result = result.Replace((char)481, 'a'); // ǡ 
            result = result.Replace((char)482, 'A'); // Ǣ 
            result = result.Replace((char)483, 'a'); // ǣ 
            result = result.Replace((char)484, 'G'); // Ǥ 
            result = result.Replace((char)485, 'g'); // ǥ 
            result = result.Replace((char)486, 'G'); // Ǧ 
            result = result.Replace((char)487, 'g'); // ǧ 
            result = result.Replace((char)488, 'K'); // Ǩ 
            result = result.Replace((char)489, 'k'); // ǩ 
            result = result.Replace((char)490, 'Q'); // Ǫ 
            result = result.Replace((char)491, 'q'); // ǫ 
            result = result.Replace((char)492, 'Q'); // Ǭ 
            result = result.Replace((char)493, 'q'); // ǭ 
            result = result.Replace((char)494, '.'); // Ǯ 
            result = result.Replace((char)495, '.'); // ǯ 
            result = result.Replace((char)496, 'J'); // ǰ 
            result = result.Replace((char)497, 'D'); // Ǳ 
            result = result.Replace((char)498, 'd'); // ǲ 
            result = result.Replace((char)499, 'd'); // ǳ 
            result = result.Replace((char)500, 'G'); // Ǵ 
            result = result.Replace((char)501, 'g'); // ǵ 
            result = result.Replace((char)502, 'H'); // Ƕ 
            result = result.Replace((char)503, 'P'); // Ƿ 
            result = result.Replace((char)504, 'N'); // Ǹ 
            result = result.Replace((char)505, 'n'); // ǹ 
            result = result.Replace((char)506, 'A'); // Ǻ 
            result = result.Replace((char)507, 'a'); // ǻ 
            result = result.Replace((char)508, 'A'); // Ǽ 
            result = result.Replace((char)509, 'a'); // ǽ 
            result = result.Replace((char)510, 'O'); // Ǿ 
            result = result.Replace((char)511, 'o'); // ǿ 
            result = result.Replace((char)512, 'A'); // Ȁ 
            result = result.Replace((char)513, 'a'); // ȁ 
            result = result.Replace((char)514, 'A'); // Ȃ 
            result = result.Replace((char)515, 'a'); // ȃ 
            result = result.Replace((char)516, 'E'); // Ȅ 
            result = result.Replace((char)517, 'e'); // ȅ 
            result = result.Replace((char)518, 'E'); // Ȇ 
            result = result.Replace((char)519, 'e'); // ȇ 
            result = result.Replace((char)520, 'I'); // Ȉ 
            result = result.Replace((char)521, 'i'); // ȉ 
            result = result.Replace((char)522, 'I'); // Ȋ 
            result = result.Replace((char)523, 'i'); // ȋ 
            result = result.Replace((char)524, 'O'); // Ȍ 
            result = result.Replace((char)525, 'o'); // ȍ 
            result = result.Replace((char)526, 'O'); // Ȏ 
            result = result.Replace((char)527, 'o'); // ȏ 
            result = result.Replace((char)528, 'R'); // Ȑ 
            result = result.Replace((char)529, 'r'); // ȑ 
            result = result.Replace((char)530, 'R'); // Ȓ 
            result = result.Replace((char)531, 'r'); // ȓ 
            result = result.Replace((char)532, 'U'); // Ȕ 
            result = result.Replace((char)533, 'U'); // ȕ 
            result = result.Replace((char)534, 'U'); // Ȗ 
            result = result.Replace((char)535, 'u'); // ȗ 
            result = result.Replace((char)536, 'S'); // Ș 
            result = result.Replace((char)537, 's'); // ș 
            result = result.Replace((char)538, 'T'); // Ț 
            result = result.Replace((char)539, 't'); // ț 
            result = result.Replace((char)540, '.'); // Ȝ 
            result = result.Replace((char)541, '.'); // ȝ 
            result = result.Replace((char)542, 'H'); // Ȟ 
            result = result.Replace((char)543, 'h'); // ȟ 
            result = result.Replace((char)544, 'n'); // Ƞ 
            result = result.Replace((char)545, '.'); // ȡ 
            result = result.Replace((char)546, '.'); // Ȣ 
            result = result.Replace((char)547, '.'); // ȣ 
            result = result.Replace((char)548, 'Z'); // Ȥ 
            result = result.Replace((char)549, 'z'); // ȥ 
            result = result.Replace((char)550, 'A'); // Ȧ 
            result = result.Replace((char)551, 'a'); // ȧ 
            result = result.Replace((char)552, 'E'); // Ȩ 
            result = result.Replace((char)553, 'e'); // ȩ 
            result = result.Replace((char)554, 'O'); // Ȫ 
            result = result.Replace((char)555, 'o'); // ȫ 
            result = result.Replace((char)556, 'O'); // Ȭ 
            result = result.Replace((char)557, 'o'); // ȭ 
            result = result.Replace((char)558, 'O'); // Ȯ 
            result = result.Replace((char)559, 'o'); // ȯ 
            result = result.Replace((char)560, 'O'); // Ȱ 
            result = result.Replace((char)561, 'o'); // ȱ 
            result = result.Replace((char)562, 'Y'); // Ȳ 
            result = result.Replace((char)563, 'y'); // ȳ 
            result = result.Replace((char)564, 'L'); // ȴ 
            result = result.Replace((char)565, 'n'); // ȵ 
            result = result.Replace((char)566, 't'); // ȶ 
            result = result.Replace((char)567, 'J'); // ȷ 
            result = result.Replace((char)568, '.'); // ȸ 
            result = result.Replace((char)569, '.'); // ȹ 
            result = result.Replace((char)570, 'A'); // Ⱥ 
            result = result.Replace((char)571, 'C'); // Ȼ 
            result = result.Replace((char)572, 'c'); // ȼ 
            result = result.Replace((char)573, 'L'); // Ƚ 
            result = result.Replace((char)574, 'T'); // Ⱦ 
            result = result.Replace((char)575, 's'); // ȿ 
            result = result.Replace((char)576, 'z'); // ɀ 
            result = result.Replace((char)577, '.'); // Ɂ 
            result = result.Replace((char)578, '.'); // ɂ 
            result = result.Replace((char)579, 'B'); // Ƀ 
            result = result.Replace((char)580, 'U'); // Ʉ 
            result = result.Replace((char)581, 'A'); // Ʌ 
            result = result.Replace((char)582, 'E'); // Ɇ 
            result = result.Replace((char)583, 'e'); // ɇ 
            result = result.Replace((char)584, 'J'); // Ɉ 
            result = result.Replace((char)585, 'j'); // ɉ 
            result = result.Replace((char)586, '.'); // Ɋ 
            result = result.Replace((char)587, '.'); // ɋ 
            result = result.Replace((char)588, 'R'); // Ɍ 
            result = result.Replace((char)589, 'r'); // ɍ 
            result = result.Replace((char)590, 'Y'); // Ɏ 
            result = result.Replace((char)591, 'y'); // ɏ 
            result = result.Replace((char)592, '.'); // ɐ 
            result = result.Replace((char)593, 'a'); // ɑ 
            result = result.Replace((char)594, 'b'); // ɒ 
            result = result.Replace((char)595, 'b'); // ɓ 
            result = result.Replace((char)596, '.'); // ɔ 
            result = result.Replace((char)597, '.'); // ɕ 
            result = result.Replace((char)598, '.'); // ɖ 
            result = result.Replace((char)599, 'd'); // ɗ 
            result = result.Replace((char)600, 'e'); // ɘ 
            result = result.Replace((char)601, 'e'); // ə 
            result = result.Replace((char)602, 'e'); // ɚ 
            result = result.Replace((char)603, '.'); // ɛ 
            result = result.Replace((char)604, '.'); // ɜ 
            result = result.Replace((char)605, '.'); // ɝ 
            result = result.Replace((char)606, '.'); // ɞ 
            result = result.Replace((char)607, 'j'); // ɟ 
            result = result.Replace((char)608, 'g'); // ɠ 
            result = result.Replace((char)609, 'g'); // ɡ 
            result = result.Replace((char)610, 'G'); // ɢ 
            result = result.Replace((char)611, '.'); // ɣ 
            result = result.Replace((char)612, '.'); // ɤ 
            result = result.Replace((char)613, '.'); // ɥ 
            result = result.Replace((char)614, 'h'); // ɦ 
            result = result.Replace((char)615, 'h'); // ɧ 
            result = result.Replace((char)616, 'i'); // ɨ 
            result = result.Replace((char)617, 'l'); // ɩ 
            result = result.Replace((char)618, 'i'); // ɪ 
            result = result.Replace((char)619, 'l'); // ɫ 
            result = result.Replace((char)620, 'l'); // ɬ 
            result = result.Replace((char)621, 'l'); // ɭ 
            result = result.Replace((char)622, '.'); // ɮ 
            result = result.Replace((char)623, '.'); // ɯ 
            result = result.Replace((char)624, '.'); // ɰ 
            result = result.Replace((char)625, 'm'); // ɱ 
            result = result.Replace((char)626, '.'); // ɲ 
            result = result.Replace((char)627, 'n'); // ɳ 
            result = result.Replace((char)628, 'N'); // ɴ 
            result = result.Replace((char)629, 'o'); // ɵ 
            result = result.Replace((char)630, 'c'); // ɶ 
            result = result.Replace((char)631, '.'); // ɷ 
            result = result.Replace((char)632, '.'); // ɸ 
            //result = result.Replace((char)633, ' '); // ɹ 
            //result = result.Replace((char)634, ' '); // ɺ 
            //result = result.Replace((char)635, ' '); // ɻ 
            result = result.Replace((char)636, 'r'); // ɼ 
            result = result.Replace((char)637, 'r'); // ɽ 
            result = result.Replace((char)638, 'r'); // ɾ 
            result = result.Replace((char)639, 'r'); // ɿ 
            result = result.Replace((char)640, 'R'); // ʀ 
            result = result.Replace((char)641, 'R'); // ʁ 
            result = result.Replace((char)642, 's'); // ʂ 
            result = result.Replace((char)643, '.'); // ʃ 
            result = result.Replace((char)644, '.'); // ʄ 
            result = result.Replace((char)645, '.'); // ʅ 
            result = result.Replace((char)646, '.'); // ʆ 
            result = result.Replace((char)647, '.'); // ʇ 
            result = result.Replace((char)648, 't'); // ʈ 
            result = result.Replace((char)649, 'u'); // ʉ 
            result = result.Replace((char)650, 'v'); // ʊ 
            result = result.Replace((char)651, 'v'); // ʋ 
            result = result.Replace((char)652, 'a'); // ʌ 
            result = result.Replace((char)653, 'M'); // ʍ 
            result = result.Replace((char)654, '.'); // ʎ 
            result = result.Replace((char)655, 'Y'); // ʏ 
            result = result.Replace((char)656, 'z'); // ʐ 
            result = result.Replace((char)657, 'z'); // ʑ 
            //result = result.Replace((char)658, ' '); // ʒ 
            //result = result.Replace((char)659, ' '); // ʓ 
            //result = result.Replace((char)660, ' '); // ʔ 
            //result = result.Replace((char)661, ' '); // ʕ 
            //result = result.Replace((char)662, ' '); // ʖ 
            //result = result.Replace((char)663, ' '); // ʗ 
            //result = result.Replace((char)664, ' '); // ʘ 
            //result = result.Replace((char)665, ' '); // ʙ 
            //result = result.Replace((char)666, ' '); // ʚ 
            //result = result.Replace((char)667, ' '); // ʛ 
            //result = result.Replace((char)668, ' '); // ʜ 
            //result = result.Replace((char)669, ' '); // ʝ 
            //result = result.Replace((char)670, ' '); // ʞ 
            //result = result.Replace((char)671, ' '); // ʟ 
            //result = result.Replace((char)672, ' '); // ʠ 
            //result = result.Replace((char)673, ' '); // ʡ 
            //result = result.Replace((char)674, ' '); // ʢ 
            //result = result.Replace((char)675, ' '); // ʣ 
            //result = result.Replace((char)676, ' '); // ʤ 
            //result = result.Replace((char)677, ' '); // ʥ 
            //result = result.Replace((char)678, ' '); // ʦ 
            //result = result.Replace((char)679, ' '); // ʧ 
            //result = result.Replace((char)680, ' '); // ʨ 
            //result = result.Replace((char)681, ' '); // ʩ 
            //result = result.Replace((char)682, ' '); // ʪ 
            //result = result.Replace((char)683, ' '); // ʫ 
            //result = result.Replace((char)684, ' '); // ʬ 
            //result = result.Replace((char)685, ' '); // ʭ 
            //result = result.Replace((char)686, ' '); // ʮ 
            //result = result.Replace((char)687, ' '); // ʯ 
            //result = result.Replace((char)688, ' '); // ʰ 
            //result = result.Replace((char)689, ' '); // ʱ 
            //result = result.Replace((char)690, ' '); // ʲ 
            //result = result.Replace((char)691, ' '); // ʳ 
            //result = result.Replace((char)692, ' '); // ʴ 
            //result = result.Replace((char)693, ' '); // ʵ 
            //result = result.Replace((char)694, ' '); // ʶ 
            //result = result.Replace((char)695, ' '); // ʷ 
            //result = result.Replace((char)696, ' '); // ʸ 
            result = result.Replace((char)697, ' '); // ʹ 
            result = result.Replace((char)698, ' '); // ʺ 
            result = result.Replace((char)699, ' '); // ʻ 
            result = result.Replace((char)700, ' '); // ʼ 
            result = result.Replace((char)701, ' '); // ʽ 
            result = result.Replace((char)702, ' '); // ʾ 
            result = result.Replace((char)703, ' '); // ʿ 
            result = result.Replace((char)704, ' '); // ˀ 
            result = result.Replace((char)705, ' '); // ˁ 
            result = result.Replace((char)706, ' '); // ˂ 
            result = result.Replace((char)707, ' '); // ˃ 
            result = result.Replace((char)708, ' '); // ˄ 
            result = result.Replace((char)709, ' '); // ˅ 
            result = result.Replace((char)710, ' '); // ˆ 
            result = result.Replace((char)711, ' '); // ˇ 
            result = result.Replace((char)712, ' '); // ˈ 
            result = result.Replace((char)713, ' '); // ˉ 
            result = result.Replace((char)714, ' '); // ˊ 
            result = result.Replace((char)715, ' '); // ˋ 
            result = result.Replace((char)716, ' '); // ˌ 
            result = result.Replace((char)717, ' '); // ˍ 
            result = result.Replace((char)718, ' '); // ˎ 
            result = result.Replace((char)719, ' '); // ˏ 
            result = result.Replace((char)720, ' '); // ː 
            result = result.Replace((char)721, ' '); // ˑ 
            result = result.Replace((char)722, ' '); // ˒ 
            result = result.Replace((char)723, ' '); // ˓ 
            result = result.Replace((char)724, ' '); // ˔ 
            result = result.Replace((char)725, ' '); // ˕ 
            result = result.Replace((char)726, ' '); // ˖ 
            result = result.Replace((char)727, ' '); // ˗ 
            result = result.Replace((char)728, ' '); // ˘ 
            result = result.Replace((char)729, ' '); // ˙ 
            result = result.Replace((char)730, ' '); // ˚ 
            result = result.Replace((char)731, ' '); // ˛ 
            result = result.Replace((char)732, ' '); // ˜ 
            result = result.Replace((char)733, ' '); // ˝ 
            result = result.Replace((char)734, ' '); // ˞ 
            result = result.Replace((char)735, ' '); // ˟ 
            result = result.Replace((char)736, ' '); // ˠ 
            result = result.Replace((char)737, ' '); // ˡ 
            result = result.Replace((char)738, ' '); // ˢ 
            result = result.Replace((char)739, ' '); // ˣ 
            result = result.Replace((char)740, ' '); // ˤ 
            result = result.Replace((char)741, ' '); // ˥ 
            result = result.Replace((char)742, ' '); // ˦ 
            result = result.Replace((char)743, ' '); // ˧ 
            result = result.Replace((char)744, ' '); // ˨ 
            result = result.Replace((char)745, ' '); // ˩ 
            result = result.Replace((char)746, ' '); // ˪ 
            result = result.Replace((char)747, ' '); // ˫ 
            result = result.Replace((char)748, ' '); // ˬ 
            result = result.Replace((char)749, ' '); // ˭ 
            result = result.Replace((char)750, ' '); // ˮ 
            result = result.Replace((char)751, ' '); // ˯ 
            result = result.Replace((char)752, ' '); // ˰ 
            result = result.Replace((char)753, ' '); // ˱ 
            result = result.Replace((char)754, ' '); // ˲ 
            result = result.Replace((char)755, ' '); // ˳ 
            result = result.Replace((char)756, ' '); // ˴ 
            result = result.Replace((char)757, ' '); // ˵ 
            result = result.Replace((char)758, ' '); // ˶ 
            result = result.Replace((char)759, ' '); // ˷ 
            result = result.Replace((char)760, ' '); // ˸ 
            result = result.Replace((char)761, ' '); // ˹ 
            result = result.Replace((char)762, ' '); // ˺ 
            result = result.Replace((char)763, ' '); // ˻ 
            result = result.Replace((char)764, ' '); // ˼ 
            result = result.Replace((char)765, ' '); // ˽ 
            result = result.Replace((char)766, ' '); // ˾ 
            result = result.Replace((char)767, ' '); // ˿ 
            result = result.Replace((char)768, ' '); // ̀ 
            result = result.Replace((char)769, ' '); // ́ 
            result = result.Replace((char)770, ' '); // ̂ 
            result = result.Replace((char)771, ' '); // ̃ 
            result = result.Replace((char)772, ' '); // ̄ 
            result = result.Replace((char)773, ' '); // ̅ 
            result = result.Replace((char)774, ' '); // ̆ 
            result = result.Replace((char)775, ' '); // ̇ 
            result = result.Replace((char)776, ' '); // ̈ 
            result = result.Replace((char)777, ' '); // ̉ 
            result = result.Replace((char)778, ' '); // ̊ 
            result = result.Replace((char)779, ' '); // ̋ 
            result = result.Replace((char)780, ' '); // ̌ 
            result = result.Replace((char)781, ' '); // ̍ 
            result = result.Replace((char)782, ' '); // ̎ 
            result = result.Replace((char)783, ' '); // ̏ 
            result = result.Replace((char)784, ' '); // ̐ 
            result = result.Replace((char)785, ' '); // ̑ 
            result = result.Replace((char)786, ' '); // ̒ 
            result = result.Replace((char)787, ' '); // ̓ 
            result = result.Replace((char)788, ' '); // ̔ 
            result = result.Replace((char)789, ' '); // ̕ 
            result = result.Replace((char)790, ' '); // ̖ 
            result = result.Replace((char)791, ' '); // ̗ 
            result = result.Replace((char)792, ' '); // ̘ 
            result = result.Replace((char)793, ' '); // ̙ 
            result = result.Replace((char)794, ' '); // ̚ 
            result = result.Replace((char)795, ' '); // ̛ 
            result = result.Replace((char)796, ' '); // ̜ 
            result = result.Replace((char)797, ' '); // ̝ 
            result = result.Replace((char)798, ' '); // ̞ 
            result = result.Replace((char)799, ' '); // ̟ 
            result = result.Replace((char)800, ' '); // ̠ 
            result = result.Replace((char)801, ' '); // ̡ 
            result = result.Replace((char)802, ' '); // ̢ 
            result = result.Replace((char)803, ' '); // ̣ 
            result = result.Replace((char)804, ' '); // ̤ 
            result = result.Replace((char)805, ' '); // ̥ 
            result = result.Replace((char)806, ' '); // ̦ 
            result = result.Replace((char)807, ' '); // ̧ 
            result = result.Replace((char)808, ' '); // ̨ 
            result = result.Replace((char)809, ' '); // ̩ 
            result = result.Replace((char)810, ' '); // ̪ 
            result = result.Replace((char)811, ' '); // ̫ 
            result = result.Replace((char)812, ' '); // ̬ 
            result = result.Replace((char)813, ' '); // ̭ 
            result = result.Replace((char)814, ' '); // ̮ 
            result = result.Replace((char)815, ' '); // ̯ 
            result = result.Replace((char)816, ' '); // ̰ 
            result = result.Replace((char)817, ' '); // ̱ 
            result = result.Replace((char)818, ' '); // ̲ 
            result = result.Replace((char)819, ' '); // ̳ 
            result = result.Replace((char)820, ' '); // ̴ 
            result = result.Replace((char)821, ' '); // ̵ 
            result = result.Replace((char)822, ' '); // ̶ 
            result = result.Replace((char)823, ' '); // ̷ 
            result = result.Replace((char)824, ' '); // ̸ 
            result = result.Replace((char)825, ' '); // ̹ 
            result = result.Replace((char)826, ' '); // ̺ 
            result = result.Replace((char)827, ' '); // ̻ 
            result = result.Replace((char)828, ' '); // ̼ 
            result = result.Replace((char)829, ' '); // ̽ 
            result = result.Replace((char)830, ' '); // ̾ 
            result = result.Replace((char)831, ' '); // ̿ 
            result = result.Replace((char)832, ' '); // ̀ 
            result = result.Replace((char)833, ' '); // ́ 
            result = result.Replace((char)834, ' '); // ͂ 
            result = result.Replace((char)835, ' '); // ̓ 
            result = result.Replace((char)836, ' '); // ̈́ 
            result = result.Replace((char)837, ' '); // ͅ 
            result = result.Replace((char)838, ' '); // ͆ 
            result = result.Replace((char)839, ' '); // ͇ 
            result = result.Replace((char)840, ' '); // ͈ 
            result = result.Replace((char)841, ' '); // ͉ 
            result = result.Replace((char)842, ' '); // ͊ 
            result = result.Replace((char)843, ' '); // ͋ 
            result = result.Replace((char)844, ' '); // ͌ 
            result = result.Replace((char)845, ' '); // ͍ 
            result = result.Replace((char)846, ' '); // ͎ 
            result = result.Replace((char)847, ' '); // ͏ 
            result = result.Replace((char)848, ' '); // ͐ 
            result = result.Replace((char)849, ' '); // ͑ 
            result = result.Replace((char)850, ' '); // ͒ 
            result = result.Replace((char)851, ' '); // ͓ 
            result = result.Replace((char)852, ' '); // ͔ 
            result = result.Replace((char)853, ' '); // ͕ 
            result = result.Replace((char)854, ' '); // ͖ 
            result = result.Replace((char)855, ' '); // ͗ 
            result = result.Replace((char)856, ' '); // ͘ 
            result = result.Replace((char)857, ' '); // ͙ 
            result = result.Replace((char)858, ' '); // ͚ 
            result = result.Replace((char)859, ' '); // ͛ 
            result = result.Replace((char)860, ' '); // ͜ 
            result = result.Replace((char)861, ' '); // ͝ 
            result = result.Replace((char)862, ' '); // ͞ 
            result = result.Replace((char)863, ' '); // ͟ 
            result = result.Replace((char)864, ' '); // ͠ 
            result = result.Replace((char)865, ' '); // ͡ 
            result = result.Replace((char)866, ' '); // ͢ 
            result = result.Replace((char)867, ' '); // ͣ 
            result = result.Replace((char)868, ' '); // ͤ 
            result = result.Replace((char)869, ' '); // ͥ 
            result = result.Replace((char)870, ' '); // ͦ 
            result = result.Replace((char)871, ' '); // ͧ 
            result = result.Replace((char)872, ' '); // ͨ 
            result = result.Replace((char)873, ' '); // ͩ 
            result = result.Replace((char)874, ' '); // ͪ 
            result = result.Replace((char)875, ' '); // ͫ 
            result = result.Replace((char)876, ' '); // ͬ 
            result = result.Replace((char)877, ' '); // ͭ 
            result = result.Replace((char)878, ' '); // ͮ 
            result = result.Replace((char)879, ' '); // ͯ 
            //result = result.Replace((char)880, ' '); // Ͱ 
            //result = result.Replace((char)881, ' '); // ͱ 
            //result = result.Replace((char)882, ' '); // Ͳ 
            //result = result.Replace((char)883, ' '); // ͳ 
            result = result.Replace((char)884, ' '); // ʹ 
            result = result.Replace((char)885, ' '); // ͵ 
            //result = result.Replace((char)886, ' '); // Ͷ 
            //result = result.Replace((char)887, ' '); // ͷ 
            //result = result.Replace((char)888, ' '); // ͸ 
            //result = result.Replace((char)889, ' '); // ͹ 
            result = result.Replace((char)890, ' '); // ͺ 
            result = result.Replace((char)891, ' '); // ͻ 
            result = result.Replace((char)892, ' '); // ͼ 
            result = result.Replace((char)893, ' '); // ͽ 
            result = result.Replace((char)894, ' '); // ; 
            //result = result.Replace((char)895, ' '); // Ϳ 
            //result = result.Replace((char)896, ' '); // ΀ 
            //result = result.Replace((char)897, ' '); // ΁ 
            //result = result.Replace((char)898, ' '); // ΂ 
            //result = result.Replace((char)899, ' '); // ΃ 
            result = result.Replace((char)900, ' '); // ΄ 
            result = result.Replace((char)901, ' '); // ΅ 
            result = result.Replace((char)902, 'A'); // Ά 
            result = result.Replace((char)903, ' '); // · 
            result = result.Replace((char)904, 'E'); // Έ 
            result = result.Replace((char)905, 'H'); // Ή 
            result = result.Replace((char)906, 'I'); // Ί 
            //result = result.Replace((char)907, ' '); // ΋ 
            result = result.Replace((char)908, ' '); // Ό 
            //result = result.Replace((char)909, ' '); // ΍ 
            result = result.Replace((char)910, 'Y'); // Ύ 
            result = result.Replace((char)911, '.'); // Ώ 
            result = result.Replace((char)912, '.'); // ΐ 
            result = result.Replace((char)913, 'A'); // Α 
            result = result.Replace((char)914, 'B'); // Β 
            result = result.Replace((char)915, '.'); // Γ 
            result = result.Replace((char)916, '.'); // Δ 
            result = result.Replace((char)917, 'E'); // Ε 
            result = result.Replace((char)918, 'Z'); // Ζ 
            result = result.Replace((char)919, 'H'); // Η 
            result = result.Replace((char)920, 'O'); // Θ 
            result = result.Replace((char)921, 'I'); // Ι 
            result = result.Replace((char)922, 'k'); // Κ 
            result = result.Replace((char)923, 'A'); // Λ 
            result = result.Replace((char)924, 'M'); // Μ 
            result = result.Replace((char)925, 'N'); // Ν 
            result = result.Replace((char)926, '.'); // Ξ 
            result = result.Replace((char)927, 'O'); // Ο 
            result = result.Replace((char)928, '.'); // Π 
            result = result.Replace((char)929, 'P'); // Ρ 
            //result = result.Replace((char)930, ' '); // ΢ 
            result = result.Replace((char)931, '.'); // Σ 
            result = result.Replace((char)932, 'T'); // Τ 
            result = result.Replace((char)933, 'Y'); // Υ 
            result = result.Replace((char)934, '.'); // Φ 
            result = result.Replace((char)935, 'X'); // Χ 
            result = result.Replace((char)936, '.'); // Ψ 
            result = result.Replace((char)937, '.'); // Ω 
            result = result.Replace((char)938, 'I'); // Ϊ 
            result = result.Replace((char)939, 'Y'); // Ϋ 
            result = result.Replace((char)940, 'a'); // ά 
            result = result.Replace((char)941, '.'); // έ 
            result = result.Replace((char)942, 'n'); // ή 
            result = result.Replace((char)943, 'i'); // ί 
            result = result.Replace((char)944, 'u'); // ΰ 
            result = result.Replace((char)945, 'a'); // α 
            result = result.Replace((char)946, 'b'); // β 
            result = result.Replace((char)947, 'y'); // γ 
            result = result.Replace((char)948, '.'); // δ 
            result = result.Replace((char)949, '.'); // ε 
            result = result.Replace((char)950, '.'); // ζ 
            result = result.Replace((char)951, 'n'); // η 
            result = result.Replace((char)952, 'o'); // θ 
            result = result.Replace((char)953, 'l'); // ι 
            result = result.Replace((char)954, 'k'); // κ 
            result = result.Replace((char)955, '.'); // λ 
            result = result.Replace((char)956, 'm'); // μ 
            result = result.Replace((char)957, 'v'); // ν 
            result = result.Replace((char)958, '.'); // ξ 
            result = result.Replace((char)959, 'o'); // ο 
            result = result.Replace((char)960, 'p'); // π 
            result = result.Replace((char)961, 'p'); // ρ 
            result = result.Replace((char)962, 'c'); // ς 
            result = result.Replace((char)963, 'o'); // σ 
            result = result.Replace((char)964, '.'); // τ 
            result = result.Replace((char)965, 'u'); // υ 
            result = result.Replace((char)966, '.'); // φ 
            result = result.Replace((char)967, 'x'); // χ 
            result = result.Replace((char)968, '.'); // ψ 
            result = result.Replace((char)969, 'w'); // ω 
            result = result.Replace((char)970, 'i'); // ϊ 
            result = result.Replace((char)971, 'u'); // ϋ 
            result = result.Replace((char)972, 'o'); // ό 
            result = result.Replace((char)973, 'v'); // ύ 
            result = result.Replace((char)974, 'w'); // ώ 
            //result = result.Replace((char)975, ' '); // Ϗ 
            result = result.Replace((char)976, '.'); // ϐ 
            result = result.Replace((char)977, 'v'); // ϑ 
            result = result.Replace((char)978, 'y'); // ϒ 
            result = result.Replace((char)979, 'y'); // ϓ 
            result = result.Replace((char)980, 'y'); // ϔ 
            result = result.Replace((char)981, '.'); // ϕ 
            result = result.Replace((char)982, 'w'); // ϖ 
            result = result.Replace((char)983, 'n'); // ϗ 
            result = result.Replace((char)984, 'q'); // Ϙ 
            result = result.Replace((char)985, 'q'); // ϙ 
            result = result.Replace((char)986, 'c'); // Ϛ 
            result = result.Replace((char)987, 'c'); // ϛ 
            result = result.Replace((char)988, 'F'); // Ϝ 
            result = result.Replace((char)989, 'f'); // ϝ 
            //result = result.Replace((char)990, '.'); // Ϟ 
            //result = result.Replace((char)991, '.'); // ϟ 
            //result = result.Replace((char)992, ' '); // Ϡ 
            //result = result.Replace((char)993, ' '); // ϡ 
            //result = result.Replace((char)994, ' '); // Ϣ 
            //result = result.Replace((char)995, ' '); // ϣ 
            //result = result.Replace((char)996, ' '); // Ϥ 
            //result = result.Replace((char)997, ' '); // ϥ 
            //result = result.Replace((char)998, ' '); // Ϧ 
            //result = result.Replace((char)999, ' '); // ϧ 

            result = result.Replace((char)1019, 'm'); // ϻ 
            result = result.Replace((char)1024, 'E'); // Ѐ 
            result = result.Replace((char)1025, 'E'); // Ё 

            result = result.Replace((char)1031, 'I'); // Ї 

            result = result.Replace((char)1104, 'e'); // ѐ 
            result = result.Replace((char)1105, 'e'); // ё 
            result = result.Replace((char)1106, 'h'); // ђ 
            result = result.Replace((char)1108, 'c'); // є 

            result = result.Replace((char)1136, '.'); // Ѱ 
            result = result.Replace((char)1137, '.'); // ѱ 
            result = result.Replace((char)1138, 'O'); // Ѳ 
            result = result.Replace((char)1139, 'o'); // ѳ 
            result = result.Replace((char)1140, 'V'); // Ѵ 
            result = result.Replace((char)1141, 'v'); // ѵ 
            result = result.Replace((char)1142, 'V'); // Ѷ 
            result = result.Replace((char)1143, 'v'); // ѷ 

            result = result.Replace((char)1152, 'C'); // Ҁ 
            result = result.Replace((char)1153, 'c'); // ҁ 

            result = result.Replace((char)1194, 'C'); // Ҫ 
            result = result.Replace((char)1195, 'c'); // ҫ 
            result = result.Replace((char)1196, 'T'); // Ҭ 
            result = result.Replace((char)1197, 't'); // ҭ 
            result = result.Replace((char)1198, 'Y'); // Ү 
            result = result.Replace((char)1199, 'Y'); // ү 
            result = result.Replace((char)1200, 'Y'); // Ұ 
            result = result.Replace((char)1201, 'Y'); // ұ 
            result = result.Replace((char)1202, 'X'); // Ҳ 
            result = result.Replace((char)1203, 'x'); // ҳ 

            result = result.Replace((char)1232, 'A'); // Ӑ 
            result = result.Replace((char)1233, 'a'); // ӑ 
            result = result.Replace((char)1234, 'A'); // Ӓ 
            result = result.Replace((char)1235, 'a'); // ӓ 
            result = result.Replace((char)1236, 'A'); // Ӕ 
            result = result.Replace((char)1237, 'a'); // ӕ 
            result = result.Replace((char)1238, 'E'); // Ӗ 
            result = result.Replace((char)1239, 'e'); // ӗ 

            result = result.Replace((char)1254, 'O'); // Ӧ 
            result = result.Replace((char)1255, 'o'); // ӧ 
            result = result.Replace((char)1256, 'O'); // Ө 
            result = result.Replace((char)1257, 'o'); // ө 
            result = result.Replace((char)1258, 'O'); // Ӫ 
            result = result.Replace((char)1259, 'o'); // ӫ 
            result = result.Replace((char)1260, '.'); // Ӭ 
            result = result.Replace((char)1261, '.'); // ӭ 
            result = result.Replace((char)1262, 'y'); // Ӯ 
            result = result.Replace((char)1263, 'y'); // ӯ 
            result = result.Replace((char)1264, 'y'); // Ӱ 
            result = result.Replace((char)1265, 'y'); // ӱ 
            result = result.Replace((char)1266, 'y'); // Ӳ 
            result = result.Replace((char)1267, 'y'); // ӳ 

            result = result.Replace((char)1276, 'X'); // Ӽ 
            result = result.Replace((char)1277, 'x'); // ӽ 
            result = result.Replace((char)1278, 'X'); // Ӿ 
            result = result.Replace((char)1279, 'x'); // ӿ

            return result.Trim();
        }

        public static char GetNexLetter(char letter, int nextPozition)
        {
            char result = ' ';

            if (letter == 'z')
                result = 'a';
            else if (letter == 'Z')
                result = 'A';
            else
                result = (char)(((int)letter) + nextPozition);

            return result;
        }
        
        //public static DateTime ConvertStringDateToDateTime(string inputString)
        //{
        //    DateTime result = DateTime.MinValue;

        //    string[] datestring = inputString.Split('.');

        //    if (datestring.Length == 3)
        //    {
        //        int day, month, year = 0;
        //        int.TryParse(datestring[0], out day);
        //        int.TryParse(datestring[1], out month);
        //        int.TryParse(datestring[2], out year);

        //        result = new DateTime(year, month, day);
        //    }

        //    return result;
        //}

        public static string ConvertDataTableToString(DataTable sourceDataTable, string columnName)
        {
            string resultString = string.Empty;

            if (sourceDataTable != null && sourceDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < sourceDataTable.Rows.Count; i++)
                {
                    if (i > 0)
                    {
                        resultString += ", ";
                    }
                    resultString += "'" + sourceDataTable.Rows[i][columnName].ToString() + "'";
                }
            }
            else
            {
                resultString = string.Empty;
            }

            return resultString;
        }

        public static string ConvertDataTableToString(DataRow[] sourceRows, string columnName)
        {
            string resultString = string.Empty;

            if (sourceRows != null && sourceRows.Length > 0)
            {
                for (int i = 0; i < sourceRows.Length; i++)
                {
                    string val = sourceRows[i][columnName].ToString().Trim();
                    if (!string.IsNullOrEmpty(val))
                    {
                        if (i > 0 && !string.IsNullOrEmpty(resultString))
                        {
                            resultString += ",";
                        }

                        resultString += "'" + val + "'";
                    }
                }
            }            

            return resultString;
        }
        
        public static List<string> ConvertDataTableToList(DataTable mSelected, string columnName)
        {
            List<string> resultList = new List<string>();

            if (mSelected != null && mSelected.Rows.Count > 0)
            {
                for (int i = 0; i < mSelected.Rows.Count; i++)
                {
                    resultList.Add(mSelected.Rows[i][columnName].ToString());
                }
            }

            return resultList;
        }

        public static List<int> ConvertDataTableToIntList(DataTable mSelected, string columnName)
        {
            List<int> resultList = new List<int>();

            if (mSelected != null && mSelected.Rows.Count > 0 && mSelected.Columns.Contains(columnName))
            {
                for (int i = 0; i < mSelected.Rows.Count; i++)
                {
                    try
                    {
                        int value = 0;
                        int.TryParse(mSelected.Rows[i][columnName].ToString(), out value);

                        if (!resultList.Contains(value))
                            resultList.Add(value);
                    }
                    catch { }
                }
            }

            return resultList;
        }
        
        public static string ConvertListToString(List<string> list)
        {
            string resultString = string.Empty;

            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string val = list[i].Trim();
                    if (!string.IsNullOrEmpty(val))
                    {
                        if (i > 0 && !string.IsNullOrEmpty(resultString))
                        {
                            resultString += ",";
                        }

                        resultString += "'" + val + "'";
                    }
                }
            }
            
            return resultString;
        }

        public static string ConvertListToString(string[] stringAray)
        {
            string resultString = string.Empty;

            if (stringAray != null && stringAray.Length > 0)
            {
                for (int i = 0; i < stringAray.Length; i++)
                {
                    string val = stringAray[i].Trim();
                    if (!string.IsNullOrEmpty(val))
                    {
                        if (i > 0 && !string.IsNullOrEmpty(resultString))
                        {
                            resultString += ",";
                        }

                        resultString += "'" + val + "'";
                    }
                }
            }
            
            return resultString;
        }

        public static string ConvertListToString(List<int> list)
        {
            string resultString = string.Empty;

            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string val = list[i].ToString();
                    if (!string.IsNullOrEmpty(val))
                    {
                        if (i > 0 && !string.IsNullOrEmpty(resultString))
                        {
                            resultString += ",";
                        }

                        resultString += val;
                    }
                }
            }

            return resultString;
        }

        public static string ConvertListToString(List<long> mSelected)
        {
            string resultString = string.Empty;

            if (mSelected != null && mSelected.Count > 0)
            {
                for (int i = 0; i < mSelected.Count; i++)
                {
                    string val = mSelected[i].ToString();
                    if (!string.IsNullOrEmpty(val))
                    {
                        if (i > 0 && !string.IsNullOrEmpty(resultString))
                        {
                            resultString += ",";
                        }

                        resultString += "'" + val + "'";
                    }
                }
            }           

            return resultString;
        }

        public static string ConvertListToString(List<DateTime> source)
        {
            string resultString = string.Empty;

            if (source != null && source.Count > 0)
            {
                for (int i = 0; i < source.Count; i++)
                {
                    DateTime val = source[i];
                    if (val != DateTime.MinValue)
                    {
                        if (i > 0 && !string.IsNullOrEmpty(resultString))
                        {
                            resultString += ",";
                        }

                        resultString += "'" + val.ToString(Constants.Constants.ISODateTimeMillisec3DecimalsFormat) + "'";
                    }
                }
            }

            return resultString;
        }
                
        public static byte[] ReadFileAsStream(System.IO.Stream input)
        {
            byte[] buffer = new byte[input.Length];
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static DataTable AddTotalsToTable(DataTable sourceTable, string columnToInsertTotalWord, string totalWord, List<string> columnsForCalculateTotals)
        {
            if (sourceTable.Columns.Contains(columnToInsertTotalWord))
            {
                try
                {
                    double[] totalsList = new double[columnsForCalculateTotals.Count];

                    for (int i = 0; i < sourceTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < columnsForCalculateTotals.Count; j++)
                        {
                            if (sourceTable.Columns.Contains(columnsForCalculateTotals[j]))
                            {
                                double tempNumber = 0;
                                double.TryParse(sourceTable.Rows[i][columnsForCalculateTotals[j]].ToString(), out tempNumber);

                                double temTotal = totalsList[j] + tempNumber;
                                totalsList[j] = temTotal;
                            }
                        }
                    }

                    sourceTable.Rows.Add();
                    sourceTable.Rows.Add();

                    for (int j = 0; j < columnsForCalculateTotals.Count; j++)
                    {
                        sourceTable.Rows[sourceTable.Rows.Count - 1][columnsForCalculateTotals[j]] = totalsList[j];
                    }
                }
                catch { }
            }

            return sourceTable;
        }

        public static byte[] ToByteArray(Stream stream)
        {
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            for (int totalBytesCopied = 0; totalBytesCopied < stream.Length; )
                totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
            return buffer;
        }

        public static DataTable MakeNewTable(DataRow[] inputRows)
        {
            DataTable result = new DataTable();

            if (inputRows != null)
            {
                result = inputRows[0].Table.Clone();

                for (int i = 0; i < inputRows.Length; i++)
                {
                    DataRow originalRow = inputRows[i];
                    DataRow cloneRow = result.NewRow();
                    object[] itemArrayClone = new object[originalRow.ItemArray.Length];
                    originalRow.ItemArray.CopyTo(itemArrayClone, 0);
                    cloneRow.ItemArray = itemArrayClone;
                    result.Rows.Add(cloneRow);
                }
            }

            return result;
        }

        public static string ExportDataTableToFormatedExcel(DataTable dataTable)
        {
            string resultString = string.Empty;

            try
            {
                int colSpan = (dataTable.Columns.Count - 1);

                resultString += "<meta http-equiv=Content-Type content=text/html;charset=UTF-8> \r\n";
                resultString += "<TABLE WIDTH=\"100%\"> \r\n";

                #region Body
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    resultString += "\t<TR ALIGN=\"left\" VALIGN=\"top\" BGCOLOR=\"#D3D3D3\"> \r\n";
                    for (int c = 0; c < dataTable.Columns.Count; c++)
                    {
                        resultString += "\t\t<TD ><B>" // WIDTH=\"10%\"
                                     + dataTable.Columns[c].ColumnName + "</B></TD> \r\n";
                    }
                    resultString += "\t</TR> \r\n";

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        resultString += "\t<TR BGCOLOR=\"" + (i % 2 == 0 ? "White" : "#F0F0F0") + "\"> \r\n";
                        for (int c = 0; c < dataTable.Columns.Count; c++)
                        {
                            resultString += "\t\t<TD" //WIDTH=\"10%\"  
                                        + ">" + dataTable.Rows[i][c].ToString()
                                         + "</TD> \r\n";
                        }
                        resultString += "\t</TR> \r\n";
                    }
                }
                #endregion Body
                resultString += "</TABLE> \r\n";
            }
            catch (Exception exception)
            {
                throw (exception);
            }

            return resultString;
        }

        //public static void DataTableToExcel(DataTable dataTable, string reportName, string legalEntity, List<string> datePeriods, string releaseStatus)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.DefaultExt = "xls";
        //    saveFileDialog.Filter = "excel files (*.xls)|*.xls";
        //    saveFileDialog.AddExtension = true;
        //    saveFileDialog.RestoreDirectory = true;
        //    saveFileDialog.Title = "Where do you want to save the file?";
        //    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string fileName = saveFileDialog.FileName;

        //        if (mExportToExcelBackgroundWorker != null && mExportToExcelBackgroundWorker.IsBusy)
        //        {
        //            MessageBox.Show("Application is busy. Please wait", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            return;
        //        }

        //        waitWindow = new WaitWindow();
        //        waitWindow.Show();

        //        mExportToExcelBackgroundWorker = new BackgroundWorker();
        //        mExportToExcelBackgroundWorker.DoWork += ExportToExcelBackgroundWorker_DoWork;
        //        mExportToExcelBackgroundWorker.RunWorkerCompleted += ExportToExcelBackgroundWorker_Completed;
        //        object[] parameters = new object[] { dataTable, reportName, legalEntity, datePeriods, releaseStatus, fileName };
        //        mExportToExcelBackgroundWorker.RunWorkerAsync(parameters);
        //    }
        //}

        //private static void ExportToExcelBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    // Get parameters
        //    object[] parameters = e.Argument as object[];
        //    DataTable dataTable = parameters[0] as DataTable;
        //    string reportName = parameters[1] as String;
        //    string legalEntity = parameters[2] as String;
        //    List<string> datePeriods = parameters[3] as List<string>;
        //    string releaseStatus = parameters[4] as String;
        //    string fileName = parameters[5] as String;

        //    StreamWriter sw = null;
        //    try
        //    {
        //        int colSpan = (dataTable.Columns.Count - 1);

        //        string resultString = string.Empty;
        //        resultString += "<meta http-equiv=Content-Type content=text/html;charset=UTF-8> \r\n";
        //        resultString += "<TABLE WIDTH=\"100%\"> \r\n";
        //        #region Header
        //        resultString += "   <TR> \r\n";
        //        resultString += "       <TD WIDTH=\"10%\" ALIGN=\"left\" COLSPAN=\"" + colSpan + "\" BGCOLOR=\"White\"><FONT FACE='Verdana,Helvetica' SIZE='2.5' COLOR='#000000'><B>" + reportName + "</B></FONT></TD> \r\n";
        //        resultString += "   </TR> \r\n";
        //        resultString += "   <TR> \r\n";
        //        resultString += "       <TD WIDTH=\"10%\" ALIGN=\"left\" COLSPAN=\"" + colSpan + "\" BGCOLOR=\"White\"><FONT FACE='Verdana,Helvetica' SIZE='2.5' COLOR='#000000'>" + legalEntity + "</FONT></TD> \r\n";
        //        resultString += "   </TR> \r\n";
        //        resultString += "   <TR> \r\n";
        //        resultString += "       <TD WIDTH=\"25%\" ALIGN=\"left\" COLSPAN=\"" + colSpan + "\" BGCOLOR=\"White\"><FONT FACE='Verdana,Helvetica' SIZE='2.5' COLOR='#000000'>Executed date: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "</FONT></TD> \r\n";
        //        resultString += "   </TR> \r\n";

        //        string periods = String.Join(", ", datePeriods.ToArray());

        //        resultString += "   <TR> \r\n";
        //        resultString += "       <TD WIDTH=\"10%\" ALIGN=\"left\" COLSPAN=\"" + colSpan + "\" ><FONT SIZE='2.5'>Period: " + periods + "</FONT></TD> \r\n";
        //        resultString += "   </TR> \r\n";
        //        resultString += "   <TR> \r\n";
        //        if (!String.IsNullOrEmpty(releaseStatus))
        //        {
        //            resultString += "	<TD WIDTH=\"10%\" ALIGN=\"left\" COLSPAN=\"" + colSpan + "\" ><FONT SIZE='2.5'>Release Status: " + releaseStatus + "</FONT></TD> \r\n";
        //        }
        //        resultString += "   </TR> \r\n";

        //        resultString += "   <TR> \r\n";
        //        resultString += "       <TD WIDTH=\"10%\" ALIGN=\"left\" COLSPAN=\"7\"><FONT SIZE='2.5'></FONT></TD> \r\n";
        //        resultString += "   </TR> \r\n";
        //        #endregion Header

        //        #region Body
        //        if (dataTable != null && dataTable.Rows.Count > 0)
        //        {
        //            resultString += "\t<TR ALIGN=\"left\" VALIGN=\"top\" BGCOLOR=\"#AAAAAA\"> \r\n";
        //            foreach (DataColumn column in dataTable.Columns)
        //            {
        //                resultString += "\t\t<TD ><B>" // WIDTH=\"10%\"
        //                             + column.ColumnName + "</B></TD> \r\n";
        //            }
        //            resultString += "\t</TR> \r\n";

        //            for (int i = 0; i < dataTable.Rows.Count; i++)
        //            {
        //                resultString += "\t<TR BGCOLOR=\"" + (i % 2 == 0 ? "White" : "#DDDDDD") + "\"> \r\n";
        //                foreach (DataColumn column in dataTable.Columns)
        //                {
        //                    resultString += "\t\t<TD" //WIDTH=\"10%\"  
        //                                + ">" + dataTable.Rows[i][column.ColumnName].ToString()
        //                                 + "</TD> \r\n";
        //                }
        //                resultString += "\t</TR> \r\n";
        //            }
        //        }
        //        #endregion Body
        //        resultString += "</TABLE> \r\n";

        //        sw = new StreamWriter(fileName, false);
        //        sw.AutoFlush = true;
        //        sw.Write(resultString);
        //    }
        //    catch (Exception exception)
        //    {
        //        throw (exception);
        //    }
        //    finally
        //    {
        //        if (sw != null)
        //        {
        //            sw.Close();
        //        }
        //    }
        //    object[] result = new object[] { reportName, fileName };
        //    e.Result = result;
        //}

        //private static void ExportToExcelBackgroundWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    waitWindow.Close();
        //    if (e.Error != null)
        //    {
        //        MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    object[] result = e.Result as object[];
        //    if (result.Length > 1)
        //    {
        //        string reportName = result[0] as String;
        //        string fileName = result[1] as String;
        //        MessageBox.Show(reportName + " saved in " + fileName, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        string exception = result[0] as String;
        //        MessageBox.Show("Cannot save file. Error: " + exception, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //public static string CSVStringToExcel(string fileString, string reportName, string legalEntity, string lineSeparator, string columnSeparator)
        //{
        //    int colSpan = 0;
        //    string resultString = string.Empty;

        //    try
        //    {

        //        string[] Lines = fileString.Split(new string[] { lineSeparator }, StringSplitOptions.None);
        //        string[][] ArrayFromCSV = new string[Lines.Length][];

        //        if (ArrayFromCSV.Length > 0)
        //        {
        //            resultString += "<meta http-equiv=Content-Type content=text/html;charset=UTF-8> \r\n";
        //            resultString += "<TABLE WIDTH=\"100%\"> \r\n";

        //            #region Body

        //            for (int i = 0; i < Lines.Length; i++)
        //            {
        //                ArrayFromCSV[i] = Lines[i].Split(new string[] { columnSeparator }, StringSplitOptions.None);
        //                resultString += "\t<TR > \r\n";
        //                for (int j = 0; j < ArrayFromCSV[i].Length; j++)
        //                {
        //                    resultString += "\t\t<TD BGCOLOR=\"" + (i % 2 == 0 ? "White" : "#EFEFEF") + "\"> \r\n";
        //                    resultString += ArrayFromCSV[i][j].ToString()
        //                                 + "</TD> \r\n";
        //                }
        //                resultString += "\t</TR> \r\n";
        //            }

        //            #endregion Body
        //            resultString += "</TABLE> \r\n";
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        throw (exception);
        //    }
        //    return resultString;

        //}

        //public static string CSVStringToExcel(string fileString, string reportName, string legalEntity, string lineSeparator, string columnSeparator, string align)
        //{
        //    string resultString = string.Empty;

        //    try
        //    {

        //        string[] Lines = fileString.Split(new string[] { lineSeparator }, StringSplitOptions.None);
        //        string[][] ArrayFromCSV = new string[Lines.Length][];

        //        if (ArrayFromCSV.Length > 0)
        //        {
        //            resultString += "<meta http-equiv=Content-Type content=text/html;charset=UTF-8> \r\n";
        //            resultString += "<TABLE WIDTH=\"100%\"> \r\n";

        //            #region Body

        //            for (int i = 0; i < Lines.Length; i++)
        //            {
        //                ArrayFromCSV[i] = Lines[i].Split(new string[] { columnSeparator }, StringSplitOptions.None);
        //                resultString += "\t<TR > \r\n";
        //                for (int j = 0; j < ArrayFromCSV[i].Length; j++)
        //                {
        //                    resultString += "\t\t<TD align=\"" + align + "\" BGCOLOR=\"" + (i % 2 == 0 ? "White" : "#EFEFEF") + "\"> \r\n";
        //                    resultString += ArrayFromCSV[i][j].ToString()
        //                                 + "</TD> \r\n";
        //                }
        //                resultString += "\t</TR> \r\n";
        //            }

        //            #endregion Body
        //            resultString += "</TABLE> \r\n";
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        throw (exception);
        //    }
        //    return resultString;

        //}

        public static DataTable SortTable(DataTable dt, string colName, string direction)
        {
            DataTable dtOut = null;
            dt.DefaultView.Sort = colName + " " + direction;
            dtOut = dt.DefaultView.ToTable();
            return dtOut;
        }

    }
}
