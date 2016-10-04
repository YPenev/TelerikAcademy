namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        /// <summary>
        /// Convert input string to hexadecimal string
        /// </summary>
        /// <param input string ="input"></param>
        /// <returns>Converted hexadecimal string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Convert string parameter to boolean type
        /// </summary>
        /// <param Input string ="input"></param>
        /// <returns>true or false</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        public static short ToShort(this string input)
        {
            short shortValue;

            // Try to convert input to short
            short.TryParse(input, out shortValue);

            // Return converted value
            // If convertion is unsuccessful return short default value
            return shortValue;
        }

        /// <summary>
        /// Convert input string to integer
        /// </summary>
        /// <param input string ="input"></param>
        /// <returns>
        /// If successful return converted value
        /// Else return int default value
        /// </returns>
        public static int ToInteger(this string input)
        {
            int integerValue;

            // Try to convert input to integer
            int.TryParse(input, out integerValue);

            // Return converted value
            // If convertion is unsuccessful int default value
            return integerValue;
        }


        /// <summary>
        /// Convert input string to Long
        /// </summary>
        /// <param input string ="input"></param>
        /// <returns>
        /// If successful return converted value
        /// Else return Long default value
        /// </returns>
        public static long ToLong(this string input)
        {
            long longValue;

            // Try to convert input to long
            long.TryParse(input, out longValue);

            // Return converted value
            // If convertion is unsuccessful return long default value
            return longValue;
        }


        /// <summary>
        /// Convert input string to DateTime
        /// </summary>
        /// <param input string ="input"></param>
        /// <returns>
        /// If successful return converted value
        /// Else return DateTime default value
        /// </returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;

            // Try to convert input to DateTime 
            DateTime.TryParse(input, out dateTimeValue);

            // Return converted value
            // If convertion is unsuccessful return DateTime default value
            return dateTimeValue;
        }

        /// <summary>
        /// Convert first letter of given text to upper
        /// </summary>
        /// <param input string ="input"></param>
        /// <returns>Text with upper first letter</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Return input value with upper first letter
            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Take text between given start and end strings
        /// </summary>
        /// <param input string="input"></param>
        /// <param string from witch to start="startString"></param>
        /// <param string from witch to end="endString"></param>
        /// <param index from witch to start="startFrom"></param>
        /// <returns>
        /// The content between given strings
        /// or emty string if strings is not found
        /// </returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            // Trim everything before start index 
            input = input.Substring(startFrom);
            startFrom = 0;

            // Validate input
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            // Set start position to position of first match with start string
            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                // If did not find a match return empty string
                return string.Empty;
            }

            // Set start position to position of first match with end string
            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                // If did not find a match return empty string
                return string.Empty;
            }

            // Return everything between start position and end position
            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Convert cyrillic text to latin
        /// </summary>
        /// <param input string="input"></param>
        /// <returns>Converted text</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                // Replace every lower cyrillic letter with its latin representation
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                
                // Replace every upper cyrillic letter with its latin representation
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }


        /// <summary>
        /// Convert latin text to cyrillic
        /// </summary>
        /// <param input string="input"></param>
        /// <returns>Converted text</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                // Replace every lower latin letter with its cyrillic representation
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);

                // Replace every upper latin letter with its cyrillic representation
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Validate user name
        /// </summary>
        /// <param user name ="input"></param>
        /// <returns>Correct user name, without not allowed simbols</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();

            // Remove all not allowed simbols from username
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }


        /// <summary>
        /// Validate file name
        /// </summary>
        /// <param file name ="input"></param>
        /// <returns>Correct file name, without not allowed simbols</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();

            // Remove all not allowed simbols from file name
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Get begining part (with exactly size) of the string
        /// </summary>
        /// <param input string="input"></param>
        /// <param begining part size ="charsCount"></param>
        /// <returns>Trimmed begining part with fixed size</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            // Return trimmed string from beggining to input index or end of the string
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Retrieves the file exention of a given file name
        /// </summary>
        /// <param name of file ="fileName"></param>
        /// <returns>File extention</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);

            // Validate that there is extention after last dot
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            // Return text after last dot
            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Retrieves content type from a given exension
        /// </summary>
        /// <param extension="fileExtension"></param>
        /// <returns>Content type</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };

           // If extention is recognised return its content type
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Convert given string to array of bytes
        /// </summary>
        /// <param input string="input"></param>
        /// <returns>Array of bytes</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];

            // Copy all of the bytes and return then as array of bytes
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
