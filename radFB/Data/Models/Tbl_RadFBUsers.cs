namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_RadFBUsers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_RadFBUsers()
        {
            Tbl_activeSesion = new HashSet<Tbl_activeSesion>();
            Tbl_activities = new HashSet<Tbl_activities>();
            Tbl_AnswerToQuestion = new HashSet<Tbl_AnswerToQuestion>();
            Tbl_awards = new HashSet<Tbl_awards>();
            Tbl_BlockedUsers = new HashSet<Tbl_BlockedUsers>();
            Tbl_BlockedUsers1 = new HashSet<Tbl_BlockedUsers>();
            Tbl_BlockedUsers2 = new HashSet<Tbl_BlockedUsers>();
            Tbl_calender = new HashSet<Tbl_calender>();
            Tbl_CommentLike = new HashSet<Tbl_CommentLike>();
            Tbl_criticsAndSuggestions = new HashSet<Tbl_criticsAndSuggestions>();
            Tbl_DeclarationOfReadiness = new HashSet<Tbl_DeclarationOfReadiness>();
            Tbl_EmploymentAdvApply = new HashSet<Tbl_EmploymentAdvApply>();
            Tbl_followers = new HashSet<Tbl_followers>();
            Tbl_followers1 = new HashSet<Tbl_followers>();
            Tbl_group = new HashSet<Tbl_group>();
            Tbl_groupException = new HashSet<Tbl_groupException>();
            Tbl_groupMessages = new HashSet<Tbl_groupMessages>();
            Tbl_legalClient = new HashSet<Tbl_legalClient>();
            Tbl_Logins = new HashSet<Tbl_Logins>();
            Tbl_memberOfGroup = new HashSet<Tbl_memberOfGroup>();
            Tbl_messages = new HashSet<Tbl_messages>();
            Tbl_messages1 = new HashSet<Tbl_messages>();
            Tbl_messagesException = new HashSet<Tbl_messagesException>();
            Tbl_messagesException1 = new HashSet<Tbl_messagesException>();
            Tbl_muteGroupMessage = new HashSet<Tbl_muteGroupMessage>();
            Tbl_muteMessages = new HashSet<Tbl_muteMessages>();
            Tbl_MuteUsers = new HashSet<Tbl_MuteUsers>();
            Tbl_MuteUsers1 = new HashSet<Tbl_MuteUsers>();
            Tbl_notifications = new HashSet<Tbl_notifications>();
            Tbl_pay = new HashSet<Tbl_pay>();
            Tbl_pointsDetail = new HashSet<Tbl_pointsDetail>();
            Tbl_post = new HashSet<Tbl_post>();
            Tbl_postChanged = new HashSet<Tbl_postChanged>();
            Tbl_postChangedException = new HashSet<Tbl_postChangedException>();
            Tbl_postChangedException1 = new HashSet<Tbl_postChangedException>();
            Tbl_PostForward = new HashSet<Tbl_PostForward>();
            Tbl_PostForward1 = new HashSet<Tbl_PostForward>();
            Tbl_PostLike = new HashSet<Tbl_PostLike>();
            Tbl_privacy = new HashSet<Tbl_privacy>();
            //Tbl_Question = new HashSet<Tbl_Question>();
            Tbl_questionFilter = new HashSet<Tbl_questionFilter>();
            //Tbl_questionnaire = new HashSet<Tbl_questionnaire>();
            Tbl_questionnaireFilter = new HashSet<Tbl_questionnaireFilter>();
            Tbl_RealCient = new HashSet<Tbl_RealCient>();
            Tbl_reportUsers = new HashSet<Tbl_reportUsers>();
            Tbl_reportUsers1 = new HashSet<Tbl_reportUsers>();
            Tbl_savedQuestion = new HashSet<Tbl_savedQuestion>();
            Tbl_savedQuestionnaire = new HashSet<Tbl_savedQuestionnaire>();
            Tbl_savedTopics = new HashSet<Tbl_savedTopics>();
            Tbl_silentUsers = new HashSet<Tbl_silentUsers>();
            Tbl_silentUsers1 = new HashSet<Tbl_silentUsers>();
            Tbl_story = new HashSet<Tbl_story>();
            Tbl_storySeen = new HashSet<Tbl_storySeen>();
            Tbl_SuggestionUsers = new HashSet<Tbl_SuggestionUsers>();
            Tbl_SuggestionUsers1 = new HashSet<Tbl_SuggestionUsers>();
            Tbl_userBackGroundSetting = new HashSet<Tbl_userBackGroundSetting>();
            Tbl_userDiscount = new HashSet<Tbl_userDiscount>();
            Tbl_UserEducationalBackground = new HashSet<Tbl_UserEducationalBackground>();
            Tbl_UserFavorites = new HashSet<Tbl_UserFavorites>();
            Tbl_UserJobStatus = new HashSet<Tbl_UserJobStatus>();
            Tbl_UserRegistrationCourses = new HashSet<Tbl_UserRegistrationCourses>();
            Tbl_userSetting = new HashSet<Tbl_userSetting>();
            Tbl_usersQuestions = new HashSet<Tbl_usersQuestions>();
            Tbl_usersSearchs = new HashSet<Tbl_usersSearchs>();
            Tbl_UsersSkills = new HashSet<Tbl_UsersSkills>();
            Tbl_UserWorkExperience = new HashSet<Tbl_UserWorkExperience>();
            Tbl_UserWorkExperienceStamp = new HashSet<Tbl_UserWorkExperienceStamp>();
            Tbl_UserWorkExperienceStamp1 = new HashSet<Tbl_UserWorkExperienceStamp>();
            Tbl_VisitedPosts = new HashSet<Tbl_VisitedPosts>();
            Tbl_Voluntaryworks = new HashSet<Tbl_Voluntaryworks>();
        }

        [Key]
        public long RadFbUserID { get; set; }

        public string userName { get; set; }

        public string Password { get; set; }

        public string email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string phoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public int fk_countryID { get; set; }

        public long fk_provinceID { get; set; }

        public long fk_jobCategoryID { get; set; }

        public int fk_userTypeID { get; set; }

        public string interdusedEmail { get; set; }

        public string UserAddress { get; set; }

        public string UserPic { get; set; }

        public string UserWebsite { get; set; }

        public string RegisterDate { get; set; }

        public string lastSeenDate { get; set; }

        public bool userStatus { get; set; }

        public string city { get; set; }

        public bool DeleteStatus { get; set; }

        public string inactiveDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_activeSesion> Tbl_activeSesion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_activities> Tbl_activities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_AnswerToQuestion> Tbl_AnswerToQuestion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_awards> Tbl_awards { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_BlockedUsers> Tbl_BlockedUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_BlockedUsers> Tbl_BlockedUsers1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_BlockedUsers> Tbl_BlockedUsers2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_calender> Tbl_calender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_CommentLike> Tbl_CommentLike { get; set; }

        public virtual Tbl_countries Tbl_countries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_criticsAndSuggestions> Tbl_criticsAndSuggestions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DeclarationOfReadiness> Tbl_DeclarationOfReadiness { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_EmploymentAdvApply> Tbl_EmploymentAdvApply { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_followers> Tbl_followers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_followers> Tbl_followers1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_group> Tbl_group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_groupException> Tbl_groupException { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_groupMessages> Tbl_groupMessages { get; set; }

        public virtual Tbl_jobCategory Tbl_jobCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_legalClient> Tbl_legalClient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Logins> Tbl_Logins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_memberOfGroup> Tbl_memberOfGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_messages> Tbl_messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_messages> Tbl_messages1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_messagesException> Tbl_messagesException { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_messagesException> Tbl_messagesException1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_muteGroupMessage> Tbl_muteGroupMessage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_muteMessages> Tbl_muteMessages { get; set; }

        public virtual Tbl_muteMessages Tbl_muteMessages1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_MuteUsers> Tbl_MuteUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_MuteUsers> Tbl_MuteUsers1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_notifications> Tbl_notifications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_pay> Tbl_pay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_pointsDetail> Tbl_pointsDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_post> Tbl_post { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_postChanged> Tbl_postChanged { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_postChangedException> Tbl_postChangedException { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_postChangedException> Tbl_postChangedException1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_PostForward> Tbl_PostForward { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_PostForward> Tbl_PostForward1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_PostLike> Tbl_PostLike { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_privacy> Tbl_privacy { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Tbl_Question> Tbl_Question { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_questionFilter> Tbl_questionFilter { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Tbl_questionnaire> Tbl_questionnaire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_questionnaireFilter> Tbl_questionnaireFilter { get; set; }

        public virtual Tbl_userType Tbl_userType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_RealCient> Tbl_RealCient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_reportUsers> Tbl_reportUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_reportUsers> Tbl_reportUsers1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_savedQuestion> Tbl_savedQuestion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_savedQuestionnaire> Tbl_savedQuestionnaire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_savedTopics> Tbl_savedTopics { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_silentUsers> Tbl_silentUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_silentUsers> Tbl_silentUsers1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_story> Tbl_story { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_storySeen> Tbl_storySeen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_SuggestionUsers> Tbl_SuggestionUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_SuggestionUsers> Tbl_SuggestionUsers1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_userBackGroundSetting> Tbl_userBackGroundSetting { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_userDiscount> Tbl_userDiscount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserEducationalBackground> Tbl_UserEducationalBackground { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserFavorites> Tbl_UserFavorites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserJobStatus> Tbl_UserJobStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserRegistrationCourses> Tbl_UserRegistrationCourses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_userSetting> Tbl_userSetting { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_usersQuestions> Tbl_usersQuestions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_usersSearchs> Tbl_usersSearchs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UsersSkills> Tbl_UsersSkills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserWorkExperience> Tbl_UserWorkExperience { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserWorkExperienceStamp> Tbl_UserWorkExperienceStamp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UserWorkExperienceStamp> Tbl_UserWorkExperienceStamp1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_VisitedPosts> Tbl_VisitedPosts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Voluntaryworks> Tbl_Voluntaryworks { get; set; }
    }
}
