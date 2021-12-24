using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Company.Client.Presentation.Utils
{
  public class ColoringThroughParticles : MonoBehaviour, IColorChangeable
  {
    [SerializeField] private List<ParticleSystem> particles; 
    
    public void SetupColor(Color color)
    {
      foreach (var particle in particles.Where(particle => particle))
      {
        var settings = particle.main;
        settings.startColor = new ParticleSystem.MinMaxGradient(color);
      }
    }
  }
}