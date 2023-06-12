using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickyplatform : MonoBehaviour
{
    // Start is called before the first frame update
    private void OncollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OncollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
