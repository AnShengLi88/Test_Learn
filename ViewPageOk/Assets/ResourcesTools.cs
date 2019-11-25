using UnityEngine;
using System.Collections;

public static class ResourcesTools {

//	public static GameObject CreateObject (string path_name) {
//
//		Object obj = Load (path_name);
//
//		return GameObject.Instantiate (obj) as GameObject;
//
//	}

	public static GameObject CreateObject (string path_name, Vector3 position = default(Vector3), Vector3 angle = default(Vector3)) {
	
		return GameObject.Instantiate(Load(path_name), position, Quaternion.Euler(angle)) as GameObject;
	
	}

	private static T CreateObjectT<T> (string path_name) where T : Component {
	
		return CreateObject(path_name).GetComponent<T>();
	
	}

//	public static T CreateObject<T> (string path_name, Vector3 pos) where T : MonoBehaviour {
//	
//		T t = CreateObject<T> (path_name);
//
//		t.transform.position = pos;
//
//		return t;
//	
//	}

	public static T CreateObject<T> (string path_name,  Vector3 pos = default(Vector3),  Vector3 angle = default(Vector3), Transform tranRoot = null)  where T : Component {

		T t = CreateObjectT<T> (path_name);

		t.transform.position = pos;
		t.transform.eulerAngles = angle;

		if (tranRoot != null) {
		
			t.transform.SetParent(tranRoot);
			t.transform.localPosition = Vector3.zero;

		}

		return t;

	}

	public static Object Load(string path_name) {
	
		//Debug.Log("Path_name:" + path_name);

		Object obj = null;

        obj = Resources.Load (path_name);

//		try {
//
//			obj = Resources.Load (path_name);
//
//		}catch(UnityException ex) {
//
//			Debug.LogError("Resoures error:" + ex);
//
//		}

		return obj;
	
	}

	public static T CreateObject<T> (GameObject _obj) where T : Component {
	
		GameObject obj = GameObject.Instantiate(_obj);
		obj.SetActive(true);
		return obj.GetComponent<T>();
	
	}

	public static T Inst<T> (GameObject _obj, Transform tranroot = null) where T : Component {

		GameObject obj = GameObject.Instantiate(_obj, tranroot);
		obj.transform.localScale = Vector3.one;
		obj.SetActive(true);
		return obj.GetComponent<T>();

	}

	public static void InstantiateGameObject(Object obj,Transform farTran, float Angle, float radius) {
	
		GameObject t_obj = GameObject.Instantiate(obj) as GameObject;
		t_obj.transform.parent = farTran;
		t_obj.transform.localPosition = Vector3.zero;
		t_obj.transform.localEulerAngles = new Vector3(0, 0, Angle);
		t_obj.transform.Translate(radius, 0, 0);
	
	}

	public static T Load<T> (string path_name) where T : Object {
	
		return Resources.Load<T> (path_name);
	
	}

	public static GameObject Instantiate(Object obj) {

		return  GameObject.Instantiate(obj) as GameObject;

	}

	public static GameObject Instantiate(GameObject obj, Vector3 pos) {

		return  GameObject.Instantiate(obj, pos, Quaternion.identity) as GameObject;

	}

	public static void ClearChildElement(Transform tran) {

		for(int i = tran.childCount - 1; i > -1; i--) {
		
			GameObject.DestroyImmediate(tran.GetChild(0).gameObject);
		
		}
	
	}
	                                          

}
