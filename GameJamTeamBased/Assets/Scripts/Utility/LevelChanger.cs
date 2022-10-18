using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        animator.SetTrigger("FadeIn");
    }
}


