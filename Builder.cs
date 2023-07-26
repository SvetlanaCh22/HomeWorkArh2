
/* Строитель (Builder) - это порождающий паттерн проектирования, который позволяет создавать сложные объекты пошагово.
Строитель даёт возможность использовать один и тот же код строительства для получения разных представлений объектов.*/
class Client
{
    void Main()
    {
        Builder builder = new ConcreteBuilder();
        Director director = new Director(builder);
        director.Construct();
        Product product = builder.GetResult();
    }
}

// Director: распорядитель - создает объект, используя объекты Builder
class Director
{
    Builder builder;
    public Director(Builder builder)
    {
        this.builder = builder;
    }
    public void Construct()
    {
        builder.BuildPartA();
        builder.BuildPartB();
        builder.BuildPartC();
    }
}
 
 // Builder: определяет интерфейс для создания различных частей объекта Product
abstract class Builder
{
    public abstract void BuildPartA();
    public abstract void BuildPartB();
    public abstract void BuildPartC();
    public abstract Product GetResult();
}
 
 /* Product: представляет объект, который должен быть создан.
  В данном случае все части объекта заключены в списке parts.*/
class Product
{
    List<object> parts = new List<object>();
    public void Add(string part)
    {
        parts.Add(part);
    }
}
 
 /*ConcreteBuilder: конкретная реализация Buildera. Создает объект Product
 и определяет интерфейс для доступа к нему.*/
class ConcreteBuilder : Builder
{
    Product product = new Product();
    public override void BuildPartA()
    {
        product.Add("Part A");
    }
    public override void BuildPartB()
    {
        product.Add("Part B");
    }
    public override void BuildPartC()
    {
        product.Add("Part C");
    }
    public override Product GetResult()
    {
        return product;
    }
}