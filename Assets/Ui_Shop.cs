using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemple;
    private IShopCostumer shopCustomer;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemple = container.Find("shopItemTemplate");
        shopItemTemple.gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    private void CreateItemButton(Item.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemReactTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 30f;
        shopItemReactTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite=itemSprite;

        shopItemTransform.GetComponent<Button_UI>()ClickFun = () =>
        {
            TryBuyItem(itemType);
        };
    }
    private void TryBuyItem(ContextMenuItemAttribute.ItemType itemType)
    {
        shopCustomer.BoughtItem(itemType);
    }
   
    public void show (IShopCustomer shopCustomer)
    {
        this shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        GameObject.SetActive(false);
    }

}
