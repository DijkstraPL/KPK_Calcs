using System.Collections.Generic;
using System.Web.Mvc;

namespace KPK_CalcSite.Models
{
    public class MailModels
    {
        public static IList<SelectListItem> Coutries { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Country { get; set; }
        public string Message { get; set; }

        static MailModels()
        {
            var group = new SelectListGroup() { Name = "Countries" };

            Coutries = new List<SelectListItem>();
            Coutries.Add(new SelectListItem()
            {
                Text = "Poland",
                Value = "Poland",
                Selected = true
            });
            Coutries.Add(new SelectListItem()
            {
                Text = "Czech Republic",
                Value = "Czech Republic",
                Group = group,
            });
            Coutries.Add(new SelectListItem()
            {
                Text = "Denmark",
                Value = "Denmark",
                Group = group,
            });
            Coutries.Add(new SelectListItem()
            {
                Text = "Finland",
                Value = "Finland",
                Group = group,
            });
            Coutries.Add(new SelectListItem()
            {
                Text = "France",
                Value = "France",
                Group = group,
            });
            Coutries.Add(new SelectListItem()
            {
                Text = "Germany",
                Value = "Germany",
                Group = group,
            });
            Coutries.Add(new SelectListItem()
            {
                Text = "Greece",
                Value = "Greece",
                Group = group,
            });
            Coutries.Add(new SelectListItem()
            {
                Text = "Norway",
                Value = "Norway",
                Group = group,
            });
            Coutries.Add(new SelectListItem()
            {
                Text = "Sweden",
                Value = "Sweden",
                Group = group,
            });
            Coutries.Add(new SelectListItem()
            {
                Text = "Other",
                Value = "Other",
                Group = new SelectListGroup() { Name = "Other" },
            });
        }
    }
}