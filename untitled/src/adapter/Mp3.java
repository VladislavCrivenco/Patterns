package adapter;


public class Mp3 implements MediaPlayer {
    @Override
    public void play() {
        System.out.println("Playing Mp3 File");
    }
}
