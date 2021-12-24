namespace Company.Client.Presentation.Controls
{
  public interface IOptionFactory
  {
    IOption<TValue> Create<TValue>(TValue value);
  }
}