using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Company.Client.Presentation.Utils
{
  public class ColoringThroughUIGraphics : MonoBehaviour, IColorChangeable
  {
    [SerializeField] private List<Graphic> uiElements; 
    
    public void SetupColor(Color color)
    {
      foreach (var element in uiElements.Where(element => element))
      {
        element.color = color;
      }
    }
  }
}