using UnityEngine;

public class MenuAnimator : MonoBehaviour, IMenuAnimator<string>
{
    [SerializeField] private Animator MainMenuAnim;

    private void Awake()
    {
        MainMenuAnim = GetComponent<Animator>();
    }

    public void AnimTriggerSet(string key)
    {
        MainMenuAnim.SetTrigger(key);
    }
}
