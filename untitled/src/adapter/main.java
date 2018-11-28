package adapter;


public class main {

    public static void main(String[] args) {
        //playing mp3 file
        MediaPlayer player = new Mp3();
        player.play();


        player = new FormatAdapter(new Mp4());
        player.play();
    }
}
