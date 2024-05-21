using EFDemo1.Data;

namespace EFDemo1.Models
{
    public class StudentDAL
    {
        private ApplicationDbContext db;
        public StudentDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Student> GetStudent()
        {
            // LINQ
            //var model=(from emp in db.Employees
            //          select emp).ToList();

            //return model;

            // Lambda experssion

            return db.Students.ToList();
        }
        public Student GetStudentById(int id)
        {
            //LINQ

            //var model = (from emp in db.Employees 
            //            where emp.Id == id 
            //            select emp).FirstOrDefault();

            //return model;

            //lambda

            var model = db.Students.Where(x => x.Id == id).SingleOrDefault();
            return model;
        }
        public int AddStudent(Student std)
        {
            int result = 0;
            // add object in DbSet
            db.Students.Add(std); // Add method will add emp object in DbSet
            //update the changes in DB
            result = db.SaveChanges(); // SaveChanges() reflect the changes from DbSet to DB
            return result;
        }
        public int EditStudent(Student std) // emp object has new data
        {
            int result = 0;
            var model = db.Students.Where(x => x.Id == std.Id).SingleOrDefault();
            if (model != null)
            {
                model.Name = std.Name; // model will hold old data
                model.City = std.City;
                model.Percentage= std.Percentage;
                result = db.SaveChanges();

            }
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            var model = db.Students.Where(x => x.Id == id).SingleOrDefault();
            if (model != null)
            {
                // remove from dbSet
                db.Students.Remove(model);
                result = db.SaveChanges();
            }
            return result;
        }

    }
}
