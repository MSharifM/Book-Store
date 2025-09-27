using System.ComponentModel.DataAnnotations;

namespace BookStore.DataLayer.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [MaxLength(150, ErrorMessage = "نام کتاب نمی تواند بیشتر از 150 کاراکتر باشد.")]
        [Required(ErrorMessage = "لطفا نام کتاب را وارد کنید.")]
        [Display(Name = "نام کتاب")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا کد شابک را وارد کنید.")]
        [Display(Name = "کد شابک")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "کد شابک باید ۱۳ رقم باشد.")]
        public string ShahbakCode { get; set; }

        [MaxLength(150, ErrorMessage = "نام نویسنده نمی تواند بیشتر از 150 کاراکتر باشد.")]
        [Required(ErrorMessage = "لطفا نام نویسنده را وارد کنید.")]
        [Display(Name = "نام نویسنده")]
        public string Author { get; set; }

        [MaxLength(150, ErrorMessage = "نام انتشارات نمی تواند بیشتر از 150 کاراکتر باشد.")]
        [Required(ErrorMessage = "لطفا نام انتشارات را وارد کنید.")]
        [Display(Name = "نام انتشارات")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ انتشار را وارد کنید.")]
        [Display(Name = "تاریخ انتشار")]
        public DateTime DatePublishing { get; set; }

        [Required(ErrorMessage = "لطفا قیمت کتاب را وارد کنید.")]
        [Display(Name = "قیمت کتاب")]
        public int Price { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "فایل نمونه")]
        public string DemoFile { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا تصویر کتاب را وارد کنید.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "لطفا تعداد موجودی کتاب را وارد کنید.")]
        [Display(Name = "تعداد موجودی")]
        public int CountExist { get; set; }

        public bool IsDelete { get; set; }
    }
}
