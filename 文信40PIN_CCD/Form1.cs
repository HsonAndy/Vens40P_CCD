using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyUI;
using Basic;
using AxAxAltairUDrv;
using AxAxOvkBase;
using AxAxOvkImage;
using SQLUI;
namespace 文信40PIN_CCD
{
    public partial class Form1 : Form
    {
        SQLUI.SQL_DataGridView.ConnentionClass connentionClass = new SQL_DataGridView.ConnentionClass();


        public Form1()
        {
            InitializeComponent();
        }
        MyThread MyThread_Program_CCD01;
        MyThread MyThread_Canvas;
        MyThread MyThread_Program_CCD01_SNAP;
        MyThread MyThread_Program_CCD02;
        MyThread MyThread_Program_CCD02_SNAP;

        private void CCD01_Init()
        {
            if (CCD01_01_AxImageSewer == null) CCD01_01_AxImageSewer = new AxOvkImage.AxImageSewer();
            if (CCD01_01_AxROIBW8_拼圖1校正量測框調整 == null) CCD01_01_AxROIBW8_拼圖1校正量測框調整 = new AxOvkBase.AxROIBW8();
            if (CCD01_01_AxObject_拼圖1校正量測框調整 == null) CCD01_01_AxObject_拼圖1校正量測框調整 = new AxOvkBlob.AxObject();
            if (CCD01_01_AxROIBW8_拼圖2校正量測框調整 == null) CCD01_01_AxROIBW8_拼圖2校正量測框調整 = new AxOvkBase.AxROIBW8();
            if (CCD01_01_AxObject_拼圖2校正量測框調整 == null) CCD01_01_AxObject_拼圖2校正量測框調整 = new AxOvkBlob.AxObject();

            if (CCD01_02_AxImageSewer == null) CCD01_02_AxImageSewer = new AxOvkImage.AxImageSewer();
            if (CCD01_02_AxROIBW8_拼圖1校正量測框調整 == null) CCD01_02_AxROIBW8_拼圖1校正量測框調整 = new AxOvkBase.AxROIBW8();
            if (CCD01_02_AxObject_拼圖1校正量測框調整 == null) CCD01_02_AxObject_拼圖1校正量測框調整 = new AxOvkBlob.AxObject();
            if (CCD01_02_AxROIBW8_拼圖2校正量測框調整 == null) CCD01_02_AxROIBW8_拼圖2校正量測框調整 = new AxOvkBase.AxROIBW8();
            if (CCD01_02_AxObject_拼圖2校正量測框調整 == null) CCD01_02_AxObject_拼圖2校正量測框調整 = new AxOvkBlob.AxObject();

            //if (this.CCD01_01_左基準圓量測_AxCircleMsr == null) this.CCD01_01_左基準圓量測_AxCircleMsr = new AxOvkMsr.AxCircleMsr();
            //if (this.CCD01_01_右基準圓量測_AxCircleMsr == null) this.CCD01_01_右基準圓量測_AxCircleMsr = new AxOvkMsr.AxCircleMsr();
            //if (this.CCD01_01_基準線量測_AxLineRegression == null) this.CCD01_01_基準線量測_AxLineRegression = new AxOvkMsr.AxLineRegression();
            for (int i = 0; i < 2; i++)
            {
                this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整.Add(new AxOvkBase.AxROIBW8());
                this.List_CCD01_01_基準圓量測_AxObject_區塊分析.Add(new AxOvkBlob.AxObject());
            }
            if (this.CCD01_01基準圓AxVisionInspectionFrame_量測框調整 == null) this.CCD01_01基準圓AxVisionInspectionFrame_量測框調整 = new AxOvkPat.AxVisionInspectionFrame();
            
            #region 基準線
            if (this.CCD01_01_水平基準線量測_AxLineMsr == null) this.CCD01_01_水平基準線量測_AxLineMsr = new AxOvkMsr.AxLineMsr();
            if (this.CCD01_01_水平基準線量測_AxLineRegression == null) this.CCD01_01_水平基準線量測_AxLineRegression = new AxOvkMsr.AxLineRegression();
            if (this.CCD01_01_垂直基準線量測_AxLineMsr == null) this.CCD01_01_垂直基準線量測_AxLineMsr = new AxOvkMsr.AxLineMsr();
            if (this.CCD01_01_垂直基準線量測_AxLineRegression == null) this.CCD01_01_垂直基準線量測_AxLineRegression = new AxOvkMsr.AxLineRegression();
            if (this.CCD01_01_基準線量測_AxIntersectionMsr == null) this.CCD01_01_基準線量測_AxIntersectionMsr = new AxOvkMsr.AxIntersectionMsr();
            #endregion
            #region PIN量測
            if (this.CCD01_02_PIN量測_AxPointLineDistanceMsr_線到點量測 == null) this.CCD01_02_PIN量測_AxPointLineDistanceMsr_線到點量測 = new AxOvkMsr.AxPointLineDistanceMsr();
            if (this.CCD01_02_PIN量測_AxVisionInspectionFrame_量測框調整 == null) this.CCD01_02_PIN量測_AxVisionInspectionFrame_量測框調整 = new AxOvkPat.AxVisionInspectionFrame();
            for (int i = 0; i < 40; i++)
            {
                this.List_CCD01_02_PIN量測_AxROIBW8_量測框調整.Add(new AxOvkBase.AxROIBW8());
                this.List_CCD01_02_PIN量測_AxObject_區塊分析.Add(new AxOvkBlob.AxObject());
            }
            #endregion
            if (CCD01_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整 == null) CCD01_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整 = new AxOvkPat.AxVisionInspectionFrame();
        }
        private void CCD02_Init()
        {
            if (CCD02_01_AxImageSewer == null) CCD02_01_AxImageSewer = new AxOvkImage.AxImageSewer();
            if (CCD02_01_AxROIBW8_拼圖1校正量測框調整 == null) CCD02_01_AxROIBW8_拼圖1校正量測框調整 = new AxOvkBase.AxROIBW8();
            if (CCD02_01_AxObject_拼圖1校正量測框調整 == null) CCD02_01_AxObject_拼圖1校正量測框調整 = new AxOvkBlob.AxObject();
            if (CCD02_01_AxROIBW8_拼圖2校正量測框調整 == null) CCD02_01_AxROIBW8_拼圖2校正量測框調整 = new AxOvkBase.AxROIBW8();
            if (CCD02_01_AxObject_拼圖2校正量測框調整 == null) CCD02_01_AxObject_拼圖2校正量測框調整 = new AxOvkBlob.AxObject();

            if (CCD02_02_AxImageSewer == null) CCD02_02_AxImageSewer = new AxOvkImage.AxImageSewer();
            if (CCD02_02_AxROIBW8_拼圖1校正量測框調整 == null) CCD02_02_AxROIBW8_拼圖1校正量測框調整 = new AxOvkBase.AxROIBW8();
            if (CCD02_02_AxObject_拼圖1校正量測框調整 == null) CCD02_02_AxObject_拼圖1校正量測框調整 = new AxOvkBlob.AxObject();
            if (CCD02_02_AxROIBW8_拼圖2校正量測框調整 == null) CCD02_02_AxROIBW8_拼圖2校正量測框調整 = new AxOvkBase.AxROIBW8();
            if (CCD02_02_AxObject_拼圖2校正量測框調整 == null) CCD02_02_AxObject_拼圖2校正量測框調整 = new AxOvkBlob.AxObject();
            #region 基準線
            if (this.CCD02_01_水平基準線量測_AxLineMsr == null) this.CCD02_01_水平基準線量測_AxLineMsr = new AxOvkMsr.AxLineMsr();
            if (this.CCD02_01_水平基準線量測_AxLineRegression == null) this.CCD02_01_水平基準線量測_AxLineRegression = new AxOvkMsr.AxLineRegression();
            if (this.CCD02_01_垂直基準線量測_AxLineMsr == null) this.CCD02_01_垂直基準線量測_AxLineMsr = new AxOvkMsr.AxLineMsr();
            if (this.CCD02_01_垂直基準線量測_AxLineRegression == null) this.CCD02_01_垂直基準線量測_AxLineRegression = new AxOvkMsr.AxLineRegression();
            if (this.CCD02_01_基準線量測_AxIntersectionMsr == null) this.CCD02_01_基準線量測_AxIntersectionMsr = new AxOvkMsr.AxIntersectionMsr();
            #endregion
            #region PIN量測
            if (this.CCD02_02_PIN量測_AxPointLineDistanceMsr_線到點量測 == null) this.CCD02_02_PIN量測_AxPointLineDistanceMsr_線到點量測 = new AxOvkMsr.AxPointLineDistanceMsr();
            if (this.CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整 == null) this.CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整 = new AxOvkPat.AxVisionInspectionFrame();
            for (int i = 0; i < 40; i++)
            {
                this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Add(new AxOvkBase.AxROIBW8());
                this.List_CCD02_02_PIN量測_AxObject_區塊分析.Add(new AxOvkBlob.AxObject());
            }
            #endregion
            if (CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整 == null) CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整 = new AxOvkPat.AxVisionInspectionFrame();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            MyMessageBox.form = this.FindForm();
            this.MyThread_Canvas = new MyThread(this.FindForm());

            this.MyThread_Canvas.Add_Method(this.h_Canvas_Tech_CCD01_01_拼接圖1.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Tech_CCD01_01_拼接圖2.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Tech_CCD01_01_拼接完成圖.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Tech_CCD01_02_拼接圖1.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Tech_CCD01_02_拼接圖2.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Tech_CCD01_02_拼接完成圖.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Tech_CCD02_01_拼接圖1.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Tech_CCD02_01_拼接圖2.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Tech_CCD02_01_拼接完成圖.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Tech_CCD02_02_拼接圖1.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Tech_CCD02_02_拼接圖2.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Tech_CCD02_02_拼接完成圖.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Main_CCD01_01_檢測畫面.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Main_CCD01_02_檢測畫面.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Main_CCD02_01_檢測畫面.Get_Method());
            this.MyThread_Canvas.Add_Method(this.h_Canvas_Main_CCD02_02_檢測畫面.Get_Method());
            this.MyThread_Canvas.AutoRun(true);
            this.MyThread_Canvas.AutoStop(false);
            this.MyThread_Canvas.Trigger();

            plC_UI_Init1.Run(this.FindForm(), lowerMachine_Panel1);
            plC_UI_Init1.UI_Finished_Event += PlC_UI_Init1_UI_Finished_Event;
            timer_Init.Enabled = true;
            //AxAltairU拼接圖.QuickCreateChannel();


        }

