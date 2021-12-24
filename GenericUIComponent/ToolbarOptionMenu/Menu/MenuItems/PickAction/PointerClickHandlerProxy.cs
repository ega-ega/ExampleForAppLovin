using UnityEngine;
using UnityEngine.EventSystems;

namespace Company.Client.Presentation.Controls
{
  public class PointerClickHandlerProxy : MonoBehaviour, IPointerClickHandler
  {
    private IPointerClickHandler _pointerClickHandler; 
    
    public void Setup(IPointerClickHandler pointerClickHandler)
    {
      _pointerClickHandler = pointerClickHandler;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      _pointerClickHandler?.OnPointerClick(eventData);
    }

    protected void OnDestroy()
    {
      _pointerClickHandler = null;
    }
  }
}