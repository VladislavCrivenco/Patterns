using System.Collections.Generic;
public abstract class ResourceManager{
    public List<string> GetFiles(){
        return GetStorageService().GetFiles();
    }
    public abstract IStorageService GetStorageService();
}