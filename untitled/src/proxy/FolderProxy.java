package proxy;


public class FolderProxy implements IFolder {

    Folder folder;
    User user;

    public FolderProxy(User user) {
        this.user = user;
    }

    public void PerformOperations() {

        if(user.getUserName().equalsIgnoreCase("jora") && user.getPassword().equalsIgnoreCase("cardan"))
        {
            folder=new Folder();
            folder.PerformOperations();
        }
        else
        {
            System.out.println("NO ACCESS!!!");
        }
    }
}
