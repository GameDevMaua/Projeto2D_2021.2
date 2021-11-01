using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Classe para clicar, arrastar e deixar um gameobject no canvas
/// </summary>
public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    [SerializeField] private Canvas canvas;

    public DuplicateGameObject duplicateGameObject;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
 
    /// <summary>
    /// Toda vez que comeca a cena pega os componentes RectTransform e CanvasGroup
    /// </summary>
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// Quando comeca a arrastar, o gameobject fica mais transparente
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    /// <summary>
    /// Termina de arrastar o gameobject, voltando para a opacidade de sempre
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    
    /// <summary>
    /// Toda Vez que abaixar o botao do mouse, clona esse gameobject
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if(duplicateGameObject != null)
            duplicateGameObject.Duplicate();
    }

    /// <summary>
    /// Toda a vez que está arrastando com o mouse, ele altera a posicao desse de acordo com o canvas para arrastar junto com o mouse
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }
    
    /// <summary>
    /// Toda vez que aperta com o mouse 2 vezes rapidamente em um clone, destroi esse
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        int i = eventData.clickCount;
        if(i == 2 && this.gameObject.CompareTag("Clone"))
            Destroy(this.gameObject);
        
    }
}