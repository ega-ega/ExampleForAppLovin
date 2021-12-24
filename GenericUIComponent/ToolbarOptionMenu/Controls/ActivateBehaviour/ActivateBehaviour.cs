using UnityEngine;
using UnityEngine.Events;

namespace Company.Client.Presentation.Controls
{
  public class ActivateBehaviour : MonoBehaviour
  {
    [Header("Events")]
    public UnityEvent onActive;
    public UnityEvent onDeactivate;

    private IActivated _activatedTarget;
    private IActivated ActivatedTarget => _activatedTarget ??= transform.GetComponent<IActivated>();

    protected void OnActivated(bool isActive)
    {
      ActivatedTarget?.ChangeActive(isActive);

      if (isActive)
      {
        onActive?.Invoke();
      }
      else
      {
        onDeactivate?.Invoke();
      }; 
    }
  }
}