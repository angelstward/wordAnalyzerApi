using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WordAnalyzer.Domain.Models;

namespace WordAnalyzer.Domain.Services
{
    public class ProcessorTextService : IProcessorTextService
    {
        private const string pattern = "[az]";
        private const string patternInvalid = "[!||,||.||*||+||@||0-9]||#||$||%||&||'||¡||°||!||-||_]";
        public MessageModel<List<WordModel>> Process(TextModel text)
        {
            MessageModel<List<WordModel>> messageModel = new MessageModel<List<WordModel>>();
            List<WordModel> wordModels = new List<WordModel>();
            Regex rg = new Regex(pattern);
            text.Body = text.Body.ToLower();
            try
            {
                //MatchCollection matchedAttributes = rg.Matches(text.Body);
                string textoCompleto = Regex.Replace(text.Body, patternInvalid, "");
                Console.WriteLine(textoCompleto);
                string[] palabras = textoCompleto.Split(' ');
                string[] textDisctinc = string.Join(" ", textoCompleto.Split(' ').Distinct()).Split(' ');
                foreach (string item in textDisctinc)
                {
                    WordModel wordModel = new WordModel
                    {
                        Description = item,
                        //Count = (int)text.Body.LongCount(word => word.ToString() == item);
                        Count = CounterWords(item, palabras)
                    };
                    wordModels.Add(wordModel);
                };
                messageModel.Status = true;
                messageModel.Data = wordModels;
            }
            
            catch(Exception ex)
            {
                messageModel.Status = false;
                messageModel.Message = ex.Message;
            }
            return messageModel;
        }

        private int CounterWords(string item, string[] palabras)
        {
            int counter = 0;
            foreach(var element in palabras)
            {
                _ = element == item ? counter++ : counter;
            }
            return counter;            
        }
    }
}
