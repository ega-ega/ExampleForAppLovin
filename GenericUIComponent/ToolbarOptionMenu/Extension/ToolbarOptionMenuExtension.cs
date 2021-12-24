using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  public static class ToolbarOptionMenuExtension
  {
    public static IOptionMenuShowing GetShowingFacade<TValue>(this ToolbarOptionMenu menu, OptionPicker<TValue> optionPicker)
    {
      return new OpenOptionsMenuFacade<TValue>(menu, optionPicker);
    }
    
    public static IOptionMenuShowing GetAddingFacade<TValue>(this ToolbarOptionMenu menu, OptionPicker<TValue> optionPicker)
    {
      return new AddOptionsMenuFacade<TValue>(menu, optionPicker);
    }

    public static ToolbarOptionMenu FindMenuInHierarchy(this Transform start)
    {
      return start.TryGetComponent(out ToolbarOptionMenu result) ? result : FindMenuInHierarchyInternal(start.parent);
    }
    private static ToolbarOptionMenu FindMenuInHierarchyInternal(this Transform start)
    {
      if (!start)
      {
        return null;
      }
      
      if (start.TryGetComponent(out ToolbarOptionMenu result))
      {
        return result;
      }

      result = start.GetComponentInChildren<ToolbarOptionMenu>(true);
      
      return !result ? FindMenuInHierarchy(start.parent) : result;
    }
    
  }
}