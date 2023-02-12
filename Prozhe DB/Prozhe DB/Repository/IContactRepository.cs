using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Prozhe_DB
{
    interface IContactRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int contactid);
        bool insert(string name, string family, string  mobile, string email);
        bool Update(int contactid,string name, string family,  string mobile, string email);
        bool Delete(int contactid);
        DataTable search(string parameter);
    }
}
