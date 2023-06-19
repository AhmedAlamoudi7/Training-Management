namespace TrainingManagement.Core.Constants
{
    public static class Message
    {
        public const string RegularExpPhone = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public const string Password = "Password";
        //public const string RegularExpEmail = @"[a-z0-9]+@[a-z]+\.[a-z]{2,3}";
        public const string DescriptionFName = "الاسم الأول";
        public const string DescriptionTitle = "العنوان";
        public const string DescriptionTitleFirst = "العنوان الأول";
        public const string DescriptionTitleSecond = "العنوان الثاني";
        public const string DescriptionTitleThird = "العنوان الثالث";
        public const string Description = "الوصف";
        public const string DescriptionFirst = "الوصف الأول"; 
        public const string DescriptionFullName = "الاسم كامل";

        public const string DescriptionSecond = "الوصف الثاني";
        public const string DescriptionThird = "الوصف الثالث";

        public const string DescriptionName = "الاسم";
        public const string DescriptionLName = "الاسم الاخير";
        public const string DescriptionPhone = "رقم الهاتف";
        public const string DescriptionEmail = "البريد الالكتروني";
        public const string DescriptionCountry = "الدولة";
        public const string DescriptionSpecialization = "التخصص";
        public const string DescriptionDegree = "الدرجة العلمية";
        public const string DescriptionPassword = "كلمة المرور";
        public const string DescriptionConfirmPassword = "تأكيد كلمة المرور";
        public const string DescriptionImage = "الصورة الشخصية";
        public const string DescriptionCV = "السيرة الذاتية";
        public const string DescriptionSkills = "المهارات";
        public const string DescriptionWrittenBy = "المهارات";
        public const string DescriptionMessage = "الرسالة";
        public const string DescriptionAcceptTerms = "الموافقة على سياسة الخصوصية";
        public const string DescriptionIcon = "صورة 'Icon'";


        public const string DescriptionFaceBook = " رابط فيسبوك";
        public const string DescriptionTwitter = " رابط تويتر";
        public const string DescriptionInstagram = " رابط الانسجرام";
        public const string DescriptionWhatsapp = " رقم الواتس اب";
        public const string DescriptionLinkedIn = " رابط لينكد ان";


        public const int MinLength3 = 3;
        public const int MinLength6 = 6;
        public const int MaxLength100 = 100;
        public const int MaxLength200 = 200;
        public const int MaxLength400 = 400;

        public static class ErrorMessage
        {
            public const string Max100_Min3Length = "يجب أن يكون {0} على الأقل {3} والحد الأقصى {100} من الأحرف.";
            public const string Max100_Min6Length = "يجب أن يكون {0} على الأقل {6} والحد الأقصى {100} من الأحرف.";
            public const string Max200_Min6Length = "يجب أن يكون {0} على الأقل {6} والحد الأقصى {200} من الأحرف.";
            public const string Max400_Min6Length = "يجب أن يكون {0} على الأقل {6} والحد الأقصى {400} من الأحرف.";
            public const string Max800_Min6Length = "يجب أن يكون {0} على الأقل {6} والحد الأقصى {800} من الأحرف.";
            public const string Max10000_Min6Length = "يجب أن يكون {0} على الأقل {6} والحد الأقصى {10000} من الأحرف.";

            public const string RightPhoneEnter = "05XXXXXXX or 05XXXXXXX  الرجاء ادخال رقم موبايل صحيح";
            public const string PassAndConfirmPassNotSame = "كلمة المرور وكلمة المرور التأكيدية غير متطابقتين.";
            public const string RequiredField = "هذا الحقل مطلوب.";
        }
        public static class MessageEmail
        {
            public const string ActiveCode = "كود تفعيل الحساب";
            public const string ResetPassword = "إعادة تعيين كلمة مرور الحساب";
            public const string ActiveConsulting = "تفعيل الاستشارة الخاصة بك";
            public const string UnReadMessage = "رسائل غير مقروءة";

        }
    }
}
