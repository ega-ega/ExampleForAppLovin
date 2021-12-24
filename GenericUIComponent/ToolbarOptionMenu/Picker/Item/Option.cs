namespace Company.Client.Presentation.Controls
{
  public class Option<TValue> : IOption<TValue>
  {
    public TValue Value { get; }

    public Option(TValue value)
    {
      Value = value;
    }
  }
}