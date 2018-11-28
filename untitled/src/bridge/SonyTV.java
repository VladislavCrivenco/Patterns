package bridge;


public class SonyTV implements ITV {
    @Override
    public void on(){
        System.out.println("Sony is turned on");
    }

    @Override
    public void off(){
        System.out.printf("Sony is turned off");
    }

    @Override
    public void switchChannel(int channel){
        System.out.println("Sony : channel - " + channel);
    }
}
