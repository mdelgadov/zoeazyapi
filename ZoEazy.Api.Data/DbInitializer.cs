using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZoEazy.Api.Data;
using ZoEazy.Api.Model;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;

public class DbInitializer
{
    private static string _name = "Miguel";
    private static string _password = "VVirals13.7";
    private static string _email = "mdelgadov@hotmail.com";

    private static string _admin = "Admin";
    private static string _customer = "Customer";
    private static string[] _roles = { _admin, "Manager", "Staff", _customer };
    private static ZoeazyDbContext _context;

    private static Subscriber _subscriber;
    public static async Task Initialize(ZoeazyDbContext context, ILogger<DbInitializer> logger)
    {
        _context = context;
        _context.Database.EnsureCreated();
        _subscriber = _context.Subscribers.First(s => s.Email == "mdelgadov@hotmail.com");

        // if (context.Users.Any()) return; // DB has been seeded

        // await CreateDefaultUserAndRoleForApplication(userManager, roleManager, logger);

        await InitDemo();
    }
    //private static async Task AddDefaultRoleToDefaultUser(UserManager<Subscriber> um, ILogger<DbInitializer> logger)
    //{
    //    logger.LogInformation($"Add default user `{_email}` to role '{_admin}'");
    //    var ir = await um.AddToRoleAsync(_subscriber, _admin);
    //    if (ir.Succeeded)
    //    {
    //        logger.LogDebug($"Added the role '{_admin}' to default user `{_email}` successfully");
    //    }
    //    else
    //    {
    //        var exception = new ApplicationException($"The role `{_admin}` cannot be set for the user `{_email}`");
    //        logger.LogError(exception, GetIdentiryErrorsInCommaSeperatedList(ir));
    //        throw exception;
    //    }
    //}
    //private static async Task CreateDefaultUserAndRoleForApplication(UserManager<Subscriber> um, RoleManager<IdentityRole> rm, ILogger<DbInitializer> logger)
    //{
    //    await CreateDefaultAdministratorRole(rm, logger);
    //    await CreateOtherRoles(rm);
    //    _subscriber = await CreateDefaultUser(um, logger);
    //    await AddDefaultRoleToDefaultUser(um, logger);
    //}
    //private static async Task CreateDefaultAdministratorRole(RoleManager<IdentityRole> rm, ILogger<DbInitializer> logger)
    //{
    //    logger.LogInformation($"Create the role `{_admin}` for application");
    //    var ir = await rm.CreateAsync(new IdentityRole(_admin));
    //    if (ir.Succeeded)
    //    {
    //        logger.LogDebug($"Created the role `{_admin}` successfully");
    //    }
    //    else
    //    {
    //        var exception = new ApplicationException($"Default role `{_admin}` cannot be created");
    //        logger.LogError(exception, GetIdentiryErrorsInCommaSeperatedList(ir));
    //        throw exception;
    //    }
    //}
    //private static async Task<Subscriber> CreateDefaultUser(UserManager<Subscriber> um, ILogger<DbInitializer> logger)
    //{
    //    logger.LogInformation($"Create default user with email `{_email}` for application");
    //    var user = new Subscriber
    //    {
    //        FirstName = "Miguel",
    //        LastName = "Delgado",
    //        Email = _email,
    //        NormalizedEmail = _email.ToUpperInvariant(),
    //        UserName = _email,
    //        NormalizedUserName = _email.ToUpperInvariant(),
    //        PhoneNumber = "+7187209661",
    //        EmailConfirmed = true,
    //        PhoneNumberConfirmed = true,
    //        SecurityStamp = Guid.NewGuid().ToString("D"),
    //        Gender = Gender.Male

    //    };
    //    var password = new PasswordHasher<Subscriber>();
    //    user.PasswordHash = password.HashPassword(user, _password);
    //    var ir = await um.CreateAsync(user);
    //    if (ir.Succeeded)
    //    {
    //        logger.LogDebug($"Created default user `{_email}` successfully");
    //    }
    //    else
    //    {
    //        var exception = new ApplicationException($"Default user `{_email}` cannot be created");
    //        logger.LogError(exception, GetIdentiryErrorsInCommaSeperatedList(ir));
    //        throw exception;
    //    }

    //    var createdUser = await um.FindByEmailAsync(_email);
    //    return createdUser;
    //}
    //private static async Task CreateOtherRoles(RoleManager<IdentityRole> rm)
    //{

    //    foreach (var roleName in _roles)
    //    {
    //        var createdUser = await rm.FindByNameAsync(roleName);
    //        if (createdUser == null)
    //        {
    //            var ir = await rm.CreateAsync(new IdentityRole(roleName));
    //        }

    //    }
    //}
    private static string GetIdentiryErrorsInCommaSeperatedList(IdentityResult ir)
    {
        string errors = null;
        foreach (var identityError in ir.Errors)
        {
            errors += identityError.Description;
            errors += ", ";
        }
        return errors;
    }
    // data
    private static async Task InitDemo()

