using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemController : MonoBehaviour
{
    public int ID;
    public int quantity;
    public TextMeshProUGUI quantityText;
    public bool Clicked = false;

    private Button _button;
    private LevelEditorManager _editor;
    void Start()
    {
        quantityText.text = quantity.ToString();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClicked);
        _editor = GameObject.FindGameObjectWithTag("LevelEditorManager").
            GetComponent<LevelEditorManager>();
    }

    public void ButtonClicked()
    {
        if(quantity > 0)
        {
            //not clickable until placed, and change quantity left
            Clicked = true;
            quantity--;
            quantityText.text = quantity.ToString();

            //couple with LevelEditorManager
            _editor.CurrentButtonPressed = ID;

            //instantiate an image that follows the mouse
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _editor.ItemImage = Instantiate(_editor.ItemImages[ID], worldPos,
                GameObject.FindGameObjectWithTag("MainCamera").transform.rotation);
            _editor.ItemImage.transform.position = new Vector3(worldPos.x, worldPos.y, worldPos.z + 10);
            _editor.ItemImage.SetActive(true);

        }
    }

}
