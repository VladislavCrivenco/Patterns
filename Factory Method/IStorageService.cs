using System.Collections.Generic;
public interface IStorageService
{
    List<string> GetFiles();
    string GetFileSize(string filePath);

    string GetLastModifiedDate(string filePath);
}