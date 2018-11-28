import java.util.HashMap;
import java.util.Map;

public class Triangle implements  Shape {
    private static Map<String, Shape> shapeCache = new HashMap<>();
    private String color;

    public static Shape createShape(String color) {
        return shapeCache.computeIfAbsent(color, newColor -> new Triangle(color));
    }

    private Triangle(String color){
        this.color = color;
    }


    public  void draw(){
        System.out.println("Acesta este un Triunghi " + color);
    }
}
