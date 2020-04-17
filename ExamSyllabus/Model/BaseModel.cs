using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace ExamSyllabus.Model
{
    /// <summary>
    /// This is the base model for all the database models.
    /// </summary>
    public abstract class BaseModel
    {
        public int Id { get; set;  }
        public bool Deleted { get; set; }

        /// <summary>
        /// This method is used to get a list of all selected exams.
        /// </summary>
        /// <returns></returns>
        public List<int> GetSelectedIds(ListBox control)
        {
            List<int> ids = control
                .SelectedItems
                .Cast<BaseModel>()
                .ToList()
                .Where(x => x.Id != -1)
                .Select(x => x.Id)
                .ToList();

            return ids;
        }
    }
}
