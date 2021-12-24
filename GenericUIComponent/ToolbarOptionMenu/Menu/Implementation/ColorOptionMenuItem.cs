using UnityEngine;
using Company.Client.Presentation.Utils;

namespace Company.Client.Presentation.Controls
{
  [RequireComponent(typeof(PointerClickHandlerProxy))]
  public class ColorOptionMenuItem : MonoBehaviour, IOptionMenuItem<Color>
  {
    [SerializeField] private Transform selectionView;
    
    public IOption<Color> Option { get; private set; }

    public void Setup(IOption<Color> option, IOptionMenuItem<Color>.Selected selectHandler)
    {
      Option = option;
      
      transform.TryColoring(option.Value);
      
      gameObject.TurnOnClicker(selectHandler);
    }

    public void ChangeSelect(bool isSelected)
    {
      selectionView.gameObject.SetActive(isSelected);
    }
  }
}