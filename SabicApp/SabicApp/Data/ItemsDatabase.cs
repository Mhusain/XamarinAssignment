using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SabicApp.Models;

namespace SabicApp.Data
{
    public class ItemsDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ItemsDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetItemsAsync()
        {
            //Get all items.
            var a = database.Table<Item>().ToListAsync();
            return a;
        }

        public Task<Item> GetItemAsync(int id)
        {
            // Get a specific item.
            return database.Table<Item>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            try
            {
                if (item.Id != 0)
                {
                    // Update an existing item.
                    return database.UpdateAsync(item);
                }
                else
                {
                    // Save a new item.
                    return database.InsertAsync(item);
                }

            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            // Delete a item.
            return database.DeleteAsync(item);
        }
    }
}

