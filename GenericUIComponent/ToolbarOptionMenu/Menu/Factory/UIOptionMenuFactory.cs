using System.Linq;
using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  [RequireComponent(typeof(ToolbarOptionMenu))]
  public class UIOptionMenuFactory : MonoBehaviour, IOptionMenuFactory
  {
    [SerializeField] private OptionMenuSettings settings;

    public IOptionMenu<TValue> Create<TValue>(Transform parent)
    {
      var suitablePrefab = settings.customMenu.FirstOrDefault(prefab => prefab.CheckItemValueType<TValue>());

      OptionMenuContainer menuContainer = null;
      if (suitablePrefab)
      {
        menuContainer = Instantiate(suitablePrefab, parent);

        return new OptionMenu<TValue>(menuContainer);
      }

      var basicTypeItemPrefab =
        settings.basicTypesItem.FirstOrDefault(item => item.GetComponent<IOptionMenuItem<TValue>>() != null);
      if (basicTypeItemPrefab)
      {
        menuContainer = Instantiate(settings.basicOptionMenu, parent);
        menuContainer.SetupItemPrefab(basicTypeItemPrefab);

        return new OptionMenu<TValue>(menuContainer);
      }

      Debug.LogError($"UIOptionMenuFactory. instantiate failed: not found suitable menu prefab for type:{typeof(TValue)}");
      return null;
    }

    protected void Awake()
    {
      GetComponent<ToolbarOptionMenu>().SetupOptionMenuFactory(this);
    }
  }
}