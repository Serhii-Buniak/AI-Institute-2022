namespace Lab67.Entities;

public class Seed : BaseEntity
{
    public ICollection<SignalInput> InputSignals { get; set; } = null!;
    public ICollection<SignalOutput> OutputSignals { get; set; } = null!;
}