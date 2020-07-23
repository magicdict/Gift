using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tax
{
    class ItemInfo
    {

        public const string ItemTaxCode = "1080207020000000000";

        public static Dictionary<string, string> ItemCodeDict = new Dictionary<string, string>();

        public static int ReadSys()
        {
            var sr = new StreamReader("商品编码.txt", Encoding.GetEncoding("GB2312"));
            ItemCodeDict.Clear();
            sr.ReadLine();
            sr.ReadLine();
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                var info = sr.ReadLine().Split("~~".ToCharArray());
                ItemCodeDict.Add(info[2], info[0]);
            }
            return ItemCodeDict.Count;
        }
    }


    class CustomerInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string TaxCode { get; set; }
        public string AddressTel { get; set; }
        public string BankAccount { get; set; }
        public string MailAddress { get; set; }
        public string Memo { get; set; }
        public string Validate { get; set; }

        public static List<CustomerInfo> list = new List<CustomerInfo>();


        public static int ReadSys()
        {
            var sr = new StreamReader("客户编码.txt", Encoding.GetEncoding("GB2312"));
            list.Clear();
            sr.ReadLine();
            sr.ReadLine();
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                var info = sr.ReadLine().Split("~~".ToCharArray());
                if (info.Length == 17)
                {
                    var r = new CustomerInfo();
                    r.ID = info[0];
                    r.Name = info[2];
                    r.TaxCode = info[6];
                    r.AddressTel = info[8];
                    r.BankAccount = info[10];
                    list.Add(r);
                }
            }
            return list.Count;
        }

    }
}
