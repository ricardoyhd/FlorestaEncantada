using UnityEngine;
using UnityEngine.UI;

public class ImageControl : MonoBehaviour
{
    public Image LeftImageBox, RightImageBox;
    public Image EndingBackground;
    public Sprite[] animalArray;
    public Sprite[] backgroundArray;
    public void SetLeftAnimalImage(int index){
        LeftImageBox.sprite = animalArray[index];
    }
    public void SetRightAnimalImage(int index){
        RightImageBox.sprite = animalArray[index];
    }
    public void SetEndingBackgroundImage(int index){
        EndingBackground.sprite = backgroundArray[index];
    }
}
