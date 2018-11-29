using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class Photo
    {
        public int PhotoID { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayName("Picture")]
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Createate")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yy}")]
        public DateTime CreateDate { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Comment>Comments { get; set; }
    }
}