namespace Company.Client.Presentation.Controls
{
  public interface IOptionMenu
  {
    void Cleanup();
  }

  public interface IOptionMenu<TValue> : IOptionMenu, IOptionPickerView<TValue>
  {
  }
}