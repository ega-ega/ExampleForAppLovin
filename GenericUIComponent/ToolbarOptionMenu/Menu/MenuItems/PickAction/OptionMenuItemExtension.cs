using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  public static class OptionMenuItemExtension
  {
    public static void TurnOnClicker<TValue>(this GameObject target, IOptionMenuItem<TValue>.Selected selectHandler)
    {
      var menuItem = target.GetComponent<IOptionMenuItem<TValue>>();

      target.GetComponent<PointerClickHandlerProxy>().Setup(new MenuItemClickSelectionAdapter<TValue>(menuItem.Option, selectHandler));
    }
  }
}