using System.Collections.Generic;
using System.Linq;
using System;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();

            List<string> sentences = text.Split(".:;?!()".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach(string sents in sentences)
            {
                List<string> words = new List<string>();
                string word = "";
                foreach (char chr in sents)
                {
                    if (char.IsLetter(chr) || chr == '\'')
                        word += chr.ToString().ToLowerInvariant;
                    else if (word.Length > 0)
                    {
                        words.Add(word);
                        word = "";
                    }
                }
                if (word.Length > 0)
                    words.Add(word);
                if (words.Count > 0)
                    sentencesList.Add(words);
            } 
            
            return sentencesList;
            
        }
    }
}