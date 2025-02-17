using UnityEngine;
public class ButtonHover : MonoBehaviour
{
    public GameObject infoBox;
    public GameObject imageBox, otherImageBox;
    public RectTransform buttonRectTransform;

    void Update()
    {
        if (IsMouseOverButton(buttonRectTransform))
        {
            infoBox.SetActive(true);
            otherImageBox.SetActive(false);
        }
        else
        {
            infoBox.SetActive(false);
            otherImageBox.SetActive(true);
        }
    }
    bool IsMouseOverButton(RectTransform buttonRect)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(buttonRect, Input.mousePosition, null, out localPoint);

        return buttonRect.rect.Contains(localPoint);
    }
}
