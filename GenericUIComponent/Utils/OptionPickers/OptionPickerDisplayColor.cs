using UnityEngine;

namespace Company.Presentation.Utils
{
  public class OptionPickerDisplayColor : OptionPickerDisplayBase<Color>
  {
    protected override void Display(Color optionValue)
    {
      transform.TryColoring(optionValue);
    }
  }
}