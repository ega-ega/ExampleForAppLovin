using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Company.Client.Core.ValueObjects.Annotations;

namespace Company.Client.Presentation.Utils
{
  public class SpriteAnnotationOrientationStateViewer : MonoBehaviour, IEnumStateViewer<AnnotationOrientation>
  {
    [Header("Target")]
    [SerializeField] private Image targetImage;
    
    [Header("Orientation Icons")]
    [SerializeField] private Sprite upAnnotationSprite;
    [SerializeField] private Sprite downAnnotationSprite;
    [SerializeField] private Sprite leftAnnotationSprite;
    [SerializeField] private Sprite rightAnnotationSprite;

    
    private Dictionary<AnnotationOrientation, Sprite> _cachedSprites;
    private Dictionary<AnnotationOrientation, Sprite> CachedSprites
    {
      get
      {
        if (_cachedSprites == null)
        {
          _cachedSprites = new Dictionary<AnnotationOrientation, Sprite>
          {
            {AnnotationOrientation.Up, upAnnotationSprite},
            {AnnotationOrientation.Down, downAnnotationSprite},
            {AnnotationOrientation.Left, leftAnnotationSprite},
            {AnnotationOrientation.Right, rightAnnotationSprite},
          };
        }

        return _cachedSprites;
      }
    }
    
    public void SetupState(AnnotationOrientation state)
    {
      if (CachedSprites.TryGetValue(state, out var sprite))
      {
        targetImage.sprite = sprite;
      }
      else
      {
        throw new ArgumentOutOfRangeException(nameof(state), state, null);
      }
    }
  }
}