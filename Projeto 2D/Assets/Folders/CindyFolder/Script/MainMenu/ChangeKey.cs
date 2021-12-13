using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeKey : MonoBehaviour
{
    public BindKey bindKey;
    private bool isCoroutineExecuting = false;
    public float time;
 
    /// <summary>
    /// Essa corrotina permite que de um delay antes de voltar a navegar nos botoes.
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;
 
        isCoroutineExecuting = true;
 
        yield return new WaitForSeconds(time);
        EventSystem.current.sendNavigationEvents = true;
 
        isCoroutineExecuting = false;
    }
    
    /// <summary>
    /// Caso o i da classe BindKey for maior que i, ele desativa a imagem e executa a corotina
    /// </summary>
    private void Update()
    {
        if (bindKey.i >= 1)
        {
            bindKey.changeKeyBind.changeButtonImage.SetActive(false);
            StartCoroutine(ExecuteAfterTime(time));

        }
    }
}
