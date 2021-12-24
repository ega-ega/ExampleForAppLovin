using UnityEngine;
using UnityEngine.Events;

namespace Company.Client.Presentation.Controls
{
  public class HideByHoverComplex : MonoBehaviour
  {
    private int _visibleCounter;

    public UnityEvent onHide;
    
    public void Enter()
    {
      _visibleCounter++;
    }

    public void Exit()
    {
      _visibleCounter--;
      
      if (_visibleCounter <= 0)
      {
        onHide?.Invoke();
      }
    }
  }
}