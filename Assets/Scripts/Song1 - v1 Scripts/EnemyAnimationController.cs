using UnityEngine;

public class EnemyAnimationController : MonoBehaviour, IEnemyAnimationController
{
    public Animator anim;

    private void Awake()
    {
        anim = this.GetComponent<Animator>();
    }
    public void EnemyHit()
    {
        anim.SetTrigger("Hit");
    }
}
