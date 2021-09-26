using System.Collections.Generic;
using System.Threading.Tasks;
using WordAnalyzer.Domain.Models;

namespace WordAnalyzer.Domain.Services
{
    public interface IProcessorTextService
    {
        MessageModel<List<WordModel>> Process(TextModel text);
    }
}
