using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System;

using UnityEditor;



public class ObjProp : MonoBehaviour
{
    private string connString;
    public GameObject[] objects;
    public string id;
    public string s;
    SqlConnection conn;
    public Text infotext;
    string objectId = null;
    List<string> param = new List<string>();
    List<string> ListofTable = new List<string>();
    private Vector2 ScrollPos;
    public GameObject selobj;
    //public string highscoreURL = "http://localhost:8080/aa.php?elementid=145999";
    public string highscoreURL = "http://localhost:8082/aa.php?";
    void Start()
    {

    }
    WWW hs_get;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            //turning a screen point to a ray.. camera ---> mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                // to get the ElementId alone from the object name
                var obj = hit.collider.gameObject;
                var objName = hit.collider.gameObject.name;
                var lastString = objName.Split(' ').Last();
                Debug.Log("Name of the object:" + objName);
                objectId = lastString.Trim(new char[] { '[', ']' });
                Debug.Log(objectId);
                SelectObject(obj);
            }
            StartCoroutine(GetScores());
            IEnumerator GetScores()
            {
                hs_get = new WWW(highscoreURL + "elementid=" + objectId);
                //   Debug.Log(highscoreURL + "elementid=" + objectId);
                yield return hs_get;
                Debug.Log(hs_get.text);
                splitString();

            }

            if (Input.GetMouseButtonDown(2))
            {
                param.Clear();
            }
        }
    }

    private void splitString()
    {
        param.Clear();
        string[] objp = hs_get.text.Split('|');
        for (int i = 0; i < objp.Length; i++)
        {
            string[] Userresult = objp[i].Split(',');
            param.Add(Userresult[0]); 
        }
    }

    void SelectObject(GameObject obj)
    {

        if (selobj != null)
        {
            if (obj == selobj)
                return;

            ClearSelection();
        }
        selobj = obj;

        Renderer[] rend = selobj.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rend)
        {
            Material mat = r.material;
            mat.color = Color.red;
            r.material = mat;
        }
    }

    void ClearSelection()
    {
        if (selobj == null)
            return;
        Renderer[] rend = selobj.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rend)
        {
            Material mat = r.material;
            mat.color = Color.white;
            r.material = mat;
        }
    }

    public void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 900));
        GUILayout.Label("Object Properties:");
        ScrollPos = GUILayout.BeginScrollView(ScrollPos, GUILayout.Width(300), GUILayout.Height(900));
        if (param.Count > 0)
        {
            for (int k = 0; k < param.Count; k++)
            {
                GUILayout.BeginVertical();
                GUILayout.Label(param[k]);
            }
            GUILayout.EndVertical();
        }
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }
}
