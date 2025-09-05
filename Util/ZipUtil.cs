using System;
using System.IO.Compression;


#nullable enable
namespace InvestSupTool.Util
{
    internal class ZipUtil
    {
        public void ZipUnPack(string filePath, string baseDir, bool isWrite)
        {
            try
            {
                ZipFile.ExtractToDirectory(filePath, baseDir, true);
            }
            catch (Exception ex)
            {
                LogUtil.Error("압축 해제 중에 에러가 발생했습니다.", ex);
            }
        }
    }
}