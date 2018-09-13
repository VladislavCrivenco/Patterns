using System.Collections.Generic;
public abstract class ResourceManager{
    public List<string> GetFiles(){
        return GetStorageService().GetFiles();
    }

    public string GetFileSize(string filePath){
        return GetStorageService().GetFileSize(filePath);
    }

    public string GetLastModifiedDate(string filePath){
        return GetStorageService().GetLastModifiedDate(filePath);
    }

    public abstract IStorageService GetStorageService();
}