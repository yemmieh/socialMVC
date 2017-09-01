using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialCampaignMVC.Models
{
    public class DownloadInfoModel
    {

        public string Customer_FacebookID { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Email { get; set; }
        public string Referrer_ID { get; set; }
        public string Campaign_ID { get; set; }
        public string Product_ID { get; set; }

    }
}