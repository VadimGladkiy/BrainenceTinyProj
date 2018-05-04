using Brainence2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Brainence2.Repositories
{
    public class SentencesRepository : IRepository<Entity>
    {
        private SentencesContext dataCtx;
        private List<Entity> listToReturnToView;
        public SentencesRepository()
        {
            dataCtx = new Models.SentencesContext();
            listToReturnToView = new List<Entity>();
        }
        public void ParseSentences(String[] sentences, String seekingWord )
        {
            Char firstch = seekingWord.ToUpper().ToCharArray()[0];
            StringBuilder sb = new StringBuilder(seekingWord);
            sb[0] = firstch;
            String seekingWord2 = sb.ToString();

            Entity toDbCandidate = new Entity();
            toDbCandidate.Word = seekingWord;
            foreach (String oneSentence in sentences)
            {
                var words = oneSentence.Split(' ');
                if (words.Contains(seekingWord2))
                {
                    for (var i =0; i< words.Length; i++ )
                    {
                        if (words[i] == seekingWord2) words[i] = seekingWord;
                    }
                } 
                if (words.Contains(seekingWord))
                {
                    toDbCandidate.Sentence = Reverse(oneSentence);
                    toDbCandidate.Counter = words
                            .Where(w => w == seekingWord)
                            .Count();

                    SaveSentence(toDbCandidate);
                }
            }
        }
        private void SaveSentence(Entity entity)
        {
            dataCtx.Entities.Add(entity);
            dataCtx.SaveChanges();
        }
        public async Task SaveSentenceAsync(Entity entity)
        {
            throw new NotImplementedException();
        }
        private String Reverse(String input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public IEnumerable<Entity> GetSentences()
        {
            return dataCtx.Entities.ToList();
        }
    }
}