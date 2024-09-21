using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using UnityEngine;
using System.Text;

public class UdpSocket : MonoBehaviour
{
    public ObjectInfoBuffer ObjInfoBuf;
    UdpClient Client;
    Thread UdpThread;
    IPEndPoint AnyIP;
    public string RcvText;
    // Start is called before the first frame update
    void Start()
    {
        ObjInfoBuf.Init();
        Client = new UdpClient(27000);
        AnyIP = new IPEndPoint(IPAddress.Any, 0);
        UdpThread = new Thread(new ThreadStart(ThreadMethod));
        UdpThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ThreadMethod()
    {
        while (true)
        {
            try
            {
                byte[] data = Client.Receive(ref AnyIP);
                //Debug.Log(anyIP);
                string textdata = Encoding.UTF8.GetString(data);//收到的文字
                //string[] textarray = textdata.Split('#');
                //text = textarray[5];
                RcvText = textdata;
                //Debug.Log(RcvText);

                //拆解
                string[] msgArr = RcvText.Split(";");
                //Debug.Log(msgArr[0]);
                int objId = int.Parse(msgArr[0]);

                ObjInfoBuf.ObjIdArr[objId] = objId;
                ObjInfoBuf.FeatureCodeArr[objId] = int.Parse(msgArr[1]);
                ObjInfoBuf.PosXArr[objId] = float.Parse(msgArr[2])/100;
                ObjInfoBuf.PosYArr[objId] = float.Parse(msgArr[3])/100;
                ObjInfoBuf.PosZArr[objId] = float.Parse(msgArr[4])/100;
                ObjInfoBuf.StatusArr[objId] = int.Parse(msgArr[5]);

            }
            catch { }
        }
    }
    private void OnApplicationQuit()
    {
        UdpThread.Abort();
    }
}
