using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WordAnalyzer.Domain.Models;

namespace WordAnalyzer.Domain.Services
{
    public class ProcessorTextService : IProcessorTextService
    {
        private const string patternInvalid = "[!||,||.||*||+||@||0-9]||#||$||%||&||'||¡||°||!||-||_]";
        public MessageModel<List<WordModel>> Process(TextModel text)
        {
            MessageModel<List<WordModel>> messageModel = new MessageModel<List<WordModel>>();
            List<WordModel> wordModels = new List<WordModel>();
            text.Body = text.Body.ToLower();
            try
            {
                string textoCompleto = Regex.Replace(text.Body, patternInvalid, "");
                Console.WriteLine(textoCompleto);
                string[] palabras = textoCompleto.Split(' ');
                string[] textDisctinc = string.Join(" ", textoCompleto.Split(' ').Distinct()).Split(' ');
                foreach (string item in textDisctinc)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        WordModel wordModel = new WordModel
                        {
                            Description = item,
                            Count = CounterWords(item, palabras)
                        };
                        wordModels.Add(wordModel);
                    }
                }
                messageModel.Status = true;
                messageModel.Data = wordModels;
            }

            catch (Exception ex)
            {
                messageModel.Status = false;
                messageModel.Message = ex.Message;
            }
            return messageModel;
        }

        public int CounterWords(string item, string[] palabras)
        {
            int counter = 0;
            foreach (string element in palabras)
            {
                _ = element == item ? counter++ : counter;
            }
            return counter;
        }
    }
}
