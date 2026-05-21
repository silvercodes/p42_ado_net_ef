
#region CREATE

//using _01_crud;

//using Db db = new Db();

//db.Users.AddRange(
//    new User() { Email = "vasia@mail.com", Password = "123123123"},    
//    new User() { Email = "petya@mail.com", Password = "123123123"},    
//    new User() { Email = "dima@mail.com", Password = "123123123"} 
//);

//db.SaveChanges();

#endregion

#region READ

//using _01_crud;

//using Db db = new Db();

//List<User> users =  db.Users.Where(u => u.Id > 1).ToList();
//users.ForEach(Console.WriteLine);


//IQueryable<User> users = db.Users.Where(u => u.Id > 1);
//foreach (User user in users)
//    Console.WriteLine(user);

#endregion

#region UPDATE

using _01_crud;

//using Db db = new Db();

//User? user = db.Users.FirstOrDefault(u => u.Id == 3);

//if (user is not null)
//{
//    user.Email = "aaabbbccc@mail.com";
//    user.Password = "0987654321";

//    db.SaveChanges();
//}





//User? user = null;

//using (Db db = new Db())
//{
//    user = db.Users.FirstOrDefault(u => u.Id == 3);
//}

//user.Email = "test@mail.com";

//using (Db db = new Db())
//{
//    // user.Id = 0;
//    // db.Users.Add(user);
//    db.Update(user);
//    db.SaveChanges();
//}

#endregion

#region DELETE

using Db db = new Db();

User? user = db.Users.FirstOrDefault(u => u.Id == 3);

if (user is not null)
{
    db.Users.Remove(user);
}

db.SaveChanges();

#endregion


