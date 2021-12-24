using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  public class AddOptionsMenuFacade<TValue> : OpenOptionsMenuFacade<TValue>
  {
    public AddOptionsMenuFacade(ToolbarOptionMenu menu, OptionPicker<TValue> optionPicker) : base(menu, optionPicker)
    {
    }
    
    protected override IMenuShowingProcess InvokeSelf(Transform target)
    {
      return Menu.AddMenu(OptionPicker);
    }
  }
}