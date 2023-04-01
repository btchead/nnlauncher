using Microsoft.Win32;
using System;

public static class Crypto
{
    private static string FetchMachineGUID()
    {
        const string registryPath = "SOFTWARE\\Microsoft\\Cryptography";
        const string targetKey = "MachineGuid";
        string machineGUID;

        try
        {
            using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                RegistryKey targetSubKey = registryKey.OpenSubKey(registryPath);
                if (targetSubKey == null)
                {
                    throw new Exception("Unable to find the registry path: " + registryPath);
                }

                object targetValue = targetSubKey.GetValue(targetKey);
                if (targetValue == null)
                {
                    throw new Exception("Unable to find the target key: " + targetKey);
                }

                machineGUID = targetValue.ToString();
            }
        }
        catch (Exception ex)
        {
            Logger.Error("Failed to fetch machine GUID: ", ex);
            return string.Empty;
        }

        return machineGUID;
    }

    private static string GenerateRandomString()
    {
        Random random = new Random();
        byte[] array = new byte[random.Next(5, 19)];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = (byte)random.Next(0, 255);
        }
        return Convert.ToBase64String(array);
    }

    public static string MachineGUID => FetchMachineGUID();
    public static string RandomString => GenerateRandomString();
}

