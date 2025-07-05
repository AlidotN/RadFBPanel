using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RadFBApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadFBApp.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=185.2.14.219\\MSSQLSERVER2017;database=radfbDB;User ID=radfbcom; Password=6yO62Gbjy4;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_FrequentlyAskedQuestions>().HasQueryFilter(u => !u.DeleteStatus);
        }

        public virtual DbSet<postType> postType { get; set; }
        public virtual DbSet<Tbl_activeSesion> Tbl_activeSesion { get; set; }
        public virtual DbSet<Tbl_activities> Tbl_activities { get; set; }
        public virtual DbSet<Tbl_AnswerToQuestion> Tbl_AnswerToQuestion { get; set; }
        public virtual DbSet<Tbl_awards> Tbl_awards { get; set; }
        public virtual DbSet<Tbl_BlockedUsers> Tbl_BlockedUsers { get; set; }
        public virtual DbSet<Tbl_calender> Tbl_calender { get; set; }
        public virtual DbSet<Tbl_CommentLike> Tbl_CommentLike { get; set; }
        public virtual DbSet<Tbl_CooperationType> Tbl_CooperationType { get; set; }
        public virtual DbSet<Tbl_countries> Tbl_countries { get; set; }
        public virtual DbSet<Tbl_criticsAndSuggestions> Tbl_criticsAndSuggestions { get; set; }
        public virtual DbSet<Tbl_DeclarationOfReadiness> Tbl_DeclarationOfReadiness { get; set; }
        public virtual DbSet<Tbl_dialog> Tbl_dialog { get; set; }
        public virtual DbSet<Tbl_discount> Tbl_discount { get; set; }
        public virtual DbSet<Tbl_EmploymentAdvApply> Tbl_EmploymentAdvApply { get; set; }
        public virtual DbSet<Tbl_EmploymentAdvPost> Tbl_EmploymentAdvPost { get; set; }
        public virtual DbSet<Tbl_factor> Tbl_factor { get; set; }
        public virtual DbSet<Tbl_followers> Tbl_followers { get; set; }
        public virtual DbSet<Tbl_FrequentlyAskedQuestions> Tbl_FrequentlyAskedQuestions { get; set; }
        public virtual DbSet<Tbl_FrequentlyAskedQuestionsSubject> Tbl_FrequentlyAskedQuestionsSubject { get; set; }
        public virtual DbSet<Tbl_gender> Tbl_gender { get; set; }
        public virtual DbSet<Tbl_grade> Tbl_grade { get; set; }
        public virtual DbSet<Tbl_group> Tbl_group { get; set; }
        public virtual DbSet<Tbl_groupException> Tbl_groupException { get; set; }
        public virtual DbSet<Tbl_groupMessages> Tbl_groupMessages { get; set; }
        public virtual DbSet<Tbl_guild> Tbl_guild { get; set; }
        public virtual DbSet<Tbl_Introduction> Tbl_Introduction { get; set; }
        public virtual DbSet<Tbl_jobCategory> Tbl_jobCategory { get; set; }
        public virtual DbSet<Tbl_jobStatus> Tbl_jobStatus { get; set; }
        public virtual DbSet<Tbl_keyWords> Tbl_keyWords { get; set; }
        public virtual DbSet<Tbl_legalClient> Tbl_legalClient { get; set; }
        public virtual DbSet<Tbl_Logins> Tbl_Logins { get; set; }
        public virtual DbSet<Tbl_major> Tbl_major { get; set; }
        public virtual DbSet<Tbl_memberOfGroup> Tbl_memberOfGroup { get; set; }
        public virtual DbSet<Tbl_messages> Tbl_messages { get; set; }
        public virtual DbSet<Tbl_messagesException> Tbl_messagesException { get; set; }
        public virtual DbSet<Tbl_messageType> Tbl_messageType { get; set; }
        public virtual DbSet<Tbl_militaryServiceSituation> Tbl_militaryServiceSituation { get; set; }
        public virtual DbSet<Tbl_muteGroupMessage> Tbl_muteGroupMessage { get; set; }
        public virtual DbSet<Tbl_muteMessages> Tbl_muteMessages { get; set; }
        public virtual DbSet<Tbl_MuteUsers> Tbl_MuteUsers { get; set; }
        public virtual DbSet<Tbl_notifications> Tbl_notifications { get; set; }
        public virtual DbSet<Tbl_packageOptions> Tbl_packageOptions { get; set; }
        public virtual DbSet<Tbl_pay> Tbl_pay { get; set; }
        public virtual DbSet<Tbl_permiumPackage> Tbl_permiumPackage { get; set; }
        public virtual DbSet<Tbl_points> Tbl_points { get; set; }
        public virtual DbSet<Tbl_pointsDetail> Tbl_pointsDetail { get; set; }
        public virtual DbSet<Tbl_post> Tbl_post { get; set; }
        public virtual DbSet<Tbl_postChanged> Tbl_postChanged { get; set; }
        public virtual DbSet<Tbl_postChangedException> Tbl_postChangedException { get; set; }
        public virtual DbSet<Tbl_poster> Tbl_poster { get; set; }
        public virtual DbSet<Tbl_posterFilter> Tbl_posterFilter { get; set; }
        public virtual DbSet<Tbl_posterTemplate> Tbl_posterTemplate { get; set; }
        public virtual DbSet<Tbl_PostFile> Tbl_PostFile { get; set; }
        public virtual DbSet<Tbl_PostForward> Tbl_PostForward { get; set; }
        public virtual DbSet<Tbl_PostLike> Tbl_PostLike { get; set; }
        public virtual DbSet<Tbl_privacy> Tbl_privacy { get; set; }
        public virtual DbSet<Tbl_province> Tbl_province { get; set; }
        public virtual DbSet<Tbl_Question> Tbl_Question { get; set; }
        public virtual DbSet<Tbl_questionFilter> Tbl_questionFilter { get; set; }
        public virtual DbSet<Tbl_questionnaire> Tbl_questionnaire { get; set; }
        public virtual DbSet<Tbl_questionnaireFilter> Tbl_questionnaireFilter { get; set; }
        public virtual DbSet<Tbl_RadFBUsers> Tbl_RadFBUsers { get; set; }
        public virtual DbSet<Tbl_RealCient> Tbl_RealCient { get; set; }
        public virtual DbSet<Tbl_reportUsers> Tbl_reportUsers { get; set; }
        public virtual DbSet<Tbl_savedQuestion> Tbl_savedQuestion { get; set; }
        public virtual DbSet<Tbl_savedQuestionnaire> Tbl_savedQuestionnaire { get; set; }
        public virtual DbSet<Tbl_savedTopics> Tbl_savedTopics { get; set; }
        public virtual DbSet<Tbl_setting> Tbl_setting { get; set; }
        public virtual DbSet<Tbl_silentUsers> Tbl_silentUsers { get; set; }
        public virtual DbSet<Tbl_siteSetting> Tbl_siteSetting { get; set; }
        public virtual DbSet<Tbl_Skills> Tbl_Skills { get; set; }
        public virtual DbSet<Tbl_story> Tbl_story { get; set; }
        public virtual DbSet<Tbl_storySeen> Tbl_storySeen { get; set; }
        public virtual DbSet<Tbl_subject> Tbl_subject { get; set; }
        public virtual DbSet<Tbl_SuggestionUsers> Tbl_SuggestionUsers { get; set; }
        public virtual DbSet<Tbl_UnauthorizedWords> Tbl_UnauthorizedWords { get; set; }
        public virtual DbSet<Tbl_userAccess> Tbl_userAccess { get; set; }
        public virtual DbSet<Tbl_userBackGroundSetting> Tbl_userBackGroundSetting { get; set; }
        public virtual DbSet<Tbl_userDiscount> Tbl_userDiscount { get; set; }
        public virtual DbSet<Tbl_UserEducationalBackground> Tbl_UserEducationalBackground { get; set; }
        public virtual DbSet<Tbl_UserFavorites> Tbl_UserFavorites { get; set; }
        public virtual DbSet<Tbl_UserJobStatus> Tbl_UserJobStatus { get; set; }
        public virtual DbSet<Tbl_UserRegistrationCourses> Tbl_UserRegistrationCourses { get; set; }
        public virtual DbSet<Tbl_userSetting> Tbl_userSetting { get; set; }
        public virtual DbSet<Tbl_usersQuestions> Tbl_usersQuestions { get; set; }
        public virtual DbSet<Tbl_usersSearchs> Tbl_usersSearchs { get; set; }
        public virtual DbSet<Tbl_UsersSkills> Tbl_UsersSkills { get; set; }
        public virtual DbSet<Tbl_userType> Tbl_userType { get; set; }
        public virtual DbSet<Tbl_UserWorkExperience> Tbl_UserWorkExperience { get; set; }
        public virtual DbSet<Tbl_UserWorkExperienceStamp> Tbl_UserWorkExperienceStamp { get; set; }
        public virtual DbSet<Tbl_VisitedPosts> Tbl_VisitedPosts { get; set; }
        public virtual DbSet<Tbl_Voluntaryworks> Tbl_Voluntaryworks { get; set; }
        public virtual DbSet<maritalStatus> Tbl_maritalStatus { get; set; }
        public virtual DbSet<Tbl_UsersPackage> Tbl_UsersPackage { get; set; }
        public virtual DbSet<Tbl_questionnaireTemplate> Tbl_questionnaireTemplate { get; set; }
        public virtual DbSet<Tbl_PanelActivities> Tbl_PanelActivities { get; set; }
    }
}
