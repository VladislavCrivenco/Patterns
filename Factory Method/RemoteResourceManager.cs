using System.Collections.Generic;
using System.IO;
using System.Linq;
public class RemoteResourceManager : ResourceManager
{
    private string username;
    private string password;

    public RemoteResourceManager(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public override IStorageService GetStorageService()
    {
        return new RemoteStorageService(username, password);
    }
}