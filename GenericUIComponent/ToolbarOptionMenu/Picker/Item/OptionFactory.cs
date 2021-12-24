namespace Company.Client.Presentation.Controls
{
  public class OptionFactory : IOptionFactory
  {
    public IOption<TValue> Create<TValue>(TValue value)
    {
      return new Option<TValue>(value);
    }
  }
}