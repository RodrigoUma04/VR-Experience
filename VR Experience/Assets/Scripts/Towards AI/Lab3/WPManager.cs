using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Link
{

    public enum direction
    {

        UNI,
        BI
    }

    public GameObject node1, node2;
    public direction dir;
}

public class WPManager : MonoBehaviour
{

    public GameObject[] waypoints;
    public Link[] links;
    public Graph graph = new Graph();
    private GameObject selectedWaypoint;
    public Transform tank;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            foreach (GameObject wp in waypoints)
            {
                graph.AddNode(wp);

                foreach (Link l in links)
                {
                    graph.AddEdge(l.node1, l.node2);
                    if (l.dir == Link.direction.BI)
                        graph.AddEdge(l.node2, l.node1);
                }
            }
        }

        TMP_Dropdown dropdown = Object.FindFirstObjectByType<TMP_Dropdown>();
        if (dropdown != null)
        {
            dropdown.onValueChanged.AddListener(OnWaypointSelected);
            PopulateDropdown();
        }
    }

    void PopulateDropdown()
    {
        TMP_Dropdown dropdown = Object.FindFirstObjectByType<TMP_Dropdown>();
        dropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> optionDataList = new List<TMP_Dropdown.OptionData>();

        for (int i = 0; i < waypoints.Length; i++)
            optionDataList.Add(new TMP_Dropdown.OptionData("Waypoint " + (i + 1)));

        dropdown.AddOptions(optionDataList);
    }

    void OnWaypointSelected(int index)
    {
        if (index >= 0 && index < waypoints.Length)
        {
            selectedWaypoint = waypoints[index];
            Debug.Log("Selected waypoint: " + selectedWaypoint.name);
            StartCoroutine(MoveTankToWaypoint(selectedWaypoint));
        }
    }

    Node FindClosestWaypoint()
    {
        Node closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject wpGO in waypoints)
        {
            float dist = Vector3.Distance(tank.position, wpGO.transform.position);
            Node n = graph.FindNode(wpGO);
            if (dist < minDist)
            {
                minDist = dist;
                closest = n;
            }
        }

        return closest;
    }

IEnumerator MoveTankToWaypoint(GameObject target)
    {
        Node startNode = FindClosestWaypoint();
        if (startNode == null)
        {
            Debug.LogError("No start waypoint found near the tank!");
            yield break;
        }

        bool pathFound = graph.AStar(startNode.getID(), target);
        if (!pathFound)
        {
            Debug.LogWarning("No path found to target!");
            yield break;
        }

        foreach (Node n in graph.pathList)
        {
            Vector3 targetPos = n.getID().transform.position;

            while (Vector3.Distance(tank.position, targetPos) > 0.1f)
            {
                tank.position = Vector3.MoveTowards(tank.position, targetPos, 5f * Time.deltaTime);

                Vector3 direction = (targetPos - tank.position).normalized;
                if (direction != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    tank.rotation = Quaternion.Slerp(tank.rotation, lookRotation, 5f * Time.deltaTime);
                }

                yield return null;
            }
        }

        Debug.Log("Reached target waypoint: " + target.name);
    }
}
