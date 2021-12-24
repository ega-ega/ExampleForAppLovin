using System.Collections.Generic;
using UnityEngine;
using Company.Client.Core.ValueObjects.Annotations;

namespace Company.Client.Presentation.Utils
{
  public class AnnotationOrientationStateViewer : MonoBehaviour, IEnumStateViewer<AnnotationOrientation>
  {
    [SerializeField] private GameObject upAnnotationView;
    [SerializeField] private GameObject downAnnotationView;
    [SerializeField] private GameObject leftAnnotationView;
    [SerializeField] private GameObject rightAnnotationView;

    private Dictionary<AnnotationOrientation, GameObject> _cachedViews;
    private Dictionary<AnnotationOrientation, GameObject> CachedViews
    {
      get
      {
        if (_cachedViews == null)
        {
          _cachedViews = new Dictionary<AnnotationOrientation, GameObject>
          {
            {AnnotationOrientation.Up, upAnnotationView},
            {AnnotationOrientation.Down, downAnnotationView},
            {AnnotationOrientation.Left, leftAnnotationView},
            {AnnotationOrientation.Right, rightAnnotationView},
          };
        }

        return _cachedViews;
      }
    }
    

    public void SetupState(AnnotationOrientation state)
    {
      foreach (var pair in CachedViews)
      {
        pair.Value.SetActive(pair.Key == state);
      }
    }
  }
}