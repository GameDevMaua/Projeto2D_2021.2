using UnityEngine;

/// <summary>
/// Comandos que são usados no mapa
/// </summary>
public class Map : MonoBehaviour
{

    public KeyCode mapKey = KeyCode.Tab;
    private int countMapKey = 0;
    public Camera camera;
    public GameObject player;
    public GameObject map;
    public GameObject mapPlayerGameObject;
    private Transform mapTransform;
    private Transform playerTransform;
    public Canvas canvas;

    /// <summary>
    /// Quando inicia o script:
    /// </summary>
    public void Start()
    {
        mapTransform = map.GetComponent<Transform>(); // pega o componente transform
        playerTransform = player.GetComponent<Transform>(); // pega o componente transform
        camera.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10); // Altera a posicao da camera para o player
        camera.transform.SetParent(playerTransform); // A camera vira filha do player
        map.transform.position = mapPlayerGameObject.transform.position; // O mapa vai para a posicao do playerMap
        canvas.enabled = false; // Canvas inicia desativado
    }

    /// <summary>
    /// Quando pressiona conta mais um
    /// </summary>
    private void mapKeyPressed()
    {
        countMapKey++;
    }
    void Update()
    {
        // Quando o contador for zero e pressionar o botao mapa
        if (Input.GetKeyDown(mapKey) && countMapKey == 0)
        {

            mapKeyPressed(); // Contador conta mais um
            camera.transform.position = new Vector3(map.transform.position.x,map.transform.position.y,-10); // Camera vai na posicao do map
            camera.transform.SetParent(mapTransform); // Camera vira filha do mapa
            canvas.enabled = true; // Canvas e ativado

        }
        
        // Quando o contador for 1 e estiver apertando o botao mapa
        else if (Input.GetKeyDown(mapKey) && countMapKey == 1)
        {
            countMapKey = 0; // Contador zera
            camera.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10); // Camera vai na posicao do player
            camera.transform.SetParent(playerTransform); // Camera vira filha do player
            canvas.enabled = false; // Canvas e desativado
   
        }
    }
}