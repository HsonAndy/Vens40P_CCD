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
using AxAxOvkImage;

namespace 文信40PIN_CCD
{
    public partial class Form1 : Form
    {


        DialogResult err_message4;

        void Program_CCD02_02()
        {
            this.sub_Program_CCD02_02_SNAP_拼接圖1();
            this.sub_Program_CCD02_02_SNAP_拼接圖2();
            this.sub_Program_CCD02_02_Tech_檢驗一次();
            this.sub_Program_CCD02_02_計算一次();
            this.sub_Program_CCD02_02_拼接校正();
            this.sub_Program_CCD02_02_校正量測框();
            this.sub_Program_CCD02_02_影像拼接();
            this.sub_Program_CCD02_02_Main_取像並檢驗();

            this.sub_Program_CCD02_02_PIN量測_量測框調整();
            this.sub_Program_CCD02_02_PIN量測_檢測距離計算();
            this.sub_Program_CCD02_02_PIN正位度量測_設定規範位置();
            this.sub_Program_CCD02_02_PIN量測_檢測正位度計算();

        }

        #region PLC_CCD02_02_SNAP_拼接圖1
        PLC_Device PLC_Device_CCD02_02_SNAP_拼接圖1_按鈕 = new PLC_Device("S15310");
        PLC_Device PLC_Device_CCD02_02_SNAP_拼接圖1 = new PLC_Device("S15305");
        PLC_Device PLC_Device_CCD02_02_SNAP_拼接圖1_LIVE = new PLC_Device("S15306");
        PLC_Device PLC_Device_CCD02_02_SNAP_拼接圖1_電子快門 = new PLC_Device("F9110");
        PLC_Device PLC_Device_CCD02_02_SNAP_拼接圖1_視訊增益 = new PLC_Device("F9111");
        PLC_Device PLC_Device_CCD02_02_SNAP_拼接圖1_銳利度 = new PLC_Device("F9112");
        PLC_Device PLC_Device_CCD02_02_SNAP_拼接圖1_光源亮度_白正照 = new PLC_Device("F25142");
        PLC_Device PLC_Device_CCD02_02_SNAP_拼接圖1_光源亮度_藍側照 = new PLC_Device("F25143");

