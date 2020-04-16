using ExamSyllabus.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;

namespace ExamSyllabus.Model
{
    /// <summary>
    /// This class represents the Subject table.
    /// </summary>
    public class SubjectModel : BaseModel
    {
        public string SubjectName { get; set; }

        /// <summary>
        /// This method is used to bind subjects to the control of type list such as ListBox and ComboBox.
        /// </summary>
        /// <param name="control">Takes a control to bind data to it.</param>
        public void Binder(ListControl control)
        {
            IDataService<SubjectModel> subjectService = new DataService<SubjectModel>();
            var subjectData = subjectService.GetRecords(DatabaseTable.Subject);

            // Convert datatable data to a list, sort it by name.
            List<SubjectModel> modelData = (from DataRow row in subjectData.Rows
                                            select new SubjectModel
                                            {
                                                Deleted = Convert.ToBoolean(row[TableColumns.COMMON_DELETED]),
                                                Id = Convert.ToInt32(row[TableColumns.COMMON_ID]),
                                                SubjectName = row[TableColumns.SUBJECT_SUBJECT_NAME].ToString()
                                            })
                                         .ToList();

            modelData = modelData.OrderBy(x => x.SubjectName).ToList();

            // First record as default record.
            modelData.Insert(0, new SubjectModel
            {
                Id = -1,
                Deleted = false,
                SubjectName = "--SELECT SUBJECT--"
            });

            control.DataSource = modelData;
            control.DisplayMember = TableColumns.SUBJECT_SUBJECT_NAME;
            control.ValueMember = TableColumns.COMMON_ID;
        }
    }
}
