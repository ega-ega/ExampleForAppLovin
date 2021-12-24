using System.Collections.Generic;
using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  public class OptionMenu<TValue> : IOptionMenu<TValue>
  {
    private readonly OptionMenuContainer _container;
    private OptionPicker<TValue> _optionController;
    
    private readonly List<IOptionMenuItem<TValue>> _items = new List<IOptionMenuItem<TValue>>();

    public OptionMenu(OptionMenuContainer container)
    {
      _container = container;
    }
    
    public void Setup(OptionPicker<TValue> optionPicker)
    {
      _optionController = optionPicker;

      _items.Clear();

      _container.CleanupItems();
      
      foreach (var option in optionPicker.Options)
      {
        var menuItem = _container.InstantiateItem<TValue>();
        menuItem.Setup(option, SelectionChanged);
        
        _items.Add(menuItem);
      }

      RefreshSelect();
    }

    public void Cleanup()
    {
      _items.Clear();
      _container.CleanupItems();
      
      Object.Destroy(_container.gameObject);
    }

    private void SelectionChanged(IOption<TValue> selectedOption)
    {
      _optionController.Pick(selectedOption);
      
      RefreshSelect();
    }

    private void RefreshSelect()
    {
      foreach (var item in _items)
      {
        item.ChangeSelect(item.Option == _optionController.SelectedOption);
      }
    }
  }
}