using UnityEngine;
using UnityEngine.UI;

/// <summary>
///Main Menu com um bacckground animado
/// </summary>
public class MainMenuAnimation : MonoBehaviour
{
    public Sprite[] animatedImages;
    public Image animateImageObj;
    void Update()
    {
        animateImageObj.sprite = animatedImages[(int) (Time.time*10) % animatedImages.Length];
    }
}
