using AdvancedSiebelLogScanner.Properties;
using LiteDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedSiebelLogScanner
{
    class UpdateDatabase
    {
        public static void updateLiteDb(string code, string desc, string resolve)
        {
            var fmtcode = code.Substring(checked(code.IndexOf("SBL")), 13).Trim();
            var fmtdesc = desc.Substring(1, desc.Length-2).Trim();
            using (var dbase = new LiteDatabase("ErrorMsg.db"))
                try
                {                    
                    var ErrO = dbase.GetCollection<ErrorMsg>("ErrorMsg");
                    var recrd = dbase.GetCollection("ErrorMsg").Find(Query.Contains("_id", fmtcode), limit: 1);
                    if (recrd.Count() < 1)
                    {
                        var docs = new BsonDocument
                        {
                            ["_id"] = fmtcode,
                            ["Desc"] = fmtdesc,
                            ["Solution"] = resolve
                        };
                        dbase.GetCollection("ErrorMsg").Insert(docs);
                    }
                    else
                    {
                        var docs = new BsonDocument
                        {
                            ["_id"] = fmtcode,
                            ["Desc"] = fmtdesc,
                            ["Solution"] = resolve
                        };
                        dbase.GetCollection("ErrorMsg").Update(docs);
                    }
                    ErrO.EnsureIndex("_id");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

        }
        public static async Task updateMongoDbAsync(string code , string resolve)
        {
            try
            {
                var Mcode = code.Substring(checked(code.IndexOf("SBL")), 13).Trim();
                var path = Settings.Default.Path.ToString();
                var usr = Settings.Default.User.ToString();
                string connstring = "mongodb://" +usr+":"+usr+"@"+path;
                MongoClient client = new MongoClient(connstring);
                IMongoDatabase datb = client.GetDatabase("SiebErrorMsg");
                var collc = datb.GetCollection<MongoDB.Bson.BsonDocument>("ErrorMsg");
                var result = await collc.UpdateOneAsync(
                   Builders<MongoDB.Bson.BsonDocument>.Filter.Eq("Code", Mcode),
                   Builders<MongoDB.Bson.BsonDocument>.Update.Set("Resolution", resolve),
                   new UpdateOptions { IsUpsert = true }
                   );
            }
            catch (MongoException mEx)
            {
                MessageBox.Show(mEx.ToString());
            }
        }

    }
}