        private void PlC_UI_Init1_UI_Finished_Event()
        {
            
            this.connentionClass.DataBaseName = "dbvm";
            this.connentionClass.UserName = "user";
            this.connentionClass.Password = "66437068";
            //this.connentionClass.Password = "user82822040";
            this.connentionClass.Port = 3306;
            this.connentionClass.IP = "127.0.0.1";
            this.connentionClass.MySqlSslMode = MySql.Data.MySqlClient.MySqlSslMode.None;
            this.Program_PLC資料交握參數_Init();
            PLC_UI_Init.Set_PLC_ScreenPage(panel_Main, this.plC_ScreenPage_Main);
            Basic.Screen.FullScreen(FindForm(), 0, true);
            this.WindowState = FormWindowState.Maximized;
        }

        private void timer_Init_Tick(object sender, EventArgs e)
        {
            if(plC_UI_Init1.Init_Finish)
            {
                this.MyThread_Program_CCD01_SNAP = new MyThread(this.FindForm());
                this.MyThread_Program_CCD01_SNAP.Add_Method(this.plC_MindVision_Camera_UI_CCD01.Method);
                this.MyThread_Program_CCD01_SNAP.Add_Method(this.sub_Program_CCD01_SNAP);
                this.MyThread_Program_CCD01_SNAP.SetSleepTime(1);
                this.MyThread_Program_CCD01_SNAP.AutoRun(true);
                this.MyThread_Program_CCD01_SNAP.AutoStop(false);
                this.MyThread_Program_CCD01_SNAP.Trigger();

                this.MyThread_Program_CCD01 = new MyThread(this.FindForm());
                this.MyThread_Program_CCD01.Add_Method(this.Program_CCD01_01);
                this.MyThread_Program_CCD01.Add_Method(this.Program_CCD01_02);
                this.MyThread_Program_CCD01.SetSleepTime(1);
                this.MyThread_Program_CCD01.AutoRun(true);
                this.MyThread_Program_CCD01.AutoStop(false);
                this.MyThread_Program_CCD01.Trigger();

                this.MyThread_Program_CCD02_SNAP = new MyThread(this.FindForm());
                this.MyThread_Program_CCD02_SNAP.Add_Method(this.plC_MindVision_Camera_UI2_CCD02.Method);
                this.MyThread_Program_CCD02_SNAP.Add_Method(this.sub_Program_CCD02_SNAP);

                this.MyThread_Program_CCD02_SNAP.AutoRun(true);
                this.MyThread_Program_CCD02_SNAP.AutoStop(false);
                this.MyThread_Program_CCD02_SNAP.Trigger();

                this.MyThread_Program_CCD02 = new MyThread(this.FindForm());
                this.MyThread_Program_CCD02.Add_Method(this.Program_CCD02_01);
                this.MyThread_Program_CCD02.Add_Method(this.Program_CCD02_02);
                this.MyThread_Program_CCD02.AutoRun(true);
                this.MyThread_Program_CCD02.AutoStop(false);
                this.MyThread_Program_CCD02.Trigger();
                timer_Init.Enabled = false;

       
            }
        }
        private double FunctionMsr_Y(double conf0, double conf1, double X)
        {
            double Y;

            // Y=conf0 * X + conf1;

            Y = ((X * conf1) + conf0);

            return Y;
        }
        private double Conf0Msr(double conf1, double X, double Y)
        {
            double conf0;

            conf0 = Y - conf1 * X;

            return conf0;
        }

