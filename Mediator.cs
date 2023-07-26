/* Паттерн Посредник (Mediator) - это поведенческий паттерн проектирования, который позволяет уменьшить
связанность множества классов между собой, благодаря перемещению этих связей в один класс-посредник.*/

// Mediator: представляет интерфейс для взаимодействия с объектами Colleague.
abstract class Mediator
{
    public abstract void Send(string msg, Colleague colleague);
}

// Colleague: представляет интерфейс для взаимодействия с объектом Mediator. 
abstract class Colleague
{
    protected Mediator mediator;
 
    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }
}

// ConcreteColleague1 и ConcreteColleague2: конкретные классы коллег, которые обмениваются друг с другом через объект Mediator. 
class ConcreteColleague1 : Colleague
{
    public ConcreteColleague1(Mediator mediator)
        : base(mediator)
    { }
  
    public void Send(string message)
    {
        mediator.Send(message, this);
    }
  
    public void Notify(string message)
    { }
}
 
class ConcreteColleague2 : Colleague
{
    public ConcreteColleague2(Mediator mediator)
        : base(mediator)
    { }
  
    public void Send(string message)
    {
        mediator.Send(message, this);
    }
  
    public void Notify(string message)
    { }
}
 
 // ConcreteMediator: конкретный посредник, реализующий интерфейс типа Mediator.
class ConcreteMediator : Mediator
{
    public ConcreteColleague1 Colleague1 { get; set; }
    public ConcreteColleague2 Colleague2 { get; set; }
    public override void Send(string msg, Colleague colleague)
    {
        if (Colleague1 == colleague)
            Colleague2.Notify(msg);
        else
            Colleague1.Notify(msg);
    }
}