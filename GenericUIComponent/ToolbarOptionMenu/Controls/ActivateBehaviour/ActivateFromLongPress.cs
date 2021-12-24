using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  [RequireComponent(typeof(LongPressEvent))]
  public class ActivateFromLongPress : ActivateBehaviour
  {
    private LongPressEvent _longPressEvent;

    protected void Awake()
    {
      _longPressEvent = GetComponent<LongPressEvent>();
      _longPressEvent.onLongPress.AddListener(Activate);
    }

    protected void OnDestroy()
    {
      _longPressEvent.onLongPress.RemoveListener(Activate);
    }

    private void Activate()
    {
      OnActivated(true); 
    }
  }
}