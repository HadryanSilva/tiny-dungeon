using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public UnityEvent OnStartDialog;

    [SerializeField]
    protected GameObject dialogCanvas;

    [SerializeField]
    protected TextMeshProUGUI title;

    [SerializeField]
    protected TextMeshProUGUI message;

    [SerializeField]
    protected Image image;

    [Space(10), SerializeField]
    protected string titleText;

    [TextArea, SerializeField]
    protected string messageText;

    [SerializeField]
    protected Sprite sprite;

    private void Start()
    {
        dialogCanvas.SetActive(false);
    }
}
