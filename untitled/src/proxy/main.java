package proxy;


public class main {
    public static void main(String[] args) {

        //corect
        User user=new User("jora","cardan");
        FolderProxy folderProxy=new FolderProxy(user);
        System.out.println("User and pass correct");
        folderProxy.PerformOperations();
        System.out.println("______________________________________");
        // gresit
        User userWrong=new User("abc","abc");
        FolderProxy folderProxyWrong=new FolderProxy(userWrong);
        System.out.println("User and pass not correct");
        folderProxyWrong.PerformOperations();
    }
}
