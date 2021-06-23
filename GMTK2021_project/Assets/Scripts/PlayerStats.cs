using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameControl gameControl;

    public MoveControl moveControl;

    private float _rotatingTime, _usedTime;

    private int _jumpTimes;

    private TextMesh _textMesh;
    // Start is called before the first frame update
    void Start()
    {
        _textMesh = GetComponent<TextMesh>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetStats()
    {
        _rotatingTime = moveControl.RotatingTime;
        _jumpTimes = moveControl.JumpTimes;
        _usedTime = gameControl.UsedTime;
    }

    public void Print()
    {
        var percentage = _rotatingTime / _usedTime * 100; // the percentage of rotating time
        _textMesh.text = "You used " + (int) _usedTime + " s,\nand " + (int) percentage +
                         "% of that you were rolling;\nYou jumped " + _jumpTimes +
                         " times, hope you enjoyed it!\n\n\n\nCreated by\nStacy Gao\n\nMusic\nhttps://www.bensound.com";


    }
}
