using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RG.Application.ViewModel.AlgoHR.Business.Training
{
    public class TrainingCreateVM
    {
        public int ID { get; set; }
        [Display(Name = "Training Type")]
        public int TrainingTypeID { get; set; }
        [Display(Name = "Training Name")]
        public string TrainingName { get; set; }
        [Display(Name = "Description")]
        public string TrainingDescription { get; set; }
        [Display(Name = "Document Type")]
        public int DocumentTypeID { get; set; }
        [Display(Name = "File Serial")]
        public int FileSerial { get; set; }
        [Display(Name = "File Title")]
        public string FileTitle { get; set; }
        [Display(Name = "File Extension")]
        public string FileExtension { get; set; }
        [Display(Name = "File Url")]
        public string FileUrl { get; set; }
        [Display(Name = "Upload File")]
        public string UploadFile { get; set; }
        [Display(Name = "External File")]
        public bool IsExternalFile { get; set; }

        //[Required(ErrorMessage = "Please select file.")]
        //[Display(Name = "Browse File")]
        //public HttpPostedFileBase[] files { get; set; }
        public List<SelectListItem> DDLDocumentType { get; set; }
        public List<SelectListItem> DDLFileSerial { get; set; }
        public List<SelectListItem> DDLFileExtension { get; set; }
        public List<SelectListItem> DDLTrainingType { get; set; }
        

    }
}
