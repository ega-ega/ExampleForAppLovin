using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Company.Client.Presentation.Utils
{
  public class ColoringThroughRenderers : MonoBehaviour, IColorChangeable
  {
    public enum ColorProperty
    {
      Emission,
      MainColor
    }

    [SerializeField] private ColorProperty colorProperty;

    private static readonly int _emissionColor = Shader.PropertyToID("_EmissionColor");
    private static readonly int _mainColor = Shader.PropertyToID("_Color");

    [SerializeField] private List<Renderer> renderers;

    public void SetupColor(Color color)
    {
      var property = colorProperty == ColorProperty.Emission ? _emissionColor : _mainColor;
      foreach (var material in renderers.Select(element => element.material))
      {
        material.SetColor(property, color);
      }
    }
  }
}