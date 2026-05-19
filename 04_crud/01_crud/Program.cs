
#region CREATE

using _01_crud;

using Db db = new Db();

db.Users.AddRange(
    new User() { Email = "vasia@mail.com", Password = "123123123"},    
    new User() { Email = "petya@mail.com", Password = "123123123"},    
    new User() { Email = "dima@mail.com", Password = "123123123"} 
);

db.SaveChanges();

#endregion

#region READ






#endregion

#region UPDATE

#endregion

#region DELETE

#endregion


