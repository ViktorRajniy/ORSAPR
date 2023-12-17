﻿using System.Diagnostics;
using GrillPlugin.Model;
using ModelAPI;
using Microsoft.VisualBasic.Devices;
using Autodesk.AutoCAD.Runtime;
using System.IO;
using System;

public class StressTests
{

    [CommandMethod("StressTest")]
    public void StressTest()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        Parameters parameters = new Parameters();

        StreamWriter writer = new StreamWriter($"log.txt", false);

        AutoCadBuilder autoCadBuilder = new AutoCadBuilder(parameters);

        Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
        var count = 0;

        while (count != 10000)
        {
            const double gigabyteInByte = 0.000000000931322574615478515625;
            autoCadBuilder.BuildGrill();
            var computerInfo = new ComputerInfo();
            var usedMemory = (computerInfo.TotalPhysicalMemory
            - computerInfo.AvailablePhysicalMemory)
            * gigabyteInByte;
            writer.WriteLine(
            $"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
            writer.Flush();
        }

        stopWatch.Stop();
        writer.Close();
        writer.Dispose();
        Console.Write($"End {new ComputerInfo().TotalPhysicalMemory}");
    }
}
