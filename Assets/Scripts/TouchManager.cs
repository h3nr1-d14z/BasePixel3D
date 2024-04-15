


using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchManager : MonoBehaviour
{
    private RaycastHit hit;

    private Camera cam;

    private Vector3 startPosition;

    private bool isClick;

    private string nameHint;

    private void Awake()
    {
        this.cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update1()
    {
        if (!Physics.Raycast(this.cam.ScreenPointToRay(Input.mousePosition), out this.hit))
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) && !this.isClick)
        {
            this.isClick = true;
            this.startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        bool hasMouseUp = true;
        if (Input.GetMouseButtonUp(0))
        {
            hasMouseUp = false;
            this.isClick = false;
            Vector3 b = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!(Math.Abs(Vector3.Distance(this.startPosition, b)) > 5f))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    UnityEngine.Debug.Log("Clicked on the UI");
                }
                else if (this.hit.collider.tag == VoxConstants.Tag)
                {
                    VoxCubeItem component = ((Component)this.hit.transform).GetComponent<VoxCubeItem>();
                    if (component != null)
                    {
                        component.TochCubeItem();
                    }
                }
                hasMouseUp = true;
            }
            return;
        }
        if (hasMouseUp)
        {
            if (UnitySingleton<GameController>.Instance.IsLongClick)
            {
                Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    UnityEngine.Debug.Log("Clicked on the UI");
                }
                else if (this.hit.collider.tag == VoxConstants.Tag && !this.hit.collider.name.Equals(this.nameHint))
                {
                    this.nameHint = this.hit.collider.name;
                    VoxCubeItem component2 = ((Component)this.hit.transform).GetComponent<VoxCubeItem>();
                    if (component2 != null)
                    {
                        component2.TochCubeItem();
                    }
                }
            }
        }
    }

    public void CheckCube(Vector2 touchPos, bool isVibro = true)
    {
        if (!GameScene.Instance.isUsingBoom)
        {
            if (Physics.Raycast(this.cam.ScreenPointToRay(touchPos), out this.hit) && this.hit.collider.tag == VoxConstants.Tag)
            {
                VoxCubeItem component = ((Component)this.hit.transform).GetComponent<VoxCubeItem>();
                if (component != null)
                {
                    if (!GameScene.Instance.isUsingWand)
                    {
                        int num = component.TochCubeItem();
                        if (num >= 0)
                        {
                            if (num > 0)
                            {
                                Debug.Log("OnCubeColored" + component.ColorIndex);
                                UnitySingleton<GameController>.Instance.OnCubeColored(component.ColorIndex);
                                UnitySingleton<GameController>.Instance.SetCubeItemProgress(component);
                            }
                            if (isVibro)
                            {
                                if (num > 0)
                                {
                                    VibroWrapper.PlayVibroRight();
                                }
                                else
                                {
                                    VibroWrapper.PlayVibroWrong();
                                    DailyGame.IncresetError();
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (VoxCubeItem voxCubeItem in GameController.Instance.VoxCubeItems)
                        {
                            if (voxCubeItem.ColorIndex == component.ColorIndex && !voxCubeItem.isColored)
                            {
                                Debug.Log("voxCubeItem.isColored = " + voxCubeItem.name + "  " + voxCubeItem.isColored);
                                UnitySingleton<GameController>.Instance.OnCubeColored(voxCubeItem.ColorIndex);
                                UnitySingleton<GameController>.Instance.SetCubeItemProgress(voxCubeItem);
                                voxCubeItem.SetSuccessColorCube();
                            }
                        }
                    }
                }
            }
        }
        else
        {

            //List<Vector2> rayPosList = new List<Vector2>();
            //rayPosList = CreateCircularGrid(touchPos, 6, 30, 10f);
            //Debug.Log("rayPosList.Count : " + rayPosList.Count);
            //         foreach (var pos in rayPosList)
            //         {
            //	if (Physics.Raycast(this.cam.ScreenPointToRay(pos), out this.hit) && this.hit.collider.tag == VoxConstants.Tag)
            //	{
            //		VoxCubeItem component = ((Component)this.hit.transform).GetComponent<VoxCubeItem>();

            //		if (component == null)
            //			return;

            //		if (!component.isColored)
            //		{
            //			UnitySingleton<GameController>.Instance.OnCubeColored(component.ColorIndex);
            //			UnitySingleton<GameController>.Instance.SetCubeItemProgress(component);
            //			component.SetSuccessColorCube();
            //		}
            //	}
            //}
            if (Physics.Raycast(this.cam.ScreenPointToRay(touchPos), out this.hit) && this.hit.collider.tag == VoxConstants.Tag)
            {
                VoxCubeItem component = ((Component)this.hit.transform).GetComponent<VoxCubeItem>();
                if (component != null)
                {
                    CreateSphereCollider(hit.transform.position, GameScene.Instance.boomRadius);
                }
            }
        }
    }

    private SphereCollider sphereCollider;
    void CreateSphereCollider(Vector3 pos, float radius)
    {
        Debug.Log("CreateSphereCollider : " + pos);

        GameScene.Instance.boomCollider.transform.localPosition = pos;
        sphereCollider = GameScene.Instance.boomCollider.AddComponent<SphereCollider>();
        sphereCollider.radius = radius;

        CheckCollision(pos);
    }

    void CheckCollision(Vector3 pos)
    {
        Collider[] colliders = Physics.OverlapSphere(pos, sphereCollider.radius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag != VoxConstants.Tag)
                continue;

            VoxCubeItem component = collider.GetComponent<VoxCubeItem>();
            if (component == null)
                continue;

            if (!component.isColored)
            {
                UnitySingleton<GameController>.Instance.OnCubeColored(component.ColorIndex);
                UnitySingleton<GameController>.Instance.SetCubeItemProgress(component);
                component.SetSuccessColorCube();
            }
        }
    }

    //private List<Vector2> CreateCircularGrid(Vector2 inputPoint, int numberOfCircles, int pointsPerCircle, float circleRadius)
    //{
    //	List<Vector2> list = new List<Vector2>();

    //	for (int circleIndex = 0; circleIndex < numberOfCircles; circleIndex++)
    //	{
    //		float angleIncrement = 360f / pointsPerCircle;

    //		for (int pointIndex = 0; pointIndex < pointsPerCircle; pointIndex++)
    //		{
    //			float angle = pointIndex * angleIncrement;
    //			float x = inputPoint.x + Mathf.Cos(Mathf.Deg2Rad * angle) * circleRadius * (circleIndex + 1);
    //			float y = inputPoint.y + Mathf.Sin(Mathf.Deg2Rad * angle) * circleRadius * (circleIndex + 1);

    //			Vector2 circularPoint = new Vector2(x, y);
    //			list.Add(circularPoint);
    //		}
    //	}

    //	return list;
    //}
}


