using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class NPCDialog : MonoBehaviour
{
    public UnityEvent OnStartDialog;

    [SerializeField]
    private GameObject dialogCanvas;

    [SerializeField]
    private TextMeshProUGUI title;

    [SerializeField]
    private TextMeshProUGUI message;

    [SerializeField]
    private Image image;

    [Space(10), SerializeField]
    private string titleText;

    [TextArea, SerializeField]
    private string messageText;

    [SerializeField]
    private Sprite sprite;

    [Space(10), SerializeField]
    private string tagToInteract;

    private void Start()
    {
        dialogCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToInteract))
        {
            OnStartDialog?.Invoke();

            title.text = titleText;
            message.text = messageText;
            image.sprite = sprite;

            dialogCanvas.SetActive(true);
        }

    }



}
