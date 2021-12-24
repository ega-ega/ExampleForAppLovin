using UnityEngine;

namespace Company.Client.Presentation.Controls
{
  public class OptionMenuContainer : MonoBehaviour
  {
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private Transform itemsRoot;

    public bool CheckItemValueType<TValue>() => itemPrefab.GetComponent<IOptionMenuItem<TValue>>() != null;

    public void SetupItemPrefab(GameObject prefab)
    {
      itemPrefab = prefab;
    }
    
    public void CleanupItems()
    {
      foreach (Transform child in itemsRoot)
      {
        Destroy(child.gameObject);
      }
    }
    
    public IOptionMenuItem<TValue> InstantiateItem<TValue>()
    {
      if (!itemPrefab.TryGetComponent<IOptionMenuItem<TValue>>(out var menuItem))
      {
        Debug.LogError($"Instantiate option menu item failed. Not found component:{typeof(IOptionMenuItem<TValue>)} in prefab:{itemPrefab.name})");
        return null;
      }

      menuItem = Instantiate(itemPrefab, itemsRoot).GetComponent<IOptionMenuItem<TValue>>();
      

      return menuItem;
    }
  }
}