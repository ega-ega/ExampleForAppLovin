using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Company.Client.Presentation.Controls
{
  public class ToolbarOptionMenu : MonoBehaviour
  {
    [Header("Parent for menu")]
    [SerializeField] private Transform menuRoot;
    
    private IOptionMenuFactory _optionMenuFactory;
    
    private readonly List<IOptionMenu> _activeMenu = new List<IOptionMenu>();
    private MenuShowingProcess _showingProcess = MenuShowingProcess.FinishedShowing;
    
    
    public IMenuShowingProcess Show<TValue>(OptionPicker<TValue> optionPicker, Transform target)
    {
      _showingProcess?.Finish();
      _showingProcess = new MenuShowingProcess();
      
      CleanupMenu();

      ShowInPosition(target);

      AddMenu(optionPicker);

      return _showingProcess;
    }
    public IMenuShowingProcess AddMenu<TValue>(OptionPicker<TValue> optionPicker)
    {
      var optionMenu = _optionMenuFactory.Create<TValue>(menuRoot);
      optionMenu.Setup(optionPicker);
      
      _activeMenu.Add(optionMenu);

      LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform) menuRoot);

      return _showingProcess;
    }
    
    public void Hide()
    {
      _showingProcess?.Finish();
      _showingProcess = MenuShowingProcess.FinishedShowing;
      
      gameObject.SetActive(false);
    }
    public void OnDeactivateMenu()
    {
      Hide();
    }
    
    
    private void CleanupMenu()
    {
      foreach (var menu in _activeMenu)
      {
        menu.Cleanup();
      }

      _activeMenu.Clear();
    }
    private void ShowInPosition(Transform target)
    {
      gameObject.SetActive(true);

      transform.position = target.position;
    }

    public void SetupOptionMenuFactory(IOptionMenuFactory optionMenuFactory)
    {
      _optionMenuFactory = optionMenuFactory;
    }
  }
} 