    {
        await InitCreditCards();
        await InitCountries();
        await InitLocales();
        await InitCurrencies();
        await InitContractPeriods();
        await InitFranchises();
        await InitBranches();
        await InitCuisines();
        await InitCustomer();
        await InitPlans();
        await InitPredefinedSchedules();
        await FinishDetails();
       
        
        
        await Complement();
        await InitZipCodes();
    }
    private static async Task Complement()
    {
        try
        {
            await _context.Database.ExecuteSqlCommandAsync(@"
				DROP TRIGGER [dbo].[UpdateContract]
				");
        }
        catch
        {
        }
        try
        {
            //trigger for Position geography field derived from longitude and latitiude of the address...
            await _context.Database.ExecuteSqlCommandAsync(@"
					create TRIGGER [dbo].[UpdateContract]
					ON [dbo].[BranchOrderItems]
					FOR Insert
					AS 
					Begin
				
					DECLARE @contract int
					declare @branch int
								
					select @branch = branch_id from contracts, inserted where contracts.id = inserted.contract_id

						UPDATE Contracts Set	
						Proposed = 'false',
						Active = 'true',
						ActiveUTC = GETUTCDATE(),
                        Cancelled = 'false'
						FROM Inserted
						WHERE inserted.Contract_Id = Contracts.Id

					UPDATE Contracts Set	
						Active = 'false',
						Cancelled = 'true',
                        CancelledUTC = GETUTCDATE()
						FROM Inserted 
						where contracts.branch_id = @branch and contracts.id != inserted.contract_id

					End
				");
        }
        catch (Exception e)
        {
            ;
        }

        //ALTER TABLE dbo.doc_exa ADD column_b VARCHAR(20) NULL, column_c INT NULL ;  
        try
        {
            await _context.Database.ExecuteSqlCommandAsync(@"
				alter table [dbo].[FranchiseAddresses] Add Position geography null;
				alter table [dbo].[BranchAddresses] Add Position geography null;
				alter table [dbo].[SubscriberAddresses] Add Position geography null;
				alter table [dbo].[CustomerAddresses] Add Position geography null;
				alter table [dbo].[Corners] Add Position geography null;
                ");
        }
        catch (Exception e)
        {
            ;
        }


        try
        {
            await _context.Database.ExecuteSqlCommandAsync(@"
				DROP TRIGGER [dbo].[FranchisePosition]
                ");
        }
        catch (Exception e)
        {
            ;
        }
        try
        {
            //trigger for Position geography field derived from longitude and latitiude of the address...
            await _context.Database.ExecuteSqlCommandAsync(@"
				create TRIGGER [dbo].[FranchisePosition]
				ON [dbo].[FranchiseAddresses]
				FOR Insert, UPDATE
				AS 
				Begin

				 UPDATE FranchiseAddresses SET Position = geography::Parse('POINT(' + CAST(FranchiseAddresses.[Longitude] AS VARCHAR(20)) + ' ' + CAST(FranchiseAddresses.[Latitude] AS VARCHAR(20)) + ')')
				  FROM INSERTED
				  WHERE inserted.id=FranchiseAddresses.id
			    End
				");
        }
        catch (Exception e)
        {
            ;
        }
        try
        {
            await _context.Database.ExecuteSqlCommandAsync(@"
				DROP TRIGGER [dbo].[BranchPosition]
				");
        }
        catch
        {
        }
        try
        {
            //trigger for Position geography field derived from longitude and latitiude of the address...
            await _context.Database.ExecuteSqlCommandAsync(@"
                create TRIGGER [dbo].[BranchPosition]
				ON [dbo].[BranchAddresses]
				FOR Insert, UPDATE
				AS 
				Begin

				 UPDATE BranchAddresses SET Position = geography::Parse('POINT(' + CAST(BranchAddresses.[Longitude] AS VARCHAR(20)) + ' ' + CAST(BranchAddresses.[Latitude] AS VARCHAR(20)) + ')')
				  FROM INSERTED
				  WHERE inserted.id=BranchAddresses.id
			    End

				");
        }
        catch (Exception e)
        {
        }
        try
        {
            await _context.Database.ExecuteSqlCommandAsync(@"
				DROP TRIGGER [dbo].[SubscriberPosition]
				");
        }
        catch
        {
        }
        try
        {
            //trigger for Position geography field derived from longitude and latitiude of the address...
            await _context.Database.ExecuteSqlCommandAsync(@"
                create TRIGGER [dbo].[SubscriberPosition]
				ON [dbo].[SubscriberAddresses]
				FOR Insert, UPDATE
				AS 
				Begin

				 UPDATE SubscriberAddresses SET Position = geography::Parse('POINT(' + CAST(SubscriberAddresses.[Longitude] AS VARCHAR(20)) + ' ' + CAST(SubscriberAddresses.[Latitude] AS VARCHAR(20)) + ')')
				  FROM INSERTED
				  WHERE inserted.id=SubscriberAddresses.id
			    End

				");
        }
        catch (Exception e)
        {
        }
        try
        {
            await _context.Database.ExecuteSqlCommandAsync(@"
				DROP TRIGGER [dbo].[CustomerPosition]
				");
        }
        catch
        {
        }
        try
        {
            //trigger for Position geography field derived from longitude and latitiude of the address...
            await _context.Database.ExecuteSqlCommandAsync(@"
                create TRIGGER [dbo].[CustomerPosition]
				ON [dbo].[CustomerAddresses]
				FOR Insert, UPDATE
				AS 
				Begin

				 UPDATE CustomerAddresses SET Position = geography::Parse('POINT(' + CAST(CustomerAddresses.[Longitude] AS VARCHAR(20)) + ' ' + CAST(CustomerAddresses.[Latitude] AS VARCHAR(20)) + ')')
				  FROM INSERTED
				  WHERE inserted.id=CustomerAddresses.id
			    End

				");
        }
        catch (Exception e)
        {
        }
        try
        {
            //trigger for Position geography field derived from longitude and latitiude of the address...
            await _context.Database.ExecuteSqlCommandAsync(@"
                create TRIGGER [dbo].[CornerPosition]
				ON [dbo].[Corners]
				FOR Insert, UPDATE
				AS 
				Begin

				 UPDATE Corners SET Position = geography::Parse('POINT(' + CAST(Corners.[Longitude] AS VARCHAR(20)) + ' ' + CAST(Corners.[Latitude] AS VARCHAR(20)) + ')')
				  FROM INSERTED
				  WHERE inserted.id=Corners.id
			    End

				");
        }
        catch (Exception e)
        {
        }
    }
    private static async Task FinishDetails()
    {

        var phone = new SubscriberPhone
        {
            Subscriber = _subscriber,
            Number = "12345678901"
        };

        var address = new SubscriberAddress
        {
            Subscriber = _subscriber,
            Street = "10 Hamilton St.",
            Apartment = "2nd Floor",
            City = "Staten Island",
            PostalCode = "10304",
            Latitude = 40.788645,
            Longitude = -73.9707,
            State = _context.States.First(s => s.Code == "NY")
        };

        await _context.SubscriberPhones.AddAsync(phone);
        await _context.SubscriberAddresses.AddAsync(address);

        var bphone = new BranchPhone
        {
            Branch = _context.Branches.First(),
            Number = "12345678901"
        };

        var baddress = new BranchAddress
        {
            Branch = _context.Branches.First(),
            Street = "10 Hamilton St.",
            Apartment = "2nd Floor",
            City = "Staten Island",
            PostalCode = "10304",
            Latitude = 40.788645,
            Longitude = -73.9707,
            State = _context.States.First(s => s.Code == "NY")
        };

        await _context.BranchPhones.AddAsync(bphone);
        await _context.BranchAddresses.AddAsync(baddress);
        var fphone = new FranchisePhone
        {
            Franchise = _context.Franchises.First(),
            Number = "12345678901"
        };

        var faddress = new FranchiseAddress
        {
            Franchise = _context.Franchises.First(),
            Street = "10 Hamilton St.",
            Apartment = "2nd Floor",
            City = "Staten Island",
            PostalCode = "10304",
            Latitude = 40.788645,
            Longitude = -73.9707,
            State = _context.States.First(s => s.Code == "NY")
        };

        await _context.FranchisePhones.AddAsync(fphone);
        await _context.FranchiseAddresses.AddAsync(faddress);


        var cphone = new CustomerPhone
        {
            Customer = _context.Customers.First(),
            Number = "12345678901"
        };

        var caddress = new CustomerAddress
        {
            Customer = _context.Customers.First(),
            Street = "10 Hamilton St.",
            Apartment = "2nd Floor",
            City = "Staten Island",
            PostalCode = "10304",
            Latitude = 40.788645,
            Longitude = -73.9707,
            State = _context.States.First(s => s.Code == "NY")
        };

        await _context.CustomerPhones.AddAsync(cphone);
        await _context.CustomerAddresses.AddAsync(caddress);

        await _context.SaveChangesAsync();
    }
    private static async Task InitCreditCards()
    {
        try
        {
            //Trace.WriteLine("Credit Cards");
            var creditCard = new CreditCardDict();

            foreach (var brand in creditCard.Brands)
            {

                var brandI = new CreditCardBrand
                {
                    //Id = brand.Key,
                    Name = brand.Value
                };

                switch (brand.Value)
                {
                    case "AmericanExpress":
                        brandI.Id = CreditCardEnum.AmericanExpress;
                        brandI.Pattern = "^3[47][0-9]{13}$";
                        brandI.CvcLength = 4;
                        brandI.TestNumber = "370000000000002";
                        brandI.EagerPattern = "^3[47]";
                        brandI.GroupPattern = "(\\d{1,4})(\\d{1,6})?(\\d{1,5})?";
                        brandI.Mnemonic = "amex";
                        brandI.MaskArray = @"/[1-9]/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/, /\d/";
                        brandI.CvcName = "CID";
                        break;
                    case "Visa":
                        brandI.Id = CreditCardEnum.Visa;
                        brandI.Pattern = "^4[0-9]{12}(?:[0-9]{3})?$";
                        brandI.CvcLength = 3;
                        brandI.TestNumber = "4007000000000027";
                        brandI.EagerPattern = "^4";
                        brandI.GroupPattern = "(\\d{1,4})(\\d{1,4})?(\\d{1,4})?(\\d{1,4})?(\\d{1,3})?";
                        brandI.Mnemonic = "visa";
                        brandI.MaskArray = @"/[1-9]/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/";
                        brandI.CvcName = "CVV";
                        break;
                    case "MasterCard":
                        brandI.Id = CreditCardEnum.MasterCard;
                        brandI.Pattern = "^5[1-5][0-9]{14}$";
                        brandI.CvcLength = 3;
                        brandI.TestNumber = "5424000000000015";
                        brandI.EagerPattern = "^5[1-5]";
                        brandI.GroupPattern = "(\\d{1,4})(\\d{1,4})?(\\d{1,4})?(\\d{1,4})?(\\d{1,3})?";
                        brandI.Mnemonic = "mc";
                        brandI.MaskArray = @"/[1-9]/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/";
                        brandI.CvcName = "CVC";
                        break;
                    case "DinersClub":
                        brandI.Id = CreditCardEnum.DinersClub;
                        brandI.Pattern = "^3(?:0[0-5]|[68][0-9])[0-9]{11}$";
                        brandI.TestNumber = "";
                        brandI.CvcLength = 3;
                        brandI.TestNumber = "38000000000006";
                        brandI.EagerPattern = "^3(0|[68])";
                        brandI.GroupPattern = "(\\d{1,4})?(\\d{1,6})?(\\d{1,4})?";
                        brandI.Mnemonic = "diners";
                        brandI.MaskArray = @"/[1-9]/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/";
                        brandI.CvcName = "CID";
                        break;
                    case "Discover":
                        brandI.Id = CreditCardEnum.Discover;
                        brandI.Pattern = "^6(?:011|5[0-9]{2})[0-9]{12}$";
                        brandI.TestNumber = "";
                        brandI.CvcLength = 3;
                        brandI.TestNumber = "6011000000000012";
                        brandI.EagerPattern = "^6(011(0[0-9]|[2-4]|74|7[7-9]|8[6-9]|9[0-9])|4[4-9]|5)";
                        brandI.GroupPattern = "(\\d{1,4})(\\d{1,4})?(\\d{1,4})?(\\d{1,4})?(\\d{1,3})?";
                        brandI.Mnemonic = "disc";
                        brandI.MaskArray = @"/[1-9]/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/";
                        brandI.CvcName = "CID";
                        break;
                }
                await _context.CreditCardBrands.AddAsync(brandI);
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        await _context.SaveChangesAsync();

    }
    private static async Task InitCuisines()
    {
        await _context.Cuisines.AddAsync(
            new Cuisine
            {
                Branch_Id = _context.Branches.First().Id,
                Name = "Pizzeria"
            });
        await _context.Cuisines.AddAsync(
             new Cuisine
             {
                 Branch_Id = _context.Branches.First().Id,
                 Name = "Deli"
             });

        await _context.SaveChangesAsync();

    }
    private static async Task InitLocales()
    {
        await _context.Locales.AddAsync(
            new Locale
            {
                Id = 1,
                Country_Id = _context.Countries.First(c => c.Code == "US").Id,
                CountryName = "USA",
                Language = "English",
                LocaleString = "en-US"
            });
        await _context.SaveChangesAsync();

    }
    private static async Task InitContractPeriods()
    {

        await _context.ContractPeriods.AddAsync(new ContractPeriod
        {
            Id = LongPeriod.Month,
            Discount = 0,
            Months = 1
        });
        await _context.ContractPeriods.AddAsync(new ContractPeriod
        {
            Id = LongPeriod.Semester,
            Discount = 10,
            Months = 6
        });
        await _context.ContractPeriods.AddAsync(new ContractPeriod
        {
            Id = LongPeriod.Annum,
            Discount = 20,
            Months = 12
        });
        await _context.SaveChangesAsync();
    }
    private static async Task InitCurrencies()
    {
        await _context.Currencies.AddAsync(new Currency()
        {
            Code = "USD",
            Name = "US Dollar",
            Short = "Dollar",
            Symbol = "$"
        }
        );

        await _context.SaveChangesAsync();
    }
    private static async Task InitCustomer()
    {

        var newUser = new Customer
        {
            Name = "Miguel Delgado",
            Email = _name,
            NormalizedEmail = _name.ToUpperInvariant(),
            UserName = _name,
            NormalizedUserName = _name.ToUpperInvariant(),
            PhoneNumber = "+7187209661",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            Gender = Gender.Male

        };

        var password = new PasswordHasher<Customer>();
        newUser.PasswordHash = password.HashPassword(newUser, _password);

        await _context.Customers.AddAsync(newUser);

        await _context.SaveChangesAsync();

    }
    private static async Task InitCountries()
    {
        //Trace.WriteLine("countries");

        //  This method will be called after migrating to the latest version.
        await _context.Countries.AddAsync(

            new Country
            {
                Code = "US",
                Name = "United States",
                Abbreviation = "U.S.",
                States = new List<State>
                {
                        new State
                        {
                            Code = "NY",
                            Name = "New York",
                            Abbreviation= "N.Y."
                        },
                        new State
                        {
                            Code = "CA",
                            Name = "California",
                            Abbreviation= "Cal."
                        },
                        new State
                        {
                            Code = "FL",
                            Name = "Florida",
                            Abbreviation= "Fla."
                        },
                        new State
                        {
                            Code = "MA",
                            Name = "Massachusets",
                            Abbreviation= "Mass"
                        },
                        new State
                        {
                            Code = "NJ",
                            Name = "New Jersey",
                            Abbreviation= "N.J."
                        },
                        new State
                        {
                            Code = "CT",
                            Name = "Connecticut",
                            Abbreviation= "Conn."
                        }
                }
            });

        await _context.SaveChangesAsync();
    }
    private static async Task InitBranches()
    {
        //Trace.WriteLine("Branches");
        //var active = new Status
        //{
        //    Is = true,
        //    Date =
        //    {
        //        Year = System.DateTime.Now.Year,
        //        Month = System.DateTime.Now.Month,
        //        Day = System.DateTime.Now.Day
        //    },
        //    Time =
        //    {
        //        Hour = System.DateTime.Now.Hour,
        //        Minute = System.DateTime.Now.Minute,
        //        Second = System.DateTime.Now.Second
        //    }
        //};

        //var proposed = new Status
        //{
        //    Is = false
        //};
        //var canceled = new Status
        //{
        //    Is = false
        //};
        //var config = new Config();

        //config.AppName = "PizzeriaGloria.zoeazy";


        await _context.Branches.AddAsync(
               new Branch
               {
                   Radius = 1,
                   Zoom = 14,
                   Name = "Pizzeria Gloria",
                   Franchise_Id = _context.Franchises.First().Id,
                   Secret = "1234567890",
                   
                   Active = true,
                   ActiveUtc = DateTimeOffset.Now,
                   AppName = "PizzeriaGloria.zoeazy",
                   State = InitialWebsiteState.New,
                   Redirection = Redirection.VerticalVirals
               });

        await _context.SaveChangesAsync();

        await _context.WebsiteNames.AddAsync(
            new WebsiteName
            {
                Domain = "PizzeriaGloria",
                Suffix = "com",
                Branch_Id =
                    _context.Branches.First().Id
            });
        var now = DateTimeOffset.Now;
        var until = now.AddMonths((int)LongPeriod.Annum);
        await _context.Contracts.AddAsync(new Contract
        {
            Branch_Id = _context.Branches.First().Id,
            Plan_Id = _context.Plans.First(p => p.Period_Id == LongPeriod.Annum).Id,
            Status = ContractStatus.Active,
        });

        await _context.SaveChangesAsync();
    }
    private static async Task InitFranchises()
    {
        //Trace.WriteLine("Franchises");

        await _context.Franchises.AddAsync(
            new Franchise
            {
                Name = "Pizzeria Gloria",
                Subscriber = _subscriber
            });
        await _context.SaveChangesAsync();

    }
    private static async Task InitPlans()
    {
        var from = new DateTimeOffset(new DateTime(2018, 01, 01), new TimeSpan(0));
        var to = new DateTimeOffset(new DateTime(2018, 12, 31), new TimeSpan(0));

        await _context.Plans.AddAsync(
            new Plan
            {
                Description = "Monthly charge",
                Title = "Monthly charge",
                Charge = 75,
                Discount = 0,
                SetupCharge = 90,
                SetupDiscount = 0,
                Currency_Id = _context.Currencies.First().Id,
                Period_Id = LongPeriod.Month,
                ValidFromUtc = null,
                ValidToUtc = null,
                DaysFree = DaysFree.zero
            });
        await _context.Plans.AddAsync(
             new Plan
             {

                 Description = "Monthly charge for Semester charge",
                 Title = "Monthly charge for Semester charge",
                 Charge = 50,
                 Discount = 0,
                 SetupCharge = 90,
                 SetupDiscount = 0,

                 Currency_Id = _context.Currencies.First().Id,
                 Period_Id = LongPeriod.Semester,
                 ValidFromUtc = null,
                 ValidToUtc = null,
                 DaysFree = DaysFree.zero
             });
        await _context.Plans.AddAsync(
             new Plan
             {
                 Description = "Monthly charge.",
                 Title = "Monthly charge.",
                 Charge = 35,
                 Discount = 0,
                 SetupCharge = 90,
                 SetupDiscount = 0,

                 Currency_Id = _context.Currencies.First().Id,
                 Period_Id = LongPeriod.Annum,
                 ValidFromUtc = null,
                 ValidToUtc = null,
                 DaysFree = DaysFree.zero
             });
        await _context.Plans.AddAsync(
            new Plan
            {
                Branch_Id = _context.Branches.First().Id,
                Description = "Monthly charge",
                Title = "Monthly charge",
                Charge = 70,
                Currency_Id = _context.Currencies.First().Id,
                Discount = 0,
                SetupCharge = 90,
                SetupDiscount = 0,
                Period_Id = LongPeriod.Month,
                ValidFromUtc = null,
                ValidToUtc = null,
                DaysFree = DaysFree.zero

            });
        await _context.Plans.AddAsync(
             new Plan
             {
                 Branch_Id = _context.Branches.First().Id,
                 Description = "Monthly charge. Paid every six months.",
                 Title = "Monthly charge. Paid every six months.",
                 Charge = 45,
                 Currency_Id = _context.Currencies.First().Id,
                 Period_Id = LongPeriod.Semester,
                 Discount = 0,
                 SetupCharge = 90,
                 SetupDiscount = 0,
                 ValidFromUtc = null,
                 ValidToUtc = null,
                 DaysFree = DaysFree.seven
             });
        await _context.Plans.AddAsync(
             new Plan
             {
                 Branch_Id = _context.Branches.First().Id,
                 Description = "Monthly charge. Paid once per year.",
                 Title = "Monthly charge. Paid once per year.",
                 Charge = 30,
                 Currency_Id = _context.Currencies.First().Id,
                 Discount = 0,
                 SetupCharge = 90,
                 SetupDiscount = 0,
                 Period_Id = LongPeriod.Annum,
                 ValidFromUtc = null,
                 ValidToUtc = null,
                 DaysFree = DaysFree.seven
             });
        await _context.Plans.AddAsync(
            new Plan
            {
                Franchise_Id = _context.Franchises.First().Id,
                Description = "Monthly charge",
                Title = "Monthly charge",
                Charge = 70,
                Discount = 0,
                SetupCharge = 90,
                SetupDiscount = 0,
                Currency_Id = _context.Currencies.First().Id,
                Period_Id = LongPeriod.Month,
                ValidFromUtc = null,
                ValidToUtc = null,
                DaysFree = DaysFree.seven

            });
        await _context.Plans.AddAsync(
             new Plan
             {
                 Franchise_Id = _context.Franchises.First().Id,
                 Description = "Monthly charge. Paid every six months.",
                 Title = "Monthly charge. Paid every six months.",
                 Charge = 45,
                 Discount = 0,
                 SetupCharge = 90,
                 SetupDiscount = 0,
                 Currency_Id = _context.Currencies.First().Id,
                 Period_Id = LongPeriod.Semester,
                 ValidFromUtc = null,
                 ValidToUtc = null,
                 DaysFree = DaysFree.seven
             });
        await _context.Plans.AddAsync(
             new Plan
             {
                 Franchise_Id = _context.Franchises.First().Id,
                 Description = "Monthly charge. Paid once per year.",
                 Title = "Monthly charge. Paid once per year.",
                 Charge = 30,
                 Discount = 0,
                 SetupCharge = 90,
                 SetupDiscount = 0,

                 Currency_Id = _context.Currencies.First().Id,
                 Period_Id = LongPeriod.Annum,
                 ValidFromUtc = null,
                 ValidToUtc = null,
                 DaysFree = DaysFree.seven
             });
        await _context.Plans.AddAsync(
            new Plan
            {
                ValidFromUtc = from,
                ValidToUtc = to,
                Description = "Monthly charge",
                Title = "Monthly charge",
                Charge = 65,
                Discount = 0,
                SetupCharge = 90,
                SetupDiscount = 0,

                Currency_Id = _context.Currencies.First().Id,
                Period_Id = LongPeriod.Month,
                DaysFree = DaysFree.seven

            });
        await _context.Plans.AddAsync(
             new Plan
             {
                 ValidFromUtc = from,
                 ValidToUtc = to,
                 Description = "Monthly charge. Paid every six months.",
                 Title = "Monthly charge. Paid every six months.",
                 Charge = 40,
                 Discount = 0,
                 SetupCharge = 90,
                 SetupDiscount = 0,

                 Currency_Id = _context.Currencies.First().Id,
                 Period_Id = LongPeriod.Semester,
                 DaysFree = DaysFree.seven
             });
        await _context.Plans.AddAsync(
             new Plan
             {
                 ValidFromUtc = from,
                 ValidToUtc = to,
                 Description = "Monthly charge. Paid once per year.",
                 Title = "Monthly charge. Paid once per year.",
                 Charge = 25,
                 Discount = 0,
                 SetupCharge = 90,
                 SetupDiscount = 0,

                 Currency_Id = _context.Currencies.First().Id,
                 Period_Id = LongPeriod.Annum,
                 DaysFree = DaysFree.seven
             });
        await _context.Plans.AddAsync(
            new Plan
            {
                Branch_Id = _context.Branches.First().Id,
                ValidFromUtc = from,
                ValidToUtc = to,
                Description = "Monthly charge",
                Title = "Monthly charge",
                Charge = 60,
                Discount = 0,
                SetupCharge = 90,
                SetupDiscount = 0,

                Currency_Id = _context.Currencies.First().Id,
                Period_Id = LongPeriod.Month,
                DaysFree = DaysFree.seven

            });
        await _context.Plans.AddAsync(
             new Plan
             {
                 Branch_Id = _context.Branches.First().Id,
                 ValidFromUtc = from,
                 ValidToUtc = to,
                 Description = "Monthly charge. Paid every six months.",
                 Title = "Monthly charge. Paid every six months.",
                 Charge = 30,
                 Discount = 0,
                 SetupCharge = 90,
                 SetupDiscount = 0,

                 Currency_Id = _context.Currencies.First().Id,
                 Period_Id = LongPeriod.Semester,
                 DaysFree = DaysFree.seven
             });
        await _context.Plans.AddAsync(
             new Plan
             {
                 Branch_Id = _context.Branches.First().Id,
                 ValidFromUtc = from,
                 ValidToUtc = to,
                 Description = "Monthly charge. Paid once per year.",
                 Title = "Monthly charge. Paid once per year.",
                 Charge = 20,
                 Discount = 0,
                 SetupCharge = 90,
                 SetupDiscount = 0,

                 Currency_Id = _context.Currencies.First().Id,
                 Period_Id = LongPeriod.Annum,
                 DaysFree = DaysFree.seven
             });
        await _context.Plans.AddAsync(
            new Plan
            {
                Franchise_Id = _context.Franchises.First().Id,
                ValidFromUtc = from,
                ValidToUtc = to,
                Description = "Monthly charge",
                Title = "Monthly charge",
                Charge = 60,
                Discount = 0,
                SetupCharge = 90,
                SetupDiscount = 0,

                Currency_Id = _context.Currencies.First().Id,
                Period_Id = LongPeriod.Month,
                DaysFree = DaysFree.seven

            });
        await _context.Plans.AddAsync(
             new Plan
             {
                 Franchise_Id = _context.Franchises.First().Id,
                 ValidFromUtc = from,
                 ValidToUtc = to,
                 Description = "Monthly charge. Paid every six months.",
                 Title = "Monthly charge. Paid every six months.",
                 Charge = 30,
                 Discount = 0,
                 SetupCharge = 90,
                 SetupDiscount = 0,

                 Currency_Id = _context.Currencies.First().Id,
                 Period_Id = LongPeriod.Semester,
                 DaysFree = DaysFree.seven
             });
        await _context.Plans.AddAsync(
             new Plan
             {
                 Franchise_Id = _context.Franchises.First().Id,
                 ValidFromUtc = from,
                 ValidToUtc = to,
                 Description = "Monthly charge. Paid once per year.",
                 Charge = 20,
                 Discount = 0,
                 SetupCharge = 90,
                 SetupDiscount = 0,
                 Title = "Monthly charge. Paid once per year.",
                 Currency_Id = _context.Currencies.First().Id,
                 Period_Id = LongPeriod.Annum,
                 DaysFree = DaysFree.seven
             });
        await _context.SaveChangesAsync();

    }
    private static async Task InitPredefinedSchedules()
    {
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Sunday,
                 Name = "sundays",
                 Service = ServiceStatus.Open,
                 OpensHour = Hour.h10,
                 OpensMinute = Quarter.f0,
                 ClosesHour = Hour.h22,
                 ClosesMinute = Quarter.f0
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Monday,
                 Name = "monday",
                 Service = ServiceStatus.Open,
                 OpensHour = Hour.h10,
                 OpensMinute = Quarter.f0,
                 ClosesHour = Hour.h22,
                 ClosesMinute = Quarter.f0
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Tuesday,
                 Name = "tuesday",
                 Service = ServiceStatus.Open,
                 OpensHour = Hour.h10,
                 OpensMinute = Quarter.f0,
                 ClosesHour = Hour.h22,
                 ClosesMinute = Quarter.f0
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Wednesday,
                 Name = "wednesday",
                 Service = ServiceStatus.Open,
                 OpensHour = Hour.h10,
                 OpensMinute = Quarter.f0,
                 ClosesHour = Hour.h22,
                 ClosesMinute = Quarter.f0
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Thursday,
                 Name = "thursday",
                 Service = ServiceStatus.Open,
                 OpensHour = Hour.h10,
                 OpensMinute = Quarter.f0,
                 ClosesHour = Hour.h22,
                 ClosesMinute = Quarter.f0
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Friday,
                 Name = "fridays",
                 Service = ServiceStatus.Open,
                 OpensHour = Hour.h10,
                 OpensMinute = Quarter.f0,
                 ClosesHour = Hour.h22,
                 ClosesMinute = Quarter.f0
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Saturday,
                 Name = "saturdays",
                 Service = ServiceStatus.Open,
                 OpensHour = Hour.h10,
                 OpensMinute = Quarter.f0,
                 ClosesHour = Hour.h1,
                 ClosesMinute = Quarter.f0,
                 CloseOfTheNextDay = true
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Jan1,
                 Name = "January 1st",
                 Day = DayOfMonth.mo1,
                 Month = Month.January
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Jul3,
                 Name = "July 3rd",
                 Day = DayOfMonth.mo3,
                 Month = Month.July,
                 Service = ServiceStatus.Open,
                 OpensHour = Hour.h10,
                 OpensMinute = Quarter.f0,
                 ClosesHour = Hour.h19,
                 ClosesMinute = Quarter.f0
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Jul4,
                 Name = "July 4th",
                 Day = DayOfMonth.mo4,
                 Month = Month.July
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.TGW,
                 Name = "T.Giving Wednesday",
                 Month = Month.November,
                 Service = ServiceStatus.Open,
                 OpensHour = Hour.h10,
                 OpensMinute = Quarter.f0,
                 ClosesHour = Hour.h19,
                 ClosesMinute = Quarter.f0
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.TGT,
                 Name = "T.Giving Thursday",
                 Month = Month.November
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.TGF,
                 Month = Month.November,
                 Name = "T.Giving Friday",
                 Service = ServiceStatus.Open,
                 OpensHour = Hour.h10,
                 OpensMinute = Quarter.f0,
                 ClosesHour = Hour.h22,
                 ClosesMinute = Quarter.f0
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.CrE,
                 Day = DayOfMonth.mo24,
                 Month = Month.December,
                 Name = "Chirstmas Eve",
                 Service = ServiceStatus.Open,
                 OpensHour = Hour.h10,
                 OpensMinute = Quarter.f0,
                 ClosesHour = Hour.h19,
                 ClosesMinute = Quarter.f0
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Crs,
                 Name = "Chirstmas Day",
                 Day = DayOfMonth.mo25,
                 Month = Month.December
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Dec31,
                 Name = "New Years Eve",
                 Day = DayOfMonth.mo31,
                 Month = Month.December,
                 Service = ServiceStatus.Open,
                 OpensHour = Hour.h10,
                 OpensMinute = Quarter.f0,
                 ClosesHour = Hour.h19,
                 ClosesMinute = Quarter.f0
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Yom,
                 Name = "Yom Kipur",
                 Optional = true,
                 Disable = true
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Dow = PredefinedDay.Ros,
                 Name = "Rosh Hassana",
                 Optional = true,
                 Disable = true
             });
        await _context.PredefinedSchedules.AddAsync(
             new PredefinedSchedule
             {
                 Optional = true,
                 Disable = true,
                 Dow = PredefinedDay.T247,
                 Name = "24 - 7",
                 OpensHour = Hour.h24,
                 OpensMinute = Quarter.f0,
                 ClosesHour = Hour.h24,
                 ClosesMinute = Quarter.f0
             });
        await _context.SaveChangesAsync();

    }
    private static async Task InitZipCodes()
    {
        var csv_file_path = @"./assets/US ZIP codes.csv";
        var csvData = new DataTable();
        try
        {
            char[] delimiters = new char[] { ',' };
            using (var reader = new StreamReader(csv_file_path))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    var parts = line.Split(delimiters);
                    var start = line.IndexOf('\"');
                    var polygon = string.Empty;

                    if (start > -1)
                    {
                        polygon = line.Substring(start + 1);
                        polygon = polygon.Substring(0, polygon.Length - 1);
                    }

                    var state = _context.States.FirstOrDefault(s => s.Code == parts[6].ToString());
                    if (state != null)
                    {
                        await _context.ZipCodes.AddAsync(new ZipCode
                        {
                            Name = parts[2].ToString(),
                            Zip = Convert.ToInt32(parts[3].ToString()),
                            Latitude = Convert.ToDouble(parts[4].ToString()),
                            Longitude = Convert.ToDouble(parts[9].ToString()),
                            PopulationAt2001 = Convert.ToInt32(parts[5].ToString()),
                            State_Id = state.Id,
                            Area = Convert.ToDouble(parts[7].ToString()),

                            Sumblkpop = Convert.ToInt32(parts[10].ToString()),
                            Geometry = polygon
                        });

                    }

                }
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {

        }

    }

}