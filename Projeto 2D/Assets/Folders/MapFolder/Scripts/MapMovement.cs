using UnityEngine;

/// <summary>
/// Movimentacao do mapPlayer
/// </summary>
public class MapMovement : MonoBehaviour
{
    public RectTransform bound;
    public RectTransform map;
    private float scalex;
    private float scaley;
    public GameObject playerGameObject;
    public float positionx = 0;
    public float positiony = 0;

/// <summary>
/// Quando incia a cena:
/// </summary>
    private void Awake()
    {
        scalex = map.sizeDelta.x*map.localScale.x / bound.sizeDelta.x*map.localScale.x; // Faz a conta da escala x ( Tamanho do mapa/Tamanho do Grid)
        scaley = map.sizeDelta.y / bound.sizeDelta.y; // Faz a conta da escala y ( Tamanho do mapa/Tamanho do Grid)
        this.gameObject.transform.position = new Vector3(playerGameObject.transform.position.x * scalex + positionx,
            playerGameObject.transform.position.y * scaley+ positiony); // O player map comeca com a posicao do player * a escala + uma variavel

    }
    
    void Update()
    {
        this.gameObject.transform.position = new Vector3(playerGameObject.transform.position.x * scalex + positionx,
            playerGameObject.transform.position.y * scaley + positiony); // O player map altera a posicao de acordo com a posicao do player * a escala + uma variavel

    }


}
