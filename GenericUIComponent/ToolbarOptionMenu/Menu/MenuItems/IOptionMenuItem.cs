namespace Company.Client.Presentation.Controls
{
  public interface IOptionMenuItem<TValue>
  {
    public delegate void Selected(IOption<TValue> selectedOption);
    
    IOption<TValue> Option { get; }
    void Setup(IOption<TValue> option, Selected selectHandler);
    void ChangeSelect(bool isSelected);
  }
}