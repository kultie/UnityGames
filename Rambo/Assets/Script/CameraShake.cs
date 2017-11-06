using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    public float timeShake;
    public float shakeAmt = 0.05f;
    public float kickBackAmt = 0.5f;
    Vector3 cameraOriginalPos;
    public void StartShake()
    {
        InvokeRepeating("Shake", 0, .01f);
        Invoke("StopShaking", timeShake);
    }
    private void Start()
    {
        cameraOriginalPos = Camera.main.transform.position;
    }
    void Shake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 withOffSet = Camera.main.transform.position;
            // vertical shake
            withOffSet.x += quakeAmt * Random.Range(-1,1);
            withOffSet.y += quakeAmt * Random.Range(-1,1);
            Camera.main.transform.position = withOffSet;
        }
    }

    void StopShaking()
    {
        CancelInvoke("Shake");
        Camera.main.transform.position = cameraOriginalPos;
    }

    // camera kick, opposite of firing direction
    public void CameraKick(int dir)
    {
        Vector3 withOffSet = Camera.main.transform.position;
        withOffSet.x += -dir * kickBackAmt;
        Camera.main.transform.position = withOffSet;
    }
}