        #region PLC_Method
        PLC_Device PLC_Device_Method = new PLC_Device("");
        PLC_Device PLC_Device_Method_OK = new PLC_Device("");
        Task Task_Method;
        MyTimer MyTimer_Method_結束延遲 = new MyTimer();
        int cnt_Program_Method = 65534;
        void sub_Program_Method()
        {
            if (cnt_Program_Method == 65534)
            {
                this.MyTimer_Method_結束延遲.StartTickTime(10000);
                PLC_Device_Method.SetComment("PLC_Method");
                PLC_Device_Method_OK.SetComment("PLC_Method_OK");
                PLC_Device_Method.Bool = false;
                cnt_Program_Method = 65535;
            }
            if (cnt_Program_Method == 65535) cnt_Program_Method = 1;
            if (cnt_Program_Method == 1) cnt_Program_Method_檢查按下(ref cnt_Program_Method);
            if (cnt_Program_Method == 2) cnt_Program_Method_初始化(ref cnt_Program_Method);
            if (cnt_Program_Method == 3) cnt_Program_Method = 65500;
            if (cnt_Program_Method > 1) cnt_Program_Method_檢查放開(ref cnt_Program_Method);

            if (cnt_Program_Method == 65500)
            {
                this.MyTimer_Method_結束延遲.TickStop();
                this.MyTimer_Method_結束延遲.StartTickTime(10000);
                PLC_Device_Method.Bool = false;
                PLC_Device_Method_OK.Bool = false;
                cnt_Program_Method = 65535;
            }
        }
        void cnt_Program_Method_檢查按下(ref int cnt)
        {
            if (PLC_Device_Method.Bool) cnt++;
        }
        void cnt_Program_Method_檢查放開(ref int cnt)
        {
            if (!PLC_Device_Method.Bool) cnt = 65500;
        }
        void cnt_Program_Method_初始化(ref int cnt)
        {
            if (this.MyTimer_Method_結束延遲.IsTimeOut())
            {
                if (Task_Method == null)
                {
                    Task_Method = new Task(new Action(delegate { }));
                }
                if (Task_Method.Status == TaskStatus.RanToCompletion)
                {
                    Task_Method = new Task(new Action(delegate { }));
                }
                if (Task_Method.Status == TaskStatus.Created)
                {
                    Task_Method.Start();
                }
                cnt++;
            }
        }



























