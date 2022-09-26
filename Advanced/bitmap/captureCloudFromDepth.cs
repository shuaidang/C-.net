﻿using System;
using System.Collections.Generic;
//using Emgu.CV;
//using Emgu.CV.CvEnum;
using mmind.apiSharp;
using System.Windows.Forms;

class sample
{
    
    static void showError(ErrorStatus status)
    {
        if (status.errorCode == (int)ErrorCode.MMIND_STATUS_SUCCESS)
            return;
        Console.WriteLine("Error Code : {0}, Error Description: {1}.", status.errorCode, status.errorDescription);
    }
    static void printDeviceInfo(MechEyeDeviceInfo deviceInfo)
    {
        Console.WriteLine("............................");
        Console.WriteLine("Camera Model Name: {0}", deviceInfo.model);
        Console.WriteLine("Camera ID:         {0}", deviceInfo.id);
        Console.WriteLine("Camera IP Address: {0}", deviceInfo.ipAddress);
        Console.WriteLine("Hardware Version:  V{0}", deviceInfo.hardwareVersion);
        Console.WriteLine("Firmware Version:  V{0}", deviceInfo.firmwareVersion);
        Console.WriteLine("............................");
        Console.WriteLine("");
    }

    static int Main()
    {
        Console.WriteLine("Find Mech-Eye devices...");
        List<MechEyeDeviceInfo> deviceInfoList = MechEyeDevice.enumerateMechEyeDeviceList();

        if (deviceInfoList.Count == 0)
        {
            Console.WriteLine("No Mech-Eye Device found.");
            return -1;
        }

        for (int i = 0; i < deviceInfoList.Count; ++i)
        {
            Console.WriteLine("Mech-Eye device index : {0}", i);
            printDeviceInfo(deviceInfoList[i]);
        }

        Console.WriteLine("Please enter the device index you want to connect: ");
        int inputIndex = 0;

        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out inputIndex) && inputIndex >= 0 && inputIndex < deviceInfoList.Count)
                break;
            Console.WriteLine("Input invalid! Please enter the device index you wnat to connect: ");
        }

        //MechEyeDeviceInfo deviceInfo = new MechEyeDeviceInfo() { model = "", id = "", hardwareVersion = "", firmwareVersion = "1.5.0", ipAddress = "127.0.0.1", port = 5577 };

        ErrorStatus status = new ErrorStatus();
        MechEyeDevice device = new MechEyeDevice();
        status = device.connect(deviceInfoList[inputIndex]);

        //status = device.connect(deviceInfo);

        if (status.errorCode != (int)ErrorCode.MMIND_STATUS_SUCCESS)
        {
            showError(status);
            return -1;
        }

        Console.WriteLine("Connected to the Mech-Eye device successfully.");

        MechEyeDeviceInfo deviceInfo = new MechEyeDeviceInfo();
        showError(device.getDeviceInfo(ref deviceInfo));
        printDeviceInfo(deviceInfo);

        mmind.apiSharp.ColorMap color = new mmind.apiSharp.ColorMap();
        showError(device.captureColorMap(ref color));

        DepthMap depth = new DepthMap();
        showError(device.captureDepthMap(ref depth));

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        CaptureCloudFromDepth.ShowMap m = new CaptureCloudFromDepth.ShowMap();
        //m.SetABCDEFG(1000);
        m.SetColor(ref color);
        m.SetDepth(ref depth);
        Application.Run(m);
        //Mat color8UC3 = new Mat(unchecked((int)color.height()), unchecked((int)color.width()), DepthType.Cv8U, 3, color.data(), unchecked((int)color.width()) * 3);
        DeviceIntri deviceIntri = new DeviceIntri();
        showError(device.getDeviceIntri(ref deviceIntri));


        showError(device.setScan3DROI(new ROI(0, 0, 500, 500)));

        PointXYZBGRMap xyzbgr = new PointXYZBGRMap();
        sample.showError(device.capturePointXYZBGRMap(ref xyzbgr));

        color.resize(xyzbgr.width(), xyzbgr.height());

        for (uint i = 0; i < xyzbgr.height(); i++)
            for (uint j = 0; j < xyzbgr.width(); j++)
            {
                color.at(i, j).b = xyzbgr.at(i, j).b;
                color.at(i, j).g = xyzbgr.at(i, j).g;
                color.at(i, j).r = xyzbgr.at(i, j).r;
            }
        PointXYZMap pointXYZMap = new PointXYZMap();
        showError(device.capturePointXYZMap(ref pointXYZMap));
        string pointCloudPath = "PointCloudXYZ.ply";
        string pointCloudColorPath = "PointCloudXYZRGB.ply";

        //CvInvoke.WriteCloud(pointCloudPath, depth32FC3);
        //Console.WriteLine("PointCloudXYZ has : {0} data points.", depth32FC3.Rows * depth32FC3.Cols);
        //CvInvoke.WriteCloud(pointCloudColorPath, depth32FC3, color8UC3);
        //Console.WriteLine("PointCloudXYZRGB has: {0} data points.", depth32FC3.Rows * depth32FC3.Cols);

        //PointXYZMap pointXYZMap = new PointXYZMap();
        //pointXYZMap.resize(depth.width(), depth.height());
        //for (uint m = 0; m < depth.height(); ++m)
        //    for (uint n = 0; n < depth.width(); ++n)
        //    {
        //        float d;
        //        try
        //        {
        //            d = depth.at(m, n).d;
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("Exception: {0}", e);
        //            device.disconnect();
        //            return 0;
        //        }
        //        pointXYZMap.at(m, n).z = d;
        //        pointXYZMap.at(m, n).x = ((float)n - (float)deviceIntri.depthCameraIntri.cx) * d / (float)deviceIntri.depthCameraIntri.fx;
        //        pointXYZMap.at(m, n).y = ((float)m - (float)deviceIntri.depthCameraIntri.cy) * d / (float)deviceIntri.depthCameraIntri.fy;
        //    }

        //string pointCloudPath = "PointCloudXYZ.ply";
        //string pointCloudColorPath = "PointCloudXYZRGB.ply";
        //Mat depth32FC3 = new Mat(unchecked((int)pointXYZMap.height()), unchecked((int)pointXYZMap.width()), DepthType.Cv32F, 3, pointXYZMap.data(), unchecked((int)pointXYZMap.width()) * 12);

        // CvInvoke.WriteCloud(pointCloudPath, depth32FC3);
        // Console.WriteLine("PointCloudXYZ has : {0} data points.", depth32FC3.Rows * depth32FC3.Cols);
        // CvInvoke.WriteCloud(pointCloudColorPath, depth32FC3, color8UC3);
        // Console.WriteLine("PointCloudXYZRGB has: {0} data points.", depth32FC3.Rows * depth32FC3.Cols);

        device.disconnect();
        Console.WriteLine("Disconnected from the Mech-Eye device successfully.");

        return 0;
    }
}