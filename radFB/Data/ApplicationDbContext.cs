namespace radFB.db
{
    using System;  
    using System.ComponentModel.DataAnnotations.Schema;
    using radFB.Models;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.UseSqlServer("Server=LAPTOP\\MSSQL2017;Database=radfbDB;Trusted_Connection=True;MultipleActiveResultSets=true");
#else
            optionsBuilder.UseSqlServer("Server=185.10.74.111;Database=radfbDB;User ID=radfb; Password=Rf123456#;MultipleActiveResultSets=true");
#endif
        }

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        //{

        //}


        //public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        //public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }

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
        public virtual DbSet<Tbl_postSeen> Tbl_postSeen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


           
            //
            //modelBuilder.Entity<AspNetRoles>()
            //    .HasMany(e => e.AspNetRoleClaims)
            //    .WithOne(e => e.AspNetRoles).IsRequired()
            //    .HasForeignKey(e => e.RoleId);

            //modelBuilder.Entity<AspNetRoles>()
            //    .HasMany(e => e.AspNetUsers)
            //    .WithMany(e => e.AspNetRoles)
            //    .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            //modelBuilder.Entity<AspNetUsers>()
            //    .HasMany(e => e.AspNetUserClaims)
            //    .WithOne(e => e.AspNetUsers).IsRequired()
            //    .HasForeignKey(e => e.UserId);

            //modelBuilder.Entity<AspNetUsers>()
            //    .HasMany(e => e.AspNetUserLogins)
            //    .WithOne(e => e.AspNetUsers).IsRequired()
            //    .HasForeignKey(e => e.UserId);

            //modelBuilder.Entity<AspNetUsers>()
            //    .HasMany(e => e.AspNetUserTokens)
            //    .WithOne(e => e.AspNetUsers).IsRequired()
            //    .HasForeignKey(e => e.UserId);
            //



            modelBuilder.Entity<postType>()
                .HasMany(e => e.Tbl_post)
                .WithOne(e => e.postType).IsRequired()
                .HasForeignKey(e => e.fk_PostTypeID)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_AnswerToQuestion>()
                .HasMany(e => e.Tbl_AnswerToQuestion1)
                .WithOne(e => e.Tbl_AnswerToQuestion2).IsRequired()
                .HasForeignKey(e => e.ChildID);

            modelBuilder.Entity<Tbl_AnswerToQuestion>()
                .HasMany(e => e.Tbl_CommentLike)
                .WithOne(e => e.Tbl_AnswerToQuestion).IsRequired()
                .HasForeignKey(e => e.fk_AnswerToQuestionID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_CooperationType>()
                .HasMany(e => e.Tbl_EmploymentAdvPost)
                .WithOne(e => e.Tbl_CooperationType)
                .HasForeignKey(e => e.fk_CooperationTypeID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_CooperationType>()
                .HasMany(e => e.Tbl_RealCient)
                .WithOne(e => e.Tbl_CooperationType)
                .HasForeignKey(e => e.fk_CooperationID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_countries>()
                .HasMany(e => e.Tbl_EmploymentAdvPost)
                .WithOne(e => e.Tbl_countries)
                .HasForeignKey(e => e.fk_countryID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_countries>()
                .HasMany(e => e.Tbl_poster)
                .WithOne(e => e.Tbl_countries)
                .HasForeignKey(e => e.fk_countryID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_countries>()
                .HasMany(e => e.Tbl_posterFilter)
                .WithOne(e => e.Tbl_countries)
                .HasForeignKey(e => e.fk_countryID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_countries>()
                .HasMany(e => e.Tbl_province)
                .WithOne(e => e.Tbl_countries)
                .HasForeignKey(e => e.fk_countryID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_countries>()
                .HasMany(e => e.Tbl_RadFBUsers)
                .WithOne(e => e.Tbl_countries)
                .HasForeignKey(e => e.fk_countryID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_discount>()
                .HasMany(e => e.Tbl_userDiscount)
                .WithOne(e => e.Tbl_discount)
                .HasForeignKey(e => e.fk_discountID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_FrequentlyAskedQuestions>()
                .HasOne(e => e.Tbl_FrequentlyAskedQuestionsSubject)
                .WithOne(e => e.Tbl_FrequentlyAskedQuestions)
                .HasForeignKey<Tbl_FrequentlyAskedQuestions>(e => e.fk_SubjectID);



            modelBuilder.Entity<Tbl_gender>()
                .HasMany(e => e.Tbl_EmploymentAdvPost)
                .WithOne(e => e.Tbl_gender)
                .HasForeignKey(e => e.fk_genderID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_gender>()
                .HasMany(e => e.Tbl_poster)
                .WithOne(e => e.Tbl_gender)
                .HasForeignKey(e => e.fk_genderID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_gender>()
                .HasMany(e => e.Tbl_posterFilter)
                .WithOne(e => e.Tbl_gender)
                .HasForeignKey(e => e.fk_genderID)
                .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Tbl_gender>()
            //    .HasMany(e => e.Tbl_questionnaire)
            //    .WithOne(e => e.Tbl_gender)
            //    .HasForeignKey(e => e.fk_genderID)
            //    .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_gender>()
                .HasMany(e => e.Tbl_RealCient)
                .WithOne(e => e.Tbl_gender)
                .HasForeignKey(e => e.fk_GenderID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_grade>()
                .HasMany(e => e.Tbl_EmploymentAdvPost)
                .WithOne(e => e.Tbl_grade)
                .HasForeignKey(e => e.fk_grageID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_grade>()
                .HasMany(e => e.Tbl_UserEducationalBackground)
                .WithOne(e => e.Tbl_grade)
                .HasForeignKey(e => e.fk_gradeID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_group>()
                .HasMany(e => e.Tbl_groupException)
                .WithOne(e => e.Tbl_group)
                .HasForeignKey(e => e.fk_ExecptionGroupID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_group>()
                .HasMany(e => e.Tbl_groupMessages)
                .WithOne(e => e.Tbl_group)
                .HasForeignKey(e => e.fk_groupID);

            modelBuilder.Entity<Tbl_group>()
                .HasMany(e => e.Tbl_memberOfGroup)
                .WithOne(e => e.Tbl_group)
                .HasForeignKey(e => e.fk_groupID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_group>()
                .HasMany(e => e.Tbl_muteGroupMessage)
                .WithOne(e => e.Tbl_group)
                .HasForeignKey(e => e.fk_groupID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_guild>()
                .HasMany(e => e.Tbl_jobCategory)
                .WithOne(e => e.Tbl_guild)
                .HasForeignKey(e => e.fk_guildID)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_jobCategory>()
                .HasMany(e => e.Tbl_EmploymentAdvPost)
                .WithOne(e => e.Tbl_jobCategory)
                .HasForeignKey(e => e.fk_jobCategoryID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_jobCategory>()
                .HasMany(e => e.Tbl_Question)
                .WithOne(e => e.Tbl_jobCategory)
                .HasForeignKey(e => e.fk_JobCategoryID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_jobCategory>()
                .HasMany(e => e.Tbl_questionFilter)
                .WithOne(e => e.Tbl_jobCategory)
                .HasForeignKey(e => e.fk_JobCategoryID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_jobCategory>()
                .HasMany(e => e.Tbl_questionnaire)
                .WithOne(e => e.Tbl_jobCategory)
                .HasForeignKey(e => e.fk_JobCategoryID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_jobCategory>()
                .HasMany(e => e.Tbl_RadFBUsers)
                .WithOne(e => e.Tbl_jobCategory)
                .HasForeignKey(e => e.fk_jobCategoryID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_jobStatus>()
                .HasMany(e => e.Tbl_UserJobStatus)
                .WithOne(e => e.Tbl_jobStatus)
                .HasForeignKey(e => e.fk_JobStatusID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_major>()
                .HasMany(e => e.Tbl_UserEducationalBackground)
                .WithOne(e => e.Tbl_major)
                .HasForeignKey(e => e.fk_majorID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_messageType>()
                .HasMany(e => e.Tbl_groupMessages)
                .WithOne(e => e.Tbl_messageType)
                .HasForeignKey(e => e.fk_messageTypeID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_messageType>()
                .HasMany(e => e.Tbl_messages)
                .WithOne(e => e.Tbl_messageType)
                .HasForeignKey(e => e.fk_messageTypeID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_militaryServiceSituation>()
                .HasMany(e => e.Tbl_EmploymentAdvPost)
                .WithOne(e => e.Tbl_militaryServiceSituation)
                .HasForeignKey(e => e.fk_mssID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_militaryServiceSituation>()
                .HasMany(e => e.Tbl_RealCient)
                .WithOne(e => e.Tbl_militaryServiceSituation)
                .HasForeignKey(e => e.fk_mssID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_muteMessages>()
                .HasOne(e => e.Tbl_RadFBUsers1)
                .WithOne(e => e.Tbl_muteMessages1)
                .HasForeignKey<Tbl_muteMessages>(e => e.fk_ReciverUserID);

            modelBuilder.Entity<Tbl_pay>()
                .HasMany(e => e.Tbl_factor)
                .WithOne(e => e.Tbl_pay)
                .HasForeignKey(e => e.fk_payID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_permiumPackage>()
                .HasMany(e => e.Tbl_packageOptions)
                .WithOne(e => e.Tbl_permiumPackage)
                .HasForeignKey(e => e.fk_permiumPackageID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_permiumPackage>()
                .HasMany(e => e.Tbl_pay)
                .WithOne(e => e.Tbl_permiumPackage)
                .HasForeignKey(e => e.fk_permiumPackageID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_points>()
                .HasMany(e => e.Tbl_pointsDetail)
                .WithOne(e => e.Tbl_points)
                .HasForeignKey(e => e.fk_pointID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_post>()
                .HasMany(e => e.Tbl_EmploymentAdvApply)
                .WithOne(e => e.Tbl_post)
                .HasForeignKey(e => e.fk_postID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_post>()
                .HasMany(e => e.Tbl_EmploymentAdvPost)
                .WithOne(e => e.Tbl_post)
                .HasForeignKey(e => e.fk_PostID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_post>()
                .HasMany(e => e.Tbl_keyWords)
                .WithOne(e => e.Tbl_post)
                .HasForeignKey(e => e.fk_postID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_post>()
                .HasMany(e => e.Tbl_PostFile)
                .WithOne(e => e.Tbl_post)
                .HasForeignKey(e => e.fk_postID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_post>()
                .HasMany(e => e.Tbl_PostForward)
                .WithOne(e => e.Tbl_post)
                .HasForeignKey(e => e.fk_PostID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_post>()
                .HasMany(e => e.Tbl_PostLike)
                .WithOne(e => e.Tbl_post)
                .HasForeignKey(e => e.fk_PostID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_post>()
                .HasMany(e => e.Tbl_Question)
                .WithOne(e => e.Tbl_post)
                .HasForeignKey(e => e.fk_postID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_post>()
                .HasMany(e => e.Tbl_questionnaire)
                .WithOne(e => e.Tbl_post)
                .HasForeignKey(e => e.fk_postID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_post>()
                .HasMany(e => e.Tbl_VisitedPosts)
                .WithOne(e => e.Tbl_post)
                .HasForeignKey(e => e.fk_PostID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_poster>()
                .HasMany(e => e.Tbl_UserRegistrationCourses)
                .WithOne(e => e.Tbl_poster)
                .HasForeignKey(e => e.fk_posterID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_posterTemplate>()
                .HasMany(e => e.Tbl_poster)
                .WithOne(e => e.Tbl_posterTemplate)
                .HasForeignKey(e => e.fk_posterTemplateID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_Question>()
                .HasMany(e => e.Tbl_AnswerToQuestion)
                .WithOne(e => e.Tbl_Question)
                .HasForeignKey(e => e.fk_QuestiontID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_Question>()
                .HasMany(e => e.Tbl_savedQuestion)
                .WithOne(e => e.Tbl_Question)
                .HasForeignKey(e => e.fk_QuestionID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_questionnaire>()
                .HasMany(e => e.Tbl_DeclarationOfReadiness)
                .WithOne(e => e.Tbl_questionnaire)
                .HasForeignKey(e => e.fk_questionnaireID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_questionnaire>()
                .HasMany(e => e.Tbl_savedQuestionnaire)
                .WithOne(e => e.Tbl_questionnaire)
                .HasForeignKey(e => e.fk_QuestionnaireID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_activeSesion)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_activities)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_AnswerToQuestion)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_awards)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_BlockedUsers)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_BlockingUSerID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_BlockedUsers1)
                .WithOne(e => e.Tbl_RadFBUsers1)
                .HasForeignKey(e => e.fk_BlockedUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_BlockedUsers2)
                .WithOne(e => e.Tbl_RadFBUsers2)
                .HasForeignKey(e => e.fk_BlockingUSerID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_calender)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_CommentLike)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_criticsAndSuggestions)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_senderUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_DeclarationOfReadiness)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_volunteerUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_EmploymentAdvApply)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_ApplicantUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_followers)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_followers1)
                .WithOne(e => e.Tbl_RadFBUsers1)
                .HasForeignKey(e => e.fk_followerUSerID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_group)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_creatorUserID);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_groupException)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_groupMessages)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_senderUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_legalClient)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_Logins)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_memberOfGroup)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_messages)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_ReciverUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_messages1)
                .WithOne(e => e.Tbl_RadFBUsers1)
                .HasForeignKey(e => e.fk_senderUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_messagesException)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_messagesException1)
                .WithOne(e => e.Tbl_RadFBUsers1)
                .HasForeignKey(e => e.fk_ExecptionUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_muteGroupMessage)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_muteMessages)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_senderUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_MuteUsers)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_MuteUsers1)
                .WithOne(e => e.Tbl_RadFBUsers1)
                .HasForeignKey(e => e.fk_MutedUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_notifications)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_pay)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_pointsDetail)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_post)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_postChanged)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_postChangedException)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_postChangedException1)
                .WithOne(e => e.Tbl_RadFBUsers1)
                .HasForeignKey(e => e.fk_ExecptionUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_PostForward)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_ForwardedUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_PostForward1)
                .WithOne(e => e.Tbl_RadFBUsers1)
                .HasForeignKey(e => e.fk_ForwardingUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_PostLike)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_privacy)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Tbl_Question>()
            //    .HasMany(e => e.Tbl_subject)
            //    .WithOne(e => e.Tbl_subject)
            //    .HasForeignKey(e => e.fk)
            //    .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_questionFilter)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Tbl_RadFBUsers>()
            //    .HasMany(e => e.Tbl_questionnaire)
            //    .WithOne(e => e.Tbl_RadFBUsers)
            //    .HasForeignKey(e => e.fk_ApplicantUserID)
            //    .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_questionnaireFilter)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_RealCient)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_reportUsers)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_ReportingUSerID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_reportUsers1)
                .WithOne(e => e.Tbl_RadFBUsers1)
                .HasForeignKey(e => e.fk_ReportedUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_savedQuestion)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_savedQuestionnaire)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_savedTopics)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_silentUsers)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_silentUsers1)
                .WithOne(e => e.Tbl_RadFBUsers1)
                .HasForeignKey(e => e.fk_silentUSerID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_story)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_storySeen)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_SuggestionUsers)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_SuggestionUsers1)
                .WithOne(e => e.Tbl_RadFBUsers1)
                .HasForeignKey(e => e.fk_SuggestedUSerID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_userBackGroundSetting)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_userDiscount)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_UserEducationalBackground)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_UserFavorites)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_UserJobStatus)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_UserRegistrationCourses)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_RegisteredUserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_userSetting)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_usersQuestions)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_usersSearchs)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_UsersSkills)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_UserWorkExperience)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_UserWorkExperienceStamp)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_UserWorkExperienceStamp1)
                .WithOne(e => e.Tbl_RadFBUsers1)
                .HasForeignKey(e => e.fk_stampedUSerID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_VisitedPosts)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_UserID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_RadFBUsers>()
                .HasMany(e => e.Tbl_Voluntaryworks)
                .WithOne(e => e.Tbl_RadFBUsers)
                .HasForeignKey(e => e.fk_userID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_setting>()
                .HasMany(e => e.Tbl_packageOptions)
                .WithOne(e => e.Tbl_setting)
                .HasForeignKey(e => e.fk_settingID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_setting>()
                .HasMany(e => e.Tbl_userSetting)
                .WithOne(e => e.Tbl_setting)
                .HasForeignKey(e => e.fk_settingID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_Skills>()
                .HasMany(e => e.Tbl_UsersSkills)
                .WithOne(e => e.Tbl_Skills)
                .HasForeignKey(e => e.fk_SkillID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_story>()
                .HasMany(e => e.Tbl_storySeen)
                .WithOne(e => e.Tbl_story)
                .HasForeignKey(e => e.fk_storyID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_subject>()
                .HasMany(e => e.Tbl_questionFilter)
                .WithOne(e => e.Tbl_subject)
                .HasForeignKey(e => e.fk_subjectID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_subject>()
               .HasMany(e => e.Tbl_Question)
               .WithOne(e => e.Tbl_subject)
               .HasForeignKey(e => e.fk_subjectID)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_subject>()
                .HasMany(e => e.Tbl_questionnaireFilter)
                .WithOne(e => e.Tbl_subject)
                .HasForeignKey(e => e.fk_subjectID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_subject>()
               .HasMany(e => e.Tbl_questionnaire)
               .WithOne(e => e.Tbl_subject)
               .HasForeignKey(e => e.fk_subjectID)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_subject>()
                .HasMany(e => e.Tbl_savedTopics)
                .WithOne(e => e.Tbl_subject)
                .HasForeignKey(e => e.fk_subjectID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_userType>()
                .HasMany(e => e.Tbl_RadFBUsers)
                .WithOne(e => e.Tbl_userType)
                .HasForeignKey(e => e.fk_userTypeID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tbl_UserWorkExperience>()
                .HasMany(e => e.Tbl_UserWorkExperienceStamp)
                .WithOne(e => e.Tbl_UserWorkExperience)
                .HasForeignKey(e => e.fk_UserWorkExperienceID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
