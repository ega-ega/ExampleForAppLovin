using System.Collections.Generic;
using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  public class OpenOptionsMenuFacade<TValue> : IOptionMenuShowing
  {
    protected readonly OptionPicker<TValue> OptionPicker;
    protected readonly ToolbarOptionMenu Menu;

    private readonly List<IOptionMenuShowing> _showHandlers = new List<IOptionMenuShowing>();

    public OpenOptionsMenuFacade(ToolbarOptionMenu menu, OptionPicker<TValue> optionPicker)
    {
      Menu = menu;
      OptionPicker = optionPicker;
    }

    public IMenuShowingProcess Invoke(Transform target)
    {
      var notification = InvokeSelf(target);
      
      foreach (var showHandler in _showHandlers)
      {
        showHandler.Invoke(target);
      }

      return notification;
    }

    protected virtual IMenuShowingProcess InvokeSelf(Transform target)
    {
      return Menu.Show(OptionPicker, target);
    }

    public IOptionMenuShowing Concat(IOptionMenuShowing another)
    {
      _showHandlers.Add(another);
      return this;
    }
  }
}