        int cnt_Program_CCD02_02_SNAP_拼接圖1 = 65534;
        void sub_Program_CCD02_02_SNAP_拼接圖1()
        {
            if (cnt_Program_CCD02_02_SNAP_拼接圖1 == 65534)
            {
                PLC_Device_CCD02_02_SNAP_拼接圖1.SetComment("PLC_CCD02_02_SNAP_拼接圖1");
                PLC_Device_CCD02_02_SNAP_拼接圖1.Bool = false;
                cnt_Program_CCD02_02_SNAP_拼接圖1 = 65535;
            }
            if (cnt_Program_CCD02_02_SNAP_拼接圖1 == 65535) cnt_Program_CCD02_02_SNAP_拼接圖1 = 1;
            if (cnt_Program_CCD02_02_SNAP_拼接圖1 == 1) cnt_Program_CCD02_02_SNAP_拼接圖1_檢查按下(ref cnt_Program_CCD02_02_SNAP_拼接圖1);
            if (cnt_Program_CCD02_02_SNAP_拼接圖1 == 2) cnt_Program_CCD02_02_SNAP_拼接圖1_初始化(ref cnt_Program_CCD02_02_SNAP_拼接圖1);
            if (cnt_Program_CCD02_02_SNAP_拼接圖1 == 3) cnt_Program_CCD02_02_SNAP_拼接圖1_開始取像(ref cnt_Program_CCD02_02_SNAP_拼接圖1);
            if (cnt_Program_CCD02_02_SNAP_拼接圖1 == 4) cnt_Program_CCD02_02_SNAP_拼接圖1_取像結束(ref cnt_Program_CCD02_02_SNAP_拼接圖1);
            if (cnt_Program_CCD02_02_SNAP_拼接圖1 == 5) cnt_Program_CCD02_02_SNAP_拼接圖1_繪製影像(ref cnt_Program_CCD02_02_SNAP_拼接圖1);
            if (cnt_Program_CCD02_02_SNAP_拼接圖1 == 6) cnt_Program_CCD02_02_SNAP_拼接圖1 = 65500;
            if (cnt_Program_CCD02_02_SNAP_拼接圖1 > 1) cnt_Program_CCD02_02_SNAP_拼接圖1_檢查放開(ref cnt_Program_CCD02_02_SNAP_拼接圖1);

            if (cnt_Program_CCD02_02_SNAP_拼接圖1 == 65500)
            {
                PLC_Device_CCD02_SNAP.Bool = false;
                PLC_Device_CCD02_02_SNAP_拼接圖1.Bool = false;
                cnt_Program_CCD02_02_SNAP_拼接圖1 = 65535;
            }
        }
        void cnt_Program_CCD02_02_SNAP_拼接圖1_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_02_SNAP_拼接圖1.Bool) cnt++;
        }
        void cnt_Program_CCD02_02_SNAP_拼接圖1_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_SNAP_拼接圖1.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_02_SNAP_拼接圖1_初始化(ref int cnt)
        {
            PLC_Device_CCD02_SNAP_電子快門.Value = PLC_Device_CCD02_02_SNAP_拼接圖1_電子快門.Value;
            PLC_Device_CCD02_SNAP_視訊增益.Value = PLC_Device_CCD02_02_SNAP_拼接圖1_視訊增益.Value;
            PLC_Device_CCD02_SNAP_銳利度.Value = PLC_Device_CCD02_02_SNAP_拼接圖1_銳利度.Value;

            cnt++;
        }
        void cnt_Program_CCD02_02_SNAP_拼接圖1_開始取像(ref int cnt)
        {
            if (!PLC_Device_CCD02_SNAP.Bool)
            {
                PLC_Device_CCD02_SNAP.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD02_02_SNAP_拼接圖1_取像結束(ref int cnt)
        {
            if (!PLC_Device_CCD02_SNAP.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD02_02_SNAP_拼接圖1_繪製影像(ref int cnt)
        {
            this.CCD02_02_SrcImageHandle_拼接圖1 = this.h_Canvas_Tech_CCD02_02_拼接圖1.VegaHandle;
            this.h_Canvas_Tech_CCD02_02_拼接圖1.ImageCopy(this.CCD02_AxImageBW8.VegaHandle);
            this.h_Canvas_Tech_CCD02_02_拼接圖1.SetImageSize(this.h_Canvas_Tech_CCD02_02_拼接圖1.ImageWidth, this.h_Canvas_Tech_CCD02_02_拼接圖1.ImageHeight);
            if (this.PLC_Device_CCD02_02_SNAP_拼接圖1_按鈕.Bool) this.h_Canvas_Tech_CCD02_02_拼接圖1.RefreshCanvas();

            if (PLC_Device_CCD02_02_SNAP_拼接圖1_LIVE.Bool)
            {
                cnt = 2;
                return;
            }
            cnt++;
        }





        #endregion
        #region PLC_CCD02_02_SNAP_拼接圖2
        PLC_Device PLC_Device_CCD02_02_SNAP_拼接圖2_按鈕 = new PLC_Device("S15330");
        PLC_Device PLC_Device_CCD02_02_SNAP_拼接圖2 = new PLC_Device("S15325");
        PLC_Device PLC_Device_CCD02_02_SNAP_拼接圖2_LIVE = new PLC_Device("S15316");

        int cnt_Program_CCD02_02_SNAP_拼接圖2 = 65534;
        void sub_Program_CCD02_02_SNAP_拼接圖2()
        {
            if (cnt_Program_CCD02_02_SNAP_拼接圖2 == 65534)
            {
                PLC_Device_CCD02_02_SNAP_拼接圖2.SetComment("PLC_CCD02_02_SNAP_拼接圖2");
                PLC_Device_CCD02_02_SNAP_拼接圖2.Bool = false;
                cnt_Program_CCD02_02_SNAP_拼接圖2 = 65535;
            }
            if (cnt_Program_CCD02_02_SNAP_拼接圖2 == 65535) cnt_Program_CCD02_02_SNAP_拼接圖2 = 1;
            if (cnt_Program_CCD02_02_SNAP_拼接圖2 == 1) cnt_Program_CCD02_02_SNAP_拼接圖2_檢查按下(ref cnt_Program_CCD02_02_SNAP_拼接圖2);
            if (cnt_Program_CCD02_02_SNAP_拼接圖2 == 2) cnt_Program_CCD02_02_SNAP_拼接圖2_初始化(ref cnt_Program_CCD02_02_SNAP_拼接圖2);
            if (cnt_Program_CCD02_02_SNAP_拼接圖2 == 3) cnt_Program_CCD02_02_SNAP_拼接圖2_開始取像(ref cnt_Program_CCD02_02_SNAP_拼接圖2);
            if (cnt_Program_CCD02_02_SNAP_拼接圖2 == 4) cnt_Program_CCD02_02_SNAP_拼接圖2_取像結束(ref cnt_Program_CCD02_02_SNAP_拼接圖2);
            if (cnt_Program_CCD02_02_SNAP_拼接圖2 == 5) cnt_Program_CCD02_02_SNAP_拼接圖2_繪製影像(ref cnt_Program_CCD02_02_SNAP_拼接圖2);
            if (cnt_Program_CCD02_02_SNAP_拼接圖2 == 6) cnt_Program_CCD02_02_SNAP_拼接圖2 = 65500;
            if (cnt_Program_CCD02_02_SNAP_拼接圖2 > 1) cnt_Program_CCD02_02_SNAP_拼接圖2_檢查放開(ref cnt_Program_CCD02_02_SNAP_拼接圖2);

            if (cnt_Program_CCD02_02_SNAP_拼接圖2 == 65500)
            {
                PLC_Device_CCD02_SNAP.Bool = false;
                PLC_Device_CCD02_02_SNAP_拼接圖2.Bool = false;
                cnt_Program_CCD02_02_SNAP_拼接圖2 = 65535;
            }
        }
        void cnt_Program_CCD02_02_SNAP_拼接圖2_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_02_SNAP_拼接圖2.Bool) cnt++;
        }
        void cnt_Program_CCD02_02_SNAP_拼接圖2_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_SNAP_拼接圖2.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_02_SNAP_拼接圖2_初始化(ref int cnt)
        {
            PLC_Device_CCD02_SNAP_電子快門.Value = PLC_Device_CCD02_02_SNAP_拼接圖1_電子快門.Value;
            PLC_Device_CCD02_SNAP_視訊增益.Value = PLC_Device_CCD02_02_SNAP_拼接圖1_視訊增益.Value;
            PLC_Device_CCD02_SNAP_銳利度.Value = PLC_Device_CCD02_02_SNAP_拼接圖1_銳利度.Value;

            cnt++;
        }
        void cnt_Program_CCD02_02_SNAP_拼接圖2_開始取像(ref int cnt)
        {
            if (!PLC_Device_CCD02_SNAP.Bool)
            {
                PLC_Device_CCD02_SNAP.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD02_02_SNAP_拼接圖2_取像結束(ref int cnt)
        {
            if (!PLC_Device_CCD02_SNAP.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD02_02_SNAP_拼接圖2_繪製影像(ref int cnt)
        {
            this.CCD02_02_SrcImageHandle_拼接圖2 = this.h_Canvas_Tech_CCD02_02_拼接圖2.VegaHandle;
            this.h_Canvas_Tech_CCD02_02_拼接圖2.ImageCopy(this.CCD02_AxImageBW8.VegaHandle);
            this.h_Canvas_Tech_CCD02_02_拼接圖2.SetImageSize(this.h_Canvas_Tech_CCD02_02_拼接圖2.ImageWidth, this.h_Canvas_Tech_CCD02_02_拼接圖2.ImageHeight);
            if (this.PLC_Device_CCD02_02_SNAP_拼接圖2_按鈕.Bool) this.h_Canvas_Tech_CCD02_02_拼接圖2.RefreshCanvas();

            if (PLC_Device_CCD02_02_SNAP_拼接圖2_LIVE.Bool)
            {
                cnt = 2;
                return;
            }
            cnt++;
        }





        #endregion               
        #region PLC_CCD02_02_拼接校正
        PLC_Device PLC_Device_CCD02_02_拼接校正_按鈕 = new PLC_Device("S18310");
        PLC_Device PLC_Device_CCD02_02_拼接校正 = new PLC_Device("S18305");
        PLC_Device PLC_Device_CCD02_02_拼接校正_RefreshCanvas = new PLC_Device("S18306");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real1_1_X = new PLC_Device("F6350");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real1_2_X = new PLC_Device("F6351");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real1_3_X = new PLC_Device("F6352");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real1_4_X = new PLC_Device("F6353");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real2_1_X = new PLC_Device("F6354");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real2_2_X = new PLC_Device("F6355");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real2_3_X = new PLC_Device("F6356");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real2_4_X = new PLC_Device("F6357");

        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real1_1_Y = new PLC_Device("F6360");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real1_2_Y = new PLC_Device("F6361");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real1_3_Y = new PLC_Device("F6362");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real1_4_Y = new PLC_Device("F6363");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real2_1_Y = new PLC_Device("F6364");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real2_2_Y = new PLC_Device("F6365");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real2_3_Y = new PLC_Device("F6366");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_Real2_4_Y = new PLC_Device("F6367");
        private AxOvkImage.AxImageSewer CCD02_02_AxImageSewer;
        double CCD02_02拼圖1_X1 = new double();
        double CCD02_02拼圖1_Y1 = new double();
        double CCD02_02拼圖1_X2 = new double();
        double CCD02_02拼圖1_Y2 = new double();
        double CCD02_02拼圖1_X3 = new double();
        double CCD02_02拼圖1_Y3 = new double();
        double CCD02_02拼圖1_X4 = new double();
        double CCD02_02拼圖1_Y4 = new double();

        double CCD02_02拼圖2_X1 = new double();
        double CCD02_02拼圖2_Y1 = new double();
        double CCD02_02拼圖2_X2 = new double();
        double CCD02_02拼圖2_Y2 = new double();
        double CCD02_02拼圖2_X3 = new double();
        double CCD02_02拼圖2_Y3 = new double();
        double CCD02_02拼圖2_X4 = new double();
        double CCD02_02拼圖2_Y4 = new double();

        private void H_Canvas_Tech_CCD02_02_拼接校正_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            try
            {

                if (this.PLC_Device_CCD02_02_拼接校正_RefreshCanvas.Bool)
                {

                    Graphics g = Graphics.FromHdc((IntPtr)HDC);




                    DrawingClass.Draw.十字中心(CCD02_02拼圖1校正點座標, 50, Color.Lime, 1, g, ZoomX, ZoomY);
                    g.Dispose();
                    g = null;
                }
            }
            catch
            {

            }

            this.PLC_Device_CCD02_02_拼接校正_RefreshCanvas.Bool = false;
        }
        int cnt_Program_CCD02_02_拼接校正 = 65534;
        void sub_Program_CCD02_02_拼接校正()
        {
            if(CCD02_02_AxImageSewer != null)
            {
                if (cnt_Program_CCD02_02_拼接校正 == 65534)
                {
                    h_Canvas_Tech_CCD02_02_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_02_拼接校正_OnCanvasDrawEvent;
                    this.CCD02_02_AxImageSewer.LoadFile(@"C:\Users\Administrator\Desktop\Vens40P_CCD\Imagesewer_File\CCD02_02_Calibrate.cb");
                    #region 拼圖座標
                    CCD02_02拼圖1_X1 = PLC_Device_CCD02_02_校正量測框_拼圖1校正座標1_X.Value / 1000D;
                    CCD02_02拼圖1_Y1 = PLC_Device_CCD02_02_校正量測框_拼圖1校正座標1_Y.Value / 1000D;
                    CCD02_02拼圖1_X2 = PLC_Device_CCD02_02_校正量測框_拼圖1校正座標2_X.Value / 1000D;
                    CCD02_02拼圖1_Y2 = PLC_Device_CCD02_02_校正量測框_拼圖1校正座標2_Y.Value / 1000D;
                    CCD02_02拼圖1_X3 = PLC_Device_CCD02_02_校正量測框_拼圖1校正座標3_X.Value / 1000D;
                    CCD02_02拼圖1_Y3 = PLC_Device_CCD02_02_校正量測框_拼圖1校正座標3_Y.Value / 1000D;
                    CCD02_02拼圖1_X4 = PLC_Device_CCD02_02_校正量測框_拼圖1校正座標4_X.Value / 1000D;
                    CCD02_02拼圖1_Y4 = PLC_Device_CCD02_02_校正量測框_拼圖1校正座標4_Y.Value / 1000D;

                    CCD02_02拼圖2_X1 = PLC_Device_CCD02_02_校正量測框_拼圖2校正座標1_X.Value / 1000D;
                    CCD02_02拼圖2_Y1 = PLC_Device_CCD02_02_校正量測框_拼圖2校正座標1_Y.Value / 1000D;
                    CCD02_02拼圖2_X2 = PLC_Device_CCD02_02_校正量測框_拼圖2校正座標2_X.Value / 1000D;
                    CCD02_02拼圖2_Y2 = PLC_Device_CCD02_02_校正量測框_拼圖2校正座標2_Y.Value / 1000D;
                    CCD02_02拼圖2_X3 = PLC_Device_CCD02_02_校正量測框_拼圖2校正座標3_X.Value / 1000D;
                    CCD02_02拼圖2_Y3 = PLC_Device_CCD02_02_校正量測框_拼圖2校正座標3_Y.Value / 1000D;
                    CCD02_02拼圖2_X4 = PLC_Device_CCD02_02_校正量測框_拼圖2校正座標4_X.Value / 1000D;
                    CCD02_02拼圖2_Y4 = PLC_Device_CCD02_02_校正量測框_拼圖2校正座標4_Y.Value / 1000D;
                    #endregion
                    PLC_Device_CCD02_02_拼接校正.SetComment("PLC_CCD02_02_拼接校正");
                    PLC_Device_CCD02_02_拼接校正.Bool = false;
                    cnt_Program_CCD02_02_拼接校正 = 65535;
                }
                if (cnt_Program_CCD02_02_拼接校正 == 65535) cnt_Program_CCD02_02_拼接校正 = 1;
                if (cnt_Program_CCD02_02_拼接校正 == 1) cnt_Program_CCD02_02_拼接校正_檢查按下(ref cnt_Program_CCD02_02_拼接校正);
                if (cnt_Program_CCD02_02_拼接校正 == 2) cnt_Program_CCD02_02_拼接校正_初始化(ref cnt_Program_CCD02_02_拼接校正);
                if (cnt_Program_CCD02_02_拼接校正 == 3) cnt_Program_CCD02_02_拼接校正_拼接教導完成(ref cnt_Program_CCD02_02_拼接校正);
                if (cnt_Program_CCD02_02_拼接校正 == 4) cnt_Program_CCD02_02_拼接校正_繪製影像(ref cnt_Program_CCD02_02_拼接校正);
                if (cnt_Program_CCD02_02_拼接校正 == 5) cnt_Program_CCD02_02_拼接校正 = 65500;
                if (cnt_Program_CCD02_02_拼接校正 > 1) cnt_Program_CCD02_02_拼接校正_檢查放開(ref cnt_Program_CCD02_02_拼接校正);
                if (cnt_Program_CCD02_02_拼接校正 == 65500)
                {
                    PLC_Device_CCD02_02_拼接校正.Bool = false;
                    cnt_Program_CCD02_02_拼接校正 = 65535;
                }
            }

        }
        void cnt_Program_CCD02_02_拼接校正_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_02_拼接校正.Bool) cnt++;
        }
        void cnt_Program_CCD02_02_拼接校正_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_拼接校正.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_02_拼接校正_初始化(ref int cnt)
        {
            
            this.CCD02_02_AxImageSewer.UseGreylevelImage = true;
            this.CCD02_02_AxImageSewer.GreylevelBlankColor = 0;
            this.CCD02_02_AxImageSewer.DstImageWidth = h_Canvas_Tech_CCD02_02_拼接完成圖.ImageWidth;
            this.CCD02_02_AxImageSewer.DstImageHeight = h_Canvas_Tech_CCD02_02_拼接完成圖.ImageHeight;
            this.CCD02_02_AxImageSewer.DstImageWidth = 2592;
            this.CCD02_02_AxImageSewer.DstImageHeight = 1944;

            this.CCD02_02_AxImageSewer.NumOfSrcImages = 2;

            this.CCD02_02_AxImageSewer.SrcImageIndex = 0;
            this.CCD02_02_AxImageSewer.SrcImageWidth = h_Canvas_Tech_CCD02_02_拼接圖1.ImageWidth;
            this.CCD02_02_AxImageSewer.SrcImageHeight = h_Canvas_Tech_CCD02_02_拼接圖1.ImageHeight;
            this.CCD02_02_AxImageSewer.MapperMethod = AxOvkImage.TxAxImageSewerWorldMapperMethod.AX_IMAGE_SEWER_MAPPER_METHOD_PERSPECTIVE_METHOD;
            this.CCD02_02_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA1, CCD02_02拼圖1_X1, CCD02_02拼圖1_Y1, PLC_Device_CCD02_02_校正量測框_Real1_1_X.Value, PLC_Device_CCD02_02_校正量測框_Real1_1_Y.Value);
            this.CCD02_02_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA2, CCD02_02拼圖1_X2, CCD02_02拼圖1_Y2, PLC_Device_CCD02_02_校正量測框_Real1_2_X.Value, PLC_Device_CCD02_02_校正量測框_Real1_2_Y.Value);
            this.CCD02_02_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA3, CCD02_02拼圖1_X3, CCD02_02拼圖1_Y3, PLC_Device_CCD02_02_校正量測框_Real1_3_X.Value, PLC_Device_CCD02_02_校正量測框_Real1_3_Y.Value);
            this.CCD02_02_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA4, CCD02_02拼圖1_X4, CCD02_02拼圖1_Y4, PLC_Device_CCD02_02_校正量測框_Real1_4_X.Value, PLC_Device_CCD02_02_校正量測框_Real1_4_Y.Value);



            this.CCD02_02_AxImageSewer.SrcImageIndex = 1;
            this.CCD02_02_AxImageSewer.SrcImageWidth = h_Canvas_Tech_CCD02_02_拼接圖2.ImageWidth;
            this.CCD02_02_AxImageSewer.SrcImageHeight = h_Canvas_Tech_CCD02_02_拼接圖2.ImageHeight;
            this.CCD02_02_AxImageSewer.MapperMethod = AxOvkImage.TxAxImageSewerWorldMapperMethod.AX_IMAGE_SEWER_MAPPER_METHOD_PERSPECTIVE_METHOD;
            this.CCD02_02_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA1, CCD02_02拼圖2_X1, CCD02_02拼圖2_Y1, PLC_Device_CCD02_02_校正量測框_Real2_1_X.Value, PLC_Device_CCD02_02_校正量測框_Real2_1_Y.Value);
            this.CCD02_02_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA2, CCD02_02拼圖2_X2, CCD02_02拼圖2_Y2, PLC_Device_CCD02_02_校正量測框_Real2_2_X.Value, PLC_Device_CCD02_02_校正量測框_Real2_2_Y.Value);
            this.CCD02_02_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA3, CCD02_02拼圖2_X3, CCD02_02拼圖2_Y3, PLC_Device_CCD02_02_校正量測框_Real2_3_X.Value, PLC_Device_CCD02_02_校正量測框_Real2_3_Y.Value);
            this.CCD02_02_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA4, CCD02_02拼圖2_X4, CCD02_02拼圖2_Y4, PLC_Device_CCD02_02_校正量測框_Real2_4_X.Value, PLC_Device_CCD02_02_校正量測框_Real2_4_Y.Value);

            this.CCD02_02_AxImageSewer.Calibrate();

                cnt++;
            

        }
        void cnt_Program_CCD02_02_拼接校正_拼接教導完成(ref int cnt)
        {
            if (CCD02_02_AxImageSewer.Calibrate() == true)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD02_02_拼接校正_繪製影像(ref int cnt)
        {
            cnt++;
        }





        #endregion
        #region PLC_CCD02_02_影像拼接
        PLC_Device PLC_Device_CCD02_02_影像拼接_按鈕 = new PLC_Device("S18330");
        PLC_Device PLC_Device_CCD02_02_影像拼接 = new PLC_Device("S18325");
        PLC_Device PLC_Device_CCD02_02_影像拼接_RefreshCanvas = new PLC_Device("S18326");

        private void H_Canvas_Tech_CCD02_02_影像拼接_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            try
            {

                if (this.PLC_Device_CCD02_02_影像拼接_RefreshCanvas.Bool)
                {

                    Graphics g = Graphics.FromHdc((IntPtr)HDC);
                    // DrawingClass.Draw.十字中心(CCD02_02拼圖1校正點座標, 50, Color.Lime, 1, g, ZoomX, ZoomY);
                    g.Dispose();
                    g = null;
                }
            }
            catch
            {

            }

            this.PLC_Device_CCD02_02_影像拼接_RefreshCanvas.Bool = false;
        }
        int cnt_Program_CCD02_02_影像拼接 = 65534;
        void sub_Program_CCD02_02_影像拼接()
        {
            if (cnt_Program_CCD02_02_影像拼接 == 65534)
            {
                h_Canvas_Tech_CCD02_02_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_02_影像拼接_OnCanvasDrawEvent;

                PLC_Device_CCD02_02_影像拼接.SetComment("PLC_CCD02_02_影像拼接");
                PLC_Device_CCD02_02_影像拼接.Bool = false;
                cnt_Program_CCD02_02_影像拼接 = 65535;
            }
            if (cnt_Program_CCD02_02_影像拼接 == 65535) cnt_Program_CCD02_02_影像拼接 = 1;
            if (cnt_Program_CCD02_02_影像拼接 == 1) cnt_Program_CCD02_02_影像拼接_檢查按下(ref cnt_Program_CCD02_02_影像拼接);
            if (cnt_Program_CCD02_02_影像拼接 == 2) cnt_Program_CCD02_02_影像拼接_初始化(ref cnt_Program_CCD02_02_影像拼接);
            if (cnt_Program_CCD02_02_影像拼接 == 3) cnt_Program_CCD02_02_影像拼接_影像拼接(ref cnt_Program_CCD02_02_影像拼接);
            if (cnt_Program_CCD02_02_影像拼接 == 4) cnt_Program_CCD02_02_影像拼接_繪製影像(ref cnt_Program_CCD02_02_影像拼接);
            if (cnt_Program_CCD02_02_影像拼接 == 5) cnt_Program_CCD02_02_影像拼接 = 65500;
            if (cnt_Program_CCD02_02_影像拼接 > 1) cnt_Program_CCD02_02_影像拼接_檢查放開(ref cnt_Program_CCD02_02_影像拼接);
            if (cnt_Program_CCD02_02_影像拼接 == 65500)
            {
                PLC_Device_CCD02_02_影像拼接.Bool = false;
                cnt_Program_CCD02_02_影像拼接 = 65535;
            }
        }
        void cnt_Program_CCD02_02_影像拼接_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_02_影像拼接.Bool) cnt++;
        }
        void cnt_Program_CCD02_02_影像拼接_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_影像拼接.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_02_影像拼接_初始化(ref int cnt)
        {
            this.CCD02_02_AxImageSewer.SrcImageIndex = 0;
            this.CCD02_02_AxImageSewer.SrcImageHandle = h_Canvas_Tech_CCD02_02_拼接圖1.VegaHandle;
            this.CCD02_02_AxImageSewer.SrcImageIndex = 1;
            this.CCD02_02_AxImageSewer.SrcImageHandle = h_Canvas_Tech_CCD02_02_拼接圖2.VegaHandle;
            cnt++;
        }
        void cnt_Program_CCD02_02_影像拼接_影像拼接(ref int cnt)
        {

            CCD02_02_AxImageSewer.Sew();
            cnt++;

        }
        void cnt_Program_CCD02_02_影像拼接_繪製影像(ref int cnt)
        {
            if (CCD02_02_AxImageSewer.Sew())
            {
                PLC_Device_CCD02_02_影像拼接_RefreshCanvas.Bool = true;
                this.h_Canvas_Tech_CCD02_02_拼接完成圖.ImageCopy(this.CCD02_02_AxImageSewer.DstImageHandle);
                this.CCD02_02_SrcImageHandle_拼接完成圖 = this.CCD02_02_AxImageSewer.DstImageHandle;
                this.h_Canvas_Tech_CCD02_02_拼接完成圖.RefreshCanvas();
                cnt++;
            }
        }





        #endregion
        #region PLC_CCD02_02_校正量測框調整
        PLC_Device PLC_Device_CCD02_02_校正量測框調整_按鈕 = new PLC_Device("S18350");
        PLC_Device PLC_Device_CCD02_02_校正量測框調整 = new PLC_Device("S18345");
        PLC_Device PLC_Device_CCD02_02_拼圖1校正量測框調整_RefreshCanvas = new PLC_Device("S6012");
        PLC_Device PLC_Device_CCD02_02_拼圖2校正量測框調整_RefreshCanvas = new PLC_Device("S6013");
        private AxOvkBase.AxROIBW8 CCD02_02_AxROIBW8_拼圖1校正量測框調整;
        private AxOvkBlob.AxObject CCD02_02_AxObject_拼圖1校正量測框調整;
        private AxOvkBase.AxROIBW8 CCD02_02_AxROIBW8_拼圖2校正量測框調整;
        private AxOvkBlob.AxObject CCD02_02_AxObject_拼圖2校正量測框調整;
        private PLC_Device PLC_Device_CCD02_02_校正量測框_灰階門檻值 = new PLC_Device("F6300");
        private PLC_Device PLC_Device_CCD02_02_拼圖1校正量測框_OrgX = new PLC_Device("F6301");
        private PLC_Device PLC_Device_CCD02_02_拼圖1校正量測框_OrgY = new PLC_Device("F6302");
        private PLC_Device PLC_Device_CCD02_02_拼圖1校正量測框_Width = new PLC_Device("F6303");
        private PLC_Device PLC_Device_CCD02_02_拼圖1校正量測框_Height = new PLC_Device("F6304");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_面積上限 = new PLC_Device("F6305");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_面積下限 = new PLC_Device("F6306");
        private PLC_Device PLC_Device_CCD02_02_拼圖2校正量測框_OrgX = new PLC_Device("F6311");
        private PLC_Device PLC_Device_CCD02_02_拼圖2校正量測框_OrgY = new PLC_Device("F6312");
        private PLC_Device PLC_Device_CCD02_02_拼圖2校正量測框_Width = new PLC_Device("F6313");
        private PLC_Device PLC_Device_CCD02_02_拼圖2校正量測框_Height = new PLC_Device("F6314");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖1座標X = new PLC_Device("F6320");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖1座標Y = new PLC_Device("F6321");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖1校正座標1_X = new PLC_Device("F6322");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖1校正座標1_Y = new PLC_Device("F6323");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖1校正座標2_X = new PLC_Device("F6324");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖1校正座標2_Y = new PLC_Device("F6325");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖1校正座標3_X = new PLC_Device("F6326");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖1校正座標3_Y = new PLC_Device("F6327");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖1校正座標4_X = new PLC_Device("F6328");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖1校正座標4_Y = new PLC_Device("F6329");

        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖2座標X = new PLC_Device("F6330");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖2座標Y = new PLC_Device("F6331");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖2校正座標1_X = new PLC_Device("F6332");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖2校正座標1_Y = new PLC_Device("F6333");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖2校正座標2_X = new PLC_Device("F6334");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖2校正座標2_Y = new PLC_Device("F6335");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖2校正座標3_X = new PLC_Device("F6336");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖2校正座標3_Y = new PLC_Device("F6337");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖2校正座標4_X = new PLC_Device("F6338");
        private PLC_Device PLC_Device_CCD02_02_校正量測框_拼圖2校正座標4_Y = new PLC_Device("F6339");


        PointF CCD02_02拼圖1校正點座標 = new PointF();
        PointF CCD02_02拼圖2校正點座標 = new PointF();

        private AxOvkBase.TxAxHitHandle CCD02_02_TxAxHitHandle_AxROIBW8_拼圖1校正量測框調整 = new AxOvkBase.TxAxHitHandle();
        private bool flag_CCD02_02_拼圖1校正量測框調整_AxROIBW8_MouseDown;
        private AxOvkBase.TxAxHitHandle CCD02_02_TxAxHitHandle_AxROIBW8_拼圖2校正量測框調整 = new AxOvkBase.TxAxHitHandle();
        private bool flag_CCD02_02_拼圖2校正量測框調整_AxROIBW8_MouseDown;
        private void H_Canvas_Tech_CCD02_02_拼圖1校正量測框調整_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            
            try
            {

                if (this.PLC_Device_CCD02_02_拼圖1校正量測框調整_RefreshCanvas.Bool)
                {

                    Graphics g = Graphics.FromHdc((IntPtr)HDC);

                    this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.ShowTitle = true;
                    this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.ShowPlacement = false;
                    this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.Title = "拼圖1量測框";
                    this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.DrawFrame(HDC, ZoomX, ZoomY, 0, 0, 0x0000FF);

                    if (this.plC_CheckBox_CCD02_02_校正量測框_繪製量測區塊.Checked)
                    {
                        this.CCD02_02_AxObject_拼圖1校正量測框調整.DrawBlobs(HDC, -1, ZoomX, ZoomY, 0, 0, true, -1);

                    }
                    DrawingClass.Draw.十字中心(CCD02_02拼圖1校正點座標, 50, Color.Lime, 1, g, ZoomX, ZoomY);
                    g.Dispose();
                    g = null;
                }
            }
            catch
            {

            }

            this.PLC_Device_CCD02_02_拼圖1校正量測框調整_RefreshCanvas.Bool = false;
        }
        private void H_Canvas_Tech_CCD02_02_拼圖1校正量測框調整_OnCanvasMouseDownEvent(int x, int y, float ZoomX, float ZoomY, ref int InUsedEventNum, int InUsedCanvasHandle)
        {
            if (this.PLC_Device_CCD02_02_校正量測框調整.Bool)
            {
                this.CCD02_02_TxAxHitHandle_AxROIBW8_拼圖1校正量測框調整 = this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.HitTest(x, y, ZoomX, ZoomY, 0, 0);
                if (this.CCD02_02_TxAxHitHandle_AxROIBW8_拼圖1校正量測框調整 != AxOvkBase.TxAxHitHandle.AX_HANDLE_NONE)
                {
                    this.flag_CCD02_02_拼圖1校正量測框調整_AxROIBW8_MouseDown = true;
                    InUsedEventNum = 10;
                    return;
                }

            }

        }
        private void H_Canvas_Tech_CCD02_02_拼圖1校正量測框調整_OnCanvasMouseMoveEvent(int x, int y, float ZoomX, float ZoomY)
        {
            if (this.flag_CCD02_02_拼圖1校正量測框調整_AxROIBW8_MouseDown)
            {
                this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.DragROI(this.CCD02_02_TxAxHitHandle_AxROIBW8_拼圖1校正量測框調整, x, y, ZoomX, ZoomY, 0, 0);
                this.PLC_Device_CCD02_02_拼圖1校正量測框_OrgX.Value = this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.OrgX;
                this.PLC_Device_CCD02_02_拼圖1校正量測框_OrgY.Value = this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.OrgY;
                this.PLC_Device_CCD02_02_拼圖1校正量測框_Width.Value = this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.ROIWidth;
                this.PLC_Device_CCD02_02_拼圖1校正量測框_Height.Value = this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.ROIHeight;
            }

        }
        private void H_Canvas_Tech_CCD02_02_拼圖1校正量測框調整_OnCanvasMouseUpEvent(int x, int y, float ZoomX, float ZoomY)
        {
            this.flag_CCD02_02_拼圖1校正量測框調整_AxROIBW8_MouseDown = false;
        }

        private void H_Canvas_Tech_CCD02_02_拼圖2校正量測框調整_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            try
            {

                if (this.PLC_Device_CCD02_02_拼圖2校正量測框調整_RefreshCanvas.Bool)
                {

                    Graphics g = Graphics.FromHdc((IntPtr)HDC);

                    this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.ShowTitle = true;
                    this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.ShowPlacement = false;
                    this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.Title = "拼圖2量測框";
                    this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.DrawFrame(HDC, ZoomX, ZoomY, 0, 0, 0x0000FF);

                    if (this.plC_CheckBox_CCD02_02_校正量測框_繪製量測區塊.Checked)
                    {
                        this.CCD02_02_AxObject_拼圖2校正量測框調整.DrawBlobs(HDC, -1, ZoomX, ZoomY, 0, 0, true, -1);

                    }
                    DrawingClass.Draw.十字中心(CCD02_02拼圖2校正點座標, 50, Color.Lime, 1, g, ZoomX, ZoomY);
                    g.Dispose();
                    g = null;
                }
            }
            catch
            {

            }

            this.PLC_Device_CCD02_02_拼圖2校正量測框調整_RefreshCanvas.Bool = false;
        }
        private void H_Canvas_Tech_CCD02_02_拼圖2校正量測框調整_OnCanvasMouseDownEvent(int x, int y, float ZoomX, float ZoomY, ref int InUsedEventNum, int InUsedCanvasHandle)
        {
            if (this.PLC_Device_CCD02_02_校正量測框調整.Bool)
            {
                this.CCD02_02_TxAxHitHandle_AxROIBW8_拼圖2校正量測框調整 = this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.HitTest(x, y, ZoomX, ZoomY, 0, 0);
                if (this.CCD02_02_TxAxHitHandle_AxROIBW8_拼圖2校正量測框調整 != AxOvkBase.TxAxHitHandle.AX_HANDLE_NONE)
                {
                    this.flag_CCD02_02_拼圖2校正量測框調整_AxROIBW8_MouseDown = true;
                    InUsedEventNum = 10;
                    return;
                }

            }

        }
        private void H_Canvas_Tech_CCD02_02_拼圖2校正量測框調整_OnCanvasMouseMoveEvent(int x, int y, float ZoomX, float ZoomY)
        {
            if (this.flag_CCD02_02_拼圖2校正量測框調整_AxROIBW8_MouseDown)
            {
                this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.DragROI(this.CCD02_02_TxAxHitHandle_AxROIBW8_拼圖2校正量測框調整, x, y, ZoomX, ZoomY, 0, 0);
                this.PLC_Device_CCD02_02_拼圖2校正量測框_OrgX.Value = this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.OrgX;
                this.PLC_Device_CCD02_02_拼圖2校正量測框_OrgY.Value = this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.OrgY;
                this.PLC_Device_CCD02_02_拼圖2校正量測框_Width.Value = this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.ROIWidth;
                this.PLC_Device_CCD02_02_拼圖2校正量測框_Height.Value = this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.ROIHeight;
            }

        }
        private void H_Canvas_Tech_CCD02_02_拼圖2校正量測框調整_OnCanvasMouseUpEvent(int x, int y, float ZoomX, float ZoomY)
        {
            this.flag_CCD02_02_拼圖2校正量測框調整_AxROIBW8_MouseDown = false;
        }
        int cnt_Program_CCD02_02_校正量測框 = 65534;
        void sub_Program_CCD02_02_校正量測框()
        {
            if (cnt_Program_CCD02_02_校正量測框 == 65534)
            {

                this.h_Canvas_Tech_CCD02_02_拼接圖1.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_02_拼圖1校正量測框調整_OnCanvasDrawEvent;
                this.h_Canvas_Tech_CCD02_02_拼接圖1.OnCanvasMouseDownEvent += H_Canvas_Tech_CCD02_02_拼圖1校正量測框調整_OnCanvasMouseDownEvent;
                this.h_Canvas_Tech_CCD02_02_拼接圖1.OnCanvasMouseMoveEvent += H_Canvas_Tech_CCD02_02_拼圖1校正量測框調整_OnCanvasMouseMoveEvent;
                this.h_Canvas_Tech_CCD02_02_拼接圖1.OnCanvasMouseUpEvent += H_Canvas_Tech_CCD02_02_拼圖1校正量測框調整_OnCanvasMouseUpEvent;

                this.h_Canvas_Tech_CCD02_02_拼接圖2.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_02_拼圖2校正量測框調整_OnCanvasDrawEvent;
                this.h_Canvas_Tech_CCD02_02_拼接圖2.OnCanvasMouseDownEvent += H_Canvas_Tech_CCD02_02_拼圖2校正量測框調整_OnCanvasMouseDownEvent;
                this.h_Canvas_Tech_CCD02_02_拼接圖2.OnCanvasMouseMoveEvent += H_Canvas_Tech_CCD02_02_拼圖2校正量測框調整_OnCanvasMouseMoveEvent;
                this.h_Canvas_Tech_CCD02_02_拼接圖2.OnCanvasMouseUpEvent += H_Canvas_Tech_CCD02_02_拼圖2校正量測框調整_OnCanvasMouseUpEvent;


                if (PLC_Device_CCD02_02_拼圖1校正量測框_OrgX.Value <= 0) PLC_Device_CCD02_02_拼圖1校正量測框_OrgX.Value = 20;
                if (PLC_Device_CCD02_02_拼圖1校正量測框_OrgY.Value <= 0) PLC_Device_CCD02_02_拼圖1校正量測框_OrgY.Value = 20;
                if (PLC_Device_CCD02_02_拼圖1校正量測框_Width.Value <= 0) PLC_Device_CCD02_02_拼圖1校正量測框_Width.Value = 20;
                if (PLC_Device_CCD02_02_拼圖1校正量測框_Height.Value <= 0) PLC_Device_CCD02_02_拼圖1校正量測框_Height.Value = 20;
                if (PLC_Device_CCD02_02_拼圖2校正量測框_OrgX.Value <= 0) PLC_Device_CCD02_02_拼圖2校正量測框_OrgX.Value = 20;
                if (PLC_Device_CCD02_02_拼圖2校正量測框_OrgY.Value <= 0) PLC_Device_CCD02_02_拼圖2校正量測框_OrgY.Value = 20;
                if (PLC_Device_CCD02_02_拼圖2校正量測框_Width.Value <= 0) PLC_Device_CCD02_02_拼圖2校正量測框_Width.Value = 20;
                if (PLC_Device_CCD02_02_拼圖2校正量測框_Height.Value <= 0) PLC_Device_CCD02_02_拼圖2校正量測框_Height.Value = 20;

                PLC_Device_CCD02_02_校正量測框調整.SetComment("PLC_CCD02_02_校正量測框");
                PLC_Device_CCD02_02_校正量測框調整.Bool = false;
                cnt_Program_CCD02_02_校正量測框 = 65535;
            }
            if (cnt_Program_CCD02_02_校正量測框 == 65535) cnt_Program_CCD02_02_校正量測框 = 1;
            if (cnt_Program_CCD02_02_校正量測框 == 1) cnt_Program_CCD02_02_校正量測框_檢查按下(ref cnt_Program_CCD02_02_校正量測框);
            if (cnt_Program_CCD02_02_校正量測框 == 2) cnt_Program_CCD02_02_校正量測框_初始化(ref cnt_Program_CCD02_02_校正量測框);
            if (cnt_Program_CCD02_02_校正量測框 == 3) cnt_Program_CCD02_02_校正量測框_區塊分析(ref cnt_Program_CCD02_02_校正量測框);
            if (cnt_Program_CCD02_02_校正量測框 == 4) cnt_Program_CCD02_02_校正量測框_繪製影像(ref cnt_Program_CCD02_02_校正量測框);
            if (cnt_Program_CCD02_02_校正量測框 == 5) cnt_Program_CCD02_02_校正量測框 = 65500;
            if (cnt_Program_CCD02_02_校正量測框 > 1) cnt_Program_CCD02_02_校正量測框_檢查放開(ref cnt_Program_CCD02_02_校正量測框);
            if (cnt_Program_CCD02_02_校正量測框 == 65500)
            {
                //PLC_Device_CCD02_02_校正量測框調整.Bool = false;
                cnt_Program_CCD02_02_校正量測框 = 65535;
            }
        }
        void cnt_Program_CCD02_02_校正量測框_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_02_校正量測框調整.Bool) cnt++;
        }
        void cnt_Program_CCD02_02_校正量測框_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_校正量測框調整.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_02_校正量測框_初始化(ref int cnt)
        {


            this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.ParentHandle = this.CCD02_02_SrcImageHandle_拼接圖1;
            this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.OrgX = this.PLC_Device_CCD02_02_拼圖1校正量測框_OrgX.Value;
            this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.OrgY = this.PLC_Device_CCD02_02_拼圖1校正量測框_OrgY.Value;
            this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.ROIWidth = this.PLC_Device_CCD02_02_拼圖1校正量測框_Width.Value;
            this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.ROIHeight = this.PLC_Device_CCD02_02_拼圖1校正量測框_Height.Value;
            this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.SkewAngle = 0;

            this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.ParentHandle = this.CCD02_02_SrcImageHandle_拼接圖2;
            this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.OrgX = this.PLC_Device_CCD02_02_拼圖2校正量測框_OrgX.Value;
            this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.OrgY = this.PLC_Device_CCD02_02_拼圖2校正量測框_OrgY.Value;
            this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.ROIWidth = this.PLC_Device_CCD02_02_拼圖2校正量測框_Width.Value;
            this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.ROIHeight = this.PLC_Device_CCD02_02_拼圖2校正量測框_Height.Value;
            this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.SkewAngle = 0;
            cnt++;
        }
        void cnt_Program_CCD02_02_校正量測框_區塊分析(ref int cnt)
        {
            uint 區塊特徵總和 = 4294951423;
            this.CCD02_02_AxObject_拼圖1校正量測框調整.SrcImageHandle = this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.VegaHandle;

            this.CCD02_02_AxObject_拼圖1校正量測框調整.ObjectClass = AxOvkBlob.TxAxObjClass.AX_OBJECT_DETECT_LIGHTER_CLASS;
            this.CCD02_02_AxObject_拼圖1校正量測框調整.HighThreshold = PLC_Device_CCD02_02_校正量測框_灰階門檻值.Value;
            this.CCD02_02_AxObject_拼圖1校正量測框調整.BlobAnalyze(true);
            this.CCD02_02_AxObject_拼圖1校正量測框調整.CalculateFeatures((int)區塊特徵總和, -1);
            this.CCD02_02_AxObject_拼圖1校正量測框調整.SortObjects(AxOvkBlob.TxAxObjFeatureSortOrder.AX_OBJECT_SORT_ORDER_LARGE_TO_SMALL, AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, 0, -1);
            this.CCD02_02_AxObject_拼圖1校正量測框調整.SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_LESS_THAN, this.PLC_Device_CCD02_02_校正量測框_面積下限.Value);
            this.CCD02_02_AxObject_拼圖1校正量測框調整.SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_GREAT_THAN, this.PLC_Device_CCD02_02_校正量測框_面積上限.Value);
            if (this.CCD02_02_AxObject_拼圖1校正量測框調整.DetectedNumObjs > 0)
            {
                this.CCD02_02_AxObject_拼圖1校正量測框調整.BlobIndex = 0;
                int 拼圖1_X0 = this.CCD02_02_AxObject_拼圖1校正量測框調整.BlobLimBoxX;
                int 拼圖1_Y0 = this.CCD02_02_AxObject_拼圖1校正量測框調整.BlobLimBoxY;
                float 拼圖1_X1 = this.CCD02_02_AxObject_拼圖1校正量測框調整.BlobCentroidX;
                float 拼圖1_Y1 = this.CCD02_02_AxObject_拼圖1校正量測框調整.BlobCentroidY;

                this.CCD02_02拼圖1校正點座標.X = 拼圖1_X1;
                this.CCD02_02拼圖1校正點座標.X += this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.OrgX;
                this.CCD02_02拼圖1校正點座標.Y = 拼圖1_Y1;
                this.CCD02_02拼圖1校正點座標.Y += this.CCD02_02_AxROIBW8_拼圖1校正量測框調整.OrgY;
                this.PLC_Device_CCD02_02_校正量測框_拼圖1座標X.Value = (int)(CCD02_02拼圖1校正點座標.X * 1000);
                this.PLC_Device_CCD02_02_校正量測框_拼圖1座標Y.Value = (int)(CCD02_02拼圖1校正點座標.Y * 1000);

            }

            this.CCD02_02_AxObject_拼圖2校正量測框調整.SrcImageHandle = this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.VegaHandle;

            this.CCD02_02_AxObject_拼圖2校正量測框調整.ObjectClass = AxOvkBlob.TxAxObjClass.AX_OBJECT_DETECT_LIGHTER_CLASS;
            this.CCD02_02_AxObject_拼圖2校正量測框調整.HighThreshold = PLC_Device_CCD02_02_校正量測框_灰階門檻值.Value;
            this.CCD02_02_AxObject_拼圖2校正量測框調整.BlobAnalyze(true);
            this.CCD02_02_AxObject_拼圖2校正量測框調整.CalculateFeatures((int)區塊特徵總和, -1);
            this.CCD02_02_AxObject_拼圖2校正量測框調整.SortObjects(AxOvkBlob.TxAxObjFeatureSortOrder.AX_OBJECT_SORT_ORDER_LARGE_TO_SMALL, AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, 0, -1);
            this.CCD02_02_AxObject_拼圖2校正量測框調整.SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_LESS_THAN, this.PLC_Device_CCD02_02_校正量測框_面積下限.Value);
            this.CCD02_02_AxObject_拼圖2校正量測框調整.SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_GREAT_THAN, this.PLC_Device_CCD02_02_校正量測框_面積上限.Value);
            if (this.CCD02_02_AxObject_拼圖2校正量測框調整.DetectedNumObjs > 0)
            {
                this.CCD02_02_AxObject_拼圖2校正量測框調整.BlobIndex = 0;
                int 拼圖2_X0 = this.CCD02_02_AxObject_拼圖2校正量測框調整.BlobLimBoxX;
                int 拼圖2_Y0 = this.CCD02_02_AxObject_拼圖2校正量測框調整.BlobLimBoxY;
                float 拼圖2_X1 = this.CCD02_02_AxObject_拼圖2校正量測框調整.BlobCentroidX;
                float 拼圖2_Y1 = this.CCD02_02_AxObject_拼圖2校正量測框調整.BlobCentroidY;

                this.CCD02_02拼圖2校正點座標.X = 拼圖2_X1;
                this.CCD02_02拼圖2校正點座標.X += this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.OrgX;
                this.CCD02_02拼圖2校正點座標.Y = 拼圖2_Y1;
                this.CCD02_02拼圖2校正點座標.Y += this.CCD02_02_AxROIBW8_拼圖2校正量測框調整.OrgY;
                this.PLC_Device_CCD02_02_校正量測框_拼圖2座標X.Value = (int)(CCD02_02拼圖2校正點座標.X * 1000);
                this.PLC_Device_CCD02_02_校正量測框_拼圖2座標Y.Value = (int)(CCD02_02拼圖2校正點座標.Y * 1000);

            }

            cnt++;


        }
        void cnt_Program_CCD02_02_校正量測框_繪製影像(ref int cnt)
        {

            if (PLC_Device_CCD02_02_校正量測框調整_按鈕.Bool)
            {
                this.PLC_Device_CCD02_02_拼圖1校正量測框調整_RefreshCanvas.Bool = true;
                this.h_Canvas_Tech_CCD02_02_拼接圖1.RefreshCanvas();
            }


            if (PLC_Device_CCD02_02_校正量測框調整_按鈕.Bool)
            {
                this.PLC_Device_CCD02_02_拼圖2校正量測框調整_RefreshCanvas.Bool = true;
                this.h_Canvas_Tech_CCD02_02_拼接圖2.RefreshCanvas();
            }

            cnt++;
        }





        #endregion
        #region PLC_CCD02_02_Main_取像並檢驗
        PLC_Device PLC_Device_CCD02_02_Main_取像並檢驗 = new PLC_Device("S39930");
        PLC_Device PLC_Device_CCD02_02_PLC觸發檢測 = new PLC_Device("S39730");
        MyTimer CCD02_02_Init_Timer = new MyTimer();
        int cnt_Program_CCD02_02_Main_取像並檢驗 = 65534;
        void sub_Program_CCD02_02_Main_取像並檢驗()
        {
            if (cnt_Program_CCD02_02_Main_取像並檢驗 == 65534)
            {
                PLC_Device_CCD02_02_Main_取像並檢驗.SetComment("PLC_CCD02_02_Main_取像並檢驗");
                PLC_Device_CCD02_02_Main_取像並檢驗.Bool = false;
                PLC_Device_CCD02_02_PLC觸發檢測.Bool = false;

            }
            if (cnt_Program_CCD02_02_Main_取像並檢驗 == 65535) cnt_Program_CCD02_02_Main_取像並檢驗 = 1;
            if (cnt_Program_CCD02_02_Main_取像並檢驗 == 1) cnt_Program_CCD02_02_Main_取像並檢驗_檢查按下(ref cnt_Program_CCD02_02_Main_取像並檢驗);
            if (cnt_Program_CCD02_02_Main_取像並檢驗 == 2) cnt_Program_CCD02_02_Main_取像並檢驗_初始化(ref cnt_Program_CCD02_02_Main_取像並檢驗);
            if (cnt_Program_CCD02_02_Main_取像並檢驗 == 3) cnt_Program_CCD02_02_Main_取像並檢驗_開始SNAP(ref cnt_Program_CCD02_02_Main_取像並檢驗);
            if (cnt_Program_CCD02_02_Main_取像並檢驗 == 4) cnt_Program_CCD02_02_Main_取像並檢驗_結束SNAP(ref cnt_Program_CCD02_02_Main_取像並檢驗);
            if (cnt_Program_CCD02_02_Main_取像並檢驗 == 5) cnt_Program_CCD02_02_Main_取像並檢驗_開始計算一次(ref cnt_Program_CCD02_02_Main_取像並檢驗);
            if (cnt_Program_CCD02_02_Main_取像並檢驗 == 6) cnt_Program_CCD02_02_Main_取像並檢驗_結束計算一次(ref cnt_Program_CCD02_02_Main_取像並檢驗);
            if (cnt_Program_CCD02_02_Main_取像並檢驗 == 7) cnt_Program_CCD02_02_Main_取像並檢驗_繪製畫布(ref cnt_Program_CCD02_02_Main_取像並檢驗);
            if (cnt_Program_CCD02_02_Main_取像並檢驗 == 8) cnt_Program_CCD02_02_Main_取像並檢驗_檢查重測次數(ref cnt_Program_CCD02_02_Main_取像並檢驗);
            if (cnt_Program_CCD02_02_Main_取像並檢驗 == 9) cnt_Program_CCD02_02_Main_取像並檢驗 = 65500;
            if (cnt_Program_CCD02_02_Main_取像並檢驗 > 1) cnt_Program_CCD02_02_Main_取像並檢驗_檢查放開(ref cnt_Program_CCD02_02_Main_取像並檢驗);

            if (cnt_Program_CCD02_02_Main_取像並檢驗 == 65500)
            {
                PLC_Device_CCD02_02_Main_取像並檢驗.Bool = false;
                PLC_Device_CCD02_02_PLC觸發檢測.Bool = false;
                cnt_Program_CCD02_02_Main_取像並檢驗 = 65535;
            }
        }
        void cnt_Program_CCD02_02_Main_取像並檢驗_檢查按下(ref int cnt)
        {

            if (PLC_Device_CCD02_02_Main_取像並檢驗.Bool && !PLC_Device_CCD02_02_PLC觸發檢測.Bool)
            {

                cnt++;
            }

            else if (PLC_Device_CCD02_02_PLC觸發檢測.Bool)
            {

                cnt++;
            }



        }
        void cnt_Program_CCD02_02_Main_取像並檢驗_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_Main_取像並檢驗.Bool && !PLC_Device_CCD02_02_PLC觸發檢測.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_02_Main_取像並檢驗_初始化(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD02_02_Main_取像並檢驗_開始SNAP(ref int cnt)
        {
            cnt++;

        }
        void cnt_Program_CCD02_02_Main_取像並檢驗_結束SNAP(ref int cnt)
        {
            this.h_Canvas_Main_CCD02_02_檢測畫面.ImageCopy(h_Canvas_Tech_CCD02_02_拼接完成圖.VegaHandle);
            cnt++;

        }
        void cnt_Program_CCD02_02_Main_取像並檢驗_開始計算一次(ref int cnt)
        {
            if (!this.PLC_Device_CCD02_02_計算一次.Bool)
            {
                this.PLC_Device_CCD02_02_計算一次.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD02_02_Main_取像並檢驗_結束計算一次(ref int cnt)
        {
            if (!this.PLC_Device_CCD02_02_計算一次.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD02_02_Main_取像並檢驗_繪製畫布(ref int cnt)
        {
            if (CCD02_02_SrcImageHandle_拼接完成圖 != 0)
            {
                this.h_Canvas_Main_CCD02_02_檢測畫面.RefreshCanvas();
            }
            cnt++;
        }
        void cnt_Program_CCD02_02_Main_取像並檢驗_檢查重測次數(ref int cnt)
        {
            cnt++;
        }





        #endregion
        #region PLC_CCD02_02_Tech_檢驗一次
        PLC_Device PLC_Device_CCD02_02_Tech_檢驗一次 = new PLC_Device("S15345");
        int cnt_Program_CCD02_02_Tech_檢驗一次 = 65534;
        void sub_Program_CCD02_02_Tech_檢驗一次()
        {
            if (cnt_Program_CCD02_02_Tech_檢驗一次 == 65534)
            {
                PLC_Device_CCD02_02_Tech_檢驗一次.SetComment("PLC_CCD02_02_Tech_檢驗一次");
                PLC_Device_CCD02_02_Tech_檢驗一次.Bool = false;
                cnt_Program_CCD02_02_Tech_檢驗一次 = 65535;
            }
            if (cnt_Program_CCD02_02_Tech_檢驗一次 == 65535) cnt_Program_CCD02_02_Tech_檢驗一次 = 1;
            if (cnt_Program_CCD02_02_Tech_檢驗一次 == 1) cnt_Program_CCD02_02_Tech_檢驗一次_檢查按下(ref cnt_Program_CCD02_02_Tech_檢驗一次);
            if (cnt_Program_CCD02_02_Tech_檢驗一次 == 2) cnt_Program_CCD02_02_Tech_檢驗一次_初始化(ref cnt_Program_CCD02_02_Tech_檢驗一次);
            if (cnt_Program_CCD02_02_Tech_檢驗一次 == 3) cnt_Program_CCD02_02_Tech_檢驗一次_計算一次開始(ref cnt_Program_CCD02_02_Tech_檢驗一次);
            if (cnt_Program_CCD02_02_Tech_檢驗一次 == 4) cnt_Program_CCD02_02_Tech_檢驗一次_計算一次結束(ref cnt_Program_CCD02_02_Tech_檢驗一次);
            if (cnt_Program_CCD02_02_Tech_檢驗一次 == 5) cnt_Program_CCD02_02_Tech_檢驗一次_繪製畫布(ref cnt_Program_CCD02_02_Tech_檢驗一次);
            if (cnt_Program_CCD02_02_Tech_檢驗一次 == 6) cnt_Program_CCD02_02_Tech_檢驗一次 = 65500;
            if (cnt_Program_CCD02_02_Tech_檢驗一次 > 1) cnt_Program_CCD02_02_Tech_檢驗一次_檢查放開(ref cnt_Program_CCD02_02_Tech_檢驗一次);

            if (cnt_Program_CCD02_02_Tech_檢驗一次 == 65500)
            {
                PLC_Device_CCD02_02_Tech_檢驗一次.Bool = false;
                cnt_Program_CCD02_02_Tech_檢驗一次 = 65535;
            }
        }
        void cnt_Program_CCD02_02_Tech_檢驗一次_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_02_Tech_檢驗一次.Bool) cnt++;
        }
        void cnt_Program_CCD02_02_Tech_檢驗一次_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_Tech_檢驗一次.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_02_Tech_檢驗一次_初始化(ref int cnt)
        {

            cnt++;
        }
        void cnt_Program_CCD02_02_Tech_檢驗一次_計算一次開始(ref int cnt)
        {
            if (!this.PLC_Device_CCD02_02_計算一次.Bool)
            {
                this.PLC_Device_CCD02_02_計算一次.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD02_02_Tech_檢驗一次_計算一次結束(ref int cnt)
        {
            if (!this.PLC_Device_CCD02_02_計算一次.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD02_02_Tech_檢驗一次_繪製畫布(ref int cnt)
        {
            if (CCD02_02_SrcImageHandle_拼接完成圖 != 0)
            {
                this.h_Canvas_Tech_CCD02_02_拼接完成圖.RefreshCanvas();
            }
            cnt++;
        }

































        #endregion
        #region PLC_CCD02_02_計算一次
        PLC_Device PLC_Device_CCD02_02_計算一次 = new PLC_Device("S5035");
        PLC_Device PLC_Device_CCD02_02_計算一次_OK = new PLC_Device("S5036");
        PLC_Device PLC_Device_CCD02_02_計算一次_READY = new PLC_Device("S5037");
        MyTimer MyTimer_CCD02_02_計算一次 = new MyTimer();

        int cnt_Program_CCD02_02_計算一次 = 65534;
        void sub_Program_CCD02_02_計算一次()
        {
            this.PLC_Device_CCD02_02_計算一次_READY.Bool = !this.PLC_Device_CCD02_02_計算一次.Bool;
            if (cnt_Program_CCD02_02_計算一次 == 65534)
            {
                PLC_Device_CCD02_02_計算一次.SetComment("PLC_CCD02_02_計算一次");
                PLC_Device_CCD02_02_計算一次.Bool = false;

                cnt_Program_CCD02_02_計算一次 = 65535;
            }
            if (cnt_Program_CCD02_02_計算一次 == 65535) cnt_Program_CCD02_02_計算一次 = 1;
            if (cnt_Program_CCD02_02_計算一次 == 1) cnt_Program_CCD02_02_計算一次_檢查按下(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 2) cnt_Program_CCD02_02_計算一次_步驟01開始(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 3) cnt_Program_CCD02_02_計算一次_步驟01結束(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 4) cnt_Program_CCD02_02_計算一次_步驟02開始(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 5) cnt_Program_CCD02_02_計算一次_步驟02結束(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 6) cnt_Program_CCD02_02_計算一次_步驟03開始(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 7) cnt_Program_CCD02_02_計算一次_步驟03結束(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 8) cnt_Program_CCD02_02_計算一次_步驟04開始(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 9) cnt_Program_CCD02_02_計算一次_步驟04結束(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 10) cnt_Program_CCD02_02_計算一次_步驟05開始(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 11) cnt_Program_CCD02_02_計算一次_步驟05結束(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 12) cnt_Program_CCD02_02_計算一次_步驟06開始(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 13) cnt_Program_CCD02_02_計算一次_步驟06結束(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 14) cnt_Program_CCD02_02_計算一次_計算結果(ref cnt_Program_CCD02_02_計算一次);
            if (cnt_Program_CCD02_02_計算一次 == 15) cnt_Program_CCD02_02_計算一次 = 65500;
            if (cnt_Program_CCD02_02_計算一次 > 1) cnt_Program_CCD02_02_計算一次_檢查放開(ref cnt_Program_CCD02_02_計算一次);

            if (cnt_Program_CCD02_02_計算一次 == 65500)
            {
                PLC_Device_CCD02_02_計算一次.Bool = false;
                cnt_Program_CCD02_02_計算一次 = 65535;
            }
        }
        void cnt_Program_CCD02_02_計算一次_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_02_計算一次.Bool) cnt++;
        }
        void cnt_Program_CCD02_02_計算一次_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_計算一次.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_02_計算一次_初始化(ref int cnt)
        {
            PLC_Device_CCD02_02_PIN量測_量測框調整.Bool = false;
            PLC_Device_CCD02_02_PIN量測_檢測距離計算.Bool = false;
            PLC_Device_CCD02_02_PIN正位度量測_設定規範位置.Bool = false;
            PLC_Device_CCD02_02_PIN量測_檢測距離計算.Bool = false;
            cnt++;
        }
        void cnt_Program_CCD02_02_計算一次_步驟01開始(ref int cnt)
        {
            this.MyTimer_CCD02_02_計算一次.TickStop();
            GetTickTime = this.MyTimer_CCD02_02_計算一次.GetTickTime();
            this.MyTimer_CCD02_02_計算一次.StartTickTime(99999);


                cnt++;
            

        }
        void cnt_Program_CCD02_02_計算一次_步驟01結束(ref int cnt)
        {

                cnt++;
            
        }
        void cnt_Program_CCD02_02_計算一次_步驟02開始(ref int cnt)
        {
            if (!this.PLC_Device_CCD02_02_PIN量測_量測框調整.Bool)
            {
                this.PLC_Device_CCD02_02_PIN量測_量測框調整.Bool = true;
                cnt++;
            }

        }
        void cnt_Program_CCD02_02_計算一次_步驟02結束(ref int cnt)
        {
            if (!this.PLC_Device_CCD02_02_PIN量測_量測框調整.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD02_02_計算一次_步驟03開始(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_PIN量測_檢測距離計算.Bool && !PLC_Device_CCD02_02_PIN正位度量測_設定規範位置.Bool)
            {
                PLC_Device_CCD02_02_PIN量測_檢測距離計算.Bool = true;
                PLC_Device_CCD02_02_PIN正位度量測_設定規範位置.Bool = true;
            }
            cnt++;
        }
        void cnt_Program_CCD02_02_計算一次_步驟03結束(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_PIN量測_檢測距離計算.Bool && !PLC_Device_CCD02_02_PIN正位度量測_設定規範位置.Bool)
            {
                cnt++;
            }

        }
        void cnt_Program_CCD02_02_計算一次_步驟04開始(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_PIN量測_檢測距離計算.Bool)
            {
                PLC_Device_CCD02_02_PIN量測_檢測正位度計算.Bool = true;
            }
            cnt++;
        }
        void cnt_Program_CCD02_02_計算一次_步驟04結束(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_PIN量測_檢測正位度計算.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD02_02_計算一次_步驟05開始(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD02_02_計算一次_步驟05結束(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD02_02_計算一次_步驟06開始(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD02_02_計算一次_步驟06結束(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD02_02_計算一次_計算結果(ref int cnt)
        {
            bool flag = true;
            if (!this.PLC_Device_CCD02_02_PIN量測_量測框調整_OK.Bool) flag = false;


            this.PLC_Device_CCD02_02_計算一次_OK.Bool = flag;
            //flag_CCD02_02_上端水平度寫入列表資料 = true;
            //flag_CCD02_02_上端間距寫入列表資料 = true;
            //flag_CCD02_02_上端水平度差值寫入列表資料 = true;

            cnt++;
        }





        #endregion

        #region PLC_CCD02_02_PIN量測_量測框調整
        MyTimer MyTimer_CCD02_02_PIN量測_量測框調整 = new MyTimer();
        PLC_Device PLC_Device_CCD02_02_PIN量測_量測框調整按鈕 = new PLC_Device("S6270");
        PLC_Device PLC_Device_CCD02_02_PIN量測_量測框調整 = new PLC_Device("S6265");
        PLC_Device PLC_Device_CCD02_02_PIN量測_量測框調整_OK = new PLC_Device("S6266");
        PLC_Device PLC_Device_CCD02_02_PIN量測_量測框調整_測試完成 = new PLC_Device("S6267");
        PLC_Device PLC_Device_CCD02_02_PIN量測_量測框調整_RefreshCanvas = new PLC_Device("S6568");

        private List<AxOvkBase.AxROIBW8> List_CCD02_02_PIN量測_AxROIBW8_量測框調整 = new List<AxOvkBase.AxROIBW8>();
        private List<AxOvkBlob.AxObject> List_CCD02_02_PIN量測_AxObject_區塊分析 = new List<AxOvkBlob.AxObject>();
        private AxOvkPat.AxVisionInspectionFrame CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整;

        private List<PLC_Device> List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值 = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD02_02_PIN量測參數_OrgX = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD02_02_PIN量測參數_OrgY = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD02_02_PIN量測參數_Width = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD02_02_PIN量測參數_Height = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD02_02_PIN量測參數_面積上限 = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD02_02_PIN量測參數_面積下限 = new List<PLC_Device>();
        private PointF[] List_CCD02_02_PIN量測參數_量測點 = new PointF[40];
        private PointF[] List_CCD02_02_PIN量測參數_量測點_結果 = new PointF[40];
        private Point[] List_CCD02_02_PIN量測參數_量測點_轉換後座標 = new Point[40];

        private bool[] List_CCD02_02_PIN量測參數_量測點_有無 = new bool[40];

        #region 灰階門檻值
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN01 = new PLC_Device("F1400");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN02 = new PLC_Device("F1401");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN03 = new PLC_Device("F1402");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN04 = new PLC_Device("F1403");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN05 = new PLC_Device("F1404");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN06 = new PLC_Device("F1405");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN07 = new PLC_Device("F1406");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN08 = new PLC_Device("F1407");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN09 = new PLC_Device("F1408");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN10 = new PLC_Device("F1409");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN11 = new PLC_Device("F1410");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN12 = new PLC_Device("F1411");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN13 = new PLC_Device("F1412");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN14 = new PLC_Device("F1413");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN15 = new PLC_Device("F1414");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN16 = new PLC_Device("F1415");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN17 = new PLC_Device("F1416");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN18 = new PLC_Device("F1417");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN19 = new PLC_Device("F1418");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN20 = new PLC_Device("F1419");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN21 = new PLC_Device("F1420");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN22 = new PLC_Device("F1421");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN23 = new PLC_Device("F1422");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN24 = new PLC_Device("F1423");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN25 = new PLC_Device("F1424");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN26 = new PLC_Device("F1425");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN27 = new PLC_Device("F1426");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN28 = new PLC_Device("F1427");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN29 = new PLC_Device("F1428");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN30 = new PLC_Device("F1429");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN31 = new PLC_Device("F1430");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN32 = new PLC_Device("F1431");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN33 = new PLC_Device("F1432");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN34 = new PLC_Device("F1433");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN35 = new PLC_Device("F1434");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN36 = new PLC_Device("F1435");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN37 = new PLC_Device("F1436");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN38 = new PLC_Device("F1437");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN39 = new PLC_Device("F1438");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN40 = new PLC_Device("F1439");
        #endregion
        #region OrgX
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN01 = new PLC_Device("F1500");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN02 = new PLC_Device("F1501");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN03 = new PLC_Device("F1502");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN04 = new PLC_Device("F1503");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN05 = new PLC_Device("F1504");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN06 = new PLC_Device("F1505");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN07 = new PLC_Device("F1506");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN08 = new PLC_Device("F1507");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN09 = new PLC_Device("F1508");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN10 = new PLC_Device("F1509");

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN11 = new PLC_Device("F1510");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN12 = new PLC_Device("F1511");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN13 = new PLC_Device("F1512");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN14 = new PLC_Device("F1513");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN15 = new PLC_Device("F1514");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN16 = new PLC_Device("F1515");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN17 = new PLC_Device("F1516");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN18 = new PLC_Device("F1517");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN19 = new PLC_Device("F1518");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN20 = new PLC_Device("F1519");

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN21 = new PLC_Device("F1520");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN22 = new PLC_Device("F1521");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN23 = new PLC_Device("F1522");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN24 = new PLC_Device("F1523");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN25 = new PLC_Device("F1524");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN26 = new PLC_Device("F1525");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN27 = new PLC_Device("F1526");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN28 = new PLC_Device("F1527");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN29 = new PLC_Device("F1528");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN30 = new PLC_Device("F1529");

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN31 = new PLC_Device("F1530");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN32 = new PLC_Device("F1531");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN33 = new PLC_Device("F1532");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN34 = new PLC_Device("F1533");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN35 = new PLC_Device("F1534");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN36 = new PLC_Device("F1535");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN37 = new PLC_Device("F1536");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN38 = new PLC_Device("F1537");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN39 = new PLC_Device("F1538");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN40 = new PLC_Device("F1539");
        #endregion
        #region OrgY
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN01 = new PLC_Device("F1600");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN02 = new PLC_Device("F1601");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN03 = new PLC_Device("F1602");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN04 = new PLC_Device("F1603");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN05 = new PLC_Device("F1604");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN06 = new PLC_Device("F1605");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN07 = new PLC_Device("F1606");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN08 = new PLC_Device("F1607");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN09 = new PLC_Device("F1608");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN10 = new PLC_Device("F1609");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN11 = new PLC_Device("F1610");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN12 = new PLC_Device("F1611");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN13 = new PLC_Device("F1612");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN14 = new PLC_Device("F1613");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN15 = new PLC_Device("F1614");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN16 = new PLC_Device("F1615");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN17 = new PLC_Device("F1616");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN18 = new PLC_Device("F1617");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN19 = new PLC_Device("F1618");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN20 = new PLC_Device("F1619");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN21 = new PLC_Device("F1620");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN22 = new PLC_Device("F1621");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN23 = new PLC_Device("F1622");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN24 = new PLC_Device("F1623");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN25 = new PLC_Device("F1624");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN26 = new PLC_Device("F1625");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN27 = new PLC_Device("F1626");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN28 = new PLC_Device("F1627");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN29 = new PLC_Device("F1628");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN30 = new PLC_Device("F1629");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN31 = new PLC_Device("F1630");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN32 = new PLC_Device("F1631");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN33 = new PLC_Device("F1632");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN34 = new PLC_Device("F1633");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN35 = new PLC_Device("F1634");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN36 = new PLC_Device("F1635");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN37 = new PLC_Device("F1636");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN38 = new PLC_Device("F1637");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN39 = new PLC_Device("F1638");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN40 = new PLC_Device("F1639");

        #endregion
        #region Width
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN01 = new PLC_Device("F1700");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN02 = new PLC_Device("F1701");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN03 = new PLC_Device("F1702");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN04 = new PLC_Device("F1703");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN05 = new PLC_Device("F1704");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN06 = new PLC_Device("F1705");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN07 = new PLC_Device("F1706");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN08 = new PLC_Device("F1707");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN09 = new PLC_Device("F1708");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN10 = new PLC_Device("F1709");

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN11 = new PLC_Device("F1710");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN12 = new PLC_Device("F1711");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN13 = new PLC_Device("F1712");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN14 = new PLC_Device("F1713");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN15 = new PLC_Device("F1714");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN16 = new PLC_Device("F1715");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN17 = new PLC_Device("F1716");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN18 = new PLC_Device("F1717");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN19 = new PLC_Device("F1718");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN20 = new PLC_Device("F1719");

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN21 = new PLC_Device("F1720");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN22 = new PLC_Device("F1721");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN23 = new PLC_Device("F1722");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN24 = new PLC_Device("F1723");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN25 = new PLC_Device("F1724");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN26 = new PLC_Device("F1725");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN27 = new PLC_Device("F1726");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN28 = new PLC_Device("F1727");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN29 = new PLC_Device("F1728");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN30 = new PLC_Device("F1729");

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN31 = new PLC_Device("F1730");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN32 = new PLC_Device("F1731");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN33 = new PLC_Device("F1732");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN34 = new PLC_Device("F1733");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN35 = new PLC_Device("F1734");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN36 = new PLC_Device("F1735");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN37 = new PLC_Device("F1736");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN38 = new PLC_Device("F1737");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN39 = new PLC_Device("F1738");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Width_PIN40 = new PLC_Device("F1739");

        #endregion
        #region Height
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN01 = new PLC_Device("F1800");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN02 = new PLC_Device("F1801");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN03 = new PLC_Device("F1802");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN04 = new PLC_Device("F1803");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN05 = new PLC_Device("F1804");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN06 = new PLC_Device("F1805");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN07 = new PLC_Device("F1806");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN08 = new PLC_Device("F1807");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN09 = new PLC_Device("F1808");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN10 = new PLC_Device("F1809");

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN11 = new PLC_Device("F1810");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN12 = new PLC_Device("F1811");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN13 = new PLC_Device("F1812");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN14 = new PLC_Device("F1813");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN15 = new PLC_Device("F1814");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN16 = new PLC_Device("F1815");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN17 = new PLC_Device("F1816");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN18 = new PLC_Device("F1817");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN19 = new PLC_Device("F1818");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN20 = new PLC_Device("F1819");

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN21 = new PLC_Device("F1820");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN22 = new PLC_Device("F1821");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN23 = new PLC_Device("F1822");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN24 = new PLC_Device("F1823");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN25 = new PLC_Device("F1824");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN26 = new PLC_Device("F1825");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN27 = new PLC_Device("F1826");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN28 = new PLC_Device("F1827");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN29 = new PLC_Device("F1828");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN30 = new PLC_Device("F1829");

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN31 = new PLC_Device("F1830");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN32 = new PLC_Device("F1831");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN33 = new PLC_Device("F1832");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN34 = new PLC_Device("F1833");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN35 = new PLC_Device("F1834");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN36 = new PLC_Device("F1835");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN37 = new PLC_Device("F1836");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN38 = new PLC_Device("F1837");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN39 = new PLC_Device("F1838");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_Height_PIN40 = new PLC_Device("F1839");
        #endregion
        #region 面積上限

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN01 = new PLC_Device("F1900");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN02 = new PLC_Device("F1901");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN03 = new PLC_Device("F1902");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN04 = new PLC_Device("F1903");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN05 = new PLC_Device("F1904");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN06 = new PLC_Device("F1905");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN07 = new PLC_Device("F1906");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN08 = new PLC_Device("F1907");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN09 = new PLC_Device("F1908");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN10 = new PLC_Device("F1909");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN11 = new PLC_Device("F1910");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN12 = new PLC_Device("F1911");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN13 = new PLC_Device("F1912");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN14 = new PLC_Device("F1913");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN15 = new PLC_Device("F1914");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN16 = new PLC_Device("F1915");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN17 = new PLC_Device("F1916");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN18 = new PLC_Device("F1917");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN19 = new PLC_Device("F1918");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN20 = new PLC_Device("F1919");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN21 = new PLC_Device("F1920");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN22 = new PLC_Device("F1921");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN23 = new PLC_Device("F1922");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN24 = new PLC_Device("F1923");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN25 = new PLC_Device("F1924");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN26 = new PLC_Device("F1925");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN27 = new PLC_Device("F1926");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN28 = new PLC_Device("F1927");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN29 = new PLC_Device("F1928");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN30 = new PLC_Device("F1929");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN31 = new PLC_Device("F1930");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN32 = new PLC_Device("F1931");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN33 = new PLC_Device("F1932");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN34 = new PLC_Device("F1933");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN35 = new PLC_Device("F1934");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN36 = new PLC_Device("F1935");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN37 = new PLC_Device("F1936");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN38 = new PLC_Device("F1937");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN39 = new PLC_Device("F1938");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN40 = new PLC_Device("F1939");

        #endregion
        #region 面積下限

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN01 = new PLC_Device("F2000");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN02 = new PLC_Device("F2001");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN03 = new PLC_Device("F2002");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN04 = new PLC_Device("F2003");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN05 = new PLC_Device("F2004");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN06 = new PLC_Device("F2005");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN07 = new PLC_Device("F2006");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN08 = new PLC_Device("F2007");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN09 = new PLC_Device("F2008");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN10 = new PLC_Device("F2009");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN11 = new PLC_Device("F2010");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN12 = new PLC_Device("F2011");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN13 = new PLC_Device("F2012");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN14 = new PLC_Device("F2013");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN15 = new PLC_Device("F2014");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN16 = new PLC_Device("F2015");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN17 = new PLC_Device("F2016");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN18 = new PLC_Device("F2017");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN19 = new PLC_Device("F2018");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN20 = new PLC_Device("F2019");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN21 = new PLC_Device("F2020");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN22 = new PLC_Device("F2021");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN23 = new PLC_Device("F2022");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN24 = new PLC_Device("F2023");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN25 = new PLC_Device("F2024");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN26 = new PLC_Device("F2025");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN27 = new PLC_Device("F2026");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN28 = new PLC_Device("F2027");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN29 = new PLC_Device("F2028");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN30 = new PLC_Device("F2029");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN31 = new PLC_Device("F2030");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN32 = new PLC_Device("F2031");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN33 = new PLC_Device("F2032");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN34 = new PLC_Device("F2033");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN35 = new PLC_Device("F2034");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN36 = new PLC_Device("F2035");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN37 = new PLC_Device("F2036");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN38 = new PLC_Device("F2037");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN39 = new PLC_Device("F2038");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN40 = new PLC_Device("F2039");

        #endregion
        AxOvkBase.TxAxHitHandle[] CCD02_02_PIN量測_AxROIBW8_TxAxHitHandle = new AxOvkBase.TxAxHitHandle[40];
        bool[] flag_CCD02_02_PIN量測_AxROIBW8_MouseDown = new bool[40];
        private void H_Canvas_Tech_CCD02_02_PIN量測_量測框調整_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            if (PLC_Device_CCD02_02_Main_取像並檢驗.Bool || PLC_Device_CCD02_02_PLC觸發檢測.Bool)
            {
                try
                {
                    Graphics g = Graphics.FromHdc((IntPtr)HDC);
                    for (int i = 0; i < this.List_CCD02_02_PIN量測參數_量測點.Length; i++)
                    {
                        DrawingClass.Draw.十字中心(this.List_CCD02_02_PIN量測參數_量測點[i], 50, Color.Lime, 2, g, ZoomX, ZoomY);
                    }
                    g.Dispose();
                    g = null;
                }
                catch
                {

                }

            }

            else if(PLC_Device_CCD02_02_Tech_檢驗一次.Bool)
            {
                if (this.PLC_Device_CCD02_02_PIN量測_量測框調整_RefreshCanvas.Bool)
                {
                    try
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);
                        for (int i = 0; i < this.List_CCD02_02_PIN量測參數_量測點.Length; i++)
                        {
                            DrawingClass.Draw.十字中心(this.List_CCD02_02_PIN量測參數_量測點[i], 50, Color.Lime, 2, g, ZoomX, ZoomY);
                        }
                        g.Dispose();
                        g = null;
                    }
                    catch
                    {

                    }


                }


            }
            else
            {
                if (this.PLC_Device_CCD02_02_PIN量測_量測框調整_RefreshCanvas.Bool)
                {
                    try
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);
                        PointF po_str_PIN到基準Y = new PointF(200, 250);
                        Font font = new Font("微軟正黑體", 10);

                        if (this.plC_CheckBox_CCD02_02_PIN量測_繪製量測框.Checked)
                        {
                            for (int i = 0; i < this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Count; i++)
                            {
                                this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].ShowTitle = true;
                                this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].ShowPlacement = false;
                                this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].Title = string.Format("{0}", (i + 1).ToString("00"));
                                this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].DrawFrame(HDC, ZoomX, ZoomY, 0, 0, 0x0000FF);
                            }
                        }
                        if (this.plC_CheckBox_CCD02_02_PIN量測_繪製量測區塊.Checked)
                        {
                            for (int i = 0; i < this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Count; i++)
                            {
                                this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].DrawBlobs(HDC, -1, ZoomX, ZoomY, 0, 0, true, -1);
                            }

                        }
                        for (int i = 0; i < this.List_CCD02_02_PIN量測參數_量測點.Length; i++)
                        {
                            DrawingClass.Draw.十字中心(this.List_CCD02_02_PIN量測參數_量測點[i], 50, Color.Lime, 2, g, ZoomX, ZoomY);
                        }
                        g.Dispose();
                        g = null;
                    }
                    catch
                    {

                    }


                }
            }



            this.PLC_Device_CCD02_02_PIN量測_量測框調整_RefreshCanvas.Bool = false;
        }
        private void H_Canvas_Tech_CCD02_02_PIN量測_量測框調整_OnCanvasMouseDownEvent(int x, int y, float ZoomX, float ZoomY, ref int InUsedEventNum, int InUsedCanvasHandle)
        {
            if (this.PLC_Device_CCD02_02_PIN量測_量測框調整.Bool)
            {
                for (int i = 0; i < this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Count; i++)
                {
                    this.CCD02_02_PIN量測_AxROIBW8_TxAxHitHandle[i] = this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].HitTest(x, y, ZoomX, ZoomY, 0, 0);
                    if (this.CCD02_02_PIN量測_AxROIBW8_TxAxHitHandle[i] != AxOvkBase.TxAxHitHandle.AX_HANDLE_NONE)
                    {
                        this.flag_CCD02_02_PIN量測_AxROIBW8_MouseDown[i] = true;
                        InUsedEventNum = 10;
                        return;
                    }
                }


            }

        }
        private void H_Canvas_Tech_CCD02_02_PIN量測_量測框調整_OnCanvasMouseMoveEvent(int x, int y, float ZoomX, float ZoomY)
        {
            for (int i = 0; i < this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Count; i++)
            {
                if (this.flag_CCD02_02_PIN量測_AxROIBW8_MouseDown[i])
                {
                    this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].DragROI(this.CCD02_02_PIN量測_AxROIBW8_TxAxHitHandle[i], x, y, ZoomX, ZoomY, 0, 0);
                    this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[i].Value = this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].OrgX;
                    this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[i].Value = this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].OrgY;
                    this.List_PLC_Device_CCD02_02_PIN量測參數_Width[i].Value = this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].ROIWidth;
                    this.List_PLC_Device_CCD02_02_PIN量測參數_Height[i].Value = this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].ROIHeight;
                }
            }

        }
        private void H_Canvas_Tech_CCD02_02_PIN量測_量測框調整_OnCanvasMouseUpEvent(int x, int y, float ZoomX, float ZoomY)
        {
            for (int i = 0; i < this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Count; i++)
            {
                this.flag_CCD02_02_PIN量測_AxROIBW8_MouseDown[i] = false;
            }
        }

        int cnt_Program_CCD02_02_PIN量測_量測框調整 = 65534;
        void sub_Program_CCD02_02_PIN量測_量測框調整()
        {
            if (cnt_Program_CCD02_02_PIN量測_量測框調整 == 65534)
            {
                this.h_Canvas_Tech_CCD02_02_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_02_PIN量測_量測框調整_OnCanvasDrawEvent;
                this.h_Canvas_Tech_CCD02_02_拼接完成圖.OnCanvasMouseDownEvent += H_Canvas_Tech_CCD02_02_PIN量測_量測框調整_OnCanvasMouseDownEvent;
                this.h_Canvas_Tech_CCD02_02_拼接完成圖.OnCanvasMouseMoveEvent += H_Canvas_Tech_CCD02_02_PIN量測_量測框調整_OnCanvasMouseMoveEvent;
                this.h_Canvas_Tech_CCD02_02_拼接完成圖.OnCanvasMouseUpEvent += H_Canvas_Tech_CCD02_02_PIN量測_量測框調整_OnCanvasMouseUpEvent;

                this.h_Canvas_Main_CCD02_02_檢測畫面.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_02_PIN量測_量測框調整_OnCanvasDrawEvent;

                #region 灰階門檻值
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN01);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN02);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN03);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN04);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN05);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN06);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN07);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN08);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN09);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN10);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN11);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN12);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN13);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN14);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN15);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN16);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN17);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN18);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN19);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN20);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN21);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN22);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN23);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN24);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN25);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN26);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN27);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN28);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN29);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN30);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN31);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN32);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN33);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN34);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN35);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN36);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN37);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN38);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN39);
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值.Add(this.PLC_Device_CCD02_02_PIN量測參數_灰階門檻值_PIN40);

                #endregion
                #region OrgX
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN01);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN02);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN03);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN04);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN05);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN06);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN07);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN08);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN09);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN10);

                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN11);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN12);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN13);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN14);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN15);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN16);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN17);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN18);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN19);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN20);

                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN21);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN22);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN23);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN24);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN25);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN26);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN27);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN28);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN29);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN30);

                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN31);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN32);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN33);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN34);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN35);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN36);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN37);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN38);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN39);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgX_PIN40);
                #endregion
                #region OrgY
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN01);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN02);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN03);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN04);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN05);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN06);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN07);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN08);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN09);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN10);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN11);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN12);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN13);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN14);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN15);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN16);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN17);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN18);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN19);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN20);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN21);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN22);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN23);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN24);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN25);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN26);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN27);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN28);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN29);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN30);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN31);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN32);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN33);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN34);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN35);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN36);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN37);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN38);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN39);
                this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY.Add(this.PLC_Device_CCD02_02_PIN量測參數_OrgY_PIN40);
                #endregion
                #region Width
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN01);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN02);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN03);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN04);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN05);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN06);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN07);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN08);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN09);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN10);

                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN11);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN12);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN13);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN14);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN15);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN16);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN17);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN18);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN19);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN20);

                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN21);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN22);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN23);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN24);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN25);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN26);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN27);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN28);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN29);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN30);

                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN31);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN32);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN33);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN34);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN35);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN36);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN37);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN38);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN39);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width.Add(this.PLC_Device_CCD02_02_PIN量測參數_Width_PIN40);

                #endregion
                #region Height
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN01);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN02);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN03);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN04);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN05);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN06);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN07);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN08);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN09);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN10);

                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN11);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN12);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN13);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN14);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN15);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN16);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN17);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN18);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN19);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN20);

                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN21);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN22);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN23);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN24);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN25);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN26);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN27);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN28);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN29);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN30);

                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN31);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN32);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN33);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN34);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN35);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN36);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN37);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN38);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN39);
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height.Add(this.PLC_Device_CCD02_02_PIN量測參數_Height_PIN40);

                #endregion
                #region 面積上限
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN01);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN02);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN03);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN04);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN05);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN06);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN07);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN08);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN09);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN10);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN11);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN12);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN13);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN14);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN15);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN16);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN17);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN18);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN19);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN20);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN21);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN22);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN23);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN24);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN25);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN26);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN27);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN28);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN29);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN30);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN31);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN32);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN33);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN34);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN35);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN36);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN37);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN38);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN39);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積上限_PIN40);

                #endregion
                #region 面積下限
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN01);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN02);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN03);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN04);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN05);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN06);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN07);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN08);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN09);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN10);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN11);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN12);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN13);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN14);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN15);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN16);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN17);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN18);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN19);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN20);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN21);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN22);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN23);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN24);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN25);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN26);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN27);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN28);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN29);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN30);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN31);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN32);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN33);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN34);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN35);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN36);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN37);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN38);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN39);
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限.Add(this.PLC_Device_CCD02_02_PIN量測參數_面積下限_PIN40);

                #endregion
                for (int i = 0; i < 40; i++)
                {
                    if (this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值[i].Value == 0) this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值[i].Value = 200;
                    if (this.List_PLC_Device_CCD02_02_PIN量測參數_Height[i].Value == 0) this.List_PLC_Device_CCD02_02_PIN量測參數_Height[i].Value = 100;
                    if (this.List_PLC_Device_CCD02_02_PIN量測參數_Width[i].Value == 0) this.List_PLC_Device_CCD02_02_PIN量測參數_Width[i].Value = 100;
                    if (this.List_PLC_Device_CCD02_02_PIN量測參數_Height[i].Value > 500) this.List_PLC_Device_CCD02_02_PIN量測參數_Height[i].Value = 500;
                    if (this.List_PLC_Device_CCD02_02_PIN量測參數_Width[i].Value > 500) this.List_PLC_Device_CCD02_02_PIN量測參數_Width[i].Value = 500;
                }

                PLC_Device_CCD02_02_PIN量測_量測框調整.SetComment("PLC_CCD02_02_PIN量測_量測框調整");
                PLC_Device_CCD02_02_PIN量測_量測框調整.Bool = false;
                cnt_Program_CCD02_02_PIN量測_量測框調整 = 65535;
            }
            if (cnt_Program_CCD02_02_PIN量測_量測框調整 == 65535) cnt_Program_CCD02_02_PIN量測_量測框調整 = 1;
            if (cnt_Program_CCD02_02_PIN量測_量測框調整 == 1) cnt_Program_CCD02_02_PIN量測_量測框調整_檢查按下(ref cnt_Program_CCD02_02_PIN量測_量測框調整);
            if (cnt_Program_CCD02_02_PIN量測_量測框調整 == 2) cnt_Program_CCD02_02_PIN量測_量測框調整_初始化(ref cnt_Program_CCD02_02_PIN量測_量測框調整);
            if (cnt_Program_CCD02_02_PIN量測_量測框調整 == 3) cnt_Program_CCD02_02_PIN量測_量測框調整_座標轉換(ref cnt_Program_CCD02_02_PIN量測_量測框調整);
            if (cnt_Program_CCD02_02_PIN量測_量測框調整 == 4) cnt_Program_CCD02_02_PIN量測_量測框調整_讀取參數(ref cnt_Program_CCD02_02_PIN量測_量測框調整);
            if (cnt_Program_CCD02_02_PIN量測_量測框調整 == 5) cnt_Program_CCD02_02_PIN量測_量測框調整_開始區塊分析(ref cnt_Program_CCD02_02_PIN量測_量測框調整);
            if (cnt_Program_CCD02_02_PIN量測_量測框調整 == 6) cnt_Program_CCD02_02_PIN量測_量測框調整_繪製畫布(ref cnt_Program_CCD02_02_PIN量測_量測框調整);
            if (cnt_Program_CCD02_02_PIN量測_量測框調整 == 7) cnt_Program_CCD02_02_PIN量測_量測框調整 = 65500;
            if (cnt_Program_CCD02_02_PIN量測_量測框調整 > 1) cnt_Program_CCD02_02_PIN量測_量測框調整_檢查放開(ref cnt_Program_CCD02_02_PIN量測_量測框調整);

            if (cnt_Program_CCD02_02_PIN量測_量測框調整 == 65500)
            {
                PLC_Device_CCD02_02_PIN量測_量測框調整.Bool = false;
                cnt_Program_CCD02_02_PIN量測_量測框調整 = 65535;
            }
        }
        void cnt_Program_CCD02_02_PIN量測_量測框調整_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_02_PIN量測_量測框調整.Bool) cnt++;
        }
        void cnt_Program_CCD02_02_PIN量測_量測框調整_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_PIN量測_量測框調整.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_02_PIN量測_量測框調整_初始化(ref int cnt)
        {
            this.MyTimer_CCD02_02_PIN量測_量測框調整.TickStop();
            this.MyTimer_CCD02_02_PIN量測_量測框調整.StartTickTime(99999);
            this.List_CCD02_02_PIN量測參數_量測點 = new PointF[40];
            this.List_CCD02_02_PIN量測參數_量測點_結果 = new PointF[40];
            this.List_CCD02_02_PIN量測參數_量測點_轉換後座標 = new Point[40];
            this.List_CCD02_02_PIN量測參數_量測點_有無 = new bool[40];



            cnt++;
        }
        void cnt_Program_CCD02_02_PIN量測_量測框調整_座標轉換(ref int cnt)
        {
            if (PLC_Device_CCD02_02_計算一次.Bool)
            {
                CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.RefPointX = PLC_Device_CCD02_01_水平基準線量測_量測中心_X.Value;
                CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.RefPointY = PLC_Device_CCD02_01_水平基準線量測_量測中心_Y.Value;
                CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.RefAngle = 0;
                CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.CurrentRefPointX = Point_CCD02_01_中心基準座標_量測點.X;
                CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.CurrentRefPointY = Point_CCD02_01_中心基準座標_量測點.Y;
                CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.CurrentRefAngle = 0;
                CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.NumOfVisionPoints = 40;

                for (int j = 0; j < 40; j++)
                {
                    if (this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[j].Value == 0) this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[j].Value = 100;
                    if (this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[j].Value == 0) this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[j].Value = 100;
                    if (this.List_PLC_Device_CCD02_02_PIN量測參數_Width[j].Value == 0) this.List_PLC_Device_CCD02_02_PIN量測參數_Width[j].Value = 100;
                    if (this.List_PLC_Device_CCD02_02_PIN量測參數_Height[j].Value == 0) this.List_PLC_Device_CCD02_02_PIN量測參數_Height[j].Value = 100;

                    CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.VisionPointIndex = j;
                    CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.VisionPointX = this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[j].Value;
                    CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.VisionPointY = this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[j].Value;
                }
                CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.EstimateCurrentVisionPoints();
                for (int j = 0; j < 40; j++)
                {
                    CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.VisionPointIndex = j;
                    List_CCD02_02_PIN量測參數_量測點_轉換後座標[j].X = (int)CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.CurrentVisionPointX;
                    List_CCD02_02_PIN量測參數_量測點_轉換後座標[j].Y = (int)CCD02_02_PIN量測_AxVisionInspectionFrame_量測框調整.CurrentVisionPointY;
                }
            }
            cnt++;

        }
        void cnt_Program_CCD02_02_PIN量測_量測框調整_讀取參數(ref int cnt)
        {
            for (int i = 0; i < this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Count; i++)
            {
                if (this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[i].Value > 2596) this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[i].Value = 0;
                if (this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[i].Value > 1922) this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[i].Value = 0;
                if (this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[i].Value < 0) this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[i].Value = 0;
                if (this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[i].Value < 0) this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[i].Value = 0;

                if (this.List_CCD02_02_PIN量測參數_量測點_轉換後座標[i].X > 2596) this.List_CCD02_02_PIN量測參數_量測點_轉換後座標[i].X = 0;
                if (this.List_CCD02_02_PIN量測參數_量測點_轉換後座標[i].Y > 1922) this.List_CCD02_02_PIN量測參數_量測點_轉換後座標[i].Y = 0;
                if (this.List_CCD02_02_PIN量測參數_量測點_轉換後座標[i].X < 0) this.List_CCD02_02_PIN量測參數_量測點_轉換後座標[i].X = 0;
                if (this.List_CCD02_02_PIN量測參數_量測點_轉換後座標[i].Y < 0) this.List_CCD02_02_PIN量測參數_量測點_轉換後座標[i].Y = 0;
            }
            for (int i = 0; i < this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Count; i++)
            {
                this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].ParentHandle = this.CCD02_02_SrcImageHandle_拼接完成圖;
                if (PLC_Device_CCD02_02_計算一次.Bool)
                {
                    this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].OrgX = List_CCD02_02_PIN量測參數_量測點_轉換後座標[i].X;
                    this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].OrgY = List_CCD02_02_PIN量測參數_量測點_轉換後座標[i].Y;
                }
                else
                {
                    this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].OrgX = this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[i].Value;
                    this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].OrgY = this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[i].Value;
                }
                this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].ROIWidth = this.List_PLC_Device_CCD02_02_PIN量測參數_Width[i].Value;
                this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].ROIHeight = this.List_PLC_Device_CCD02_02_PIN量測參數_Height[i].Value;
                this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].SkewAngle = 0;
            }

            cnt++;
        }
        void cnt_Program_CCD02_02_PIN量測_量測框調整_開始區塊分析(ref int cnt)
        {
            uint object_value = 4294963615;

            for (int i = 0; i < this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Count; i++)
            {

                this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].SrcImageHandle = this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].VegaHandle;
                this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].ObjectClass = AxOvkBlob.TxAxObjClass.AX_OBJECT_DETECT_LIGHTER_CLASS;
                this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].HighThreshold = List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值[i].Value;
                if (this.CCD02_02_SrcImageHandle_拼接完成圖 != 0)
                {
                    if (this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[i].Value + this.List_PLC_Device_CCD02_02_PIN量測參數_Width[i].Value < 2596 &&
                        this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[i].Value + this.List_PLC_Device_CCD02_02_PIN量測參數_Height[i].Value < 1922 &&
                        this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[i].Value > 0 && this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[i].Value > 0)
                    {
                        this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].BlobAnalyze(false);
                    }


                }
                this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].CalculateFeatures((int)object_value, -1);
                this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].SortObjects(AxOvkBlob.TxAxObjFeatureSortOrder.AX_OBJECT_SORT_ORDER_LARGE_TO_SMALL, AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, 0, -1);
                this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_LESS_THAN, this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限[i].Value);
                this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_GREAT_THAN, this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限[i].Value);
                if (this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].DetectedNumObjs > 0)
                {
                    this.List_CCD02_02_PIN量測參數_量測點_有無[i] = true;
                    this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].BlobIndex = 0;
                    this.List_CCD02_02_PIN量測參數_量測點[i].X = (float)this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].BlobCentroidX;
                    this.List_CCD02_02_PIN量測參數_量測點[i].X += this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].OrgX;
                    this.List_CCD02_02_PIN量測參數_量測點[i].Y = (float)this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].BlobCentroidY;
                    //this.List_CCD02_02_PIN量測參數_量測點[i].Y = (float)this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].BlobCentroidY - (float)this.List_CCD02_02_PIN量測_AxObject_區塊分析[i].BlobLimBoxHeight / 2;
                    this.List_CCD02_02_PIN量測參數_量測點[i].Y += this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整[i].OrgY;
                }


            }

            cnt++;
        }
        void cnt_Program_CCD02_02_PIN量測_量測框調整_繪製畫布(ref int cnt)
        {
            this.PLC_Device_CCD02_02_PIN量測_量測框調整_RefreshCanvas.Bool = true;
            if (this.PLC_Device_CCD02_02_PIN量測_量測框調整按鈕.Bool && !PLC_Device_CCD02_02_計算一次.Bool)
            {
                this.h_Canvas_Tech_CCD02_02_拼接完成圖.RefreshCanvas();
            }

            cnt++;
        }





        #endregion
        #region PLC_CCD02_02_PIN量測_檢測距離計算
        private AxOvkMsr.AxPointLineDistanceMsr CCD02_02_PIN量測_AxPointLineDistanceMsr_線到點量測;
        MyTimer MyTimer_CCD02_02_PIN量測_檢測距離計算 = new MyTimer();
        PLC_Device PLC_Device_CCD02_02_PIN量測_檢測距離計算按鈕 = new PLC_Device("S6290");
        PLC_Device PLC_Device_CCD02_02_PIN量測_檢測距離計算 = new PLC_Device("S6285");
        PLC_Device PLC_Device_CCD02_02_PIN量測_檢測距離計算_OK = new PLC_Device("S6286");
        PLC_Device PLC_Device_CCD02_02_PIN量測_檢測距離計算_測試完成 = new PLC_Device("S6287");
        PLC_Device PLC_Device_CCD02_02_PIN量測_檢測距離計算_RefreshCanvas = new PLC_Device("S6288");

        PLC_Device PLC_Device_CCD02_02_PIN量測_水平度量測不測試 = new PLC_Device("S6110");
        PLC_Device PLC_Device_CCD02_02_PIN量測_間距量測不測試 = new PLC_Device("S6111");

        PLC_Device PLC_Device_CCD02_02_PIN量測_左右間距量測標準值 = new PLC_Device("F2300");
        PLC_Device PLC_Device_CCD02_02_PIN量測_左右間距量測上限值 = new PLC_Device("F2301");
        PLC_Device PLC_Device_CCD02_02_PIN量測_左右間距量測下限值 = new PLC_Device("F2302");
        PLC_Device PLC_Device_CCD02_02_PIN量測_上下間距量測標準值 = new PLC_Device("F2303");
        PLC_Device PLC_Device_CCD02_02_PIN量測_上下間距量測上限值 = new PLC_Device("F2304");
        PLC_Device PLC_Device_CCD02_02_PIN量測_上下間距量測下限值 = new PLC_Device("F2305");

        PLC_Device PLC_Device_CCD02_02_PIN量測_上排水平度量測標準值 = new PLC_Device("F2310");
        PLC_Device PLC_Device_CCD02_02_PIN量測_上排水平度量測上限值 = new PLC_Device("F2311");
        PLC_Device PLC_Device_CCD02_02_PIN量測_上排水平度量測下限值 = new PLC_Device("F2312");
        PLC_Device PLC_Device_CCD02_02_PIN量測_下排水平度量測標準值 = new PLC_Device("F2322");
        PLC_Device PLC_Device_CCD02_02_PIN量測_下排水平度量測上限值 = new PLC_Device("F2323");
        PLC_Device PLC_Device_CCD02_02_PIN量測_下排水平度量測下限值 = new PLC_Device("F2324");

        PLC_Device PLC_Device_CCD02_02_PIN量測_水平度量測差值 = new PLC_Device("F2313");
        PLC_Device PLC_Device_CCD02_02_PIN量測_水平度量測差值上限 = new PLC_Device("F2314");
        PLC_Device PLC_Device_CCD02_02_PIN量測_水平度量測差值下限 = new PLC_Device("F2315");
        PLC_Device PLC_Device_CCD02_02_PIN量測_左右間距PIN01到基準數值 = new PLC_Device("F2316");
        PLC_Device PLC_Device_CCD02_02_PIN量測_左右間距PIN01到基準上限 = new PLC_Device("F2317");
        PLC_Device PLC_Device_CCD02_02_PIN量測_左右間距PIN01到基準下限 = new PLC_Device("F2318");
        PLC_Device PLC_Device_CCD02_02_PIN量測_上下間距PIN01到基準數值 = new PLC_Device("F2319");
        PLC_Device PLC_Device_CCD02_02_PIN量測_上下間距PIN01到基準上限 = new PLC_Device("F2320");
        PLC_Device PLC_Device_CCD02_02_PIN量測_上下間距PIN01到基準下限 = new PLC_Device("F2321");

        private List<PLC_Device> List_PLC_Device_CCD02_02_PIN量測參數_間距不測試 = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD02_02_PIN量測參數_左右間距量測值 = new List<PLC_Device>();

        private double[] List_CCD02_02_PIN量測參數_左右間距量測距離 = new double[39];
        private double[] List_CCD02_02_PIN量測參數_上下間距量測距離 = new double[39];
        private double[] List_CCD02_02_PIN量測參數_水平度量測距離 = new double[40];
        private double CCD02_02_PIN量測參數_左右間距PIN01到基準距離 = new double();
        private double CCD02_02_PIN量測參數_上下間距PIN01到基準距離 = new double();

        private bool[] List_CCD02_02_PIN量測參數_量測點_OK = new bool[40];
        private bool[] List_CCD02_02_PIN量測參數_左右間距量測_OK = new bool[39];
        private bool[] List_CCD02_02_PIN量測參數_上下間距量測_OK = new bool[39];
        private bool[] List_CCD02_02_PIN量測參數_水平度量測_OK = new bool[40];
        private bool CCD02_02_PIN量測參數_左右間距PIN01到基準_OK = new bool();
        private bool CCD02_02_PIN量測參數_上下間距PIN01到基準_OK = new bool();

        private double[] List_CCD02_02_PIN量測參數_水平度量測顯示點_X = new double[40];
        private double[] List_CCD02_02_PIN量測參數_水平度量測顯示點_Y = new double[40];


        #region 間距不測試
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN01_02 = new PLC_Device("S35000");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN02_03 = new PLC_Device("S35001");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN03_04 = new PLC_Device("S35002");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN04_05 = new PLC_Device("S35003");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN05_06 = new PLC_Device("S35004");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN06_07 = new PLC_Device("S35005");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN07_08 = new PLC_Device("S35006");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN08_09 = new PLC_Device("S35007");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN09_10 = new PLC_Device("S35008");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN10_11 = new PLC_Device("S35009");

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN11_12 = new PLC_Device("S35010");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN12_13 = new PLC_Device("S35011");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN13_14 = new PLC_Device("S35012");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN14_15 = new PLC_Device("S35013");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN15_16 = new PLC_Device("S35014");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN16_17 = new PLC_Device("S35015");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN17_18 = new PLC_Device("S35016");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN18_19 = new PLC_Device("S35017");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN19_20 = new PLC_Device("S35018");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN20_21 = new PLC_Device("S35019");

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN21_22 = new PLC_Device("S35020");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN22_23 = new PLC_Device("S35021");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN23_24 = new PLC_Device("S35022");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN24_25 = new PLC_Device("S35023");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN25_26 = new PLC_Device("S35024");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN26_27 = new PLC_Device("S35025");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN27_28 = new PLC_Device("S35026");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN28_29 = new PLC_Device("S35027");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN29_30 = new PLC_Device("S35028");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN30_31 = new PLC_Device("S35029");

        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN31_32 = new PLC_Device("S35030");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN32_33 = new PLC_Device("S35031");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN33_34 = new PLC_Device("S35032");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN34_35 = new PLC_Device("S35033");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN35_36 = new PLC_Device("S35034");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN36_37 = new PLC_Device("S35035");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN37_38 = new PLC_Device("S35036");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN38_39 = new PLC_Device("S35037");
        private PLC_Device PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN39_40 = new PLC_Device("S35038");


        #endregion

        private void H_Canvas_Tech_CCD02_02_PIN間距量測_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            PointF p0;
            PointF p1;
            PointF point;
            PointF to_line_point;
            double 間距;
            double 水平度;
            if (PLC_Device_CCD02_02_Main_取像並檢驗.Bool || PLC_Device_CCD02_02_PLC觸發檢測.Bool)
            {
                try
                {
                    Graphics g = Graphics.FromHdc((IntPtr)HDC);
                    #region 左右間距顯示
                    for (int i = 0; i < 39; i++)
                    {
                        p0 = new PointF(this.List_CCD02_02_PIN量測參數_量測點[i].X, this.List_CCD02_02_PIN量測參數_量測點[i].Y);
                        p1 = new PointF(this.List_CCD02_02_PIN量測參數_量測點[i + 1].X, this.List_CCD02_02_PIN量測參數_量測點[i + 1].Y);
                        間距 = List_CCD02_02_PIN量測參數_左右間距量測距離[i];

                        if (i != 19)
                        {
                            if (List_CCD02_02_PIN量測參數_左右間距量測_OK[i])
                            {
                                DrawingClass.Draw.文字中心繪製(string.Format("{0}", (間距 / 1D).ToString("0.000")), new PointF((float)((p0.X + p1.X) / 2),
                                    (float)((p0.Y + p1.Y) / 2) + 150 * ZoomY), new Font("標楷體", 8), Color.Black, Color.Lime, g, ZoomX, ZoomY);
                                DrawingClass.Draw.線段繪製(p0, p1, Color.Lime, 1, g, ZoomX, ZoomY);

                            }
                            else
                            {
                                DrawingClass.Draw.文字中心繪製(string.Format("{0}", (間距 / 1D).ToString("0.000")), new PointF((float)((p0.X + p1.X) / 2),
                                    (float)((p0.Y + p1.Y) / 2) + 150 * ZoomY), new Font("標楷體", 8), Color.Black, Color.Red, g, ZoomX, ZoomY);
                                DrawingClass.Draw.線段繪製(p0, p1, Color.Red, 1, g, ZoomX, ZoomY);

                            }
                        }

                    }
                    #endregion
                    #region 水平度顯示
                    DrawingClass.Draw.水平線段繪製(0, 10000, CCD01_01_水平基準線量測_AxLineMsr.MeasuredSlope, CCD01_01_水平基準線量測_AxLineMsr.MeasuredPivotX,
                        CCD01_01_水平基準線量測_AxLineMsr.MeasuredPivotY + this.PLC_Device_CCD01_01_基準線量測_基準線偏移.Value, Color.Yellow, 2, g, ZoomX, ZoomY);

                    for (int i = 0; i < 40; i++)
                    {
                        point = new PointF(this.List_CCD02_02_PIN量測參數_量測點[i].X, this.List_CCD02_02_PIN量測參數_量測點[i].Y);

                        to_line_point = new PointF((float)this.List_CCD02_02_PIN量測參數_水平度量測顯示點_X[i], (float)(List_CCD02_02_PIN量測參數_水平度量測顯示點_Y[i]) + this.PLC_Device_CCD01_01_基準線量測_基準線偏移.Value);

                        水平度 = List_CCD02_02_PIN量測參數_水平度量測距離[i];


                        if (List_CCD02_02_PIN量測參數_水平度量測_OK[i])
                        {
                            DrawingClass.Draw.文字中心繪製(string.Format("{0}", (水平度 / 1D).ToString("0.000")),
                                new PointF(point.X, point.Y + 500 * ZoomY), new Font("標楷體", 8), Color.Black, Color.Yellow, g, ZoomX, ZoomY);

                            DrawingClass.Draw.線段繪製(point, to_line_point, Color.Yellow, 1, g, ZoomX, ZoomY);

                        }
                        else
                        {
                            DrawingClass.Draw.文字中心繪製(string.Format("{0}", (水平度 / 1D).ToString("0.000")),
                                new PointF(point.X, point.Y + 500 * ZoomY), new Font("標楷體", 8), Color.Black, Color.Red, g, ZoomX, ZoomY);

                            DrawingClass.Draw.線段繪製(point, to_line_point, Color.Red, 1, g, ZoomX, ZoomY);

                        }


                    }



                    #endregion

                    #region 結果顯示
                    for (int i = 0; i < 39; i++)
                    {
                        if (i != 19)
                        {
                            if (List_CCD02_02_PIN量測參數_左右間距量測_OK[i] || CCD02_02_PIN量測參數_左右間距PIN01到基準_OK)
                            {
                                DrawingClass.Draw.文字左上繪製("間距量測OK!", new PointF(0, 100), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                            }
                            else
                            {
                                DrawingClass.Draw.文字左上繪製("間距量測NG!", new PointF(0, 100), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                            }
                        }
                    }
                    for (int i = 0; i < 40; i++)
                    {
                        if (List_CCD02_02_PIN量測參數_水平度量測_OK[i])
                        {
                            DrawingClass.Draw.文字左上繪製("水平度量測OK!", new PointF(0, 200), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                        }
                        else
                        {
                            DrawingClass.Draw.文字左上繪製("水平度量測NG!", new PointF(0, 200), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                        }
                    }
                    #endregion
                    g.Dispose();
                    g = null;
                }
                catch
                {

                }

            }
            else if(PLC_Device_CCD02_02_Tech_檢驗一次.Bool)
            {
                if (this.PLC_Device_CCD02_02_PIN量測_檢測距離計算_RefreshCanvas.Bool)
                {
                    Graphics g = Graphics.FromHdc((IntPtr)HDC);
                    #region 左右間距顯示
                    for (int i = 0; i < 39; i++)
                    {
                        p0 = new PointF(this.List_CCD02_02_PIN量測參數_量測點[i].X, this.List_CCD02_02_PIN量測參數_量測點[i].Y);
                        p1 = new PointF(this.List_CCD02_02_PIN量測參數_量測點[i + 1].X, this.List_CCD02_02_PIN量測參數_量測點[i + 1].Y);
                        間距 = List_CCD02_02_PIN量測參數_左右間距量測距離[i];

                        if (i != 19)
                        {
                            if (List_CCD02_02_PIN量測參數_左右間距量測_OK[i])
                            {
                                DrawingClass.Draw.文字中心繪製(string.Format("{0}", (間距 / 1D).ToString("0.000")), new PointF((float)((p0.X + p1.X) / 2),
                                    (float)((p0.Y + p1.Y) / 2) + 150 * ZoomY), new Font("標楷體", 8), Color.Black, Color.Lime, g, ZoomX, ZoomY);
                                DrawingClass.Draw.線段繪製(p0, p1, Color.Lime, 1, g, ZoomX, ZoomY);

                            }
                            else
                            {
                                DrawingClass.Draw.文字中心繪製(string.Format("{0}", (間距 / 1D).ToString("0.000")), new PointF((float)((p0.X + p1.X) / 2),
                                    (float)((p0.Y + p1.Y) / 2) + 150 * ZoomY), new Font("標楷體", 8), Color.Black, Color.Red, g, ZoomX, ZoomY);
                                DrawingClass.Draw.線段繪製(p0, p1, Color.Red, 1, g, ZoomX, ZoomY);

                            }
                        }

                    }
                    #endregion
                    #region 水平度顯示
                    DrawingClass.Draw.水平線段繪製(0, 10000, CCD02_01_水平基準線量測_AxLineMsr.MeasuredSlope, CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotX,
                        CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotY + this.PLC_Device_CCD02_01_基準線量測_基準線偏移.Value, Color.Yellow, 2, g, ZoomX, ZoomY);

                    for (int i = 0; i < 40; i++)
                    {
                        point = new PointF(this.List_CCD02_02_PIN量測參數_量測點[i].X, this.List_CCD02_02_PIN量測參數_量測點[i].Y);

                        to_line_point = new PointF((float)this.List_CCD02_02_PIN量測參數_水平度量測顯示點_X[i], (float)(List_CCD02_02_PIN量測參數_水平度量測顯示點_Y[i]) + this.PLC_Device_CCD02_01_基準線量測_基準線偏移.Value);

                        水平度 = List_CCD02_02_PIN量測參數_水平度量測距離[i];


                        if (List_CCD02_02_PIN量測參數_水平度量測_OK[i])
                        {
                            DrawingClass.Draw.文字中心繪製(string.Format("{0}", (水平度 / 1D).ToString("0.000")),
                                new PointF(point.X, point.Y + 500 * ZoomY), new Font("標楷體", 8), Color.Black, Color.Yellow, g, ZoomX, ZoomY);

                            DrawingClass.Draw.線段繪製(point, to_line_point, Color.Yellow, 1, g, ZoomX, ZoomY);

                        }
                        else
                        {
                            DrawingClass.Draw.文字中心繪製(string.Format("{0}", (水平度 / 1D).ToString("0.000")),
                                new PointF(point.X, point.Y + 500 * ZoomY), new Font("標楷體", 8), Color.Black, Color.Red, g, ZoomX, ZoomY);

                            DrawingClass.Draw.線段繪製(point, to_line_point, Color.Red, 1, g, ZoomX, ZoomY);

                        }


                    }



                    #endregion

                    #region 結果顯示
                    //if (PLC_Device_CCD02_02_PIN量測_檢測距離計算_OK.Bool)
                    //{
                    //    DrawingClass.Draw.文字左上繪製("檢測OK!", new PointF(0, 0), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                    //}
                    //else
                    //{
                    //    DrawingClass.Draw.文字左上繪製("檢測NG!", new PointF(0, 0), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                    //}
                    for (int i = 0; i < 39; i++)
                    {
                        if (i != 19)
                        {
                            if (List_CCD02_02_PIN量測參數_左右間距量測_OK[i] || CCD02_02_PIN量測參數_左右間距PIN01到基準_OK)
                            {
                                DrawingClass.Draw.文字左上繪製("間距量測OK!", new PointF(0, 100), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                            }
                            else
                            {
                                DrawingClass.Draw.文字左上繪製("間距量測NG!", new PointF(0, 100), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                            }
                        }
                    }
                    for (int i = 0; i < 40; i++)
                    {
                        if (List_CCD02_02_PIN量測參數_水平度量測_OK[i])
                        {
                            DrawingClass.Draw.文字左上繪製("水平度量測OK!", new PointF(0, 200), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                        }
                        else
                        {
                            DrawingClass.Draw.文字左上繪製("水平度量測NG!", new PointF(0, 200), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                        }
                    }
                    #endregion
                    g.Dispose();
                    g = null;
                }
            }
            else
            {
                if (this.PLC_Device_CCD02_02_PIN量測_檢測距離計算_RefreshCanvas.Bool && PLC_Device_CCD02_02_PIN量測_檢測距離計算.Bool)
                {
                    try
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);
                        Font font = new Font("微軟正黑體", 10);


                        #region 左右間距顯示
                        for (int i = 0; i < 39; i++)
                        {
                            p0 = new PointF(this.List_CCD02_02_PIN量測參數_量測點[i].X, this.List_CCD02_02_PIN量測參數_量測點[i].Y);
                            p1 = new PointF(this.List_CCD02_02_PIN量測參數_量測點[i + 1].X, this.List_CCD02_02_PIN量測參數_量測點[i + 1].Y);
                            間距 = List_CCD02_02_PIN量測參數_左右間距量測距離[i];

                            if (i != 19)
                            {
                                if (List_CCD02_02_PIN量測參數_左右間距量測_OK[i])
                                {
                                    DrawingClass.Draw.文字中心繪製(string.Format("{0}", (間距 / 1D).ToString("0.000")), new PointF((float)((p0.X + p1.X) / 2),
                                        (float)((p0.Y + p1.Y) / 2) + 150 * ZoomY), new Font("標楷體", 8), Color.Black, Color.Lime, g, ZoomX, ZoomY);
                                    DrawingClass.Draw.線段繪製(p0, p1, Color.Lime, 1, g, ZoomX, ZoomY);

                                }
                                else
                                {
                                    DrawingClass.Draw.文字中心繪製(string.Format("{0}", (間距 / 1D).ToString("0.000")), new PointF((float)((p0.X + p1.X) / 2),
                                        (float)((p0.Y + p1.Y) / 2) + 150 * ZoomY), new Font("標楷體", 8), Color.Black, Color.Red, g, ZoomX, ZoomY);
                                    DrawingClass.Draw.線段繪製(p0, p1, Color.Red, 1, g, ZoomX, ZoomY);

                                }
                            }

                        }
                        #endregion
                        #region 水平度顯示
                        DrawingClass.Draw.水平線段繪製(0, 10000, CCD02_01_水平基準線量測_AxLineMsr.MeasuredSlope, CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotX,
                            CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotY + this.PLC_Device_CCD02_01_基準線量測_基準線偏移.Value, Color.Yellow, 2, g, ZoomX, ZoomY);

                        for (int i = 0; i < 40; i++)
                        {
                            point = new PointF(this.List_CCD02_02_PIN量測參數_量測點[i].X, this.List_CCD02_02_PIN量測參數_量測點[i].Y);

                            to_line_point = new PointF((float)this.List_CCD02_02_PIN量測參數_水平度量測顯示點_X[i], (float)(List_CCD02_02_PIN量測參數_水平度量測顯示點_Y[i]) + this.PLC_Device_CCD02_01_基準線量測_基準線偏移.Value);

                            水平度 = List_CCD02_02_PIN量測參數_水平度量測距離[i];


                            if (List_CCD02_02_PIN量測參數_水平度量測_OK[i])
                            {
                                DrawingClass.Draw.文字中心繪製(string.Format("{0}", (水平度 / 1D).ToString("0.000")),
                                    new PointF(point.X, point.Y + 500 * ZoomY), new Font("標楷體", 8), Color.Black, Color.Yellow, g, ZoomX, ZoomY);

                                DrawingClass.Draw.線段繪製(point, to_line_point, Color.Yellow, 1, g, ZoomX, ZoomY);

                            }
                            else
                            {
                                DrawingClass.Draw.文字中心繪製(string.Format("{0}", (水平度 / 1D).ToString("0.000")),
                                    new PointF(point.X, point.Y + 500 * ZoomY), new Font("標楷體", 8), Color.Black, Color.Red, g, ZoomX, ZoomY);

                                DrawingClass.Draw.線段繪製(point, to_line_point, Color.Red, 1, g, ZoomX, ZoomY);

                            }


                        }



                        #endregion

                        #region 結果顯示
                        //if (PLC_Device_CCD02_02_PIN量測_檢測距離計算_OK.Bool)
                        //{
                        //    DrawingClass.Draw.文字左上繪製("檢測OK!", new PointF(0, 0), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                        //}
                        //else
                        //{
                        //    DrawingClass.Draw.文字左上繪製("檢測NG!", new PointF(0, 0), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                        //}
                        for (int i = 0; i < 39; i++)
                        {
                            if (i != 19)
                            {
                                if (List_CCD02_02_PIN量測參數_左右間距量測_OK[i] || CCD02_02_PIN量測參數_左右間距PIN01到基準_OK)
                                {
                                    DrawingClass.Draw.文字左上繪製("間距量測OK!", new PointF(0, 100), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                                }
                                else
                                {
                                    DrawingClass.Draw.文字左上繪製("間距量測NG!", new PointF(0, 100), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                                }
                            }
                        }
                        for (int i = 0; i < 40; i++)
                        {
                            if (List_CCD02_02_PIN量測參數_水平度量測_OK[i])
                            {
                                DrawingClass.Draw.文字左上繪製("水平度量測OK!", new PointF(0, 200), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                            }
                            else
                            {
                                DrawingClass.Draw.文字左上繪製("水平度量測NG!", new PointF(0, 200), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                            }
                        }
                        #endregion
                        g.Dispose();
                        g = null;
                    }
                    catch
                    {

                    }


                }

            }


            this.PLC_Device_CCD02_02_PIN量測_檢測距離計算_RefreshCanvas.Bool = false;
        }

        int cnt_Program_CCD02_02_PIN量測_檢測距離計算 = 65534;
        void sub_Program_CCD02_02_PIN量測_檢測距離計算()
        {
            if (cnt_Program_CCD02_02_PIN量測_檢測距離計算 == 65534)
            {
                this.h_Canvas_Tech_CCD02_02_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_02_PIN間距量測_OnCanvasDrawEvent;
                this.h_Canvas_Main_CCD02_02_檢測畫面.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_02_PIN間距量測_OnCanvasDrawEvent;
                PLC_Device_CCD02_02_PIN量測_檢測距離計算.SetComment("PLC_CCD02_02_PIN量測_檢測距離計算");
                PLC_Device_CCD02_02_PIN量測_檢測距離計算.Bool = false;
                cnt_Program_CCD02_02_PIN量測_檢測距離計算 = 65535;
                #region 間距不量測
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN01_02);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN02_03);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN03_04);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN04_05);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN05_06);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN06_07);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN07_08);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN08_09);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN09_10);

                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN11_12);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN12_13);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN13_14);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN14_15);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN15_16);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN16_17);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN17_18);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN18_19);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN19_20);

                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN21_22);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN22_23);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN23_24);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN24_25);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN25_26);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN26_27);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN27_28);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN28_29);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN29_30);

                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN31_32);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN32_33);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN33_34);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN34_35);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN35_36);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN36_37);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN37_38);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN38_39);
                List_PLC_Device_CCD02_02_PIN量測參數_間距不測試.Add(PLC_Device_CCD02_02_PIN量測參數_間距不測試_PIN39_40);

                #endregion
            }
            if (cnt_Program_CCD02_02_PIN量測_檢測距離計算 == 65535) cnt_Program_CCD02_02_PIN量測_檢測距離計算 = 1;
            if (cnt_Program_CCD02_02_PIN量測_檢測距離計算 == 1) cnt_Program_CCD02_02_PIN量測_檢測距離計算_檢查按下(ref cnt_Program_CCD02_02_PIN量測_檢測距離計算);
            if (cnt_Program_CCD02_02_PIN量測_檢測距離計算 == 2) cnt_Program_CCD02_02_PIN量測_檢測距離計算_初始化(ref cnt_Program_CCD02_02_PIN量測_檢測距離計算);
            if (cnt_Program_CCD02_02_PIN量測_檢測距離計算 == 3) cnt_Program_CCD02_02_PIN量測_檢測距離計算_數值計算(ref cnt_Program_CCD02_02_PIN量測_檢測距離計算);
            if (cnt_Program_CCD02_02_PIN量測_檢測距離計算 == 4) cnt_Program_CCD02_02_PIN量測_檢測距離計算_量測結果(ref cnt_Program_CCD02_02_PIN量測_檢測距離計算);
            if (cnt_Program_CCD02_02_PIN量測_檢測距離計算 == 5) cnt_Program_CCD02_02_PIN量測_檢測距離計算_繪製畫布(ref cnt_Program_CCD02_02_PIN量測_檢測距離計算);
            if (cnt_Program_CCD02_02_PIN量測_檢測距離計算 == 6) cnt_Program_CCD02_02_PIN量測_檢測距離計算 = 65500;
            if (cnt_Program_CCD02_02_PIN量測_檢測距離計算 > 1) cnt_Program_CCD02_02_PIN量測_檢測距離計算_檢查放開(ref cnt_Program_CCD02_02_PIN量測_檢測距離計算);

            if (cnt_Program_CCD02_02_PIN量測_檢測距離計算 == 65500)
            {
                PLC_Device_CCD02_02_PIN量測_檢測距離計算.Bool = false;
                cnt_Program_CCD02_02_PIN量測_檢測距離計算 = 65535;
            }
        }
        void cnt_Program_CCD02_02_PIN量測_檢測距離計算_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_02_PIN量測_檢測距離計算.Bool) cnt++;
        }
        void cnt_Program_CCD02_02_PIN量測_檢測距離計算_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_PIN量測_檢測距離計算.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_02_PIN量測_檢測距離計算_初始化(ref int cnt)
        {
            this.MyTimer_CCD02_02_PIN量測_檢測距離計算.TickStop();
            this.MyTimer_CCD02_02_PIN量測_檢測距離計算.StartTickTime(99999);

            this.List_CCD02_02_PIN量測參數_左右間距量測距離 = new double[39];
            this.List_CCD02_02_PIN量測參數_上下間距量測距離 = new double[39];
            this.List_CCD02_02_PIN量測參數_水平度量測距離 = new double[40];
            this.CCD02_02_PIN量測參數_左右間距PIN01到基準距離 = new double();
            this.CCD02_02_PIN量測參數_上下間距PIN01到基準距離 = new double();

            this.List_CCD02_02_PIN量測參數_量測點_OK = new bool[40];
            this.List_CCD02_02_PIN量測參數_左右間距量測_OK = new bool[39];
            this.List_CCD02_02_PIN量測參數_上下間距量測_OK = new bool[39];
            this.List_CCD02_02_PIN量測參數_水平度量測_OK = new bool[40];
            this.CCD02_02_PIN量測參數_左右間距PIN01到基準_OK = new bool();
            this.CCD02_02_PIN量測參數_上下間距PIN01到基準_OK = new bool();




            cnt++;
        }
        void cnt_Program_CCD02_02_PIN量測_檢測距離計算_數值計算(ref int cnt)
        {
            #region 水平度數值計算
            this.CCD02_02_PIN量測_AxPointLineDistanceMsr_線到點量測.LinePivotX = this.CCD02_01_水平基準線量測_AxLineRegression.FittedPivotX;
            this.CCD02_02_PIN量測_AxPointLineDistanceMsr_線到點量測.LinePivotY = this.CCD02_01_水平基準線量測_AxLineRegression.FittedPivotY;
            this.CCD02_02_PIN量測_AxPointLineDistanceMsr_線到點量測.LineHorzVert = AxOvkMsr.TxAxLineHorzVert.AX_LINE_QUASI_HORIZONTAL;
            this.CCD02_02_PIN量測_AxPointLineDistanceMsr_線到點量測.LineSlope = this.CCD02_01_水平基準線量測_AxLineRegression.FittedSlope;
            for (int i = 0; i < this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Count; i++)
            {
                if (this.List_CCD02_02_PIN量測參數_量測點_有無[i])
                {
                    this.CCD02_02_PIN量測_AxPointLineDistanceMsr_線到點量測.PivotX = this.List_CCD02_02_PIN量測參數_量測點[i].X;
                    this.CCD02_02_PIN量測_AxPointLineDistanceMsr_線到點量測.PivotY = this.List_CCD02_02_PIN量測參數_量測點[i].Y;
                    this.CCD02_02_PIN量測_AxPointLineDistanceMsr_線到點量測.FindDistance();
                    this.List_CCD02_02_PIN量測參數_水平度量測顯示點_X[i] = CCD02_02_PIN量測_AxPointLineDistanceMsr_線到點量測.ProjectPivotX;
                    this.List_CCD02_02_PIN量測參數_水平度量測顯示點_Y[i] = CCD02_02_PIN量測_AxPointLineDistanceMsr_線到點量測.ProjectPivotY;

                    this.List_CCD02_02_PIN量測參數_水平度量測距離[i] = this.CCD02_02_PIN量測_AxPointLineDistanceMsr_線到點量測.Distance * this.CCD02_比例尺_pixcel_To_mm;
                }

            }
            #endregion
            #region 左右間距數值計算
            double distance = 0;
            double 間距Temp1_X = 0;
            double 間距Temp2_X = 0;

            for (int i = 0; i < 39; i++)
            {
                if (this.List_CCD02_02_PIN量測參數_量測點_有無[i] && this.List_CCD02_02_PIN量測參數_量測點_有無[i + 1])
                {

                    間距Temp1_X = this.List_CCD02_02_PIN量測參數_量測點[i].X - this.Point_CCD02_01_中心基準座標_量測點.X;
                    間距Temp2_X = this.List_CCD02_02_PIN量測參數_量測點[i + 1].X - this.Point_CCD02_01_中心基準座標_量測點.X;

                    distance = Math.Abs(間距Temp1_X - 間距Temp2_X);

                    this.List_CCD02_02_PIN量測參數_左右間距量測距離[i] = distance * this.CCD02_比例尺_pixcel_To_mm;
                }
                else
                {
                    PLC_Device_CCD02_02_PIN量測_檢測距離計算_OK.Bool = false;
                    List_CCD02_02_PIN量測參數_量測點_OK[i] = false;
                }

            }
            #endregion
            cnt++;
        }
        void cnt_Program_CCD02_02_PIN量測_檢測距離計算_量測結果(ref int cnt)
        {

            PLC_Device_CCD02_02_PIN量測_檢測距離計算_OK.Bool = true; // 檢測結果初始化


            #region 左右間距量測判斷

            for (int i = 0; i < 39; i++)
            {
                int 標準值 = this.PLC_Device_CCD02_02_PIN量測_左右間距量測標準值.Value;
                int 標準值上限 = this.PLC_Device_CCD02_02_PIN量測_左右間距量測上限值.Value;
                int 標準值下限 = this.PLC_Device_CCD02_02_PIN量測_左右間距量測下限值.Value;
                double 量測距離 = this.List_CCD02_02_PIN量測參數_左右間距量測距離[i];

                量測距離 = 量測距離 * 1000 - 標準值;
                量測距離 /= 1000;
                if (!PLC_Device_CCD02_02_PIN量測_間距量測不測試.Bool)
                {
                    if (this.List_CCD02_02_PIN量測參數_量測點_有無[i])
                    {
                        if (量測距離 >= 0 && i != 19)
                        {
                            if (標準值上限 <= Math.Abs(量測距離) * 1000 || 標準值下限 > Math.Abs(量測距離) * 1000)
                            {
                                this.List_CCD02_02_PIN量測參數_左右間距量測_OK[i] = false;
                                PLC_Device_CCD02_02_PIN量測_檢測距離計算_OK.Bool = false;
                            }
                            else
                            {
                                this.List_CCD02_02_PIN量測參數_左右間距量測_OK[i] = true;
                            }
                        }
                    }
                }
                else
                {
                    this.List_CCD02_02_PIN量測參數_左右間距量測_OK[i] = true;
                }



                this.List_CCD02_02_PIN量測參數_左右間距量測距離[i] = 量測距離;

            }
            #endregion
            #region 水平度量測判斷
            for (int i = 0; i < 40; i++)
            {
                int 上排標準值 = this.PLC_Device_CCD02_02_PIN量測_上排水平度量測標準值.Value;
                int 上排標準值上限 = this.PLC_Device_CCD02_02_PIN量測_上排水平度量測上限值.Value;
                int 上排標準值下限 = this.PLC_Device_CCD02_02_PIN量測_上排水平度量測下限值.Value;
                double 上排量測距離 = this.List_CCD02_02_PIN量測參數_水平度量測距離[i];

                int 下排標準值 = this.PLC_Device_CCD02_02_PIN量測_下排水平度量測標準值.Value;
                int 下排標準值上限 = this.PLC_Device_CCD02_02_PIN量測_下排水平度量測上限值.Value;
                int 下排標準值下限 = this.PLC_Device_CCD02_02_PIN量測_下排水平度量測下限值.Value;
                double 下排量測距離 = this.List_CCD02_02_PIN量測參數_水平度量測距離[i];

                上排量測距離 = 上排量測距離 * 1000 - 上排標準值;
                上排量測距離 /= 1000;

                下排量測距離 = 下排量測距離 * 1000 - 下排標準值;
                下排量測距離 /= 1000;
                if (!PLC_Device_CCD02_02_PIN量測_水平度量測不測試.Bool)
                {
                    if (this.List_CCD02_02_PIN量測參數_量測點_有無[i])
                    {
                        if (上排量測距離 >= 0 && i < 20)
                        {
                            if (上排標準值上限 <= Math.Abs(上排量測距離) * 1000 || 上排標準值下限 > Math.Abs(上排量測距離) * 1000)
                            {
                                this.List_CCD02_02_PIN量測參數_水平度量測_OK[i] = false;
                                PLC_Device_CCD02_02_PIN量測_檢測距離計算_OK.Bool = false;
                            }
                            else
                            {
                                this.List_CCD02_02_PIN量測參數_水平度量測_OK[i] = true;
                            }
                        }
                        else if (下排量測距離 >= 0 && i >= 20)
                        {
                            if (下排標準值上限 <= Math.Abs(下排量測距離) * 1000 || 下排標準值下限 > Math.Abs(下排量測距離) * 1000)
                            {
                                this.List_CCD02_02_PIN量測參數_水平度量測_OK[i] = false;
                                PLC_Device_CCD02_02_PIN量測_檢測距離計算_OK.Bool = false;
                            }
                            else
                            {
                                this.List_CCD02_02_PIN量測參數_水平度量測_OK[i] = true;
                            }
                        }

                    }
                }
                else
                {
                    this.List_CCD02_02_PIN量測參數_水平度量測_OK[i] = true;
                }
                if (PLC_Device_CCD02_02_PIN量測_間距量測不測試.Bool && PLC_Device_CCD02_02_PIN量測_水平度量測不測試.Bool)
                {
                    PLC_Device_CCD02_02_PIN量測_檢測距離計算_OK.Bool = true;
                }

                //this.List_CCD02_02_PIN量測參數_水平度量測距離[i] = 量測距離;

            }
            #endregion
            #region 左右間距PIN01到基準線量測

            double temp_PIN01到基準 = 0;
            int 左右間距PIN01到基準標準值 = this.PLC_Device_CCD02_02_PIN量測_左右間距PIN01到基準數值.Value;
            int 左右間距PIN01到基準標準值上限 = this.PLC_Device_CCD02_02_PIN量測_左右間距PIN01到基準上限.Value;
            int 左右間距PIN01到基準標準值下限 = this.PLC_Device_CCD02_02_PIN量測_左右間距PIN01到基準下限.Value;
            double 左右間距PIN01到基準量測距離 = this.CCD02_02_PIN量測參數_左右間距PIN01到基準距離;

            if (this.List_CCD02_02_PIN量測參數_量測點_有無[0])
            {
                temp_PIN01到基準 = Math.Abs(this.List_CCD02_02_PIN量測參數_量測點[0].X - this.Point_CCD02_01_中心基準座標_量測點.X);
                this.CCD02_02_PIN量測參數_左右間距PIN01到基準距離 = temp_PIN01到基準 * this.CCD02_比例尺_pixcel_To_mm;
            }
            else
            {
                PLC_Device_CCD02_02_PIN量測_檢測距離計算_OK.Bool = false;
                CCD02_02_PIN量測參數_左右間距PIN01到基準_OK = false;
            }



            左右間距PIN01到基準量測距離 = 左右間距PIN01到基準量測距離 * 1000 - 左右間距PIN01到基準標準值;
            左右間距PIN01到基準量測距離 /= 1000;

            if (!PLC_Device_CCD02_02_PIN量測_間距量測不測試.Bool)
            {
                if (this.List_CCD02_02_PIN量測參數_量測點_有無[0])
                {
                    if (左右間距PIN01到基準標準值上限 <= Math.Abs(左右間距PIN01到基準量測距離) * 1000 || 左右間距PIN01到基準標準值下限 >
                        Math.Abs(左右間距PIN01到基準量測距離) * 1000)
                    {
                        this.CCD02_02_PIN量測參數_左右間距PIN01到基準_OK = false;
                        PLC_Device_CCD02_02_PIN量測_檢測距離計算_OK.Bool = false;
                        this.List_CCD02_02_PIN量測參數_左右間距量測_OK[0] = false;
                    }
                    else
                    {
                        this.CCD02_02_PIN量測參數_左右間距PIN01到基準_OK = true;
                    }

                }
            }
            else
            {
                this.PLC_Device_CCD02_02_PIN量測_檢測距離計算_OK.Bool = true;
            }

            #endregion
            cnt++;
        }
        void cnt_Program_CCD02_02_PIN量測_檢測距離計算_繪製畫布(ref int cnt)
        {
            this.PLC_Device_CCD02_02_PIN量測_檢測距離計算_RefreshCanvas.Bool = true;
            if (this.PLC_Device_CCD02_02_PIN量測_檢測距離計算按鈕.Bool && !PLC_Device_CCD02_02_計算一次.Bool)
            {

                this.h_Canvas_Tech_CCD02_02_拼接完成圖.RefreshCanvas();
            }

            cnt++;
        }
        #endregion

        #region PLC_CCD02_02_PIN正位度量測_設定規範位置
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_設定規範按鈕 = new PLC_Device("S6310");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_設定規範位置 = new PLC_Device("S6305");
        PLC_Device PLC_Device_CCD02_02_PIN設定規範位置_OK = new PLC_Device("S6306");
        PLC_Device PLC_Device_CCD02_02_PIN設定規範位置_測試完成 = new PLC_Device("S6307");
        PLC_Device PLC_Device_CCD02_02_PIN設定規範位置_RefreshCanvas = new PLC_Device("S6308");
        private List<PLC_Device> List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y = new List<PLC_Device>();
        private AxOvkPat.AxVisionInspectionFrame CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整;

        #region 正位度規範值
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN01 = new PLC_Device("F11000");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN02 = new PLC_Device("F11001");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN03 = new PLC_Device("F11002");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN04 = new PLC_Device("F11003");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN05 = new PLC_Device("F11004");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN06 = new PLC_Device("F11005");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN07 = new PLC_Device("F11006");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN08 = new PLC_Device("F11007");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN09 = new PLC_Device("F11008");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN10 = new PLC_Device("F11009");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN11 = new PLC_Device("F11010");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN12 = new PLC_Device("F11011");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN13 = new PLC_Device("F11012");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN14 = new PLC_Device("F11013");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN15 = new PLC_Device("F11014");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN16 = new PLC_Device("F11015");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN17 = new PLC_Device("F11016");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN18 = new PLC_Device("F11017");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN19 = new PLC_Device("F11018");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN20 = new PLC_Device("F11019");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN21 = new PLC_Device("F11020");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN22 = new PLC_Device("F11021");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN23 = new PLC_Device("F11022");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN24 = new PLC_Device("F11023");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN25 = new PLC_Device("F11024");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN26 = new PLC_Device("F11025");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN27 = new PLC_Device("F11026");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN28 = new PLC_Device("F11027");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN29 = new PLC_Device("F11028");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN30 = new PLC_Device("F11029");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN31 = new PLC_Device("F11030");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN32 = new PLC_Device("F11031");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN33 = new PLC_Device("F11032");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN34 = new PLC_Device("F11033");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN35 = new PLC_Device("F11034");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN36 = new PLC_Device("F11035");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN37 = new PLC_Device("F11036");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN38 = new PLC_Device("F11037");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN39 = new PLC_Device("F11038");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN40 = new PLC_Device("F11039");

        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN01 = new PLC_Device("F11100");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN02 = new PLC_Device("F11101");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN03 = new PLC_Device("F11102");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN04 = new PLC_Device("F11103");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN05 = new PLC_Device("F11104");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN06 = new PLC_Device("F11105");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN07 = new PLC_Device("F11106");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN08 = new PLC_Device("F11107");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN09 = new PLC_Device("F11108");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN10 = new PLC_Device("F11109");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN11 = new PLC_Device("F11110");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN12 = new PLC_Device("F11111");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN13 = new PLC_Device("F11112");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN14 = new PLC_Device("F11113");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN15 = new PLC_Device("F11114");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN16 = new PLC_Device("F11115");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN17 = new PLC_Device("F11116");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN18 = new PLC_Device("F11117");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN19 = new PLC_Device("F11118");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN20 = new PLC_Device("F11119");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN21 = new PLC_Device("F11120");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN22 = new PLC_Device("F11121");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN23 = new PLC_Device("F11122");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN24 = new PLC_Device("F11123");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN25 = new PLC_Device("F11124");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN26 = new PLC_Device("F11125");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN27 = new PLC_Device("F11126");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN28 = new PLC_Device("F11127");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN29 = new PLC_Device("F11128");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN30 = new PLC_Device("F11129");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN31 = new PLC_Device("F11130");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN32 = new PLC_Device("F11131");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN33 = new PLC_Device("F11132");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN34 = new PLC_Device("F11133");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN35 = new PLC_Device("F11134");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN36 = new PLC_Device("F11135");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN37 = new PLC_Device("F11136");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN38 = new PLC_Device("F11137");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN39 = new PLC_Device("F11138");
        PLC_Device PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN40 = new PLC_Device("F11139");
        #endregion
        private PointF[] List_CCD02_02_PIN正位度量測參數_規範點 = new PointF[40];
        private PointF[] List_CCD02_02_PIN正位度量測參數_轉換後座標 = new PointF[40];
        private double[] List_CCD02_02_PIN正位度量測參數_正位度規範點_X = new double[40];
        private double[] List_CCD02_02_PIN正位度量測參數_正位度規範點_Y = new double[40];

        int cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 = 65534;

        private void H_Canvas_Tech_CCD02_02_PIN正位度設定規範位置_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {

            if (PLC_Device_CCD02_02_Main_取像並檢驗.Bool || PLC_Device_CCD02_02_PLC觸發檢測.Bool)
            {
                try
                {
                    Graphics g = Graphics.FromHdc((IntPtr)HDC);
                    for (int i = 0; i < 40; i++)
                    {
                        DrawingClass.Draw.十字中心(new PointF((float)List_CCD02_02_PIN正位度量測參數_正位度規範點_X[i], (float)List_CCD02_02_PIN正位度量測參數_正位度規範點_Y[i]), 50, Color.Red, 1, g, ZoomX, ZoomY);
                    }
                    g.Dispose();
                    g = null;
                }
                catch
                {

                }

            }
            else if (PLC_Device_CCD02_02_Tech_檢驗一次.Bool)
            {
                if (this.PLC_Device_CCD02_02_PIN設定規範位置_RefreshCanvas.Bool)
                {
                    try
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);
                        for (int i = 0; i < 40; i++)
                        {
                            DrawingClass.Draw.十字中心(new PointF((float)List_CCD02_02_PIN正位度量測參數_正位度規範點_X[i], (float)List_CCD02_02_PIN正位度量測參數_正位度規範點_Y[i]), 50, Color.Red, 1, g, ZoomX, ZoomY);
                        }

                        g.Dispose();
                        g = null;
                    }
                    catch
                    {

                    }
                }
            }

            else
            {
                if (this.PLC_Device_CCD02_02_PIN設定規範位置_RefreshCanvas.Bool)
                {
                    try
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);
                        for (int i = 0; i < 40; i++)
                        {
                            DrawingClass.Draw.十字中心(new PointF((float)List_CCD02_02_PIN正位度量測參數_正位度規範點_X[i], (float)List_CCD02_02_PIN正位度量測參數_正位度規範點_Y[i]), 50, Color.Red, 1, g, ZoomX, ZoomY);
                        }

                        g.Dispose();
                        g = null;
                    }
                    catch
                    {

                    }
                }
            }



            this.PLC_Device_CCD02_02_PIN設定規範位置_RefreshCanvas.Bool = false;
        }
        void sub_Program_CCD02_02_PIN正位度量測_設定規範位置()
        {
            if (cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 == 65534)
            {

                this.h_Canvas_Tech_CCD02_02_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_02_PIN正位度設定規範位置_OnCanvasDrawEvent;
                this.h_Canvas_Main_CCD02_02_檢測畫面.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_02_PIN正位度設定規範位置_OnCanvasDrawEvent;

                PLC_Device_CCD02_02_PIN正位度量測_設定規範位置.SetComment("PLC_CCD02_02_PIN正位度量測_設定規範位置");
                PLC_Device_CCD02_02_PIN正位度量測_設定規範位置.Bool = false;
                cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 = 65535;
                #region 正位度規範值
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN01);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN02);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN03);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN04);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN05);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN06);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN07);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN08);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN09);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN10);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN11);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN12);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN13);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN14);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN15);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN16);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN17);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN18);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN19);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN20);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN21);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN22);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN23);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN24);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN25);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN26);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN27);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN28);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN29);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN30);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN31);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN32);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN33);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN34);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN35);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN36);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN37);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN38);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN39);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_X_PIN40);

                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN01);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN02);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN03);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN04);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN05);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN06);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN07);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN08);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN09);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN10);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN11);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN12);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN13);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN14);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN15);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN16);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN17);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN18);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN19);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN20);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN21);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN22);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN23);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN24);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN25);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN26);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN27);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN28);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN29);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN30);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN31);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN32);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN33);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN34);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN35);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN36);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN37);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN38);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN39);
                this.List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y.Add(this.PLC_Device_CCD02_02_PIN正位度量測_正位度規範值_Y_PIN40);
                #endregion
            }
            if (cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 == 65535) cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 = 1;
            if (cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 == 1) cnt_Program_CCD02_02_PIN正位度量測_設定規範位置_檢查按下(ref cnt_Program_CCD02_02_PIN正位度量測_設定規範位置);
            if (cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 == 2) cnt_Program_CCD02_02_PIN正位度量測_設定規範位置_初始化(ref cnt_Program_CCD02_02_PIN正位度量測_設定規範位置);
            if (cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 == 3) cnt_Program_CCD02_02_PIN正位度量測_設定規範位置_座標轉換(ref cnt_Program_CCD02_02_PIN正位度量測_設定規範位置);
            if (cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 == 4) cnt_Program_CCD02_02_PIN正位度量測_設定規範位置_讀取參數(ref cnt_Program_CCD02_02_PIN正位度量測_設定規範位置);
            if (cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 == 5) cnt_Program_CCD02_02_PIN正位度量測_設定規範位置_繪製畫布(ref cnt_Program_CCD02_02_PIN正位度量測_設定規範位置);
            if (cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 == 6) cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 = 65500;
            if (cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 > 1) cnt_Program_CCD02_02_PIN正位度量測_設定規範位置_檢查放開(ref cnt_Program_CCD02_02_PIN正位度量測_設定規範位置);

            if (cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 == 65500)
            {
                PLC_Device_CCD02_02_PIN正位度量測_設定規範位置.Bool = false;
                cnt_Program_CCD02_02_PIN正位度量測_設定規範位置 = 65535;
            }
        }
        void cnt_Program_CCD02_02_PIN正位度量測_設定規範位置_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_02_PIN正位度量測_設定規範位置.Bool) cnt++;
        }
        void cnt_Program_CCD02_02_PIN正位度量測_設定規範位置_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_PIN正位度量測_設定規範位置.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_02_PIN正位度量測_設定規範位置_初始化(ref int cnt)
        {
            this.List_CCD02_02_PIN正位度量測參數_正位度規範點_X = new double[40];
            this.List_CCD02_02_PIN正位度量測參數_正位度規範點_Y = new double[40];
            this.List_CCD02_02_PIN正位度量測參數_規範點 = new PointF[40];
            this.List_CCD02_02_PIN正位度量測參數_轉換後座標 = new PointF[40];

            if (!PLC_Device_CCD02_02_計算一次.Bool)
            {
                for (int i = 0; i < this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Count; i++)
                {
                    List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X[i].Value = (int)this.List_CCD02_02_PIN量測參數_量測點[i].X;
                    List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y[i].Value = (int)this.List_CCD02_02_PIN量測參數_量測點[i].Y;
                }
            }

            cnt++;
        }
        void cnt_Program_CCD02_02_PIN正位度量測_設定規範位置_座標轉換(ref int cnt)
        {
            if (PLC_Device_CCD02_02_計算一次.Bool)
            {
                CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.RefPointX = PLC_Device_CCD02_01_水平基準線量測_量測中心_X.Value;
                CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.RefPointY = PLC_Device_CCD02_01_水平基準線量測_量測中心_Y.Value;
                CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.RefAngle = 0;
                CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.CurrentRefPointX = Point_CCD02_01_中心基準座標_量測點.X;
                CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.CurrentRefPointY = Point_CCD02_01_中心基準座標_量測點.Y;
                CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.CurrentRefAngle = 0;
                CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.NumOfVisionPoints = this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Count;

                for (int j = 0; j < this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Count; j++)
                {
                    CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.VisionPointIndex = j;
                    CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.VisionPointX = (float)(List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X[j].Value);
                    CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.VisionPointX = CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.VisionPointX / 1;
                    CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.VisionPointY = (float)(List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y[j].Value);
                    CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.VisionPointY = CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.VisionPointY / 1;
                }
                CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.EstimateCurrentVisionPoints();
                for (int j = 0; j < this.List_CCD02_02_PIN量測_AxROIBW8_量測框調整.Count; j++)
                {
                    CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.VisionPointIndex = j;
                    List_CCD02_02_PIN正位度量測參數_轉換後座標[j].X = (int)CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.CurrentVisionPointX;
                    List_CCD02_02_PIN正位度量測參數_轉換後座標[j].Y = (int)CCD02_02_PIN正位度量測參數_AxVisionInspectionFrame_量測框調整.CurrentVisionPointY;
                }
            }
            cnt++;
        }
        void cnt_Program_CCD02_02_PIN正位度量測_設定規範位置_讀取參數(ref int cnt)
        {
            for (int i = 0; i < 40; i++)
            {
                if (PLC_Device_CCD02_02_計算一次.Bool)
                {
                    this.List_CCD02_02_PIN正位度量測參數_正位度規範點_X[i] = List_CCD02_02_PIN正位度量測參數_轉換後座標[i].X;
                    this.List_CCD02_02_PIN正位度量測參數_正位度規範點_Y[i] = List_CCD02_02_PIN正位度量測參數_轉換後座標[i].Y;
                }
                else
                {
                    this.List_CCD02_02_PIN正位度量測參數_正位度規範點_X[i] = (float)(List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_X[i].Value);
                    this.List_CCD02_02_PIN正位度量測參數_正位度規範點_X[i] = this.List_CCD02_02_PIN正位度量測參數_正位度規範點_X[i] / 1;
                    this.List_CCD02_02_PIN正位度量測參數_正位度規範點_Y[i] = (float)(List_PLC_Device_CCD02_02_PIN正位度量測參數_正位度規範值_Y[i].Value);
                    this.List_CCD02_02_PIN正位度量測參數_正位度規範點_Y[i] = this.List_CCD02_02_PIN正位度量測參數_正位度規範點_Y[i] / 1;
                }
                List_CCD02_02_PIN正位度量測參數_規範點[i].X = (float)this.List_CCD02_02_PIN正位度量測參數_正位度規範點_X[i];
                List_CCD02_02_PIN正位度量測參數_規範點[i].Y = (float)this.List_CCD02_02_PIN正位度量測參數_正位度規範點_Y[i];
            }

            cnt++;
        }
        void cnt_Program_CCD02_02_PIN正位度量測_設定規範位置_繪製畫布(ref int cnt)
        {
            this.PLC_Device_CCD02_02_PIN設定規範位置_RefreshCanvas.Bool = true;
            if (this.PLC_Device_CCD02_02_PIN正位度量測_設定規範按鈕.Bool && !PLC_Device_CCD02_02_計算一次.Bool)
            {
                this.h_Canvas_Tech_CCD02_02_拼接完成圖.RefreshCanvas();
            }

            cnt++;
        }



        #endregion
        #region PLC_CCD02_02_PIN量測_檢測正位度計算

        MyTimer MyTimer_CCD02_02_PIN量測_檢測正位度計算 = new MyTimer();
        PLC_Device PLC_Device_CCD02_02_PIN量測_檢測正位度計算按鈕 = new PLC_Device("S6330");
        PLC_Device PLC_Device_CCD02_02_PIN量測_檢測正位度計算 = new PLC_Device("S6325");
        PLC_Device PLC_Device_CCD02_02_PIN量測_檢測正位度計算_OK = new PLC_Device("S6326");
        PLC_Device PLC_Device_CCD02_02_PIN量測_檢測正位度計算_測試完成 = new PLC_Device("S6327");
        PLC_Device PLC_Device_CCD02_02_PIN量測_檢測正位度計算_RefreshCanvas = new PLC_Device("S6328");
        PLC_Device PLC_Device_CCD02_02_PIN量測_檢測正位度計算_不測試 = new PLC_Device("S6112");
        PLC_Device PLC_Device_CCD02_02_PIN量測_檢測正位度計算_差值 = new PLC_Device("F11201");

        private double[] List_CCD02_02_PIN正位度量測參數_正位度距離 = new double[40];
        private bool[] List_CCD02_02_PIN正位度量測參數_正位度量測點_OK = new bool[40];


        private void H_Canvas_Tech_CCD02_02_PIN量測正位度_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            if (PLC_Device_CCD02_02_Main_取像並檢驗.Bool || PLC_Device_CCD02_02_PLC觸發檢測.Bool)
            {
                try
                {
                    Graphics g = Graphics.FromHdc((IntPtr)HDC);
                    Font font = new Font("微軟正黑體", 10);
                    string 正位度差值顯示;

                    for (int i = 0; i < 40; i++)
                    {
                        DrawingClass.Draw.十字中心(new PointF((float)List_CCD02_02_PIN正位度量測參數_正位度規範點_X[i], (float)List_CCD02_02_PIN正位度量測參數_正位度規範點_Y[i]), 50, Color.Red, 1, g, ZoomX, ZoomY);
                        DrawingClass.Draw.十字中心(this.List_CCD02_02_PIN量測參數_量測點[i], 50, Color.Lime, 1, g, ZoomX, ZoomY);
                    }
                    #region 正位度量測結果顯示
                    if (PLC_Device_CCD02_02_PIN量測_檢測正位度計算_OK.Bool)
                    {
                        DrawingClass.Draw.文字左上繪製("正位度數值OK:", new PointF(1750, 0), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);
                    }
                    else
                    {
                        DrawingClass.Draw.文字左上繪製("正位度數值NG:", new PointF(1750, 0), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                    }
                    #endregion
                    #region PIN正位結果顯示
                    for (int i = 0; i < 40; i++)
                    {
                        正位度差值顯示 = ("P" + (i + 1).ToString("00:") + this.List_CCD02_02_PIN正位度量測參數_正位度距離[i].ToString("0.000"));

                        if (this.List_CCD02_02_PIN正位度量測參數_正位度量測點_OK[i])
                        {

                            if (i <= 19)
                            {
                                DrawingClass.Draw.文字左上繪製(正位度差值顯示, new PointF(2200, i * 40), new Font("標楷體", 10), Color.Black, Color.Lime, g, ZoomX, ZoomY);
                            }

                            if (i > 19)
                            {
                                DrawingClass.Draw.文字左上繪製(正位度差值顯示, new PointF(2400, (i - 20) * 40), new Font("標楷體", 10), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                            }
                        }
                        else
                        {

                            if (i <= 19)
                            {
                                DrawingClass.Draw.文字左上繪製(正位度差值顯示, new PointF(2200, i * 40), new Font("標楷體", 10), Color.Black, Color.Red, g, ZoomX, ZoomY);
                            }

                            if (i > 19)
                            {
                                DrawingClass.Draw.文字左上繪製(正位度差值顯示, new PointF(2400, (i - 20) * 40), new Font("標楷體", 10), Color.Black, Color.Red, g, ZoomX, ZoomY);

                            }

                        }


                    }


                    #endregion
                    g.Dispose();
                    g = null;
                }
                catch
                {

                }

            }
            else if (PLC_Device_CCD02_02_Tech_檢驗一次.Bool)
            {
                if (this.PLC_Device_CCD02_02_PIN量測_檢測正位度計算_RefreshCanvas.Bool)
                {
                    try
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);
                        Font font = new Font("微軟正黑體", 10);
                        string 正位度差值顯示;

                        //DrawingClass.Draw.文字左上繪製(this.MyTimer_CCD02_02_計算一次.GetTickTime().ToString("0.000ms"), new PointF(2100, 1800), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);
                        for (int i = 0; i < 40; i++)
                        {
                            DrawingClass.Draw.十字中心(new PointF((float)List_CCD02_02_PIN正位度量測參數_正位度規範點_X[i], (float)List_CCD02_02_PIN正位度量測參數_正位度規範點_Y[i]), 50, Color.Red, 1, g, ZoomX, ZoomY);
                            DrawingClass.Draw.十字中心(this.List_CCD02_02_PIN量測參數_量測點[i], 50, Color.Lime, 1, g, ZoomX, ZoomY);
                        }

                        #region 正位度量測結果顯示
                        if (PLC_Device_CCD02_02_PIN量測_檢測正位度計算_OK.Bool)
                        {
                            DrawingClass.Draw.文字左上繪製("正位度數值OK:", new PointF(1750, 0), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);
                        }
                        else
                        {
                            DrawingClass.Draw.文字左上繪製("正位度數值NG:", new PointF(1750, 0), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                        }
                        #endregion
                        #region PIN正位結果顯示
                        for (int i = 0; i < 40; i++)
                        {
                            正位度差值顯示 = ("P" + (i + 1).ToString("00:") + this.List_CCD02_02_PIN正位度量測參數_正位度距離[i].ToString("0.000"));

                            if (this.List_CCD02_02_PIN正位度量測參數_正位度量測點_OK[i])
                            {

                                if (i <= 19)
                                {
                                    DrawingClass.Draw.文字左上繪製(正位度差值顯示, new PointF(2200, i * 40), new Font("標楷體", 10), Color.Black, Color.Lime, g, ZoomX, ZoomY);
                                }

                                if (i > 19)
                                {
                                    DrawingClass.Draw.文字左上繪製(正位度差值顯示, new PointF(2400, (i - 20) * 40), new Font("標楷體", 10), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                                }
                            }
                            else
                            {

                                if (i <= 19)
                                {
                                    DrawingClass.Draw.文字左上繪製(正位度差值顯示, new PointF(2200, i * 40), new Font("標楷體", 10), Color.Black, Color.Red, g, ZoomX, ZoomY);
                                }

                                if (i > 19)
                                {
                                    DrawingClass.Draw.文字左上繪製(正位度差值顯示, new PointF(2400, (i - 20) * 40), new Font("標楷體", 10), Color.Black, Color.Red, g, ZoomX, ZoomY);

                                }

                            }


                        }


                        #endregion
                        g.Dispose();
                        g = null;
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                if (this.PLC_Device_CCD02_02_PIN量測_檢測正位度計算_RefreshCanvas.Bool && PLC_Device_CCD02_02_PIN量測_檢測正位度計算.Bool)
                {
                    try
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);
                        Font font = new Font("微軟正黑體", 10);
                        string 正位度差值顯示;

                        for (int i = 0; i < 40; i++)
                        {
                            DrawingClass.Draw.十字中心(new PointF((float)List_CCD02_02_PIN正位度量測參數_正位度規範點_X[i], (float)List_CCD02_02_PIN正位度量測參數_正位度規範點_Y[i]), 50, Color.Red, 1, g, ZoomX, ZoomY);
                            DrawingClass.Draw.十字中心(this.List_CCD02_02_PIN量測參數_量測點[i], 50, Color.Lime, 1, g, ZoomX, ZoomY);
                        }
                        #region 正位度量測結果顯示
                        if (PLC_Device_CCD02_02_PIN量測_檢測正位度計算_OK.Bool)
                        {
                            DrawingClass.Draw.文字左上繪製("正位度數值OK:", new PointF(1750, 0), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);
                        }
                        else
                        {
                            DrawingClass.Draw.文字左上繪製("正位度數值NG:", new PointF(1750, 0), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                        }
                        #endregion
                        #region PIN正位結果顯示
                        for (int i = 0; i < 40; i++)
                        {
                            正位度差值顯示 = ("P" + (i + 1).ToString("00:") + this.List_CCD02_02_PIN正位度量測參數_正位度距離[i].ToString("0.000"));

                            if (this.List_CCD02_02_PIN正位度量測參數_正位度量測點_OK[i])
                            {
                                if (i <= 19)
                                {
                                    DrawingClass.Draw.文字左上繪製(正位度差值顯示, new PointF(2200, i * 40), new Font("標楷體", 10), Color.Black, Color.Lime, g, ZoomX, ZoomY);
                                }

                                if (i > 19)
                                {
                                    DrawingClass.Draw.文字左上繪製(正位度差值顯示, new PointF(2400, (i - 20) * 40), new Font("標楷體", 10), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                                }
                            }
                            else
                            {
                                if (i <= 19)
                                {
                                    DrawingClass.Draw.文字左上繪製(正位度差值顯示, new PointF(2200, i * 40), new Font("標楷體", 10), Color.Black, Color.Red, g, ZoomX, ZoomY);
                                }

                                if (i > 19)
                                {
                                    DrawingClass.Draw.文字左上繪製(正位度差值顯示, new PointF(2400, (i - 20) * 40), new Font("標楷體", 10), Color.Black, Color.Red, g, ZoomX, ZoomY);

                                }

                            }

                        }

                        #endregion

                        g.Dispose();
                        g = null;
                    }
                    catch
                    {

                    }


                }

            }

            this.PLC_Device_CCD02_02_PIN量測_檢測正位度計算_RefreshCanvas.Bool = false;
        }

        int cnt_Program_CCD02_02_PIN量測_檢測正位度計算 = 65534;
        void sub_Program_CCD02_02_PIN量測_檢測正位度計算()
        {
            if (cnt_Program_CCD02_02_PIN量測_檢測正位度計算 == 65534)
            {
                this.h_Canvas_Tech_CCD02_02_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_02_PIN量測正位度_OnCanvasDrawEvent;
                this.h_Canvas_Main_CCD02_02_檢測畫面.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_02_PIN量測正位度_OnCanvasDrawEvent;
                PLC_Device_CCD02_02_PIN量測_檢測正位度計算.SetComment("PLC_CCD02_02_PIN量測_檢測正位度計算");
                PLC_Device_CCD02_02_PIN量測_檢測正位度計算.Bool = false;
                cnt_Program_CCD02_02_PIN量測_檢測正位度計算 = 65535;

            }
            if (cnt_Program_CCD02_02_PIN量測_檢測正位度計算 == 65535) cnt_Program_CCD02_02_PIN量測_檢測正位度計算 = 1;
            if (cnt_Program_CCD02_02_PIN量測_檢測正位度計算 == 1) cnt_Program_CCD02_02_PIN量測_檢測正位度計算_檢查按下(ref cnt_Program_CCD02_02_PIN量測_檢測正位度計算);
            if (cnt_Program_CCD02_02_PIN量測_檢測正位度計算 == 2) cnt_Program_CCD02_02_PIN量測_檢測正位度計算_初始化(ref cnt_Program_CCD02_02_PIN量測_檢測正位度計算);
            if (cnt_Program_CCD02_02_PIN量測_檢測正位度計算 == 3) cnt_Program_CCD02_02_PIN量測_檢測正位度計算_數值計算(ref cnt_Program_CCD02_02_PIN量測_檢測正位度計算);
            if (cnt_Program_CCD02_02_PIN量測_檢測正位度計算 == 4) cnt_Program_CCD02_02_PIN量測_檢測正位度計算_量測結果(ref cnt_Program_CCD02_02_PIN量測_檢測正位度計算);
            if (cnt_Program_CCD02_02_PIN量測_檢測正位度計算 == 5) cnt_Program_CCD02_02_PIN量測_檢測正位度計算_繪製畫布(ref cnt_Program_CCD02_02_PIN量測_檢測正位度計算);
            if (cnt_Program_CCD02_02_PIN量測_檢測正位度計算 == 6) cnt_Program_CCD02_02_PIN量測_檢測正位度計算 = 65500;
            if (cnt_Program_CCD02_02_PIN量測_檢測正位度計算 > 1) cnt_Program_CCD02_02_PIN量測_檢測正位度計算_檢查放開(ref cnt_Program_CCD02_02_PIN量測_檢測正位度計算);

            if (cnt_Program_CCD02_02_PIN量測_檢測正位度計算 == 65500)
            {
                PLC_Device_CCD02_02_PIN量測_檢測正位度計算.Bool = false;
                cnt_Program_CCD02_02_PIN量測_檢測正位度計算 = 65535;
            }
        }
        void cnt_Program_CCD02_02_PIN量測_檢測正位度計算_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_02_PIN量測_檢測正位度計算.Bool) cnt++;
        }
        void cnt_Program_CCD02_02_PIN量測_檢測正位度計算_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_02_PIN量測_檢測正位度計算.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_02_PIN量測_檢測正位度計算_初始化(ref int cnt)
        {
            this.MyTimer_CCD02_02_PIN量測_檢測正位度計算.TickStop();
            this.MyTimer_CCD02_02_PIN量測_檢測正位度計算.StartTickTime(99999);
            this.List_CCD02_02_PIN正位度量測參數_正位度距離 = new double[40];
            this.List_CCD02_02_PIN正位度量測參數_正位度量測點_OK = new bool[40];

            cnt++;
        }
        void cnt_Program_CCD02_02_PIN量測_檢測正位度計算_數值計算(ref int cnt)
        {
            double distance = 0;
            double temp_X = 0;
            double temp_Y = 0;
            PLC_Device_CCD02_02_PIN量測_檢測正位度計算_OK.Bool = true;

            for (int i = 0; i < 40; i++)
            {
                if (this.List_CCD02_02_PIN量測參數_量測點_有無[i])
                {
                    temp_X = Math.Pow(this.List_CCD02_02_PIN量測參數_量測點[i].X - this.List_CCD02_02_PIN正位度量測參數_規範點[i].X, 2);
                    temp_Y = Math.Pow(this.List_CCD02_02_PIN量測參數_量測點[i].Y - this.List_CCD02_02_PIN正位度量測參數_規範點[i].Y, 2);

                    distance = Math.Sqrt(temp_X + temp_Y);
                    this.List_CCD02_02_PIN正位度量測參數_正位度距離[i] = distance * this.CCD02_比例尺_pixcel_To_mm;
                }
                else
                {
                    PLC_Device_CCD02_02_PIN量測_檢測正位度計算_OK.Bool = false;
                    List_CCD02_02_PIN正位度量測參數_正位度量測點_OK[i] = false;
                }

            }
            cnt++;
        }
        void cnt_Program_CCD02_02_PIN量測_檢測正位度計算_量測結果(ref int cnt)
        {

            PLC_Device_CCD02_02_PIN量測_檢測正位度計算_OK.Bool = true; // 檢測結果初始化

            for (int i = 0; i < 40; i++)
            {
                int 標準值差值 = this.PLC_Device_CCD02_02_PIN量測_檢測正位度計算_差值.Value;
                double 量測距離 = this.List_CCD02_02_PIN正位度量測參數_正位度距離[i];

                量測距離 = 量測距離 * 1000;
                量測距離 /= 1000;

                if (!PLC_Device_CCD02_02_PIN量測_檢測正位度計算_不測試.Bool)
                {
                    if (this.List_CCD02_02_PIN量測參數_量測點_有無[i])
                    {


                        if (量測距離 >= 0)
                        {
                            if (標準值差值 <= Math.Abs(量測距離) * 1000)
                            {
                                this.List_CCD02_02_PIN正位度量測參數_正位度量測點_OK[i] = false;
                                PLC_Device_CCD02_02_PIN量測_檢測正位度計算_OK.Bool = false;
                            }
                            else
                            {
                                this.List_CCD02_02_PIN正位度量測參數_正位度量測點_OK[i] = true;
                            }
                        }

                    }
                    else
                    {
                        this.List_CCD02_02_PIN正位度量測參數_正位度量測點_OK[i] = false;
                        PLC_Device_CCD02_02_PIN量測_檢測正位度計算_OK.Bool = false;
                    }
                }
                else
                {
                    this.List_CCD02_02_PIN正位度量測參數_正位度量測點_OK[i] = true;
                }

                this.List_CCD02_02_PIN正位度量測參數_正位度距離[i] = 量測距離;

            }

            cnt++;
        }
        void cnt_Program_CCD02_02_PIN量測_檢測正位度計算_繪製畫布(ref int cnt)
        {
            this.PLC_Device_CCD02_02_PIN量測_檢測正位度計算_RefreshCanvas.Bool = true;
            if (this.PLC_Device_CCD02_02_PIN量測_檢測正位度計算按鈕.Bool && !PLC_Device_CCD02_02_計算一次.Bool)
            {

                this.h_Canvas_Tech_CCD02_02_拼接完成圖.RefreshCanvas();
            }

            cnt++;
        }
        #endregion

        #region Event
        private void plC_RJ_Button_CCD02_02_拼接圖1_儲存圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.h_Canvas_Tech_CCD02_02_拼接圖1.SaveImage(saveImageDialog.FileName);
                }
            }));

        }
        private void plC_RJ_Button_CCD02_02_拼接圖1_讀取圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (openImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.CCD02_AxImageBW8.LoadFile(openImageDialog.FileName);
                    try
                    {
                        this.h_Canvas_Tech_CCD02_02_拼接圖1.ImageCopy(CCD02_AxImageBW8.VegaHandle);
                        this.CCD02_02_SrcImageHandle_拼接圖1 = h_Canvas_Tech_CCD02_02_拼接圖1.VegaHandle;
                        this.h_Canvas_Tech_CCD02_02_拼接圖1.RefreshCanvas();
                    }
                    catch
                    {
                        err_message4 = MessageBox.Show("讀取圖片空白", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (err_message4 == DialogResult.OK)
                        {

                        }
                    }
                }
            }));


        }
        private void plC_RJ_Button_CCD02_02_拼接圖2_儲存圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.h_Canvas_Tech_CCD02_02_拼接圖2.SaveImage(saveImageDialog.FileName);
                }
            }));
        }
        private void plC_RJ_Button_CCD02_02_拼接圖2_讀取圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (openImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.CCD02_AxImageBW8.LoadFile(openImageDialog.FileName);
                    try
                    {
                        this.h_Canvas_Tech_CCD02_02_拼接圖2.ImageCopy(CCD02_AxImageBW8.VegaHandle);
                        this.CCD02_02_SrcImageHandle_拼接圖2 = h_Canvas_Tech_CCD02_02_拼接圖2.VegaHandle;
                        this.h_Canvas_Tech_CCD02_02_拼接圖2.RefreshCanvas();
                    }
                    catch
                    {
                        err_message4 = MessageBox.Show("讀取圖片空白", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (err_message4 == DialogResult.OK)
                        {

                        }
                    }
                }
            }));
        }
        private void plC_RJ_Button_CCD02_02_拼接完成圖_儲存圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.h_Canvas_Tech_CCD02_02_拼接完成圖.SaveImage(saveImageDialog.FileName);
                }
            }));
        }
        private void plC_RJ_Button_CCD02_02_拼接完成圖_讀取圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (openImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.CCD02_AxImageBW8.LoadFile(openImageDialog.FileName);
                    try
                    {
                        this.h_Canvas_Tech_CCD02_02_拼接完成圖.ImageCopy(CCD02_AxImageBW8.VegaHandle);
                        this.CCD02_02_SrcImageHandle_拼接完成圖 = h_Canvas_Tech_CCD02_02_拼接完成圖.VegaHandle;
                        this.h_Canvas_Tech_CCD02_02_拼接完成圖.RefreshCanvas();
                    }
                    catch
                    {
                        err_message4 = MessageBox.Show("讀取圖片空白", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (err_message4 == DialogResult.OK)
                        {

                        }
                    }
                }
            }));
        }
        private void plC_RJ_Button_Main_CCD02_02儲存圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.h_Canvas_Main_CCD02_02_檢測畫面.SaveImage(saveImageDialog.FileName);
                }
            }));
        }
        private void plC_RJ_Button_Main_CCD012_02讀取圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (openImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.CCD02_AxImageBW8.LoadFile(openImageDialog.FileName);
                    try
                    {
                        this.h_Canvas_Main_CCD02_02_檢測畫面.ImageCopy(CCD02_AxImageBW8.VegaHandle);
                        this.CCD02_02_SrcImageHandle_拼接圖1 = h_Canvas_Main_CCD02_02_檢測畫面.VegaHandle;
                        this.h_Canvas_Main_CCD02_02_檢測畫面.RefreshCanvas();
                    }
                    catch
                    {
                        err_message4 = MessageBox.Show("讀取圖片空白", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                        if (err_message4 == DialogResult.OK)
                        {

                        }
                    }
                }
            }));
        }
        private void plC_Button_CCD02_02_儲存拼接檔案_btnClick(object sender, EventArgs e)
        {
            if (saveFileDialog_拼接校正檔.ShowDialog() == DialogResult.OK)
            {
                this.CCD02_02_AxImageSewer.SaveFile(saveFileDialog_拼接校正檔.FileName);
            }
        }
        private void plC_Button_CCD02_02_讀取拼接檔案_btnClick(object sender, EventArgs e)
        {
            if (openFileDialog_拼接校正檔.ShowDialog() == DialogResult.OK)
            {
                this.CCD02_02_AxImageSewer.LoadFile(@"C:\Users\Administrator\Desktop\Vens40P_CCD\Imagesewer_File\CCD02_02_Calibrate.cb");
            }
        }

        int CCD02_02_接圖1拼接順序 = 0;
        int CCD02_02_接圖2拼接順序 = 0;
        private void plC_Button_CCD02_02拼圖1校正SET_btnClick(object sender, EventArgs e)
        {
            if (PLC_Device_CCD02_02_校正量測框調整.Bool)
            {
                if (CCD02_02_接圖1拼接順序 == 0)
                {
                    PLC_Device_CCD02_02_校正量測框_拼圖1校正座標1_X.Value = PLC_Device_CCD02_02_校正量測框_拼圖1座標X.Value;
                    PLC_Device_CCD02_02_校正量測框_拼圖1校正座標1_Y.Value = PLC_Device_CCD02_02_校正量測框_拼圖1座標Y.Value;
                    CCD02_02_接圖1拼接順序 = 1;
                }
                else if (CCD02_02_接圖1拼接順序 == 1)
                {
                    PLC_Device_CCD02_02_校正量測框_拼圖1校正座標2_X.Value = PLC_Device_CCD02_02_校正量測框_拼圖1座標X.Value;
                    PLC_Device_CCD02_02_校正量測框_拼圖1校正座標2_Y.Value = PLC_Device_CCD02_02_校正量測框_拼圖1座標Y.Value;
                    CCD02_02_接圖1拼接順序 = 2;
                }
                else if (CCD02_02_接圖1拼接順序 == 2)
                {
                    PLC_Device_CCD02_02_校正量測框_拼圖1校正座標3_X.Value = PLC_Device_CCD02_02_校正量測框_拼圖1座標X.Value;
                    PLC_Device_CCD02_02_校正量測框_拼圖1校正座標3_Y.Value = PLC_Device_CCD02_02_校正量測框_拼圖1座標Y.Value;
                    CCD02_02_接圖1拼接順序 = 3;
                }
                else if (CCD02_02_接圖1拼接順序 == 3)
                {
                    PLC_Device_CCD02_02_校正量測框_拼圖1校正座標4_X.Value = PLC_Device_CCD02_02_校正量測框_拼圖1座標X.Value;
                    PLC_Device_CCD02_02_校正量測框_拼圖1校正座標4_Y.Value = PLC_Device_CCD02_02_校正量測框_拼圖1座標Y.Value;
                    CCD02_02_接圖1拼接順序 = 0;
                    MessageBox.Show("拼圖1校正點輸入完成", "訊息", MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }
        private void plC_Button_CCD02_02拼圖2校正SET_btnClick(object sender, EventArgs e)
        {
            if (PLC_Device_CCD02_02_校正量測框調整.Bool)
            {
                if (CCD02_02_接圖2拼接順序 == 0)
                {
                    PLC_Device_CCD02_02_校正量測框_拼圖2校正座標1_X.Value = PLC_Device_CCD02_02_校正量測框_拼圖2座標X.Value;
                    PLC_Device_CCD02_02_校正量測框_拼圖2校正座標1_Y.Value = PLC_Device_CCD02_02_校正量測框_拼圖2座標Y.Value;
                    CCD02_02_接圖2拼接順序 = 1;
                }
                else if (CCD02_02_接圖2拼接順序 == 1)
                {
                    PLC_Device_CCD02_02_校正量測框_拼圖2校正座標2_X.Value = PLC_Device_CCD02_02_校正量測框_拼圖2座標X.Value;
                    PLC_Device_CCD02_02_校正量測框_拼圖2校正座標2_Y.Value = PLC_Device_CCD02_02_校正量測框_拼圖2座標Y.Value;
                    CCD02_02_接圖2拼接順序 = 2;
                }
                else if (CCD02_02_接圖2拼接順序 == 2)
                {
                    PLC_Device_CCD02_02_校正量測框_拼圖2校正座標3_X.Value = PLC_Device_CCD02_02_校正量測框_拼圖2座標X.Value;
                    PLC_Device_CCD02_02_校正量測框_拼圖2校正座標3_Y.Value = PLC_Device_CCD02_02_校正量測框_拼圖2座標Y.Value;
                    CCD02_02_接圖2拼接順序 = 3;
                }
                else if (CCD02_02_接圖2拼接順序 == 3)
                {
                    PLC_Device_CCD02_02_校正量測框_拼圖2校正座標4_X.Value = PLC_Device_CCD02_02_校正量測框_拼圖2座標X.Value;
                    PLC_Device_CCD02_02_校正量測框_拼圖2校正座標4_Y.Value = PLC_Device_CCD02_02_校正量測框_拼圖2座標Y.Value;
                    CCD02_02_接圖2拼接順序 = 0;
                    MessageBox.Show("拼圖2校正點輸入完成", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }

        }

        private void plC_RJ_Button_CCD02_02_Tech_PIN量測框大小設為一致_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 40; i++)
            {
                this.List_PLC_Device_CCD02_02_PIN量測參數_Width[i].Value = this.List_PLC_Device_CCD02_02_PIN量測參數_Width[0].Value;
                this.List_PLC_Device_CCD02_02_PIN量測參數_Height[i].Value = this.List_PLC_Device_CCD02_02_PIN量測參數_Height[0].Value;
                this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值[i].Value = this.List_PLC_Device_CCD02_02_PIN量測參數_灰階門檻值[0].Value;
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限[i].Value = this.List_PLC_Device_CCD02_02_PIN量測參數_面積上限[0].Value;
                this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限[i].Value = this.List_PLC_Device_CCD02_02_PIN量測參數_面積下限[0].Value;

            }



        }

        private PLC_Device PLC_Device_CCD02_02_PIN量測一鍵排列間距 = new PLC_Device("F4001");
        private void plC_RJ_Button_CCD02_02_Tech_PIN量測框一鍵排列_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 40; i++)
            {
                if (i < 20)
                {
                    this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[i].Value = this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[0].Value + i * PLC_Device_CCD02_02_PIN量測一鍵排列間距.Value;
                    this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[i].Value = this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[0].Value;
                }

                else
                {
                    this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[i].Value = this.List_PLC_Device_CCD02_02_PIN量測參數_OrgX[20].Value + (i - 20) * PLC_Device_CCD02_02_PIN量測一鍵排列間距.Value;
                    this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[i].Value = this.List_PLC_Device_CCD02_02_PIN量測參數_OrgY[20].Value;
                }

            }


        }
        #endregion
    }
}

