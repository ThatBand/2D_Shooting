using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntro : MonoBehaviour
{
    public Vector3 startPos = new Vector3(0, -10, 0);
    public Vector3 targetPos = new Vector3(0, -4, 0);

    public float flyDur = 1;

    private PlayerShooter shooter;
    private PlayerMove move;

    private void Awake()
    {
        shooter = GetComponent<PlayerShooter>();
        move = GetComponent<PlayerMove>();

        shooter.enabled = false;
        move.enabled = false;

        transform.position = startPos;
    }

    public IEnumerator FlyInSequence()
    {
        float timer = 0;

        while (timer < flyDur)
        {
            timer += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, timer / flyDur);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }

        transform.position = targetPos;

        shooter.enabled = true;
        move.enabled = true;
    }
}
