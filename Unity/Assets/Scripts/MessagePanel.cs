using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePanel : MonoBehaviour {

    private void Start()
    {
        Vector3 pos = transform.position;
        pos.x += Random.Range(-100f, 1000f);

        transform.position = pos;
    }
    // Update is called once per frame
    void Update () {

        Vector3 pos = transform.position;
        pos.y += 3.0f;

        gameObject.transform.position = pos;

        if(transform.position.y >= 850f)
        {
            Destroy(gameObject);
        }

	}
}
