namespace ZoneSystemAssistant.Models
{
    public interface IItem
    {
        string Id { get; }
        int Ev { get; }
        string Description { get; }
    }
}