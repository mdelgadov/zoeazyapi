using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZoEazy.Api.Data.Migrations.ZoEazy
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    IsEnabled = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 250, nullable: true),
                    LastName = table.Column<string>(maxLength: 250, nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    DataEventRecordsRole = table.Column<string>(nullable: true),
                    SecuredFilesRole = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    ImageSource = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Website = table.Column<string>(nullable: true),
                    PaymentSystemId = table.Column<string>(nullable: true),
                    L4DSSN = table.Column<string>(maxLength: 4, nullable: true),
                    DateOfBirth_Day = table.Column<int>(nullable: false),
                    DateOfBirth_Month = table.Column<int>(nullable: false),
                    DateOfBirth_Year = table.Column<int>(nullable: false),
                    Suspended_Value = table.Column<bool>(nullable: false),
                    Suspended_setAtUtc = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Months = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Abbreviation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardBrands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Mnemonic = table.Column<string>(nullable: true),
                    Pattern = table.Column<string>(nullable: true),
                    EagerPattern = table.Column<string>(nullable: true),
                    GroupPattern = table.Column<string>(nullable: true),
                    CvcLength = table.Column<int>(nullable: false),
                    TestNumber = table.Column<string>(nullable: true),
                    MaskArray = table.Column<string>(nullable: true),
                    CvcName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cultures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Short = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
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
                    Name = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ECustomers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    ImageSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PredefinedSchedules",
                columns: table => new
                {
                    Dow = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Service = table.Column<int>(nullable: true),
                    OpensHour = table.Column<int>(nullable: true),
                    Day = table.Column<int>(nullable: true),
                    Month = table.Column<int>(nullable: true),
                    Year = table.Column<int>(nullable: true),
                    OpensMinute = table.Column<int>(nullable: true),
                    ClosesHour = table.Column<int>(nullable: true),
                    ClosesMinute = table.Column<int>(nullable: true),
                    Disable = table.Column<bool>(nullable: true),
                    Optional = table.Column<bool>(nullable: true),
                    CloseOfTheNextDay = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredefinedSchedules", x => x.Dow);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceLevel = table.Column<int>(nullable: false),
                    Charge = table.Column<decimal>(nullable: false),
                    Prepaid = table.Column<decimal>(nullable: false),
                    Net = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EntryTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
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
                    UserId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
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
                name: "Franchises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDirty = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CustomerType = table.Column<int>(nullable: false),
                    Subscriber_Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Franchises_AspNetUsers_Subscriber_Id",
                        column: x => x.Subscriber_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriberFaxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    Subscriber_Id = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberFaxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriberFaxes_AspNetUsers_Subscriber_Id",
                        column: x => x.Subscriber_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriberPhones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    Extension = table.Column<int>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    Subscriber_Id = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriberPhones_AspNetUsers_Subscriber_Id",
                        column: x => x.Subscriber_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Country_Id = table.Column<int>(nullable: false),
                    CountryName = table.Column<string>(nullable: true),
                    LocaleString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locales_Countries_Country_Id",
                        column: x => x.Country_Id,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Abbreviation = table.Column<string>(nullable: false),
                    Country_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_Country_Id",
                        column: x => x.Country_Id,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriberCreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sequence = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: true),
                    ActivatedUtc = table.Column<DateTimeOffset>(nullable: false),
                    ExpiredUtc = table.Column<DateTimeOffset>(nullable: false),
                    CCV = table.Column<string>(nullable: true),
                    ValidThruYear = table.Column<int>(nullable: false),
                    ValidThruMonth = table.Column<int>(nullable: false),
                    CreditCardBrand_Id = table.Column<int>(nullable: false),
                    TokenId = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(maxLength: 5, nullable: false),
                    Subscriber_Id = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberCreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriberCreditCards_CreditCardBrands_CreditCardBrand_Id",
                        column: x => x.CreditCardBrand_Id,
                        principalTable: "CreditCardBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriberCreditCards_AspNetUsers_Subscriber_Id",
                        column: x => x.Subscriber_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    CultureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Cultures_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cultures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sequence = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: true),
                    CCV = table.Column<string>(nullable: true),
                    ValidThruYear = table.Column<int>(nullable: false),
                    ValidThruMonth = table.Column<int>(nullable: false),
                    ActivatedUtc = table.Column<DateTimeOffset>(nullable: false),
                    ExpiredUtc = table.Column<DateTimeOffset>(nullable: false),
                    CreditCardBrand_Id = table.Column<int>(nullable: false),
                    TokenId = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(maxLength: 5, nullable: false),
                    Customer_Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerCreditCards_CreditCardBrands_CreditCardBrand_Id",
                        column: x => x.CreditCardBrand_Id,
                        principalTable: "CreditCardBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCreditCards_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPhones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    Extension = table.Column<int>(nullable: true),
                    IsCell = table.Column<bool>(nullable: false),
                    Sms = table.Column<bool>(nullable: false),
                    Memo = table.Column<string>(nullable: true),
                    Customer_Id = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPhones_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    ImageSource = table.Column<string>(nullable: true),
                    Sequence = table.Column<float>(nullable: false),
                    Customer_Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerId1 = table.Column<string>(nullable: true),
                    ECustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EOrders_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EOrders_ECustomers_ECustomerId",
                        column: x => x.ECustomerId,
                        principalTable: "ECustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    BuyingPrice = table.Column<decimal>(nullable: false),
                    SellingPrice = table.Column<decimal>(nullable: false),
                    UnitsInStock = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDiscontinued = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    ProductCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Products_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    CustomerType = table.Column<int>(nullable: false),
                    StripeCustomerId = table.Column<string>(nullable: true),
                    Franchise_Id = table.Column<int>(nullable: false),
                    Proposed = table.Column<bool>(nullable: true),
                    ProposedUtc = table.Column<DateTimeOffset>(nullable: false),
                    Executed = table.Column<bool>(nullable: true),
                    ExecutedUtc = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: true),
                    ActiveUtc = table.Column<DateTimeOffset>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Secret = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Redirection = table.Column<int>(nullable: false),
                    AppName = table.Column<string>(nullable: true),
                    Radius = table.Column<double>(nullable: true),
                    Unit = table.Column<int>(nullable: true),
                    Zoom = table.Column<double>(nullable: true),
                    BankAccountType = table.Column<int>(nullable: false),
                    Routing = table.Column<string>(maxLength: 9, nullable: true),
                    RoutingJson = table.Column<string>(nullable: true),
                    Account = table.Column<string>(maxLength: 8, nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Franchises_Franchise_Id",
                        column: x => x.Franchise_Id,
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FranchiseFaxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    Franchise_Id = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FranchiseFaxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FranchiseFaxes_Franchises_Franchise_Id",
                        column: x => x.Franchise_Id,
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FranchisePhones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    Extension = table.Column<int>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    AndFax = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false),
                    Franchise_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FranchisePhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FranchisePhones_Franchises_Franchise_Id",
                        column: x => x.Franchise_Id,
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Customer_Id = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Apartment = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 5, nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    State_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_States_State_Id",
                        column: x => x.State_Id,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FranchiseAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Franchise_Id = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Apartment = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 5, nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    State_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FranchiseAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FranchiseAddresses_Franchises_Franchise_Id",
                        column: x => x.Franchise_Id,
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FranchiseAddresses_States_State_Id",
                        column: x => x.State_Id,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubscriberAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Subscriber_Id = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Apartment = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 5, nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    State_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriberAddresses_States_State_Id",
                        column: x => x.State_Id,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubscriberAddresses_AspNetUsers_Subscriber_Id",
                        column: x => x.Subscriber_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZipCodes",
                columns: table => new
                {
                    Zip = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    PopulationAt2001 = table.Column<int>(nullable: false),
                    State_Id = table.Column<int>(nullable: false),
                    Area = table.Column<double>(nullable: false),
                    Sumblkpop = table.Column<int>(nullable: false),
                    Geometry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCodes", x => x.Zip);
                    table.ForeignKey(
                        name: "FK_ZipCodes_States_State_Id",
                        column: x => x.State_Id,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoritePresentations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<string>(nullable: true),
                    Favorite_Id = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritePresentations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritePresentations_Favorites_Favorite_Id",
                        column: x => x.Favorite_Id,
                        principalTable: "Favorites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Branch_Id = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Apartment = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 5, nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    State_Id = table.Column<int>(nullable: true),
                    Geological = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchAddresses_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchAddresses_States_State_Id",
                        column: x => x.State_Id,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BranchFaxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    Branch_Id = table.Column<int>(nullable: false),
                    AndPhone = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchFaxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchFaxes_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Branch_Id = table.Column<int>(nullable: false),
                    SubscriberCreditCard_Id = table.Column<int>(nullable: false),
                    Proposed = table.Column<bool>(nullable: false),
                    ProposedUtc = table.Column<DateTimeOffset>(nullable: false),
                    Executed = table.Column<bool>(nullable: false),
                    ExecutedUtc = table.Column<DateTimeOffset>(nullable: false),
                    Cancelled = table.Column<bool>(nullable: false),
                    CancelledUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchOrders_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchOrders_SubscriberCreditCards_SubscriberCreditCard_Id",
                        column: x => x.SubscriberCreditCard_Id,
                        principalTable: "SubscriberCreditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BranchPhones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    Extension = table.Column<int>(nullable: true),
                    IsCell = table.Column<bool>(nullable: true),
                    Sms = table.Column<bool>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    Branch_Id = table.Column<int>(nullable: false),
                    AndFax = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchPhones_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Branch_Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuisines_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAreas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Branch_Id = table.Column<int>(nullable: false),
                    IsClosed = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryAreas_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Footnote = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    ImageSource = table.Column<string>(nullable: true),
                    Sequence = table.Column<float>(nullable: false),
                    Branch_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    ImageSource = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: true),
                    Percentage = table.Column<double>(nullable: true),
                    Sequence = table.Column<float>(nullable: false),
                    OfferType_Id = table.Column<int>(nullable: true),
                    Branch_Id = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_OfferTypes_OfferType_Id",
                        column: x => x.OfferType_Id,
                        principalTable: "OfferTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Sequence = table.Column<float>(nullable: false),
                    Ordered = table.Column<bool>(nullable: false),
                    OrderedUtc = table.Column<DateTimeOffset>(nullable: false),
                    Prepped = table.Column<bool>(nullable: false),
                    PreppedUtc = table.Column<DateTimeOffset>(nullable: false),
                    Sent = table.Column<bool>(nullable: false),
                    SentUtc = table.Column<DateTimeOffset>(nullable: false),
                    Delivered = table.Column<bool>(nullable: false),
                    DeliveredUtc = table.Column<DateTimeOffset>(nullable: false),
                    Branch_Id = table.Column<int>(nullable: false),
                    Customer_Id = table.Column<string>(nullable: false),
                    CustomerCreditCardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_CustomerCreditCards_CustomerCreditCardId",
                        column: x => x.CustomerCreditCardId,
                        principalTable: "CustomerCreditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    PaymentSystemId = table.Column<string>(nullable: true),
                    FreeMonths = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Franchise_Id = table.Column<int>(nullable: true),
                    Branch_Id = table.Column<int>(nullable: true),
                    ValidFromUtc = table.Column<DateTimeOffset>(nullable: true),
                    ValidToUtc = table.Column<DateTimeOffset>(nullable: true),
                    Period_Id = table.Column<int>(nullable: false),
                    Nickname = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Charge = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    SetupCharge = table.Column<decimal>(nullable: false),
                    SetupDiscount = table.Column<decimal>(nullable: false),
                    Currency_Id = table.Column<int>(nullable: false),
                    DaysFree = table.Column<int>(nullable: false),
                    SetupDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_Franchises_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_Currencies_Currency_Id",
                        column: x => x.Currency_Id,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plans_ContractPeriods_Period_Id",
                        column: x => x.Period_Id,
                        principalTable: "ContractPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostalCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Branch_Id = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Valid = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostalCodes_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Branch_Id = table.Column<int>(nullable: false),
                    Dow = table.Column<int>(nullable: true),
                    Day = table.Column<short>(nullable: true),
                    Month = table.Column<int>(nullable: true),
                    Year = table.Column<int>(nullable: true),
                    Service = table.Column<int>(nullable: false),
                    OpensHour = table.Column<int>(nullable: true),
                    OpensMinute = table.Column<int>(nullable: true),
                    ClosesHour = table.Column<int>(nullable: true),
                    ClosesMinute = table.Column<int>(nullable: true),
                    CloseOfTheNextDay = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Disable = table.Column<bool>(nullable: true),
                    Optional = table.Column<bool>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebsiteNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Branch_Id = table.Column<int>(nullable: false),
                    Suffix = table.Column<string>(nullable: true),
                    Domain = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebsiteNames_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Corners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    StreetOf = table.Column<string>(nullable: true),
                    StreetAnd = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zip = table.Column<int>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    DeliveryArea_Id = table.Column<int>(nullable: false),
                    Geo = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corners_DeliveryAreas_DeliveryArea_Id",
                        column: x => x.DeliveryArea_Id,
                        principalTable: "DeliveryAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Corners_ZipCodes_Zip",
                        column: x => x.Zip,
                        principalTable: "ZipCodes",
                        principalColumn: "Zip",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Footnote = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    ImageSource = table.Column<string>(nullable: true),
                    Sequence = table.Column<float>(nullable: false),
                    Menu_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menus_Menu_Id",
                        column: x => x.Menu_Id,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuPresentations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<string>(nullable: true),
                    Menu_Id = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPresentations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuPresentations_Menus_Menu_Id",
                        column: x => x.Menu_Id,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    ImageSource = table.Column<string>(nullable: true),
                    Sequence = table.Column<float>(nullable: false),
                    Offer_Id = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    DeletedUtc = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferItems_Offers_Offer_Id",
                        column: x => x.Offer_Id,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EOrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    EOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EOrderDetails_EOrders_EOrderId",
                        column: x => x.EOrderId,
                        principalTable: "EOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EOrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EOrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    ImageSource = table.Column<string>(nullable: true),
                    Sequence = table.Column<float>(nullable: false),
                    Order_Id = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchOrder_Id = table.Column<int>(nullable: false),
                    Charge = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Currency_Id = table.Column<int>(nullable: false),
                    Concept = table.Column<string>(nullable: true),
                    Period_Id = table.Column<int>(nullable: false),
                    Plan_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchOrderItems_BranchOrders_BranchOrder_Id",
                        column: x => x.BranchOrder_Id,
                        principalTable: "BranchOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchOrderItems_Currencies_Currency_Id",
                        column: x => x.Currency_Id,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchOrderItems_ContractPeriods_Period_Id",
                        column: x => x.Period_Id,
                        principalTable: "ContractPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchOrderItems_Plans_Plan_Id",
                        column: x => x.Plan_Id,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchOrderService",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchOrder_Id = table.Column<int>(nullable: false),
                    Charge = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Currency_Id = table.Column<int>(nullable: false),
                    MonthsFree = table.Column<int>(nullable: false),
                    Concept = table.Column<string>(nullable: true),
                    Service_Id = table.Column<int>(nullable: false),
                    Plan_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOrderService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchOrderService_BranchOrders_BranchOrder_Id",
                        column: x => x.BranchOrder_Id,
                        principalTable: "BranchOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchOrderService_Currencies_Currency_Id",
                        column: x => x.Currency_Id,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchOrderService_Plans_Plan_Id",
                        column: x => x.Plan_Id,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Branch_Id = table.Column<int>(nullable: false),
                    Plan_Id = table.Column<int>(nullable: false),
                    SubscriberCreditCard_Id = table.Column<int>(nullable: false),
                    CreatedUtc = table.Column<DateTimeOffset>(nullable: false),
                    ActiveUtc = table.Column<DateTimeOffset>(nullable: false),
                    CancelledUtc = table.Column<DateTimeOffset>(nullable: false),
                    ExpiredUtc = table.Column<DateTimeOffset>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Plans_Plan_Id",
                        column: x => x.Plan_Id,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_SubscriberCreditCards_SubscriberCreditCard_Id",
                        column: x => x.SubscriberCreditCard_Id,
                        principalTable: "SubscriberCreditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Plan_Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_Plans_Plan_Id",
                        column: x => x.Plan_Id,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CornerFromId = table.Column<int>(nullable: true),
                    CornerToId = table.Column<int>(nullable: true),
                    DeliveryArea_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sides_Corners_CornerFromId",
                        column: x => x.CornerFromId,
                        principalTable: "Corners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sides_Corners_CornerToId",
                        column: x => x.CornerToId,
                        principalTable: "Corners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sides_DeliveryAreas_DeliveryArea_Id",
                        column: x => x.DeliveryArea_Id,
                        principalTable: "DeliveryAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemPresentations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<string>(nullable: true),
                    MenuItem_Id = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemPresentations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItemPresentations_MenuItems_MenuItem_Id",
                        column: x => x.MenuItem_Id,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferPresentations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<string>(nullable: true),
                    OfferItem_Id = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferPresentations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferPresentations_OfferItems_OfferItem_Id",
                        column: x => x.OfferItem_Id,
                        principalTable: "OfferItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPresentations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<string>(nullable: true),
                    OrderItem_Id = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPresentations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPresentations_OrderItems_OrderItem_Id",
                        column: x => x.OrderItem_Id,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contract_Id = table.Column<int>(nullable: false),
                    Plan_Id = table.Column<int>(nullable: false),
                    PlanId = table.Column<int>(nullable: true),
                    ActiveFromUtc = table.Column<DateTimeOffset>(nullable: false),
                    ActiveToUtc = table.Column<DateTimeOffset>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Response = table.Column<string>(nullable: true),
                    ContractPeriodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractItems_ContractPeriods_ContractPeriodId",
                        column: x => x.ContractPeriodId,
                        principalTable: "ContractPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractItems_Contracts_Contract_Id",
                        column: x => x.Contract_Id,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractItems_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contract_Id = table.Column<int>(nullable: false),
                    ContractItem_Id = table.Column<int>(nullable: true),
                    Concept = table.Column<string>(nullable: true),
                    Charge = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Currency_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractServices_ContractItems_ContractItem_Id",
                        column: x => x.ContractItem_Id,
                        principalTable: "ContractItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractServices_Currencies_Currency_Id",
                        column: x => x.Currency_Id,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_BranchAddresses_Branch_Id",
                table: "BranchAddresses",
                column: "Branch_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BranchAddresses_State_Id",
                table: "BranchAddresses",
                column: "State_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Franchise_Id",
                table: "Branches",
                column: "Franchise_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BranchFaxes_Branch_Id",
                table: "BranchFaxes",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrderItems_BranchOrder_Id",
                table: "BranchOrderItems",
                column: "BranchOrder_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrderItems_Currency_Id",
                table: "BranchOrderItems",
                column: "Currency_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrderItems_Period_Id",
                table: "BranchOrderItems",
                column: "Period_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrderItems_Plan_Id",
                table: "BranchOrderItems",
                column: "Plan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrders_Branch_Id",
                table: "BranchOrders",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrders_SubscriberCreditCard_Id",
                table: "BranchOrders",
                column: "SubscriberCreditCard_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrderService_BranchOrder_Id",
                table: "BranchOrderService",
                column: "BranchOrder_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrderService_Currency_Id",
                table: "BranchOrderService",
                column: "Currency_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOrderService_Plan_Id",
                table: "BranchOrderService",
                column: "Plan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BranchPhones_Branch_Id",
                table: "BranchPhones",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContractItems_ContractPeriodId",
                table: "ContractItems",
                column: "ContractPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractItems_Contract_Id",
                table: "ContractItems",
                column: "Contract_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContractItems_PlanId",
                table: "ContractItems",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_Branch_Id",
                table: "Contracts",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_Plan_Id",
                table: "Contracts",
                column: "Plan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_SubscriberCreditCard_Id",
                table: "Contracts",
                column: "SubscriberCreditCard_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContractServices_ContractItem_Id",
                table: "ContractServices",
                column: "ContractItem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContractServices_Currency_Id",
                table: "ContractServices",
                column: "Currency_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Corners_DeliveryArea_Id",
                table: "Corners",
                column: "DeliveryArea_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Corners_Zip",
                table: "Corners",
                column: "Zip");

            migrationBuilder.CreateIndex(
                name: "IX_Cuisines_Branch_Id",
                table: "Cuisines",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_Customer_Id",
                table: "CustomerAddresses",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_State_Id",
                table: "CustomerAddresses",
                column: "State_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCreditCards_CreditCardBrand_Id",
                table: "CustomerCreditCards",
                column: "CreditCardBrand_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCreditCards_Customer_Id",
                table: "CustomerCreditCards",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhones_Customer_Id",
                table: "CustomerPhones",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAreas_Branch_Id",
                table: "DeliveryAreas",
                column: "Branch_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EOrderDetails_EOrderId",
                table: "EOrderDetails",
                column: "EOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_EOrderDetails_OrderId",
                table: "EOrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_EOrderDetails_ProductId",
                table: "EOrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EOrders_CustomerId1",
                table: "EOrders",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_EOrders_ECustomerId",
                table: "EOrders",
                column: "ECustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePresentations_Favorite_Id",
                table: "FavoritePresentations",
                column: "Favorite_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Customer_Id",
                table: "Favorites",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Features_Plan_Id",
                table: "Features",
                column: "Plan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FranchiseAddresses_Franchise_Id",
                table: "FranchiseAddresses",
                column: "Franchise_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FranchiseAddresses_State_Id",
                table: "FranchiseAddresses",
                column: "State_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FranchiseFaxes_Franchise_Id",
                table: "FranchiseFaxes",
                column: "Franchise_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FranchisePhones_Franchise_Id",
                table: "FranchisePhones",
                column: "Franchise_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Franchises_Subscriber_Id",
                table: "Franchises",
                column: "Subscriber_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Locales_Country_Id",
                table: "Locales",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemPresentations_MenuItem_Id",
                table: "MenuItemPresentations",
                column: "MenuItem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_Menu_Id",
                table: "MenuItems",
                column: "Menu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPresentations_Menu_Id",
                table: "MenuPresentations",
                column: "Menu_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Branch_Id",
                table: "Menus",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_Offer_Id",
                table: "OfferItems",
                column: "Offer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OfferPresentations_OfferItem_Id",
                table: "OfferPresentations",
                column: "OfferItem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_Branch_Id",
                table: "Offers",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CurrencyId",
                table: "Offers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OfferType_Id",
                table: "Offers",
                column: "OfferType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_Order_Id",
                table: "OrderItems",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPresentations_OrderItem_Id",
                table: "OrderPresentations",
                column: "OrderItem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Branch_Id",
                table: "Orders",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerCreditCardId",
                table: "Orders",
                column: "CustomerCreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Customer_Id",
                table: "Orders",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_Branch_Id",
                table: "Plans",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_Currency_Id",
                table: "Plans",
                column: "Currency_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_Period_Id",
                table: "Plans",
                column: "Period_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PostalCodes_Branch_Id",
                table: "PostalCodes",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_CultureId",
                table: "Resources",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Branch_Id",
                table: "Schedules",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sides_CornerFromId",
                table: "Sides",
                column: "CornerFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Sides_CornerToId",
                table: "Sides",
                column: "CornerToId");

            migrationBuilder.CreateIndex(
                name: "IX_Sides_DeliveryArea_Id",
                table: "Sides",
                column: "DeliveryArea_Id");

            migrationBuilder.CreateIndex(
                name: "IX_States_Country_Id",
                table: "States",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberAddresses_State_Id",
                table: "SubscriberAddresses",
                column: "State_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberAddresses_Subscriber_Id",
                table: "SubscriberAddresses",
                column: "Subscriber_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberCreditCards_CreditCardBrand_Id",
                table: "SubscriberCreditCards",
                column: "CreditCardBrand_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberCreditCards_Subscriber_Id",
                table: "SubscriberCreditCards",
                column: "Subscriber_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberFaxes_Subscriber_Id",
                table: "SubscriberFaxes",
                column: "Subscriber_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberPhones_Subscriber_Id",
                table: "SubscriberPhones",
                column: "Subscriber_Id");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteNames_Branch_Id",
                table: "WebsiteNames",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ZipCodes_State_Id",
                table: "ZipCodes",
                column: "State_Id");
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
                name: "BranchAddresses");

            migrationBuilder.DropTable(
                name: "BranchFaxes");

            migrationBuilder.DropTable(
                name: "BranchOrderItems");

            migrationBuilder.DropTable(
                name: "BranchOrderService");

            migrationBuilder.DropTable(
                name: "BranchPhones");

            migrationBuilder.DropTable(
                name: "ContractServices");

            migrationBuilder.DropTable(
                name: "Cuisines");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "CustomerPhones");

            migrationBuilder.DropTable(
                name: "EOrderDetails");

            migrationBuilder.DropTable(
                name: "FavoritePresentations");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "FranchiseAddresses");

            migrationBuilder.DropTable(
                name: "FranchiseFaxes");

            migrationBuilder.DropTable(
                name: "FranchisePhones");

            migrationBuilder.DropTable(
                name: "Locales");

            migrationBuilder.DropTable(
                name: "MenuItemPresentations");

            migrationBuilder.DropTable(
                name: "MenuPresentations");

            migrationBuilder.DropTable(
                name: "OfferPresentations");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "OrderPresentations");

            migrationBuilder.DropTable(
                name: "PostalCodes");

            migrationBuilder.DropTable(
                name: "PredefinedSchedules");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Setups");

            migrationBuilder.DropTable(
                name: "Sides");

            migrationBuilder.DropTable(
                name: "SubscriberAddresses");

            migrationBuilder.DropTable(
                name: "SubscriberFaxes");

            migrationBuilder.DropTable(
                name: "SubscriberPhones");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "WebsiteNames");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BranchOrders");

            migrationBuilder.DropTable(
                name: "ContractItems");

            migrationBuilder.DropTable(
                name: "EOrders");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "OfferItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Cultures");

            migrationBuilder.DropTable(
                name: "Corners");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "ECustomers");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryAreas");

            migrationBuilder.DropTable(
                name: "ZipCodes");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "SubscriberCreditCards");

            migrationBuilder.DropTable(
                name: "OfferTypes");

            migrationBuilder.DropTable(
                name: "CustomerCreditCards");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "ContractPeriods");

            migrationBuilder.DropTable(
                name: "CreditCardBrands");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Franchises");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
