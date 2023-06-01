using Microsoft.AspNetCore.Http;

namespace TrainingManagement.Constants
{
    public static class Constant
    {

        public const string Adviser = "Adviser";
        public const string Email = "Email";
        public const string Image = "Image";
        public const string ImageUrl = "ImageUrl";
        public const int NumberOne = 1;
        public const int NumberZero = 0;
        public const int NumberTwilve = 12;
        public const int NumberTwinty = 20;
        public const int NumberFourHundred = 400;
        public const float twintyfivePrecentage = (float)0.25;

        public const string Palestine = "Palestine";


        public static class RolesFilter
        {
            public const string SuperAdmin = "SuperAdmin";
            public const string Admin = "Admin";
            public const string SuperAdminAndAdmin = "SuperAdmin,Admin";
            public const string UserAndAdvisor = "User,Adviser";
            public const string User = "User";
            public const string Adviser = "Adviser";
			public const string Trainee = "Trainee";
            public const string Manager = "Manager";
		}
        public static class Area
        {
            public const string ControlPanel = "ControlPanel";
            public const string ProfileAccount = "ProfileAccount";

        }
        public static class FilterFileExtentions
        {
            public const string png = ".png";
            public const string jpg = ".jpg";
            public const string svg = ".svg";
            public const string jpeg = ".jpeg";
            public const string pdf = ".pdf";
            public const string docx = ".docx";
            // 1mb = 1048576
            public const int _maxAllowedPosterSize = 1048576;

        }
        public static class ViewBag
        {
            //Specializations
            public const string titleSpecializations = "Specializations";
            public const string idSpecializations = "Id";
            public const string nameSpecializations = "Name";
            public const string adviserDetailes = "adviserDetailes";
            public const string UserDetailes = "userDetailes";

            //Adviser
            public const string titleAdviserImage = "AdviserImage";
            public const string titleAdviserskills = "Adviserskills";
			public const string totalTransaction = "TotalTransaction";

			//user
			public const string titleUsers = "Users";
            public const string titleUserImage = "UserImage";
            public const string titleImageMain = "ImageMain";
			public const string titleIcon= "Icon";

			//Degree
			public const string titleDegree = "Degree";
            public const string idDegree = "Id";
            public const string nameDegree = "Name";
            public const string Success = "success";


        }
        public static class DefaultImage
        {
            public const string ImagefileName = "default.jpeg";
            public const string path = "./wwwroot/Metronic/" + ImagefileName;
            public const string path2 = "./wwwroot/assets/" + ImagefileName;
            public const string FolderFileMessage = "FileMessage";
            public const string Images = "Images";

            public static IFormFile File = null;
        }
        public static class EmailTemplate
        {
            public const string userLink = "[userLink]";
            public const string userCode = "[userCode]";
            public const string Home = "[Home]";
            public const string TokenLink = "[TokenLink]";

        }
        public static class Response
        {
            public const string Email = "Email";
            public const string Roles = "Roles";
            public const string UserName = "UserName";
            public const string RolesSelect = "الرجاء اختار صلاحية واحدة على الأقل";
            public const string EmailIsExist = "البريد الالكتروني موجود بالفعل.";
            public const string UserIsExist = "المستخدم موجود بالفعل.";
            public const string UserNameIsExist = "اسم المستخدم موجود بالفعل.";
            public const string MaxLimit1MB = "الحد الأقصى للملف هو 1MB ?.";
            public const string FileDenied = " .pdf and .docx فقط مسموح !?.";
            public const string ImageDenied = " .jpg , .svg and .png فقط مسموح !?.";
            public const string Success = "لقد تم الاضافة بنجاح.";
            public const string Error = "يوجد حطأ بالبيانات.";
            public const string ErrorExistNotActiveWithDrawRequest = "لقد قمت بطلب سحب المبلغ من قبل وجاري التدقيق والسحب من طرف مدراء المنصة ...";
            public const string SuccessWithDrawRequest = " لقد قمت بطلب سحب المبلغ   وجاري التدقيق والسحب من طرف مدراء المنصة وسيتم التواصل والرد عبر البريد الالكتروني خلال 3 أيام  ...";

