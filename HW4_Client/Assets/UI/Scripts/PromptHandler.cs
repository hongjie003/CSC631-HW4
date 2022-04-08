using UnityEngine;

public class PromptHandler : MonoBehaviour
{
    [SerializeField] GameObject prompt;
    [SerializeField] GameObject overlay;

    public void SetActive()
    {
        if (prompt)
        {
            prompt.SetActive(true);
        }

        if (overlay)
        {
            overlay.SetActive(true);
        }
    }

    public void SetDeactive()
    {
        if (prompt)
        {
            prompt.SetActive(false);
        }

        if (overlay)
        {
            overlay.SetActive(false);
        }
    }
}
