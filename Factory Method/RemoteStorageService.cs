using System.Collections.Generic;
using System.IO;
using System.Linq;

public class RemoteStorageService : IStorageService
{
    private DirectoryInfo homeDirectoryInfo;
    public RemoteStorageService(string username, string password){
        homeDirectoryInfo = new DirectoryInfo(@"E:\UTM\BDC");
    }

    public List<string> GetFiles(){
        return homeDirectoryInfo.EnumerateFiles("*", SearchOption.AllDirectories).Select((x) => x.FullName).ToList();
    }

    public string GetFileSize(string filePath){
        return new FileInfo(filePath).Length.ToString();
    }

    public string GetLastModifiedDate(string filePath){
        return new FileInfo(filePath).LastWriteTimeUtc.ToString();
    }
}

