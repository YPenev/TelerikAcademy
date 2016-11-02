#Strategy

Идеята му да имаме енкапсулирани алгоритми които си приличат по някакъв начин но са различни.
При него позлволяване на даден клас да има достъп до дадени алгоритми в зависимост от това от какво има нужда.
Трябва да помислил дали да не използваме strategy pattern-а когато имаме много if-ове или трябва да модифицираме класа.
Имаме някъв абстрактен клас, който има абстрактен метод (в него подаваме начина на имплементиране на метода)
Недостатъка на тази патерн е , че стратегиите не може да използват private членове.
Предимството е, че позволява много лесно да се пишат unit- тестове и методите да бъдат моквани.
Друго предимство е , че добавянето на нови стратегии (имплементации на абстрактния метод) не модифицират нищо старо.


##Пимерен код:

```C#
using System;
 
namespace DoFactory.GangOfFour.Strategy.Structural
{
  class MainApp
  {
    static void Main()
    {
      Context context;
 
      // Three contexts following different strategies
      context = new Context(new ConcreteStrategyA());
      context.ContextInterface();
 
      context = new Context(new ConcreteStrategyB());
      context.ContextInterface();
 
      context = new Context(new ConcreteStrategyC());
      context.ContextInterface();
 
      // Wait for user
      Console.ReadKey();
    }
  }
 
  abstract class Strategy
  {
    public abstract void AlgorithmInterface();
  }

  class ConcreteStrategyA : Strategy
  {
    public override void AlgorithmInterface()
    {
      Console.WriteLine(
        "Called ConcreteStrategyA.AlgorithmInterface()");
    }
  }
 
  class ConcreteStrategyB : Strategy
  {
    public override void AlgorithmInterface()
    {
      Console.WriteLine(
        "Called ConcreteStrategyB.AlgorithmInterface()");
    }
  }

  class ConcreteStrategyC : Strategy
  {
    public override void AlgorithmInterface()
    {
      Console.WriteLine(
        "Called ConcreteStrategyC.AlgorithmInterface()");
    }
  }
 
  class Context
  {
    private Strategy _strategy;
 
    // Constructor
    public Context(Strategy strategy)
    {
      this._strategy = strategy;
    }
 
    public void ContextInterface()
    {
      _strategy.AlgorithmInterface();
    }
  }
}
```

#Chain of responsibility

Идеята му е при пускане на някаква заявка на даден клас и той  да знае какво да прави с нея,
и ако не е негова работа да го изпълни да я подаде на някой следваш, който да провери дали е ногова работа и така нататък.
С по-прости думи е верига от класове, които могат да изпълняват дадена работа и всеки прецеянва дали тази работа е за него 
(съответно дали да се заеме с нея или да я подаде някъде)
Това се изпозлва на много места и замества веригата от if-ове
Позволява ни да разделим някаква сложна логика за проверкаи на няколко отделни класа в които много по-лесно се намира ако има проблем и много по-лесно се добавя нещо ново.
Sender-а знае само за един изпълнител и всеки изпълнител знае само за следващия. Първия който свърши работата прекъсва веригата.
Използва се и при request-ти при web програмирането.

##Пимерен код:

```C#
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCof
{

 
    //Request
    class LoanRequest
    {
        public string Customer { get; set; }
        public decimal Amount { get; set; }
    }

    //Abstract Request Handler
    interface IRequestHandler
    {
        string Name { get; set; }
        void HandleRequest(LoanRequest req);
        IRequestHandler Successor { get; set; }
    }

    //Just an extension method for the passing the request
    static class RequestHandlerExtension
    {
        public static void TrySuccessor(this IRequestHandler current, LoanRequest req)
        {

            if (current.Successor != null) 
            {
                Console.WriteLine("{0} Can't approve - Passing request to {1}", current.Name, current.Successor.Name);
                current.Successor.HandleRequest(req);
            }
            else
            {
                Console.WriteLine("Amount invaid, no approval given");                
            }
        }
    }

    //Concrete Request Handler - Cachier
    //Cachier can approve requests upto 1000$$
    class Cashier : IRequestHandler
    {
        public string Name { get; set; }
        
        public void HandleRequest(LoanRequest req)
        {
            Console.WriteLine("\n----\n{0} $$ Loan Requested by {1}",
                  req.Amount, req.Customer);

           if (req.Amount<1000)
               Console.WriteLine("{0} $$ Loan approved for {1} - Approved by {2}",
                    req.Amount,req.Customer, this.Name);
           else
               this.TrySuccessor(req);
        }

        public IRequestHandler Successor { get; set; }       
    }

    //Concrete Request Handler - Manager
    //Manager can approve requests upto 10000$
    class Manager : IRequestHandler
    {
        public string Name { get; set; }
        public void HandleRequest(LoanRequest req)
        {
            if (req.Amount < 10000)
                Console.WriteLine("{0} $$ Loan approved for {1} - Approved by {2}",
                         req.Amount, req.Customer, this.Name);
            else
               this.TrySuccessor(req);

        }
        public IRequestHandler Successor { get; set; }  
    }

   

    //Main driver
    class Program
    {
        static void Main(string[] args)
        {
            var request1 = new LoanRequest() { Amount = 800, Customer = "Jimmy"};
            var request2 = new LoanRequest() { Amount = 5000, Customer = "Ben"};
            var request3 = new LoanRequest() {Amount = 200000, Customer = "Harry"};

            var manager = new Manager() {Name = "Tom, Manager"};
            var cashier = new Cashier(){ Name = "Job, Cachier", Successor = manager};

            cashier.HandleRequest(request1);
            cashier.HandleRequest(request2);
            cashier.HandleRequest(request3);

            Console.ReadLine();
        }


    }
}

```

