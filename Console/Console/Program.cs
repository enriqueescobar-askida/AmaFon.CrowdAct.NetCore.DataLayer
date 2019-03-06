namespace Console
{
    using System;
    using DataLayer.Contexts;
    using DataLayer;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello CrowdAct!");
            CrowdActDbContext crowdActDbContext = new CrowdActDbContext();

            crowdActDbContext.Countries.AddRange(GetCountries());
            Console.WriteLine("All in database: " + crowdActDbContext.SaveChanges(true));
            foreach (Country country in crowdActDbContext.Countries)
                Console.WriteLine(" - {0}", country.Label);

            crowdActDbContext.Categories.AddRange(GetCategories());
            Console.WriteLine("All in database: " + crowdActDbContext.SaveChanges(true));
            foreach (Category category in crowdActDbContext.Categories)
                Console.WriteLine(" - {0}", category.Label);

            crowdActDbContext.Languages.AddRange(GetLanguages());
            Console.WriteLine("All in database: " + crowdActDbContext.SaveChanges(true));
            foreach (Language language in crowdActDbContext.Languages)
                Console.WriteLine(" - {0}", language.Label);
        }

        #region aRegion
        static Country[] GetCountries()
        {
            Country cn = new Country { Label = "China",  Active = true, Disabled = false };
            Country fr = new Country { Label = "France", Active = true, Disabled = false };
            Country ge = new Country { Label = "Germany", Active = true, Disabled = false };
            Country md = new Country { Label = "Madagascar", Active = true, Disabled = false };
            Country sp = new Country { Label = "Spain", Active = true, Disabled = false };
            Country uk = new Country { Label = "United Kingdom", Active = true, Disabled = false };
            Country vi = new Country { Label = "Vietnam", Active = true, Disabled = false };

            return new Country[] { cn, fr, ge, md, sp, uk, vi };
        }

        static Category[] GetCategories()
        {
            Category edu = new Category { Label = "Education" };
            Category emp = new Category { Label = "Employment" };
            Category hel = new Category { Label = "Health" };

            return new Category[] { edu, emp, hel };
        }
        #endregion

        static Language[] GetLanguages()
        {
            Language c = new Language { Label = "Chinese", Active = true, Disabled = false };
            Language e = new Language { Label = "English", Active = true, Disabled = false };
            Language f = new Language { Label = "French", Active = true, Disabled = false };
            Language v = new Language { Label = "Vietnamese", Active = true, Disabled = false };

            return new Language[] { c };
        }

        static AccountStatus[] GetAccountStatuses()
        {
            AccountStatus a = new AccountStatus { Label = "Accepted" };
            AccountStatus p = new AccountStatus { Label = "Pending" };
            AccountStatus r = new AccountStatus { Label = "Refused" };

            return new AccountStatus[] { a, p, r };
        }

        static ResourceType[] GetResourceTypes()
        {
            ResourceType ma = new ResourceType { Label = "Material" };
            ResourceType mo = new ResourceType { Label = "Money" };
            ResourceType pe = new ResourceType { Label = "Persons" };
            ResourceType sk = new ResourceType { Label = "Skills" };

            return new ResourceType[] { ma, mo, pe, sk };
        }

        static ParticipantStatus[] GetParticipantStatuses()
        {
            ParticipantStatus a = new ParticipantStatus { Label = "Accepted" };
            ParticipantStatus o = new ParticipantStatus { Label = "On Waiting List" };
            ParticipantStatus r = new ParticipantStatus { Label = "Refused" };

            return new ParticipantStatus[] { a, o, r };
        }

        static ActivityType[] GetActivityTypes()
        {
            ActivityType c = new ActivityType { Label = "Collection" };
            ActivityType e = new ActivityType { Label = "Event" };

            return new ActivityType[]{ };
        }

        static Skill[] GetSkills()
        {
            Skill g = new Skill { Label = "Good communicator" };
            Skill p = new Skill { Label = "Proactive" };
            Skill m = new Skill { Label = "Motivated" };

            return new Skill[] { g, p, m };
        }
    }
}
