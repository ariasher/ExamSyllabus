namespace ExamSyllabus.Model
{
    /// <summary>
    /// This is the base model for all the database models.
    /// </summary>
    public abstract class BaseModel
    {
        public int Id { get; set;  }
        public bool Deleted { get; set; }
    }
}
