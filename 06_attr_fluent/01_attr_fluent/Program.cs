
using _01_attr_fluent;
using Microsoft.EntityFrameworkCore;

//using Db db = new Db();

//User user = new User()
//{
//    Email = "vasia@mail.com",
//    Age = 23,
//};
//Role role = new Role()
//{
//    Title = "admin",
//};

//db.Users.Add(user);
//db.Roles.Add(role);

////
////
//user.Token = Guid.NewGuid().ToString();
//user.Role = role;
////
////
//Console.WriteLine(user.Token);
////
////
//db.SaveChanges();



using Db db = new Db();

//User user = db.Users
//    .Include(u => u.Role)
//    .First(u => u.Id == 1);

//Console.WriteLine(user.Role?.Title);



//User user = db.Users.First(u => u.Id == 1);
////
////
//db.Entry(user).Reference(u => u.Role).Load();

//Console.WriteLine(user.Role?.Title);


