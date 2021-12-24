using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  [RequireComponent(typeof(ToggleButton))]
  public class ToggleButtonWithOptionsMenu : ButtonWithOptions, ToggleButton.IChangeState
  {
    private ToggleButton _toggle;

    public ToggleButton Toggle => _toggle ? _toggle : _toggle = GetComponent<ToggleButton>();

    protected override bool Disable => !_toggle.button.interactable;

    [SerializeField] private bool setToggleStateOnActivateMenu = false;

    protected void Awake()
    {
      Toggle.StateChanged += ToggleStateChanged;
    }
    
    protected void OnDestroy()
    {
      if (Toggle)
      {
        Toggle.StateChanged -= ToggleStateChanged;  
      }
    }
    
    private void ToggleStateChanged(bool isOn)
    {
      if (!isOn)
      {
        HideMenu();  
      }
    }

    protected override void ActivateMenuInternal()
    {
      base.ActivateMenuInternal();
      if (setToggleStateOnActivateMenu)
      {
        Toggle.ForceSetState(true, true);  
      }
    }
    
    public void ForceSetState(bool isOn, bool invokeStateChanged = false)
    {
      Toggle.ForceSetState(isOn, invokeStateChanged);

      if (!invokeStateChanged)
      {
        ToggleStateChanged(isOn);
      }
    }

    protected override void OnOptionChanged()
    {
      Toggle.ForceSetState(true, true);
    }
  }
}