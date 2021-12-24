using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Company.Client.Presentation.Controls
{
  public class LongPressEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
  {
    [SerializeField]
    [Tooltip("How long must pointer be down on this object to trigger a long press")]
    private float holdTime = 1f;

    [SerializeField]
    [Tooltip("Set true if need block onClick event in ")]
    private bool blockingOnClick = false;
    
    private PointerEventData _downEventData;
 
    public UnityEvent onLongPress = new UnityEvent();
 
    public void OnPointerDown(PointerEventData eventData)
    {
      _downEventData = eventData;
      Invoke(nameof(OnLongPress), holdTime);
    }
 
    public void OnPointerUp(PointerEventData eventData)
    {
      CancelInvoke(nameof(OnLongPress));
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
      CancelInvoke(nameof(OnLongPress));
    }
 
    private void OnLongPress()
    {
      _downEventData.eligibleForClick = !blockingOnClick;
      onLongPress.Invoke();
    }
  }
}