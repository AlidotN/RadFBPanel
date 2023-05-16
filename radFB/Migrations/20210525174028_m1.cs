using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace radFB.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "postType",
                columns: table => new
                {
                    PostTypeID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FaPostTypeTitle = table.Column<string>(nullable: true),
                    EnPostTypeTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postType", x => x.PostTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CooperationType",
                columns: table => new
                {
                    CooperationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrCooperationName = table.Column<string>(nullable: true),
                    EnCooperationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CooperationType", x => x.CooperationID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_countries",
                columns: table => new
                {
                    countryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    countryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_countries", x => x.countryID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_dialog",
                columns: table => new
                {
                    notificationID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prnotificationTitle = table.Column<string>(nullable: true),
                    enNotificationTitle = table.Column<string>(nullable: true),
                    prNotificationText = table.Column<string>(nullable: true),
                    enNotificationText = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_dialog", x => x.notificationID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_discount",
                columns: table => new
                {
                    discountID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    discountTitle = table.Column<string>(nullable: true),
                    discountPercent = table.Column<int>(nullable: false),
                    startDate = table.Column<string>(nullable: true),
                    endDate = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_discount", x => x.discountID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_FrequentlyAskedQuestionsSubject",
                columns: table => new
                {
                    FrequentlyAskedQuestionsSubjectID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FaTitle = table.Column<string>(nullable: true),
                    EnTitle = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_FrequentlyAskedQuestionsSubject", x => x.FrequentlyAskedQuestionsSubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_gender",
                columns: table => new
                {
                    GenderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrGenderTitle = table.Column<string>(nullable: true),
                    EnGenderTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_grade",
                columns: table => new
                {
                    gradeID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrGradeTitle = table.Column<string>(nullable: true),
                    EnGradeTitle = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_grade", x => x.gradeID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_guild",
                columns: table => new
                {
                    guildID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FAguildNAme = table.Column<string>(nullable: true),
                    EnguildNAme = table.Column<string>(nullable: true),
                    guildColor = table.Column<int>(nullable: false),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_guild", x => x.guildID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Introduction",
                columns: table => new
                {
                    IntroductionID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FaText = table.Column<string>(nullable: true),
                    EnText = table.Column<string>(nullable: true),
                    FaPic = table.Column<string>(nullable: true),
                    EnPic = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Introduction", x => x.IntroductionID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_jobStatus",
                columns: table => new
                {
                    jobStatusID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrJobStatusTitle = table.Column<string>(nullable: true),
                    EnJobStatusTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_jobStatus", x => x.jobStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_major",
                columns: table => new
                {
                    majorID = table.Column<long>(nullable: false),
                    PrMajorTitle = table.Column<string>(maxLength: 50, nullable: true),
                    EnMajorTitle = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_major", x => x.majorID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_messageType",
                columns: table => new
                {
                    messageTypeID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    messageTypeTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_messageType", x => x.messageTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_militaryServiceSituation",
                columns: table => new
                {
                    mssID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prMSS = table.Column<string>(nullable: true),
                    enMSS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_militaryServiceSituation", x => x.mssID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_permiumPackage",
                columns: table => new
                {
                    permiumPackageID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    permiumPackageTitle = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    time = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_permiumPackage", x => x.permiumPackageID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_points",
                columns: table => new
                {
                    pointID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pointTitle = table.Column<string>(nullable: true),
                    pointValue = table.Column<int>(nullable: false),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_points", x => x.pointID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_posterTemplate",
                columns: table => new
                {
                    posterTemplateID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    posterName = table.Column<string>(nullable: true),
                    posterDescription = table.Column<string>(nullable: true),
                    posterFileAddress = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_posterTemplate", x => x.posterTemplateID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_setting",
                columns: table => new
                {
                    settingID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prSettingTitle = table.Column<string>(nullable: true),
                    enSettingTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_setting", x => x.settingID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_siteSetting",
                columns: table => new
                {
                    siteSettingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrAboutUS = table.Column<string>(nullable: true),
                    enAboutUS = table.Column<string>(nullable: true),
                    PrRules = table.Column<string>(nullable: true),
                    enRules = table.Column<string>(nullable: true),
                    phoneNumbers = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TelegramID = table.Column<string>(nullable: true),
                    WhatsAppPhoneNumber = table.Column<string>(nullable: true),
                    instagramID = table.Column<string>(nullable: true),
                    allowedBlock = table.Column<int>(nullable: false),
                    PrDemo = table.Column<string>(nullable: true),
                    EnDemo = table.Column<string>(nullable: true),
                    postsShowTime = table.Column<string>(nullable: true),
                    groupsMemberCount = table.Column<int>(nullable: false),
                    TitleAllowedCharacterCount = table.Column<int>(nullable: false),
                    DescriptionAllowedCharacterCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_siteSetting", x => x.siteSettingID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Skills",
                columns: table => new
                {
                    SkillID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrSkillTitle = table.Column<string>(nullable: true),
                    EnSkillTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Skills", x => x.SkillID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_subject",
                columns: table => new
                {
                    subjectID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FaTitle = table.Column<string>(nullable: true),
                    EnTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_subject", x => x.subjectID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UnauthorizedWords",
                columns: table => new
                {
                    UnauthorizedWordsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prWord = table.Column<string>(nullable: true),
                    enWord = table.Column<string>(nullable: true),
                    registerDate = table.Column<string>(nullable: true),
                    fk_ApplicationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UnauthorizedWords", x => x.UnauthorizedWordsID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_userAccess",
                columns: table => new
                {
                    userAccessID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userAccessTitle = table.Column<string>(nullable: true),
                    setting = table.Column<bool>(nullable: false),
                    users = table.Column<bool>(nullable: false),
                    UnauthorizedWords = table.Column<bool>(nullable: false),
                    posts = table.Column<bool>(nullable: false),
                    permiumPackage = table.Column<bool>(nullable: false),
                    financialDepartment = table.Column<bool>(nullable: false),
                    questions = table.Column<bool>(nullable: false),
                    adv = table.Column<bool>(nullable: false),
                    reports = table.Column<bool>(nullable: false),
                    criticsAndSuggestions = table.Column<bool>(nullable: false),
                    userAccessMenu = table.Column<bool>(nullable: false),
                    usersAdminPanel = table.Column<bool>(nullable: false),
                    deleteInformation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_userAccess", x => x.userAccessID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_userType",
                columns: table => new
                {
                    userTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrUserTypeName = table.Column<string>(nullable: true),
                    EnUserTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_userType", x => x.userTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_province",
                columns: table => new
                {
                    provinceID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    provinceName = table.Column<string>(nullable: true),
                    fk_countryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_province", x => x.provinceID);
                    table.ForeignKey(
                        name: "FK_Tbl_province_Tbl_countries_fk_countryID",
                        column: x => x.fk_countryID,
                        principalTable: "Tbl_countries",
                        principalColumn: "countryID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_FrequentlyAskedQuestions",
                columns: table => new
                {
                    FrequentlyAskedQuestionsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prQuestion = table.Column<string>(nullable: true),
                    prAnswer = table.Column<string>(nullable: true),
                    EnQuestion = table.Column<string>(nullable: true),
                    EnAnswer = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    fk_SubjectID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_FrequentlyAskedQuestions", x => x.FrequentlyAskedQuestionsID);
                    table.ForeignKey(
                        name: "FK_Tbl_FrequentlyAskedQuestions_Tbl_FrequentlyAskedQuestionsSubject_fk_SubjectID",
                        column: x => x.fk_SubjectID,
                        principalTable: "Tbl_FrequentlyAskedQuestionsSubject",
                        principalColumn: "FrequentlyAskedQuestionsSubjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_posterFilter",
                columns: table => new
                {
                    posterID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    posterTitle = table.Column<string>(nullable: true),
                    posterSubject = table.Column<string>(nullable: true),
                    posterContacts = table.Column<string>(nullable: true),
                    posterAddress = table.Column<string>(nullable: true),
                    posterDegree = table.Column<string>(nullable: true),
                    posterPrerequisites = table.Column<string>(nullable: true),
                    posterOtherThings = table.Column<string>(nullable: true),
                    fk_countryID = table.Column<int>(nullable: true),
                    posterCity = table.Column<string>(nullable: true),
                    posterStartDate = table.Column<string>(nullable: true),
                    posterEndDate = table.Column<string>(nullable: true),
                    OnlineOflineStatus = table.Column<bool>(nullable: false),
                    fk_genderID = table.Column<int>(nullable: true),
                    PosterCapacity = table.Column<int>(nullable: false),
                    posterCoust = table.Column<string>(nullable: true),
                    posterType = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_posterFilter", x => x.posterID);
                    table.ForeignKey(
                        name: "FK_Tbl_posterFilter_Tbl_countries_fk_countryID",
                        column: x => x.fk_countryID,
                        principalTable: "Tbl_countries",
                        principalColumn: "countryID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tbl_posterFilter_Tbl_gender_fk_genderID",
                        column: x => x.fk_genderID,
                        principalTable: "Tbl_gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_jobCategory",
                columns: table => new
                {
                    jobCategoryID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrJobCategoryTitle = table.Column<string>(nullable: true),
                    EnJobCategoryTitle = table.Column<string>(nullable: true),
                    fk_guildID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_jobCategory", x => x.jobCategoryID);
                    table.ForeignKey(
                        name: "FK_Tbl_jobCategory_Tbl_guild_fk_guildID",
                        column: x => x.fk_guildID,
                        principalTable: "Tbl_guild",
                        principalColumn: "guildID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_poster",
                columns: table => new
                {
                    posterID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    posterTitle = table.Column<string>(nullable: true),
                    posterSubject = table.Column<string>(nullable: true),
                    posterContacts = table.Column<string>(nullable: true),
                    posterAddress = table.Column<string>(nullable: true),
                    posterPhoneNumber = table.Column<string>(nullable: true),
                    posterDegree = table.Column<string>(nullable: true),
                    posterPrerequisites = table.Column<string>(nullable: true),
                    posterOtherThings = table.Column<string>(nullable: true),
                    fk_countryID = table.Column<int>(nullable: true),
                    posterCity = table.Column<string>(nullable: true),
                    posterStartDate = table.Column<string>(nullable: true),
                    posterEndDate = table.Column<string>(nullable: true),
                    OnlineOflineStatus = table.Column<bool>(nullable: false),
                    fk_genderID = table.Column<int>(nullable: true),
                    PosterCapacity = table.Column<int>(nullable: false),
                    posterCoust = table.Column<string>(nullable: true),
                    posterType = table.Column<string>(nullable: true),
                    fk_posterTemplateID = table.Column<long>(nullable: true),
                    daysOfWeek = table.Column<string>(nullable: true),
                    timesOfDay = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_poster", x => x.posterID);
                    table.ForeignKey(
                        name: "FK_Tbl_poster_Tbl_countries_fk_countryID",
                        column: x => x.fk_countryID,
                        principalTable: "Tbl_countries",
                        principalColumn: "countryID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tbl_poster_Tbl_gender_fk_genderID",
                        column: x => x.fk_genderID,
                        principalTable: "Tbl_gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tbl_poster_Tbl_posterTemplate_fk_posterTemplateID",
                        column: x => x.fk_posterTemplateID,
                        principalTable: "Tbl_posterTemplate",
                        principalColumn: "posterTemplateID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_packageOptions",
                columns: table => new
                {
                    packageOptionsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_settingID = table.Column<long>(nullable: true),
                    fk_permiumPackageID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_packageOptions", x => x.packageOptionsID);
                    table.ForeignKey(
                        name: "FK_Tbl_packageOptions_Tbl_permiumPackage_fk_permiumPackageID",
                        column: x => x.fk_permiumPackageID,
                        principalTable: "Tbl_permiumPackage",
                        principalColumn: "permiumPackageID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tbl_packageOptions_Tbl_setting_fk_settingID",
                        column: x => x.fk_settingID,
                        principalTable: "Tbl_setting",
                        principalColumn: "settingID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    UserPic = table.Column<string>(nullable: true),
                    Fk_userAccessID = table.Column<int>(nullable: false),
                    DeleteStatus = table.Column<bool>(nullable: false),
                    Tbl_userAccessuserAccessID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Tbl_userAccess_Tbl_userAccessuserAccessID",
                        column: x => x.Tbl_userAccessuserAccessID,
                        principalTable: "Tbl_userAccess",
                        principalColumn: "userAccessID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_RadFBUsers",
                columns: table => new
                {
                    RadFbUserID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    phoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    fk_countryID = table.Column<int>(nullable: true),
                    fk_provinceID = table.Column<long>(nullable: true),
                    fk_jobCategoryID = table.Column<long>(nullable: true),
                    fk_userTypeID = table.Column<int>(nullable: true),
                    interdusedEmail = table.Column<int>(nullable: false),
                    UserAddress = table.Column<string>(nullable: true),
                    UserPic = table.Column<string>(nullable: true),
                    UserWebsite = table.Column<string>(nullable: true),
                    RegisterDate = table.Column<string>(nullable: true),
                    lastSeenDate = table.Column<string>(nullable: true),
                    userStatus = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_RadFBUsers", x => x.RadFbUserID);
                    table.ForeignKey(
                        name: "FK_Tbl_RadFBUsers_Tbl_countries_fk_countryID",
                        column: x => x.fk_countryID,
                        principalTable: "Tbl_countries",
                        principalColumn: "countryID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tbl_RadFBUsers_Tbl_jobCategory_fk_jobCategoryID",
                        column: x => x.fk_jobCategoryID,
                        principalTable: "Tbl_jobCategory",
                        principalColumn: "jobCategoryID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tbl_RadFBUsers_Tbl_userType_fk_userTypeID",
                        column: x => x.fk_userTypeID,
                        principalTable: "Tbl_userType",
                        principalColumn: "userTypeID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_activeSesion",
                columns: table => new
                {
                    activeSesionID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_userID = table.Column<long>(nullable: true),
                    deviceName = table.Column<string>(nullable: true),
                    deviceCode = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_activeSesion", x => x.activeSesionID);
                    table.ForeignKey(
                        name: "FK_Tbl_activeSesion_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_activities",
                columns: table => new
                {
                    activityID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    avtivityTitle = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false),
                    fk_userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_activities", x => x.activityID);
                    table.ForeignKey(
                        name: "FK_Tbl_activities_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_awards",
                columns: table => new
                {
                    awardsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    awardsTitle = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false),
                    fk_userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_awards", x => x.awardsID);
                    table.ForeignKey(
                        name: "FK_Tbl_awards_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_BlockedUsers",
                columns: table => new
                {
                    BlockedUsersID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_BlockingUSerID = table.Column<long>(nullable: true),
                    fk_BlockedUserID = table.Column<long>(nullable: true),
                    BlockExplantion = table.Column<string>(nullable: true),
                    Tbl_RadFBUsersRadFbUserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_BlockedUsers", x => x.BlockedUsersID);
                    table.ForeignKey(
                        name: "FK_Tbl_BlockedUsers_Tbl_RadFBUsers_Tbl_RadFBUsersRadFbUserID",
                        column: x => x.Tbl_RadFBUsersRadFbUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_BlockedUsers_Tbl_RadFBUsers_fk_BlockedUserID",
                        column: x => x.fk_BlockedUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_BlockedUsers_Tbl_RadFBUsers_fk_BlockingUSerID",
                        column: x => x.fk_BlockingUSerID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_calender",
                columns: table => new
                {
                    calenderID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    calenderTitle = table.Column<string>(nullable: true),
                    calenderStartDate = table.Column<string>(nullable: true),
                    calenderEndDate = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false),
                    fk_userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_calender", x => x.calenderID);
                    table.ForeignKey(
                        name: "FK_Tbl_calender_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_criticsAndSuggestions",
                columns: table => new
                {
                    criticsAndSuggestionsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    txtMessage = table.Column<string>(nullable: true),
                    Confirmation = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<int>(nullable: false),
                    fk_senderUserID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_criticsAndSuggestions", x => x.criticsAndSuggestionsID);
                    table.ForeignKey(
                        name: "FK_Tbl_criticsAndSuggestions_Tbl_RadFBUsers_fk_senderUserID",
                        column: x => x.fk_senderUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_followers",
                columns: table => new
                {
                    followersID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_UserID = table.Column<long>(nullable: true),
                    fk_followerUSerID = table.Column<long>(nullable: true),
                    seePostsAllow = table.Column<bool>(nullable: false),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_followers", x => x.followersID);
                    table.ForeignKey(
                        name: "FK_Tbl_followers_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_followers_Tbl_RadFBUsers_fk_followerUSerID",
                        column: x => x.fk_followerUSerID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_group",
                columns: table => new
                {
                    groupID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    groupTitle = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    fk_creatorUserID = table.Column<long>(nullable: false),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_group", x => x.groupID);
                    table.ForeignKey(
                        name: "FK_Tbl_group_Tbl_RadFBUsers_fk_creatorUserID",
                        column: x => x.fk_creatorUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_legalClient",
                columns: table => new
                {
                    legalClientID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    companyName = table.Column<string>(nullable: true),
                    RegisterNumber = table.Column<string>(nullable: true),
                    aboutCompany = table.Column<string>(nullable: true),
                    CEOName = table.Column<string>(nullable: true),
                    natioalCode = table.Column<string>(nullable: true),
                    membersCount = table.Column<string>(nullable: true),
                    DateOfEstablishment = table.Column<string>(nullable: true),
                    companyType = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false),
                    fk_UserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_legalClient", x => x.legalClientID);
                    table.ForeignKey(
                        name: "FK_Tbl_legalClient_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Logins",
                columns: table => new
                {
                    LoginID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    deviceCode = table.Column<string>(nullable: true),
                    loginDate = table.Column<string>(nullable: true),
                    loginTime = table.Column<string>(nullable: true),
                    fk_userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Logins", x => x.LoginID);
                    table.ForeignKey(
                        name: "FK_Tbl_Logins_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_messages",
                columns: table => new
                {
                    messageID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    messageText = table.Column<string>(nullable: true),
                    messageDate = table.Column<string>(nullable: true),
                    messageIsSeen = table.Column<bool>(nullable: false),
                    fk_ReciverUserID = table.Column<long>(nullable: true),
                    fk_senderUserID = table.Column<long>(nullable: true),
                    MessageTime = table.Column<string>(nullable: true),
                    fk_messageTypeID = table.Column<long>(nullable: true),
                    MessagePicture = table.Column<string>(nullable: true),
                    MessageVoice = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_messages", x => x.messageID);
                    table.ForeignKey(
                        name: "FK_Tbl_messages_Tbl_RadFBUsers_fk_ReciverUserID",
                        column: x => x.fk_ReciverUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_messages_Tbl_messageType_fk_messageTypeID",
                        column: x => x.fk_messageTypeID,
                        principalTable: "Tbl_messageType",
                        principalColumn: "messageTypeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_messages_Tbl_RadFBUsers_fk_senderUserID",
                        column: x => x.fk_senderUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_messagesException",
                columns: table => new
                {
                    messagesExceptionID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_userID = table.Column<long>(nullable: true),
                    fk_ExecptionUserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_messagesException", x => x.messagesExceptionID);
                    table.ForeignKey(
                        name: "FK_Tbl_messagesException_Tbl_RadFBUsers_fk_ExecptionUserID",
                        column: x => x.fk_ExecptionUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_messagesException_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_muteMessages",
                columns: table => new
                {
                    muteMessagesID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    messageStatus = table.Column<bool>(nullable: false),
                    fk_ReciverUserID = table.Column<long>(nullable: true),
                    fk_senderUserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_muteMessages", x => x.muteMessagesID);
                    table.ForeignKey(
                        name: "FK_Tbl_muteMessages_Tbl_RadFBUsers_fk_ReciverUserID",
                        column: x => x.fk_ReciverUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_muteMessages_Tbl_RadFBUsers_fk_senderUserID",
                        column: x => x.fk_senderUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_MuteUsers",
                columns: table => new
                {
                    MuteUserID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_UserID = table.Column<long>(nullable: true),
                    fk_MutedUserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_MuteUsers", x => x.MuteUserID);
                    table.ForeignKey(
                        name: "FK_Tbl_MuteUsers_Tbl_RadFBUsers_fk_MutedUserID",
                        column: x => x.fk_MutedUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_MuteUsers_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_notifications",
                columns: table => new
                {
                    notificationID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    notification = table.Column<bool>(nullable: false),
                    MessageNotification = table.Column<bool>(nullable: false),
                    MessageNotificationRing = table.Column<string>(nullable: true),
                    groupNotification = table.Column<bool>(nullable: false),
                    groupNotificationRing = table.Column<string>(nullable: true),
                    postNotification = table.Column<bool>(nullable: false),
                    postNotificationRing = table.Column<string>(nullable: true),
                    AdvNotification = table.Column<bool>(nullable: false),
                    AdvNotificationRing = table.Column<string>(nullable: true),
                    QuestionNotification = table.Column<bool>(nullable: false),
                    questionNotificationRing = table.Column<string>(nullable: true),
                    appVibration = table.Column<bool>(nullable: false),
                    appNotificationRing = table.Column<string>(nullable: true),
                    fk_userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_notifications", x => x.notificationID);
                    table.ForeignKey(
                        name: "FK_Tbl_notifications_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_pay",
                columns: table => new
                {
                    payID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_userID = table.Column<long>(nullable: true),
                    fk_permiumPackageID = table.Column<long>(nullable: true),
                    price = table.Column<long>(nullable: false),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_pay", x => x.payID);
                    table.ForeignKey(
                        name: "FK_Tbl_pay_Tbl_permiumPackage_fk_permiumPackageID",
                        column: x => x.fk_permiumPackageID,
                        principalTable: "Tbl_permiumPackage",
                        principalColumn: "permiumPackageID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_pay_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_pointsDetail",
                columns: table => new
                {
                    pointsDetailID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pointDetailDate = table.Column<string>(nullable: true),
                    subPoint = table.Column<long>(nullable: false),
                    pointSubDate = table.Column<string>(nullable: true),
                    sumPoint = table.Column<long>(nullable: false),
                    fk_pointID = table.Column<long>(nullable: true),
                    fk_userID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_pointsDetail", x => x.pointsDetailID);
                    table.ForeignKey(
                        name: "FK_Tbl_pointsDetail_Tbl_points_fk_pointID",
                        column: x => x.fk_pointID,
                        principalTable: "Tbl_points",
                        principalColumn: "pointID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_pointsDetail_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_post",
                columns: table => new
                {
                    postID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    postTitle = table.Column<string>(nullable: true),
                    postDescription = table.Column<string>(nullable: true),
                    RegisterDate = table.Column<string>(nullable: true),
                    DeleteDate = table.Column<string>(nullable: true),
                    PostConfrimStatus = table.Column<bool>(nullable: false),
                    fk_PostTypeID = table.Column<long>(nullable: true),
                    fk_UserID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_post", x => x.postID);
                    table.ForeignKey(
                        name: "FK_Tbl_post_postType_fk_PostTypeID",
                        column: x => x.fk_PostTypeID,
                        principalTable: "postType",
                        principalColumn: "PostTypeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_post_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_postChanged",
                columns: table => new
                {
                    postChangedID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    postChangedPic = table.Column<string>(nullable: true),
                    postChangedExplain = table.Column<string>(nullable: true),
                    postChangedDate = table.Column<string>(nullable: true),
                    postChangedTime = table.Column<string>(nullable: true),
                    postChangedStatus = table.Column<bool>(nullable: false),
                    DeleteStatus = table.Column<bool>(nullable: false),
                    fk_userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_postChanged", x => x.postChangedID);
                    table.ForeignKey(
                        name: "FK_Tbl_postChanged_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_postChangedException",
                columns: table => new
                {
                    postChangedExceptionID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_userID = table.Column<long>(nullable: true),
                    fk_ExecptionUserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_postChangedException", x => x.postChangedExceptionID);
                    table.ForeignKey(
                        name: "FK_Tbl_postChangedException_Tbl_RadFBUsers_fk_ExecptionUserID",
                        column: x => x.fk_ExecptionUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_postChangedException_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_privacy",
                columns: table => new
                {
                    privacyID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    privateMode = table.Column<bool>(nullable: false),
                    QuestionAnswer = table.Column<bool>(nullable: false),
                    mention = table.Column<bool>(nullable: false),
                    addToGroup = table.Column<bool>(nullable: false),
                    LastSeen = table.Column<bool>(nullable: false),
                    profilePhoto = table.Column<bool>(nullable: false),
                    fk_userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_privacy", x => x.privacyID);
                    table.ForeignKey(
                        name: "FK_Tbl_privacy_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_questionFilter",
                columns: table => new
                {
                    questionFilterID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_subjectID = table.Column<long>(nullable: true),
                    fk_userID = table.Column<long>(nullable: true),
                    fk_JobCategoryID = table.Column<long>(nullable: true),
                    questionFilterStatus = table.Column<bool>(nullable: false),
                    alert = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_questionFilter", x => x.questionFilterID);
                    table.ForeignKey(
                        name: "FK_Tbl_questionFilter_Tbl_jobCategory_fk_JobCategoryID",
                        column: x => x.fk_JobCategoryID,
                        principalTable: "Tbl_jobCategory",
                        principalColumn: "jobCategoryID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_questionFilter_Tbl_subject_fk_subjectID",
                        column: x => x.fk_subjectID,
                        principalTable: "Tbl_subject",
                        principalColumn: "subjectID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_questionFilter_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_questionnaireFilter",
                columns: table => new
                {
                    questionnaireFilterID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_userID = table.Column<long>(nullable: true),
                    fk_subjectID = table.Column<long>(nullable: true),
                    benefits = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_questionnaireFilter", x => x.questionnaireFilterID);
                    table.ForeignKey(
                        name: "FK_Tbl_questionnaireFilter_Tbl_subject_fk_subjectID",
                        column: x => x.fk_subjectID,
                        principalTable: "Tbl_subject",
                        principalColumn: "subjectID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_questionnaireFilter_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_RealCient",
                columns: table => new
                {
                    RealClientID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    aboutMe = table.Column<string>(nullable: true),
                    suggestSAlary = table.Column<string>(nullable: true),
                    companyDesire = table.Column<bool>(nullable: false),
                    fk_GenderID = table.Column<int>(nullable: true),
                    fk_mssID = table.Column<long>(nullable: true),
                    fk_CooperationID = table.Column<int>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false),
                    fk_UserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_RealCient", x => x.RealClientID);
                    table.ForeignKey(
                        name: "FK_Tbl_RealCient_Tbl_CooperationType_fk_CooperationID",
                        column: x => x.fk_CooperationID,
                        principalTable: "Tbl_CooperationType",
                        principalColumn: "CooperationID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_RealCient_Tbl_gender_fk_GenderID",
                        column: x => x.fk_GenderID,
                        principalTable: "Tbl_gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_RealCient_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_RealCient_Tbl_militaryServiceSituation_fk_mssID",
                        column: x => x.fk_mssID,
                        principalTable: "Tbl_militaryServiceSituation",
                        principalColumn: "mssID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_reportUsers",
                columns: table => new
                {
                    reportUsersID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_ReportingUSerID = table.Column<long>(nullable: true),
                    fk_ReportedUserID = table.Column<long>(nullable: true),
                    isChecked = table.Column<bool>(nullable: false),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_reportUsers", x => x.reportUsersID);
                    table.ForeignKey(
                        name: "FK_Tbl_reportUsers_Tbl_RadFBUsers_fk_ReportedUserID",
                        column: x => x.fk_ReportedUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_reportUsers_Tbl_RadFBUsers_fk_ReportingUSerID",
                        column: x => x.fk_ReportingUSerID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_savedTopics",
                columns: table => new
                {
                    savedTopicsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_userID = table.Column<long>(nullable: true),
                    fk_subjectID = table.Column<long>(nullable: true),
                    savedTopicStatus = table.Column<bool>(nullable: false),
                    questionOrQuestionnaire = table.Column<bool>(nullable: false),
                    ShowOrHide = table.Column<bool>(nullable: false),
                    PinStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_savedTopics", x => x.savedTopicsID);
                    table.ForeignKey(
                        name: "FK_Tbl_savedTopics_Tbl_subject_fk_subjectID",
                        column: x => x.fk_subjectID,
                        principalTable: "Tbl_subject",
                        principalColumn: "subjectID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_savedTopics_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_silentUsers",
                columns: table => new
                {
                    silentUserID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_userID = table.Column<long>(nullable: true),
                    fk_silentUSerID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_silentUsers", x => x.silentUserID);
                    table.ForeignKey(
                        name: "FK_Tbl_silentUsers_Tbl_RadFBUsers_fk_silentUSerID",
                        column: x => x.fk_silentUSerID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_silentUsers_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_story",
                columns: table => new
                {
                    storyID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyProperty = table.Column<int>(nullable: false),
                    storyPicture = table.Column<string>(nullable: true),
                    storySong = table.Column<string>(nullable: true),
                    stroryDate = table.Column<string>(nullable: true),
                    storyTime = table.Column<string>(nullable: true),
                    storyStatus = table.Column<bool>(nullable: false),
                    fk_userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_story", x => x.storyID);
                    table.ForeignKey(
                        name: "FK_Tbl_story_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SuggestionUsers",
                columns: table => new
                {
                    SuggestionUsersID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_UserID = table.Column<long>(nullable: true),
                    fk_SuggestedUSerID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SuggestionUsers", x => x.SuggestionUsersID);
                    table.ForeignKey(
                        name: "FK_Tbl_SuggestionUsers_Tbl_RadFBUsers_fk_SuggestedUSerID",
                        column: x => x.fk_SuggestedUSerID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_SuggestionUsers_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_userBackGroundSetting",
                columns: table => new
                {
                    userBackGroundSettingID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_userID = table.Column<long>(nullable: true),
                    pic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_userBackGroundSetting", x => x.userBackGroundSettingID);
                    table.ForeignKey(
                        name: "FK_Tbl_userBackGroundSetting_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_userDiscount",
                columns: table => new
                {
                    userDiscountID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_discountID = table.Column<long>(nullable: true),
                    fk_userID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_userDiscount", x => x.userDiscountID);
                    table.ForeignKey(
                        name: "FK_Tbl_userDiscount_Tbl_discount_fk_discountID",
                        column: x => x.fk_discountID,
                        principalTable: "Tbl_discount",
                        principalColumn: "discountID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_userDiscount_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserEducationalBackground",
                columns: table => new
                {
                    UserEduBackID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstituteName = table.Column<string>(nullable: true),
                    FromDate = table.Column<string>(nullable: true),
                    UpToDate = table.Column<string>(nullable: true),
                    fk_majorID = table.Column<long>(nullable: true),
                    fk_gradeID = table.Column<long>(nullable: true),
                    fk_UserID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserEducationalBackground", x => x.UserEduBackID);
                    table.ForeignKey(
                        name: "FK_Tbl_UserEducationalBackground_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_UserEducationalBackground_Tbl_grade_fk_gradeID",
                        column: x => x.fk_gradeID,
                        principalTable: "Tbl_grade",
                        principalColumn: "gradeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_UserEducationalBackground_Tbl_major_fk_majorID",
                        column: x => x.fk_majorID,
                        principalTable: "Tbl_major",
                        principalColumn: "majorID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserFavorites",
                columns: table => new
                {
                    UserFavoriteID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_UserID = table.Column<long>(nullable: true),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserFavorites", x => x.UserFavoriteID);
                    table.ForeignKey(
                        name: "FK_Tbl_UserFavorites_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserJobStatus",
                columns: table => new
                {
                    UserJobStatusID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_JobStatusID = table.Column<long>(nullable: true),
                    fk_UserID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserJobStatus", x => x.UserJobStatusID);
                    table.ForeignKey(
                        name: "FK_Tbl_UserJobStatus_Tbl_jobStatus_fk_JobStatusID",
                        column: x => x.fk_JobStatusID,
                        principalTable: "Tbl_jobStatus",
                        principalColumn: "jobStatusID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_UserJobStatus_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserRegistrationCourses",
                columns: table => new
                {
                    UserRegistrationCoursesID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_RegisteredUserID = table.Column<long>(nullable: true),
                    fk_posterID = table.Column<long>(nullable: true),
                    UserRegistrationStatus = table.Column<bool>(nullable: false),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserRegistrationCourses", x => x.UserRegistrationCoursesID);
                    table.ForeignKey(
                        name: "FK_Tbl_UserRegistrationCourses_Tbl_RadFBUsers_fk_RegisteredUserID",
                        column: x => x.fk_RegisteredUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_UserRegistrationCourses_Tbl_poster_fk_posterID",
                        column: x => x.fk_posterID,
                        principalTable: "Tbl_poster",
                        principalColumn: "posterID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_userSetting",
                columns: table => new
                {
                    userSettingID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_settingID = table.Column<long>(nullable: true),
                    fk_userID = table.Column<long>(nullable: true),
                    settingStatus = table.Column<bool>(nullable: false),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_userSetting", x => x.userSettingID);
                    table.ForeignKey(
                        name: "FK_Tbl_userSetting_Tbl_setting_fk_settingID",
                        column: x => x.fk_settingID,
                        principalTable: "Tbl_setting",
                        principalColumn: "settingID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_userSetting_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_usersQuestions",
                columns: table => new
                {
                    usersQuestionsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    usersQuestionsText = table.Column<string>(nullable: true),
                    usersQuestionDate = table.Column<string>(nullable: true),
                    usersQuestionTime = table.Column<string>(nullable: true),
                    QuestionAnswerText = table.Column<string>(nullable: true),
                    QuestionAnswerDate = table.Column<string>(nullable: true),
                    QuestionAnswerTime = table.Column<string>(nullable: true),
                    answerPoint = table.Column<int>(nullable: false),
                    DeleteStatus = table.Column<bool>(nullable: false),
                    fk_userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_usersQuestions", x => x.usersQuestionsID);
                    table.ForeignKey(
                        name: "FK_Tbl_usersQuestions_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_usersSearchs",
                columns: table => new
                {
                    userSearchID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SearchedTitle = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false),
                    fk_userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_usersSearchs", x => x.userSearchID);
                    table.ForeignKey(
                        name: "FK_Tbl_usersSearchs_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UsersSkills",
                columns: table => new
                {
                    UsersSkillsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_SkillID = table.Column<long>(nullable: true),
                    fk_UserID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UsersSkills", x => x.UsersSkillsID);
                    table.ForeignKey(
                        name: "FK_Tbl_UsersSkills_Tbl_Skills_fk_SkillID",
                        column: x => x.fk_SkillID,
                        principalTable: "Tbl_Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_UsersSkills_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserWorkExperience",
                columns: table => new
                {
                    UserEduBackID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstituteName = table.Column<string>(nullable: true),
                    FromDate = table.Column<string>(nullable: true),
                    UpToDate = table.Column<string>(nullable: true),
                    companyLogo = table.Column<string>(nullable: true),
                    post = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    fk_UserID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserWorkExperience", x => x.UserEduBackID);
                    table.ForeignKey(
                        name: "FK_Tbl_UserWorkExperience_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Voluntaryworks",
                columns: table => new
                {
                    VoluntaryworkID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VoluntaryworkTitle = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false),
                    fk_userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Voluntaryworks", x => x.VoluntaryworkID);
                    table.ForeignKey(
                        name: "FK_Tbl_Voluntaryworks_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_groupException",
                columns: table => new
                {
                    groupExceptionID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_userID = table.Column<long>(nullable: true),
                    fk_ExecptionGroupID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_groupException", x => x.groupExceptionID);
                    table.ForeignKey(
                        name: "FK_Tbl_groupException_Tbl_group_fk_ExecptionGroupID",
                        column: x => x.fk_ExecptionGroupID,
                        principalTable: "Tbl_group",
                        principalColumn: "groupID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_groupException_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_groupMessages",
                columns: table => new
                {
                    groupMessagesID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    groupMessageText = table.Column<string>(nullable: true),
                    groupMessageDate = table.Column<int>(nullable: false),
                    groupMessageIsSeen = table.Column<bool>(nullable: false),
                    fk_groupID = table.Column<long>(nullable: true),
                    fk_senderUserID = table.Column<long>(nullable: true),
                    groupMessageTime = table.Column<string>(nullable: true),
                    fk_messageTypeID = table.Column<long>(nullable: true),
                    groupMessagePicture = table.Column<string>(nullable: true),
                    groupMessageVoice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_groupMessages", x => x.groupMessagesID);
                    table.ForeignKey(
                        name: "FK_Tbl_groupMessages_Tbl_group_fk_groupID",
                        column: x => x.fk_groupID,
                        principalTable: "Tbl_group",
                        principalColumn: "groupID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_groupMessages_Tbl_messageType_fk_messageTypeID",
                        column: x => x.fk_messageTypeID,
                        principalTable: "Tbl_messageType",
                        principalColumn: "messageTypeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_groupMessages_Tbl_RadFBUsers_fk_senderUserID",
                        column: x => x.fk_senderUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_memberOfGroup",
                columns: table => new
                {
                    memberOfGroupID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_UserID = table.Column<long>(nullable: true),
                    fk_groupID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_memberOfGroup", x => x.memberOfGroupID);
                    table.ForeignKey(
                        name: "FK_Tbl_memberOfGroup_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_memberOfGroup_Tbl_group_fk_groupID",
                        column: x => x.fk_groupID,
                        principalTable: "Tbl_group",
                        principalColumn: "groupID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_muteGroupMessage",
                columns: table => new
                {
                    muteGroupMessageID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    messageStatus = table.Column<bool>(nullable: false),
                    fk_groupID = table.Column<long>(nullable: true),
                    fk_UserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_muteGroupMessage", x => x.muteGroupMessageID);
                    table.ForeignKey(
                        name: "FK_Tbl_muteGroupMessage_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_muteGroupMessage_Tbl_group_fk_groupID",
                        column: x => x.fk_groupID,
                        principalTable: "Tbl_group",
                        principalColumn: "groupID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_factor",
                columns: table => new
                {
                    factorID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_payID = table.Column<long>(nullable: true),
                    price = table.Column<long>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    Authority = table.Column<string>(nullable: true),
                    TrackingCode = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_factor", x => x.factorID);
                    table.ForeignKey(
                        name: "FK_Tbl_factor_Tbl_pay_fk_payID",
                        column: x => x.fk_payID,
                        principalTable: "Tbl_pay",
                        principalColumn: "payID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EmploymentAdvApply",
                columns: table => new
                {
                    EmploymentAdvApplyID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_ApplicantUserID = table.Column<long>(nullable: true),
                    fk_postID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EmploymentAdvApply", x => x.EmploymentAdvApplyID);
                    table.ForeignKey(
                        name: "FK_Tbl_EmploymentAdvApply_Tbl_RadFBUsers_fk_ApplicantUserID",
                        column: x => x.fk_ApplicantUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_EmploymentAdvApply_Tbl_post_fk_postID",
                        column: x => x.fk_postID,
                        principalTable: "Tbl_post",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EmploymentAdvPost",
                columns: table => new
                {
                    EmploymentAdvPostID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_CooperationTypeID = table.Column<int>(nullable: true),
                    fk_countryID = table.Column<int>(nullable: true),
                    fk_provinceID = table.Column<long>(nullable: true),
                    fk_jobCategoryID = table.Column<long>(nullable: true),
                    fk_PostID = table.Column<long>(nullable: true),
                    fk_genderID = table.Column<int>(nullable: true),
                    fk_grageID = table.Column<long>(nullable: true),
                    fk_mssID = table.Column<long>(nullable: true),
                    salary = table.Column<string>(nullable: true),
                    SkillsReqired = table.Column<string>(nullable: true),
                    WorkExprience = table.Column<string>(nullable: true),
                    EdvType = table.Column<bool>(nullable: false),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EmploymentAdvPost", x => x.EmploymentAdvPostID);
                    table.ForeignKey(
                        name: "FK_Tbl_EmploymentAdvPost_Tbl_CooperationType_fk_CooperationTypeID",
                        column: x => x.fk_CooperationTypeID,
                        principalTable: "Tbl_CooperationType",
                        principalColumn: "CooperationID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_EmploymentAdvPost_Tbl_post_fk_PostID",
                        column: x => x.fk_PostID,
                        principalTable: "Tbl_post",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_EmploymentAdvPost_Tbl_countries_fk_countryID",
                        column: x => x.fk_countryID,
                        principalTable: "Tbl_countries",
                        principalColumn: "countryID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_EmploymentAdvPost_Tbl_gender_fk_genderID",
                        column: x => x.fk_genderID,
                        principalTable: "Tbl_gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_EmploymentAdvPost_Tbl_grade_fk_grageID",
                        column: x => x.fk_grageID,
                        principalTable: "Tbl_grade",
                        principalColumn: "gradeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_EmploymentAdvPost_Tbl_jobCategory_fk_jobCategoryID",
                        column: x => x.fk_jobCategoryID,
                        principalTable: "Tbl_jobCategory",
                        principalColumn: "jobCategoryID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_EmploymentAdvPost_Tbl_militaryServiceSituation_fk_mssID",
                        column: x => x.fk_mssID,
                        principalTable: "Tbl_militaryServiceSituation",
                        principalColumn: "mssID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_keyWords",
                columns: table => new
                {
                    keyWordID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_postID = table.Column<long>(nullable: true),
                    keyWord = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_keyWords", x => x.keyWordID);
                    table.ForeignKey(
                        name: "FK_Tbl_keyWords_Tbl_post_fk_postID",
                        column: x => x.fk_postID,
                        principalTable: "Tbl_post",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PostFile",
                columns: table => new
                {
                    postFileID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_postID = table.Column<long>(nullable: true),
                    FileAddress = table.Column<string>(nullable: true),
                    picAddress = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PostFile", x => x.postFileID);
                    table.ForeignKey(
                        name: "FK_Tbl_PostFile_Tbl_post_fk_postID",
                        column: x => x.fk_postID,
                        principalTable: "Tbl_post",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PostForward",
                columns: table => new
                {
                    PostForwardID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_ForwardedUserID = table.Column<long>(nullable: true),
                    fk_ForwardingUserID = table.Column<long>(nullable: true),
                    fk_PostID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PostForward", x => x.PostForwardID);
                    table.ForeignKey(
                        name: "FK_Tbl_PostForward_Tbl_RadFBUsers_fk_ForwardedUserID",
                        column: x => x.fk_ForwardedUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_PostForward_Tbl_RadFBUsers_fk_ForwardingUserID",
                        column: x => x.fk_ForwardingUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_PostForward_Tbl_post_fk_PostID",
                        column: x => x.fk_PostID,
                        principalTable: "Tbl_post",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PostLike",
                columns: table => new
                {
                    PostLikeID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_UserID = table.Column<long>(nullable: true),
                    fk_PostID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PostLike", x => x.PostLikeID);
                    table.ForeignKey(
                        name: "FK_Tbl_PostLike_Tbl_post_fk_PostID",
                        column: x => x.fk_PostID,
                        principalTable: "Tbl_post",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_PostLike_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Question",
                columns: table => new
                {
                    QuestionID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionTitle = table.Column<string>(nullable: true),
                    fk_JobCategoryID = table.Column<long>(nullable: true),
                    fk_UserID = table.Column<long>(nullable: true),
                    fk_postID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Question", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK_Tbl_Question_Tbl_jobCategory_fk_JobCategoryID",
                        column: x => x.fk_JobCategoryID,
                        principalTable: "Tbl_jobCategory",
                        principalColumn: "jobCategoryID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_Question_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_Question_Tbl_post_fk_postID",
                        column: x => x.fk_postID,
                        principalTable: "Tbl_post",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_questionnaire",
                columns: table => new
                {
                    questionnaireID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    questionnaireTitle = table.Column<string>(nullable: true),
                    fk_JobCategoryID = table.Column<long>(nullable: true),
                    fk_genderID = table.Column<int>(nullable: true),
                    fk_ApplicantUserID = table.Column<long>(nullable: true),
                    fk_postID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_questionnaire", x => x.questionnaireID);
                    table.ForeignKey(
                        name: "FK_Tbl_questionnaire_Tbl_RadFBUsers_fk_ApplicantUserID",
                        column: x => x.fk_ApplicantUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_questionnaire_Tbl_jobCategory_fk_JobCategoryID",
                        column: x => x.fk_JobCategoryID,
                        principalTable: "Tbl_jobCategory",
                        principalColumn: "jobCategoryID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_questionnaire_Tbl_gender_fk_genderID",
                        column: x => x.fk_genderID,
                        principalTable: "Tbl_gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_questionnaire_Tbl_post_fk_postID",
                        column: x => x.fk_postID,
                        principalTable: "Tbl_post",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_VisitedPosts",
                columns: table => new
                {
                    VisitedPostsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_UserID = table.Column<long>(nullable: true),
                    fk_PostID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_VisitedPosts", x => x.VisitedPostsID);
                    table.ForeignKey(
                        name: "FK_Tbl_VisitedPosts_Tbl_post_fk_PostID",
                        column: x => x.fk_PostID,
                        principalTable: "Tbl_post",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_VisitedPosts_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_storySeen",
                columns: table => new
                {
                    storySeenID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_userID = table.Column<long>(nullable: true),
                    fk_storyID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_storySeen", x => x.storySeenID);
                    table.ForeignKey(
                        name: "FK_Tbl_storySeen_Tbl_story_fk_storyID",
                        column: x => x.fk_storyID,
                        principalTable: "Tbl_story",
                        principalColumn: "storyID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_storySeen_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserWorkExperienceStamp",
                columns: table => new
                {
                    UserWorkExperienceStampID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_UserWorkExperienceID = table.Column<long>(nullable: true),
                    fk_UserID = table.Column<long>(nullable: true),
                    fk_stampedUSerID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserWorkExperienceStamp", x => x.UserWorkExperienceStampID);
                    table.ForeignKey(
                        name: "FK_Tbl_UserWorkExperienceStamp_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_UserWorkExperienceStamp_Tbl_UserWorkExperience_fk_UserWorkExperienceID",
                        column: x => x.fk_UserWorkExperienceID,
                        principalTable: "Tbl_UserWorkExperience",
                        principalColumn: "UserEduBackID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_UserWorkExperienceStamp_Tbl_RadFBUsers_fk_stampedUSerID",
                        column: x => x.fk_stampedUSerID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_AnswerToQuestion",
                columns: table => new
                {
                    ParentID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChildID = table.Column<long>(nullable: false),
                    postDescription = table.Column<string>(nullable: true),
                    RegisterDate = table.Column<string>(nullable: true),
                    RegisterTime = table.Column<string>(nullable: true),
                    fk_UserID = table.Column<long>(nullable: true),
                    fk_QuestiontID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_AnswerToQuestion", x => x.ParentID);
                    table.ForeignKey(
                        name: "FK_Tbl_AnswerToQuestion_Tbl_AnswerToQuestion_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Tbl_AnswerToQuestion",
                        principalColumn: "ParentID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_AnswerToQuestion_Tbl_Question_fk_QuestiontID",
                        column: x => x.fk_QuestiontID,
                        principalTable: "Tbl_Question",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_AnswerToQuestion_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_savedQuestion",
                columns: table => new
                {
                    savedQuestionID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_userID = table.Column<long>(nullable: true),
                    fk_QuestionID = table.Column<long>(nullable: true),
                    pin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_savedQuestion", x => x.savedQuestionID);
                    table.ForeignKey(
                        name: "FK_Tbl_savedQuestion_Tbl_Question_fk_QuestionID",
                        column: x => x.fk_QuestionID,
                        principalTable: "Tbl_Question",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_savedQuestion_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_DeclarationOfReadiness",
                columns: table => new
                {
                    DeclarationOfReadinessID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_volunteerUserID = table.Column<long>(nullable: true),
                    fk_questionnaireID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_DeclarationOfReadiness", x => x.DeclarationOfReadinessID);
                    table.ForeignKey(
                        name: "FK_Tbl_DeclarationOfReadiness_Tbl_questionnaire_fk_questionnaireID",
                        column: x => x.fk_questionnaireID,
                        principalTable: "Tbl_questionnaire",
                        principalColumn: "questionnaireID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_DeclarationOfReadiness_Tbl_RadFBUsers_fk_volunteerUserID",
                        column: x => x.fk_volunteerUserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_savedQuestionnaire",
                columns: table => new
                {
                    savedQuestionnaireID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_userID = table.Column<long>(nullable: true),
                    fk_QuestionnaireID = table.Column<long>(nullable: true),
                    pin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_savedQuestionnaire", x => x.savedQuestionnaireID);
                    table.ForeignKey(
                        name: "FK_Tbl_savedQuestionnaire_Tbl_questionnaire_fk_QuestionnaireID",
                        column: x => x.fk_QuestionnaireID,
                        principalTable: "Tbl_questionnaire",
                        principalColumn: "questionnaireID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_savedQuestionnaire_Tbl_RadFBUsers_fk_userID",
                        column: x => x.fk_userID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CommentLike",
                columns: table => new
                {
                    CommentLikeID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_AnswerToQuestionID = table.Column<long>(nullable: true),
                    fk_UserID = table.Column<long>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CommentLike", x => x.CommentLikeID);
                    table.ForeignKey(
                        name: "FK_Tbl_CommentLike_Tbl_AnswerToQuestion_fk_AnswerToQuestionID",
                        column: x => x.fk_AnswerToQuestionID,
                        principalTable: "Tbl_AnswerToQuestion",
                        principalColumn: "ParentID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_CommentLike_Tbl_RadFBUsers_fk_UserID",
                        column: x => x.fk_UserID,
                        principalTable: "Tbl_RadFBUsers",
                        principalColumn: "RadFbUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Tbl_userAccessuserAccessID",
                table: "AspNetUsers",
                column: "Tbl_userAccessuserAccessID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_activeSesion_fk_userID",
                table: "Tbl_activeSesion",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_activities_fk_userID",
                table: "Tbl_activities",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_AnswerToQuestion_ChildID",
                table: "Tbl_AnswerToQuestion",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_AnswerToQuestion_fk_QuestiontID",
                table: "Tbl_AnswerToQuestion",
                column: "fk_QuestiontID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_AnswerToQuestion_fk_UserID",
                table: "Tbl_AnswerToQuestion",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_awards_fk_userID",
                table: "Tbl_awards",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_BlockedUsers_Tbl_RadFBUsersRadFbUserID",
                table: "Tbl_BlockedUsers",
                column: "Tbl_RadFBUsersRadFbUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_BlockedUsers_fk_BlockedUserID",
                table: "Tbl_BlockedUsers",
                column: "fk_BlockedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_BlockedUsers_fk_BlockingUSerID",
                table: "Tbl_BlockedUsers",
                column: "fk_BlockingUSerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_calender_fk_userID",
                table: "Tbl_calender",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CommentLike_fk_AnswerToQuestionID",
                table: "Tbl_CommentLike",
                column: "fk_AnswerToQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CommentLike_fk_UserID",
                table: "Tbl_CommentLike",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_criticsAndSuggestions_fk_senderUserID",
                table: "Tbl_criticsAndSuggestions",
                column: "fk_senderUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_DeclarationOfReadiness_fk_questionnaireID",
                table: "Tbl_DeclarationOfReadiness",
                column: "fk_questionnaireID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_DeclarationOfReadiness_fk_volunteerUserID",
                table: "Tbl_DeclarationOfReadiness",
                column: "fk_volunteerUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmploymentAdvApply_fk_ApplicantUserID",
                table: "Tbl_EmploymentAdvApply",
                column: "fk_ApplicantUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmploymentAdvApply_fk_postID",
                table: "Tbl_EmploymentAdvApply",
                column: "fk_postID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmploymentAdvPost_fk_CooperationTypeID",
                table: "Tbl_EmploymentAdvPost",
                column: "fk_CooperationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmploymentAdvPost_fk_PostID",
                table: "Tbl_EmploymentAdvPost",
                column: "fk_PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmploymentAdvPost_fk_countryID",
                table: "Tbl_EmploymentAdvPost",
                column: "fk_countryID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmploymentAdvPost_fk_genderID",
                table: "Tbl_EmploymentAdvPost",
                column: "fk_genderID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmploymentAdvPost_fk_grageID",
                table: "Tbl_EmploymentAdvPost",
                column: "fk_grageID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmploymentAdvPost_fk_jobCategoryID",
                table: "Tbl_EmploymentAdvPost",
                column: "fk_jobCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmploymentAdvPost_fk_mssID",
                table: "Tbl_EmploymentAdvPost",
                column: "fk_mssID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_factor_fk_payID",
                table: "Tbl_factor",
                column: "fk_payID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_followers_fk_UserID",
                table: "Tbl_followers",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_followers_fk_followerUSerID",
                table: "Tbl_followers",
                column: "fk_followerUSerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_FrequentlyAskedQuestions_fk_SubjectID",
                table: "Tbl_FrequentlyAskedQuestions",
                column: "fk_SubjectID",
                unique: true,
                filter: "[fk_SubjectID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_group_fk_creatorUserID",
                table: "Tbl_group",
                column: "fk_creatorUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_groupException_fk_ExecptionGroupID",
                table: "Tbl_groupException",
                column: "fk_ExecptionGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_groupException_fk_userID",
                table: "Tbl_groupException",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_groupMessages_fk_groupID",
                table: "Tbl_groupMessages",
                column: "fk_groupID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_groupMessages_fk_messageTypeID",
                table: "Tbl_groupMessages",
                column: "fk_messageTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_groupMessages_fk_senderUserID",
                table: "Tbl_groupMessages",
                column: "fk_senderUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_jobCategory_fk_guildID",
                table: "Tbl_jobCategory",
                column: "fk_guildID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_keyWords_fk_postID",
                table: "Tbl_keyWords",
                column: "fk_postID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_legalClient_fk_UserID",
                table: "Tbl_legalClient",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Logins_fk_userID",
                table: "Tbl_Logins",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_memberOfGroup_fk_UserID",
                table: "Tbl_memberOfGroup",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_memberOfGroup_fk_groupID",
                table: "Tbl_memberOfGroup",
                column: "fk_groupID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_messages_fk_ReciverUserID",
                table: "Tbl_messages",
                column: "fk_ReciverUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_messages_fk_messageTypeID",
                table: "Tbl_messages",
                column: "fk_messageTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_messages_fk_senderUserID",
                table: "Tbl_messages",
                column: "fk_senderUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_messagesException_fk_ExecptionUserID",
                table: "Tbl_messagesException",
                column: "fk_ExecptionUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_messagesException_fk_userID",
                table: "Tbl_messagesException",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_muteGroupMessage_fk_UserID",
                table: "Tbl_muteGroupMessage",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_muteGroupMessage_fk_groupID",
                table: "Tbl_muteGroupMessage",
                column: "fk_groupID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_muteMessages_fk_ReciverUserID",
                table: "Tbl_muteMessages",
                column: "fk_ReciverUserID",
                unique: true,
                filter: "[fk_ReciverUserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_muteMessages_fk_senderUserID",
                table: "Tbl_muteMessages",
                column: "fk_senderUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_MuteUsers_fk_MutedUserID",
                table: "Tbl_MuteUsers",
                column: "fk_MutedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_MuteUsers_fk_UserID",
                table: "Tbl_MuteUsers",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_notifications_fk_userID",
                table: "Tbl_notifications",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_packageOptions_fk_permiumPackageID",
                table: "Tbl_packageOptions",
                column: "fk_permiumPackageID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_packageOptions_fk_settingID",
                table: "Tbl_packageOptions",
                column: "fk_settingID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_pay_fk_permiumPackageID",
                table: "Tbl_pay",
                column: "fk_permiumPackageID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_pay_fk_userID",
                table: "Tbl_pay",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_pointsDetail_fk_pointID",
                table: "Tbl_pointsDetail",
                column: "fk_pointID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_pointsDetail_fk_userID",
                table: "Tbl_pointsDetail",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_post_fk_PostTypeID",
                table: "Tbl_post",
                column: "fk_PostTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_post_fk_UserID",
                table: "Tbl_post",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_postChanged_fk_userID",
                table: "Tbl_postChanged",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_postChangedException_fk_ExecptionUserID",
                table: "Tbl_postChangedException",
                column: "fk_ExecptionUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_postChangedException_fk_userID",
                table: "Tbl_postChangedException",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_poster_fk_countryID",
                table: "Tbl_poster",
                column: "fk_countryID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_poster_fk_genderID",
                table: "Tbl_poster",
                column: "fk_genderID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_poster_fk_posterTemplateID",
                table: "Tbl_poster",
                column: "fk_posterTemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_posterFilter_fk_countryID",
                table: "Tbl_posterFilter",
                column: "fk_countryID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_posterFilter_fk_genderID",
                table: "Tbl_posterFilter",
                column: "fk_genderID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PostFile_fk_postID",
                table: "Tbl_PostFile",
                column: "fk_postID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PostForward_fk_ForwardedUserID",
                table: "Tbl_PostForward",
                column: "fk_ForwardedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PostForward_fk_ForwardingUserID",
                table: "Tbl_PostForward",
                column: "fk_ForwardingUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PostForward_fk_PostID",
                table: "Tbl_PostForward",
                column: "fk_PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PostLike_fk_PostID",
                table: "Tbl_PostLike",
                column: "fk_PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PostLike_fk_UserID",
                table: "Tbl_PostLike",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_privacy_fk_userID",
                table: "Tbl_privacy",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_province_fk_countryID",
                table: "Tbl_province",
                column: "fk_countryID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Question_fk_JobCategoryID",
                table: "Tbl_Question",
                column: "fk_JobCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Question_fk_UserID",
                table: "Tbl_Question",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Question_fk_postID",
                table: "Tbl_Question",
                column: "fk_postID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_questionFilter_fk_JobCategoryID",
                table: "Tbl_questionFilter",
                column: "fk_JobCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_questionFilter_fk_subjectID",
                table: "Tbl_questionFilter",
                column: "fk_subjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_questionFilter_fk_userID",
                table: "Tbl_questionFilter",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_questionnaire_fk_ApplicantUserID",
                table: "Tbl_questionnaire",
                column: "fk_ApplicantUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_questionnaire_fk_JobCategoryID",
                table: "Tbl_questionnaire",
                column: "fk_JobCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_questionnaire_fk_genderID",
                table: "Tbl_questionnaire",
                column: "fk_genderID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_questionnaire_fk_postID",
                table: "Tbl_questionnaire",
                column: "fk_postID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_questionnaireFilter_fk_subjectID",
                table: "Tbl_questionnaireFilter",
                column: "fk_subjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_questionnaireFilter_fk_userID",
                table: "Tbl_questionnaireFilter",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RadFBUsers_fk_countryID",
                table: "Tbl_RadFBUsers",
                column: "fk_countryID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RadFBUsers_fk_jobCategoryID",
                table: "Tbl_RadFBUsers",
                column: "fk_jobCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RadFBUsers_fk_userTypeID",
                table: "Tbl_RadFBUsers",
                column: "fk_userTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RealCient_fk_CooperationID",
                table: "Tbl_RealCient",
                column: "fk_CooperationID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RealCient_fk_GenderID",
                table: "Tbl_RealCient",
                column: "fk_GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RealCient_fk_UserID",
                table: "Tbl_RealCient",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RealCient_fk_mssID",
                table: "Tbl_RealCient",
                column: "fk_mssID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_reportUsers_fk_ReportedUserID",
                table: "Tbl_reportUsers",
                column: "fk_ReportedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_reportUsers_fk_ReportingUSerID",
                table: "Tbl_reportUsers",
                column: "fk_ReportingUSerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_savedQuestion_fk_QuestionID",
                table: "Tbl_savedQuestion",
                column: "fk_QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_savedQuestion_fk_userID",
                table: "Tbl_savedQuestion",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_savedQuestionnaire_fk_QuestionnaireID",
                table: "Tbl_savedQuestionnaire",
                column: "fk_QuestionnaireID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_savedQuestionnaire_fk_userID",
                table: "Tbl_savedQuestionnaire",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_savedTopics_fk_subjectID",
                table: "Tbl_savedTopics",
                column: "fk_subjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_savedTopics_fk_userID",
                table: "Tbl_savedTopics",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_silentUsers_fk_silentUSerID",
                table: "Tbl_silentUsers",
                column: "fk_silentUSerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_silentUsers_fk_userID",
                table: "Tbl_silentUsers",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_story_fk_userID",
                table: "Tbl_story",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_storySeen_fk_storyID",
                table: "Tbl_storySeen",
                column: "fk_storyID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_storySeen_fk_userID",
                table: "Tbl_storySeen",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SuggestionUsers_fk_SuggestedUSerID",
                table: "Tbl_SuggestionUsers",
                column: "fk_SuggestedUSerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SuggestionUsers_fk_UserID",
                table: "Tbl_SuggestionUsers",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_userBackGroundSetting_fk_userID",
                table: "Tbl_userBackGroundSetting",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_userDiscount_fk_discountID",
                table: "Tbl_userDiscount",
                column: "fk_discountID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_userDiscount_fk_userID",
                table: "Tbl_userDiscount",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserEducationalBackground_fk_UserID",
                table: "Tbl_UserEducationalBackground",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserEducationalBackground_fk_gradeID",
                table: "Tbl_UserEducationalBackground",
                column: "fk_gradeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserEducationalBackground_fk_majorID",
                table: "Tbl_UserEducationalBackground",
                column: "fk_majorID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserFavorites_fk_UserID",
                table: "Tbl_UserFavorites",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserJobStatus_fk_JobStatusID",
                table: "Tbl_UserJobStatus",
                column: "fk_JobStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserJobStatus_fk_UserID",
                table: "Tbl_UserJobStatus",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserRegistrationCourses_fk_RegisteredUserID",
                table: "Tbl_UserRegistrationCourses",
                column: "fk_RegisteredUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserRegistrationCourses_fk_posterID",
                table: "Tbl_UserRegistrationCourses",
                column: "fk_posterID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_userSetting_fk_settingID",
                table: "Tbl_userSetting",
                column: "fk_settingID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_userSetting_fk_userID",
                table: "Tbl_userSetting",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_usersQuestions_fk_userID",
                table: "Tbl_usersQuestions",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_usersSearchs_fk_userID",
                table: "Tbl_usersSearchs",
                column: "fk_userID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UsersSkills_fk_SkillID",
                table: "Tbl_UsersSkills",
                column: "fk_SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UsersSkills_fk_UserID",
                table: "Tbl_UsersSkills",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserWorkExperience_fk_UserID",
                table: "Tbl_UserWorkExperience",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserWorkExperienceStamp_fk_UserID",
                table: "Tbl_UserWorkExperienceStamp",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserWorkExperienceStamp_fk_UserWorkExperienceID",
                table: "Tbl_UserWorkExperienceStamp",
                column: "fk_UserWorkExperienceID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserWorkExperienceStamp_fk_stampedUSerID",
                table: "Tbl_UserWorkExperienceStamp",
                column: "fk_stampedUSerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_VisitedPosts_fk_PostID",
                table: "Tbl_VisitedPosts",
                column: "fk_PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_VisitedPosts_fk_UserID",
                table: "Tbl_VisitedPosts",
                column: "fk_UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Voluntaryworks_fk_userID",
                table: "Tbl_Voluntaryworks",
                column: "fk_userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Tbl_activeSesion");

            migrationBuilder.DropTable(
                name: "Tbl_activities");

            migrationBuilder.DropTable(
                name: "Tbl_awards");

            migrationBuilder.DropTable(
                name: "Tbl_BlockedUsers");

            migrationBuilder.DropTable(
                name: "Tbl_calender");

            migrationBuilder.DropTable(
                name: "Tbl_CommentLike");

            migrationBuilder.DropTable(
                name: "Tbl_criticsAndSuggestions");

            migrationBuilder.DropTable(
                name: "Tbl_DeclarationOfReadiness");

            migrationBuilder.DropTable(
                name: "Tbl_dialog");

            migrationBuilder.DropTable(
                name: "Tbl_EmploymentAdvApply");

            migrationBuilder.DropTable(
                name: "Tbl_EmploymentAdvPost");

            migrationBuilder.DropTable(
                name: "Tbl_factor");

            migrationBuilder.DropTable(
                name: "Tbl_followers");

            migrationBuilder.DropTable(
                name: "Tbl_FrequentlyAskedQuestions");

            migrationBuilder.DropTable(
                name: "Tbl_groupException");

            migrationBuilder.DropTable(
                name: "Tbl_groupMessages");

            migrationBuilder.DropTable(
                name: "Tbl_Introduction");

            migrationBuilder.DropTable(
                name: "Tbl_keyWords");

            migrationBuilder.DropTable(
                name: "Tbl_legalClient");

            migrationBuilder.DropTable(
                name: "Tbl_Logins");

            migrationBuilder.DropTable(
                name: "Tbl_memberOfGroup");

            migrationBuilder.DropTable(
                name: "Tbl_messages");

            migrationBuilder.DropTable(
                name: "Tbl_messagesException");

            migrationBuilder.DropTable(
                name: "Tbl_muteGroupMessage");

            migrationBuilder.DropTable(
                name: "Tbl_muteMessages");

            migrationBuilder.DropTable(
                name: "Tbl_MuteUsers");

            migrationBuilder.DropTable(
                name: "Tbl_notifications");

            migrationBuilder.DropTable(
                name: "Tbl_packageOptions");

            migrationBuilder.DropTable(
                name: "Tbl_pointsDetail");

            migrationBuilder.DropTable(
                name: "Tbl_postChanged");

            migrationBuilder.DropTable(
                name: "Tbl_postChangedException");

            migrationBuilder.DropTable(
                name: "Tbl_posterFilter");

            migrationBuilder.DropTable(
                name: "Tbl_PostFile");

            migrationBuilder.DropTable(
                name: "Tbl_PostForward");

            migrationBuilder.DropTable(
                name: "Tbl_PostLike");

            migrationBuilder.DropTable(
                name: "Tbl_privacy");

            migrationBuilder.DropTable(
                name: "Tbl_province");

            migrationBuilder.DropTable(
                name: "Tbl_questionFilter");

            migrationBuilder.DropTable(
                name: "Tbl_questionnaireFilter");

            migrationBuilder.DropTable(
                name: "Tbl_RealCient");

            migrationBuilder.DropTable(
                name: "Tbl_reportUsers");

            migrationBuilder.DropTable(
                name: "Tbl_savedQuestion");

            migrationBuilder.DropTable(
                name: "Tbl_savedQuestionnaire");

            migrationBuilder.DropTable(
                name: "Tbl_savedTopics");

            migrationBuilder.DropTable(
                name: "Tbl_silentUsers");

            migrationBuilder.DropTable(
                name: "Tbl_siteSetting");

            migrationBuilder.DropTable(
                name: "Tbl_storySeen");

            migrationBuilder.DropTable(
                name: "Tbl_SuggestionUsers");

            migrationBuilder.DropTable(
                name: "Tbl_UnauthorizedWords");

            migrationBuilder.DropTable(
                name: "Tbl_userBackGroundSetting");

            migrationBuilder.DropTable(
                name: "Tbl_userDiscount");

            migrationBuilder.DropTable(
                name: "Tbl_UserEducationalBackground");

            migrationBuilder.DropTable(
                name: "Tbl_UserFavorites");

            migrationBuilder.DropTable(
                name: "Tbl_UserJobStatus");

            migrationBuilder.DropTable(
                name: "Tbl_UserRegistrationCourses");

            migrationBuilder.DropTable(
                name: "Tbl_userSetting");

            migrationBuilder.DropTable(
                name: "Tbl_usersQuestions");

            migrationBuilder.DropTable(
                name: "Tbl_usersSearchs");

            migrationBuilder.DropTable(
                name: "Tbl_UsersSkills");

            migrationBuilder.DropTable(
                name: "Tbl_UserWorkExperienceStamp");

            migrationBuilder.DropTable(
                name: "Tbl_VisitedPosts");

            migrationBuilder.DropTable(
                name: "Tbl_Voluntaryworks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tbl_AnswerToQuestion");

            migrationBuilder.DropTable(
                name: "Tbl_pay");

            migrationBuilder.DropTable(
                name: "Tbl_FrequentlyAskedQuestionsSubject");

            migrationBuilder.DropTable(
                name: "Tbl_messageType");

            migrationBuilder.DropTable(
                name: "Tbl_group");

            migrationBuilder.DropTable(
                name: "Tbl_points");

            migrationBuilder.DropTable(
                name: "Tbl_CooperationType");

            migrationBuilder.DropTable(
                name: "Tbl_militaryServiceSituation");

            migrationBuilder.DropTable(
                name: "Tbl_questionnaire");

            migrationBuilder.DropTable(
                name: "Tbl_subject");

            migrationBuilder.DropTable(
                name: "Tbl_story");

            migrationBuilder.DropTable(
                name: "Tbl_discount");

            migrationBuilder.DropTable(
                name: "Tbl_grade");

            migrationBuilder.DropTable(
                name: "Tbl_major");

            migrationBuilder.DropTable(
                name: "Tbl_jobStatus");

            migrationBuilder.DropTable(
                name: "Tbl_poster");

            migrationBuilder.DropTable(
                name: "Tbl_setting");

            migrationBuilder.DropTable(
                name: "Tbl_Skills");

            migrationBuilder.DropTable(
                name: "Tbl_UserWorkExperience");

            migrationBuilder.DropTable(
                name: "Tbl_userAccess");

            migrationBuilder.DropTable(
                name: "Tbl_Question");

            migrationBuilder.DropTable(
                name: "Tbl_permiumPackage");

            migrationBuilder.DropTable(
                name: "Tbl_gender");

            migrationBuilder.DropTable(
                name: "Tbl_posterTemplate");

            migrationBuilder.DropTable(
                name: "Tbl_post");

            migrationBuilder.DropTable(
                name: "postType");

            migrationBuilder.DropTable(
                name: "Tbl_RadFBUsers");

            migrationBuilder.DropTable(
                name: "Tbl_countries");

            migrationBuilder.DropTable(
                name: "Tbl_jobCategory");

            migrationBuilder.DropTable(
                name: "Tbl_userType");

            migrationBuilder.DropTable(
                name: "Tbl_guild");
        }
    }
}
