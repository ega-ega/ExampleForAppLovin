using UnityEngine;
using Company.Client.Core.ValueObjects.Annotations;

namespace Company.Client.Presentation.Utils
{
  public class RotateOrientationStateViewer : MonoBehaviour, IEnumStateViewer<AnnotationOrientation>
  {
    public void SetupState(AnnotationOrientation state)
    {
      switch (state)
      {
        case AnnotationOrientation.Left:
          transform.eulerAngles = Vector3.forward * -90;
          break;
        case AnnotationOrientation.Right:
          transform.eulerAngles = Vector3.forward * 90;
          break;
        case AnnotationOrientation.Up:
          transform.eulerAngles = Vector3.forward * 180;
          break;
        default:
          transform.eulerAngles = Vector3.zero;
          break;
      }
    }
  }
}
