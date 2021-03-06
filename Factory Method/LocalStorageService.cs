using System.Collections.Generic;
using System.IO;
using System.Linq;

public class LocalStorageService : IStorageService
{
    private DirectoryInfo homeDirectoryInfo;
    public LocalStorageService(DirectoryInfo homeDirectory){
        homeDirectoryInfo = homeDirectory;
    }

    public List<string> GetFiles(){
        return homeDirectoryInfo.EnumerateFiles().Select((x) => x.FullName).ToList();
    }

    public string GetFileSize(string filePath){
        return new FileInfo(filePath).Length.ToString();
    }

    public string GetLastModifiedDate(string filePath){
        return new FileInfo(filePath).LastWriteTimeUtc.ToString();
    }
}

