using UnityEngine.EventSystems;

namespace Company.Client.Presentation.Controls
{
  public class MenuItemClickSelectionAdapter<TValue> : IPointerClickHandler
  {
    private readonly IOption<TValue> _option;
    private readonly IOptionMenuItem<TValue>.Selected _selectHandler;

    public MenuItemClickSelectionAdapter(IOption<TValue> option, IOptionMenuItem<TValue>.Selected selectHandler)
    {
      _option = option;
      _selectHandler = selectHandler;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      _selectHandler.Invoke(_option);
    }
  }
}