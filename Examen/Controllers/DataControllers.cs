using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Examen.Models;
using System.Threading.Tasks;

namespace Examen.Controllers
{
    public class DataControllers
    {
        readonly SQLiteAsyncConnection connection;

        public DataControllers(String dbpath)
        {
            
            connection = new SQLiteAsyncConnection(dbpath);

         
            connection.CreateTableAsync<Data>().Wait();
        }
        public Task<int> Savedata(Data data)
        {
            if (data.id != 0)
                return connection.UpdateAsync(data);
            else
                return connection.InsertAsync(data);
        }

 
        public Task<List<Data>> GetListdata()
        {
            return connection.Table<Data>().ToListAsync();
        }

        public Task<Data> Getdata(int pid)
        {
            return connection.Table<Data>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }


        public Task<int> Deletedata(Data data)
        {
            return connection.DeleteAsync(data);
        }
    }
}
