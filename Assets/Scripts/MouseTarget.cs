using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] RectTransform crosshair;
    [SerializeField] RectTransform parent;
    [SerializeField] Canvas canvas;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 target;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, Input.mousePosition, null, out target);
        crosshair.anchoredPosition = target; 
    }
}
