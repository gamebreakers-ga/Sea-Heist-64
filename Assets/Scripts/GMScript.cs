using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GMScript : MonoBehaviour
{
    public int Score;
    public TextMeshProUGUI st;
    public TextMeshProUGUI tt;
    public float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        st = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        tt = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Score < 4)
        {
            if (Timer < 30)
            {
                Timer += Time.deltaTime;
                st.text = $"Score: {Score}";
                tt.text = $"Time: {Mathf.Round(Timer)}";
            } else
            {
                st.text = "YOU";
                tt.text = "LOST";
            }
        } else if (Timer > 30)
        {
            st.text = "YOU";
            tt.text = "LOST";
        } else
        {
            st.text = "YOU";
            tt.text = "WON";
        }
        
    }
}