        #endregion
        #region Main控制面板
        PLC_Device PLC_Device_Main_CCD01_01_ZOOM更新 = new PLC_Device("S30120");
        PLC_Device PLC_Device_Main_CCD01_02_ZOOM更新 = new PLC_Device("S30130");
        PLC_Device PLC_Device_Main_CCD02_01_ZOOM更新 = new PLC_Device("S30140");
        PLC_Device PLC_Device_Main_CCD02_02_ZOOM更新 = new PLC_Device("S30150");
        private void plC_Button_Main_CCD01_01_ZOOM更新_btnClick(object sender, EventArgs e)
        {
            PLC_Device_Main_CCD01_01_ZOOM更新.Bool = true;
            h_Canvas_Main_CCD01_01_檢測畫面.RefreshCanvas();
        }

        private void plC_Button_Main_CCD01_02_ZOOM更新_btnClick(object sender, EventArgs e)
        {
            PLC_Device_Main_CCD01_02_ZOOM更新.Bool = true;
            h_Canvas_Main_CCD01_02_檢測畫面.RefreshCanvas();
        }

        private void plC_Button_Main_CCD02_01_ZOOM更新_btnClick(object sender, EventArgs e)
        {
            PLC_Device_Main_CCD02_01_ZOOM更新.Bool = true;
            h_Canvas_Main_CCD02_01_檢測畫面.RefreshCanvas();
        }

        private void plC_Button_Main_CCD02_02_ZOOM更新_btnClick(object sender, EventArgs e)
        {
            PLC_Device_Main_CCD02_02_ZOOM更新.Bool = true;
            h_Canvas_Main_CCD02_02_檢測畫面.RefreshCanvas();
        }
        #endregion

        PLC_Device PLC_Device_Tech_CCD01_01拼接圖1_ZOOM更新 = new PLC_Device("S30000");
        PLC_Device PLC_Device_Tech_CCD01_01拼接圖2_ZOOM更新 = new PLC_Device("S30010");

        private void plC_Button_Tech_CCD01_01拼接圖1_ZOOM更新_btnClick(object sender, EventArgs e)
        {
            PLC_Device_Tech_CCD01_01拼接圖1_ZOOM更新.Bool = true;
            h_Canvas_Tech_CCD01_01_拼接圖1.RefreshCanvas();
        }

        private void plC_Button_Tech_CCD01_01拼接圖2_ZOOM更新_btnClick(object sender, EventArgs e)
        {
            PLC_Device_Tech_CCD01_01拼接圖2_ZOOM更新.Bool = true;
            h_Canvas_Tech_CCD01_01_拼接圖2.RefreshCanvas();
        }


    }
}
