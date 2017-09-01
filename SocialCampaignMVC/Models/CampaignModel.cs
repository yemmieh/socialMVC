using System;
using System.ComponentModel.DataAnnotations;

namespace SocialCampaignMVC.Models
{
    class CampaignViewModel
    {
        [Display(Name = "Campaign ID")]
        [EmailAddress]
        public string Campaign_ID { get; set; }

        [Display(Name = "Product ID")]
        public string Product_ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Please provide the campaign title", MinimumLength = 6)]
        [Display(Name = "Campaign Title")]
        public string Campaign_Title { get; set; }

        [Display(Name = "Campaign Type")]
        public string Campaign_Type { get; set; }

        [Required]
        [Display(Name = "Campaign Link")]
        public string Campaign_Link { get; set; }

        [Required]
        public string Created_By { get; set; }

        [Required]
        public string Editted_By { get; set; }

        public DateTime Update_Date { get; set; }

        public string Campaign_Status { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Start_Date { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime End_Date { get; set; }
    }
}
