/* Паттерн Посетитель (Visitor) - это поведенческий паттерн проектирования, который позволяет добавлять в программу новые операции,
не изменяя классы объектов, над которыми эти операции могут выполняться.*/

class Client
{
    void Main()
    {
        var structure = new ObjectStructure();
        structure.Add(new ElementA());
        structure.Add(new ElementB());
        structure.Accept(new ConcreteVisitor1());
        structure.Accept(new ConcreteVisitor2());
    }
}
 
 // Visitor: интерфейс посетителя, который определяет метод Visit() для каждого объекта Element.
abstract class Visitor
{
    public abstract void VisitElementA(ElementA elemA);
    public abstract void VisitElementB(ElementB elemB);
}

// ConcreteVisitor1 / ConcreteVisitor2: конкретные классы посетителей, реализуют интерфейс, определенный в Visitor. 
class ConcreteVisitor1 : Visitor
{
    public override void VisitElementA(ElementA elementA)
    {
        elementA.OperationA();
    }
    public override void VisitElementB(ElementB elementB)
    {
            elementB.OperationB();
    }
}
class ConcreteVisitor2 : Visitor
{
    public override void VisitElementA(ElementA elementA)
    {
        elementA.OperationA();
    }
    public override void VisitElementB(ElementB elementB)
    {
        elementB.OperationB();
    }
}

/* ObjectStructure: некоторая структура, которая хранит объекты Element и предоставляет к ним доступ.
Это могут быть и простые списки, и сложные составные структуры в виде деревьев.*/ 
class ObjectStructure
{
    List<Element> elements = new List<Element>();
    public void Add(Element element)
    {
        elements.Add(element);
    }
    public void Remove(Element element)
    {
        elements.Remove(element);
    }
    public void Accept(Visitor visitor)
    {
        foreach (Element element in elements)
            element.Accept(visitor);
    }
}

// Element: определяет метод Accept(), в котором в качестве параметра принимается объект Visitor. 
abstract class Element
{
    public abstract void Accept(Visitor visitor);
    public string SomeState { get; set; }
}

// ElementA / ElementB: конкретные элементы, которые реализуют метод Accept(). 
class ElementA : Element
{
    public override void Accept(Visitor visitor)
    {
        visitor.VisitElementA(this);
    }
    public void OperationA()
    { }
}
 
class ElementB : Element
{
    public override void Accept(Visitor visitor)
    {
        visitor.VisitElementB(this);
    }
    public void OperationB()
    { }
}