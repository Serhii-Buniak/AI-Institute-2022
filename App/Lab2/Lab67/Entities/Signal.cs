using System.Text.Json.Serialization;

namespace Lab67.Entities;

public abstract class Signal : BaseEntity
{
    public double Value { get; set; }
}

public class SignalInput : Signal
{

}

public class SignalOutput : Signal
{

}