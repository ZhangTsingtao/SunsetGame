using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorManager : MonoBehaviour
{
    public ItemController[] ItemButtons;
    public GameObject[] ItemPrefabs;
    public GameObject[] ItemImages;
    public int CurrentButtonPressed;

    public GameObject ItemImage;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && ItemButtons[CurrentButtonPressed].Clicked)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                ItemButtons[CurrentButtonPressed].Clicked = false;
                Instantiate(ItemPrefabs[CurrentButtonPressed], hit.point, Quaternion.identity);

                //Destroy the image
                if(ItemImage  != null)
                {
                    Destroy(ItemImage);
                }
            }
        }
    }
}
