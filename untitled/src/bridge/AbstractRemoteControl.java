package bridge;


public class AbstractRemoteControl {
    private ITV tv;

    public AbstractRemoteControl(ITV tv){
        this.tv = tv;
    }

    public void setChannel(int channel){
        tv.switchChannel(channel);
    }
}
