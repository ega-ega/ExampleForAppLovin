using System.Collections.Generic;
using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  [CreateAssetMenu(menuName = "ToolBarOptionMenu/TypeMenuSettings")]
  public class OptionMenuSettings : ScriptableObject
  {
    [Header("Type open in basic menu")]
    public OptionMenuContainer basicOptionMenu;
    public List<GameObject> basicTypesItem = new List<GameObject>();
    
    [Header("Type open in custom menu")]
    public List<OptionMenuContainer> customMenu = new List<OptionMenuContainer>();
  }
}