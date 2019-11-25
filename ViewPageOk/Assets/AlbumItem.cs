using UnityEngine;
using UnityEngine.UI;

public class AlbumItem : MonoBehaviour
{

    public RawImage HeadIcon;
    public Text Index;
    void Start () {}
	
    public void Init(string id)
    {
        Index.text = id;
    }


    public void SetHeadIcon(Texture2D texture)
    {
        HeadIcon.texture = texture;
    }
	
}
