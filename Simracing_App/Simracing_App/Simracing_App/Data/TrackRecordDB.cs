using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Simracing_App.Models;
using System.Collections;
using System.Threading.Tasks;

namespace Simracing_App.Data
{
    class TrackRecordDB
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<TrackRecordDB> Instance = new AsyncLazy<TrackRecordDB>(async () =>
        {
            var instance = new TrackRecordDB();
            CreateTableResult result = await Database.CreateTableAsync<TrackRecord>();
            return instance;
        });
        public TrackRecordDB()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
        public Task<List<TrackRecord>> GetItemsAsync()
        {
            return Database.Table<TrackRecord>().ToListAsync();
        }

        public Task<List<TrackRecord>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<TrackRecord>("SELECT * FROM [TrackRecord] WHERE [Done] = 0");
        }

        public Task<TrackRecord> GetItemAsync(int id)
        {
            return Database.Table<TrackRecord>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TrackRecord item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(TrackRecord item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
