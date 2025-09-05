using InvestSupTool.DB;
using InvestSupTool.Util;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;


#nullable enable
namespace InvestSupTool.StockAPI
{
    internal class StockInfo
    {
        public static void ImportKospiCodeToLiteDB(string baseDir)
        {
            string path = Path.Combine(baseDir, "kospi_code.mst");
            string connectionString = Path.Combine(baseDir, "InvestSupTool.db");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding(949);
            if (!File.Exists(path))
            {
                LogUtil.Error("KOSPI 마스터 파일을 찾을 수 없습니다. 경로: " + path);
            }
            else
            {
                List<Stock> entities = new List<Stock>();
                LogUtil.Debug("KOSPI 마스터 파일 읽기를 시작합니다==========");
                foreach (string readAllLine in File.ReadAllLines(path, encoding))
                {
                    try
                    {
                        int length = readAllLine.Length - 228;
                        if (length >= 21)
                        {
                            string str1 = readAllLine.Substring(0, length);
                            string str2 = str1.Substring(0, 9).TrimEnd();
                            string str3 = str1.Substring(21).Trim();
                            if (!string.IsNullOrEmpty(str2) && !string.IsNullOrEmpty(str3))
                                entities.Add(new Stock()
                                {
                                    StockCode = str2,
                                    StockName = str3
                                });
                        }
                    }
                    catch (Exception ex)
                    {
                        LogUtil.Error("라인 파싱 중 오류 발생", ex);
                    }
                }
                using (LiteDatabase liteDatabase = new LiteDatabase(connectionString))
                {
                    ILiteCollection<Stock> collection = liteDatabase.GetCollection<Stock>("stocks", BsonAutoId.ObjectId);
                    collection.Upsert((IEnumerable<Stock>)entities);
                    collection.EnsureIndex<string>((Expression<Func<Stock, string>>)(x => x.StockName));
                }
            }
        }
    }
}