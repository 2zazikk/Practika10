using System;

// ================== PRODUCT ==================
public interface ITicket
{
    void Book();
}

// Конкретные продукты

public class PlaneTicket : ITicket
{
    public void Book()
    {
        Console.WriteLine("Забронирован авиабилет ✈");
    }
}

public class TrainTicket : ITicket
{
    public void Book()
    {
        Console.WriteLine("Забронирован билет на поезд 🚆");
    }
}

public class BusTicket : ITicket
{
    public void Book()
    {
        Console.WriteLine("Забронирован билет на автобус 🚌");
    }
}

// ================== ABSTRACT FACTORY ==================
public abstract class TicketFactory
{
    public abstract ITicket CreateTicket();
}

// ================== CONCRETE FACTORIES ==================

public class PlaneFactory : TicketFactory
{
    public override ITicket CreateTicket()
    {
        return new PlaneTicket();
    }
}

public class TrainFactory : TicketFactory
{
    public override ITicket CreateTicket()
    {
        return new TrainTicket();
    }
}

public class BusFactory : TicketFactory
{
    public override ITicket CreateTicket()
    {
        return new BusTicket();
    }
}

// ================== CLIENT ==================
class Program
{
    static void Main()
    {
        TicketFactory factory;

        factory = new PlaneFactory();
        ITicket plane = factory.CreateTicket();
        plane.Book();

        factory = new TrainFactory();
        ITicket train = factory.CreateTicket();
        train.Book();

        factory = new BusFactory();
        ITicket bus = factory.CreateTicket();
        bus.Book();
    }
}