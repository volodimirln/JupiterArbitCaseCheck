using JupiterWebAPI.Models;

namespace JupiterWebAPI.Services
{
    public class Repository
    {
        public Repository() 
        {
            if (JupiterContext.GetContext().Roles.FirstOrDefault() == null)
            {
                JupiterContext.GetContext().Roles.Add(new Role() { Title= "Aдминистратор" });
                JupiterContext.GetContext().Roles.Add(new Role() { Title= "Менеджер" });
                JupiterContext.GetContext().SaveChanges();

            }
            if (JupiterContext.GetContext().Users.FirstOrDefault() == null)
            {
                JupiterContext.GetContext().Users.Add(new User() {  Name = "Олеся", Surname = "Мартынова", Patronymic = "Егоровна", Phone ="78570374758", Email ="martinova@jupiter.com", RoleId = 1, DataChange = DateOnly.FromDateTime(DateTime.Now), DateRegistration = DateOnly.FromDateTime(DateTime.Now) });
                JupiterContext.GetContext().Users.Add(new User() {  Name = "Виолетта", Surname = "Шаповалова", Patronymic = "Данииловна", Phone = "78570372540", Email = "shapavola@jupiter.com", RoleId = 2, DataChange = DateOnly.FromDateTime(DateTime.Now), DateRegistration = DateOnly.FromDateTime(DateTime.Now) });
                JupiterContext.GetContext().Users.Add(new User() {  Name = "Василиса", Surname = "Бычкова", Patronymic = "Тимофеевна", Phone = "78570379510", Email = "bikovaa@jupiter.com", RoleId = 1, DataChange = DateOnly.FromDateTime(DateTime.Now), DateRegistration = DateOnly.FromDateTime(DateTime.Now) });
                JupiterContext.GetContext().Users.Add(new User() {  Name = "Тимур", Surname = "Шилов", Patronymic = "Александрович", Phone = "78570370653", Email = "shilov@jupiter.com", RoleId = 2, DataChange = DateOnly.FromDateTime(DateTime.Now), DateRegistration = DateOnly.FromDateTime(DateTime.Now) });
                JupiterContext.GetContext().Users.Add(new User() {  Name = "Арина", Surname = "Балашова", Patronymic = "Константиновна", Phone = "78570373754", Email = "balashova@jupiter.com", RoleId = 1, DataChange = DateOnly.FromDateTime(DateTime.Now), DateRegistration = DateOnly.FromDateTime(DateTime.Now) });
                JupiterContext.GetContext().SaveChanges();
            }
            if (JupiterContext.GetContext().Passwords.FirstOrDefault() == null)
            {
                //dgd$5gdre24WFd + ids78dn
                JupiterContext.GetContext().Passwords.Add(new Password() { Status = true, UserId = 1, DateAdd = DateOnly.FromDateTime(DateTime.Now) , HashPassword = "b423430d7f607222cbef2d767f60b340" });
                JupiterContext.GetContext().Passwords.Add(new Password() { Status = true, UserId = 2, DateAdd = DateOnly.FromDateTime(DateTime.Now) , HashPassword = "b423430d7f607222cbef2d767f60b340" });
                JupiterContext.GetContext().Passwords.Add(new Password() { Status = true, UserId = 3, DateAdd = DateOnly.FromDateTime(DateTime.Now) , HashPassword = "b423430d7f607222cbef2d767f60b340" });
                JupiterContext.GetContext().Passwords.Add(new Password() { Status = true, UserId = 4, DateAdd = DateOnly.FromDateTime(DateTime.Now) , HashPassword = "b423430d7f607222cbef2d767f60b340" });
                JupiterContext.GetContext().Passwords.Add(new Password() { Status = true, UserId = 5, DateAdd = DateOnly.FromDateTime(DateTime.Now) , HashPassword = "b423430d7f607222cbef2d767f60b340" });
                JupiterContext.GetContext().SaveChanges();
            }
            if (JupiterContext.GetContext().Cities.FirstOrDefault() == null)
            {
                JupiterContext.GetContext().Cities.Add(new City() { Court = "АС Краснодарского края", Name = "KRASNODAR" });
                JupiterContext.GetContext().Cities.Add(new City() { Court = "АС Ростовской области", Name = "ROSTOV" });
                JupiterContext.GetContext().Cities.Add(new City() { Court = "АС Ставропольского края", Name = "STAVROPOL" });
                JupiterContext.GetContext().Cities.Add(new City() { Court = "АС Республики Крым", Name = "KRYM" });
                JupiterContext.GetContext().SaveChanges();
            }
            if (JupiterContext.GetContext().FavorieCases.FirstOrDefault() == null)
            {
                JupiterContext.GetContext().FavorieCases.Add(new FavorieCase() { Court = "test1", CaseNumber = "test1", Date="20-02-2020", Judge = "test", Plaintiff = "test", Respondent = "test" });
                JupiterContext.GetContext().FavorieCases.Add(new FavorieCase() { Court = "test2", CaseNumber = "test2", Date = "20-02-2020", Judge = "test", Plaintiff = "test", Respondent = "test" });
                JupiterContext.GetContext().FavorieCases.Add(new FavorieCase() { Court = "test3", CaseNumber = "test3", Date = "20-02-2020", Judge = "test", Plaintiff = "test", Respondent = "test" });
                JupiterContext.GetContext().FavorieCases.Add(new FavorieCase() { Court = "test4", CaseNumber = "test4", Date = "20-02-2020", Judge = "test", Plaintiff = "test", Respondent = "test" });
                JupiterContext.GetContext().FavorieCases.Add(new FavorieCase() { Court = "test5", CaseNumber = "test5", Date = "20-02-2020", Judge = "test", Plaintiff = "test", Respondent = "test" });
                JupiterContext.GetContext().SaveChanges();
            }
        }
    }
}
