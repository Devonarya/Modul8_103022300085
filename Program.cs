using Modul8_103022300085;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
public class program {
    public static void Main(String[] args)
    {
        BankTransferConfig bankTransferConfig = new BankTransferConfig();
        string configPath = "bank_transfer_config.json";
        bankTransferConfig.readConfigFile(configPath);

        if (bankTransferConfig.lang == "en") {
            Console.WriteLine("Please insert the amount of money to transfer:");
        } else if(bankTransferConfig.lang == "id") { 
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer: ");
        }

        int nominalTransfer = int.Parse(Console.ReadLine());
        int totalBiaya = 0;

        if (nominalTransfer <= bankTransferConfig.Transfer.treshold)
        {
            totalBiaya = bankTransferConfig.Transfer.low_fee + nominalTransfer;
        }
        else { 
            totalBiaya = bankTransferConfig.Transfer.high_fee + nominalTransfer;
        }

        if (bankTransferConfig.lang == "en")
        {
            Console.WriteLine($"Transfer Fee = {totalBiaya - nominalTransfer}");
            Console.WriteLine($"Total amount = {totalBiaya}");
            Console.WriteLine("select transfer method : ");
        }
        else if (bankTransferConfig.lang == "id") {
            Console.WriteLine($"Transfer Fee = {totalBiaya - nominalTransfer}");
            Console.WriteLine($"Total amount = {totalBiaya}");
            Console.WriteLine("Pilih Transfer Method : ");
        }


    }
}