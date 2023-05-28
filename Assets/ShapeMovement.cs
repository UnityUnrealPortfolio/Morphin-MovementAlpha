using UnityEngine;
using PathCreation;
public class ShapeMovement : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction end;
    public float speed;
    float dstTravelled;

    private void Start()
    {
        transform.position = pathCreator.path.GetPoint(0);
    }
    void Update()
    {
        dstTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(dstTravelled, end);
        transform.rotation = pathCreator.path.GetRotationAtDistance(dstTravelled, end);
    }
}
