using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPrisonShield : MonoBehaviour
{
    [Header("쉴드 / 감옥 오브젝트")]
    public PrionsShield shield;
    public GameObject prison;
    public GameObject[] prisonObjs;

    private void OnEnable()
    {
        StartCoroutine(BreakPrison());
    }

    IEnumerator BreakPrison()
    {
        GameManager.instance.player.GetComponent<PlayerShooter>().enabled = false;
        GameManager.instance.player.GetComponent<PlayerMove>().StopPlayer();
        GameManager.instance.player.GetComponent<PlayerMove>().enabled = false;

        for (int i = 0; i < prisonObjs.Length; i++)
        {
            prisonObjs[i].transform.localScale = new Vector3(0.05f, 3, 0);
            yield return null;
        }

        float timer = 0;
        float dur = 4f;

        while (timer <= dur)
        {
            timer += Time.deltaTime;

            float t = timer / dur;

            prison.transform.position = Vector3.Lerp(prison.transform.position, GameManager.instance.boss.position, t);
            prison.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 0.2f, t);

            yield return null;
        }

        prison.transform.position = GameManager.instance.boss.position;
        prison.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        shield.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        shield.RotationShield();

        GameManager.instance.player.GetComponent<PlayerShooter>().enabled = true;
        GameManager.instance.player.GetComponent<PlayerMove>().enabled = true;
    }
}
