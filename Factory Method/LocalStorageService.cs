using System.Collections.Generic;
public interface LocalStorageService : IStorageService
{
    List<string> GetFiles(){
    return HomeDirectory.EnumerateFiles().Select((x) => x.FullName).ToList();
}
}

