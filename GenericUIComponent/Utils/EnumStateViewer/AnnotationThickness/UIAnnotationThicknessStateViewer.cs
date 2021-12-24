using UnityEngine;
using Company.Client.Core.ValueObjects.Annotations;

namespace Company.Client.Presentation.Utils
{
  public class UIAnnotationThicknessStateViewer : AnnotationThicknessStateViewerBase, IEnumStateViewer<AnnotationThickness>
  {
    [SerializeField] private RectTransform target;

    public void SetupState(AnnotationThickness state)
    {
      target.sizeDelta = new Vector2(target.sizeDelta.x, GetThicknessValue(state));
    }
  }
}