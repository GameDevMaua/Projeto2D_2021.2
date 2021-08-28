using UnityEngine;
using UnityEngine.UI;


public class MainMenuAnimation : MonoBehaviour
{
    public Sprite[] animatedImages;
    public Image animateImageObj;
    void Update()
    {
        animateImageObj.sprite = animatedImages[(int) (Time.time*10) % animatedImages.Length];
    }
}
