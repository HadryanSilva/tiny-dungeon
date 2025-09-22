using UnityEngine;

public class LevelDialog : Dialog
{
    public void Show()
    {
        OnStartDialog?.Invoke();

        title.text = titleText;
        message.text = messageText;
        image.sprite = sprite;

        dialogCanvas.SetActive(true);
    }
}