            public const string ErrorDateNow = "تاريخ الجلسة يجب أن يكون خلال اليوم او لاحقا بعد التوقيت الحالي";
            public const string ErrorDate = "تاريخ بداية الجلسة يجب ان تكون أقل من نهاية الجلسة.";
            public const string ErrorDenied = "يوجد جلسة محجوزة بالتاريخ والوقت المدخل.";
            public const string AlertSucsess = "نشكرك على تواصلك معنا سنرد قريبا على استفساراتك.";
            public const string LoginSucsess = " تم تسجيل الدخول الى الحساب.";
            public const string LogoutSucsess = " تم تسجيل الخروج من الحساب.";
            public const string EditSucsess = " تم التعديل على بيانات المستخدم ";
            public const string Payment = " تم الحجز بنجاح يرجى تاكيد الحجز عبر الدفع  ";
            public const string BalnceEquelZero = " عذراً رصيدك أقل من أو يساوي 0   ";

        }
        public static class Links
        {
            public const string ProgileHomeIndex = "/ProfileAccount/AccountProfileHome/Index";
            public const string ProgileHomeAdvisors = "/ProfileAccount/AccountProfileHome/Advisors";
            public const string ProfileHomeTrainees = "/ProfileAccount/AccountProfileHome/Trainees";
            public const string ProfileHomeManagers = "/ProfileAccount/AccountProfileHome/Managers";
            public const string ProfileHomeTrainingProgrammes = "/ProfileAccount/AccountProfileHome/TrainingProgrammes";
            public const string ProfileHomeTrainingProgrammesRequest = "/ProfileAccount/AccountProfileHome/TrainingProgrammesRequest";

            public const string ConfirmEmailWithUserIdParameter = "/ProfileAccount/AccountProfileUsers/ConfirmEmail?userId=";
            public const string Login = "~/Identity/Account/Login";
            public const string Logout = "~/Identity/Account/Logout";
            public const string ProfileUsersEditAdvisor = "~/ProfileAccount/AccountProfileAdvisors/EditAdvisor/";
            public const string ProfileUsersEditTrainee = "~/ProfileAccount/AccountProfileTrainees/In/";
             public const string ProfileUsersEditManager = "~/ProfileAccount/AccountProfileManagers/EditManager/";

            public const string ProfileUsersEditUser = "~/ProfileAccount/AccountProfileUsers/EditUser/";
            public const string ProfileUsersConsultationRequestData = "/ProfileAccount/AccountProfileUsers/ConsultationRequestData";
            public const string ProfileUsersPaymentData = "/ProfileAccount/AccountProfileUsers/Payment";
            public const string HomeClient = "/Home/Index";
            public const string ProfileUsersAdvisorDetailes = "/ProfileAccount/AccountProfileUsers/AdvisorDetailes/";
            public const string ProfileUsersCallBack = "/ProfileAccount/AccountProfileUsers/CallBack";
            public const string ProfileChat = "/ProfileAccount/AccountProfileChat/Index";
            public const string LogoutEndpoint = "/ProfileAccount/AccountProfileUsers/Logout";
            public const string ProfileUsersEditUser2 = "/ProfileAccount/AccountProfileUsers/EditUser/";


        }
        public static class Actions
        {
            public const string Index = "Index";
            public const string Edit = "Edit";
            public const string Create = "Create";
            public const string IndexExperienceSectionInAdvisorPage = "IndexExperiencesInExperienceSectionInAdvisorPage";
            public const string IndexCategorySectionInAdvisorPage = "IndexCategorySectionInAdvisorPage";
            public const string IndexListOfBeneficiariesInSectionInAdvisorPage = "IndexListOfBeneficiariesInSectionInAdvisorPage";
            public const string IndexSectionTwoHomePage = "IndexSectionTwoHomePage";
            public const string IndexSectionThreeHomePage = "IndexSectionThreeHomePage";

        }
    }
}
