using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoClass;

namespace OpinionsList
{
    public class ObjectTargetList
    {
        string username;
        string title;
        string rate;
        string description;
        int countOpinions;
        public ObjectTargetList(string username, string title, string rate, string description, int countOpinions)
        {
            this.username=username;
            this.title=title;
            this.rate=rate;
            this.description=description;
            this.countOpinions = countOpinions;
        }
    }
    public class TargetList
    {
        public List<ObjectTargetList> ReturnTargetList(List<OpinionsObject> opinionList, List<BooksObject> listBook)
        {
            List<ObjectTargetList> list = new List<ObjectTargetList>();
            for (int i = 0; i < opinionList.Count ; i++)
            {
                for (int j = 0;j < opinionList[i].opinions.Count; j++)
                {

                    list.Add(new ObjectTargetList(opinionList[i].username, searchTitle(opinionList[i].opinions[j].book_id, listBook), opinionList[i].opinions[j].rate, opinionList[i].opinions[j].description, opinionList[i].opinions.Count));
                }
              
            }

            return list;
        }
        public string searchTitle(string idTitle, List<BooksObject> listBook)
        {
            int idTitleInt = Convert.ToInt32(idTitle);
            for (int i = 0; i < listBook.Count; i++)
            {
                if (listBook[i].id==idTitleInt)
                {
                    return listBook[i].title;
                }
            }
            throw new Exception("Nie znaleziono książki o id:" + idTitle);
        }
    }
}
