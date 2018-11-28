package bridge;


public class LogitechRemoteControl extends AbstractRemoteControl{

    public LogitechRemoteControl(ITV tv){
        super(tv);
    }

    public void setChannelKeyboard(int channel){
        setChannel(channel);
        System.out.printf("Logitech use keyword to set channel");
    }
}
