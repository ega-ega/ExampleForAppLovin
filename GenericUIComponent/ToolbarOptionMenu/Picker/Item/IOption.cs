namespace Company.Client.Presentation.Controls
{
  public interface IOption<out TValue>
  {
    TValue Value { get; }
  }
}