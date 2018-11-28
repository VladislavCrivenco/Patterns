import java.util.HashMap;
import java.util.Map;

public class Square implements Shape {
    private static Map<String, Shape> shapeCache = new HashMap<>();
    private String color;

    public static Shape createShape(String color) {
        return shapeCache.computeIfAbsent(color, newColor -> new Square(color));
    }

    private Square(String color){
        this.color = color;
    }

    public  void draw(){
        System.out.println("Acesta este un Patrat " + color);
    }
}