#Iterator

Идеята му е да ни позволи по някаккъв начин да обиколим дадена колекция коята не може да бъде обиколена по елементарен начин в езика.
Изключително полезен при работа с графи.
Скрива самото iter-иране.
Foreach е имплементиран iterator pattern.
Тук е важно да разделим самата структора от данни в отделен клас и логиката която я обикаля и итерира в отделен клас. 
Тоест имаме два отделни класа с различни задачи, първия дефинира как са структорирани данните, а втория дефинира как тези данни се обикалят,
и ако решим да сменим начина на итерация просто сменяме класа отговарящ за итерация с друг такъв и по -този начин няма никакъв проблем да използваме  дадена структура от данни с различни итератори.
Другия плюс е, че скрива всякакви сложности по имплементацията


##Пимерен код:

```C#
public class Client
{
    public void UseIterator()
    {
        ConcreteAggregate aggr = new ConcreteAggregate();
        aggr.Add("One");
        aggr.Add("Two");
        aggr.Add("Three");
        aggr.Add("Four");
        aggr.Add("Five");
 
        IteratorBase iterator = aggr.CreateIterator();
 
        string item = (string)iterator.First();
        while (!iterator.IsDone())
        {
            Console.WriteLine(item);
            item = (string)iterator.Next();
        }
    }
}
 
 
public abstract class AggregateBase
{
    public abstract IteratorBase CreateIterator();
}
 
 
public class ConcreteAggregate : AggregateBase
{
    private ArrayList _items = new ArrayList();
 
    public override IteratorBase CreateIterator()
    {
        return new ConcreteIterator(this);
    }
 
    public object this[int index]
    {
        get { return _items[index]; }
    }
 
    public int Count
    {
        get { return _items.Count; }
    }
 
    public void Add(object o)
    {
        _items.Add(o);
    }
}
 
 
public abstract class IteratorBase
{
    public abstract object First();
 
    public abstract object Next();
 
    public abstract object CurrentItem();
 
    public abstract bool IsDone();
}
 
 
public class ConcreteIterator : IteratorBase
{
    private ConcreteAggregate _aggregate;
    int _position;
 
    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        _aggregate = aggregate;
        _position = 0;
    }
 
    public override object First()
    {
        _position = 0;
        return CurrentItem();
    }
 
    public override object Next()
    {
        _position++;
        return CurrentItem();
    }
 
    public override object CurrentItem()
    {
        if (_position < _aggregate.Count)
            return _aggregate[_position];
        else
            return null;
    }
 
    public override bool IsDone()
    {
        return _position >= _aggregate.Count;
    }
}

```

#Template mehtod

Идеята му е, че той дефинира някакв алгоритъм в някакъв базов клас и оставя имплементацията на алгоритъма за неговите наследници. 
С други думи базовия клас само описва конкректните стъпки една след друга, но не каква как точно се изпълнява.
Тоест позволява ни да изпозваме наследяване когато искаме да изпозлваме даден алгоритъм.
Обикновенно това се изпълнява чрез абстрактни или виртуални методи и така трябва да се дефинира кода, че базовия клас да дефинира стъпките и тези под него да не могат да ги променят.
Използва се всеки път когато имаме един и същи алгоритъм с много малки промени.
Идеята е, че самия алгоръм не се променя, само конкретните имплементации се променят.

##Пимерен код:

```C#
public abstract class AlgorithmBase
{
    public void TemplateMethod()
    {
        Step1();
        Step2();
        Step3();
    }
 
    public abstract void Step1();
 
    public abstract void Step2();
 
    public abstract void Step3();
}
 
 
public class ConcreteAlgorithmA : AlgorithmBase
{
    public override void Step1()
    {
        Console.WriteLine("Algorithm A, Step 1");
    }
 
    public override void Step2()
    {
        Console.WriteLine("Algorithm A, Step 2");
    }
 
    public override void Step3()
    {
        Console.WriteLine("Algorithm A, Step 3");
    }
}
 
 
public class ConcreteAlgorithmB : AlgorithmBase
{
    public override void Step1()
    {
        Console.WriteLine("Algorithm B, Step 1");
    }
 
    public override void Step2()
    {
        Console.WriteLine("Algorithm B, Step 2");
    }
 
    public override void Step3()
    {
        Console.WriteLine("Algorithm B, Step 3");
    }
}
```
