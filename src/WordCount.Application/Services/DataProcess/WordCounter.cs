using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WordCount.Application.Services.DataProcess
{
    internal class WordCounter : IWordCounter
    {
        
        public IDictionary<string, int> CountWords(Stream stream)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            if (stream == null) 
                return new Dictionary<string, int>();
            int start = 0; //, end = Math.Min(bufferSize, (int)stream.Length);

            int bufferSize = 150;

            byte[] buffer = new byte[bufferSize];
            ///read stream in chunks
            string reminder = "";
            int reminderOffset = 0;
            while (stream.Read(buffer,start, bufferSize) > 0)
            {
                reminderOffset  = reminder.Length;
                string s = Encoding.UTF8.GetString(buffer);
                s = reminder + s;
                //all string inside buffer
                if (stream.Length <= bufferSize)
                {
                    s = s.Substring(0, (int)stream.Length);
                    CountSubStringWords(s, result);
                    break;
                }

                reminder = s;

                //the string is bigger then buffer then we need to keep the reminder for next iteration
                int i = 0;

                if (buffer[buffer.Length - 1] == 0)
                {
                    //the buffer contains empty data, thus all data inside string
                    for (int j = 0; j < buffer.Length - 1; j++)
                    {
                        if (s[j] == 0)
                        {
                            s = s.Substring(0, j);
                            break;
                        }
                    }
                }
                else
                {
                    
                    //find last space
                    while (!s.EndsWith(" ") && !s.EndsWith("\r\n"))
                    {
                        i++;
                        s = s.Substring(0, reminderOffset+ buffer.Length - i);
                    }
                    reminder = reminder.Substring(reminderOffset + buffer.Length - i, i).Trim();
                    buffer = new byte[bufferSize];
                }
                CountSubStringWords(s, result);
            }


            return result;
        }

        private void CountSubStringWords(string s, Dictionary<string, int> result)
        {
            string[] words = s.Split(new string[] { " ","\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            for (var i=0; i<words.Length; i++)
            {
                words[i] = RemoveExtraCharcters(words[i]);
                var key = words[i].ToLower();
                if (result.ContainsKey(key))
                    //increment count
                    result[key] = result[key] + 1;
                else
                    result[key] = 1;
            }
        }

        private string RemoveExtraCharcters(string word)
        {
            Regex pExtraChars = new Regex(@"[\?,\.()!-\*]", RegexOptions.Compiled);
            word = pExtraChars.Replace(word, "");
            return word;
        }
    }
}
