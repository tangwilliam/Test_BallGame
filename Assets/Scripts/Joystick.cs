using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler,IPointerDownHandler {

    private Image containerImg;
    private Image joyStickImg;

    public Vector3 InputDirection { set; get; }


    private void Start()
    {
        containerImg = GetComponent<Image>();
        joyStickImg = transform.GetChild(0).GetComponent<Image>();

        InputDirection = Vector3.zero;
    }

    public virtual void OnDrag( PointerEventData ped )
    {
        
        Vector2 pos = Vector2.zero;

        if( RectTransformUtility.ScreenPointToLocalPointInRectangle(
            containerImg.rectTransform,
            ped.position,
            ped.pressEventCamera,
            out pos 
        ) ){

            //Debug.Log("pos = " + pos + "    sizeDelta = " + containerImg.rectTransform.sizeDelta );

            pos.x = pos.x / containerImg.rectTransform.sizeDelta.x;
            pos.y = pos.y / containerImg.rectTransform.sizeDelta.y;

            float x = (containerImg.rectTransform.pivot.x == 1 ) ? 2 * pos.x + 1 : 2 * pos.x - 1;
            float y = (containerImg.rectTransform.pivot.y == 1) ? 2 * pos.y + 1 : 2 * pos.y - 1;


            InputDirection = new Vector3(x, 0, y);
            InputDirection = InputDirection.magnitude > 1.0f ? InputDirection.normalized : InputDirection;

            joyStickImg.rectTransform.anchoredPosition = new Vector2(InputDirection.x * (containerImg.rectTransform.sizeDelta.x / 3),
                                                                     InputDirection.z * (containerImg.rectTransform.sizeDelta.y / 3));


        }
    }

    public virtual void OnPointerDown( PointerEventData ped )
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp( PointerEventData ped)
    {
        InputDirection = Vector3.zero;
        joyStickImg.rectTransform.anchoredPosition = Vector2.zero;
    }
}
