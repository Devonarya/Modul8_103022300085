using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic.FileIO;

namespace Modul8_103022300085
{
    public class BankTransferConfig
    {
        //Attribute untuk diserialisasi
        public String lang { get; set; }
        public transfer Transfer { get; set; }
        public String [] methods { get; set; }
        public confirmation Confirmation { get; set;}

        public class transfer
        { 
            public int treshold { get; set;}          
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }

        public class confirmation
        { 
            public string en { get; set;}
            public string id { get; set;}
        }
        public BankTransferConfig() { 
            lang = "en";
            Transfer = new transfer();
            Transfer.treshold = 25000000;
            Transfer.low_fee = 6500;
            Transfer.high_fee = 15000;
            methods = new string[] { "RTO(real - time)", "SKN", "RTGS", "BI FAST" };
            Confirmation = new confirmation();
            Confirmation.en = "yes";
            Confirmation.id = "ya";
        }

        public void readConfigFile(string path)
        {

            if (File.Exists(path))
            {
                string jsonText = File.ReadAllText(path);
                BankTransferConfig config = JsonSerializer.Deserialize<BankTransferConfig>(jsonText);
                this.lang = config.lang;
                this.Transfer = config.Transfer;
                this.methods = config.methods;
                this.Confirmation = config.Confirmation;

            }
            else {
                 Console.WriteLine("Gagal membaca file");
            }
        }

        public void writeNewConfig(string path)
        {
            string jsonText = JsonSerializer.Serialize(this);
            File.WriteAllText(path, jsonText);
            Console.WriteLine("File Berhasil ditulis!");
        }

        public void readandwriteConfigFile(string path) {
            if (File.Exists(path)) { 
                readConfigFile(path);
            } else
            {
                writeNewConfig(path);
                readConfigFile(path);
            }
        }
    }
}
