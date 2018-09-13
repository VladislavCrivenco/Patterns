using System.Collections.Generic;
using System.IO;
using System.Linq;
public class LocalResourceManager: ResourceManager{

private DirectoryInfo HomeDirectory;

public LocalResourceManager(string homeDirectory){
    HomeDirectory = new DirectoryInfo(homeDirectory);
}

public List<string> GetFiles(){
    return HomeDirectory.EnumerateFiles().Select((x) => x.FullName).ToList();
}
}