namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_RadFBUsers
    {
        public Tbl_RadFBUsers()
        {
            this.ActiveSessions = new HashSet<Tbl_activeSesion>();
            this.AnswerToQuestions = new HashSet<Tbl_AnswerToQuestion>();
            this.Awards = new HashSet<Tbl_awards>();
            this.BlockedUsers = new HashSet<Tbl_BlockedUsers>();
            this.Calendars = new HashSet<Tbl_calender>();
            this.CommentLikes = new HashSet<Tbl_CommentLike>();
            this.Criticism = new HashSet<Tbl_criticsAndSuggestions>();
            this.Declarations = new HashSet<Tbl_DeclarationOfReadiness>();
            this.Posts = new HashSet<Tbl_post>();
            this.EmploymentAdvApplies = new HashSet<Tbl_EmploymentAdvApply>();
            this.Followers = new HashSet<Tbl_followers>();
            this.Groups = new HashSet<Tbl_group>();
            this.GroupExceptions = new HashSet<Tbl_groupException>();
            this.GroupMessages = new HashSet<Tbl_groupMessages>();
            this.LegalClients = new HashSet<Tbl_legalClient>();
            this.Logins = new HashSet<Tbl_Logins>();
            this.MemberOfGroups = new HashSet<Tbl_memberOfGroup>();
            this.Messages = new HashSet<Tbl_messages>();
            this.MessagesExceptions = new HashSet<Tbl_messagesException>();
            this.MuteGroupMessages = new HashSet<Tbl_muteGroupMessage>();
            this.MuteMessages = new HashSet<Tbl_muteMessages>();
            this.MuteUsers = new HashSet<Tbl_MuteUsers>();
            this.Notifications = new HashSet<Tbl_notifications>();
            this.Pays = new HashSet<Tbl_pay>();
            this.PointsDetails = new HashSet<Tbl_pointsDetail>();
            this.PostsChanged = new HashSet<Tbl_postChanged>();
            this.PostChangedExceptions = new HashSet<Tbl_postChangedException>();
            this.Posters = new HashSet<Tbl_poster>();
            this.PostForwards = new HashSet<Tbl_PostForward>();
            this.PostLikes = new HashSet<Tbl_PostLike>();
            this.Privacy = new HashSet<Tbl_privacy>();
            this.QuestionFilters = new HashSet<Tbl_questionFilter>();
            this.QuestionnaireFilters = new HashSet<Tbl_questionnaireFilter>();
            this.RealCients = new HashSet<Tbl_RealCient>();
            this.ReportUsers = new HashSet<Tbl_reportUsers>();
            this.SavedQuestions = new HashSet<Tbl_savedQuestion>();
            this.SavedQuestionnaires = new HashSet<Tbl_savedQuestionnaire>();
            this.SavedTopics = new HashSet<Tbl_savedTopics>();
            this.SilentUsers = new HashSet<Tbl_silentUsers>();
            this.Stories = new HashSet<Tbl_story>();
            this.StorySeen = new HashSet<Tbl_storySeen>();
            this.SuggestionUsers = new HashSet<Tbl_SuggestionUsers>();
            this.UserBackGroundSettings = new HashSet<Tbl_userBackGroundSetting>();
            this.UserDiscounts = new HashSet<Tbl_userDiscount>();
            this.UserEducationalBackgrounds = new HashSet<Tbl_UserEducationalBackground>();
            this.UserFavorites = new HashSet<Tbl_UserFavorites>();
            this.UserJobStatus = new HashSet<Tbl_UserJobStatus>();
            this.UserRegistrationCourses = new HashSet<Tbl_UserRegistrationCourses>();
            this.UserSettings = new HashSet<Tbl_userSetting>();
            this.UsersPackages = new HashSet<Tbl_UsersPackage>();
            this.UsersQuestions = new HashSet<Tbl_usersQuestions>();
            this.UsersSearchs = new HashSet<Tbl_usersSearchs>();
            this.UsersSkills = new HashSet<Tbl_UsersSkills>();
            this.UserWorkExperiences = new HashSet<Tbl_UserWorkExperience>();
            this.UserWorkExperienceStamps = new HashSet<Tbl_UserWorkExperienceStamp>();
            this.VisitedPosts = new HashSet<Tbl_VisitedPosts>();
            this.Voluntaryworks = new HashSet<Tbl_Voluntaryworks>();
            this.Activities = new HashSet<Tbl_activities>();


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

        [ForeignKey("fk_countryID")]
        public Tbl_countries Countries { get; set; }

        [ForeignKey("fk_provinceID")]
        public Tbl_province Provinces { get; set; }

        [ForeignKey("fk_jobCategoryID")]
        public Tbl_jobCategory JobCategories { get; set; }

        [ForeignKey("fk_userTypeID")]
        public Tbl_userType UserTypes { get; set; }


        public virtual ICollection<Tbl_activeSesion> ActiveSessions { get; set; }
        public virtual ICollection<Tbl_AnswerToQuestion> AnswerToQuestions { get; set; }
        public virtual ICollection<Tbl_awards> Awards { get; set; }
        public virtual ICollection<Tbl_BlockedUsers> BlockedUsers { get; set; }
        public virtual ICollection<Tbl_calender> Calendars { get; set; }
        public virtual ICollection<Tbl_CommentLike> CommentLikes { get; set; }
        public virtual ICollection<Tbl_criticsAndSuggestions> Criticism { get; set; }
        public virtual ICollection<Tbl_DeclarationOfReadiness> Declarations { get; set; }
        public virtual ICollection<Tbl_post> Posts { get; set; }
        public virtual ICollection<Tbl_EmploymentAdvApply> EmploymentAdvApplies { get; set; }
        public virtual ICollection<Tbl_followers> Followers { get; set; }
        public virtual ICollection<Tbl_group> Groups { get; set; }
        public virtual ICollection<Tbl_groupException> GroupExceptions { get; set; }
        public virtual ICollection<Tbl_groupMessages> GroupMessages { get; set; }
        public virtual ICollection<Tbl_legalClient> LegalClients { get; set; }
        public virtual ICollection<Tbl_Logins> Logins { get; set; }
        public virtual ICollection<Tbl_memberOfGroup> MemberOfGroups { get; set; }
        public virtual ICollection<Tbl_messages> Messages { get; set; }
        public virtual ICollection<Tbl_messagesException> MessagesExceptions { get; set; }
        public virtual ICollection<Tbl_muteGroupMessage> MuteGroupMessages { get; set; }
        public virtual ICollection<Tbl_muteMessages> MuteMessages { get; set; }
        public virtual ICollection<Tbl_MuteUsers> MuteUsers { get; set; }
        public virtual ICollection<Tbl_notifications> Notifications { get; set; }
        public virtual ICollection<Tbl_pay> Pays { get; set; }
        public virtual ICollection<Tbl_pointsDetail> PointsDetails { get; set; }
        public virtual ICollection<Tbl_postChanged> PostsChanged { get; set; }
        public virtual ICollection<Tbl_postChangedException> PostChangedExceptions { get; set; }
        public virtual ICollection<Tbl_poster> Posters { get; set; }
        public virtual ICollection<Tbl_PostForward> PostForwards { get; set; }
        public virtual ICollection<Tbl_PostLike> PostLikes { get; set; }
        public virtual ICollection<Tbl_privacy> Privacy { get; set; }
        public virtual ICollection<Tbl_questionFilter> QuestionFilters { get; set; }
        public virtual ICollection<Tbl_questionnaireFilter> QuestionnaireFilters { get; set; }
        public virtual ICollection<Tbl_RealCient> RealCients { get; set; }
        public virtual ICollection<Tbl_reportUsers> ReportUsers { get; set; }
        public virtual ICollection<Tbl_savedQuestion> SavedQuestions { get; set; }
        public virtual ICollection<Tbl_savedQuestionnaire> SavedQuestionnaires { get; set; }
        public virtual ICollection<Tbl_savedTopics> SavedTopics { get; set; }
        public virtual ICollection<Tbl_silentUsers> SilentUsers { get; set; }
        public virtual ICollection<Tbl_story> Stories { get; set; }
        public virtual ICollection<Tbl_storySeen> StorySeen { get; set; }
        public virtual ICollection<Tbl_SuggestionUsers> SuggestionUsers { get; set; }
        public virtual ICollection<Tbl_userBackGroundSetting> UserBackGroundSettings { get; set; }
        public virtual ICollection<Tbl_userDiscount> UserDiscounts { get; set; }
        public virtual ICollection<Tbl_UserEducationalBackground> UserEducationalBackgrounds { get; set; }
        public virtual ICollection<Tbl_UserFavorites> UserFavorites { get; set; }
        public virtual ICollection<Tbl_UserJobStatus> UserJobStatus { get; set; }
        public virtual ICollection<Tbl_UserRegistrationCourses> UserRegistrationCourses { get; set; }
        public virtual ICollection<Tbl_userSetting> UserSettings { get; set; }
        public virtual ICollection<Tbl_UsersPackage> UsersPackages { get; set; }
        public virtual ICollection<Tbl_usersQuestions> UsersQuestions { get; set; }
        public virtual ICollection<Tbl_usersSearchs> UsersSearchs { get; set; }
        public virtual ICollection<Tbl_UsersSkills> UsersSkills { get; set; }
        public virtual ICollection<Tbl_UserWorkExperience> UserWorkExperiences { get; set; }
        public virtual ICollection<Tbl_UserWorkExperienceStamp> UserWorkExperienceStamps { get; set; }
        public virtual ICollection<Tbl_VisitedPosts> VisitedPosts { get; set; }
        public virtual ICollection<Tbl_Voluntaryworks> Voluntaryworks { get; set; }
        public virtual ICollection<Tbl_activities> Activities { get; set; }

    }
}
