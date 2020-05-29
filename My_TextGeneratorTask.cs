using System.Collections.Generic;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string Splitting(string text, int i)
        {
            return text.Split()[text.Split().Length - i];
        }

        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            string phrase = phraseBeginning;
            string additionalPhrase = null;
            for (int i = 0; i < wordsCount; i++)
            {
                if (nextWords.ContainsKey(phraseBeginning)) additionalPhrase = nextWords[phraseBeginning];
                else if (phraseBeginning.Split().Length > 1)
                {
                    if (nextWords.ContainsKey(Splitting(phraseBeginning, 2) + " " + Splitting(phraseBeginning, 1))) additionalPhrase = nextWords[Splitting(phraseBeginning, 2) + " " + Splitting(phraseBeginning, 1)];
                    else if (nextWords.ContainsKey(Splitting(phraseBeginning, 1))) additionalPhrase = nextWords[Splitting(phraseBeginning, 1)];
                    else break;
                }
                else break;
                if (phraseBeginning.Split().Length > 1)
                    phraseBeginning = phraseBeginning.Split()[phraseBeginning.Split().Length - 1] + " " + additionalPhrase;
                else phraseBeginning = phraseBeginning + " " + additionalPhrase;
                phrase += (" " + additionalPhrase);
            }
            return phrase;
        }
    }
}