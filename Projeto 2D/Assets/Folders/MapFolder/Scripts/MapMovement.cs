using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Movimentacao do mapPlayer
/// </summary>
public class MapMovement : MonoBehaviour
{
    public GameObject bound;
    public GameObject map;
    public float scalex;
    public float scaley;
    public GameObject playerGameObject;
    public float positionx = 0;
    public float positiony = 0;

/// <summary>
/// Quando incia a cena:
/// </summary>
    private void Awake()
    {
        scalex = map.GetComponent<SpriteRenderer>().size.x / bound.GetComponent<Tilemap>().size.x; // Faz a conta da escala x ( Tamanho do mapa/Tamanho do Grid)
        scaley =map.GetComponent<SpriteRenderer>().size.y / bound.GetComponent<Tilemap>().size.y; // Faz a conta da escala y ( Tamanho do mapa/Tamanho do Grid)
        this.gameObject.transform.position = new Vector3((playerGameObject.transform.position.x) * scalex,
            (playerGameObject.transform.position.y )* scaley); // O player map comeca com a posicao do player * a escala + uma variavel
    }
    
    void Update()
    {
        this.gameObject.transform.position = new Vector3((playerGameObject.transform.position.x )* scalex,
            (playerGameObject.transform.position.y) * scaley); // O player map altera a posicao de acordo com a posicao do player * a escala + uma variavel

    }


}
