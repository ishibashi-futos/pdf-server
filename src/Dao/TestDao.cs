using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace pdf_server.Dao
{
    // TODO: リポジトリクラスをちゃんと作る
    public class TestRepository : IRepository
    {
        public TestRepository()
        {

        }

        public string findById(string id)
        {
            return @"D:\mvcapp\assets\README.pdf";
        }
    }
    public interface IRepository
    {
        // 文字列じゃなくてmodelを返すようにする
        string findById(string id);
    }

}
