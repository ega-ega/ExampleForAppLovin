using UnityEngine;
using UnityEngine.EventSystems;

namespace Company.Client.Presentation.Controls
{
  public class ActivateFromHover : ActivateBehaviour,  IPointerEnterHandler, IPointerExitHandler
  {
    [Header("Settings")]
    [SerializeField] private bool closeOnExit;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
      OnActivated(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      if (closeOnExit)
      {
        OnActivated(false);  
      }
    }
  }
}