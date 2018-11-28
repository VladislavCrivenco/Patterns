public class Main {

    public static void main(String[] args) {
        Composite composite = new Composite();
        composite.addComponent(Circle.createShape("rosu"));
        composite.addComponent(Square.createShape("albastru"));


        Composite composite1 = new Composite();
        composite1.addComponent(composite);
        composite1.addComponent(Triangle.createShape("verde"));

        composite1.draw();
    }
}
