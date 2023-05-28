using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobShape : MonoBehaviour
{
    [SerializeField] float valToSet = 0;
    [SerializeField] float morphSpeed;
    [SerializeField] float morphStateTime;
    [SerializeField] float timeInMorphedState;
    public ShapeState m_currentShapeState;
    SkinnedMeshRenderer skinnedMeshRenderer;
    SwipeInputHandler swipeInputHandler;
  
    public bool isShapeActivated = false;//ToDo:public for testing
    Shapes activeShape;
    private void Awake()
    {
        swipeInputHandler = FindAnyObjectByType<SwipeInputHandler>();
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    private void OnEnable()
    {
        swipeInputHandler.OnShapeMorph += HandleShapeMorph;
    }

    private void Start()
    {
        timeInMorphedState = morphStateTime;
    }
    public void HandleShapeMorph(Shapes shape)
    {
        isShapeActivated = true;
        activeShape = shape;
    }

    private void Update()
    {
        if (isShapeActivated == true)
        {
            
            valToSet += morphSpeed;
            if(valToSet >= 100f)
            {
                valToSet = 100f;
               
            }
            switch (activeShape)
            {
                case Shapes.Cube:
                    skinnedMeshRenderer.SetBlendShapeWeight(0, valToSet);
                    skinnedMeshRenderer.SetBlendShapeWeight(1, 0);
                    skinnedMeshRenderer.SetBlendShapeWeight(2, 0);

                    if (valToSet >= 100f)
                    {
                        m_currentShapeState = ShapeState.Box;
                    }
                    else
                    {
                        m_currentShapeState = ShapeState.Blob;

                    }
                    timeInMorphedState -= Time.deltaTime;

                    if (timeInMorphedState < 0)
                    {
                        
                        isShapeActivated = false;
                        
                    }
                    break;
                case Shapes.Cylinder:
                    skinnedMeshRenderer.SetBlendShapeWeight(1,valToSet);
                    skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
                    skinnedMeshRenderer.SetBlendShapeWeight(2, 0);

                    if(valToSet >= 100f)
                    {
                        m_currentShapeState = ShapeState.Cylinder;
                    }
                    else
                    {
                        m_currentShapeState = ShapeState.Blob;

                    }
                    timeInMorphedState -= Time.deltaTime;

                    if (timeInMorphedState < 0)
                    {
                      
                        isShapeActivated = false;
                    }
                    break;

                case Shapes.Sphere:
                    skinnedMeshRenderer.SetBlendShapeWeight(2, valToSet);
                    skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
                    skinnedMeshRenderer.SetBlendShapeWeight(1, 0);

                    if (valToSet >= 100f)
                    {
                        m_currentShapeState = ShapeState.Sphere;
                    }
                    else
                    {
                        m_currentShapeState = ShapeState.Blob;

                    }
                    timeInMorphedState -= Time.deltaTime;

                    if (timeInMorphedState < 0)
                    {

                        isShapeActivated = false;
                    }
                    break;

            }


        }
        if (isShapeActivated == false)
        {
            valToSet -= morphSpeed;
            if (valToSet < 0)
            {
                valToSet = 0;
            }
            skinnedMeshRenderer.SetBlendShapeWeight(0, valToSet);
            skinnedMeshRenderer.SetBlendShapeWeight(1, valToSet);
            skinnedMeshRenderer.SetBlendShapeWeight(2, valToSet);
            m_currentShapeState = ShapeState.Blob;
            timeInMorphedState = morphStateTime;
        }

    }
   
}

public enum ShapeState
{
    Sphere,Box,Cylinder,Blob
}
