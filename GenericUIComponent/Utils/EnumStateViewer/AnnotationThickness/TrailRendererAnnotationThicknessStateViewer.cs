using UnityEngine;
using Company.Client.Core.ValueObjects.Annotations;

namespace Company.Client.Presentation.Utils
{
  public class TrailRendererAnnotationThicknessStateViewer : AnnotationThicknessStateViewerBase, IEnumStateViewer<AnnotationThickness>
  {
    [SerializeField] private TrailRenderer trailRenderer;

    public void SetupState(AnnotationThickness state)
    {
      trailRenderer.startWidth = GetThicknessValue(state);
      trailRenderer.endWidth = GetThicknessValue(state);
    }
  }
}