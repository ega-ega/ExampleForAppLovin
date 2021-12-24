using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Company.Client.Core.ValueObjects.Annotations;

namespace Company.Client.Presentation.Utils
{
  public class AnnotationThicknessStateViewerBase : MonoBehaviour
  {
    [SerializeField] private float normalThickness = 3;
    [SerializeField] private float width1Thickness = 4;
    [SerializeField] private float width2Thickness = 5;
    [SerializeField] private float width3Thickness = 6;
    
    
    private Dictionary<AnnotationThickness, float> _cachedValues;

    private Dictionary<AnnotationThickness, float> CachedValues
    {
      get
      {
        if (_cachedValues == null)
        {
          _cachedValues = new Dictionary<AnnotationThickness, float>()
          {
            { AnnotationThickness.Normal, normalThickness },
            { AnnotationThickness.Bold1, width1Thickness},
            { AnnotationThickness.Bold2, width2Thickness},
            { AnnotationThickness.Bold3, width3Thickness}
          };
        }

        return _cachedValues;
      }
    }

    protected float GetThicknessValue(AnnotationThickness thickness)
    {
      if (CachedValues.TryGetValue(thickness, out var result))
      {
        return result;
      }

      return CachedValues.Values.First();
    }
  }
}