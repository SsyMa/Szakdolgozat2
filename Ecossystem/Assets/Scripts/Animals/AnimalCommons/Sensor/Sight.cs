using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Sight : Sensor
{
    //Animal
    Animal animal;

    //Sight variables
    int scanFrequency;
    float scanInterval;
    float scanTimer;

    //Collisions
    public List<Collider> colliders;
    Mesh mesh;
    MeshCollider meshCollider;
    MeshCollider mc;

    //Tracking
    GameObject objectToTrack;

    //Sight Object
    GameObject wedgeObject;
    SightObject sightObject;

    // Start is called before the first frame update
    void Start()
    {
        //Animal
        animal = gameObject.GetComponent<Animal>();

        //Sight variables
        scanFrequency = 20;
        scanInterval = 1.0f / scanFrequency;


        //Collisions
        colliders = new List<Collider>();
        mc = gameObject.GetComponentInChildren<MeshCollider>();
        

        //Tracking
        objectToTrack = null;

        CreateWedgeObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        scanTimer -= Time.deltaTime;
        if (scanTimer < 0 && !objectToTrack)
        {
            scanTimer += scanInterval;
            objectToTrack = Scan();
        }
        if (objectToTrack)
        {
            Vector3 cPos = objectToTrack.transform.position;
            Vector3 tPos = transform.position;
            Torque = -Vector3.SignedAngle(cPos - tPos, transform.forward, Vector3.up) * animal.TorqueMultiplier;
            Acceleration = animal.AccelerationMultiplier;
        }
        else
        {
            Torque = 0;
            Acceleration = 0;
        }
    }

    private void CreateWedgeObject()
    {
        wedgeObject = new("Wedge");
        wedgeObject.transform.parent = transform;
        wedgeObject.transform.localPosition = Vector3.zero;
        wedgeObject.transform.localRotation = new(0, 0, 0, 0);
        wedgeObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        meshCollider = wedgeObject.AddComponent<MeshCollider>();
        meshCollider.convex = true;
        meshCollider.isTrigger = true;
        mesh = CreateWedgeMesh();
        meshCollider.sharedMesh = mesh;
        sightObject = wedgeObject.AddComponent<SightObject>();
    }

    public void RecreateWedgeMesh()
    {
        if (animal)
        {
            mesh = CreateWedgeMesh();
            meshCollider.sharedMesh = mesh;
        }
    }

    private GameObject Scan()
    {
        float distance = float.MaxValue;
        Transform t = transform;
        Vector2 tPos = new(t.position.x, t.position.z);
        foreach (Collider c in SelectColliders())
        {
            Vector3 cWorldPos = c.gameObject.transform.position;
            Vector2 cPos = new(cWorldPos.x, cWorldPos.z);
            float cDistance = CalculateDistance(tPos, cPos);
            if (distance > cDistance)
            {
                distance = cDistance;
                objectToTrack = c.gameObject;
            }
        }
        return objectToTrack;
    }

    private float CalculateDistance(Vector2 t, Vector2 c)
    {
        return Vector2.Distance(t, c);
    }

    private List<Collider> SelectColliders()
    {
        List<Collider> selected = new();
        if(sightObject == null) return selected;
        foreach(Collider collider in sightObject.GetColliders())
        {
            foreach (string tag in animal.diet)
            {
                if (collider.gameObject.CompareTag(tag))
                {
                    if ((tag == "animal") && (collider.gameObject.GetComponent<Animal>().animalName == animal.animalName))
                    {
                        continue;
                    }
                    selected.Add(collider);
                }
            }
        }
        return selected;
    }

    Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();

        int segments = 12;
        int numTriangles = segments * 4 + 4;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 depth = new Vector3(0, animal.SightDepth, 0);
        Vector3 height = new Vector3(0, animal.SightHeight, 0);

        Vector3 bottomCenter = new(0, 0, 0);
        Vector3 bottomLeft = Quaternion.Euler(0, -animal.FovHorizontal / 2, 0) * Vector3.forward * animal.ViewDistance - depth;
        Vector3 bottomRight = Quaternion.Euler(0, animal.FovHorizontal / 2, 0) * Vector3.forward * animal.ViewDistance - depth;

        Vector3 topCenter = new(0, 0.6f, 0);
        Vector3 topLeft = bottomLeft + depth + height;
        Vector3 topRight = bottomRight + depth + height;

        int vert = 0;
        //Left
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;
        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;
        //Right
        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;
        vertices[vert++] = topRight;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomCenter;

        float currAngle = -animal.FovHorizontal / 2;
        float angleChange = animal.FovHorizontal / segments;
        for (int i = 0; i < segments; ++i)
        {
            bottomLeft = Quaternion.Euler(0, currAngle, 0) * Vector3.forward * animal.ViewDistance - depth;
            bottomRight = Quaternion.Euler(0, currAngle + angleChange, 0) * Vector3.forward * animal.ViewDistance - depth;
            
            topLeft = bottomLeft + depth + height;
            topRight = bottomRight + depth + height;

            vertices[vert++] = bottomLeft;
            vertices[vert++] = bottomRight;
            vertices[vert++] = topRight;
            vertices[vert++] = topRight;
            vertices[vert++] = topLeft;
            vertices[vert++] = bottomLeft;

            vertices[vert++] = topCenter;
            vertices[vert++] = topLeft;
            vertices[vert++] = topRight;

            vertices[vert++] = bottomCenter;
            vertices[vert++] = bottomRight;
            vertices[vert++] = bottomLeft;

            currAngle += angleChange;
        }

        for (int i = 0; i < numVertices; ++i)
        {
            triangles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    private void OnDrawGizmos()
    {
        if (mesh)
        {
            Color c = Color.white;
            c.a = 0.5f;
            Gizmos.color = c;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }
    }
}
