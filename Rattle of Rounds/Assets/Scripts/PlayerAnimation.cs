using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    // References
    Animator an;
    PlayerMovement pm;
    SpriteRenderer sr;

    void Awake()
    {
        an = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector2 dir = pm.moveDir;

        bool moving = dir.sqrMagnitude > 0.0001f;
        an.SetBool("Move", moving);

        HandleFlip(dir, moving);
    }

    void HandleFlip(Vector2 dir, bool moving)
    {
        if (!moving) return;

        if (Mathf.Abs(dir.x) > 0.001f)
            sr.flipX = dir.x < 0f;
    }

}
