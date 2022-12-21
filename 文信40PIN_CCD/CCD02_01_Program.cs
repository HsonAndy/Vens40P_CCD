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


        DialogResult err_message2;

        void Program_CCD02_01()
        {
            this.sub_Program_CCD02_01_SNAP_拼接圖1();
            this.sub_Program_CCD02_01_SNAP_拼接圖2();
            this.sub_Program_CCD02_01_Tech_檢驗一次();
            this.sub_Program_CCD02_01_計算一次();
            this.sub_Program_CCD02_01_拼接校正();
            this.sub_Program_CCD02_01_校正量測框();
            this.sub_Program_CCD02_01_影像拼接();
            this.sub_Program_CCD02_01_基準線量測();
            this.sub_Program_CCD02_01_Main_取像並檢驗();
            this.Program_CCD02_01_PIN量測_combobox();

        }

        #region PLC_CCD02_01_SNAP_拼接圖1
        PLC_Device PLC_Device_CCD02_01_SNAP_拼接圖1_按鈕 = new PLC_Device("S15110");
        PLC_Device PLC_Device_CCD02_01_SNAP_拼接圖1 = new PLC_Device("S15105");
        PLC_Device PLC_Device_CCD02_01_SNAP_拼接圖1_LIVE = new PLC_Device("S15106");
        PLC_Device PLC_Device_CCD02_01_SNAP_拼接圖1_電子快門 = new PLC_Device("F9100");
        PLC_Device PLC_Device_CCD02_01_SNAP_拼接圖1_視訊增益 = new PLC_Device("F9101");
        PLC_Device PLC_Device_CCD02_01_SNAP_拼接圖1_銳利度 = new PLC_Device("F9102");
        PLC_Device PLC_Device_CCD02_01_SNAP_拼接圖1_光源亮度_白正照 = new PLC_Device("F25140");
        PLC_Device PLC_Device_CCD02_01_SNAP_拼接圖1_光源亮度_藍側照 = new PLC_Device("F25141");

        int cnt_Program_CCD02_01_SNAP_拼接圖1 = 65534;
        void sub_Program_CCD02_01_SNAP_拼接圖1()
        {
            if (cnt_Program_CCD02_01_SNAP_拼接圖1 == 65534)
            {
                PLC_Device_CCD02_01_SNAP_拼接圖1.SetComment("PLC_CCD02_01_SNAP_拼接圖1");
                PLC_Device_CCD02_01_SNAP_拼接圖1.Bool = false;
                cnt_Program_CCD02_01_SNAP_拼接圖1 = 65535;
            }
            if (cnt_Program_CCD02_01_SNAP_拼接圖1 == 65535) cnt_Program_CCD02_01_SNAP_拼接圖1 = 1;
            if (cnt_Program_CCD02_01_SNAP_拼接圖1 == 1) cnt_Program_CCD02_01_SNAP_拼接圖1_檢查按下(ref cnt_Program_CCD02_01_SNAP_拼接圖1);
            if (cnt_Program_CCD02_01_SNAP_拼接圖1 == 2) cnt_Program_CCD02_01_SNAP_拼接圖1_初始化(ref cnt_Program_CCD02_01_SNAP_拼接圖1);
            if (cnt_Program_CCD02_01_SNAP_拼接圖1 == 3) cnt_Program_CCD02_01_SNAP_拼接圖1_開始取像(ref cnt_Program_CCD02_01_SNAP_拼接圖1);
            if (cnt_Program_CCD02_01_SNAP_拼接圖1 == 4) cnt_Program_CCD02_01_SNAP_拼接圖1_取像結束(ref cnt_Program_CCD02_01_SNAP_拼接圖1);
            if (cnt_Program_CCD02_01_SNAP_拼接圖1 == 5) cnt_Program_CCD02_01_SNAP_拼接圖1_繪製影像(ref cnt_Program_CCD02_01_SNAP_拼接圖1);
            if (cnt_Program_CCD02_01_SNAP_拼接圖1 == 6) cnt_Program_CCD02_01_SNAP_拼接圖1 = 65500;
            if (cnt_Program_CCD02_01_SNAP_拼接圖1 > 1) cnt_Program_CCD02_01_SNAP_拼接圖1_檢查放開(ref cnt_Program_CCD02_01_SNAP_拼接圖1);

            if (cnt_Program_CCD02_01_SNAP_拼接圖1 == 65500)
            {
                PLC_Device_CCD02_SNAP.Bool = false;
                PLC_Device_CCD02_01_SNAP_拼接圖1.Bool = false;
                cnt_Program_CCD02_01_SNAP_拼接圖1 = 65535;
            }
        }
        void cnt_Program_CCD02_01_SNAP_拼接圖1_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_01_SNAP_拼接圖1.Bool) cnt++;
        }
        void cnt_Program_CCD02_01_SNAP_拼接圖1_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_01_SNAP_拼接圖1.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_01_SNAP_拼接圖1_初始化(ref int cnt)
        {
            PLC_Device_CCD02_SNAP_電子快門.Value = PLC_Device_CCD02_01_SNAP_拼接圖1_電子快門.Value;
            PLC_Device_CCD02_SNAP_視訊增益.Value = PLC_Device_CCD02_01_SNAP_拼接圖1_視訊增益.Value;
            PLC_Device_CCD02_SNAP_銳利度.Value = PLC_Device_CCD02_01_SNAP_拼接圖1_銳利度.Value;

            cnt++;
        }
        void cnt_Program_CCD02_01_SNAP_拼接圖1_開始取像(ref int cnt)
        {
            if (!PLC_Device_CCD02_SNAP.Bool)
            {
                PLC_Device_CCD02_SNAP.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD02_01_SNAP_拼接圖1_取像結束(ref int cnt)
        {
            if (!PLC_Device_CCD02_SNAP.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD02_01_SNAP_拼接圖1_繪製影像(ref int cnt)
        {
            this.CCD02_01_SrcImageHandle_拼接圖1 = this.h_Canvas_Tech_CCD02_01_拼接圖1.VegaHandle;
            this.h_Canvas_Tech_CCD02_01_拼接圖1.ImageCopy(this.CCD02_AxImageBW8.VegaHandle);
            this.h_Canvas_Tech_CCD02_01_拼接圖1.SetImageSize(this.h_Canvas_Tech_CCD02_01_拼接圖1.ImageWidth, this.h_Canvas_Tech_CCD02_01_拼接圖1.ImageHeight);
            if (this.PLC_Device_CCD02_01_SNAP_拼接圖1_按鈕.Bool) this.h_Canvas_Tech_CCD02_01_拼接圖1.RefreshCanvas();

            if (PLC_Device_CCD02_01_SNAP_拼接圖1_LIVE.Bool)
            {
                cnt = 2;
                return;
            }
            cnt++;
        }





        #endregion
        #region PLC_CCD02_01_SNAP_拼接圖2
        PLC_Device PLC_Device_CCD02_01_SNAP_拼接圖2_按鈕 = new PLC_Device("S15130");
        PLC_Device PLC_Device_CCD02_01_SNAP_拼接圖2 = new PLC_Device("S15125");
        PLC_Device PLC_Device_CCD02_01_SNAP_拼接圖2_LIVE = new PLC_Device("S15116");

        int cnt_Program_CCD02_01_SNAP_拼接圖2 = 65534;
        void sub_Program_CCD02_01_SNAP_拼接圖2()
        {
            if (cnt_Program_CCD02_01_SNAP_拼接圖2 == 65534)
            {
                PLC_Device_CCD02_01_SNAP_拼接圖2.SetComment("PLC_CCD02_01_SNAP_拼接圖2");
                PLC_Device_CCD02_01_SNAP_拼接圖2.Bool = false;
                cnt_Program_CCD02_01_SNAP_拼接圖2 = 65535;
            }
            if (cnt_Program_CCD02_01_SNAP_拼接圖2 == 65535) cnt_Program_CCD02_01_SNAP_拼接圖2 = 1;
            if (cnt_Program_CCD02_01_SNAP_拼接圖2 == 1) cnt_Program_CCD02_01_SNAP_拼接圖2_檢查按下(ref cnt_Program_CCD02_01_SNAP_拼接圖2);
            if (cnt_Program_CCD02_01_SNAP_拼接圖2 == 2) cnt_Program_CCD02_01_SNAP_拼接圖2_初始化(ref cnt_Program_CCD02_01_SNAP_拼接圖2);
            if (cnt_Program_CCD02_01_SNAP_拼接圖2 == 3) cnt_Program_CCD02_01_SNAP_拼接圖2_開始取像(ref cnt_Program_CCD02_01_SNAP_拼接圖2);
            if (cnt_Program_CCD02_01_SNAP_拼接圖2 == 4) cnt_Program_CCD02_01_SNAP_拼接圖2_取像結束(ref cnt_Program_CCD02_01_SNAP_拼接圖2);
            if (cnt_Program_CCD02_01_SNAP_拼接圖2 == 5) cnt_Program_CCD02_01_SNAP_拼接圖2_繪製影像(ref cnt_Program_CCD02_01_SNAP_拼接圖2);
            if (cnt_Program_CCD02_01_SNAP_拼接圖2 == 6) cnt_Program_CCD02_01_SNAP_拼接圖2 = 65500;
            if (cnt_Program_CCD02_01_SNAP_拼接圖2 > 1) cnt_Program_CCD02_01_SNAP_拼接圖2_檢查放開(ref cnt_Program_CCD02_01_SNAP_拼接圖2);

            if (cnt_Program_CCD02_01_SNAP_拼接圖2 == 65500)
            {
                PLC_Device_CCD02_SNAP.Bool = false;
                PLC_Device_CCD02_01_SNAP_拼接圖2.Bool = false;
                cnt_Program_CCD02_01_SNAP_拼接圖2 = 65535;
            }
        }
        void cnt_Program_CCD02_01_SNAP_拼接圖2_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_01_SNAP_拼接圖2.Bool) cnt++;
        }
        void cnt_Program_CCD02_01_SNAP_拼接圖2_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_01_SNAP_拼接圖2.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_01_SNAP_拼接圖2_初始化(ref int cnt)
        {
            PLC_Device_CCD02_SNAP_電子快門.Value = PLC_Device_CCD02_01_SNAP_拼接圖1_電子快門.Value;
            PLC_Device_CCD02_SNAP_視訊增益.Value = PLC_Device_CCD02_01_SNAP_拼接圖1_視訊增益.Value;
            PLC_Device_CCD02_SNAP_銳利度.Value = PLC_Device_CCD02_01_SNAP_拼接圖1_銳利度.Value;

            cnt++;
        }
        void cnt_Program_CCD02_01_SNAP_拼接圖2_開始取像(ref int cnt)
        {
            if (!PLC_Device_CCD02_SNAP.Bool)
            {
                PLC_Device_CCD02_SNAP.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD02_01_SNAP_拼接圖2_取像結束(ref int cnt)
        {
            if (!PLC_Device_CCD02_SNAP.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD02_01_SNAP_拼接圖2_繪製影像(ref int cnt)
        {
            this.CCD02_01_SrcImageHandle_拼接圖2 = this.h_Canvas_Tech_CCD02_01_拼接圖2.VegaHandle;
            this.h_Canvas_Tech_CCD02_01_拼接圖2.ImageCopy(this.CCD02_AxImageBW8.VegaHandle);
            this.h_Canvas_Tech_CCD02_01_拼接圖2.SetImageSize(this.h_Canvas_Tech_CCD02_01_拼接圖2.ImageWidth, this.h_Canvas_Tech_CCD02_01_拼接圖2.ImageHeight);
            if (this.PLC_Device_CCD02_01_SNAP_拼接圖2_按鈕.Bool) this.h_Canvas_Tech_CCD02_01_拼接圖2.RefreshCanvas();

            if (PLC_Device_CCD02_01_SNAP_拼接圖2_LIVE.Bool)
            {
                cnt = 2;
                return;
            }
            cnt++;
        }





        #endregion               
        #region PLC_CCD02_01_拼接校正
        PLC_Device PLC_Device_CCD02_01_拼接校正_按鈕 = new PLC_Device("S18110");
        PLC_Device PLC_Device_CCD02_01_拼接校正 = new PLC_Device("S18105");
        PLC_Device PLC_Device_CCD02_01_拼接校正_RefreshCanvas = new PLC_Device("S18106");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real1_1_X = new PLC_Device("F6150");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real1_2_X = new PLC_Device("F6151");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real1_3_X = new PLC_Device("F6152");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real1_4_X = new PLC_Device("F6153");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real2_1_X = new PLC_Device("F6154");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real2_2_X = new PLC_Device("F6155");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real2_3_X = new PLC_Device("F6156");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real2_4_X = new PLC_Device("F6157");

        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real1_1_Y = new PLC_Device("F6160");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real1_2_Y = new PLC_Device("F6161");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real1_3_Y = new PLC_Device("F6162");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real1_4_Y = new PLC_Device("F6163");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real2_1_Y = new PLC_Device("F6164");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real2_2_Y = new PLC_Device("F6165");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real2_3_Y = new PLC_Device("F6166");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_Real2_4_Y = new PLC_Device("F6167");
        private AxOvkImage.AxImageSewer CCD02_01_AxImageSewer;
        double CCD02_01拼圖1_X1 = new double();
        double CCD02_01拼圖1_Y1 = new double();
        double CCD02_01拼圖1_X2 = new double();
        double CCD02_01拼圖1_Y2 = new double();
        double CCD02_01拼圖1_X3 = new double();
        double CCD02_01拼圖1_Y3 = new double();
        double CCD02_01拼圖1_X4 = new double();
        double CCD02_01拼圖1_Y4 = new double();

        double CCD02_01拼圖2_X1 = new double();
        double CCD02_01拼圖2_Y1 = new double();
        double CCD02_01拼圖2_X2 = new double();
        double CCD02_01拼圖2_Y2 = new double();
        double CCD02_01拼圖2_X3 = new double();
        double CCD02_01拼圖2_Y3 = new double();
        double CCD02_01拼圖2_X4 = new double();
        double CCD02_01拼圖2_Y4 = new double();

        private void H_Canvas_Tech_CCD02_01_拼接校正_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            try
            {

                if (this.PLC_Device_CCD02_01_拼接校正_RefreshCanvas.Bool)
                {

                    Graphics g = Graphics.FromHdc((IntPtr)HDC);




                    DrawingClass.Draw.十字中心(CCD02_01拼圖1校正點座標, 50, Color.Lime, 1, g, ZoomX, ZoomY);
                    g.Dispose();
                    g = null;
                }
            }
            catch
            {

            }

            this.PLC_Device_CCD02_01_拼接校正_RefreshCanvas.Bool = false;
        }
        int cnt_Program_CCD02_01_拼接校正 = 65534;
        void sub_Program_CCD02_01_拼接校正()
        {
            if(CCD02_01_AxImageSewer != null)
            {
                if (cnt_Program_CCD02_01_拼接校正 == 65534)
                {
                    h_Canvas_Tech_CCD02_01_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_01_拼接校正_OnCanvasDrawEvent;
                    this.CCD02_01_AxImageSewer.LoadFile(@"C:\Users\Administrator\Desktop\Vens40P_CCD\Imagesewer_File\CCD02_01_Calibrate.cb");
                    #region 拼圖座標
                    CCD02_01拼圖1_X1 = PLC_Device_CCD02_01_校正量測框_拼圖1校正座標1_X.Value / 1000D;
                    CCD02_01拼圖1_Y1 = PLC_Device_CCD02_01_校正量測框_拼圖1校正座標1_Y.Value / 1000D;
                    CCD02_01拼圖1_X2 = PLC_Device_CCD02_01_校正量測框_拼圖1校正座標2_X.Value / 1000D;
                    CCD02_01拼圖1_Y2 = PLC_Device_CCD02_01_校正量測框_拼圖1校正座標2_Y.Value / 1000D;
                    CCD02_01拼圖1_X3 = PLC_Device_CCD02_01_校正量測框_拼圖1校正座標3_X.Value / 1000D;
                    CCD02_01拼圖1_Y3 = PLC_Device_CCD02_01_校正量測框_拼圖1校正座標3_Y.Value / 1000D;
                    CCD02_01拼圖1_X4 = PLC_Device_CCD02_01_校正量測框_拼圖1校正座標4_X.Value / 1000D;
                    CCD02_01拼圖1_Y4 = PLC_Device_CCD02_01_校正量測框_拼圖1校正座標4_Y.Value / 1000D;

                    CCD02_01拼圖2_X1 = PLC_Device_CCD02_01_校正量測框_拼圖2校正座標1_X.Value / 1000D;
                    CCD02_01拼圖2_Y1 = PLC_Device_CCD02_01_校正量測框_拼圖2校正座標1_Y.Value / 1000D;
                    CCD02_01拼圖2_X2 = PLC_Device_CCD02_01_校正量測框_拼圖2校正座標2_X.Value / 1000D;
                    CCD02_01拼圖2_Y2 = PLC_Device_CCD02_01_校正量測框_拼圖2校正座標2_Y.Value / 1000D;
                    CCD02_01拼圖2_X3 = PLC_Device_CCD02_01_校正量測框_拼圖2校正座標3_X.Value / 1000D;
                    CCD02_01拼圖2_Y3 = PLC_Device_CCD02_01_校正量測框_拼圖2校正座標3_Y.Value / 1000D;
                    CCD02_01拼圖2_X4 = PLC_Device_CCD02_01_校正量測框_拼圖2校正座標4_X.Value / 1000D;
                    CCD02_01拼圖2_Y4 = PLC_Device_CCD02_01_校正量測框_拼圖2校正座標4_Y.Value / 1000D;
                    #endregion
                    PLC_Device_CCD02_01_拼接校正.SetComment("PLC_CCD02_01_拼接校正");
                    PLC_Device_CCD02_01_拼接校正.Bool = false;
                    cnt_Program_CCD02_01_拼接校正 = 65535;
                }
                if (cnt_Program_CCD02_01_拼接校正 == 65535) cnt_Program_CCD02_01_拼接校正 = 1;
                if (cnt_Program_CCD02_01_拼接校正 == 1) cnt_Program_CCD02_01_拼接校正_檢查按下(ref cnt_Program_CCD02_01_拼接校正);
                if (cnt_Program_CCD02_01_拼接校正 == 2) cnt_Program_CCD02_01_拼接校正_初始化(ref cnt_Program_CCD02_01_拼接校正);
                if (cnt_Program_CCD02_01_拼接校正 == 3) cnt_Program_CCD02_01_拼接校正_拼接教導完成(ref cnt_Program_CCD02_01_拼接校正);
                if (cnt_Program_CCD02_01_拼接校正 == 4) cnt_Program_CCD02_01_拼接校正_繪製影像(ref cnt_Program_CCD02_01_拼接校正);
                if (cnt_Program_CCD02_01_拼接校正 == 5) cnt_Program_CCD02_01_拼接校正 = 65500;
                if (cnt_Program_CCD02_01_拼接校正 > 1) cnt_Program_CCD02_01_拼接校正_檢查放開(ref cnt_Program_CCD02_01_拼接校正);
                if (cnt_Program_CCD02_01_拼接校正 == 65500)
                {
                    PLC_Device_CCD02_01_拼接校正.Bool = false;
                    cnt_Program_CCD02_01_拼接校正 = 65535;
                }
            }

        }
        void cnt_Program_CCD02_01_拼接校正_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_01_拼接校正.Bool) cnt++;
        }
        void cnt_Program_CCD02_01_拼接校正_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_01_拼接校正.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_01_拼接校正_初始化(ref int cnt)
        {
            
            this.CCD02_01_AxImageSewer.UseGreylevelImage = true;
            this.CCD02_01_AxImageSewer.GreylevelBlankColor = 0;
            this.CCD02_01_AxImageSewer.DstImageWidth = h_Canvas_Tech_CCD02_01_拼接完成圖.ImageWidth;
            this.CCD02_01_AxImageSewer.DstImageHeight = h_Canvas_Tech_CCD02_01_拼接完成圖.ImageHeight;
            this.CCD02_01_AxImageSewer.DstImageWidth = 2592;
            this.CCD02_01_AxImageSewer.DstImageHeight = 1944;

            this.CCD02_01_AxImageSewer.NumOfSrcImages = 2;

            this.CCD02_01_AxImageSewer.SrcImageIndex = 0;
            this.CCD02_01_AxImageSewer.SrcImageWidth = h_Canvas_Tech_CCD02_01_拼接圖1.ImageWidth;
            this.CCD02_01_AxImageSewer.SrcImageHeight = h_Canvas_Tech_CCD02_01_拼接圖1.ImageHeight;
            this.CCD02_01_AxImageSewer.MapperMethod = AxOvkImage.TxAxImageSewerWorldMapperMethod.AX_IMAGE_SEWER_MAPPER_METHOD_PERSPECTIVE_METHOD;
            this.CCD02_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA1, CCD02_01拼圖1_X1, CCD02_01拼圖1_Y1, PLC_Device_CCD02_01_校正量測框_Real1_1_X.Value, PLC_Device_CCD02_01_校正量測框_Real1_1_Y.Value);
            this.CCD02_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA2, CCD02_01拼圖1_X2, CCD02_01拼圖1_Y2, PLC_Device_CCD02_01_校正量測框_Real1_2_X.Value, PLC_Device_CCD02_01_校正量測框_Real1_2_Y.Value);
            this.CCD02_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA3, CCD02_01拼圖1_X3, CCD02_01拼圖1_Y3, PLC_Device_CCD02_01_校正量測框_Real1_3_X.Value, PLC_Device_CCD02_01_校正量測框_Real1_3_Y.Value);
            this.CCD02_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA4, CCD02_01拼圖1_X4, CCD02_01拼圖1_Y4, PLC_Device_CCD02_01_校正量測框_Real1_4_X.Value, PLC_Device_CCD02_01_校正量測框_Real1_4_Y.Value);



            this.CCD02_01_AxImageSewer.SrcImageIndex = 1;
            this.CCD02_01_AxImageSewer.SrcImageWidth = h_Canvas_Tech_CCD02_01_拼接圖2.ImageWidth;
            this.CCD02_01_AxImageSewer.SrcImageHeight = h_Canvas_Tech_CCD02_01_拼接圖2.ImageHeight;
            this.CCD02_01_AxImageSewer.MapperMethod = AxOvkImage.TxAxImageSewerWorldMapperMethod.AX_IMAGE_SEWER_MAPPER_METHOD_PERSPECTIVE_METHOD;
            this.CCD02_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA1, CCD02_01拼圖2_X1, CCD02_01拼圖2_Y1, PLC_Device_CCD02_01_校正量測框_Real2_1_X.Value, PLC_Device_CCD02_01_校正量測框_Real2_1_Y.Value);
            this.CCD02_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA2, CCD02_01拼圖2_X2, CCD02_01拼圖2_Y2, PLC_Device_CCD02_01_校正量測框_Real2_2_X.Value, PLC_Device_CCD02_01_校正量測框_Real2_2_Y.Value);
            this.CCD02_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA3, CCD02_01拼圖2_X3, CCD02_01拼圖2_Y3, PLC_Device_CCD02_01_校正量測框_Real2_3_X.Value, PLC_Device_CCD02_01_校正量測框_Real2_3_Y.Value);
            this.CCD02_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA4, CCD02_01拼圖2_X4, CCD02_01拼圖2_Y4, PLC_Device_CCD02_01_校正量測框_Real2_4_X.Value, PLC_Device_CCD02_01_校正量測框_Real2_4_Y.Value);

            this.CCD02_01_AxImageSewer.Calibrate();




                cnt++;
            

        }
        void cnt_Program_CCD02_01_拼接校正_拼接教導完成(ref int cnt)
        {
            if (CCD02_01_AxImageSewer.Calibrate() == true)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD02_01_拼接校正_繪製影像(ref int cnt)
        {
            cnt++;
        }





        #endregion
        #region PLC_CCD02_01_影像拼接
        PLC_Device PLC_Device_CCD02_01_影像拼接_按鈕 = new PLC_Device("S18130");
        PLC_Device PLC_Device_CCD02_01_影像拼接 = new PLC_Device("S18125");
        PLC_Device PLC_Device_CCD02_01_影像拼接_RefreshCanvas = new PLC_Device("S18126");

        private void H_Canvas_Tech_CCD02_01_影像拼接_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            try
            {

                if (this.PLC_Device_CCD02_01_影像拼接_RefreshCanvas.Bool)
                {

                    Graphics g = Graphics.FromHdc((IntPtr)HDC);
                    // DrawingClass.Draw.十字中心(CCD02_01拼圖1校正點座標, 50, Color.Lime, 1, g, ZoomX, ZoomY);
                    g.Dispose();
                    g = null;
                }
            }
            catch
            {

            }

            this.PLC_Device_CCD02_01_影像拼接_RefreshCanvas.Bool = false;
        }
        int cnt_Program_CCD02_01_影像拼接 = 65534;
        void sub_Program_CCD02_01_影像拼接()
        {
            if (cnt_Program_CCD02_01_影像拼接 == 65534)
            {
                h_Canvas_Tech_CCD02_01_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_01_影像拼接_OnCanvasDrawEvent;

                PLC_Device_CCD02_01_影像拼接.SetComment("PLC_CCD02_01_影像拼接");
                PLC_Device_CCD02_01_影像拼接.Bool = false;
                cnt_Program_CCD02_01_影像拼接 = 65535;
            }
            if (cnt_Program_CCD02_01_影像拼接 == 65535) cnt_Program_CCD02_01_影像拼接 = 1;
            if (cnt_Program_CCD02_01_影像拼接 == 1) cnt_Program_CCD02_01_影像拼接_檢查按下(ref cnt_Program_CCD02_01_影像拼接);
            if (cnt_Program_CCD02_01_影像拼接 == 2) cnt_Program_CCD02_01_影像拼接_初始化(ref cnt_Program_CCD02_01_影像拼接);
            if (cnt_Program_CCD02_01_影像拼接 == 3) cnt_Program_CCD02_01_影像拼接_影像拼接(ref cnt_Program_CCD02_01_影像拼接);
            if (cnt_Program_CCD02_01_影像拼接 == 4) cnt_Program_CCD02_01_影像拼接_繪製影像(ref cnt_Program_CCD02_01_影像拼接);
            if (cnt_Program_CCD02_01_影像拼接 == 5) cnt_Program_CCD02_01_影像拼接 = 65500;
            if (cnt_Program_CCD02_01_影像拼接 > 1) cnt_Program_CCD02_01_影像拼接_檢查放開(ref cnt_Program_CCD02_01_影像拼接);
            if (cnt_Program_CCD02_01_影像拼接 == 65500)
            {
                PLC_Device_CCD02_01_影像拼接.Bool = false;
                cnt_Program_CCD02_01_影像拼接 = 65535;
            }
        }
        void cnt_Program_CCD02_01_影像拼接_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_01_影像拼接.Bool) cnt++;
        }
        void cnt_Program_CCD02_01_影像拼接_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_01_影像拼接.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_01_影像拼接_初始化(ref int cnt)
        {
            this.CCD02_01_AxImageSewer.SrcImageIndex = 0;
            this.CCD02_01_AxImageSewer.SrcImageHandle = h_Canvas_Tech_CCD02_01_拼接圖1.VegaHandle;
            this.CCD02_01_AxImageSewer.SrcImageIndex = 1;
            this.CCD02_01_AxImageSewer.SrcImageHandle = h_Canvas_Tech_CCD02_01_拼接圖2.VegaHandle;
            cnt++;
        }
        void cnt_Program_CCD02_01_影像拼接_影像拼接(ref int cnt)
        {

            CCD02_01_AxImageSewer.Sew();
            cnt++;

        }
        void cnt_Program_CCD02_01_影像拼接_繪製影像(ref int cnt)
        {
            if (CCD02_01_AxImageSewer.Sew())
            {
                PLC_Device_CCD02_01_影像拼接_RefreshCanvas.Bool = true;
                this.h_Canvas_Tech_CCD02_01_拼接完成圖.ImageCopy(this.CCD02_01_AxImageSewer.DstImageHandle);
                this.CCD02_01_SrcImageHandle_拼接完成圖 = this.CCD02_01_AxImageSewer.DstImageHandle;
                this.h_Canvas_Tech_CCD02_01_拼接完成圖.RefreshCanvas();
                cnt++;
            }
        }





        #endregion
        #region PLC_CCD02_01_校正量測框調整
        PLC_Device PLC_Device_CCD02_01_校正量測框調整_按鈕 = new PLC_Device("S18150");
        PLC_Device PLC_Device_CCD02_01_校正量測框調整 = new PLC_Device("S18145");
        PLC_Device PLC_Device_CCD02_01_拼圖1校正量測框調整_RefreshCanvas = new PLC_Device("S6010");
        PLC_Device PLC_Device_CCD02_01_拼圖2校正量測框調整_RefreshCanvas = new PLC_Device("S6011");
        private AxOvkBase.AxROIBW8 CCD02_01_AxROIBW8_拼圖1校正量測框調整;
        private AxOvkBlob.AxObject CCD02_01_AxObject_拼圖1校正量測框調整;
        private AxOvkBase.AxROIBW8 CCD02_01_AxROIBW8_拼圖2校正量測框調整;
        private AxOvkBlob.AxObject CCD02_01_AxObject_拼圖2校正量測框調整;
        private PLC_Device PLC_Device_CCD02_01_校正量測框_灰階門檻值 = new PLC_Device("F6100");
        private PLC_Device PLC_Device_CCD02_01_拼圖1校正量測框_OrgX = new PLC_Device("F6101");
        private PLC_Device PLC_Device_CCD02_01_拼圖1校正量測框_OrgY = new PLC_Device("F6102");
        private PLC_Device PLC_Device_CCD02_01_拼圖1校正量測框_Width = new PLC_Device("F6103");
        private PLC_Device PLC_Device_CCD02_01_拼圖1校正量測框_Height = new PLC_Device("F6104");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_面積上限 = new PLC_Device("F6105");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_面積下限 = new PLC_Device("F6106");
        private PLC_Device PLC_Device_CCD02_01_拼圖2校正量測框_OrgX = new PLC_Device("F6111");
        private PLC_Device PLC_Device_CCD02_01_拼圖2校正量測框_OrgY = new PLC_Device("F6112");
        private PLC_Device PLC_Device_CCD02_01_拼圖2校正量測框_Width = new PLC_Device("F6113");
        private PLC_Device PLC_Device_CCD02_01_拼圖2校正量測框_Height = new PLC_Device("F6114");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖1座標X = new PLC_Device("F6120");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖1座標Y = new PLC_Device("F6121");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖1校正座標1_X = new PLC_Device("F6122");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖1校正座標1_Y = new PLC_Device("F6123");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖1校正座標2_X = new PLC_Device("F6124");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖1校正座標2_Y = new PLC_Device("F6125");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖1校正座標3_X = new PLC_Device("F6126");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖1校正座標3_Y = new PLC_Device("F6127");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖1校正座標4_X = new PLC_Device("F6128");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖1校正座標4_Y = new PLC_Device("F6129");

        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖2座標X = new PLC_Device("F6130");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖2座標Y = new PLC_Device("F6131");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖2校正座標1_X = new PLC_Device("F6132");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖2校正座標1_Y = new PLC_Device("F6133");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖2校正座標2_X = new PLC_Device("F6134");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖2校正座標2_Y = new PLC_Device("F6135");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖2校正座標3_X = new PLC_Device("F6136");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖2校正座標3_Y = new PLC_Device("F6137");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖2校正座標4_X = new PLC_Device("F6138");
        private PLC_Device PLC_Device_CCD02_01_校正量測框_拼圖2校正座標4_Y = new PLC_Device("F6139");

        PointF CCD02_01拼圖1校正點座標 = new PointF();
        PointF CCD02_01拼圖2校正點座標 = new PointF();

        private AxOvkBase.TxAxHitHandle CCD02_01_TxAxHitHandle_AxROIBW8_拼圖1校正量測框調整 = new AxOvkBase.TxAxHitHandle();
        private bool flag_CCD02_01_拼圖1校正量測框調整_AxROIBW8_MouseDown;
        private AxOvkBase.TxAxHitHandle CCD02_01_TxAxHitHandle_AxROIBW8_拼圖2校正量測框調整 = new AxOvkBase.TxAxHitHandle();
        private bool flag_CCD02_01_拼圖2校正量測框調整_AxROIBW8_MouseDown;
        private void H_Canvas_Tech_CCD02_01_拼圖1校正量測框調整_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            
            try
            {

                if (this.PLC_Device_CCD02_01_拼圖1校正量測框調整_RefreshCanvas.Bool)
                {

                    Graphics g = Graphics.FromHdc((IntPtr)HDC);

                    this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.ShowTitle = true;
                    this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.ShowPlacement = false;
                    this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.Title = "拼圖1量測框";
                    this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.DrawFrame(HDC, ZoomX, ZoomY, 0, 0, 0x0000FF);

                    if (this.plC_CheckBox_CCD02_01_校正量測框_繪製量測區塊.Checked)
                    {
                        this.CCD02_01_AxObject_拼圖1校正量測框調整.DrawBlobs(HDC, -1, ZoomX, ZoomY, 0, 0, true, -1);

                    }
                    DrawingClass.Draw.十字中心(CCD02_01拼圖1校正點座標, 50, Color.Lime, 1, g, ZoomX, ZoomY);
                    g.Dispose();
                    g = null;
                }
            }
            catch
            {

            }

            this.PLC_Device_CCD02_01_拼圖1校正量測框調整_RefreshCanvas.Bool = false;
        }
        private void H_Canvas_Tech_CCD02_01_拼圖1校正量測框調整_OnCanvasMouseDownEvent(int x, int y, float ZoomX, float ZoomY, ref int InUsedEventNum, int InUsedCanvasHandle)
        {
            if (this.PLC_Device_CCD02_01_校正量測框調整.Bool)
            {
                this.CCD02_01_TxAxHitHandle_AxROIBW8_拼圖1校正量測框調整 = this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.HitTest(x, y, ZoomX, ZoomY, 0, 0);
                if (this.CCD02_01_TxAxHitHandle_AxROIBW8_拼圖1校正量測框調整 != AxOvkBase.TxAxHitHandle.AX_HANDLE_NONE)
                {
                    this.flag_CCD02_01_拼圖1校正量測框調整_AxROIBW8_MouseDown = true;
                    InUsedEventNum = 10;
                    return;
                }

            }

        }
        private void H_Canvas_Tech_CCD02_01_拼圖1校正量測框調整_OnCanvasMouseMoveEvent(int x, int y, float ZoomX, float ZoomY)
        {
            if (this.flag_CCD02_01_拼圖1校正量測框調整_AxROIBW8_MouseDown)
            {
                this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.DragROI(this.CCD02_01_TxAxHitHandle_AxROIBW8_拼圖1校正量測框調整, x, y, ZoomX, ZoomY, 0, 0);
                this.PLC_Device_CCD02_01_拼圖1校正量測框_OrgX.Value = this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.OrgX;
                this.PLC_Device_CCD02_01_拼圖1校正量測框_OrgY.Value = this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.OrgY;
                this.PLC_Device_CCD02_01_拼圖1校正量測框_Width.Value = this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.ROIWidth;
                this.PLC_Device_CCD02_01_拼圖1校正量測框_Height.Value = this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.ROIHeight;
            }

        }
        private void H_Canvas_Tech_CCD02_01_拼圖1校正量測框調整_OnCanvasMouseUpEvent(int x, int y, float ZoomX, float ZoomY)
        {
            this.flag_CCD02_01_拼圖1校正量測框調整_AxROIBW8_MouseDown = false;
        }

        private void H_Canvas_Tech_CCD02_01_拼圖2校正量測框調整_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            try
            {

                if (this.PLC_Device_CCD02_01_拼圖2校正量測框調整_RefreshCanvas.Bool)
                {

                    Graphics g = Graphics.FromHdc((IntPtr)HDC);

                    this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.ShowTitle = true;
                    this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.ShowPlacement = false;
                    this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.Title = "拼圖2量測框";
                    this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.DrawFrame(HDC, ZoomX, ZoomY, 0, 0, 0x0000FF);

                    if (this.plC_CheckBox_CCD02_01_校正量測框_繪製量測區塊.Checked)
                    {
                        this.CCD02_01_AxObject_拼圖2校正量測框調整.DrawBlobs(HDC, -1, ZoomX, ZoomY, 0, 0, true, -1);

                    }
                    DrawingClass.Draw.十字中心(CCD02_01拼圖2校正點座標, 50, Color.Lime, 1, g, ZoomX, ZoomY);
                    g.Dispose();
                    g = null;
                }
            }
            catch
            {

            }

            this.PLC_Device_CCD02_01_拼圖2校正量測框調整_RefreshCanvas.Bool = false;
        }
        private void H_Canvas_Tech_CCD02_01_拼圖2校正量測框調整_OnCanvasMouseDownEvent(int x, int y, float ZoomX, float ZoomY, ref int InUsedEventNum, int InUsedCanvasHandle)
        {
            if (this.PLC_Device_CCD02_01_校正量測框調整.Bool)
            {
                this.CCD02_01_TxAxHitHandle_AxROIBW8_拼圖2校正量測框調整 = this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.HitTest(x, y, ZoomX, ZoomY, 0, 0);
                if (this.CCD02_01_TxAxHitHandle_AxROIBW8_拼圖2校正量測框調整 != AxOvkBase.TxAxHitHandle.AX_HANDLE_NONE)
                {
                    this.flag_CCD02_01_拼圖2校正量測框調整_AxROIBW8_MouseDown = true;
                    InUsedEventNum = 10;
                    return;
                }

            }

        }
        private void H_Canvas_Tech_CCD02_01_拼圖2校正量測框調整_OnCanvasMouseMoveEvent(int x, int y, float ZoomX, float ZoomY)
        {
            if (this.flag_CCD02_01_拼圖2校正量測框調整_AxROIBW8_MouseDown)
            {
                this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.DragROI(this.CCD02_01_TxAxHitHandle_AxROIBW8_拼圖2校正量測框調整, x, y, ZoomX, ZoomY, 0, 0);
                this.PLC_Device_CCD02_01_拼圖2校正量測框_OrgX.Value = this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.OrgX;
                this.PLC_Device_CCD02_01_拼圖2校正量測框_OrgY.Value = this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.OrgY;
                this.PLC_Device_CCD02_01_拼圖2校正量測框_Width.Value = this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.ROIWidth;
                this.PLC_Device_CCD02_01_拼圖2校正量測框_Height.Value = this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.ROIHeight;
            }

        }
        private void H_Canvas_Tech_CCD02_01_拼圖2校正量測框調整_OnCanvasMouseUpEvent(int x, int y, float ZoomX, float ZoomY)
        {
            this.flag_CCD02_01_拼圖2校正量測框調整_AxROIBW8_MouseDown = false;
        }
        int cnt_Program_CCD02_01_校正量測框 = 65534;
        void sub_Program_CCD02_01_校正量測框()
        {
            if (cnt_Program_CCD02_01_校正量測框 == 65534)
            {
                

                this.h_Canvas_Tech_CCD02_01_拼接圖1.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_01_拼圖1校正量測框調整_OnCanvasDrawEvent;
                this.h_Canvas_Tech_CCD02_01_拼接圖1.OnCanvasMouseDownEvent += H_Canvas_Tech_CCD02_01_拼圖1校正量測框調整_OnCanvasMouseDownEvent;
                this.h_Canvas_Tech_CCD02_01_拼接圖1.OnCanvasMouseMoveEvent += H_Canvas_Tech_CCD02_01_拼圖1校正量測框調整_OnCanvasMouseMoveEvent;
                this.h_Canvas_Tech_CCD02_01_拼接圖1.OnCanvasMouseUpEvent += H_Canvas_Tech_CCD02_01_拼圖1校正量測框調整_OnCanvasMouseUpEvent;

                this.h_Canvas_Tech_CCD02_01_拼接圖2.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_01_拼圖2校正量測框調整_OnCanvasDrawEvent;
                this.h_Canvas_Tech_CCD02_01_拼接圖2.OnCanvasMouseDownEvent += H_Canvas_Tech_CCD02_01_拼圖2校正量測框調整_OnCanvasMouseDownEvent;
                this.h_Canvas_Tech_CCD02_01_拼接圖2.OnCanvasMouseMoveEvent += H_Canvas_Tech_CCD02_01_拼圖2校正量測框調整_OnCanvasMouseMoveEvent;
                this.h_Canvas_Tech_CCD02_01_拼接圖2.OnCanvasMouseUpEvent += H_Canvas_Tech_CCD02_01_拼圖2校正量測框調整_OnCanvasMouseUpEvent;


                if (PLC_Device_CCD02_01_拼圖1校正量測框_OrgX.Value <= 0) PLC_Device_CCD02_01_拼圖1校正量測框_OrgX.Value = 20;
                if (PLC_Device_CCD02_01_拼圖1校正量測框_OrgY.Value <= 0) PLC_Device_CCD02_01_拼圖1校正量測框_OrgY.Value = 20;
                if (PLC_Device_CCD02_01_拼圖1校正量測框_Width.Value <= 0) PLC_Device_CCD02_01_拼圖1校正量測框_Width.Value = 20;
                if (PLC_Device_CCD02_01_拼圖1校正量測框_Height.Value <= 0) PLC_Device_CCD02_01_拼圖1校正量測框_Height.Value = 20;
                if (PLC_Device_CCD02_01_拼圖2校正量測框_OrgX.Value <= 0) PLC_Device_CCD02_01_拼圖2校正量測框_OrgX.Value = 20;
                if (PLC_Device_CCD02_01_拼圖2校正量測框_OrgY.Value <= 0) PLC_Device_CCD02_01_拼圖2校正量測框_OrgY.Value = 20;
                if (PLC_Device_CCD02_01_拼圖2校正量測框_Width.Value <= 0) PLC_Device_CCD02_01_拼圖2校正量測框_Width.Value = 20;
                if (PLC_Device_CCD02_01_拼圖2校正量測框_Height.Value <= 0) PLC_Device_CCD02_01_拼圖2校正量測框_Height.Value = 20;

                PLC_Device_CCD02_01_校正量測框調整.SetComment("PLC_CCD02_01_校正量測框");
                PLC_Device_CCD02_01_校正量測框調整.Bool = false;
                cnt_Program_CCD02_01_校正量測框 = 65535;
            }
            if (cnt_Program_CCD02_01_校正量測框 == 65535) cnt_Program_CCD02_01_校正量測框 = 1;
            if (cnt_Program_CCD02_01_校正量測框 == 1) cnt_Program_CCD02_01_校正量測框_檢查按下(ref cnt_Program_CCD02_01_校正量測框);
            if (cnt_Program_CCD02_01_校正量測框 == 2) cnt_Program_CCD02_01_校正量測框_初始化(ref cnt_Program_CCD02_01_校正量測框);
            if (cnt_Program_CCD02_01_校正量測框 == 3) cnt_Program_CCD02_01_校正量測框_區塊分析(ref cnt_Program_CCD02_01_校正量測框);
            if (cnt_Program_CCD02_01_校正量測框 == 4) cnt_Program_CCD02_01_校正量測框_繪製影像(ref cnt_Program_CCD02_01_校正量測框);
            if (cnt_Program_CCD02_01_校正量測框 == 5) cnt_Program_CCD02_01_校正量測框 = 65500;
            if (cnt_Program_CCD02_01_校正量測框 > 1) cnt_Program_CCD02_01_校正量測框_檢查放開(ref cnt_Program_CCD02_01_校正量測框);
            if (cnt_Program_CCD02_01_校正量測框 == 65500)
            {
                //PLC_Device_CCD02_01_校正量測框調整.Bool = false;
                cnt_Program_CCD02_01_校正量測框 = 65535;
            }
        }
        void cnt_Program_CCD02_01_校正量測框_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_01_校正量測框調整.Bool) cnt++;
        }
        void cnt_Program_CCD02_01_校正量測框_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_01_校正量測框調整.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_01_校正量測框_初始化(ref int cnt)
        {


            this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.ParentHandle = this.CCD02_01_SrcImageHandle_拼接圖1;
            this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.OrgX = this.PLC_Device_CCD02_01_拼圖1校正量測框_OrgX.Value;
            this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.OrgY = this.PLC_Device_CCD02_01_拼圖1校正量測框_OrgY.Value;
            this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.ROIWidth = this.PLC_Device_CCD02_01_拼圖1校正量測框_Width.Value;
            this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.ROIHeight = this.PLC_Device_CCD02_01_拼圖1校正量測框_Height.Value;
            this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.SkewAngle = 0;

            this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.ParentHandle = this.CCD02_01_SrcImageHandle_拼接圖2;
            this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.OrgX = this.PLC_Device_CCD02_01_拼圖2校正量測框_OrgX.Value;
            this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.OrgY = this.PLC_Device_CCD02_01_拼圖2校正量測框_OrgY.Value;
            this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.ROIWidth = this.PLC_Device_CCD02_01_拼圖2校正量測框_Width.Value;
            this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.ROIHeight = this.PLC_Device_CCD02_01_拼圖2校正量測框_Height.Value;
            this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.SkewAngle = 0;
            cnt++;
        }
        void cnt_Program_CCD02_01_校正量測框_區塊分析(ref int cnt)
        {
            uint 區塊特徵總和 = 4294951423;
            this.CCD02_01_AxObject_拼圖1校正量測框調整.SrcImageHandle = this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.VegaHandle;

            this.CCD02_01_AxObject_拼圖1校正量測框調整.ObjectClass = AxOvkBlob.TxAxObjClass.AX_OBJECT_DETECT_LIGHTER_CLASS;
            this.CCD02_01_AxObject_拼圖1校正量測框調整.HighThreshold = PLC_Device_CCD02_01_校正量測框_灰階門檻值.Value;
            this.CCD02_01_AxObject_拼圖1校正量測框調整.BlobAnalyze(true);
            this.CCD02_01_AxObject_拼圖1校正量測框調整.CalculateFeatures((int)區塊特徵總和, -1);
            this.CCD02_01_AxObject_拼圖1校正量測框調整.SortObjects(AxOvkBlob.TxAxObjFeatureSortOrder.AX_OBJECT_SORT_ORDER_LARGE_TO_SMALL, AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, 0, -1);
            this.CCD02_01_AxObject_拼圖1校正量測框調整.SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_LESS_THAN, this.PLC_Device_CCD02_01_校正量測框_面積下限.Value);
            this.CCD02_01_AxObject_拼圖1校正量測框調整.SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_GREAT_THAN, this.PLC_Device_CCD02_01_校正量測框_面積上限.Value);
            if (this.CCD02_01_AxObject_拼圖1校正量測框調整.DetectedNumObjs > 0)
            {
                this.CCD02_01_AxObject_拼圖1校正量測框調整.BlobIndex = 0;
                int 拼圖1_X0 = this.CCD02_01_AxObject_拼圖1校正量測框調整.BlobLimBoxX;
                int 拼圖1_Y0 = this.CCD02_01_AxObject_拼圖1校正量測框調整.BlobLimBoxY;
                float 拼圖1_X1 = this.CCD02_01_AxObject_拼圖1校正量測框調整.BlobCentroidX;
                float 拼圖1_Y1 = this.CCD02_01_AxObject_拼圖1校正量測框調整.BlobCentroidY;

                this.CCD02_01拼圖1校正點座標.X = 拼圖1_X1;
                this.CCD02_01拼圖1校正點座標.X += this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.OrgX;
                this.CCD02_01拼圖1校正點座標.Y = 拼圖1_Y1;
                this.CCD02_01拼圖1校正點座標.Y += this.CCD02_01_AxROIBW8_拼圖1校正量測框調整.OrgY;
                this.PLC_Device_CCD02_01_校正量測框_拼圖1座標X.Value = (int)(CCD02_01拼圖1校正點座標.X * 1000);
                this.PLC_Device_CCD02_01_校正量測框_拼圖1座標Y.Value = (int)(CCD02_01拼圖1校正點座標.Y * 1000);

            }

            this.CCD02_01_AxObject_拼圖2校正量測框調整.SrcImageHandle = this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.VegaHandle;

            this.CCD02_01_AxObject_拼圖2校正量測框調整.ObjectClass = AxOvkBlob.TxAxObjClass.AX_OBJECT_DETECT_LIGHTER_CLASS;
            this.CCD02_01_AxObject_拼圖2校正量測框調整.HighThreshold = PLC_Device_CCD02_01_校正量測框_灰階門檻值.Value;
            this.CCD02_01_AxObject_拼圖2校正量測框調整.BlobAnalyze(true);
            this.CCD02_01_AxObject_拼圖2校正量測框調整.CalculateFeatures((int)區塊特徵總和, -1);
            this.CCD02_01_AxObject_拼圖2校正量測框調整.SortObjects(AxOvkBlob.TxAxObjFeatureSortOrder.AX_OBJECT_SORT_ORDER_LARGE_TO_SMALL, AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, 0, -1);
            this.CCD02_01_AxObject_拼圖2校正量測框調整.SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_LESS_THAN, this.PLC_Device_CCD02_01_校正量測框_面積下限.Value);
            this.CCD02_01_AxObject_拼圖2校正量測框調整.SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_GREAT_THAN, this.PLC_Device_CCD02_01_校正量測框_面積上限.Value);
            if (this.CCD02_01_AxObject_拼圖2校正量測框調整.DetectedNumObjs > 0)
            {
                this.CCD02_01_AxObject_拼圖2校正量測框調整.BlobIndex = 0;
                int 拼圖2_X0 = this.CCD02_01_AxObject_拼圖2校正量測框調整.BlobLimBoxX;
                int 拼圖2_Y0 = this.CCD02_01_AxObject_拼圖2校正量測框調整.BlobLimBoxY;
                float 拼圖2_X1 = this.CCD02_01_AxObject_拼圖2校正量測框調整.BlobCentroidX;
                float 拼圖2_Y1 = this.CCD02_01_AxObject_拼圖2校正量測框調整.BlobCentroidY;

                this.CCD02_01拼圖2校正點座標.X = 拼圖2_X1;
                this.CCD02_01拼圖2校正點座標.X += this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.OrgX;
                this.CCD02_01拼圖2校正點座標.Y = 拼圖2_Y1;
                this.CCD02_01拼圖2校正點座標.Y += this.CCD02_01_AxROIBW8_拼圖2校正量測框調整.OrgY;
                this.PLC_Device_CCD02_01_校正量測框_拼圖2座標X.Value = (int)(CCD02_01拼圖2校正點座標.X * 1000);
                this.PLC_Device_CCD02_01_校正量測框_拼圖2座標Y.Value = (int)(CCD02_01拼圖2校正點座標.Y * 1000);

            }

            cnt++;


        }
        void cnt_Program_CCD02_01_校正量測框_繪製影像(ref int cnt)
        {
            this.PLC_Device_CCD02_01_拼圖1校正量測框調整_RefreshCanvas.Bool = true;
            this.PLC_Device_CCD02_01_拼圖2校正量測框調整_RefreshCanvas.Bool = true;
            if (PLC_Device_CCD02_01_校正量測框調整_按鈕.Bool)
            {                
                this.h_Canvas_Tech_CCD02_01_拼接圖1.RefreshCanvas();
                this.h_Canvas_Tech_CCD02_01_拼接圖2.RefreshCanvas();
            }

            cnt++;
        }





        #endregion

        #region PLC_CCD02_01_Main_取像並檢驗
        PLC_Device PLC_Device_CCD02_01_Main_取像並檢驗 = new PLC_Device("S39920");
        PLC_Device PLC_Device_CCD02_01_PLC觸發檢測 = new PLC_Device("S39720");
        MyTimer CCD02_01_Init_Timer = new MyTimer();
        int cnt_Program_CCD02_01_Main_取像並檢驗 = 65534;
        void sub_Program_CCD02_01_Main_取像並檢驗()
        {
            if (cnt_Program_CCD02_01_Main_取像並檢驗 == 65534)
            {
                PLC_Device_CCD02_01_Main_取像並檢驗.SetComment("PLC_CCD02_01_Main_取像並檢驗");
                PLC_Device_CCD02_01_Main_取像並檢驗.Bool = false;
                PLC_Device_CCD02_01_PLC觸發檢測.Bool = false;

            }
            if (cnt_Program_CCD02_01_Main_取像並檢驗 == 65535) cnt_Program_CCD02_01_Main_取像並檢驗 = 1;
            if (cnt_Program_CCD02_01_Main_取像並檢驗 == 1) cnt_Program_CCD02_01_Main_取像並檢驗_檢查按下(ref cnt_Program_CCD02_01_Main_取像並檢驗);
            if (cnt_Program_CCD02_01_Main_取像並檢驗 == 2) cnt_Program_CCD02_01_Main_取像並檢驗_初始化(ref cnt_Program_CCD02_01_Main_取像並檢驗);
            if (cnt_Program_CCD02_01_Main_取像並檢驗 == 3) cnt_Program_CCD02_01_Main_取像並檢驗_開始SNAP(ref cnt_Program_CCD02_01_Main_取像並檢驗);
            if (cnt_Program_CCD02_01_Main_取像並檢驗 == 4) cnt_Program_CCD02_01_Main_取像並檢驗_結束SNAP(ref cnt_Program_CCD02_01_Main_取像並檢驗);
            if (cnt_Program_CCD02_01_Main_取像並檢驗 == 5) cnt_Program_CCD02_01_Main_取像並檢驗_開始計算一次(ref cnt_Program_CCD02_01_Main_取像並檢驗);
            if (cnt_Program_CCD02_01_Main_取像並檢驗 == 6) cnt_Program_CCD02_01_Main_取像並檢驗_結束計算一次(ref cnt_Program_CCD02_01_Main_取像並檢驗);
            if (cnt_Program_CCD02_01_Main_取像並檢驗 == 7) cnt_Program_CCD02_01_Main_取像並檢驗_繪製畫布(ref cnt_Program_CCD02_01_Main_取像並檢驗);
            if (cnt_Program_CCD02_01_Main_取像並檢驗 == 8) cnt_Program_CCD02_01_Main_取像並檢驗_檢查重測次數(ref cnt_Program_CCD02_01_Main_取像並檢驗);
            if (cnt_Program_CCD02_01_Main_取像並檢驗 == 9) cnt_Program_CCD02_01_Main_取像並檢驗 = 65500;
            if (cnt_Program_CCD02_01_Main_取像並檢驗 > 1) cnt_Program_CCD02_01_Main_取像並檢驗_檢查放開(ref cnt_Program_CCD02_01_Main_取像並檢驗);

            if (cnt_Program_CCD02_01_Main_取像並檢驗 == 65500)
            {
                PLC_Device_CCD02_01_Main_取像並檢驗.Bool = false;
                PLC_Device_CCD02_01_PLC觸發檢測.Bool = false;
                cnt_Program_CCD02_01_Main_取像並檢驗 = 65535;
            }
        }
        void cnt_Program_CCD02_01_Main_取像並檢驗_檢查按下(ref int cnt)
        {

            if (PLC_Device_CCD02_01_Main_取像並檢驗.Bool && !PLC_Device_CCD02_01_PLC觸發檢測.Bool)
            {

                cnt++;
            }

            else if (PLC_Device_CCD02_01_PLC觸發檢測.Bool)
            {

                cnt++;
            }



        }
        void cnt_Program_CCD02_01_Main_取像並檢驗_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_01_Main_取像並檢驗.Bool && !PLC_Device_CCD02_01_PLC觸發檢測.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_01_Main_取像並檢驗_初始化(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD02_01_Main_取像並檢驗_開始SNAP(ref int cnt)
        {
            cnt++;

        }
        void cnt_Program_CCD02_01_Main_取像並檢驗_結束SNAP(ref int cnt)
        {
            this.h_Canvas_Main_CCD02_01_檢測畫面.ImageCopy(h_Canvas_Tech_CCD02_01_拼接完成圖.VegaHandle);
            cnt++;

        }
        void cnt_Program_CCD02_01_Main_取像並檢驗_開始計算一次(ref int cnt)
        {
            if (!this.PLC_Device_CCD02_01_計算一次.Bool)
            {
                this.PLC_Device_CCD02_01_計算一次.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD02_01_Main_取像並檢驗_結束計算一次(ref int cnt)
        {
            if (!this.PLC_Device_CCD02_01_計算一次.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD02_01_Main_取像並檢驗_繪製畫布(ref int cnt)
        {
            if (CCD02_01_SrcImageHandle_拼接完成圖 != 0)
            {
                this.h_Canvas_Main_CCD02_01_檢測畫面.RefreshCanvas();
            }
            cnt++;
        }
        void cnt_Program_CCD02_01_Main_取像並檢驗_檢查重測次數(ref int cnt)
        {
            cnt++;
        }





        #endregion
        #region PLC_CCD02_01_Tech_檢驗一次
        PLC_Device PLC_Device_CCD02_01_Tech_檢驗一次 = new PLC_Device("S15145");
        int cnt_Program_CCD02_01_Tech_檢驗一次 = 65534;
        void sub_Program_CCD02_01_Tech_檢驗一次()
        {
            if (cnt_Program_CCD02_01_Tech_檢驗一次 == 65534)
            {
                PLC_Device_CCD02_01_Tech_檢驗一次.SetComment("PLC_CCD02_01_Tech_檢驗一次");
                PLC_Device_CCD02_01_Tech_檢驗一次.Bool = false;
                cnt_Program_CCD02_01_Tech_檢驗一次 = 65535;
            }
            if (cnt_Program_CCD02_01_Tech_檢驗一次 == 65535) cnt_Program_CCD02_01_Tech_檢驗一次 = 1;
            if (cnt_Program_CCD02_01_Tech_檢驗一次 == 1) cnt_Program_CCD02_01_Tech_檢驗一次_檢查按下(ref cnt_Program_CCD02_01_Tech_檢驗一次);
            if (cnt_Program_CCD02_01_Tech_檢驗一次 == 2) cnt_Program_CCD02_01_Tech_檢驗一次_初始化(ref cnt_Program_CCD02_01_Tech_檢驗一次);
            if (cnt_Program_CCD02_01_Tech_檢驗一次 == 3) cnt_Program_CCD02_01_Tech_檢驗一次_計算一次開始(ref cnt_Program_CCD02_01_Tech_檢驗一次);
            if (cnt_Program_CCD02_01_Tech_檢驗一次 == 4) cnt_Program_CCD02_01_Tech_檢驗一次_計算一次結束(ref cnt_Program_CCD02_01_Tech_檢驗一次);
            if (cnt_Program_CCD02_01_Tech_檢驗一次 == 5) cnt_Program_CCD02_01_Tech_檢驗一次_繪製畫布(ref cnt_Program_CCD02_01_Tech_檢驗一次);
            if (cnt_Program_CCD02_01_Tech_檢驗一次 == 6) cnt_Program_CCD02_01_Tech_檢驗一次 = 65500;
            if (cnt_Program_CCD02_01_Tech_檢驗一次 > 1) cnt_Program_CCD02_01_Tech_檢驗一次_檢查放開(ref cnt_Program_CCD02_01_Tech_檢驗一次);

            if (cnt_Program_CCD02_01_Tech_檢驗一次 == 65500)
            {
                PLC_Device_CCD02_01_Tech_檢驗一次.Bool = false;
                cnt_Program_CCD02_01_Tech_檢驗一次 = 65535;
            }
        }
        void cnt_Program_CCD02_01_Tech_檢驗一次_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_01_Tech_檢驗一次.Bool) cnt++;
        }
        void cnt_Program_CCD02_01_Tech_檢驗一次_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_01_Tech_檢驗一次.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_01_Tech_檢驗一次_初始化(ref int cnt)
        {

            cnt++;
        }
        void cnt_Program_CCD02_01_Tech_檢驗一次_計算一次開始(ref int cnt)
        {
            if (!this.PLC_Device_CCD02_01_計算一次.Bool)
            {
                this.PLC_Device_CCD02_01_計算一次.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD02_01_Tech_檢驗一次_計算一次結束(ref int cnt)
        {
            if (!this.PLC_Device_CCD02_01_計算一次.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD02_01_Tech_檢驗一次_繪製畫布(ref int cnt)
        {
            if (CCD02_01_SrcImageHandle_拼接完成圖 != 0)
            {
                this.h_Canvas_Tech_CCD02_01_拼接完成圖.RefreshCanvas();
            }
            cnt++;
        }

































        #endregion
        #region PLC_CCD02_01_計算一次
        PLC_Device PLC_Device_CCD02_01_計算一次 = new PLC_Device("S5015");
        PLC_Device PLC_Device_CCD02_01_計算一次_OK = new PLC_Device("S5016");
        PLC_Device PLC_Device_CCD02_01_計算一次_READY = new PLC_Device("S5017");
        MyTimer MyTimer_CCD02_01_計算一次 = new MyTimer();
   
        int cnt_Program_CCD02_01_計算一次 = 65534;
        void sub_Program_CCD02_01_計算一次()
        {
            this.PLC_Device_CCD02_01_計算一次_READY.Bool = !this.PLC_Device_CCD02_01_計算一次.Bool;
            if (cnt_Program_CCD02_01_計算一次 == 65534)
            {
                PLC_Device_CCD02_01_計算一次.SetComment("PLC_CCD02_01_計算一次");
                PLC_Device_CCD02_01_計算一次.Bool = false;

                cnt_Program_CCD02_01_計算一次 = 65535;
            }
            if (cnt_Program_CCD02_01_計算一次 == 65535) cnt_Program_CCD02_01_計算一次 = 1;
            if (cnt_Program_CCD02_01_計算一次 == 1) cnt_Program_CCD02_01_計算一次_檢查按下(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 2) cnt_Program_CCD02_01_計算一次_步驟01開始(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 3) cnt_Program_CCD02_01_計算一次_步驟01結束(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 4) cnt_Program_CCD02_01_計算一次_步驟02開始(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 5) cnt_Program_CCD02_01_計算一次_步驟02結束(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 6) cnt_Program_CCD02_01_計算一次_步驟03開始(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 7) cnt_Program_CCD02_01_計算一次_步驟03結束(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 8) cnt_Program_CCD02_01_計算一次_步驟04開始(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 9) cnt_Program_CCD02_01_計算一次_步驟04結束(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 10) cnt_Program_CCD02_01_計算一次_步驟05開始(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 11) cnt_Program_CCD02_01_計算一次_步驟05結束(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 12) cnt_Program_CCD02_01_計算一次_步驟06開始(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 13) cnt_Program_CCD02_01_計算一次_步驟06結束(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 14) cnt_Program_CCD02_01_計算一次_計算結果(ref cnt_Program_CCD02_01_計算一次);
            if (cnt_Program_CCD02_01_計算一次 == 15) cnt_Program_CCD02_01_計算一次 = 65500;
            if (cnt_Program_CCD02_01_計算一次 > 1) cnt_Program_CCD02_01_計算一次_檢查放開(ref cnt_Program_CCD02_01_計算一次);

            if (cnt_Program_CCD02_01_計算一次 == 65500)
            {
                PLC_Device_CCD02_01_計算一次.Bool = false;
                cnt_Program_CCD02_01_計算一次 = 65535;
            }
        }
        void cnt_Program_CCD02_01_計算一次_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_01_計算一次.Bool) cnt++;
        }
        void cnt_Program_CCD02_01_計算一次_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_01_計算一次.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_01_計算一次_初始化(ref int cnt)
        {
            PLC_Device_CCD02_01_基準線量測.Bool = false;
            cnt++;
        }
        void cnt_Program_CCD02_01_計算一次_步驟01開始(ref int cnt)
        {
            this.MyTimer_CCD02_01_計算一次.TickStop();
            GetTickTime = this.MyTimer_CCD02_01_計算一次.GetTickTime();
            this.MyTimer_CCD02_01_計算一次.StartTickTime(99999);

            if (!this.PLC_Device_CCD02_01_基準線量測.Bool)
            {
                this.PLC_Device_CCD02_01_基準線量測.Bool = true;
                cnt++;
            }

        }
        void cnt_Program_CCD02_01_計算一次_步驟01結束(ref int cnt)
        {
            if (!this.PLC_Device_CCD02_01_基準線量測.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD02_01_計算一次_步驟02開始(ref int cnt)
        {

                cnt++;
            

        }
        void cnt_Program_CCD02_01_計算一次_步驟02結束(ref int cnt)
        {

                cnt++;
            
        }
        void cnt_Program_CCD02_01_計算一次_步驟03開始(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD02_01_計算一次_步驟03結束(ref int cnt)
        {

                cnt++;
            

        }
        void cnt_Program_CCD02_01_計算一次_步驟04開始(ref int cnt)
        {

            cnt++;
        }
        void cnt_Program_CCD02_01_計算一次_步驟04結束(ref int cnt)
        {

                cnt++;
            
        }
        void cnt_Program_CCD02_01_計算一次_步驟05開始(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD02_01_計算一次_步驟05結束(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD02_01_計算一次_步驟06開始(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD02_01_計算一次_步驟06結束(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD02_01_計算一次_計算結果(ref int cnt)
        {
            bool flag = true;
            if (!this.PLC_Device_CCD02_01_基準線量測_OK.Bool) flag = false;


            this.PLC_Device_CCD02_01_計算一次_OK.Bool = flag;
            //flag_CCD02_01_上端水平度寫入列表資料 = true;
            //flag_CCD02_01_上端間距寫入列表資料 = true;
            //flag_CCD02_01_上端水平度差值寫入列表資料 = true;

            cnt++;
        }





        #endregion
        #region PLC_CCD02_01_基準線量測
        AxOvkMsr.AxLineMsr CCD02_01_水平基準線量測_AxLineMsr;
        AxOvkMsr.AxLineRegression CCD02_01_水平基準線量測_AxLineRegression;
        AxOvkMsr.AxLineMsr CCD02_01_垂直基準線量測_AxLineMsr;
        AxOvkMsr.AxLineRegression CCD02_01_垂直基準線量測_AxLineRegression;
        AxOvkMsr.AxIntersectionMsr CCD02_01_基準線量測_AxIntersectionMsr;
        private PointF Point_CCD02_01_中心基準座標_量測點 = new PointF();
        PLC_Device PLC_Device_CCD02_01_基準線量測按鈕 = new PLC_Device("S6250");
        PLC_Device PLC_Device_CCD02_01_基準線量測 = new PLC_Device("S6245");
        PLC_Device PLC_Device_CCD02_01_基準線量測_OK = new PLC_Device("S6246");
        PLC_Device PLC_Device_CCD02_01_基準線量測_測試完成 = new PLC_Device("S6247");
        PLC_Device PLC_Device_CCD02_01_基準線量測_RefreshCanvas = new PLC_Device("S6248");

        PLC_Device PLC_Device_CCD02_01_基準線量測_變化銳利度 = new PLC_Device("F18200");
        PLC_Device PLC_Device_CCD02_01_基準線量測_延伸變化強度 = new PLC_Device("F18201");
        PLC_Device PLC_Device_CCD02_01_基準線量測_灰階變化面積 = new PLC_Device("F18202");
        PLC_Device PLC_Device_CCD02_01_基準線量測_雜訊抑制 = new PLC_Device("F18203");
        PLC_Device PLC_Device_CCD02_01_基準線量測_最佳回歸線計算次數 = new PLC_Device("F18204");
        PLC_Device PLC_Device_CCD02_01_基準線量測_最佳回歸線濾波 = new PLC_Device("F18205");
        PLC_Device PLC_Device_CCD02_01_基準線量測_量測顏色變化 = new PLC_Device("F18210");
        PLC_Device PLC_Device_CCD02_01_基準線量測_基準線偏移 = new PLC_Device("F18211");

        PLC_Device PLC_Device_CCD02_01_水平基準線量測_量測框起點X座標 = new PLC_Device("F18206");
        PLC_Device PLC_Device_CCD02_01_水平基準線量測_量測框起點Y座標 = new PLC_Device("F18207");
        PLC_Device PLC_Device_CCD02_01_水平基準線量測_量測框終點X座標 = new PLC_Device("F18208");
        PLC_Device PLC_Device_CCD02_01_水平基準線量測_量測框終點Y座標 = new PLC_Device("F18209");
        PLC_Device PLC_Device_CCD02_01_水平基準線量測_量測高度 = new PLC_Device("F18212");
        PLC_Device PLC_Device_CCD02_01_水平基準線量測_量測中心_X = new PLC_Device("F18220");
        PLC_Device PLC_Device_CCD02_01_水平基準線量測_量測中心_Y = new PLC_Device("F18221");

        PLC_Device PLC_Device_CCD02_01_垂直基準線量測_量測框起點X座標 = new PLC_Device("F18213");
        PLC_Device PLC_Device_CCD02_01_垂直基準線量測_量測框起點Y座標 = new PLC_Device("F18214");
        PLC_Device PLC_Device_CCD02_01_垂直基準線量測_量測框終點X座標 = new PLC_Device("F18215");
        PLC_Device PLC_Device_CCD02_01_垂直基準線量測_量測框終點Y座標 = new PLC_Device("F18216");
        PLC_Device PLC_Device_CCD02_01_垂直基準線量測_量測高度 = new PLC_Device("F18217");




        private void H_Canvas_Tech_CCD02_01_基準線量測_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            try
            {
                PointF 水平量測中心 = new PointF(Point_CCD02_01_中心基準座標_量測點.X, Point_CCD02_01_中心基準座標_量測點.Y);

                if (PLC_Device_CCD02_01_Main_取像並檢驗.Bool || PLC_Device_CCD02_01_PLC觸發檢測.Bool)
                {
                    if (this.PLC_Device_CCD02_01_基準線量測_RefreshCanvas.Bool)
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);

                        DrawingClass.Draw.水平線段繪製(0, 10000, CCD02_01_水平基準線量測_AxLineMsr.MeasuredSlope, CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotX, CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotY + this.PLC_Device_CCD02_01_基準線量測_基準線偏移.Value, Color.Lime, 2, g, ZoomX, ZoomY);
                        DrawingClass.Draw.垂直線段繪製(0, 10000, CCD02_01_垂直基準線量測_AxLineMsr.MeasuredSlope, CCD02_01_垂直基準線量測_AxLineMsr.MeasuredPivotX, CCD02_01_垂直基準線量測_AxLineMsr.MeasuredPivotY, Color.Lime, 2, g, ZoomX, ZoomY);
                        DrawingClass.Draw.十字中心(水平量測中心, 100, Color.Red, 2, g, ZoomX, ZoomY);
                        g.Dispose();
                        g = null;
                    }
                }
                else if (PLC_Device_CCD02_01_Tech_檢驗一次.Bool)
                {
                    if (this.PLC_Device_CCD02_01_基準線量測_RefreshCanvas.Bool)
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);

                        DrawingClass.Draw.水平線段繪製(0, 10000, CCD02_01_水平基準線量測_AxLineMsr.MeasuredSlope, CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotX, CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotY + this.PLC_Device_CCD02_01_基準線量測_基準線偏移.Value, Color.Lime, 2, g, ZoomX, ZoomY);
                        DrawingClass.Draw.垂直線段繪製(0, 10000, CCD02_01_垂直基準線量測_AxLineMsr.MeasuredSlope, CCD02_01_垂直基準線量測_AxLineMsr.MeasuredPivotX, CCD02_01_垂直基準線量測_AxLineMsr.MeasuredPivotY, Color.Lime, 2, g, ZoomX, ZoomY);
                        DrawingClass.Draw.十字中心(水平量測中心, 100, Color.Red, 2, g, ZoomX, ZoomY);
                        if (PLC_Device_CCD02_01_基準線量測_OK.Bool)
                        {
                            DrawingClass.Draw.文字左上繪製("基準線OK!", new PointF(0, 0), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                        }
                        else
                        {
                            DrawingClass.Draw.文字左上繪製("基準線NG!", new PointF(0, 0), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                        }
                        g.Dispose();
                        g = null;
                    }
                }

                else
                {
                    if (this.PLC_Device_CCD02_01_基準線量測_RefreshCanvas.Bool)
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);


                        if (this.plC_CheckBox_CCD02_01_基準線量測_繪製量測框.Checked)
                        {
                            this.CCD02_01_水平基準線量測_AxLineMsr.Title = ("水平基準線");
                            this.CCD02_01_水平基準線量測_AxLineMsr.DrawFrame(HDC, ZoomX, ZoomY, 0, 0);
                            this.CCD02_01_垂直基準線量測_AxLineMsr.Title = ("垂直基準線");
                            this.CCD02_01_垂直基準線量測_AxLineMsr.DrawFrame(HDC, ZoomX, ZoomY, 0, 0);
                        }
                        if (this.plC_CheckBox_CCD02_01_基準線量測_繪製量測線段.Checked)
                        {
                            this.CCD02_01_水平基準線量測_AxLineMsr.DrawFittedPrimitives(HDC, ZoomX, ZoomY, 0, 0);
                            this.CCD02_01_垂直基準線量測_AxLineMsr.DrawFittedPrimitives(HDC, ZoomX, ZoomY, 0, 0);
                            //DrawingClass.Draw.水平線段繪製(0, 10000, CCD02_01_水平基準線量測_AxLineMsr.MeasuredSlope, CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotX, CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotY + this.PLC_Device_CCD02_01_基準線量測_基準線偏移.Value, Color.Yellow, 2, g, ZoomX, ZoomY);
                            //DrawingClass.Draw.垂直線段繪製(0, 10000, CCD02_01_垂直基準線量測_AxLineMsr.MeasuredSlope, CCD02_01_垂直基準線量測_AxLineMsr.MeasuredPivotX, CCD02_01_垂直基準線量測_AxLineMsr.MeasuredPivotY + this.PLC_Device_CCD02_01_基準線量測_基準線偏移.Value, Color.Yellow, 2, g, ZoomX, ZoomY);
                        }
                        if (this.plC_CheckBox_CCD02_01_基準線量測_繪製量測點.Checked)
                        {
                            this.CCD02_01_水平基準線量測_AxLineMsr.DrawPoints(HDC, ZoomX, ZoomY, 0, 0);
                            this.CCD02_01_垂直基準線量測_AxLineMsr.DrawPoints(HDC, ZoomX, ZoomY, 0, 0);
                        }
                        DrawingClass.Draw.十字中心(水平量測中心, 100, Color.Red, 2, g, ZoomX, ZoomY);


                        if (PLC_Device_CCD02_01_基準線量測_OK.Bool)
                        {
                            DrawingClass.Draw.文字左上繪製("基準線OK!", new PointF(0, 0), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                        }
                        else
                        {
                            DrawingClass.Draw.文字左上繪製("基準線NG!", new PointF(0, 0), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                        }
                        g.Dispose();
                        g = null;
                    }
                }

            }

            catch
            {

            }

            this.PLC_Device_CCD02_01_基準線量測_RefreshCanvas.Bool = false;
        }
        private AxOvkMsr.TxAxLineMsrDragHandle CCD02_01_AxOvkMsr_水平基準線量測_TxAxLineMsrDragHandle = new AxOvkMsr.TxAxLineMsrDragHandle();
        private bool flag_CCD02_01_AxOvkMsr_水平基準線量測_MouseDown = false;
        private AxOvkMsr.TxAxLineMsrDragHandle CCD02_01_AxOvkMsr_垂直基準線量測_TxAxLineMsrDragHandle = new AxOvkMsr.TxAxLineMsrDragHandle();
        private bool flag_CCD02_01_AxOvkMsr_垂直基準線量測_MouseDown = false;

        private void H_Canvas_Tech_CCD02_01_基準線量測_OnCanvasMouseDownEvent(int x, int y, float ZoomX, float ZoomY, ref int InUsedEventNum, int InUsedCanvasHandle)
        {

            if (this.PLC_Device_CCD02_01_基準線量測.Bool)
            {
                this.CCD02_01_AxOvkMsr_水平基準線量測_TxAxLineMsrDragHandle = this.CCD02_01_水平基準線量測_AxLineMsr.HitTest(x, y, ZoomX, ZoomY, 0, 0);
                if (this.CCD02_01_AxOvkMsr_水平基準線量測_TxAxLineMsrDragHandle != AxOvkMsr.TxAxLineMsrDragHandle.AX_LINEMSR_NONE)
                {
                    this.flag_CCD02_01_AxOvkMsr_水平基準線量測_MouseDown = true;
                    InUsedEventNum = 10;
                }

                this.CCD02_01_AxOvkMsr_垂直基準線量測_TxAxLineMsrDragHandle = this.CCD02_01_垂直基準線量測_AxLineMsr.HitTest(x, y, ZoomX, ZoomY, 0, 0);
                if (this.CCD02_01_AxOvkMsr_垂直基準線量測_TxAxLineMsrDragHandle != AxOvkMsr.TxAxLineMsrDragHandle.AX_LINEMSR_NONE)
                {
                    this.flag_CCD02_01_AxOvkMsr_垂直基準線量測_MouseDown = true;
                    InUsedEventNum = 10;
                }
            }

        }
        private void H_Canvas_Tech_CCD02_01_基準線量測_OnCanvasMouseMoveEvent(int x, int y, float ZoomX, float ZoomY)
        {
            if (this.flag_CCD02_01_AxOvkMsr_水平基準線量測_MouseDown)
            {
                this.CCD02_01_水平基準線量測_AxLineMsr.DragFrame(this.CCD02_01_AxOvkMsr_水平基準線量測_TxAxLineMsrDragHandle, x, y, ZoomX, ZoomY, 0, 0);
                this.PLC_Device_CCD02_01_水平基準線量測_量測框起點X座標.Value = CCD02_01_水平基準線量測_AxLineMsr.NLineStartX;
                this.PLC_Device_CCD02_01_水平基準線量測_量測框起點Y座標.Value = CCD02_01_水平基準線量測_AxLineMsr.NLineStartY;
                this.PLC_Device_CCD02_01_水平基準線量測_量測框終點X座標.Value = CCD02_01_水平基準線量測_AxLineMsr.NLineEndX;
                this.PLC_Device_CCD02_01_水平基準線量測_量測框終點Y座標.Value = CCD02_01_水平基準線量測_AxLineMsr.NLineEndY;
                this.PLC_Device_CCD02_01_水平基準線量測_量測高度.Value = CCD02_01_水平基準線量測_AxLineMsr.HalfHeight;
            }

            if (this.flag_CCD02_01_AxOvkMsr_垂直基準線量測_MouseDown)
            {
                this.CCD02_01_垂直基準線量測_AxLineMsr.DragFrame(this.CCD02_01_AxOvkMsr_垂直基準線量測_TxAxLineMsrDragHandle, x, y, ZoomX, ZoomY, 0, 0);
                this.PLC_Device_CCD02_01_垂直基準線量測_量測框起點X座標.Value = CCD02_01_垂直基準線量測_AxLineMsr.NLineStartX;
                this.PLC_Device_CCD02_01_垂直基準線量測_量測框起點Y座標.Value = CCD02_01_垂直基準線量測_AxLineMsr.NLineStartY;
                this.PLC_Device_CCD02_01_垂直基準線量測_量測框終點X座標.Value = CCD02_01_垂直基準線量測_AxLineMsr.NLineEndX;
                this.PLC_Device_CCD02_01_垂直基準線量測_量測框終點Y座標.Value = CCD02_01_垂直基準線量測_AxLineMsr.NLineEndY;
                this.PLC_Device_CCD02_01_垂直基準線量測_量測高度.Value = CCD02_01_垂直基準線量測_AxLineMsr.HalfHeight;
            }


        }
        private void H_Canvas_Tech_CCD02_01_基準線量測_OnCanvasMouseUpEvent(int x, int y, float ZoomX, float ZoomY)
        {
            this.flag_CCD02_01_AxOvkMsr_水平基準線量測_MouseDown = false;
            this.flag_CCD02_01_AxOvkMsr_垂直基準線量測_MouseDown = false;
        }

        int cnt_Program_CCD02_01_基準線量測 = 65534;
        void sub_Program_CCD02_01_基準線量測()
        {
            if (cnt_Program_CCD02_01_基準線量測 == 65534)
            {
                this.h_Canvas_Tech_CCD02_01_拼接完成圖.OnCanvasMouseDownEvent += H_Canvas_Tech_CCD02_01_基準線量測_OnCanvasMouseDownEvent;
                this.h_Canvas_Tech_CCD02_01_拼接完成圖.OnCanvasMouseMoveEvent += H_Canvas_Tech_CCD02_01_基準線量測_OnCanvasMouseMoveEvent;
                this.h_Canvas_Tech_CCD02_01_拼接完成圖.OnCanvasMouseUpEvent += H_Canvas_Tech_CCD02_01_基準線量測_OnCanvasMouseUpEvent;
                this.h_Canvas_Tech_CCD02_01_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_01_基準線量測_OnCanvasDrawEvent;

                this.h_Canvas_Main_CCD02_01_檢測畫面.OnCanvasDrawEvent += H_Canvas_Tech_CCD02_01_基準線量測_OnCanvasDrawEvent;


                PLC_Device_CCD02_01_基準線量測.SetComment("PLC_CCD02_01_基準線量測");
                PLC_Device_CCD02_01_基準線量測.Bool = false;
                cnt_Program_CCD02_01_基準線量測 = 65535;
            }
            if (cnt_Program_CCD02_01_基準線量測 == 65535) cnt_Program_CCD02_01_基準線量測 = 1;
            if (cnt_Program_CCD02_01_基準線量測 == 1) cnt_Program_CCD02_01_基準線量測_檢查按下(ref cnt_Program_CCD02_01_基準線量測);
            if (cnt_Program_CCD02_01_基準線量測 == 2) cnt_Program_CCD02_01_基準線量測_初始化(ref cnt_Program_CCD02_01_基準線量測);
            if (cnt_Program_CCD02_01_基準線量測 == 3) cnt_Program_CCD02_01_基準線量測_開始量測(ref cnt_Program_CCD02_01_基準線量測);
            if (cnt_Program_CCD02_01_基準線量測 == 4) cnt_Program_CCD02_01_基準線量測_兩線交點(ref cnt_Program_CCD02_01_基準線量測);
            if (cnt_Program_CCD02_01_基準線量測 == 5) cnt_Program_CCD02_01_基準線量測_兩線交點量測(ref cnt_Program_CCD02_01_基準線量測);
            if (cnt_Program_CCD02_01_基準線量測 == 6) cnt_Program_CCD02_01_基準線量測_開始繪製(ref cnt_Program_CCD02_01_基準線量測);
            if (cnt_Program_CCD02_01_基準線量測 == 7) cnt_Program_CCD02_01_基準線量測 = 65500;
            if (cnt_Program_CCD02_01_基準線量測 > 1) cnt_Program_CCD02_01_基準線量測_檢查放開(ref cnt_Program_CCD02_01_基準線量測);

            if (cnt_Program_CCD02_01_基準線量測 == 65500)
            {
                PLC_Device_CCD02_01_基準線量測.Bool = false;
                cnt_Program_CCD02_01_基準線量測 = 65535;
            }
        }
        void cnt_Program_CCD02_01_基準線量測_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD02_01_基準線量測.Bool) cnt++;
        }
        void cnt_Program_CCD02_01_基準線量測_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD02_01_基準線量測.Bool) cnt = 65500;
        }
        void cnt_Program_CCD02_01_基準線量測_初始化(ref int cnt)
        {
            this.PLC_Device_CCD02_01_基準線量測_OK.Bool = false;

            this.CCD02_01_水平基準線量測_AxLineMsr.SrcImageHandle = this.CCD02_01_SrcImageHandle_拼接完成圖;
            this.CCD02_01_水平基準線量測_AxLineMsr.Hysteresis = PLC_Device_CCD02_01_基準線量測_延伸變化強度.Value;
            this.CCD02_01_水平基準線量測_AxLineMsr.DeriThreshold = PLC_Device_CCD02_01_基準線量測_變化銳利度.Value;
            this.CCD02_01_水平基準線量測_AxLineMsr.MinGreyStep = PLC_Device_CCD02_01_基準線量測_灰階變化面積.Value;
            this.CCD02_01_水平基準線量測_AxLineMsr.SmoothFactor = PLC_Device_CCD02_01_基準線量測_雜訊抑制.Value;
            this.CCD02_01_水平基準線量測_AxLineMsr.HalfProfileThickness = 5;
            this.CCD02_01_水平基準線量測_AxLineMsr.SampleStep = 1;
            this.CCD02_01_水平基準線量測_AxLineMsr.FilterCount = PLC_Device_CCD02_01_基準線量測_最佳回歸線計算次數.Value;
            this.CCD02_01_水平基準線量測_AxLineMsr.FilterThreshold = PLC_Device_CCD02_01_基準線量測_最佳回歸線濾波.Value / 10;

            if (this.PLC_Device_CCD02_01_水平基準線量測_量測框起點X座標.Value == 0 && this.PLC_Device_CCD02_01_水平基準線量測_量測框終點X座標.Value == 0)
            {
                this.PLC_Device_CCD02_01_水平基準線量測_量測框起點X座標.Value = 100;
                this.PLC_Device_CCD02_01_水平基準線量測_量測框終點X座標.Value = 100;
            }
            if (this.PLC_Device_CCD02_01_水平基準線量測_量測框起點Y座標.Value == 0 && this.PLC_Device_CCD02_01_水平基準線量測_量測框終點Y座標.Value == 0)
            {
                this.PLC_Device_CCD02_01_水平基準線量測_量測框起點Y座標.Value = 200;
                this.PLC_Device_CCD02_01_水平基準線量測_量測框終點Y座標.Value = 200;
            }
            if (this.PLC_Device_CCD02_01_水平基準線量測_量測高度.Value == 0)
            {
                this.PLC_Device_CCD02_01_水平基準線量測_量測高度.Value = 100;
            }

            this.CCD02_01_水平基準線量測_AxLineMsr.NLineStartX = PLC_Device_CCD02_01_水平基準線量測_量測框起點X座標.Value;
            this.CCD02_01_水平基準線量測_AxLineMsr.NLineStartY = PLC_Device_CCD02_01_水平基準線量測_量測框起點Y座標.Value;
            this.CCD02_01_水平基準線量測_AxLineMsr.NLineEndX = PLC_Device_CCD02_01_水平基準線量測_量測框終點X座標.Value;
            this.CCD02_01_水平基準線量測_AxLineMsr.NLineEndY = PLC_Device_CCD02_01_水平基準線量測_量測框終點Y座標.Value;
            this.CCD02_01_水平基準線量測_AxLineMsr.HalfHeight = PLC_Device_CCD02_01_水平基準線量測_量測高度.Value;

            this.CCD02_01_水平基準線量測_AxLineMsr.EdgeType = (AxOvkMsr.TxAxTransitionType)PLC_Device_CCD02_01_基準線量測_量測顏色變化.Value;
            this.CCD02_01_水平基準線量測_AxLineMsr.LockedMsrDirection = AxOvkMsr.TxAxLineMsrLockedMsrDirection.AX_LINEMSR_LOCKED_CLOCKWISE;


            this.CCD02_01_垂直基準線量測_AxLineMsr.SrcImageHandle = this.CCD02_01_SrcImageHandle_拼接完成圖;
            this.CCD02_01_垂直基準線量測_AxLineMsr.Hysteresis = PLC_Device_CCD02_01_基準線量測_延伸變化強度.Value;
            this.CCD02_01_垂直基準線量測_AxLineMsr.DeriThreshold = PLC_Device_CCD02_01_基準線量測_變化銳利度.Value;
            this.CCD02_01_垂直基準線量測_AxLineMsr.MinGreyStep = PLC_Device_CCD02_01_基準線量測_灰階變化面積.Value;
            this.CCD02_01_垂直基準線量測_AxLineMsr.SmoothFactor = PLC_Device_CCD02_01_基準線量測_雜訊抑制.Value;
            this.CCD02_01_垂直基準線量測_AxLineMsr.HalfProfileThickness = 5;
            this.CCD02_01_垂直基準線量測_AxLineMsr.SampleStep = 1;
            this.CCD02_01_垂直基準線量測_AxLineMsr.FilterCount = PLC_Device_CCD02_01_基準線量測_最佳回歸線計算次數.Value;
            this.CCD02_01_垂直基準線量測_AxLineMsr.FilterThreshold = PLC_Device_CCD02_01_基準線量測_最佳回歸線濾波.Value / 10;

            if (this.PLC_Device_CCD02_01_垂直基準線量測_量測框起點X座標.Value == 0 && this.PLC_Device_CCD02_01_垂直基準線量測_量測框終點X座標.Value == 0)
            {
                this.PLC_Device_CCD02_01_垂直基準線量測_量測框起點X座標.Value = 100;
                this.PLC_Device_CCD02_01_垂直基準線量測_量測框終點X座標.Value = 100;
            }
            if (this.PLC_Device_CCD02_01_垂直基準線量測_量測框起點Y座標.Value == 0 && this.PLC_Device_CCD02_01_垂直基準線量測_量測框終點Y座標.Value == 0)
            {
                this.PLC_Device_CCD02_01_垂直基準線量測_量測框起點Y座標.Value = 200;
                this.PLC_Device_CCD02_01_垂直基準線量測_量測框終點Y座標.Value = 200;
            }
            if (this.PLC_Device_CCD02_01_垂直基準線量測_量測高度.Value == 0)
            {
                this.PLC_Device_CCD02_01_垂直基準線量測_量測高度.Value = 100;
            }

            this.CCD02_01_垂直基準線量測_AxLineMsr.NLineStartX = PLC_Device_CCD02_01_垂直基準線量測_量測框起點X座標.Value;
            this.CCD02_01_垂直基準線量測_AxLineMsr.NLineStartY = PLC_Device_CCD02_01_垂直基準線量測_量測框起點Y座標.Value;
            this.CCD02_01_垂直基準線量測_AxLineMsr.NLineEndX = PLC_Device_CCD02_01_垂直基準線量測_量測框終點X座標.Value;
            this.CCD02_01_垂直基準線量測_AxLineMsr.NLineEndY = PLC_Device_CCD02_01_垂直基準線量測_量測框終點Y座標.Value;
            this.CCD02_01_垂直基準線量測_AxLineMsr.HalfHeight = PLC_Device_CCD02_01_垂直基準線量測_量測高度.Value;

            this.CCD02_01_垂直基準線量測_AxLineMsr.EdgeType = (AxOvkMsr.TxAxTransitionType)PLC_Device_CCD02_01_基準線量測_量測顏色變化.Value;
            this.CCD02_01_垂直基準線量測_AxLineMsr.LockedMsrDirection = AxOvkMsr.TxAxLineMsrLockedMsrDirection.AX_LINEMSR_LOCKED_CLOCKWISE;
            cnt++;

        }
        void cnt_Program_CCD02_01_基準線量測_開始量測(ref int cnt)
        {
            if (CCD02_01_SrcImageHandle_拼接完成圖 != 0)
            {
                this.CCD02_01_水平基準線量測_AxLineMsr.DetectPrimitives();
                this.CCD02_01_垂直基準線量測_AxLineMsr.DetectPrimitives();
            }

            if (this.CCD02_01_水平基準線量測_AxLineMsr.LineIsFitted && this.CCD02_01_垂直基準線量測_AxLineMsr.LineIsFitted)
            {

                PointF 水平量測點p1 = new PointF();
                PointF 水平量測點p2 = new PointF();

                CCD02_01_水平基準線量測_AxLineMsr.ValidPointIndex = 0;
                水平量測點p1.X = (int)CCD02_01_水平基準線量測_AxLineMsr.ValidPointX;
                水平量測點p1.Y = (int)CCD02_01_水平基準線量測_AxLineMsr.ValidPointY;
                CCD02_01_水平基準線量測_AxLineMsr.ValidPointIndex = CCD02_01_水平基準線量測_AxLineMsr.ValidPointCount;
                水平量測點p2.X = (int)CCD02_01_水平基準線量測_AxLineMsr.ValidPointX;
                水平量測點p2.Y = (int)CCD02_01_水平基準線量測_AxLineMsr.ValidPointY;
                //Point_CCD02_01_中心基準座標_量測點.X = (int)((水平量測點p1.X + 水平量測點p2.X) / 2);
                //Point_CCD02_01_中心基準座標_量測點.Y = (int)((水平量測點p1.Y + 水平量測點p2.Y) / 2);

                PointF 水平p1 = new PointF();
                PointF 水平p2 = new PointF();
                double 水平confB;
                double 水平Slope = this.CCD02_01_水平基準線量測_AxLineMsr.MeasuredSlope;
                double 水平PivotX = this.CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotX;
                double 水平PivotY = this.CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotY;
                水平confB = Conf0Msr(水平Slope, 水平PivotX, 水平PivotY);
                水平p1.X = 1;
                水平p1.Y = (float)FunctionMsr_Y(水平confB, 水平Slope, 水平p1.X);
                水平p2.X = 10000;
                水平p2.Y = (float)FunctionMsr_Y(水平confB, 水平Slope, 水平p2.X);
                水平p1 = new PointF((水平p1.X), (水平p1.Y));
                水平p2 = new PointF((水平p2.X), (水平p2.Y));

                this.CCD02_01_水平基準線量測_AxLineRegression.RegressionOrientation = AxOvkMsr.TxAxLineRegressionOrientation.AX_QUASI_HORIZONTAL_REGRESSION;
                this.CCD02_01_水平基準線量測_AxLineRegression.PointIndex = 0;
                this.CCD02_01_水平基準線量測_AxLineRegression.PointX = 水平p1.X;
                this.CCD02_01_水平基準線量測_AxLineRegression.PointY = 水平p1.Y + (this.PLC_Device_CCD02_01_基準線量測_基準線偏移.Value / 1000) * CCD02_比例尺_mm_To_pixcel;
                this.CCD02_01_水平基準線量測_AxLineRegression.PointIndex = 1;
                this.CCD02_01_水平基準線量測_AxLineRegression.PointX = 水平p2.X;
                this.CCD02_01_水平基準線量測_AxLineRegression.PointY = 水平p2.Y + (this.PLC_Device_CCD02_01_基準線量測_基準線偏移.Value / 1000) * CCD02_比例尺_mm_To_pixcel;
                this.CCD02_01_水平基準線量測_AxLineRegression.DetectPrimitives();

                PointF 垂直p1 = new PointF();
                PointF 垂直p2 = new PointF();
                double 垂直confB;
                double 垂直Slope = this.CCD02_01_垂直基準線量測_AxLineMsr.MeasuredSlope;
                double 垂直PivotX = this.CCD02_01_垂直基準線量測_AxLineMsr.MeasuredPivotX;
                double 垂直PivotY = this.CCD02_01_垂直基準線量測_AxLineMsr.MeasuredPivotY;
                垂直confB = Conf0Msr(垂直Slope, 垂直PivotX, 垂直PivotY);
                垂直p1.X = (float)FunctionMsr_Y(垂直confB, 垂直Slope, 垂直p1.X);
                垂直p1.Y = 1;
                垂直p2.X = (float)FunctionMsr_Y(垂直confB, 垂直Slope, 垂直p2.X);
                垂直p2.Y = 10000;
                垂直p1 = new PointF((垂直p1.X), (垂直p1.Y));
                垂直p2 = new PointF((垂直p2.X), (垂直p2.Y));

                this.CCD02_01_垂直基準線量測_AxLineRegression.RegressionOrientation = AxOvkMsr.TxAxLineRegressionOrientation.AX_QUASI_VERTICAL_REGRESSION;
                this.CCD02_01_垂直基準線量測_AxLineRegression.PointIndex = 0;
                this.CCD02_01_垂直基準線量測_AxLineRegression.PointX = 垂直p1.X;
                this.CCD02_01_垂直基準線量測_AxLineRegression.PointY = 垂直p1.Y;
                this.CCD02_01_垂直基準線量測_AxLineRegression.PointIndex = 1;
                this.CCD02_01_垂直基準線量測_AxLineRegression.PointX = 垂直p2.X;
                this.CCD02_01_垂直基準線量測_AxLineRegression.PointY = 垂直p2.Y;
                this.CCD02_01_垂直基準線量測_AxLineRegression.DetectPrimitives();

                this.PLC_Device_CCD02_01_基準線量測_OK.Bool = true;
            }

            cnt++;
        }
        void cnt_Program_CCD02_01_基準線量測_兩線交點(ref int cnt)
        {
            CCD02_01_基準線量測_AxIntersectionMsr.Line1HorzVert = AxOvkMsr.TxAxLineHorzVert.AX_LINE_QUASI_HORIZONTAL;
            CCD02_01_基準線量測_AxIntersectionMsr.Line1PivotX = CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotX;
            CCD02_01_基準線量測_AxIntersectionMsr.Line1PivotY = CCD02_01_水平基準線量測_AxLineMsr.MeasuredPivotY;
            CCD02_01_基準線量測_AxIntersectionMsr.Line1Slope = CCD02_01_水平基準線量測_AxLineMsr.MeasuredSlope;

            CCD02_01_基準線量測_AxIntersectionMsr.Line2HorzVert = AxOvkMsr.TxAxLineHorzVert.AX_LINE_QUASI_VERTICAL;
            CCD02_01_基準線量測_AxIntersectionMsr.Line2PivotX = CCD02_01_垂直基準線量測_AxLineMsr.MeasuredPivotX;
            CCD02_01_基準線量測_AxIntersectionMsr.Line2PivotY = CCD02_01_垂直基準線量測_AxLineMsr.MeasuredPivotY;
            CCD02_01_基準線量測_AxIntersectionMsr.Line2Slope = CCD02_01_垂直基準線量測_AxLineMsr.MeasuredSlope;

            CCD02_01_基準線量測_AxIntersectionMsr.FindIntersection();

            cnt++;
        }
        void cnt_Program_CCD02_01_基準線量測_兩線交點量測(ref int cnt)
        {
            Point_CCD02_01_中心基準座標_量測點.X = (float)CCD02_01_基準線量測_AxIntersectionMsr.IntersectionX;
            Point_CCD02_01_中心基準座標_量測點.Y = (float)CCD02_01_基準線量測_AxIntersectionMsr.IntersectionY;

            if (!PLC_Device_CCD02_01_計算一次.Bool)
            {
                //PLC_Device_CCD02_01_水平基準線量測_量測中心_X.Value = (int)CCD02_01_基準線量測_AxIntersectionMsr.IntersectionX;
                //PLC_Device_CCD02_01_水平基準線量測_量測中心_Y.Value = (int)CCD02_01_基準線量測_AxIntersectionMsr.IntersectionY;
                PLC_Device_CCD02_01_水平基準線量測_量測中心_X.Value = 2199;
                PLC_Device_CCD02_01_水平基準線量測_量測中心_Y.Value = 1175;
            }

            cnt++;
        }
        void cnt_Program_CCD02_01_基準線量測_開始繪製(ref int cnt)
        {

            this.PLC_Device_CCD02_01_基準線量測_RefreshCanvas.Bool = true;
            if (this.PLC_Device_CCD02_01_基準線量測按鈕.Bool && !PLC_Device_CCD02_01_計算一次.Bool)
            {
                this.h_Canvas_Tech_CCD02_01_拼接完成圖.RefreshCanvas();
            }
            cnt++;
        }




        #endregion

        private PLC_Device PLC_Device_CCD02_01_PIN量測參數_灰階門檻值_combobox = new PLC_Device("F651");
        void Program_CCD02_01_PIN量測_combobox()
        {


        }




        #region Event


        private void plC_RJ_Button_CCD02_01_拼接圖1_儲存圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.h_Canvas_Tech_CCD02_01_拼接圖1.SaveImage(saveImageDialog.FileName);
                }
            }));

        }
        private void plC_RJ_Button_CCD02_01_拼接圖1_讀取圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (openImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.CCD02_AxImageBW8.LoadFile(openImageDialog.FileName);
                    try
                    {
                        this.h_Canvas_Tech_CCD02_01_拼接圖1.ImageCopy(CCD02_AxImageBW8.VegaHandle);
                        this.CCD02_01_SrcImageHandle_拼接圖1 = h_Canvas_Tech_CCD02_01_拼接圖1.VegaHandle;
                        this.h_Canvas_Tech_CCD02_01_拼接圖1.RefreshCanvas();
                    }
                    catch
                    {
                        err_message2 = MessageBox.Show("讀取圖片空白", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (err_message2 == DialogResult.OK)
                        {

                        }
                    }
                }
            }));


        }
        private void plC_RJ_Button_CCD02_01_拼接圖2_儲存圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.h_Canvas_Tech_CCD02_01_拼接圖2.SaveImage(saveImageDialog.FileName);
                }
            }));
        }
        private void plC_RJ_Button_CCD02_01_拼接圖2_讀取圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (openImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.CCD02_AxImageBW8.LoadFile(openImageDialog.FileName);
                    try
                    {
                        this.h_Canvas_Tech_CCD02_01_拼接圖2.ImageCopy(CCD02_AxImageBW8.VegaHandle);
                        this.CCD02_01_SrcImageHandle_拼接圖2 = h_Canvas_Tech_CCD02_01_拼接圖2.VegaHandle;
                        this.h_Canvas_Tech_CCD02_01_拼接圖2.RefreshCanvas();
                    }
                    catch
                    {
                        err_message2 = MessageBox.Show("讀取圖片空白", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (err_message2 == DialogResult.OK)
                        {

                        }
                    }
                }
            }));
        }
        private void plC_RJ_Button_CCD02_01_拼接完成圖_儲存圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.h_Canvas_Tech_CCD02_01_拼接完成圖.SaveImage(saveImageDialog.FileName);
                }
            }));
        }
        private void plC_RJ_Button_CCD02_01_拼接完成圖_讀取圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (openImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.CCD02_AxImageBW8.LoadFile(openImageDialog.FileName);
                    try
                    {
                        this.h_Canvas_Tech_CCD02_01_拼接完成圖.ImageCopy(CCD02_AxImageBW8.VegaHandle);
                        this.CCD02_01_SrcImageHandle_拼接完成圖 = h_Canvas_Tech_CCD02_01_拼接完成圖.VegaHandle;
                        this.h_Canvas_Tech_CCD02_01_拼接完成圖.RefreshCanvas();
                    }
                    catch
                    {
                        err_message2 = MessageBox.Show("讀取圖片空白", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                        if (err_message2 == DialogResult.OK)
                        {

                        }
                    }
                }
            }));
        }
        private void plC_RJ_Button_Main_CCD02_01儲存圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.h_Canvas_Main_CCD02_01_檢測畫面.SaveImage(saveImageDialog.FileName);
                }
            }));
        }

        private void plC_RJ_Button_Main_CCD02_01讀取圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (openImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.CCD02_AxImageBW8.LoadFile(openImageDialog.FileName);
                    try
                    {
                        this.h_Canvas_Main_CCD02_01_檢測畫面.ImageCopy(CCD02_AxImageBW8.VegaHandle);
                        this.CCD02_01_SrcImageHandle_拼接完成圖 = h_Canvas_Main_CCD02_01_檢測畫面.VegaHandle;
                        this.h_Canvas_Main_CCD02_01_檢測畫面.RefreshCanvas();
                    }
                    catch
                    {
                        err_message2 = MessageBox.Show("讀取圖片空白", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                        if (err_message2 == DialogResult.OK)
                        {

                        }
                    }
                }
            }));
        }
        private void plC_Button_CCD02_01_儲存拼接檔案_btnClick(object sender, EventArgs e)
        {
            if (saveFileDialog_拼接校正檔.ShowDialog() == DialogResult.OK)
            {
                this.CCD02_01_AxImageSewer.SaveFile(saveFileDialog_拼接校正檔.FileName);
            }
        }
        private void plC_Button_CCD02_01_讀取拼接檔案_btnClick(object sender, EventArgs e)
        {
            if (openFileDialog_拼接校正檔.ShowDialog() == DialogResult.OK)
            {
                this.CCD02_01_AxImageSewer.LoadFile(@"C:\Users\Administrator\Desktop\Vens40P_CCD\Imagesewer_File\CCD02_01_Calibrate.cb");
            }
        }
        int CCD02_01_接圖1拼接順序 = 0;
        int CCD02_01_接圖2拼接順序 = 0;
        private void plC_Button_CCD02_01拼圖1校正SET_btnClick(object sender, EventArgs e)
        {
            if (PLC_Device_CCD02_01_校正量測框調整.Bool)
            {
                if (CCD02_01_接圖1拼接順序 == 0)
                {
                    PLC_Device_CCD02_01_校正量測框_拼圖1校正座標1_X.Value = PLC_Device_CCD02_01_校正量測框_拼圖1座標X.Value;
                    PLC_Device_CCD02_01_校正量測框_拼圖1校正座標1_Y.Value = PLC_Device_CCD02_01_校正量測框_拼圖1座標Y.Value;
                    CCD02_01_接圖1拼接順序 = 1;
                }
                else if (CCD02_01_接圖1拼接順序 == 1)
                {
                    PLC_Device_CCD02_01_校正量測框_拼圖1校正座標2_X.Value = PLC_Device_CCD02_01_校正量測框_拼圖1座標X.Value;
                    PLC_Device_CCD02_01_校正量測框_拼圖1校正座標2_Y.Value = PLC_Device_CCD02_01_校正量測框_拼圖1座標Y.Value;
                    CCD02_01_接圖1拼接順序 = 2;
                }
                else if (CCD02_01_接圖1拼接順序 == 2)
                {
                    PLC_Device_CCD02_01_校正量測框_拼圖1校正座標3_X.Value = PLC_Device_CCD02_01_校正量測框_拼圖1座標X.Value;
                    PLC_Device_CCD02_01_校正量測框_拼圖1校正座標3_Y.Value = PLC_Device_CCD02_01_校正量測框_拼圖1座標Y.Value;
                    CCD02_01_接圖1拼接順序 = 3;
                }
                else if (CCD02_01_接圖1拼接順序 == 3)
                {
                    PLC_Device_CCD02_01_校正量測框_拼圖1校正座標4_X.Value = PLC_Device_CCD02_01_校正量測框_拼圖1座標X.Value;
                    PLC_Device_CCD02_01_校正量測框_拼圖1校正座標4_Y.Value = PLC_Device_CCD02_01_校正量測框_拼圖1座標Y.Value;
                    CCD02_01_接圖1拼接順序 = 0;
                    MessageBox.Show("拼圖1校正點輸入完成", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }
        private void plC_Button_CCD02_01拼圖2校正SET_btnClick(object sender, EventArgs e)
        {
            if (PLC_Device_CCD02_01_校正量測框調整.Bool)
            {
                if (CCD02_01_接圖2拼接順序 == 0)
                {
                    PLC_Device_CCD02_01_校正量測框_拼圖2校正座標1_X.Value = PLC_Device_CCD02_01_校正量測框_拼圖2座標X.Value;
                    PLC_Device_CCD02_01_校正量測框_拼圖2校正座標1_Y.Value = PLC_Device_CCD02_01_校正量測框_拼圖2座標Y.Value;
                    CCD02_01_接圖2拼接順序 = 1;
                }
                else if (CCD02_01_接圖2拼接順序 == 1)
                {
                    PLC_Device_CCD02_01_校正量測框_拼圖2校正座標2_X.Value = PLC_Device_CCD02_01_校正量測框_拼圖2座標X.Value;
                    PLC_Device_CCD02_01_校正量測框_拼圖2校正座標2_Y.Value = PLC_Device_CCD02_01_校正量測框_拼圖2座標Y.Value;
                    CCD02_01_接圖2拼接順序 = 2;
                }
                else if (CCD02_01_接圖2拼接順序 == 2)
                {
                    PLC_Device_CCD02_01_校正量測框_拼圖2校正座標3_X.Value = PLC_Device_CCD02_01_校正量測框_拼圖2座標X.Value;
                    PLC_Device_CCD02_01_校正量測框_拼圖2校正座標3_Y.Value = PLC_Device_CCD02_01_校正量測框_拼圖2座標Y.Value;
                    CCD02_01_接圖2拼接順序 = 3;
                }
                else if (CCD02_01_接圖2拼接順序 == 3)
                {
                    PLC_Device_CCD02_01_校正量測框_拼圖2校正座標4_X.Value = PLC_Device_CCD02_01_校正量測框_拼圖2座標X.Value;
                    PLC_Device_CCD02_01_校正量測框_拼圖2校正座標4_Y.Value = PLC_Device_CCD02_01_校正量測框_拼圖2座標Y.Value;
                    CCD02_01_接圖2拼接順序 = 0;
                    MessageBox.Show("拼圖2校正點輸入完成", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }

        }


        #endregion
    }
}
