import java.awt.*;
import java.util.HashMap;
import java.util.Map;

public class Circle implements  Shape {

    private static Map<String, Shape> shapeCache = new HashMap<>();
    private String color;

    public static Shape createShape(String color) {
        return shapeCache.computeIfAbsent(color, newColor -> new Circle(color));
    }

    private Circle(String color){
        this.color = color;
    }

    public  void draw(){
        System.out.println("Acesta este un Cerc " +  color);
    }
}
