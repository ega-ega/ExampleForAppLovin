using UnityEngine;
using UnityEngine.UI.Extensions;
using Company.Client.Core.ValueObjects.Annotations;

namespace Company.Client.Presentation.Utils
{
  public class UILineRendererAnnotationThicknessStateViewer : AnnotationThicknessStateViewerBase, IEnumStateViewer<AnnotationThickness>
  {
    [SerializeField] private UILineRenderer lineRenderer;

    public void SetupState(AnnotationThickness state)
    {
      lineRenderer.LineThickness = GetThicknessValue(state);
    }
  }
}