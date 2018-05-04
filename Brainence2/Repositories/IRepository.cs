using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainence2.Repositories
{
    public interface IRepository<T> where T:class
    {
        void ParseSentences(String[] sentences, String seekingWord);
        Task SaveSentenceAsync(T entity);
        IEnumerable<T> GetSentences();
    }
}
