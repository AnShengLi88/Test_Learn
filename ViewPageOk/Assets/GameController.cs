using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    //[SerializeField]
    //private Text pageNumber;
    //[SerializeField]
    //private InputField inputField;
    public Transform toggleList;
    public RectTransform content;
    public List<AlbumItem> AlbumList = new List<AlbumItem>();
    private List<GameObject> ToggleLiat = new List<GameObject>();
    [SerializeField]
    private PageView pageView;
    private int TexIndex = 0;
    // Use this for initialization
    void Start()
    {
        //pageNumber.text = string.Format("当前页码：0");
        //pageView.OnPageChanged = pageChanged;
    }


    public void LoadPhotoAlbum(int number)
    {
        DestoryAlbum();
        for (int i = 0; i < number; i++)
        {
            GameObject go =  ResourcesTools.Load<GameObject>("AlbumItem");
            GameObject item = Instantiate(go,content);
            AlbumList.Add(item.GetComponent<AlbumItem>());
            item.GetComponent<AlbumItem>().Init(i.ToString());
        }
        DestoryToggle();
        for (int i = 0; i < number; i++)
        {
            GameObject to = ResourcesTools.Load<GameObject>("AlbumToggle");
            GameObject toggle = Instantiate(to, toggleList);
            toggle.GetComponent<Toggle>().group = toggleList.GetComponent<ToggleGroup>();
            HudEvent.Get(toggle).onToggle = ChangToggleStatus;
            ToggleLiat.Add(toggle);
        }
        pageView.Init(AlbumList.Count, ToggleLiat);
    }


    public void SetTexture(Texture2D tex)
    {
        AlbumList[TexIndex].SetHeadIcon(tex);
        TexIndex++;
    }



    private void ChangToggleStatus(bool isOn,GameObject toggle)
    {
        if (isOn)
        {
            int idnex = ToggleLiat.IndexOf(toggle);
            pageView.pageTo(idnex);
        }
    }


    private void DestoryAlbum()
    {
        for (int i = 0; i < AlbumList.Count; i++)
        {
            DestroyImmediate(AlbumList[i].gameObject);
        }
        AlbumList.Clear();
    }


    private void DestoryToggle()
    {
        for (int i = 0; i < ToggleLiat.Count; i++)
        {
            DestroyImmediate(ToggleLiat[i].gameObject);
        }
        ToggleLiat.Clear();
    }










    //void pageChanged(int index)
    //{
    //    pageNumber.text = string.Format("当前页码：{0}", index.ToString());
    //}

    public void onClick()
    {
        try
        {
            //int idnex = int.Parse(inputField.text);
            //pageView.pageTo(idnex);
        }
        catch (Exception ex)
        {
            Debug.LogWarning("请输入数字" + ex.ToString());
        }
    }

    void Destroy()
    {
        pageView.OnPageChanged = null;
    }
}


