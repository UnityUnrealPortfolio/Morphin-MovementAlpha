using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHoop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blob"))
        {
            //check blob shape state
            switch (other.GetComponent<BlobShape>().m_currentShapeState)
            {
                case ShapeState.Blob:
                    GameManager.instance.Score -= 10;
                    break;
                case ShapeState.Box:
                    GameManager.instance.Score += 15;
                    break;
                case ShapeState.Sphere:
                    GameManager.instance.Score -= 10;
                    break;
            }
        }
    }
}
