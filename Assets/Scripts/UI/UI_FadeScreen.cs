using UnityEngine;

public class UI_FadeScreen : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public void FadeOut() 
    {
        anim.ResetTrigger("FadeIn");
        anim.SetTrigger("FadeOut");
    }

    public void FadeIn()
    {
        anim.ResetTrigger("FadeOut");
        anim.SetTrigger("FadeIn");
    }
}
