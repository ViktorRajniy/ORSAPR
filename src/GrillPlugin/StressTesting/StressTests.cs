using System.Diagnostics;
using GrillPlugin.Model;
using ModelAPI;
using Microsoft.VisualBasic.Devices;
using Autodesk.AutoCAD.Runtime;
using System.IO;
using System;

/// <summary>
/// Класс нагрузочного тестирования.
/// </summary>
public class StressTests
{
    /// <summary>
    /// Метод вызывающий в AutoCAD нагрузочное тестирование.
    /// </summary>
    [CommandMethod("StressTest")]
    public void StressTest()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        Parameters parameters = new Parameters();

        parameters = InitMaxParameters(parameters);

        StreamWriter writer = new StreamWriter($"MaxLog.txt", false);

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

    /// <summary>
    /// Метод инициализирует Параметры максимальными значениями.
    /// </summary>
    /// <returns>Экземпляр Параметрс с максимальными значениями.</returns>
    public Parameters InitMaxParameters(Parameters parameters)
    {
        foreach (ParameterType parameterType in Enum.GetValues(typeof(ParameterType)))
        {
            var parameter = parameters.GetParameter(parameterType);
            double value = parameter.MaxValue;
            parameters.SetValue(parameterType, value);
        }

        return parameters;
    }

    /// <summary>
    /// Метод инициализирует Параметры средними значениями.
    /// </summary>
    /// <returns>Экземпляр Параметрс со средними значениями.</returns>
    public Parameters InitMiddleParameters(Parameters parameters)
    {
        foreach (ParameterType parameterType in Enum.GetValues(typeof(ParameterType)))
        {
            var parameter = parameters.GetParameter(parameterType);
            double value = ((parameter.MaxValue - parameter.MaxValue) / 2) +
                           parameter.MaxValue;
            parameters.SetValue(parameterType, value);
        }

        return parameters;
    }
}
