/* Паттерн "Команда" (Command) это поведенческий паттерн проектирования, который превращает запросы в объекты,
позволяя передавать их как аргументы при вызове методов, ставить запросы в очередь, логировать их,
а также поддерживать отмену операций. */

/* Command: интерфейс, представляющий команду. Обычно определяет метод Execute() для выполнения действия,
а также нередко включает метод Undo(), реализация которого должна заключаться в отмене действия команды.*/
abstract class Command
{
    public abstract void Execute();
    public abstract void Undo();
}
/* ConcreteCommand: конкретная реализация команды, реализует метод Execute(), в котором вызывается определенный метод,
определенный в классе Receiver.*/
class ConcreteCommand : Command
{
    Receiver receiver;
    public ConcreteCommand(Receiver r)
    {
        receiver = r;
    }
    public override void Execute()
    {
        receiver.Operation();
    }
 
    public override void Undo()
    {}
}
 
// Receiver: получатель команды. Определяет действия, которые должны выполняться в результате запроса.
class Receiver
{
    public void Operation()
    { }
}
// Invoker: инициатор команды - вызывает команду для выполнения определенного запроса.
class Invoker
{
    Command command;
    public void SetCommand(Command c)
    {
        command = c;
    }
    public void Run()
    {
        command.Execute();
    }
    public void Cancel()
    {
        command.Undo();
    }
}

// Client: клиент - создает команду и устанавливает ее получателя с помощью метода SetCommand()
class Client
{  
    void Main()
    {
        Invoker invoker = new Invoker();
        Receiver receiver = new Receiver();
        ConcreteCommand command=new ConcreteCommand(receiver);
        invoker.SetCommand(command);
        invoker.Run();
    }
}