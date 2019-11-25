using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HudEvent : EventTrigger {

	public delegate void VoidDelegate (GameObject go);

	public VoidDelegate onDown;
	public VoidDelegate onEnter;
	public VoidDelegate onExit;
	public VoidDelegate onUp;
	public VoidDelegate onSelect;
	public VoidDelegate onUpdateSelect;

	public VoidDelegate onDrag;

	public System.Action onClick = null;
    public System.Action<GameObject> onClick_obj = null;

    public System.Action<bool,GameObject> onToggle = null;

    public Vector3 scaleVec = Vector3.one * 1.2f;
    public Vector3 orignalVec;

    private Button button;

	public Toggle toggle;

	void Awake() {
	
		button = this.GetComponent<Button>();
		if(button != null) {
		
			button.onClick.AddListener(OnClick);

            //guide event
            //GuideManager.Instance.OnBtnGuide(this.gameObject);
		
		}

		toggle = this.GetComponent<Toggle>();

		if (toggle != null) {

            toggle.onValueChanged.AddListener(OnToggle);

		}

        orignalVec = transform.lossyScale;
        scaleVec = orignalVec * 1.1f;
	
	}

//	static public HudEvent Get (GameObject go)
//	{
//		HudEvent listener = go.GetComponent<HudEvent>();
//		if (listener == null) listener = go.AddComponent<HudEvent>();
//		return listener;
//	}

	public static HudEvent Get(GameObject go) {

		HudEvent hudEvent = go.GetComponent<HudEvent>();

		if(hudEvent == null) hudEvent = go.AddComponent<HudEvent>();

		return hudEvent;

	}

	private void OnClick() {
	
        CommonEvent();

		if(onClick != null) { 

            //close guide
            //GuideManager.Instance.OnClose();

            onClick();

        
        }
        if (onClick_obj != null)
        {
            onClick_obj(this.gameObject);
        }
	
	}

	private void OnToggle(bool is_toggle) {
	
		CommonEvent();

		if (onToggle != null) {
		
			//GuideManager.Instance.OnClose();
			onToggle(is_toggle,this.gameObject);
		
		}
	
	}

	void OnDestroy() {
	
        //if(this.gameObject != null)
           //button.onClick.RemoveListener (OnClick);
	
	}

	/*****************************new**********************************/

//	public override void OnPointerClick(PointerEventData eventData)
//	{
//		if(onClick != null) 	onClick(gameObject);
//	}
	public override void OnPointerDown (PointerEventData eventData){
        CommonEvent();
        //LeanTween.scale(this.gameObject, scaleVec, 0.2f);
		if(onDown != null) onDown(gameObject);
	}
	public override void OnPointerEnter (PointerEventData eventData){
        CommonEvent();
		if(onEnter != null) onEnter(gameObject);
	}
	public override void OnPointerExit (PointerEventData eventData){
        CommonEvent();
		if(onExit != null) onExit(gameObject);
	}
	public override void OnPointerUp (PointerEventData eventData){
        CommonEvent();
        //LeanTween.scale(this.gameObject, orignalVec, 0.2f);
		if(onUp != null) onUp(gameObject);
	}
	public override void OnSelect (BaseEventData eventData){
		if(onSelect != null) onSelect(gameObject);
	}
	public override void OnUpdateSelected (BaseEventData eventData){
		if(onUpdateSelect != null) onUpdateSelect(gameObject);
	}


    public void CommonEvent() {
    
        //InputManager.Instance.not_touch_time = 0;
    
    }

}
