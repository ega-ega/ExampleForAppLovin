using System.Collections.Generic;
using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  public class ButtonWithOptions : MonoBehaviour, IActivated
  {
    [SerializeField] private ToolbarOptionMenu optionMenu;

    private List<IOptionPicker> _optionPickers = new List<IOptionPicker>();

    private ToolbarOptionMenu OptionMenu
    {
      get
      {
        if (!optionMenu)
        {
          optionMenu =  transform.FindMenuInHierarchy();
          if (!optionMenu)
          {
            Debug.LogError($"NotFound {nameof(ToolbarOptionMenu)} component in hierarchy");
          }
        }

        return optionMenu;
      }
    }
    
    private IOptionMenuShowing _openHandler;

    private IMenuShowingProcess _showingProcess;

    protected virtual bool Disable => false;

    public void Setup<TValue>(OptionPicker<TValue> optionPicker)
    {
      _openHandler = OptionMenu.GetShowingFacade(optionPicker);

      TrySetupOptionPickerViewer(optionPicker);

      optionPicker.SelectionChanged += OnOptionChanged;
      _optionPickers.Add(optionPicker);
    }

    public void Setup<TValue1, TValue2>(OptionPicker<TValue1> optionPicker1, OptionPicker<TValue2> optionPicker2)
    {
      _openHandler = OptionMenu.GetShowingFacade(optionPicker1)
        .Concat(OptionMenu.GetAddingFacade(optionPicker2));
      
      TrySetupOptionPickerViewer(optionPicker1);
      TrySetupOptionPickerViewer(optionPicker2);

      optionPicker1.SelectionChanged += OnOptionChanged;
      optionPicker2.SelectionChanged += OnOptionChanged;

      _optionPickers.Add(optionPicker1);
      _optionPickers.Add(optionPicker2);
    }

    private void TrySetupOptionPickerViewer<TValue>(OptionPicker<TValue> optionPicker)
    {
      foreach (var viewer in GetComponents<IOptionPickerView<TValue>>())
      {
        viewer.Setup(optionPicker);
      }
    }

    private  void ActivateMenu()
    {
      if (!Disable)
      {
        ActivateMenuInternal();
      }
    }

    protected  virtual void ActivateMenuInternal()
    {
      _showingProcess = _openHandler?.Invoke(transform);
    }

    protected void HideMenu()
    {
      if (_showingProcess is {IsShow: true})
      {
        OptionMenu.Hide();  
      }
    }

    public void ChangeActive(bool isActivate)
    {
      if (isActivate)
      {
        ActivateMenu();
      }
      else
      {
        HideMenu();
      }
    }

    protected virtual void OnOptionChanged() { }

    private void OnDestroy()
    {
      foreach (var optionPicker in _optionPickers)
      {
        optionPicker.SelectionChanged -= OnOptionChanged;
      }
    }
  }
}