using UnityEngine;
using Company.Client.Presentation.Controls;

namespace Company.Client.Presentation.Utils
{
  public abstract class OptionPickerDisplayBase<TValue> : MonoBehaviour, IOptionPickerView<TValue>
  {
    private OptionPicker<TValue> _options;
    public void Setup(OptionPicker<TValue> optionsPicker)
    {
      ResetLinks();
      
      _options = optionsPicker;
      _options.SelectionOptionChanged += SelectedOptionChanged;

      Display(_options.SelectedOption.Value);
    }

    protected void OnDestroy()
    {
      ResetLinks();
    }

    private void ResetLinks()
    {
      if (_options == null)
      {
        return;
      }

      _options.SelectionOptionChanged -= SelectedOptionChanged;
      _options = null;
    }

    private void SelectedOptionChanged(IOption<TValue> option)
    {
      Display(option.Value);
    }

    protected abstract void Display(TValue optionValue);
  }
}