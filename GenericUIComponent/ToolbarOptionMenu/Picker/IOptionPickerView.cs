namespace Company.Client.Presentation.Controls
{
  public interface IOptionPickerView<TValue>
  {
    void Setup(OptionPicker<TValue> optionsPicker);
  }
}